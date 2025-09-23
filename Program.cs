using ClinicaIPS_U.Infrastructure.Configuration;
using ClinicaIPS_U.UI;
using System;
using System.Windows.Forms;

namespace ClinicaIPS_U
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

            var services = new AppServiceProvider();
            Application.Run(new LoginForm(services));
        }
    }
}
