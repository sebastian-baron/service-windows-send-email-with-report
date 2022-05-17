using System;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace ReportService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                var parameter = string.Concat(args);
                switch (parameter)
                {
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new[]
                        {Assembly.GetExecutingAssembly().Location });
                        break;

                    case "--uninstall":
                        ManagedInstallerClass.InstallHelper(new[]
                        {"/u", Assembly.GetExecutingAssembly().Location });
                        break;
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ReportService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}