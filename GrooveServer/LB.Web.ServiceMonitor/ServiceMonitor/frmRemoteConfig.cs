using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using LB.RMT.Base;

namespace LB.Web.ServiceMonitor
{
	public partial class frmRemoteConfig : Form
	{
		private frmServerForm _serverForm;

		public frmRemoteConfig( frmServerForm form )
		{
			InitializeComponent();

			_serverForm = form;
			this.Width = 300;
			txtServiceName.LostFocus += txtServiceName_LostFocus;
		}

		private void frmRemoteConfig_Load( object sender, EventArgs e )
		{
			try
			{
                

                this.txtMachineName.Text = System.Environment.MachineName;

				IPHostEntry ihe = Dns.GetHostByName( Dns.GetHostName() );
				string strIP = "";
				for( int i = 0, j = ihe.AddressList.Length; i < j; i++ )
				{
					IPAddress myself = ihe.AddressList[i];

					strIP += ( strIP == "" ? "" : "/" ) + myself.ToString();
				}

				this.txtIP.Text = strIP;
				this.txtPort.Text = LB.RMT.Base.ConfigHelper.Port.ToString();

                this.txtDBUser.Text = LB.RMT.Base.ConfigHelper.DBUser;
                this.txtDBPW.Text = LB.RMT.Base.ConfigHelper.DBPW;
                this.txtLoginSecure.SelectedIndex = LB.RMT.Base.ConfigHelper.LoginSecure ? 1 : 0;

                //�ͻ��˵�¼����
                //ǿ�ƾ�����ģʽ
                //ǿ�ƻ�����ģʽ
                string strRemotingForceMode= "ǿ�ƻ�����ģʽ";
                if (LB.RMT.Base.ConfigHelper.RemotingForceMode == 1)
                {
                    strRemotingForceMode = "ǿ�ƾ�����ģʽ";
                }
                else if (LB.RMT.Base.ConfigHelper.RemotingForceMode == 2)
                {
                    strRemotingForceMode = "ǿ�ƻ�����ģʽ";
                }
                else
                {
                    strRemotingForceMode = "�ͻ��˵�¼����";
                }
                lstRemotingForceMode.Text = strRemotingForceMode;
			}
			catch( Exception err )
			{
				MonitorHelper.DealWithError( err );
			}
		}

		private void btnConfirm_Click( object sender, EventArgs e )
		{
			try
			{
				int iPort = 0;
				try
				{
					iPort = Convert.ToInt32( this.txtPort.Text );
				}
				catch
				{
					throw new Exception( "<�˿ں�>����Ϊ��Ч����ֵ����Χ1��65535����" );
				}
				if( iPort < 1 || iPort > 65535 )
				{
					throw new Exception( "<�˿ں�>����Ϊ��Ч����ֵ����Χ1��65535����" );
				}

				bool bChanged = false;
				string strRMTChannel = 1.ToString();

				//�ͻ��˵�¼����
				//ǿ�ƾ�����ģʽ
				//ǿ�ƻ�����ģʽ
				int iRemotingForceMode = 0;
				string strRemotingForceMode = lstRemotingForceMode.Text.Trim();
				if( strRemotingForceMode == "ǿ�ƾ�����ģʽ" )
				{
					iRemotingForceMode = 1;
				}
				else if( strRemotingForceMode == "ǿ�ƻ�����ģʽ" )
				{
					iRemotingForceMode = 2;
				}
				else
				{
					iRemotingForceMode = 0;
				}

				if( iPort != LB.RMT.Base.ConfigHelper.Port ||
					//strRMTChannel != LB.Web.Base.ConfigHelper.RMTChannel ||
					iRemotingForceMode != LB.RMT.Base.ConfigHelper.RemotingForceMode ||
                    this.txtDBUser.Text != LB.RMT.Base.ConfigHelper.DBUser||
                    this.txtDBPW.Text!= LB.RMT.Base.ConfigHelper.DBPW||
                    (this.txtLoginSecure.SelectedIndex == 0 ? false : true)!= ConfigHelper.LoginSecure||
                    this.txtServiceName.Text!= ConfigHelper.ServiceName)
				{
					bChanged = true;
				}

				if( !bChanged )
				{
					MonitorHelper.ShowNormalMessage( "��������û�и��ġ�" );
					return;
				}

				// ���ԭ�����������У�����ֹͣ
				_serverForm.Stop();

				// �����µ�����
				//ConfigHelper.RMTChannel = strRMTChannel;
				ConfigHelper.Port = iPort;
				ConfigHelper.ServiceName = this.txtServiceName.Text.Trim();
				ConfigHelper.RemotingForceMode = iRemotingForceMode;
                ConfigHelper.DBUser = this.txtDBUser.Text;
                ConfigHelper.DBPW = this.txtDBPW.Text;
                ConfigHelper.LoginSecure = this.txtLoginSecure.SelectedIndex == 0 ? false : true;

                // д��������
                ConfigHelper.WriteIniConfig();

				// �������з���
				_serverForm.Start();

				// �ɹ���ʾ
				MonitorHelper.ShowNormalMessage( LB.RMT.Base.ConfigHelper.ServiceURL + Environment.NewLine + "���������С�" );

				this.Close();
			}
			catch( Exception err )
			{
				MonitorHelper.DealWithError( err );
			}
		}

