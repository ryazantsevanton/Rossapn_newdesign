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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trackStart = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.trackEnd = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.refTimeButton = new System.Windows.Forms.Button();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.rbRelation = new System.Windows.Forms.RadioButton();
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
            this.importButton = new System.Windows.Forms.Button();
            this.chartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.runButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.mainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackStart)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackEnd)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trackStart);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.trackEnd);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.cbParameters);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.objectsList);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(940, 515);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // trackStart
            // 
            this.trackStart.Enabled = false;
            this.trackStart.Location = new System.Drawing.Point(7, 325);
            this.trackStart.Name = "trackStart";
            this.trackStart.Size = new System.Drawing.Size(254, 45);
            this.trackStart.TabIndex = 13;
            this.trackStart.ValueChanged += new System.EventHandler(this.trackStart_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbEnd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbStart);
            this.groupBox2.Location = new System.Drawing.Point(7, 427);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Период обработки";
            // 
            // tbEnd
            // 
            this.tbEnd.BackColor = System.Drawing.Color.White;
            this.tbEnd.Location = new System.Drawing.Point(67, 48);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.ReadOnly = true;
            this.tbEnd.Size = new System.Drawing.Size(171, 20);
            this.tbEnd.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Начало";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Конец";
            // 
            // tbStart
            // 
            this.tbStart.BackColor = System.Drawing.Color.White;
            this.tbStart.Location = new System.Drawing.Point(67, 19);
            this.tbStart.Name = "tbStart";
            this.tbStart.ReadOnly = true;
            this.tbStart.Size = new System.Drawing.Size(171, 20);
            this.tbStart.TabIndex = 15;
            // 
            // trackEnd
            // 
            this.trackEnd.Enabled = false;
            this.trackEnd.Location = new System.Drawing.Point(7, 376);
            this.trackEnd.Name = "trackEnd";
            this.trackEnd.Size = new System.Drawing.Size(254, 45);
            this.trackEnd.TabIndex = 12;
            this.trackEnd.ValueChanged += new System.EventHandler(this.trackEnd_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refTimeButton);
            this.groupBox1.Controls.Add(this.rbTime);
            this.groupBox1.Controls.Add(this.rbRelation);
            this.groupBox1.Location = new System.Drawing.Point(10, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 62);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип временных характеристик";
            // 
            // refTimeButton
            // 
            this.refTimeButton.Location = new System.Drawing.Point(160, 31);
            this.refTimeButton.Name = "refTimeButton";
            this.refTimeButton.Size = new System.Drawing.Size(75, 23);
            this.refTimeButton.TabIndex = 11;
            this.refTimeButton.Text = "Обновить";
            this.refTimeButton.UseVisualStyleBackColor = true;
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
            this.rbTime.Location = new System.Drawing.Point(20, 19);
            this.rbTime.Name = "rbTime";
            this.rbTime.Size = new System.Drawing.Size(133, 17);
            this.rbTime.TabIndex = 9;
            this.rbTime.TabStop = true;
            this.rbTime.Text = "временные значение";
            this.rbTime.UseVisualStyleBackColor = true;
            // 
            // rbRelation
            // 
            this.rbRelation.AutoSize = true;
            this.rbRelation.Location = new System.Drawing.Point(20, 37);
            this.rbRelation.Name = "rbRelation";
            this.rbRelation.Size = new System.Drawing.Size(124, 17);
            this.rbRelation.TabIndex = 10;
            this.rbRelation.TabStop = true;
            this.rbRelation.Text = "условные значения";
            this.rbRelation.UseVisualStyleBackColor = true;
            // 
            // cbParameters
            // 
            this.cbParameters.FormattingEnabled = true;
            this.cbParameters.Location = new System.Drawing.Point(5, 230);
            this.cbParameters.Name = "cbParameters";
            this.cbParameters.Size = new System.Drawing.Size(254, 21);
            this.cbParameters.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Параметры";
            // 
            // objectsList
            // 
            this.objectsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectsList.Location = new System.Drawing.Point(5, 29);
            this.objectsList.MainView = this.objectsView;
            this.objectsList.Name = "objectsList";
            this.objectsList.Padding = new System.Windows.Forms.Padding(3);
            this.objectsList.Size = new System.Drawing.Size(251, 167);
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
            this.objectsView.GroupCount = 2;
            this.objectsView.Name = "objectsView";
            this.objectsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.objectsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.objectsView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.objectsView.OptionsView.ShowGroupPanel = false;
            this.objectsView.OptionsView.ShowIndicator = false;
            this.objectsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.gridColumn4.Caption = "Месторождение";
            this.gridColumn4.FieldName = "Месторождение";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Куст";
            this.gridColumn5.FieldName = "Куст";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Объекты";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.dataPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(675, 515);
            this.tabControl.TabIndex = 0;
            // 
            // dataPage
            // 
            this.dataPage.Controls.Add(this.importButton);
            this.dataPage.Controls.Add(this.chartControl);
            this.dataPage.Controls.Add(this.runButton);
            this.dataPage.Controls.Add(this.closeButton);
            this.dataPage.Controls.Add(this.grid);
            this.dataPage.Location = new System.Drawing.Point(4, 22);
            this.dataPage.Name = "dataPage";
            this.dataPage.Padding = new System.Windows.Forms.Padding(3);
            this.dataPage.Size = new System.Drawing.Size(667, 489);
            this.dataPage.TabIndex = 0;
            this.dataPage.Text = "Данные";
            this.dataPage.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(380, 456);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(109, 23);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Импорт в Excel";
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
            this.chartControl.Location = new System.Drawing.Point(5, 192);
            this.chartControl.Margin = new System.Windows.Forms.Padding(2);
            this.chartControl.Name = "chartControl";
            this.chartControl.Size = new System.Drawing.Size(656, 259);
            this.chartControl.TabIndex = 5;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(495, 456);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(85, 23);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Обработать";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(586, 456);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Закрыть ";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(6, 7);
            this.grid.MainView = this.mainView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(655, 178);
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
            // CalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.splitContainer1);
            this.Name = "CalcForm";
            this.Size = new System.Drawing.Size(940, 515);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackStart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackEnd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.dataPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TrackBar trackStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.TrackBar trackEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.RadioButton rbRelation;
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
        private System.Windows.Forms.Button refTimeButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dataPage;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button closeButton;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView mainView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
    }
}
