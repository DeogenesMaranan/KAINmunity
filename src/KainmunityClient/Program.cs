using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using dotenv.net;
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
            DotEnv.Load();

            APIConnector.ApiUrl = (args.Length > 0 && args[0] == "online")
                ? Environment.GetEnvironmentVariable("SERVER_URL") + "/api/"
                : "http://localhost:5000/api/";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
