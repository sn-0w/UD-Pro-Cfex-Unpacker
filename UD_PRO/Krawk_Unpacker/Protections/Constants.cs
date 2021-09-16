using System;
using System.Reflection;
using Attribute_KILLER__WINDOWS_FORMS_APP_;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x0200000C RID: 12
	internal class Constants
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00003D10 File Offset: 0x00001F10
		public static int constants()
		{
			int num = 0;
			Module manifestModule = Form1.asm.ManifestModule;
			foreach (TypeDef typeDef in Form1.module.GetTypes())
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag4 = !flag;
					if (flag4)
					{
						for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
						{
							bool flag2 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call && methodDef.Body.Instructions[i].Operand.ToString().Contains("tring>") && methodDef.Body.Instructions[i].Operand is MethodSpec;
							bool flag5 = flag2;
							if (flag5)
							{
								bool flag3 = methodDef.Body.Instructions[i - 1].IsLdcI4();
								bool flag6 = flag3;
								if (flag6)
								{
									MethodSpec methodSpec = methodDef.Body.Instructions[i].Operand as MethodSpec;
									uint ldcI4Value = (uint)methodDef.Body.Instructions[i - 1].GetLdcI4Value();
									string text = (string)manifestModule.ResolveMethod(methodSpec.MDToken.ToInt32()).Invoke(null, new object[]
									{
										ldcI4Value
									});
									methodDef.Body.Instructions[i].OpCode = OpCodes.Nop;
									methodDef.Body.Instructions[i - 1].OpCode = OpCodes.Ldstr;
									methodDef.Body.Instructions[i - 1].Operand = text;
									num++;
									bool veryVerbose = Form1.veryVerbose;
									bool flag7 = veryVerbose;
									if (flag7)
									{
										Console.ForegroundColor = ConsoleColor.Cyan;
										Console.WriteLine(string.Format("Encrypted String Found In Method {0} With Param of {1} the decrypted string is {2}", methodDef.Name, ldcI4Value.ToString(), text));
										Console.ForegroundColor = ConsoleColor.Green;
									}
								}
							}
						}
					}
				}
			}
			return num;
		}
	}
}
