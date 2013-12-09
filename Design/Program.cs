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

            //Load Calc Formulas
            DataHelper.CustomFormulas = new List<CalcFormula>();
            loadAssemblies<CalcFormula>(DataHelper.CustomFormulas);
            using (var con = DataHelper.OpenOrCreateDb()) {
                foreach (var d in DataHelper.CustomFormulas)
                {
                    foreach(var p in  d.InitPredicates())  DataHelper.GetParameter(p, con, true);
                    DataHelper.GetParameter(d.Name, con, true);
                }
            }

            //Load Event Checkers
            DataHelper.EventCheckers = new List<EventChecker>();
            loadAssemblies<EventChecker>(DataHelper.EventCheckers);

            Application.Run(new Form1());
        }

        private static void loadAssemblies<T>(List<T> container)
        {
            var dllDir = new DirectoryInfo(Environment.CurrentDirectory);
            
            foreach (var file in dllDir.GetFiles("*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    var assembly = Assembly.LoadFile(file.FullName);
                    container.AddRange(assembly.GetTypes().
                                            Where(t => t.GetInterface(typeof(T).FullName, true) != null).
                                            Select(t => (T)Activator.CreateInstance(t)));
                }
                catch (Exception e)
                {
                    string s = e.Message;
                }
            }
        }
    }
}