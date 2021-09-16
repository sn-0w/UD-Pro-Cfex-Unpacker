using System;
using System.Windows.Forms;

namespace Attribute_KILLER__WINDOWS_FORMS_APP_
{
	// Token: 0x0200001B RID: 27
	internal static class Program
	{
		// Token: 0x0600008E RID: 142 RVA: 0x0000AA29 File Offset: 0x00008C29
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
