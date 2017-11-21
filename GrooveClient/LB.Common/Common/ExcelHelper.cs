using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace LB.Common
{
    class ExcelHelper
    {
        /// <summary>
        /// 查询表名
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public static List<string> GetExcelSheetNames(OleDbConnection con)
        {
            try
            {
                System.Data.DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new[] { null, null, null, "Table" });//检索Excel的架构信息
                List<string> sheet = new List<string>();
                for (int i = 0, j = dt.Rows.Count; i < j; i++)
                {
                    //获取的SheetName是带了$的
                    sheet.Add(dt.Rows[i]["TABLE_NAME"].ToString());
                }
                return sheet;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 导入excel数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataSet Import(string filePath)
        {
            List<string> content = new List<string>();
            DataSet ds = new DataSet();
            try
            {
                //Excel就好比一个数据源一般使用
                //这里可以根据判断excel文件是03的还是07的，然后写相应的连接字符串
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection con = new OleDbConnection(strConn);
                con.Open();
                List<string> names = GetExcelSheetNames(con);
                if (names.Count > 0)
                {
                    string strExcel = "select * from [" + names[0] + "]";
                    OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
                    myCommand.Fill(ds, "table1");

                }
                MessageBox.Show("数据读取成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //return ex.Message.tong;
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return ds;
            //return content;
        }

        public static DataTable GetDataFromExcelByConn(bool hasTitle = false)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.Cancel) return null;
            var filePath = openFile.FileName;
            string fileType = System.IO.Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType)) return null;

            using (DataSet ds = new DataSet())
            {
                string strCon = string.Format("Provider=Microsoft.Jet.OLEDB.{0}.0;" +
                                "Extended Properties=\"Excel {1}.0;HDR={2};IMEX=1;\";" +
                                "data source={3};",
                                (fileType == ".xls" ? 4 : 12), (fileType == ".xls" ? 8 : 12), (hasTitle ? "Yes" : "NO"), filePath);
                string strCom = " SELECT * FROM [Sheet1$]";
                using (OleDbConnection myConn = new OleDbConnection(strCon))
                using (OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn))
                {
                    myConn.Open();
                    myCommand.Fill(ds);
                }
                if (ds == null || ds.Tables.Count <= 0) return null;
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 将数据集中的数据导出到EXCEL文件
        /// </summary>
        /// <param name="dataSet">输入数据集</param>
        /// <param name="isShowExcle">是否显示该EXCEL文件</param>
        /// <returns></returns>
        public static bool DataSetToExcel(DataTable dt, bool isShowExcle)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();

            SaveFileDialog savefiledialog = new SaveFileDialog();

            System.Reflection.Missing miss = System.Reflection.Missing.Value;

            appexcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook workbookdata;

            Microsoft.Office.Interop.Excel.Worksheet worksheetdata;

            Microsoft.Office.Interop.Excel.Range rangedata;

            //设置对象不可见

            appexcel.Visible = false;

            System.Globalization.CultureInfo currentci = System.Threading.Thread.CurrentThread.CurrentCulture;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");

            workbookdata = appexcel.Workbooks.Add(miss);

            worksheetdata = (Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets.Add(miss, miss, miss, miss);

            //给工作表赋名称

            worksheetdata.Name = "saved";

            for (int i = 0; i < dt.Columns.Count; i++)

            {

                worksheetdata.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToString();

            }

            //因为第一行已经写了表头，所以所有数据都应该从a2开始

            rangedata = worksheetdata.get_Range("a2", miss);

            Microsoft.Office.Interop.Excel.Range xlrang = null;

            //irowcount为实际行数，最大行

            int irowcount = dt.Rows.Count;

            int iparstedrow = 0, icurrsize = 0;

            //ieachsize为每次写行的数值，可以自己设置

            int ieachsize = 1000;

            //icolumnaccount为实际列数，最大列数

            int icolumnaccount = dt.Columns.Count;

            //在内存中声明一个ieachsize×icolumnaccount的数组，ieachsize是每次最大存储的行数，icolumnaccount就是存储的实际列数

            object[,] objval = new object[ieachsize, icolumnaccount];

            icurrsize = ieachsize;





            while (iparstedrow < irowcount)

            {

                if ((irowcount - iparstedrow) < ieachsize)

                    icurrsize = irowcount - iparstedrow;

                //用for循环给数组赋值

                for (int i = 0; i < icurrsize; i++)

                {

                    for (int j = 0; j < icolumnaccount; j++)

                        objval[i, j] = dt.Rows[i + iparstedrow][j].ToString();

                    System.Windows.Forms.Application.DoEvents();

                }

                string X = "A" + ((int)(iparstedrow + 2)).ToString();

                string col = "";

                if (icolumnaccount <= 26)

                {

                    col = ((char)('A' + icolumnaccount - 1)).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();

                }

                else

                {

                    col = ((char)('A' + (icolumnaccount / 26 - 1))).ToString() + ((char)('A' + (icolumnaccount % 26 - 1))).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();

                }

                xlrang = worksheetdata.get_Range(X, col);

                // 调用range的value2属性，把内存中的值赋给excel

                xlrang.Value2 = objval;

                iparstedrow = iparstedrow + icurrsize;

            }

            //保存工作表

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlrang);

            xlrang = null;

            //调用方法关闭excel进程

            appexcel.Visible = true;

            return true;
        }
    }
}
