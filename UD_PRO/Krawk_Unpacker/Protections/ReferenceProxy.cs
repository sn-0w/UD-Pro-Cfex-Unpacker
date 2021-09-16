using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000013 RID: 19
	internal class ReferenceProxy
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00006388 File Offset: 0x00004588
		private static void RemoveJunkMethods(ModuleDefMD module)
		{
			int num = 0;
			foreach (TypeDef typeDef in module.GetTypes())
			{
				List<MethodDef> list = new List<MethodDef>();
				foreach (MethodDef item in typeDef.Methods)
				{
					bool flag = ReferenceProxy.junkMethods.Contains(item);
					bool flag2 = flag;
					bool flag4 = flag2;
					if (flag4)
					{
						list.Add(item);
					}
				}
				int num2;
				for (int i = 0; i < list.Count; i = num2 + 1)
				{
					typeDef.Methods.Remove(list[i]);
					num2 = num;
					num = num2 + 1;
					num2 = i;
				}
				list.Clear();
			}
			ReferenceProxy.junkMethods.Clear();
			bool flag3 = num > 0;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000064A0 File Offset: 0x000046A0
		public static int ProxyFixer(ModuleDefMD module)
		{
			int num = 0;
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag10 = !flag;
					if (flag10)
					{
						for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
						{
							bool flag2 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call;
							bool flag11 = flag2;
							if (flag11)
							{
								try
								{
									MethodDef methodDef2 = methodDef.Body.Instructions[i].Operand as MethodDef;
									bool flag3 = methodDef2 == null;
									bool flag4 = !flag3;
									bool flag12 = flag4;
									if (flag12)
									{
										bool flag5 = !methodDef2.IsStatic || !typeDef.Methods.Contains(methodDef2);
										bool flag6 = !flag5;
										bool flag13 = flag6;
										if (flag13)
										{
											OpCode opCode;
											object proxyValues = ReferenceProxy.GetProxyValues(methodDef2, out opCode);
											bool flag7 = opCode == null || proxyValues == null;
											bool flag8 = !flag7;
											bool flag14 = flag8;
											if (flag14)
											{
												methodDef.Body.Instructions[i].OpCode = opCode;
												methodDef.Body.Instructions[i].Operand = proxyValues;
												num++;
												bool flag9 = !ReferenceProxy.junkMethods.Contains(methodDef2);
												bool flag15 = flag9;
												if (flag15)
												{
													ReferenceProxy.junkMethods.Add(methodDef2);
												}
											}
										}
									}
								}
								catch
								{
								}
							}
						}
					}
				}
			}
			ReferenceProxy.RemoveJunkMethods(module);
			return num;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000066E8 File Offset: 0x000048E8
		private static object GetProxyValues(MethodDef method, out OpCode opCode)
		{
			ReferenceProxy.result = null;
			opCode = null;
			int i = 0;
			while (i < method.Body.Instructions.Count)
			{
				bool flag = method.Body.Instructions.Count <= 10;
				bool flag5 = flag;
				object obj;
				if (flag5)
				{
					bool flag2 = method.Body.Instructions[i].OpCode == OpCodes.Call;
					bool flag6 = flag2;
					if (flag6)
					{
						opCode = OpCodes.Call;
						ReferenceProxy.result = method.Body.Instructions[i].Operand;
						obj = ReferenceProxy.result;
					}
					else
					{
						bool flag3 = method.Body.Instructions[i].OpCode == OpCodes.Newobj;
						bool flag7 = flag3;
						if (flag7)
						{
							opCode = OpCodes.Newobj;
							ReferenceProxy.result = method.Body.Instructions[i].Operand;
							obj = ReferenceProxy.result;
						}
						else
						{
							bool flag4 = method.Body.Instructions[i].OpCode == OpCodes.Callvirt;
							bool flag8 = !flag4;
							if (flag8)
							{
								opCode = null;
								ReferenceProxy.result = null;
								i++;
								continue;
							}
							opCode = OpCodes.Callvirt;
							ReferenceProxy.result = method.Body.Instructions[i].Operand;
							obj = ReferenceProxy.result;
						}
					}
				}
				else
				{
					obj = null;
				}
				return obj;
			}
			return ReferenceProxy.result;
		}

		// Token: 0x04000043 RID: 67
		private static List<MethodDef> junkMethods = new List<MethodDef>();

		// Token: 0x04000044 RID: 68
		private static object result;
	}
}
