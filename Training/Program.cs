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
        private const int portMySql = 3309;
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
            //Application.Run(new Form1());
            Program.MySql(true); // Run MySql server
        }

        /// <summary>
        /// Start MySql Server
        /// </summary>
        private static void MySql(bool runStop = false)
        {
            var process = new Process();
            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Setup executable and parameters
            if (runStop)
                process.StartInfo.FileName += string.Concat(GetMySqlPath(), "\\MySql\\bin\\", "mysqladmin.exe");
            else
                process.StartInfo.FileName = string.Concat(GetMySqlPath(), "\\MySql\\bin\\", "mysqld.exe");

            if (runStop)
                process.StartInfo.Arguments += string.Concat("--user=root --port=", portMySql.ToString(), " shutdown");
            else
                process.StartInfo.Arguments = string.Concat("--port=", portMySql.ToString(), "");

            process.Start();
        }

        /// <summary>
        /// Get full path to MySql folder
        /// </summary>
        /// <param name="path">Some path to MySql folder</param>
        /// <returns>Path to MySql folder</returns>
        private static string GetMySqlPath(string path = "")
        {
            var foldersFound = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory, "DataBases", SearchOption.AllDirectories);
            if (foldersFound == null || foldersFound.Length == 0)
                foldersFound = Directory.GetDirectories(Path.GetFullPath(@"..\..\..\"), "DataBases", SearchOption.AllDirectories);
            return foldersFound != null && foldersFound.Length > 0 ? foldersFound[0] : "";
        }
    }
}
