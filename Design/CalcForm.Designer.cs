namespace Design
{
    partial class CalcForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.lStartDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbParameters = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.objectsList = new DevExpress.XtraGrid.GridControl();
            this.objectsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dataPage = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.chartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.runButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.mainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sourcePage = new System.Windows.Forms.TabPage();
            this.chartSource = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gridSource = new DevExpress.XtraGrid.GridControl();
            this.viewSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.eventPage = new System.Windows.Forms.TabPage();
            this.gridEvents = new DevExpress.XtraGrid.GridControl();
            this.viewEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEvent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.sourcePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.eventPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.cbParameters);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.objectsList);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1253, 634);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.trackBar);
            this.panel1.Controls.Add(this.lStartDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(7, 437);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 84);
            this.panel1.TabIndex = 8;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(9, 26);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(321, 56);
            this.trackBar.TabIndex = 2;
            // 
            // lStartDate
            // 
            this.lStartDate.AutoSize = true;
            this.lStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStartDate.Location = new System.Drawing.Point(164, 5);
            this.lStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lStartDate.Name = "lStartDate";
            this.lStartDate.Size = new System.Drawing.Size(159, 17);
            this.lStartDate.TabIndex = 1;
            this.lStartDate.Text = "01.01.1900 23:34:50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Начало расчета";
            // 
            // cbParameters
            // 
            this.cbParameters.FormattingEnabled = true;
            this.cbParameters.Location = new System.Drawing.Point(7, 383);
            this.cbParameters.Margin = new System.Windows.Forms.Padding(4);
            this.cbParameters.Name = "cbParameters";
            this.cbParameters.Size = new System.Drawing.Size(333, 24);
            this.cbParameters.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Параметры";
            // 
            // objectsList
            // 
            this.objectsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectsList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.objectsList.Location = new System.Drawing.Point(7, 36);
            this.objectsList.MainView = this.objectsView;
            this.objectsList.Margin = new System.Windows.Forms.Padding(4);
            this.objectsList.Name = "objectsList";
            this.objectsList.Padding = new System.Windows.Forms.Padding(4);
            this.objectsList.Size = new System.Drawing.Size(334, 297);
            this.objectsList.TabIndex = 5;
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
            this.cObject.Caption = "Объект";
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
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Объекты";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.dataPage);
            this.tabControl.Controls.Add(this.sourcePage);
            this.tabControl.Controls.Add(this.eventPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(901, 634);
            this.tabControl.TabIndex = 0;
            // 
            // dataPage
            // 
            this.dataPage.Controls.Add(this.saveButton);
            this.dataPage.Controls.Add(this.chartControl);
            this.dataPage.Controls.Add(this.runButton);
            this.dataPage.Controls.Add(this.closeButton);
            this.dataPage.Controls.Add(this.grid);
            this.dataPage.Location = new System.Drawing.Point(4, 25);
            this.dataPage.Margin = new System.Windows.Forms.Padding(4);
            this.dataPage.Name = "dataPage";
            this.dataPage.Padding = new System.Windows.Forms.Padding(4);
            this.dataPage.Size = new System.Drawing.Size(893, 605);
            this.dataPage.TabIndex = 0;
            this.dataPage.Text = "Данные";
            this.dataPage.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(539, 561);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(113, 28);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
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
            this.chartControl.Location = new System.Drawing.Point(7, 236);
            this.chartControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartControl.Name = "chartControl";
            this.chartControl.Size = new System.Drawing.Size(875, 319);
            this.chartControl.TabIndex = 5;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(660, 561);
            this.runButton.Margin = new System.Windows.Forms.Padding(4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(113, 28);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Обработать";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(781, 561);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 28);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Закрыть ";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grid.Location = new System.Drawing.Point(8, 9);
            this.grid.MainView = this.mainView;
            this.grid.Margin = new System.Windows.Forms.Padding(4);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(873, 219);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainView,
            this.gridView4});
            // 
            // mainView
            // 
            this.mainView.GridControl = this.grid;
            this.mainView.Name = "mainView";
            this.mainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.mainView.OptionsView.ShowGroupPanel = false;
            this.mainView.OptionsView.ShowIndicator = false;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grid;
            this.gridView4.Name = "gridView4";
            // 
            // sourcePage
            // 
            this.sourcePage.Controls.Add(this.chartSource);
            this.sourcePage.Controls.Add(this.gridSource);
            this.sourcePage.Location = new System.Drawing.Point(4, 25);
            this.sourcePage.Margin = new System.Windows.Forms.Padding(4);
            this.sourcePage.Name = "sourcePage";
            this.sourcePage.Size = new System.Drawing.Size(893, 605);
            this.sourcePage.TabIndex = 1;
            this.sourcePage.Text = "Исходные данные";
            this.sourcePage.UseVisualStyleBackColor = true;
            // 
            // chartSource
            // 
            this.chartSource.BorderlineColor = System.Drawing.Color.Gray;
            this.chartSource.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            this.chartSource.BorderlineWidth = 2;
            chartArea2.Name = "ChartArea1";
            this.chartSource.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSource.Legends.Add(legend2);
            this.chartSource.Location = new System.Drawing.Point(7, 255);
            this.chartSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartSource.Name = "chartSource";
            this.chartSource.Size = new System.Drawing.Size(875, 327);
            this.chartSource.TabIndex = 7;
            // 
            // gridSource
            // 
            this.gridSource.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridSource.Location = new System.Drawing.Point(8, 9);
            this.gridSource.MainView = this.viewSource;
            this.gridSource.Margin = new System.Windows.Forms.Padding(4);
            this.gridSource.Name = "gridSource";
            this.gridSource.Size = new System.Drawing.Size(873, 246);
            this.gridSource.TabIndex = 6;
            this.gridSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewSource,
            this.gridView2});
            // 
            // viewSource
            // 
            this.viewSource.GridControl = this.gridSource;
            this.viewSource.Name = "viewSource";
            this.viewSource.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewSource.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewSource.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.viewSource.OptionsView.ShowGroupPanel = false;
            this.viewSource.OptionsView.ShowIndicator = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridSource;
            this.gridView2.Name = "gridView2";
            // 
            // eventPage
            // 
            this.eventPage.Controls.Add(this.gridEvents);
            this.eventPage.Location = new System.Drawing.Point(4, 25);
            this.eventPage.Margin = new System.Windows.Forms.Padding(4);
            this.eventPage.Name = "eventPage";
            this.eventPage.Padding = new System.Windows.Forms.Padding(4);
            this.eventPage.Size = new System.Drawing.Size(893, 605);
            this.eventPage.TabIndex = 2;
            this.eventPage.Text = "События";
            this.eventPage.UseVisualStyleBackColor = true;
            // 
            // gridEvents
            // 
            this.gridEvents.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridEvents.Location = new System.Drawing.Point(4, 9);
            this.gridEvents.MainView = this.viewEvents;
            this.gridEvents.Margin = new System.Windows.Forms.Padding(4);
            this.gridEvents.Name = "gridEvents";
            this.gridEvents.Size = new System.Drawing.Size(873, 538);
            this.gridEvents.TabIndex = 7;
            this.gridEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewEvents,
            this.gridView3});
            // 
            // viewEvents
            // 
            this.viewEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colEntity,
            this.colParam,
            this.colEvent,
            this.colExpValue,
            this.colReal});
            this.viewEvents.GridControl = this.gridEvents;
            this.viewEvents.Name = "viewEvents";
            this.viewEvents.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewEvents.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewEvents.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.viewEvents.OptionsBehavior.Editable = false;
            this.viewEvents.OptionsView.ShowGroupPanel = false;
            this.viewEvents.OptionsView.ShowIndicator = false;
            // 
            // colDate
            // 
            this.colDate.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colDate.AppearanceCell.Options.UseBackColor = true;
            this.colDate.Caption = "Дата";
            this.colDate.FieldName = "colDate";
            this.colDate.Name = "colDate";
            this.colDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            // 
            // colEntity
            // 
            this.colEntity.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colEntity.AppearanceCell.Options.UseBackColor = true;
            this.colEntity.Caption = "Объект";
            this.colEntity.FieldName = "colEntity";
            this.colEntity.Name = "colEntity";
            this.colEntity.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colEntity.Visible = true;
            this.colEntity.VisibleIndex = 1;
            // 
            // colParam
            // 
            this.colParam.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colParam.AppearanceCell.Options.UseBackColor = true;
            this.colParam.Caption = "Параметр";
            this.colParam.FieldName = "colParam";
            this.colParam.Name = "colParam";
            this.colParam.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colParam.Visible = true;
            this.colParam.VisibleIndex = 2;
            // 
            // colEvent
            // 
            this.colEvent.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colEvent.AppearanceCell.Options.UseBackColor = true;
            this.colEvent.Caption = "Тип события";
            this.colEvent.FieldName = "colEvent";
            this.colEvent.Name = "colEvent";
            this.colEvent.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colEvent.Visible = true;
            this.colEvent.VisibleIndex = 3;
            // 
            // colExpValue
            // 
            this.colExpValue.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colExpValue.AppearanceCell.Options.UseBackColor = true;
            this.colExpValue.Caption = "Ожидаемое";
            this.colExpValue.FieldName = "colExpValue";
            this.colExpValue.Name = "colExpValue";
            this.colExpValue.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colExpValue.Visible = true;
            this.colExpValue.VisibleIndex = 4;
            // 
            // colReal
            // 
            this.colReal.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colReal.AppearanceCell.Options.UseBackColor = true;
            this.colReal.Caption = "Полученное";
            this.colReal.FieldName = "colReal";
            this.colReal.Name = "colReal";
            this.colReal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colReal.Visible = true;
            this.colReal.VisibleIndex = 5;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridEvents;
            this.gridView3.Name = "gridView3";
            // 
            // CalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CalcForm";
            this.Size = new System.Drawing.Size(1253, 634);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.dataPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.sourcePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.eventPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbParameters;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl objectsList;
        private DevExpress.XtraGrid.Views.Grid.GridView objectsView;
        private DevExpress.XtraGrid.Columns.GridColumn cId;
        private DevExpress.XtraGrid.Columns.GridColumn cObject;
        private DevExpress.XtraGrid.Columns.GridColumn cChecked;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dataPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button closeButton;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView mainView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.TabPage sourcePage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSource;
        private DevExpress.XtraGrid.GridControl gridSource;
        private DevExpress.XtraGrid.Views.Grid.GridView viewSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label lStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage eventPage;
        private DevExpress.XtraGrid.GridControl gridEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView viewEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEntity;
        private DevExpress.XtraGrid.Columns.GridColumn colParam;
        private DevExpress.XtraGrid.Columns.GridColumn colEvent;
        private DevExpress.XtraGrid.Columns.GridColumn colExpValue;
        private DevExpress.XtraGrid.Columns.GridColumn colReal;
    }
}
