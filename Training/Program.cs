namespace Training
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using TraningDAL.InterfaceBasics;

    static class Program
    {
        /// <summary>
        /// MySql server folder
        /// </summary>
        public static string MySqlFolder { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.MySqlFolder = GetMySqlPath();
            Program.MySql(); // Run MySql server
            Application.Run(new Training());
            Program.MySql(true); // Run MySql server
        }

        /// <summary>
        /// Start MySql Server
        /// </summary>
        private static void MySql(bool runStop = false)
        {
            var path = GetMySqlPath();
            if (string.IsNullOrWhiteSpace(path))
                return;
            var process = new Process();
            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Setup executable and parameters
            process.StartInfo.FileName = string.Concat(path, "\\MySql\\bin\\", (runStop ? "mysqladmin.exe" : "mysqld.exe"));

            if (runStop)
                process.StartInfo.Arguments = string.Concat("--user=root --port=", Properties.Settings.Default.port.ToString(), " shutdown");
            else
                process.StartInfo.Arguments = string.Concat("--port=", Properties.Settings.Default.port.ToString(), "");

            process.Start();
            System.Threading.Thread.Sleep(runStop ? 1500 : 500);
        }

        /// <summary>
        /// Get full path to MySql folder
        /// </summary>
        /// <param name="path">Some path to MySql folder</param>
        /// <returns>Path to MySql folder</returns>
        private static string GetMySqlPath(string path = "")
        {
            var foldersFound = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory, "DB", SearchOption.AllDirectories);
            if (foldersFound == null || foldersFound.Length == 0)
                foldersFound = Directory.GetDirectories(Path.GetFullPath(@"..\..\..\"), "DB", SearchOption.AllDirectories);
            return foldersFound != null && foldersFound.Length > 0 ? foldersFound[0] : "";
        }

        public static DataTable GetData(string command)
        {
            return MySqlConnectorBase.GetData(Properties.Settings.Default.server, Properties.Settings.Default.port, Properties.Settings.Default.user, Properties.Settings.Default.password, command);
        }
        public static bool Command(string command)
        {
            return MySqlConnectorBase.Command(Properties.Settings.Default.server, Properties.Settings.Default.port, Properties.Settings.Default.user, Properties.Settings.Default.password, command);
        }

    }
}