		private void btnCancel_Click( object sender, EventArgs e )
		{
			try
			{
				this.Close();
			}
			catch( Exception err )
			{
				MonitorHelper.DealWithError( err );
			}
		}

		#region �޸ķ���������װж�ط���
		private string mstrPath = string.Empty;

		private ServiceTool.ServiceHelper _sh_M3 = null;
		private ServiceTool.ServiceHelper _sh_WebAutoUpdate = null;
		private ServiceTool.ServiceHelper _sh_DBAutoBackUp = null;

		private string _strService_M3 = string.Empty;
		private string _strService_WebAutoUpdate = string.Empty;
		private string _strService_DBAutoBackUp = string.Empty;

		private string _strServicePath_M3 = string.Empty;
		private string _strServicePath_WebAutoUpdate = string.Empty;
		private string _strServicePath_DBAutoBackUp = string.Empty;

		private void InitService()
		{
			LB.RMT.Base.ConfigHelper.ReadIniConfig();

			// ��������
			_strService_M3 = LB.RMT.Base.ConfigHelper.ServiceName;
			_strService_WebAutoUpdate = _strService_M3 + "_WebAutoUpdate";
			_strService_DBAutoBackUp = _strService_M3 + "_DBAutoBackUp";

			txtServiceName.Text = _strService_M3;

			// ����·��
			mstrPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			mstrPath = mstrPath.Substring( 0, mstrPath.LastIndexOf( @"\" ) );	// ȥ���ļ������õ�Ŀ¼
			mstrPath += ( mstrPath.EndsWith( @"\" ) ? "" : @"\" );

			_strServicePath_M3 = mstrPath + "LB.Web.Server.exe";
			_strServicePath_WebAutoUpdate = mstrPath + @"WebAutoUpdate\TS.DWWeb.WebAutoUpdateServer.exe";
			_strServicePath_DBAutoBackUp = mstrPath + @"ServerBak\TS.ServerBak.DBAutoBackUpServer.exe";

			// ������������
			_sh_M3 = new ServiceTool.ServiceHelper( _strService_M3, _strServicePath_M3 );
			_sh_WebAutoUpdate = new ServiceTool.ServiceHelper( _strService_WebAutoUpdate, _strServicePath_WebAutoUpdate );
			_sh_DBAutoBackUp = new ServiceTool.ServiceHelper( _strService_DBAutoBackUp, _strServicePath_DBAutoBackUp );
		}

		private void btnInstall_Click( object sender, EventArgs e )
		{
			try
			{
				if( this.Width == 300 )
				{
					this.Width = 680;
					btnInstall.Text = "��װ����<<";

					InitService();
					BindServices();
				}
				else
				{
					this.Width = 300;
					btnInstall.Text = "��װ����>>";
				}
			}
			catch( Exception err )
			{
				MonitorHelper.DealWithError( err );
			}
		}

		private void BindServices()
		{
			clbService.Items.Clear();
			clbService.Items.Add( string.Format( "M3������({0})", _strService_M3 ) );
			clbService.SetItemChecked( 0, !_sh_M3.ExistsService() );

			//if( LB.RMT.Base.ConfigHelper.WithUpdateService )
			//{
			//	clbService.Items.Add( string.Format( "�Զ����·���({0})", _strService_WebAutoUpdate ) );
			//	clbService.SetItemChecked( 1, !_sh_WebAutoUpdate.ExistsService() );
			//}
			//if( LB.Web.Base.ConfigHelper.WithBackupService )
			//{
			//	clbService.Items.Add( string.Format( "�Զ����ݷ���({0})", _strService_DBAutoBackUp ) );
			//	clbService.SetItemChecked( clbService.Items.Count - 1, !_sh_DBAutoBackUp.ExistsService() );
			//}
		}

		private void btnInstallSure_Click( object sender, EventArgs e )
		{
			try
			{
				string strServiceName = txtServiceName.Text.Trim();
				if( strServiceName != LB.RMT.Base.ConfigHelper.ServiceName )
				{
					if( MonitorHelper.ShowConfirmMessage( "�޸ķ������������°�װ���з����Ƿ������" ) != System.Windows.Forms.DialogResult.Yes )
						return;
				}

				string strMsg = SaveInstallServices();
				if( !string.IsNullOrWhiteSpace( strMsg ) )
				{
					MonitorHelper.ShowNormalMessage( strMsg );
				}
				else
				{
					MonitorHelper.ShowNormalMessage( "���沢��װ�������" );
				}
			}
			catch( Exception err )
			{
				MonitorHelper.DealWithError( err );
			}
		}

		private string SaveInstallServices()
		{
			string strServiceName = txtServiceName.Text.Trim();
			if( strServiceName == string.Empty )
			{
				return "����������Ϊ��";
			}

			StringBuilder sbMsg = new StringBuilder();

			bool bChangeServiceName = strServiceName != LB.RMT.Base.ConfigHelper.ServiceName;

			string strServiceName_Old = LB.RMT.Base.ConfigHelper.ServiceName;

			try
			{
				LB.RMT.Base.ConfigHelper.ServiceName = strServiceName;
				LB.RMT.Base.ConfigHelper.WriteIniConfig();
				LB.RMT.Base.ConfigHelper.ReadIniConfig();
			}
			catch( Exception ex )
			{
				sbMsg.Append( ex.Message );
				sbMsg.AppendLine();
				return sbMsg.ToString();
			}

			string strName = string.Empty;
			try
			{
				for( int i = 0; i < clbService.Items.Count; i++ )
				{
					string item = clbService.Items[i].ToString();

					string strService = string.Empty;
					ServiceTool.ServiceHelper sh_New;
					ServiceTool.ServiceHelper sh_Old;

					if( item.StartsWith( "M3������" ) )
					{
						strName = "M3������";
						strService = LB.RMT.Base.ConfigHelper.ServiceName;
						sh_Old = _sh_M3;
						sh_New = new ServiceTool.ServiceHelper( strService, _strServicePath_M3 );
					}
					else if( item.StartsWith( "�Զ����·���" ) )
					{
						strName = "�Զ����·���";
						strService = LB.RMT.Base.ConfigHelper.ServiceName + "_WebAutoUpdate";
						sh_Old = _sh_WebAutoUpdate;
						sh_New = new ServiceTool.ServiceHelper( strService, _strServicePath_WebAutoUpdate );
					}
					else if( item.StartsWith( "�Զ����ݷ���" ) )
					{
						strName = "�Զ����ݷ���";
						strService = LB.RMT.Base.ConfigHelper.ServiceName + "_DBAutoBackUp";
						sh_Old = _sh_DBAutoBackUp;
						sh_New = new ServiceTool.ServiceHelper( strService, _strServicePath_DBAutoBackUp );
					}
					else
						continue;

					bool b = clbService.GetItemChecked( i );

					if( bChangeServiceName || sh_Old.ServiceName != sh_New.ServiceName )    // �޸��˷����������з���Ӧ�����°�װ 
					{
						if( sh_Old.ExistsService() )
						{
							sh_Old.Uninstall();
							sh_New.Install();
							sh_New.StartService();
						}
						else if( b )
						{
							sh_New.Install();
							sh_New.StartService();
						}

						if( item.StartsWith( "M3������" ) )
						{
							_sh_M3 = sh_New;
							_strService_M3 = strService;
						}
						else if( item.StartsWith( "�Զ����·���" ) )
						{
							_sh_WebAutoUpdate = sh_New;
							_strService_WebAutoUpdate = strService;
						}
						else if( item.StartsWith( "�Զ����ݷ���" ) )
						{
							_sh_DBAutoBackUp = sh_New;
							_strService_DBAutoBackUp = strService;
						}
					}
					else
					{
						if( !b )
							continue;

						if( sh_New.ExistsService() )
							continue;

						sh_New.Install();
						sh_New.StartService();

						if( item.StartsWith( "M3������" ) )
						{
							_sh_M3 = sh_New;
							_strService_M3 = strService;
						}
						else if( item.StartsWith( "�Զ����·���" ) )
						{
							_sh_WebAutoUpdate = sh_New;
							_strService_WebAutoUpdate = strService;
						}
						else if( item.StartsWith( "�Զ����ݷ���" ) )
						{
							_sh_DBAutoBackUp = sh_New;
							_strService_DBAutoBackUp = strService;
						}
					}
				}
			}
			catch( Exception ex )
			{
				sbMsg.Append( string.Format( "����{0}����װʧ�ܣ�{1}", strName, ex.Message ) );
				sbMsg.AppendLine();
			}

			return sbMsg.ToString();
		}

		private void txtServiceName_LostFocus( object sender, EventArgs e )
		{
			try
			{
				string strServiceName = txtServiceName.Text.Trim();

				Dictionary<string, bool> dictItems = new Dictionary<string, bool>( 0 );
				for( int i = 0; i < clbService.Items.Count; i++ )
				{
					string item = clbService.Items[i].ToString();
					dictItems.Add( item, clbService.GetItemChecked( i ) );
				}

				clbService.Items.Clear();
				foreach( string item in dictItems.Keys )
				{
					if( item.StartsWith( "M3������" ) )
					{
						clbService.Items.Add( string.Format( "M3������({0})", strServiceName ), dictItems[item] );
					}
					else if( item.StartsWith( "�Զ����·���" ) )
					{
						clbService.Items.Add( string.Format( "�Զ����·���({0}_{1})", strServiceName, "WebAutoUpdate" ),
							dictItems[item] );
					}
					else if( item.StartsWith( "�Զ����ݷ���" ) )
					{
						clbService.Items.Add( string.Format( "�Զ����ݷ���({0}_{1})", strServiceName, "DBAutoBackUp" ),
							dictItems[item] );
					}
				}
			}
			catch( Exception err )
			{
				MonitorHelper.DealWithError( err );
			}
		}

		private void btnUnInstall_Click( object sender, EventArgs e )
		{
			try
			{
				if( clbService.CheckedItems.Count == 0 )
				{
					MonitorHelper.ShowNormalMessage( "����ѡ��Ҫжװ�ķ���" );
					return;
				}

				if( MonitorHelper.ShowConfirmMessage( "ȷ��ж��ѡ��ķ���" ) != System.Windows.Forms.DialogResult.Yes )
					return;

				List<ServiceTool.ServiceHelper> lsService = new List<ServiceTool.ServiceHelper>( 0 );
				for( int i = 0; i < clbService.Items.Count; i++ )
				{
					bool b = clbService.GetItemChecked( i );
					if( !b )
						continue;

					string item = clbService.Items[i].ToString();

					if( item.StartsWith( "M3������" ) )
					{
						lsService.Add( _sh_M3 );
					}
					else if( item.StartsWith( "�Զ����·���" ) )
					{
						lsService.Add( _sh_WebAutoUpdate );
					}
					else if( item.StartsWith( "�Զ����ݷ���" ) )
					{
						lsService.Add( _sh_DBAutoBackUp );
					}
				}

				foreach( ServiceTool.ServiceHelper service in lsService )
				{
					service.Uninstall();
				}

				MonitorHelper.ShowNormalMessage( "жװ�������" );
			}
			catch( Exception err )
			{
				MonitorHelper.DealWithError( err );
			}
		}

		#endregion �޸ķ���������װж�ط���

		private void btnTestRun_Click( object sender, EventArgs e )
		{
			try
			{
				if( clbService.CheckedItems.Count == 0 )
				{
					MonitorHelper.ShowNormalMessage( "����ѡ��Ҫ���������ķ���" );
					return;
				}

				string path = Application.StartupPath;
				for( int i = 0; i < clbService.Items.Count; i++ )
				{
					bool b = clbService.GetItemChecked( i );
					if( !b )
						continue;

					string item = clbService.Items[i].ToString();

					if( item.StartsWith( "M3������" ) )
					{
						RunDev( Path.Combine( path, "LB.Web.Server.exe" ) );
					}
					else if( item.StartsWith( "�Զ����·���" ) )
					{
						//lsService.Add( _sh_WebAutoUpdate );
					}
					else if( item.StartsWith( "�Զ����ݷ���" ) )
					{
						RunDev( Path.Combine( path, "ServerBak\\TS.ServerBak.ServiceDev.exe" ) );
					}
				}
			}
			catch( Exception err )
			{
				MonitorHelper.DealWithError( err );
			}
		}

		private void RunDev( string exeName )
		{
			using( System.Diagnostics.Process process = System.Diagnostics.Process.Start( exeName ) )
			{
			}
		}
	}
}