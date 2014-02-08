namespace Design
{
    partial class DataControl
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
            DevExpress.XtraGrid.Columns.GridColumn cTime;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.opdPanel = new System.Windows.Forms.SplitContainer();
            this.opPanel = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.timeInterval = new Design.BitrackBar();
            this.objectsList = new DevExpress.XtraGrid.GridControl();
            this.objectsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cLicField = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.parametersList = new DevExpress.XtraGrid.GridControl();
            this.parametersView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.dataTable = new DevExpress.XtraGrid.GridControl();
            this.dataView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.opdPanel)).BeginInit();
            this.opdPanel.Panel1.SuspendLayout();
            this.opdPanel.Panel2.SuspendLayout();
            this.opdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opPanel)).BeginInit();
            this.opPanel.Panel1.SuspendLayout();
            this.opPanel.Panel2.SuspendLayout();
            this.opPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            this.SuspendLayout();
            // 
            // cTime
            // 
            cTime.Caption = "Время";
            cTime.FieldName = "cTime";
            cTime.Name = "cTime";
            cTime.OptionsColumn.AllowEdit = false;
            cTime.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            cTime.Visible = true;
            cTime.VisibleIndex = 0;
            // 
            // opdPanel
            // 
            this.opdPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opdPanel.Location = new System.Drawing.Point(0, 0);
            this.opdPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.opdPanel.Name = "opdPanel";
            // 
            // opdPanel.Panel1
            // 
            this.opdPanel.Panel1.Controls.Add(this.opPanel);
            // 
            // opdPanel.Panel2
            // 
            this.opdPanel.Panel2.Controls.Add(this.tabControl);
            this.opdPanel.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.opdPanel.Size = new System.Drawing.Size(1088, 642);
            this.opdPanel.SplitterDistance = 360;
            this.opdPanel.TabIndex = 1;
            // 
            // opPanel
            // 
            this.opPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opPanel.Location = new System.Drawing.Point(0, 0);
            this.opPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.opPanel.Name = "opPanel";
            this.opPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // opPanel.Panel1
            // 
            this.opPanel.Panel1.Controls.Add(this.panel1);
            this.opPanel.Panel1.Controls.Add(this.objectsList);
            this.opPanel.Panel1.Controls.Add(this.label1);
            this.opPanel.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // opPanel.Panel2
            // 
            this.opPanel.Panel2.Controls.Add(this.parametersList);
            this.opPanel.Panel2.Controls.Add(this.label2);
            this.opPanel.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.opPanel.Size = new System.Drawing.Size(360, 642);
            this.opPanel.SplitterDistance = 418;
            this.opPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.intervalLabel);
            this.panel1.Controls.Add(this.timeInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 330);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Size = new System.Drawing.Size(352, 84);
            this.panel1.TabIndex = 6;
            // 
            // intervalLabel
            // 
            this.intervalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(5, 1);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(132, 17);
            this.intervalLabel.TabIndex = 4;
            this.intervalLabel.Text = "Интервал времени";
            // 
            // timeInterval
            // 
            this.timeInterval.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeInterval.Down = 9;
            this.timeInterval.Location = new System.Drawing.Point(3, 21);
            this.timeInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeInterval.Name = "timeInterval";
            this.timeInterval.Size = new System.Drawing.Size(344, 59);
            this.timeInterval.TabIndex = 5;
            this.timeInterval.TickCount = 10;
            this.timeInterval.Up = 0;
            // 
            // objectsList
            // 
            this.objectsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectsList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.objectsList.Location = new System.Drawing.Point(4, 25);
            this.objectsList.MainView = this.objectsView;
            this.objectsList.Margin = new System.Windows.Forms.Padding(4);
            this.objectsList.Name = "objectsList";
            this.objectsList.Padding = new System.Windows.Forms.Padding(4);
            this.objectsList.Size = new System.Drawing.Size(352, 299);
            this.objectsList.TabIndex = 3;
            this.objectsList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.objectsView});
            // 
            // objectsView
            // 
            this.objectsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cId,
            this.cObject,
            this.cChecked,
            this.cLicField,
            this.cBranch});
            this.objectsView.GridControl = this.objectsList;
            this.objectsView.Name = "objectsView";
            this.objectsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.objectsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.objectsView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.objectsView.OptionsView.ShowGroupPanel = false;
            this.objectsView.OptionsView.ShowIndicator = false;
            // 
            // cId
            // 
            this.cId.Caption = "Id";
            this.cId.FieldName = "cId";
            this.cId.Name = "cId";
            this.cId.OptionsColumn.AllowEdit = false;
            this.cId.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.cId.Width = 62;
            // 
            // cObject
            // 
            this.cObject.Caption = "Скважина";
            this.cObject.FieldName = "cObject";
            this.cObject.Name = "cObject";
            this.cObject.OptionsColumn.AllowEdit = false;
            this.cObject.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.cObject.Visible = true;
            this.cObject.VisibleIndex = 1;
            this.cObject.Width = 255;
            // 
            // cChecked
            // 
            this.cChecked.Caption = "+";
            this.cChecked.FieldName = "cChecked";
            this.cChecked.Name = "cChecked";
            this.cChecked.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.cChecked.Visible = true;
            this.cChecked.VisibleIndex = 0;
            this.cChecked.Width = 62;
            // 
            // cLicField
            // 
            this.cLicField.Caption = "Лицензионный участок";
            this.cLicField.FieldName = "cLicField";
            this.cLicField.Name = "cLicField";
            this.cLicField.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.cLicField.Visible = true;
            this.cLicField.VisibleIndex = 3;
            // 
            // cBranch
            // 
            this.cBranch.Caption = "Куст";
            this.cBranch.FieldName = "cBranch";
            this.cBranch.Name = "cBranch";
            this.cBranch.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.cBranch.Visible = true;
            this.cBranch.VisibleIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Объекты";
            // 
            // parametersList
            // 
            this.parametersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parametersList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.parametersList.Location = new System.Drawing.Point(4, 21);
            this.parametersList.MainView = this.parametersView;
            this.parametersList.Margin = new System.Windows.Forms.Padding(4);
            this.parametersList.Name = "parametersList";
            this.parametersList.Size = new System.Drawing.Size(352, 201);
            this.parametersList.TabIndex = 4;
            this.parametersList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.parametersView});
            // 
            // parametersView
            // 
            this.parametersView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.parametersView.GridControl = this.parametersList;
            this.parametersView.Name = "parametersView";
            this.parametersView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.parametersView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.parametersView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.parametersView.OptionsView.ShowGroupPanel = false;
            this.parametersView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "cId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn1.Width = 45;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Параметр";
            this.gridColumn2.FieldName = "cParameter";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 255;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "+";
            this.gridColumn3.FieldName = "cChecked";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Параметры";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(4, 4);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(716, 634);
            this.tabControl.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonPanel);
            this.tabPage1.Controls.Add(this.dataTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(708, 605);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Таблица";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonPanel.Controls.Add(this.closeButton);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(3, 562);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(702, 41);
            this.buttonPanel.TabIndex = 6;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(420, 4);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(128, 34);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(570, 4);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(128, 34);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // dataTable
            // 
            this.dataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTable.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.dataTable.Location = new System.Drawing.Point(3, 2);
            this.dataTable.MainView = this.dataView;
            this.dataTable.Margin = new System.Windows.Forms.Padding(4);
            this.dataTable.Name = "dataTable";
            this.dataTable.Padding = new System.Windows.Forms.Padding(4);
            this.dataTable.Size = new System.Drawing.Size(701, 550);
            this.dataTable.TabIndex = 5;
            this.dataTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dataView});
            // 
            // dataView
            // 
            this.dataView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            cTime});
            this.dataView.GridControl = this.dataTable;
            this.dataView.Name = "dataView";
            this.dataView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dataView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dataView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.dataView.OptionsCustomization.AllowColumnMoving = false;
            this.dataView.OptionsCustomization.AllowFilter = false;
            this.dataView.OptionsCustomization.AllowGroup = false;
            this.dataView.OptionsCustomization.AllowQuickHideColumns = false;
            this.dataView.OptionsCustomization.AllowSort = false;
            this.dataView.OptionsView.ShowGroupPanel = false;
            this.dataView.OptionsView.ShowIndicator = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(708, 605);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "График";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartControl
            // 
            chartArea2.Name = "ChartArea1";
            this.chartControl.ChartAreas.Add(chartArea2);
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartControl.Legends.Add(legend2);
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartControl.Name = "chartControl";
            this.chartControl.Size = new System.Drawing.Size(708, 605);
            this.chartControl.TabIndex = 0;
            // 
            // DataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.opdPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DataControl";
            this.Size = new System.Drawing.Size(1088, 642);
            this.opdPanel.Panel1.ResumeLayout(false);
            this.opdPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opdPanel)).EndInit();
            this.opdPanel.ResumeLayout(false);
            this.opPanel.Panel1.ResumeLayout(false);
            this.opPanel.Panel1.PerformLayout();
            this.opPanel.Panel2.ResumeLayout(false);
            this.opPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opPanel)).EndInit();
            this.opPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer opdPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer opPanel;
        private DevExpress.XtraGrid.GridControl objectsList;
        private DevExpress.XtraGrid.Views.Grid.GridView objectsView;
        private DevExpress.XtraGrid.Columns.GridColumn cObject;
        private DevExpress.XtraGrid.Columns.GridColumn cId;
        private DevExpress.XtraGrid.Columns.GridColumn cChecked;
        private DevExpress.XtraGrid.GridControl parametersList;
        private DevExpress.XtraGrid.Views.Grid.GridView parametersView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl dataTable;
        private DevExpress.XtraGrid.Views.Grid.GridView dataView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.Columns.GridColumn cLicField;
        private DevExpress.XtraGrid.Columns.GridColumn cBranch;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label intervalLabel;
        private BitrackBar timeInterval;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;

    }
}
