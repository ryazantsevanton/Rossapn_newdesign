namespace Design
{
    partial class ListSwitchesForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.importButton = new System.Windows.Forms.Button();
            this.chartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.runButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.mainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEvent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.objectsList = new DevExpress.XtraGrid.GridControl();
            this.objectsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.timeInterval = new Design.BitrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(621, 484);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(128, 23);
            this.importButton.TabIndex = 24;
            this.importButton.Text = "Экспорт в Excel";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // chartControl
            // 
            this.chartControl.BorderlineColor = System.Drawing.Color.Gray;
            this.chartControl.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            this.chartControl.BorderlineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chartControl.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartControl.Legends.Add(legend1);
            this.chartControl.Location = new System.Drawing.Point(282, 220);
            this.chartControl.Margin = new System.Windows.Forms.Padding(2);
            this.chartControl.Name = "chartControl";
            this.chartControl.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartControl.Size = new System.Drawing.Size(656, 259);
            this.chartControl.TabIndex = 23;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(755, 484);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(101, 23);
            this.runButton.TabIndex = 22;
            this.runButton.Text = "Сформировать";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(862, 484);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "Закрыть ";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(282, 16);
            this.grid.MainView = this.mainView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(655, 199);
            this.grid.TabIndex = 20;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainView,
            this.gridView4});
            // 
            // mainView
            // 
            this.mainView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colObject,
            this.colParam,
            this.colEvent,
            this.colExpect,
            this.colReal});
            this.mainView.GridControl = this.grid;
            this.mainView.Name = "mainView";
            this.mainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsBehavior.Editable = false;
            this.mainView.OptionsView.ShowGroupPanel = false;
            this.mainView.OptionsView.ShowIndicator = false;
            // 
            // colDate
            // 
            this.colDate.Caption = "Дата";
            this.colDate.FieldName = "colDate";
            this.colDate.Name = "colDate";
            this.colDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            this.colDate.Width = 87;
            // 
            // colObject
            // 
            this.colObject.Caption = "Объект";
            this.colObject.FieldName = "colObject";
            this.colObject.Name = "colObject";
            this.colObject.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colObject.Visible = true;
            this.colObject.VisibleIndex = 1;
            this.colObject.Width = 165;
            // 
            // colParam
            // 
            this.colParam.Caption = "Параметр";
            this.colParam.FieldName = "colParam";
            this.colParam.Name = "colParam";
            this.colParam.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colParam.Visible = true;
            this.colParam.VisibleIndex = 2;
            this.colParam.Width = 130;
            // 
            // colEvent
            // 
            this.colEvent.Caption = "Событие";
            this.colEvent.FieldName = "colEvent";
            this.colEvent.Name = "colEvent";
            this.colEvent.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colEvent.Visible = true;
            this.colEvent.VisibleIndex = 3;
            this.colEvent.Width = 116;
            // 
            // colExpect
            // 
            this.colExpect.Caption = "Ожидаемое";
            this.colExpect.FieldName = "colExpect";
            this.colExpect.Name = "colExpect";
            this.colExpect.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colExpect.Visible = true;
            this.colExpect.VisibleIndex = 4;
            // 
            // colReal
            // 
            this.colReal.Caption = "Полученное";
            this.colReal.FieldName = "colReal";
            this.colReal.Name = "colReal";
            this.colReal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colReal.Visible = true;
            this.colReal.VisibleIndex = 5;
            this.colReal.Width = 80;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grid;
            this.gridView4.Name = "gridView4";
            // 
            // objectsList
            // 
            this.objectsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectsList.Location = new System.Drawing.Point(8, 34);
            this.objectsList.MainView = this.objectsView;
            this.objectsList.Name = "objectsList";
            this.objectsList.Padding = new System.Windows.Forms.Padding(3);
            this.objectsList.Size = new System.Drawing.Size(260, 296);
            this.objectsList.TabIndex = 26;
            this.objectsList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.objectsView});
            // 
            // objectsView
            // 
            this.objectsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cId,
            this.cObject,
            this.cChecked,
            this.gridColumn4,
            this.gridColumn5});
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
            this.cId.Visible = true;
            this.cId.VisibleIndex = 0;
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
            this.cObject.VisibleIndex = 2;
            this.cObject.Width = 255;
            // 
            // cChecked
            // 
            this.cChecked.Caption = "+";
            this.cChecked.FieldName = "cChecked";
            this.cChecked.Name = "cChecked";
            this.cChecked.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.cChecked.Visible = true;
            this.cChecked.VisibleIndex = 1;
            this.cChecked.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Лицензионный участок";
            this.gridColumn4.FieldName = "cLicField";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Куст";
            this.gridColumn5.FieldName = "cBranch";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Объекты";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.intervalLabel);
            this.panel1.Controls.Add(this.timeInterval);
            this.panel1.Location = new System.Drawing.Point(4, 350);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(264, 69);
            this.panel1.TabIndex = 27;
            // 
            // intervalLabel
            // 
            this.intervalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(4, 1);
            this.intervalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(132, 17);
            this.intervalLabel.TabIndex = 4;
            this.intervalLabel.Text = "Интервал времени";
            // 
            // timeInterval
            // 
            this.timeInterval.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeInterval.Down = 9;
            this.timeInterval.Location = new System.Drawing.Point(2, 17);
            this.timeInterval.Margin = new System.Windows.Forms.Padding(2);
            this.timeInterval.Name = "timeInterval";
            this.timeInterval.Size = new System.Drawing.Size(258, 48);
            this.timeInterval.TabIndex = 5;
            this.timeInterval.TickCount = 30;
            this.timeInterval.Up = 0;
            // 
            // ListSwitchesForm
            // 
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.objectsList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.chartControl);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.grid);
            this.Name = "ListSwitchesForm";
            this.Size = new System.Drawing.Size(950, 520);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button closeButton;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView mainView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.GridControl objectsList;
        private DevExpress.XtraGrid.Views.Grid.GridView objectsView;
        private DevExpress.XtraGrid.Columns.GridColumn cId;
        private DevExpress.XtraGrid.Columns.GridColumn cObject;
        private DevExpress.XtraGrid.Columns.GridColumn cChecked;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label intervalLabel;
        private BitrackBar timeInterval;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colObject;
        private DevExpress.XtraGrid.Columns.GridColumn colParam;
        private DevExpress.XtraGrid.Columns.GridColumn colEvent;
        private DevExpress.XtraGrid.Columns.GridColumn colExpect;
        private DevExpress.XtraGrid.Columns.GridColumn colReal;
    }
}
