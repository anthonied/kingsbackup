using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using log4net.Config;
using Liquid.Forms;

namespace Liquid
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            XmlConfigurator.ConfigureAndWatch(new FileInfo("C:\\LogConfigs\\liquid.config"));
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		    Application.Run(new frmCompanyList());
		}

	    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	    {
            var exception = (Exception) e.ExceptionObject;
	    }
	}
}	