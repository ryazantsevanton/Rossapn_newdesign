namespace Design
{
    partial class SettingsForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.npdShedule = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.mainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEntityID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPredicateID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEvent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbArguments = new System.Windows.Forms.TextBox();
            this.cbEventCheckers = new System.Windows.Forms.ComboBox();
            this.cbParameters = new System.Windows.Forms.ComboBox();
            this.cbObjects = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.npdShedule)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(375, 154);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(472, 154);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "минимальная задержа события";
            // 
            // npdShedule
            // 
            this.npdShedule.Location = new System.Drawing.Point(427, 13);
            this.npdShedule.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.npdShedule.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.npdShedule.Name = "npdShedule";
            this.npdShedule.Size = new System.Drawing.Size(120, 20);
            this.npdShedule.TabIndex = 9;
            this.npdShedule.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Настройки событий";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.grid);
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.tbArguments);
            this.panel1.Controls.Add(this.cbEventCheckers);
            this.panel1.Controls.Add(this.cbParameters);
            this.panel1.Controls.Add(this.cbObjects);
            this.panel1.Location = new System.Drawing.Point(27, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 245);
            this.panel1.TabIndex = 12;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(15, 11);
            this.grid.MainView = this.mainView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(770, 195);
            this.grid.TabIndex = 20;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainView,
            this.gridView1});
            // 
            // mainView
            // 
            this.mainView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEntityID,
            this.colObject,
            this.colPredicateID,
            this.colParam,
            this.colEvent,
            this.colArg,
            this.colEntityName});
            this.mainView.GridControl = this.grid;
            this.mainView.Name = "mainView";
            this.mainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsBehavior.Editable = false;
            this.mainView.OptionsView.ShowGroupPanel = false;
            this.mainView.OptionsView.ShowIndicator = false;
            // 
            // colEntityID
            // 
            this.colEntityID.Caption = "gridColumn1";
            this.colEntityID.FieldName = "colEntityID";
            this.colEntityID.Name = "colEntityID";
            // 
            // colObject
            // 
            this.colObject.Caption = "Объект";
            this.colObject.FieldName = "colObject";
            this.colObject.Name = "colObject";
            this.colObject.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colObject.Visible = true;
            this.colObject.VisibleIndex = 0;
            // 
            // colPredicateID
            // 
            this.colPredicateID.Caption = "gridColumn1";
            this.colPredicateID.FieldName = "colPredicateID";
            this.colPredicateID.Name = "colPredicateID";
            // 
            // colParam
            // 
            this.colParam.Caption = "Параметр";
            this.colParam.FieldName = "colParam";
            this.colParam.Name = "colParam";
            this.colParam.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colParam.Visible = true;
            this.colParam.VisibleIndex = 1;
            // 
            // colEvent
            // 
            this.colEvent.Caption = "Событие";
            this.colEvent.FieldName = "colEvent";
            this.colEvent.Name = "colEvent";
            this.colEvent.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colEvent.Visible = true;
            this.colEvent.VisibleIndex = 2;
            // 
            // colArg
            // 
            this.colArg.Caption = "Аргумент";
            this.colArg.FieldName = "colArg";
            this.colArg.Name = "colArg";
            this.colArg.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colArg.Visible = true;
            this.colArg.VisibleIndex = 3;
            // 
            // colEntityName
            // 
            this.colEntityName.Caption = "gridColumn1";
            this.colEntityName.FieldName = "colEntityName";
            this.colEntityName.Name = "colEntityName";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(580, 207);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(20, 23);
            this.btnHelp.TabIndex = 19;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.OnHelpButtonClick);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(789, 207);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnApplyButtonClick);
            // 
            // tbArguments
            // 
            this.tbArguments.Location = new System.Drawing.Point(605, 211);
            this.tbArguments.Margin = new System.Windows.Forms.Padding(2);
            this.tbArguments.Name = "tbArguments";
            this.tbArguments.Size = new System.Drawing.Size(180, 20);
            this.tbArguments.TabIndex = 3;
            // 
            // cbEventCheckers
            // 
            this.cbEventCheckers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEventCheckers.FormattingEnabled = true;
            this.cbEventCheckers.Location = new System.Drawing.Point(391, 210);
            this.cbEventCheckers.Margin = new System.Windows.Forms.Padding(2);
            this.cbEventCheckers.Name = "cbEventCheckers";
            this.cbEventCheckers.Size = new System.Drawing.Size(185, 21);
            this.cbEventCheckers.TabIndex = 2;
            // 
            // cbParameters
            // 
            this.cbParameters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParameters.FormattingEnabled = true;
            this.cbParameters.Location = new System.Drawing.Point(203, 210);
            this.cbParameters.Margin = new System.Windows.Forms.Padding(2);
            this.cbParameters.Name = "cbParameters";
            this.cbParameters.Size = new System.Drawing.Size(185, 21);
            this.cbParameters.TabIndex = 1;
            // 
            // cbObjects
            // 
            this.cbObjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObjects.FormattingEnabled = true;
            this.cbObjects.Location = new System.Drawing.Point(15, 210);
            this.cbObjects.Margin = new System.Windows.Forms.Padding(2);
            this.cbObjects.Name = "cbObjects";
            this.cbObjects.Size = new System.Drawing.Size(185, 21);
            this.cbObjects.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.npdShedule);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Location = new System.Drawing.Point(27, 308);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(886, 188);
            this.panel2.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 275);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Другие настройки";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SettingsForm";
            this.Size = new System.Drawing.Size(950, 520);
            ((System.ComponentModel.ISupportInitialize)(this.npdShedule)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown npdShedule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbArguments;
        private System.Windows.Forms.ComboBox cbEventCheckers;
        private System.Windows.Forms.ComboBox cbParameters;
        private System.Windows.Forms.ComboBox cbObjects;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHelp;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView mainView;
        private DevExpress.XtraGrid.Columns.GridColumn colObject;
        private DevExpress.XtraGrid.Columns.GridColumn colParam;
        private DevExpress.XtraGrid.Columns.GridColumn colEvent;
        private DevExpress.XtraGrid.Columns.GridColumn colArg;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEntityID;
        private DevExpress.XtraGrid.Columns.GridColumn colPredicateID;
        private DevExpress.XtraGrid.Columns.GridColumn colEntityName;
    }
}
