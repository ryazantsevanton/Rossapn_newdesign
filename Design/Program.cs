using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace Design
{
    [Serializable]
    public class DBSettings
    {
        public DBConnectionString TargetDBConnectionString { get; set; }
        public DBConnectionString[] SourceDBConnections { get; set; }
    }

    [Serializable]
    public class DBConnectionString
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Application.Run(new Form1());
        }
    }
}