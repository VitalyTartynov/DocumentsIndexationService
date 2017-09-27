using System.ServiceProcess;

namespace WindowsServiceTemplate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Replace TemplateService to your implementation
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[] { new TemplateService() };
            ServiceBase.Run(servicesToRun);
        }
    }
}
