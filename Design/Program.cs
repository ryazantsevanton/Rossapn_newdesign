using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Linq;

namespace Design
{
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

            var dllDir = new DirectoryInfo(Environment.CurrentDirectory);
            DataHelper.CustomFormulas = new List<CalcFormula>();
            foreach (var file in dllDir.GetFiles("*.dll", SearchOption.AllDirectories))
            {
                var assembly = Assembly.LoadFile(file.FullName);
                DataHelper.CustomFormulas.AddRange(assembly.GetTypes().
                                        Where(t => t.GetInterface(typeof(CalcFormula).FullName, true) != null).
                                        Select(t => (CalcFormula)Activator.CreateInstance(t)));
            }
            using (var con = DataHelper.OpenOrCreateDb()) {
                foreach (var d in DataHelper.CustomFormulas)
                {
                    foreach(var p in  d.InitPredicates())  DataHelper.GetParameter(p, con, true);
                    DataHelper.GetParameter(d.Name, con, true);
                }
            }

            Application.Run(new Form1());
        }
    }
}