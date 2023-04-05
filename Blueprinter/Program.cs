using Blueprinter.Core.Services;
using Blueprinter.Presentation;

namespace Blueprinter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var context = new XmlContext(Application.StartupPath);
            var appController = new ApplicationController(context);
            var view = new ViewMain();
            var presenter = new ViewMainPresenter(view, appController);

            Application.Run(view);
        }
    }
}