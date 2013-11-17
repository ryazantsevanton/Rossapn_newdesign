namespace Design
{
    partial class RateCalculatorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.validButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.tbFormulaExp = new System.Windows.Forms.TextBox();
            this.gridRateParams = new DevExpress.XtraGrid.GridControl();
            this.viewRateParams = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colParamId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParamName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParamType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colParamValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTestValues = new DevExpress.XtraGrid.GridControl();
            this.viewTestValues = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTestName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTestValues = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridRateList = new DevExpress.XtraGrid.GridControl();
            this.viewRateList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpression = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.testCalcValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridRateParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewRateParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTestValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTestValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRateList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewRateList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список формул";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Список Переменных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тестовые значения";
            // 
            // validButton
            // 
            this.validButton.Location = new System.Drawing.Point(464, 90);
            this.validButton.Name = "validButton";
            this.validButton.Size = new System.Drawing.Size(85, 23);
            this.validButton.TabIndex = 3;
            this.validButton.Text = "Проверить";
            this.validButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(464, 177);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(85, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // tbFormulaExp
            // 
            this.tbFormulaExp.Location = new System.Drawing.Point(148, 245);
            this.tbFormulaExp.Name = "tbFormulaExp";
            this.tbFormulaExp.Size = new System.Drawing.Size(731, 20);
            this.tbFormulaExp.TabIndex = 5;
            // 
            // gridRateParams
            // 
            this.gridRateParams.EmbeddedNavigator.TextStringFormat = "Параметр {0} из {1}";
            this.gridRateParams.Location = new System.Drawing.Point(67, 293);
            this.gridRateParams.MainView = this.viewRateParams;
            this.gridRateParams.Name = "gridRateParams";
            this.gridRateParams.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridRateParams.Size = new System.Drawing.Size(812, 204);
            this.gridRateParams.TabIndex = 6;
            this.gridRateParams.UseEmbeddedNavigator = true;
            this.gridRateParams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewRateParams});
            // 
            // viewRateParams
            // 
            this.viewRateParams.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colParamId,
            this.colParamName,
            this.colCode,
            this.colParamType,
            this.colParamValue});
            this.viewRateParams.GridControl = this.gridRateParams;
            this.viewRateParams.Name = "viewRateParams";
            this.viewRateParams.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.viewRateParams.OptionsView.ShowGroupPanel = false;
            this.viewRateParams.OptionsView.ShowIndicator = false;
            // 
            // colParamId
            // 
            this.colParamId.Caption = "ParamID";
            this.colParamId.FieldName = "Id";
            this.colParamId.Name = "colParamId";
            // 
            // colParamName
            // 
            this.colParamName.Caption = "Имя Параметра";
            this.colParamName.FieldName = "Name";
            this.colParamName.Name = "colParamName";
            this.colParamName.Visible = true;
            this.colParamName.VisibleIndex = 0;
            this.colParamName.Width = 274;
            // 
            // colCode
            // 
            this.colCode.Caption = "Код";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 80;
            // 
            // colParamType
            // 
            this.colParamType.Caption = "Тип параметра";
            this.colParamType.ColumnEdit = this.repositoryItemComboBox1;
            this.colParamType.FieldName = "TypeName";
            this.colParamType.Name = "colParamType";
            this.colParamType.Visible = true;
            this.colParamType.VisibleIndex = 2;
            this.colParamType.Width = 250;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colParamValue
            // 
            this.colParamValue.Caption = "Значение Параметра";
            this.colParamValue.FieldName = "Value";
            this.colParamValue.Name = "colParamValue";
            this.colParamValue.Visible = true;
            this.colParamValue.VisibleIndex = 3;
            this.colParamValue.Width = 150;
            // 
            // gridTestValues
            // 
            this.gridTestValues.Location = new System.Drawing.Point(567, 38);
            this.gridTestValues.MainView = this.viewTestValues;
            this.gridTestValues.Name = "gridTestValues";
            this.gridTestValues.Size = new System.Drawing.Size(312, 201);
            this.gridTestValues.TabIndex = 7;
            this.gridTestValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewTestValues});
            // 
            // viewTestValues
            // 
            this.viewTestValues.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTestName,
            this.colTestValues});
            this.viewTestValues.GridControl = this.gridTestValues;
            this.viewTestValues.Name = "viewTestValues";
            this.viewTestValues.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewTestValues.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewTestValues.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.viewTestValues.OptionsView.ShowGroupPanel = false;
            this.viewTestValues.OptionsView.ShowIndicator = false;
            // 
            // colTestName
            // 
            this.colTestName.Caption = "Имя параметра";
            this.colTestName.FieldName = "ParamName";
            this.colTestName.Name = "colTestName";
            this.colTestName.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTestName.Visible = true;
            this.colTestName.VisibleIndex = 0;
            this.colTestName.Width = 200;
            // 
            // colTestValues
            // 
            this.colTestValues.Caption = "Тестовые значения";
            this.colTestValues.FieldName = "ParamValue";
            this.colTestValues.Name = "colTestValues";
            this.colTestValues.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTestValues.Visible = true;
            this.colTestValues.VisibleIndex = 1;
            this.colTestValues.Width = 110;
            // 
            // gridRateList
            // 
            this.gridRateList.EmbeddedNavigator.TextStringFormat = "Формула {0} из {1}";
            this.gridRateList.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridRateList_EmbeddedNavigator_ButtonClick);
            this.gridRateList.Location = new System.Drawing.Point(67, 41);
            this.gridRateList.MainView = this.viewRateList;
            this.gridRateList.Name = "gridRateList";
            this.gridRateList.Size = new System.Drawing.Size(380, 198);
            this.gridRateList.TabIndex = 8;
            this.gridRateList.UseEmbeddedNavigator = true;
            this.gridRateList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewRateList});
            // 
            // viewRateList
            // 
            this.viewRateList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colExpression});
            this.viewRateList.GridControl = this.gridRateList;
            this.viewRateList.Name = "viewRateList";
            this.viewRateList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.viewRateList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.viewRateList.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.viewRateList.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.viewRateList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.viewRateList.OptionsView.ShowDetailButtons = false;
            this.viewRateList.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "Номер";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 100;
            // 
            // colName
            // 
            this.colName.Caption = "Название";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 278;
            // 
            // colExpression
            // 
            this.colExpression.FieldName = "Expression";
            this.colExpression.Name = "colExpression";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Выражение";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(464, 148);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(464, 119);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(85, 23);
            this.testButton.TabIndex = 11;
            this.testButton.Text = "Рассчитать";
            this.testButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Расчетное значение";
            // 
            // testCalcValue
            // 
            this.testCalcValue.AutoSize = true;
            this.testCalcValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testCalcValue.ForeColor = System.Drawing.Color.Red;
            this.testCalcValue.Location = new System.Drawing.Point(311, 274);
            this.testCalcValue.Name = "testCalcValue";
            this.testCalcValue.Size = new System.Drawing.Size(28, 13);
            this.testCalcValue.TabIndex = 13;
            this.testCalcValue.Text = "test";
            // 
            // RateCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.testCalcValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gridRateList);
            this.Controls.Add(this.gridTestValues);
            this.Controls.Add(this.gridRateParams);
            this.Controls.Add(this.tbFormulaExp);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.validButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RateCalculatorForm";
            this.Size = new System.Drawing.Size(950, 520);
            ((System.ComponentModel.ISupportInitialize)(this.gridRateParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewRateParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTestValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTestValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRateList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewRateList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button validButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox tbFormulaExp;
        private DevExpress.XtraGrid.GridControl gridRateParams;
        private DevExpress.XtraGrid.Views.Grid.GridView viewRateParams;
        private DevExpress.XtraGrid.GridControl gridTestValues;
        private DevExpress.XtraGrid.Views.Grid.GridView viewTestValues;
        private DevExpress.XtraGrid.GridControl gridRateList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewRateList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button testButton;
        private DevExpress.XtraGrid.Columns.GridColumn colParamId;
        private DevExpress.XtraGrid.Columns.GridColumn colParamName;
        private DevExpress.XtraGrid.Columns.GridColumn colParamType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colParamValue;
        private DevExpress.XtraGrid.Columns.GridColumn colTestName;
        private DevExpress.XtraGrid.Columns.GridColumn colTestValues;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colExpression;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label testCalcValue;
    }
}
