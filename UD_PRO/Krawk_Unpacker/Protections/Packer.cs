using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Attribute_KILLER__WINDOWS_FORMS_APP_;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.MD;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000012 RID: 18
	internal class Packer
	{
		// Token: 0x0600004B RID: 75 RVA: 0x00005F40 File Offset: 0x00004140
		public static bool IsPacked(ModuleDefMD module)
		{
			for (uint rid = 1U; rid <= module.MetaData.TablesStream.FileTable.Rows; rid += 1U)
			{
				RawFileRow row = module.TablesStream.ReadFileRow(rid);
				string name = module.StringsStream.ReadNoNull(row.Name);
				bool flag = name != "koi";
				if (!flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00005FBC File Offset: 0x000041BC
		private static void arrayFinder(Local loc)
		{
			MethodDef entryPoint = Form1.module.EntryPoint;
			for (int i = 0; i < entryPoint.Body.Instructions.Count; i++)
			{
				bool flag = entryPoint.Body.Instructions[i].IsStloc();
				if (flag)
				{
					bool flag2 = entryPoint.Body.Instructions[i].GetLocal(entryPoint.Body.Variables) == loc;
					if (flag2)
					{
						bool flag3 = entryPoint.Body.Instructions[i - 1].OpCode == OpCodes.Call && entryPoint.Body.Instructions[i - 2].OpCode == OpCodes.Ldtoken;
						if (flag3)
						{
							FieldDef tester = entryPoint.Body.Instructions[i - 2].Operand as FieldDef;
							Packer.initialValue = tester.InitialValue;
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000060BC File Offset: 0x000042BC
		public static void findLocal()
		{
			Module manifestModule = Form1.asm.ManifestModule;
			MethodDef entryPoint = Form1.module.EntryPoint;
			TypeRef aaa = Form1.module.CorLibTypes.GetTypeRef("System.Runtime.InteropServices", "GCHandle");
			Local[] tester = (from i in Form1.module.EntryPoint.Body.Variables
			where i.Type.Namespace == "System.Runtime.InteropServices" && i.Type.TypeName == "GCHandle"
			select i).ToArray<Local>();
			bool flag = tester.Length != 0;
			if (flag)
			{
				Local loc = tester[0];
				for (int j = 0; j < entryPoint.Body.Instructions.Count; j++)
				{
					bool flag2 = entryPoint.Body.Instructions[j].IsStloc();
					if (flag2)
					{
						bool flag3 = entryPoint.Body.Instructions[j].GetLocal(entryPoint.Body.Variables) == loc;
						if (flag3)
						{
							bool flag4 = entryPoint.Body.Instructions[j - 1].OpCode == OpCodes.Call;
							if (flag4)
							{
								bool flag5 = entryPoint.Body.Instructions[j - 2].IsLdcI4();
								if (flag5)
								{
									bool flag6 = entryPoint.Body.Instructions[j - 3].IsLdloc();
									if (flag6)
									{
										MethodDef decryptMethod = entryPoint.Body.Instructions[j - 1].Operand as MethodDef;
										MethodBase dec = manifestModule.ResolveMethod(decryptMethod.MDToken.ToInt32());
										object[] param = new object[]
										{
											null,
											(uint)entryPoint.Body.Instructions[j - 2].GetLdcI4Value()
										};
										Local loc2 = entryPoint.Body.Instructions[j - 3].GetLocal(entryPoint.Body.Variables);
										Packer.arrayFinder(loc2);
										uint[] decoded = new uint[Packer.initialValue.Length / 4];
										Buffer.BlockCopy(Packer.initialValue, 0, decoded, 0, Packer.initialValue.Length);
										param[0] = decoded;
										GCHandle aaaaa = (GCHandle)dec.Invoke(null, param);
										Form1.module = ModuleDefMD.Load((byte[])aaaaa.Target);
										byte[] key = manifestModule.ResolveSignature(285212673);
										Packer.epToken = ((int)key[0] | (int)key[1] << 8 | (int)key[2] << 16 | (int)key[3] << 24);
										Form1.module.EntryPoint = (Form1.module.ResolveToken(Packer.epToken) as MethodDef);
										Form1.asm = Assembly.Load((byte[])aaaaa.Target);
										break;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000041 RID: 65
		private static byte[] initialValue;

		// Token: 0x04000042 RID: 66
		public static int epToken;
	}
}
