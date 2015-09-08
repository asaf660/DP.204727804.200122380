// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace WindowsFormsApplication1
{
    // $G$ THE-001 (-24) your grade on diagrams document - 69. please see comments inside the document. (40% of your grade).
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
