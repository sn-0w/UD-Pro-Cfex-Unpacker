using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000008 RID: 8
	internal class AttributeRemover
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00002D80 File Offset: 0x00000F80
		private static IList<TypeDef> lista(ModuleDef A_0)
		{
			return A_0.Types;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002D98 File Offset: 0x00000F98
		public static int start(ModuleDefMD md)
		{
			int num = 0;
			foreach (TypeDef typeDef in md.GetTypes())
			{
				bool flag = typeDef.Name == "ConfusedByAttribute";
				bool flag17 = flag;
				if (flag17)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag2 = typeDef.Name == "ZYXDNGuarder";
				bool flag18 = flag2;
				if (flag18)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag3 = typeDef.Name == "YanoAttribute";
				bool flag19 = flag3;
				if (flag19)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag4 = typeDef.Name == "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode";
				bool flag20 = flag4;
				if (flag20)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag5 = typeDef.Name == "SmartAssembly.Attributes.PoweredByAttribute";
				bool flag21 = flag5;
				if (flag21)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag6 = typeDef.Name == "SecureTeam.Attributes.ObfuscatedByAgileDotNetAttribute";
				bool flag22 = flag6;
				if (flag22)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag7 = typeDef.Name == "ObfuscatedByGoliath";
				bool flag23 = flag7;
				if (flag23)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag8 = typeDef.Name == "NineRays.Obfuscator.Evaluation";
				bool flag24 = flag8;
				if (flag24)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag9 = typeDef.Name == "EMyPID_8234_";
				bool flag25 = flag9;
				if (flag25)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag10 = typeDef.Name == "DotfuscatorAttribute";
				bool flag26 = flag10;
				if (flag26)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag11 = typeDef.Name == "CryptoObfuscator.ProtectedWithCryptoObfuscatorAttribute";
				bool flag27 = flag11;
				if (flag27)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag12 = typeDef.Name == "BabelObfuscatorAttribute";
				bool flag28 = flag12;
				if (flag28)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag13 = typeDef.Name == ".NETGuard";
				bool flag29 = flag13;
				if (flag29)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag14 = typeDef.Name == "OrangeHeapAttribute";
				bool flag30 = flag14;
				if (flag30)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag15 = typeDef.Name == "WTF";
				bool flag31 = flag15;
				if (flag31)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
				bool flag16 = typeDef.Name == "<ObfuscatedByDotNetPatcher>";
				bool flag32 = flag16;
				if (flag32)
				{
					AttributeRemover.lista(md).Remove(typeDef);
					num++;
				}
			}
			return num;
		}
	}
}
