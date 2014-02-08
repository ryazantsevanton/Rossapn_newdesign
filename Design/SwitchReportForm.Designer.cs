namespace Design
{
    partial class SwitchReportForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.parametersList = new DevExpress.XtraGrid.GridControl();
            this.parametersView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.timeInterval = new Design.BitrackBar();
            this.objectsList = new DevExpress.XtraGrid.GridControl();
            this.objectsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.chartsTabControl = new System.Windows.Forms.TabControl();
            this.closeButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.mainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.parametersList);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.objectsList);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartsTabControl);
            this.splitContainer1.Panel2.Controls.Add(this.closeButton);
            this.splitContainer1.Panel2.Controls.Add(this.runButton);
            this.splitContainer1.Panel2.Controls.Add(this.importButton);
            this.splitContainer1.Panel2.Controls.Add(this.grid);
            this.splitContainer1.Size = new System.Drawing.Size(1253, 634);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Параметры";
            // 
            // parametersList
            // 
            this.parametersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parametersList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.parametersList.Location = new System.Drawing.Point(3, 368);
            this.parametersList.MainView = this.parametersView;
            this.parametersList.Margin = new System.Windows.Forms.Padding(4);
            this.parametersList.Name = "parametersList";
            this.parametersList.Size = new System.Drawing.Size(351, 262);
            this.parametersList.TabIndex = 29;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.intervalLabel);
            this.panel1.Controls.Add(this.timeInterval);
            this.panel1.Location = new System.Drawing.Point(3, 250);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Size = new System.Drawing.Size(351, 84);
            this.panel1.TabIndex = 28;
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
            this.timeInterval.Size = new System.Drawing.Size(343, 59);
            this.timeInterval.TabIndex = 5;
            this.timeInterval.TickCount = 30;
            this.timeInterval.Up = 0;
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
            this.objectsList.Size = new System.Drawing.Size(334, 206);
            this.objectsList.TabIndex = 5;
            this.objectsList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.objectsView});
            // 
            // objectsView
            // 
            this.objectsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cId,
            this.cObject,
            this.gridColumn6,
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
            this.cObject.VisibleIndex = 0;
            this.cObject.Width = 255;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "gridColumn6";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Лицензионный участок";
            this.gridColumn4.FieldName = "cLicField";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Куст";
            this.gridColumn5.FieldName = "cBranch";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
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
            // chartsTabControl
            // 
            this.chartsTabControl.Location = new System.Drawing.Point(9, 252);
            this.chartsTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.chartsTabControl.Name = "chartsTabControl";
            this.chartsTabControl.SelectedIndex = 0;
            this.chartsTabControl.Size = new System.Drawing.Size(871, 335);
            this.chartsTabControl.TabIndex = 7;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(780, 594);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 28);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Закрыть ";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(639, 594);
            this.runButton.Margin = new System.Windows.Forms.Padding(4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(113, 28);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Обработать";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(469, 594);
            this.importButton.Margin = new System.Windows.Forms.Padding(4);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(145, 28);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Экспорт в Excel";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grid.Location = new System.Drawing.Point(7, 4);
            this.grid.MainView = this.mainView;
            this.grid.Margin = new System.Windows.Forms.Padding(4);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(873, 240);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainView});
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
            // SwitchReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SwitchReportForm";
            this.Size = new System.Drawing.Size(1253, 634);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parametersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl objectsList;
        private DevExpress.XtraGrid.Views.Grid.GridView objectsView;
        private DevExpress.XtraGrid.Columns.GridColumn cId;
        private DevExpress.XtraGrid.Columns.GridColumn cObject;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button closeButton;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView mainView;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label intervalLabel;
        private BitrackBar timeInterval;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl parametersList;
        private DevExpress.XtraGrid.Views.Grid.GridView parametersView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.TabControl chartsTabControl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}
