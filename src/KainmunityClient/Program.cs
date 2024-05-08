using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KainmunityClient.Forms;
using KainmunityClient.ServerAPI;


namespace KainmunityClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            APIConnector.ApiUrl = $"http://{(args.Length > 0 ? args[0] : "localhost")}:5000/api/";
            MessageBox.Show(APIConnector.ApiUrl);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
