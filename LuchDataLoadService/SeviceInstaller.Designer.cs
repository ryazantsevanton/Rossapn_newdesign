namespace iTrisDocAccess
{
    partial class SeviceInstaller
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

        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            //  
            // serviceProcessInstaller1 
            //  
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            //  
            // serviceInstaller1 
            //  
            this.serviceInstaller1.Description = string.Empty;
            this.serviceInstaller1.DisplayName = "LuchDataLoadService";
            this.serviceInstaller1.ServiceName = "LuchDataLoadService";
            this.serviceInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            //  
            // ServiceInstaller 
            //  
            this.Installers.AddRange(new System.Configuration.Install.Installer[] { 
            this.serviceProcessInstaller1, 
            this.serviceInstaller1});

        } 
        #endregion
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1; 
    }
}