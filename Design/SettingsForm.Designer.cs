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
            this.label1 = new System.Windows.Forms.Label();
            this.scaleDatas = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.npDost = new System.Windows.Forms.NumericUpDown();
            this.npCase1 = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.npdShedule = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbArguments = new System.Windows.Forms.TextBox();
            this.cbEventCheckers = new System.Windows.Forms.ComboBox();
            this.cbParameters = new System.Windows.Forms.ComboBox();
            this.cbObjects = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scaleDatas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npDost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npCase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdShedule)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество делений грубого датчика";
            // 
            // scaleDatas
            // 
            this.scaleDatas.Location = new System.Drawing.Point(415, 17);
            this.scaleDatas.Margin = new System.Windows.Forms.Padding(4);
            this.scaleDatas.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.scaleDatas.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scaleDatas.Name = "scaleDatas";
            this.scaleDatas.Size = new System.Drawing.Size(160, 22);
            this.scaleDatas.TabIndex = 1;
            this.scaleDatas.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Интервал достоверности (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Критический интервал перехода события 1";
            // 
            // npDost
            // 
            this.npDost.DecimalPlaces = 5;
            this.npDost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.npDost.Location = new System.Drawing.Point(415, 57);
            this.npDost.Margin = new System.Windows.Forms.Padding(4);
            this.npDost.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            327680});
            this.npDost.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.npDost.Name = "npDost";
            this.npDost.Size = new System.Drawing.Size(160, 22);
            this.npDost.TabIndex = 4;
            this.npDost.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // npCase1
            // 
            this.npCase1.Location = new System.Drawing.Point(415, 101);
            this.npCase1.Margin = new System.Windows.Forms.Padding(4);
            this.npCase1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.npCase1.Name = "npCase1";
            this.npCase1.Size = new System.Drawing.Size(160, 22);
            this.npCase1.TabIndex = 5;
            this.npCase1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(512, 248);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(626, 248);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 151);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Интервал перехода по расписанию";
            // 
            // npdShedule
            // 
            this.npdShedule.Location = new System.Drawing.Point(415, 149);
            this.npdShedule.Margin = new System.Windows.Forms.Padding(4);
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
            this.npdShedule.Size = new System.Drawing.Size(160, 22);
            this.npdShedule.TabIndex = 9;
            this.npdShedule.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Настройки событий";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.tbArguments);
            this.panel1.Controls.Add(this.cbEventCheckers);
            this.panel1.Controls.Add(this.cbParameters);
            this.panel1.Controls.Add(this.cbObjects);
            this.panel1.Location = new System.Drawing.Point(51, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 78);
            this.panel1.TabIndex = 12;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(772, 35);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(26, 28);
            this.btnHelp.TabIndex = 19;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.OnHelpButtonClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(805, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Аргументы";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(517, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Событие";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Параметр";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Объект";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(1050, 34);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 28);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnApplyButtonClick);
            // 
            // tbArguments
            // 
            this.tbArguments.Location = new System.Drawing.Point(805, 40);
            this.tbArguments.Name = "tbArguments";
            this.tbArguments.Size = new System.Drawing.Size(238, 22);
            this.tbArguments.TabIndex = 3;
            // 
            // cbEventCheckers
            // 
            this.cbEventCheckers.FormattingEnabled = true;
            this.cbEventCheckers.Location = new System.Drawing.Point(520, 38);
            this.cbEventCheckers.Name = "cbEventCheckers";
            this.cbEventCheckers.Size = new System.Drawing.Size(245, 24);
            this.cbEventCheckers.TabIndex = 2;
            // 
            // cbParameters
            // 
            this.cbParameters.FormattingEnabled = true;
            this.cbParameters.Location = new System.Drawing.Point(269, 38);
            this.cbParameters.Name = "cbParameters";
            this.cbParameters.Size = new System.Drawing.Size(245, 24);
            this.cbParameters.TabIndex = 1;
            // 
            // cbObjects
            // 
            this.cbObjects.FormattingEnabled = true;
            this.cbObjects.Location = new System.Drawing.Point(18, 38);
            this.cbObjects.Name = "cbObjects";
            this.cbObjects.Size = new System.Drawing.Size(245, 24);
            this.cbObjects.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.scaleDatas);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.npdShedule);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.npDost);
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Controls.Add(this.npCase1);
            this.panel2.Location = new System.Drawing.Point(51, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 296);
            this.panel2.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Другие настройки";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.Size = new System.Drawing.Size(1267, 640);
            ((System.ComponentModel.ISupportInitialize)(this.scaleDatas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npDost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npCase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdShedule)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown scaleDatas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown npDost;
        private System.Windows.Forms.NumericUpDown npCase1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown npdShedule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbArguments;
        private System.Windows.Forms.ComboBox cbEventCheckers;
        private System.Windows.Forms.ComboBox cbParameters;
        private System.Windows.Forms.ComboBox cbObjects;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHelp;
    }
}
