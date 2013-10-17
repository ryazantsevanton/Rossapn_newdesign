﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Data.Linq;

namespace Design
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            iExit.ItemClick += OnExitClick;
            loadButton.ItemClick += OnLoadClick;
            clearButton.ItemClick += OnClearButtonClick;
            paramButton.ItemClick += OnEditParamButtonClick;
            objectButton.ItemClick += OnEditObjectButtonClick;
        }

        private void OnEditParamButtonClick(object sender, ItemClickEventArgs e)
        {
            if (topPanel.Controls.ContainsKey("EditParamObjectControl"))
            {
                return;
            }
            var form = new EditParamObjectControl(true);
            topPanel.Controls.Add(form);            

        }

        private void OnEditObjectButtonClick(object sender, ItemClickEventArgs e)
        {
            if (topPanel.Controls.ContainsKey("EditParamObjectControl"))
            {
                return;
            }
            var form = new EditParamObjectControl(false);
            topPanel.Controls.Add(form);            

        }

        private void OnClearButtonClick(object sender, ItemClickEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы действительно хотите удалить все данные?", "Предупреждение",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                DataHelper.ClearData();
            }
        }

        private void OnLoadClick(object sender, EventArgs e)
        {
            if (topPanel.Controls.ContainsKey("LoadXlsForm")) {
                return; 
            }
            var form = new LoadXlsForm();            
            topPanel.Controls.Add(form);            
        }

        private void OnExitClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}