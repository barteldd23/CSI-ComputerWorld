using Microsoft.Extensions.Configuration;

namespace DDB.ComputerWorld.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static IConfiguration Configuration;

        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", 
                             optional: true, 
                             reloadOnChange: true);

            Configuration = builder.Build();


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmComputerWorld());
        }
    }
}