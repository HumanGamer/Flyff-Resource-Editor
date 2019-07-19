using System;
using System.Windows.Forms;

namespace ResEditor
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ResEditor form = new ResEditor();

			if (args.Length > 0)
				form.Open(args[0]);

			Application.Run(form);
		}
	}
}
