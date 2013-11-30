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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.cbObjectGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.refTimeButton = new System.Windows.Forms.Button();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.rbRelation = new System.Windows.Forms.RadioButton();
            this.trackStart = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.trackEnd = new System.Windows.Forms.TrackBar();
            this.cbParameters = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.importButton = new System.Windows.Forms.Button();
            this.chartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.runButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.mainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.cbObjectGroup.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackStart)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // cbObjectGroup
            // 
            this.cbObjectGroup.Location = new System.Drawing.Point(19, 174);
            this.cbObjectGroup.Name = "cbObjectGroup";
            this.cbObjectGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbObjectGroup.Size = new System.Drawing.Size(257, 20);
            this.cbObjectGroup.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 155);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Куст / месторождение";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refTimeButton);
            this.groupBox1.Controls.Add(this.rbTime);
            this.groupBox1.Controls.Add(this.rbRelation);
            this.groupBox1.Location = new System.Drawing.Point(22, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 62);
            this.groupBox1.TabIndex = 15;
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
            // trackStart
            // 
            this.trackStart.Enabled = false;
            this.trackStart.Location = new System.Drawing.Point(19, 318);
            this.trackStart.Name = "trackStart";
            this.trackStart.Size = new System.Drawing.Size(254, 45);
            this.trackStart.TabIndex = 17;
            this.trackStart.ValueChanged += new System.EventHandler(this.trackStart_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbEnd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbStart);
            this.groupBox2.Location = new System.Drawing.Point(19, 420);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 74);
            this.groupBox2.TabIndex = 14;
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
            this.trackEnd.Location = new System.Drawing.Point(19, 369);
            this.trackEnd.Name = "trackEnd";
            this.trackEnd.Size = new System.Drawing.Size(254, 45);
            this.trackEnd.TabIndex = 16;
            this.trackEnd.ValueChanged += new System.EventHandler(this.trackEnd_ValueChanged);
            // 
            // cbParameters
            // 
            this.cbParameters.FormattingEnabled = true;
            this.cbParameters.Location = new System.Drawing.Point(22, 223);
            this.cbParameters.Name = "cbParameters";
            this.cbParameters.Size = new System.Drawing.Size(254, 21);
            this.cbParameters.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 197);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Параметры";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(637, 484);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(128, 23);
            this.importButton.TabIndex = 24;
            this.importButton.Text = "Импорт в Excel";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // chartControl
            // 
            this.chartControl.BorderlineColor = System.Drawing.Color.Gray;
            this.chartControl.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            this.chartControl.BorderlineWidth = 2;
            chartArea2.Name = "ChartArea1";
            this.chartControl.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartControl.Legends.Add(legend2);
            this.chartControl.Location = new System.Drawing.Point(282, 220);
            this.chartControl.Margin = new System.Windows.Forms.Padding(2);
            this.chartControl.Name = "chartControl";
            this.chartControl.Size = new System.Drawing.Size(656, 259);
            this.chartControl.TabIndex = 23;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(771, 484);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(85, 23);
            this.runButton.TabIndex = 22;
            this.runButton.Text = "Обработать";
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
            // ListSwitchesForm
            // 
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.chartControl);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.cbParameters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trackStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.trackEnd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cbObjectGroup);
            this.Name = "ListSwitchesForm";
            this.Size = new System.Drawing.Size(950, 520);
            ((System.ComponentModel.ISupportInitialize)(this.cbObjectGroup.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackStart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbObjectGroup;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button refTimeButton;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.RadioButton rbRelation;
        private System.Windows.Forms.TrackBar trackStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.TrackBar trackEnd;
        private System.Windows.Forms.ComboBox cbParameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button closeButton;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView mainView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
    }
}
