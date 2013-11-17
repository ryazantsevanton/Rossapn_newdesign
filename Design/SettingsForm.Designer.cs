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
            ((System.ComponentModel.ISupportInitialize)(this.scaleDatas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npDost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npCase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdShedule)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество делений грубого датчика";
            // 
            // scaleDatas
            // 
            this.scaleDatas.Location = new System.Drawing.Point(324, 27);
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
            this.scaleDatas.Size = new System.Drawing.Size(120, 20);
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
            this.label2.Location = new System.Drawing.Point(43, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Интервал достоверности (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 13);
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
            this.npDost.Location = new System.Drawing.Point(324, 59);
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
            this.npDost.Size = new System.Drawing.Size(120, 20);
            this.npDost.TabIndex = 4;
            this.npDost.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // npCase1
            // 
            this.npCase1.Location = new System.Drawing.Point(324, 95);
            this.npCase1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.npCase1.Name = "npCase1";
            this.npCase1.Size = new System.Drawing.Size(120, 20);
            this.npCase1.TabIndex = 5;
            this.npCase1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(295, 339);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(402, 339);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Интервал перехода по расписанию";
            // 
            // npdShedule
            // 
            this.npdShedule.Location = new System.Drawing.Point(324, 134);
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
            30,
            0,
            0,
            0});
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.npdShedule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.npCase1);
            this.Controls.Add(this.npDost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scaleDatas);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Size = new System.Drawing.Size(950, 520);
            ((System.ComponentModel.ISupportInitialize)(this.scaleDatas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npDost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npCase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdShedule)).EndInit();
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
    }
}
