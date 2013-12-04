using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace iTrisDocAccess
{
    [RunInstaller(true)]
    public partial class SeviceInstaller : Installer
    {
        public SeviceInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
        } 
    }
}
