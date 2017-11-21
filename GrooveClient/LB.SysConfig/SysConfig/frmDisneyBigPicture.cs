using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LB.Controls;

namespace LB.SysConfig.SysConfig
{
    public partial class frmDisneyBigPicture : LBUIPageBase
    {
        public frmDisneyBigPicture(Image img)
        {
            InitializeComponent();
            this.pictureBox1.Image = img;
        }
    }
}
