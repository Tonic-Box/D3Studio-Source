using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3Studio
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
            try
            {
                string str = "bin";
                Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + str);
                AppDomain.CurrentDomain.AppendPrivatePath("bin");
                Application.Run(new MainFrame());
            }
            catch
            {
                try
                {
                    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                    Application.Run(new MainFrame());
                }
                catch
                {
                    MessageBox.Show("Fatal Error: Missing libraries");
                    return;
                }
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var probingPath = Application.StartupPath + "\\bin\\";
            var assyName = new AssemblyName(args.Name);
            var newPath = Path.Combine(probingPath, assyName.Name);
            if (!newPath.EndsWith(".dll"))
            {
                newPath = newPath + ".dll";
            }
            if (File.Exists(newPath))
            {
                return Assembly.LoadFile(newPath);
            }
            return null;
        }
    }
}
