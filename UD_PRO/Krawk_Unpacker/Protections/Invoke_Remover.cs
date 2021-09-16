using System;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x0200000F RID: 15
	internal class Invoke_Remover
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00004E94 File Offset: 0x00003094
		public static void run(ModuleDefMD module)
		{
			int num = 0;
			foreach (TypeDef typeDef in module.GetTypes())
			{
				bool flag = !typeDef.IsGlobalModuleType;
				bool flag4 = !flag;
				if (flag4)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag2 = !methodDef.HasBody && !methodDef.Body.HasInstructions;
						bool flag5 = !flag2;
						if (flag5)
						{
							for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
							{
								bool flag3 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call && methodDef.Body.Instructions[i].Operand.ToString().Contains("CallingAssembly");
								bool flag6 = flag3;
								if (flag6)
								{
									methodDef.Body.Instructions[i].Operand = (methodDef.Body.Instructions[i].Operand = module.Import(typeof(Assembly).GetMethod("GetExecutingAssembly")));
									num++;
								}
							}
						}
					}
				}
			}
		}
	}
}
