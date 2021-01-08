using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeControl
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogIn login = new LogIn("");
            login.FormClosed += LogIn_Closed;
            login.Show();
            Application.Run();
        }
        private static void LogIn_Closed(object sender, FormClosedEventArgs e)        {
            ((Form)sender).FormClosed -= LogIn_Closed;
            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += LogIn_Closed;
            }
        }
    }
}
