using System;
using System.Windows.Forms;

namespace PdfPageSaver
{
	internal static class Program
	{
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		[STAThread]
		private static void Main(params string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// ReSharper disable once CoVariantArrayConversion
			Application.Run(new MainForm(args));
		}
	}
}
