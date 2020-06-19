using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturi
{
    public class FaraScenariiException : Exception { }

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
            Application.Run(new MeniuPrincipal());// new EditareScenariu(new List<Tranzactie>()));//
        }
        // import facturi csv
        // restrictii monede
        // istoric tranzactii
    }
}
