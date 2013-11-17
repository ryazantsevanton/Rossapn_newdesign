namespace Design
{
    partial class AdminControl
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
            this.components = new System.ComponentModel.Container();
            this.userList = new DevExpress.XtraGrid.GridControl();
            this.accountsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.login = new DevExpress.XtraGrid.Columns.GridColumn();
            this.role = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.journalTable = new DevExpress.XtraGrid.GridControl();
            this.journalView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.datetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.action = new DevExpress.XtraGrid.Columns.GridColumn();
            this.arguments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.accountContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.userList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journalTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.accountContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userList.Location = new System.Drawing.Point(8, 23);
            this.userList.MainView = this.accountsView;
            this.userList.Name = "userList";
            this.userList.Padding = new System.Windows.Forms.Padding(3);
            this.userList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.userList.Size = new System.Drawing.Size(258, 494);
            this.userList.TabIndex = 6;
            this.userList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.accountsView});
            // 
            // accountsView
            // 
            this.accountsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.login,
            this.role});
            this.accountsView.GridControl = this.userList;
            this.accountsView.Name = "accountsView";
            this.accountsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.accountsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.accountsView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.accountsView.OptionsCustomization.AllowColumnMoving = false;
            this.accountsView.OptionsCustomization.AllowFilter = false;
            this.accountsView.OptionsCustomization.AllowGroup = false;
            this.accountsView.OptionsCustomization.AllowQuickHideColumns = false;
            this.accountsView.OptionsCustomization.AllowSort = false;
            this.accountsView.OptionsView.ShowGroupPanel = false;
            this.accountsView.OptionsView.ShowIndicator = false;
            // 
            // login
            // 
            this.login.Caption = "Логин";
            this.login.FieldName = "login";
            this.login.Name = "login";
            this.login.OptionsColumn.AllowEdit = false;
            this.login.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.login.Visible = true;
            this.login.VisibleIndex = 0;
            // 
            // role
            // 
            this.role.Caption = "Группа";
            this.role.ColumnEdit = this.repositoryItemComboBox1;
            this.role.FieldName = "role";
            this.role.Name = "role";
            this.role.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.role.Visible = true;
            this.role.VisibleIndex = 1;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.userList);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer.Panel2.Controls.Add(this.closeButton);
            this.splitContainer.Panel2.Controls.Add(this.journalTable);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Size = new System.Drawing.Size(816, 522);
            this.splitContainer.SplitterDistance = 270;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Пользователи";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(411, 486);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(96, 30);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // journalTable
            // 
            this.journalTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.journalTable.Location = new System.Drawing.Point(4, 23);
            this.journalTable.MainView = this.journalView;
            this.journalTable.Name = "journalTable";
            this.journalTable.Padding = new System.Windows.Forms.Padding(3);
            this.journalTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2});
            this.journalTable.Size = new System.Drawing.Size(540, 458);
            this.journalTable.TabIndex = 9;
            this.journalTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.journalView});
            // 
            // journalView
            // 
            this.journalView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.datetime,
            this.action,
            this.arguments});
            this.journalView.GridControl = this.journalTable;
            this.journalView.Name = "journalView";
            this.journalView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.journalView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.journalView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.journalView.OptionsBehavior.Editable = false;
            this.journalView.OptionsBehavior.ReadOnly = true;
            this.journalView.OptionsCustomization.AllowColumnMoving = false;
            this.journalView.OptionsCustomization.AllowFilter = false;
            this.journalView.OptionsCustomization.AllowGroup = false;
            this.journalView.OptionsCustomization.AllowQuickHideColumns = false;
            this.journalView.OptionsCustomization.AllowSort = false;
            this.journalView.OptionsView.ShowGroupPanel = false;
            this.journalView.OptionsView.ShowIndicator = false;
            // 
            // datetime
            // 
            this.datetime.Caption = "Дата и время";
            this.datetime.FieldName = "datetime";
            this.datetime.Name = "datetime";
            this.datetime.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.datetime.Visible = true;
            this.datetime.VisibleIndex = 0;
            // 
            // action
            // 
            this.action.Caption = "Активность";
            this.action.FieldName = "action";
            this.action.Name = "action";
            this.action.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.action.Visible = true;
            this.action.VisibleIndex = 1;
            // 
            // arguments
            // 
            this.arguments.Caption = "Информация";
            this.arguments.FieldName = "arguments";
            this.arguments.Name = "arguments";
            this.arguments.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.arguments.Visible = true;
            this.arguments.VisibleIndex = 2;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Журнал действий в системе";
            // 
            // accountContextMenu
            // 
            this.accountContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.ChangeToolStripMenuItem,
            this.RemoveToolStripMenuItem});
            this.accountContextMenu.Name = "accountContextMenu";
            this.accountContextMenu.Size = new System.Drawing.Size(166, 70);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.AddToolStripMenuItem.Text = "Добавить";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.addAccountMenuClick);
            // 
            // ChangeToolStripMenuItem
            // 
            this.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem";
            this.ChangeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ChangeToolStripMenuItem.Text = "Сменить пароль";
            this.ChangeToolStripMenuItem.Click += new System.EventHandler(this.changePasswordMenuClick);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.RemoveToolStripMenuItem.Text = "Удалить";
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.removeAccountMenuClick);
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(816, 522);
            ((System.ComponentModel.ISupportInitialize)(this.userList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.journalTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.accountContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl userList;
        private DevExpress.XtraGrid.Views.Grid.GridView accountsView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private DevExpress.XtraGrid.Columns.GridColumn login;
        private DevExpress.XtraGrid.Columns.GridColumn role;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl journalTable;
        private DevExpress.XtraGrid.Views.Grid.GridView journalView;
        private DevExpress.XtraGrid.Columns.GridColumn datetime;
        private DevExpress.XtraGrid.Columns.GridColumn action;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn arguments;
        private System.Windows.Forms.ContextMenuStrip accountContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private System.Windows.Forms.Button closeButton;
    }
}
