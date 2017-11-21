﻿using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LB.Controls
{
    public partial class LBSkinTextBox : SkinTextBox, ILBTextBox
    {
        public LBSkinTextBox()
        {
            InitializeComponent();
        }

        public LBSkinTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private bool _CanBeEmpty = true;
        [Description("是否可为空")]
        public bool CanBeEmpty
        {
            get
            {
                return _CanBeEmpty;
            }
            set
            {
                _CanBeEmpty = value;
            }
        }

        private string _Caption = "";
        [Description("控件名称")]
        public string Caption
        {
            get
            {
                return _Caption;
            }
            set
            {
                _Caption = value;
            }
        }

        [Description("值是否为空")]
        public bool IsEmptyValue
        {
            get
            {
                return this.Text.TrimEnd()==""?true:false;
            }
        }
    }
}
