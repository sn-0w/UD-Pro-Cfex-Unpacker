using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using dnlib.IO;
using Krawk_Unpacker.Protections;

namespace Attribute_KILLER__WINDOWS_FORMS_APP_
{
	// Token: 0x0200001A RID: 26
	public partial class Form1 : Form
	{
		// Token: 0x0600007F RID: 127 RVA: 0x00008F2B File Offset: 0x0000712B
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00008F4E File Offset: 0x0000714E
		private void Form1_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00008F54 File Offset: 0x00007154
		private void TextBox1_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
				bool flag = array != null;
				bool flag6 = flag;
				if (flag6)
				{
					string text = array.GetValue(0).ToString();
					int num = text.LastIndexOf(".");
					bool flag2 = num != -1;
					bool flag7 = flag2;
					if (flag7)
					{
						string text2 = text.Substring(num);
						text2 = text2.ToLower();
						bool flag3 = text2 == ".exe" || text2 == ".dll";
						bool flag8 = flag3;
						if (flag8)
						{
							base.Activate();
							this.textBox1.Text = text;
							int num2 = text.LastIndexOf("\\");
							bool flag4 = num2 != -1;
							bool flag9 = flag4;
							if (flag9)
							{
								this.DirectoryName = text.Remove(num2, text.Length - num2);
							}
							bool flag5 = this.DirectoryName.Length == 2;
							bool flag10 = flag5;
							if (flag10)
							{
								this.DirectoryName += "\\";
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00008F4E File Offset: 0x0000714E
		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00009098 File Offset: 0x00007298
		private void TextBox1_DragEnter(object sender, DragEventArgs e)
		{
			bool dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
			bool flag = dataPresent;
			if (flag)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000090D4 File Offset: 0x000072D4
		private void AppendText(RichTextBox box, Color color, string text)
		{
			int textLength = box.TextLength;
			box.AppendText(text);
			int textLength2 = box.TextLength;
			box.Select(textLength, textLength2 - textLength);
			box.SelectionColor = color;
			box.SelectionLength = 0;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00009114 File Offset: 0x00007314
		public void Delayed(int delay, Action action)
		{
			Timer timer = new Timer();
			timer.Interval = delay;
			timer.Tick += delegate(object s, EventArgs e)
			{
				action();
				timer.Stop();
			};
			timer.Start();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000916C File Offset: 0x0000736C
		private void Button1_Click(object sender, EventArgs e)
		{
			string text = this.textBox1.Text;
			bool flag = File.Exists(text);
			bool flag6 = flag;
			if (flag6)
			{
				string diretorio = this.textBox1.Text;
				try
				{
					Form1.module = ModuleDefMD.Load(diretorio);
					Form1.asm = Assembly.LoadFrom(diretorio);
					Form1.Asmpath = diretorio;
				}
				catch (Exception)
				{
					Console.WriteLine("Not .NET Assembly...");
				}
				this.AppendText(this.richTextBox1, Color.Black, "Successfully loaded: " + AssemblyName.GetAssemblyName(this.textBox1.Text) + " Starting Unpacker...\n");
				bool @checked = this.checkBox1.Checked;
				bool flag7 = @checked;
				if (flag7)
				{
					try
					{
						Console.ForegroundColor = ConsoleColor.White;
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Removing Attributes\n");
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Removed Attributes: " + AttributeRemover.start(Form1.module) + "\n");
					}
					catch
					{
					}
				}
				bool checked2 = this.checkBox2.Checked;
				bool flag8 = checked2;
				if (flag8)
				{
					try
					{
						this.antitamper();
					}
					catch
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Failed to remove Anti-Tamper\n");
					}
				}
				bool checked3 = this.checkBox3.Checked;
				bool flag9 = checked3;
				if (flag9)
				{
					try
					{
						this.Staticpacker();
					}
					catch
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Failed to remove packer\n");
					}
				}
				bool checked4 = this.checkBox4.Checked;
				bool flag10 = checked4;
				if (flag10)
				{
					try
					{
						this.packer();
					}
					catch
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Failed to remove packer\n");
					}
				}
				bool checked5 = this.checkBox5.Checked;
				bool flag11 = checked5;
				if (flag11)
				{
					try
					{
						Console.ForegroundColor = ConsoleColor.White;
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Removing AntiDebugger\n");
						antidebugger.Run(Form1.module);
						this.AppendText(this.richTextBox1, Color.Blue, "[!] AntiDebbuger Call Removed from Module\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error removing AntiDebugger\n");
					}
				}
				bool checked6 = this.checkBox6.Checked;
				bool flag12 = checked6;
				if (flag12)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Cleaning Up Control-Flow Cases\n");
						ControlFlowRun.cleaner(Form1.module);
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Success in Cleaning Control-Flow Cases\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error Cleaning Control-Flow Cases\n");
					}
				}
				bool checked7 = this.checkBox7.Checked;
				bool flag13 = checked7;
				if (flag13)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Fixing Proxy-Calls\n");
						int num = ReferenceProxy.ProxyFixer(Form1.module);
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Proxy calls fixed: " + num + "\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error fixing Proxy-Calls\n");
					}
				}
				bool checked8 = this.checkBox8.Checked;
				bool flag14 = checked8;
				if (flag14)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Resolving math equations\n");
						MathsEquations.MathsFixer(Form1.module);
						this.AppendText(this.richTextBox1, Color.Blue, "[!] math equations resolved: " + Form1.MathsAmount + "\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error resolving math equations\n");
					}
				}
				bool checked9 = this.checkBox9.Checked;
				bool flag15 = checked9;
				if (flag15)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Removing SizeOf's\n");
						MathsEquations.SizeofRemove(Form1.module);
						this.AppendText(this.richTextBox1, Color.Blue, "[!] SizeOf's Removed: " + Form1.MathsAmount + "\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error removing SizeOf's\n");
					}
				}
				bool checked10 = this.checkBox14.Checked;
				bool flag16 = checked10;
				if (flag16)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Resolving invokes\n");
						MathsEquations.SizeofRemove(Form1.module);
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Invokes Resolved Successfully !\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error removing invokes !\n");
					}
				}
				bool checked11 = this.checkBox10.Checked;
				bool flag17 = checked11;
				if (flag17)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Removing Static Strings\n");
						int num2 = StaticStrings.Run(Form1.module);
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Static Strings Removed: " + num2 + "\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error removing static strings\n");
					}
				}
				bool checked12 = this.checkBox11.Checked;
				bool flag18 = checked12;
				if (flag18)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Removing dynamic strings\n");
						int num3 = Constants.constants();
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Strings Removed: " + num3 + "\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error removing dynamic strings\n");
					}
				}
				bool checked13 = this.checkBox13.Checked;
				bool flag19 = checked13;
				if (flag19)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Removing AntiDumper\n");
						antidumper.Run(Form1.module);
						this.AppendText(this.richTextBox1, Color.Blue, "[!] AntiDumper call removed from module\n");
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error removing antidumper\n");
					}
				}
				bool checked14 = this.checkBox12.Checked;
				bool flag20 = checked14;
				if (flag20)
				{
					try
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Decrypting Resources...\n");
						ResourcesDeobfuscator.Deobfuscate(Form1.module);
					}
					catch (Exception)
					{
						this.AppendText(this.richTextBox1, Color.Blue, "[!] Error decrypting resources\n");
					}
				}
			}
			string text2 = Path.GetDirectoryName(text);
			bool flag2 = !text2.EndsWith("\\");
			bool flag3 = flag2;
			bool flag4 = flag3;
			bool flag21 = flag4;
			if (flag21)
			{
				text2 += "\\";
			}
			string text3 = string.Format("{0}{1}_Unpacked{2}", text2, Path.GetFileNameWithoutExtension(text), Path.GetExtension(text));
			ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(Form1.module);
			moduleWriterOptions.MetaDataOptions.Flags |= MetaDataFlags.PreserveAll;
			moduleWriterOptions.Logger = DummyLogger.NoThrowInstance;
			NativeModuleWriterOptions nativeModuleWriterOptions = new NativeModuleWriterOptions(Form1.module);
			nativeModuleWriterOptions.MetaDataOptions.Flags |= MetaDataFlags.PreserveAll;
			nativeModuleWriterOptions.Logger = DummyLogger.NoThrowInstance;
			bool isILOnly = Form1.module.IsILOnly;
			bool flag5 = isILOnly;
			bool flag22 = flag5;
			if (flag22)
			{
				Form1.module.Write(text3, moduleWriterOptions);
			}
			else
			{
				Form1.module.NativeWrite(text3, nativeModuleWriterOptions);
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00009980 File Offset: 0x00007B80
		private void Staticpacker()
		{
			bool flag = Packer.IsPacked(Form1.module);
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				this.AppendText(this.richTextBox1, Color.Blue, "[!] Static Compressor Detected");
				try
				{
					StaticPacker.Run(Form1.module);
					this.AppendText(this.richTextBox1, Color.Blue, "[!] Compressor removed");
				}
				catch
				{
					this.AppendText(this.richTextBox1, Color.Blue, "[!] Error in removing Compressor");
				}
				this.antitamper();
				Form1.module.EntryPoint = (Form1.module.ResolveToken(StaticPacker.epToken) as MethodDef);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00009A34 File Offset: 0x00007C34
		private void antitamper()
		{
			bool? flag = AntiTamper.IsTampered(Form1.module);
			bool flag2 = true;
			bool flag3 = flag.GetValueOrDefault() == flag2 & flag != null;
			bool flag4 = flag3;
			bool flag5 = flag4;
			if (flag5)
			{
				this.AppendText(this.richTextBox1, Color.Blue, "[!] Anti-Tamper Detected\n");
				IImageStream imageStream = Form1.module.MetaData.PEImage.CreateFullStream();
				byte[] rawbytes = imageStream.ReadBytes((int)imageStream.Length);
				try
				{
					Form1.module = AntiTamper.UnAntiTamper(Form1.module, rawbytes);
					this.AppendText(this.richTextBox1, Color.Blue, "[!] Anti-Tamper Removed successfully!\n");
				}
				catch
				{
					this.AppendText(this.richTextBox1, Color.Blue, "[!] Failed to remove Anti-Tamper\n");
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00009B08 File Offset: 0x00007D08
		private void packer()
		{
			bool flag = Packer.IsPacked(Form1.module);
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				this.AppendText(this.richTextBox1, Color.Blue, "[!] Compressor Dynamico Detectado\n");
				try
				{
					Packer.findLocal();
					this.AppendText(this.richTextBox1, Color.Blue, "[!] Compressor Removido\n");
				}
				catch
				{
					this.AppendText(this.richTextBox1, Color.Blue, "[!] Compressor Erro ao Remover\n");
				}
				this.antitamper();
				Form1.module.EntryPoint = (Form1.module.ResolveToken(StaticPacker.epToken) as MethodDef);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00009BB4 File Offset: 0x00007DB4
		private void CheckBox15_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox15.Checked;
			bool flag3 = @checked;
			if (flag3)
			{
				foreach (object obj in base.Controls)
				{
					Control control = (Control)obj;
					bool flag = control is CheckBox;
					bool flag4 = flag;
					if (flag4)
					{
						CheckBox checkBox = (CheckBox)control;
						bool flag2 = !checkBox.Checked;
						bool flag5 = flag2;
						if (flag5)
						{
							checkBox.Checked = true;
						}
						else
						{
							checkBox.Checked = false;
						}
					}
				}
			}
		}

		// Token: 0x04000054 RID: 84
		public static bool veryVerbose = false;

		// Token: 0x04000055 RID: 85
		public static string Asmpath;

		// Token: 0x04000056 RID: 86
		public static ModuleDefMD module;

		// Token: 0x04000057 RID: 87
		public static Assembly asm;

		// Token: 0x04000058 RID: 88
		private Assembly assembly;

		// Token: 0x04000059 RID: 89
		private static string path = null;

		// Token: 0x0400005A RID: 90
		public string DirectoryName = "";

		// Token: 0x0400005B RID: 91
		public static int MathsAmount;
	}
}
