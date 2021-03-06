﻿namespace Design
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.appMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.iExit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.loadButton = new DevExpress.XtraBars.BarButtonItem();
            this.iHelp = new DevExpress.XtraBars.BarButtonItem();
            this.iAbout = new DevExpress.XtraBars.BarButtonItem();
            this.iBoldFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iItalicFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iUnderlinedFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iLeftTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.iCenterTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.iRightTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.editData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.objectButton = new DevExpress.XtraBars.BarButtonItem();
            this.paramButton = new DevExpress.XtraBars.BarButtonItem();
            this.calcButton = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.clearButton = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup2 = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonGroup3 = new DevExpress.XtraBars.BarButtonGroup();
            this.bbiReport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.adminButton = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCalc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSettings = new DevExpress.XtraBars.BarButtonItem();
            this.bbiScheduleRep = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.homeRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.fileRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.adminPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exitRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.helpRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.helpRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.topPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gvLastEvents = new DevExpress.XtraGrid.GridControl();
            this.lastEventsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEntity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPredicate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelEvents = new System.Windows.Forms.Label();
            this.gcRealValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCritValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLastEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastEventsView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.appMenu;
            this.ribbonControl.ApplicationButtonText = null;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Images = this.ribbonImageCollection;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.loadButton,
            this.iExit,
            this.iHelp,
            this.iAbout,
            this.iBoldFontStyle,
            this.iItalicFontStyle,
            this.iUnderlinedFontStyle,
            this.iLeftTextAlign,
            this.iCenterTextAlign,
            this.iRightTextAlign,
            this.editData,
            this.barButtonItem3,
            this.objectButton,
            this.paramButton,
            this.calcButton,
            this.barButtonGroup1,
            this.clearButton,
            this.barButtonGroup2,
            this.barButtonGroup3,
            this.bbiReport,
            this.barButtonItem4,
            this.barButtonItem5,
            this.adminButton,
            this.bbiCalc,
            this.bbiSettings,
            this.bbiScheduleRep});
            this.ribbonControl.LargeImages = this.ribbonImageCollectionLarge;
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl.MaxItemId = 81;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.PageHeaderItemLinks.Add(this.iAbout);
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.homeRibbonPage,
            this.ribbonPage2,
            this.ribbonPage1,
            this.helpRibbonPage});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(1108, 155);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iHelp);
            // 
            // appMenu
            // 
            this.appMenu.ItemLinks.Add(this.iExit);
            this.appMenu.Name = "appMenu";
            this.appMenu.Ribbon = this.ribbonControl;
            this.appMenu.ShowRightPane = true;
            // 
            // iExit
            // 
            this.iExit.Caption = "Выход";
            this.iExit.Description = "Closes this program after prompting you to save unsaved data.";
            this.iExit.Hint = "Closes this program after prompting you to save unsaved data";
            this.iExit.Id = 20;
            this.iExit.ImageIndex = 6;
            this.iExit.LargeImageIndex = 6;
            this.iExit.Name = "iExit";
            // 
            // ribbonImageCollection
            // 
            this.ribbonImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollection.ImageStream")));
            this.ribbonImageCollection.Images.SetKeyName(0, "Ribbon_New_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(1, "Ribbon_Open_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(2, "Ribbon_Close_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(3, "Ribbon_Find_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(4, "Ribbon_Save_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(6, "Ribbon_Exit_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(7, "Ribbon_Content_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(8, "Ribbon_Info_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(9, "Ribbon_Bold_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(10, "Ribbon_Italic_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(11, "Ribbon_Underline_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(12, "Ribbon_AlignLeft_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(13, "Ribbon_AlignCenter_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(14, "Ribbon_AlignRight_16x16.png");
            // 
            // loadButton
            // 
            this.loadButton.Caption = "&Загрузить";
            this.loadButton.Description = "Загрузка данных из Excel";
            this.loadButton.Hint = "Загрузка данных из Excel";
            this.loadButton.Id = 3;
            this.loadButton.ImageIndex = 2;
            this.loadButton.LargeImageIndex = 2;
            this.loadButton.Name = "loadButton";
            this.loadButton.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // iHelp
            // 
            this.iHelp.Caption = "Помощь";
            this.iHelp.Description = "Start the program help system.";
            this.iHelp.Hint = "Start the program help system";
            this.iHelp.Id = 22;
            this.iHelp.ImageIndex = 7;
            this.iHelp.LargeImageIndex = 7;
            this.iHelp.Name = "iHelp";
            // 
            // iAbout
            // 
            this.iAbout.Caption = "О программе";
            this.iAbout.Description = "Displays general program information.";
            this.iAbout.Hint = "Displays general program information";
            this.iAbout.Id = 24;
            this.iAbout.ImageIndex = 8;
            this.iAbout.LargeImageIndex = 8;
            this.iAbout.Name = "iAbout";
            // 
            // iBoldFontStyle
            // 
            this.iBoldFontStyle.Caption = "Bold";
            this.iBoldFontStyle.Id = 53;
            this.iBoldFontStyle.ImageIndex = 9;
            this.iBoldFontStyle.Name = "iBoldFontStyle";
            // 
            // iItalicFontStyle
            // 
            this.iItalicFontStyle.Caption = "Italic";
            this.iItalicFontStyle.Id = 54;
            this.iItalicFontStyle.ImageIndex = 10;
            this.iItalicFontStyle.Name = "iItalicFontStyle";
            // 
            // iUnderlinedFontStyle
            // 
            this.iUnderlinedFontStyle.Caption = "Underlined";
            this.iUnderlinedFontStyle.Id = 55;
            this.iUnderlinedFontStyle.ImageIndex = 11;
            this.iUnderlinedFontStyle.Name = "iUnderlinedFontStyle";
            // 
            // iLeftTextAlign
            // 
            this.iLeftTextAlign.Caption = "Left";
            this.iLeftTextAlign.Id = 57;
            this.iLeftTextAlign.ImageIndex = 12;
            this.iLeftTextAlign.Name = "iLeftTextAlign";
            // 
            // iCenterTextAlign
            // 
            this.iCenterTextAlign.Caption = "Center";
            this.iCenterTextAlign.Id = 58;
            this.iCenterTextAlign.ImageIndex = 13;
            this.iCenterTextAlign.Name = "iCenterTextAlign";
            // 
            // iRightTextAlign
            // 
            this.iRightTextAlign.Caption = "Right";
            this.iRightTextAlign.Id = 59;
            this.iRightTextAlign.ImageIndex = 14;
            this.iRightTextAlign.Name = "iRightTextAlign";
            // 
            // editData
            // 
            this.editData.Caption = "Данные";
            this.editData.Id = 62;
            this.editData.ImageIndex = 7;
            this.editData.LargeImageIndex = 7;
            this.editData.Name = "editData";
            this.editData.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 63;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // objectButton
            // 
            this.objectButton.Caption = "Объекты";
            this.objectButton.Id = 64;
            this.objectButton.ImageIndex = 7;
            this.objectButton.LargeImageIndex = 7;
            this.objectButton.Name = "objectButton";
            // 
            // paramButton
            // 
            this.paramButton.Caption = "Параметры";
            this.paramButton.Id = 65;
            this.paramButton.ImageIndex = 7;
            this.paramButton.LargeImageIndex = 7;
            this.paramButton.Name = "paramButton";
            // 
            // calcButton
            // 
            this.calcButton.Caption = "Формулы";
            this.calcButton.Id = 66;
            this.calcButton.Name = "calcButton";
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 67;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // clearButton
            // 
            this.clearButton.Caption = "Очистить";
            this.clearButton.Id = 68;
            this.clearButton.Name = "clearButton";
            // 
            // barButtonGroup2
            // 
            this.barButtonGroup2.Caption = "barButtonGroup2";
            this.barButtonGroup2.Id = 69;
            this.barButtonGroup2.Name = "barButtonGroup2";
            // 
            // barButtonGroup3
            // 
            this.barButtonGroup3.Caption = "barButtonGroup3";
            this.barButtonGroup3.Id = 73;
            this.barButtonGroup3.Name = "barButtonGroup3";
            // 
            // bbiReport
            // 
            this.bbiReport.Caption = "Отчет по скважине";
            this.bbiReport.Id = 74;
            this.bbiReport.Name = "bbiReport";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Пользователи";
            this.barButtonItem4.Id = 75;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 76;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // adminButton
            // 
            this.adminButton.Caption = "Пользователи";
            this.adminButton.Id = 77;
            this.adminButton.Name = "adminButton";
            this.adminButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.adminButtonClick);
            // 
            // bbiCalc
            // 
            this.bbiCalc.Caption = "Рассчитать";
            this.bbiCalc.Id = 78;
            this.bbiCalc.Name = "bbiCalc";
            // 
            // bbiSettings
            // 
            this.bbiSettings.Caption = "Настройки";
            this.bbiSettings.Id = 79;
            this.bbiSettings.Name = "bbiSettings";
            // 
            // bbiScheduleRep
            // 
            this.bbiScheduleRep.Caption = "Журна переключений";
            this.bbiScheduleRep.Id = 80;
            this.bbiScheduleRep.Name = "bbiScheduleRep";
            // 
            // ribbonImageCollectionLarge
            // 
            this.ribbonImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge.ImageStream")));
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png");
            // 
            // homeRibbonPage
            // 
            this.homeRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.fileRibbonPageGroup,
            this.ribbonPageGroup3,
            this.adminPageGroup,
            this.exitRibbonPageGroup});
            this.homeRibbonPage.Name = "homeRibbonPage";
            this.homeRibbonPage.Text = "Главная";
            // 
            // fileRibbonPageGroup
            // 
            this.fileRibbonPageGroup.ItemLinks.Add(this.loadButton);
            this.fileRibbonPageGroup.ItemLinks.Add(this.clearButton);
            this.fileRibbonPageGroup.ItemLinks.Add(this.bbiCalc);
            this.fileRibbonPageGroup.Name = "fileRibbonPageGroup";
            this.fileRibbonPageGroup.Text = "Данные";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.editData);
            this.ribbonPageGroup3.ItemLinks.Add(this.objectButton);
            this.ribbonPageGroup3.ItemLinks.Add(this.paramButton);
            this.ribbonPageGroup3.ItemLinks.Add(this.calcButton);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Редактор";
            // 
            // adminPageGroup
            // 
            this.adminPageGroup.ItemLinks.Add(this.adminButton);
            this.adminPageGroup.Name = "adminPageGroup";
            this.adminPageGroup.Text = "Администрирование";
            // 
            // exitRibbonPageGroup
            // 
            this.exitRibbonPageGroup.ItemLinks.Add(this.iExit);
            this.exitRibbonPageGroup.Name = "exitRibbonPageGroup";
            this.exitRibbonPageGroup.Text = "Выход";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Отчеты";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiReport);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiScheduleRep);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Переключения";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Настройки";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiSettings);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Настройки";
            // 
            // helpRibbonPage
            // 
            this.helpRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.helpRibbonPageGroup});
            this.helpRibbonPage.Name = "helpRibbonPage";
            this.helpRibbonPage.Text = "Помощь";
            // 
            // helpRibbonPageGroup
            // 
            this.helpRibbonPageGroup.ItemLinks.Add(this.iHelp);
            this.helpRibbonPageGroup.ItemLinks.Add(this.iAbout);
            this.helpRibbonPageGroup.Name = "helpRibbonPageGroup";
            this.helpRibbonPageGroup.Text = "Help";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 1008);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1108, 31);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "&Загрузить";
            this.barButtonItem1.Description = "Загрузка данных из Excel";
            this.barButtonItem1.Hint = "Загрузка данных из Excel";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageIndex = 2;
            this.barButtonItem1.LargeImageIndex = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "&Загрузить";
            this.barButtonItem2.Description = "Загрузка данных из Excel";
            this.barButtonItem2.Hint = "Загрузка данных из Excel";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.ImageIndex = 2;
            this.barButtonItem2.LargeImageIndex = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Расчеты";
            // 
            // topPanel
            // 
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1108, 679);
            this.topPanel.TabIndex = 2;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 155);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.topPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gvLastEvents);
            this.splitContainer.Panel2.Controls.Add(this.labelEvents);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.splitContainer.Size = new System.Drawing.Size(1108, 853);
            this.splitContainer.SplitterDistance = 679;
            this.splitContainer.TabIndex = 5;
            // 
            // gvLastEvents
            // 
            this.gvLastEvents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gvLastEvents.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvLastEvents.Location = new System.Drawing.Point(0, 26);
            this.gvLastEvents.MainView = this.lastEventsView;
            this.gvLastEvents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvLastEvents.Name = "gvLastEvents";
            this.gvLastEvents.Size = new System.Drawing.Size(1100, 144);
            this.gvLastEvents.TabIndex = 8;
            this.gvLastEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.lastEventsView});
            // 
            // lastEventsView
            // 
            this.lastEventsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTime,
            this.gcEvent,
            this.gcEntity,
            this.gcPredicate,
            this.gcRealValue,
            this.gcCritValue});
            this.lastEventsView.GridControl = this.gvLastEvents;
            this.lastEventsView.Name = "lastEventsView";
            this.lastEventsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.lastEventsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.lastEventsView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.lastEventsView.OptionsBehavior.Editable = false;
            this.lastEventsView.OptionsView.ShowGroupPanel = false;
            this.lastEventsView.OptionsView.ShowIndicator = false;
            // 
            // gcTime
            // 
            this.gcTime.Caption = "Время";
            this.gcTime.FieldName = "gcTime";
            this.gcTime.Name = "gcTime";
            this.gcTime.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gcTime.Visible = true;
            this.gcTime.VisibleIndex = 0;
            // 
            // gcEvent
            // 
            this.gcEvent.Caption = "Событие";
            this.gcEvent.FieldName = "gcEvent";
            this.gcEvent.Name = "gcEvent";
            this.gcEvent.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gcEvent.Visible = true;
            this.gcEvent.VisibleIndex = 1;
            // 
            // gcEntity
            // 
            this.gcEntity.Caption = "Объект";
            this.gcEntity.FieldName = "gcEntity";
            this.gcEntity.Name = "gcEntity";
            this.gcEntity.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gcEntity.Visible = true;
            this.gcEntity.VisibleIndex = 2;
            // 
            // gcPredicate
            // 
            this.gcPredicate.Caption = "Параметр";
            this.gcPredicate.FieldName = "gcPredicate";
            this.gcPredicate.Name = "gcPredicate";
            this.gcPredicate.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gcPredicate.Visible = true;
            this.gcPredicate.VisibleIndex = 3;
            // 
            // labelEvents
            // 
            this.labelEvents.AutoSize = true;
            this.labelEvents.Location = new System.Drawing.Point(3, 7);
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(138, 17);
            this.labelEvents.TabIndex = 0;
            this.labelEvents.Text = "Последние события";
            // 
            // gcRealValue
            // 
            this.gcRealValue.Caption = "Реальное значение";
            this.gcRealValue.FieldName = "gcRealValue";
            this.gcRealValue.Name = "gcRealValue";
            this.gcRealValue.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gcRealValue.Visible = true;
            this.gcRealValue.VisibleIndex = 4;
            // 
            // gcCritValue
            // 
            this.gcCritValue.Caption = "Критическое значение";
            this.gcCritValue.FieldName = "gcCritValue";
            this.gcCritValue.Name = "gcCritValue";
            this.gcCritValue.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gcCritValue.Visible = true;
            this.gcCritValue.VisibleIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 1039);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "ЗАО НПП ГА \"Луч\"";
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLastEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastEventsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem loadButton;
        private DevExpress.XtraBars.BarButtonItem iExit;
        private DevExpress.XtraBars.BarButtonItem iHelp;
        private DevExpress.XtraBars.BarButtonItem iAbout;
        private DevExpress.XtraBars.BarButtonItem iBoldFontStyle;
        private DevExpress.XtraBars.BarButtonItem iItalicFontStyle;
        private DevExpress.XtraBars.BarButtonItem iUnderlinedFontStyle;
        private DevExpress.XtraBars.BarButtonItem iLeftTextAlign;
        private DevExpress.XtraBars.BarButtonItem iCenterTextAlign;
        private DevExpress.XtraBars.BarButtonItem iRightTextAlign;
        private DevExpress.XtraBars.Ribbon.RibbonPage homeRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup fileRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup exitRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPage helpRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup helpRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu appMenu;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.Utils.ImageCollection ribbonImageCollection;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem editData;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem objectButton;
        private DevExpress.XtraBars.BarButtonItem paramButton;
        private DevExpress.XtraBars.BarButtonItem calcButton;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel topPanel;
        private DevExpress.XtraBars.BarButtonItem clearButton;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup2;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem adminButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup adminPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiCalc;
        private DevExpress.XtraBars.BarButtonItem bbiSettings;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiScheduleRep;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label labelEvents;
        private DevExpress.XtraGrid.GridControl gvLastEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView lastEventsView;
        private DevExpress.XtraGrid.Columns.GridColumn gcTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvent;
        private DevExpress.XtraGrid.Columns.GridColumn gcEntity;
        private DevExpress.XtraGrid.Columns.GridColumn gcPredicate;
        private DevExpress.XtraGrid.Columns.GridColumn gcRealValue;
        private DevExpress.XtraGrid.Columns.GridColumn gcCritValue;

    }
}
