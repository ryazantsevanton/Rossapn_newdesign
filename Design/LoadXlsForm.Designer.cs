namespace Design
{
    partial class LoadXlsForm
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
            this.xlsFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileNamebuttonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.tabBar = new DevExpress.XtraTab.XtraTabControl();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.tbTimeEnter = new System.Windows.Forms.TextBox();
            this.timeShName = new System.Windows.Forms.RadioButton();
            this.timeManual = new System.Windows.Forms.RadioButton();
            this.timeColon = new System.Windows.Forms.RadioButton();
            this.objectTroupBox = new System.Windows.Forms.GroupBox();
            this.tbObjectEnter = new System.Windows.Forms.TextBox();
            this.paramGroupBox = new System.Windows.Forms.GroupBox();
            this.tbParamEnter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.paramShName = new System.Windows.Forms.RadioButton();
            this.paramManual = new System.Windows.Forms.RadioButton();
            this.paramColon = new System.Windows.Forms.RadioButton();
            this.loadButton = new DevExpress.XtraEditors.SimpleButton();
            this.closeButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fileNamebuttonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            this.timeGroupBox.SuspendLayout();
            this.objectTroupBox.SuspendLayout();
            this.paramGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbParamEnter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файл загрузки";
            // 
            // xlsFileDialog
            // 
            this.xlsFileDialog.SupportMultiDottedExtensions = true;
            // 
            // fileNamebuttonEdit
            // 
            this.fileNamebuttonEdit.Location = new System.Drawing.Point(140, 17);
            this.fileNamebuttonEdit.Name = "fileNamebuttonEdit";
            this.fileNamebuttonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fileNamebuttonEdit.Size = new System.Drawing.Size(511, 20);
            this.fileNamebuttonEdit.TabIndex = 1;
            // 
            // tabBar
            // 
            this.tabBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBar.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.tabBar.Appearance.Options.UseBackColor = true;
            this.tabBar.Location = new System.Drawing.Point(39, 59);
            this.tabBar.Name = "tabBar";
            this.tabBar.Size = new System.Drawing.Size(858, 300);
            this.tabBar.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(39, 44);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(858, 4);
            this.progressBar.TabIndex = 5;
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.tbTimeEnter);
            this.timeGroupBox.Controls.Add(this.timeShName);
            this.timeGroupBox.Controls.Add(this.timeManual);
            this.timeGroupBox.Controls.Add(this.timeColon);
            this.timeGroupBox.Location = new System.Drawing.Point(39, 369);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Size = new System.Drawing.Size(256, 135);
            this.timeGroupBox.TabIndex = 6;
            this.timeGroupBox.TabStop = false;
            this.timeGroupBox.Text = "Выбор времени";
            // 
            // tbTimeEnter
            // 
            this.tbTimeEnter.Enabled = false;
            this.tbTimeEnter.Location = new System.Drawing.Point(7, 89);
            this.tbTimeEnter.Name = "tbTimeEnter";
            this.tbTimeEnter.Size = new System.Drawing.Size(231, 21);
            this.tbTimeEnter.TabIndex = 5;
            // 
            // timeShName
            // 
            this.timeShName.AutoSize = true;
            this.timeShName.Enabled = false;
            this.timeShName.Location = new System.Drawing.Point(8, 21);
            this.timeShName.Name = "timeShName";
            this.timeShName.Size = new System.Drawing.Size(95, 17);
            this.timeShName.TabIndex = 4;
            this.timeShName.TabStop = true;
            this.timeShName.Text = "Имя закладки";
            this.timeShName.UseVisualStyleBackColor = true;
            // 
            // timeManual
            // 
            this.timeManual.AutoSize = true;
            this.timeManual.Location = new System.Drawing.Point(8, 66);
            this.timeManual.Name = "timeManual";
            this.timeManual.Size = new System.Drawing.Size(70, 17);
            this.timeManual.TabIndex = 1;
            this.timeManual.TabStop = true;
            this.timeManual.Text = "Вручную";
            this.timeManual.UseVisualStyleBackColor = true;
            // 
            // timeColon
            // 
            this.timeColon.AutoSize = true;
            this.timeColon.Enabled = false;
            this.timeColon.Location = new System.Drawing.Point(7, 43);
            this.timeColon.Name = "timeColon";
            this.timeColon.Size = new System.Drawing.Size(101, 17);
            this.timeColon.TabIndex = 0;
            this.timeColon.TabStop = true;
            this.timeColon.Text = "Номер колонки";
            this.timeColon.UseVisualStyleBackColor = true;
            // 
            // objectTroupBox
            // 
            this.objectTroupBox.Controls.Add(this.tbObjectEnter);
            this.objectTroupBox.Location = new System.Drawing.Point(301, 370);
            this.objectTroupBox.Name = "objectTroupBox";
            this.objectTroupBox.Size = new System.Drawing.Size(252, 135);
            this.objectTroupBox.TabIndex = 7;
            this.objectTroupBox.TabStop = false;
            this.objectTroupBox.Text = "Выбор Объекта";
            // 
            // tbObjectEnter
            // 
            this.tbObjectEnter.Enabled = false;
            this.tbObjectEnter.Location = new System.Drawing.Point(6, 19);
            this.tbObjectEnter.Multiline = true;
            this.tbObjectEnter.Name = "tbObjectEnter";
            this.tbObjectEnter.Size = new System.Drawing.Size(240, 92);
            this.tbObjectEnter.TabIndex = 11;
            // 
            // paramGroupBox
            // 
            this.paramGroupBox.Controls.Add(this.tbParamEnter);
            this.paramGroupBox.Controls.Add(this.paramShName);
            this.paramGroupBox.Controls.Add(this.paramManual);
            this.paramGroupBox.Controls.Add(this.paramColon);
            this.paramGroupBox.Location = new System.Drawing.Point(559, 369);
            this.paramGroupBox.Name = "paramGroupBox";
            this.paramGroupBox.Size = new System.Drawing.Size(257, 135);
            this.paramGroupBox.TabIndex = 8;
            this.paramGroupBox.TabStop = false;
            this.paramGroupBox.Text = "Выбор Параметра";
            // 
            // tbParamEnter
            // 
            this.tbParamEnter.Enabled = false;
            this.tbParamEnter.Location = new System.Drawing.Point(9, 91);
            this.tbParamEnter.Name = "tbParamEnter";
            this.tbParamEnter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbParamEnter.Size = new System.Drawing.Size(227, 20);
            this.tbParamEnter.TabIndex = 17;
            // 
            // paramShName
            // 
            this.paramShName.AutoSize = true;
            this.paramShName.Enabled = false;
            this.paramShName.Location = new System.Drawing.Point(9, 17);
            this.paramShName.Name = "paramShName";
            this.paramShName.Size = new System.Drawing.Size(95, 17);
            this.paramShName.TabIndex = 16;
            this.paramShName.TabStop = true;
            this.paramShName.Text = "Имя закладки";
            this.paramShName.UseVisualStyleBackColor = true;
            // 
            // paramManual
            // 
            this.paramManual.AutoSize = true;
            this.paramManual.Location = new System.Drawing.Point(9, 63);
            this.paramManual.Name = "paramManual";
            this.paramManual.Size = new System.Drawing.Size(70, 17);
            this.paramManual.TabIndex = 13;
            this.paramManual.TabStop = true;
            this.paramManual.Text = "Вручную";
            this.paramManual.UseVisualStyleBackColor = true;
            // 
            // paramColon
            // 
            this.paramColon.AutoSize = true;
            this.paramColon.Enabled = false;
            this.paramColon.Location = new System.Drawing.Point(9, 40);
            this.paramColon.Name = "paramColon";
            this.paramColon.Size = new System.Drawing.Size(101, 17);
            this.paramColon.TabIndex = 12;
            this.paramColon.TabStop = true;
            this.paramColon.Text = "Номер колонки";
            this.paramColon.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(822, 447);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 9;
            this.loadButton.Text = "Загрузить";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(822, 482);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Отмена";
            // 
            // LoadXlsForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.paramGroupBox);
            this.Controls.Add(this.objectTroupBox);
            this.Controls.Add(this.timeGroupBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabBar);
            this.Controls.Add(this.fileNamebuttonEdit);
            this.Controls.Add(this.label1);
            this.Name = "LoadXlsForm";
            this.Size = new System.Drawing.Size(950, 520);
            ((System.ComponentModel.ISupportInitialize)(this.fileNamebuttonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            this.objectTroupBox.ResumeLayout(false);
            this.objectTroupBox.PerformLayout();
            this.paramGroupBox.ResumeLayout(false);
            this.paramGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbParamEnter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog xlsFileDialog;
        private DevExpress.XtraEditors.ButtonEdit fileNamebuttonEdit;
        private DevExpress.XtraTab.XtraTabControl tabBar;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.GroupBox objectTroupBox;
        private System.Windows.Forms.GroupBox paramGroupBox;
        private DevExpress.XtraEditors.SimpleButton loadButton;
        private DevExpress.XtraEditors.SimpleButton closeButton;
        private System.Windows.Forms.RadioButton timeManual;
        private System.Windows.Forms.RadioButton timeColon;
        private System.Windows.Forms.RadioButton timeShName;
        private System.Windows.Forms.TextBox tbTimeEnter;
        private System.Windows.Forms.TextBox tbObjectEnter;
        private DevExpress.XtraEditors.ComboBoxEdit tbParamEnter;
        private System.Windows.Forms.RadioButton paramShName;
        private System.Windows.Forms.RadioButton paramManual;
        private System.Windows.Forms.RadioButton paramColon;

    }
}
