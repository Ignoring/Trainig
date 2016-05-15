namespace Training
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// Port for connect to MySql
        /// </summary>
        public static int MySqlPort = 3309;
        /// <summary>
        /// MySql server folder
        /// </summary>
        public static string MySqlFolder {get; set; }
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
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Setup executable and parameters
            process.StartInfo.FileName = string.Concat(path, "\\MySql\\bin\\", (runStop ? "mysqladmin.exe" : "mysqld.exe"));

            if (runStop)
                process.StartInfo.Arguments = string.Concat("--user=root --port=", MySqlPort.ToString(), " shutdown");
            else
                process.StartInfo.Arguments = string.Concat("--port=", MySqlPort.ToString(), "");

            process.Start();
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
    }
}
