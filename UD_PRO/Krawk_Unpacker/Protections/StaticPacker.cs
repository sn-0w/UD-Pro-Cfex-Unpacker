using System;
using System.Linq;
using Attribute_KILLER__WINDOWS_FORMS_APP_;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000015 RID: 21
	internal class StaticPacker
	{
		// Token: 0x06000059 RID: 89 RVA: 0x00006E48 File Offset: 0x00005048
		public static bool Run(ModuleDefMD module)
		{
			MethodDef GetFirstMetohd = module.EntryPoint;
			uint[] val2 = StaticPacker.arrayFinder();
			bool flag = val2 == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint val3 = StaticPacker.findLocal();
				bool flag2 = val3 == 0U;
				if (flag2)
				{
					result = false;
				}
				else
				{
					byte[] val4 = StaticPacker.Decrypt(StaticPacker.decryptMethod, val2, val3);
					bool flag3 = val4 == null;
					if (flag3)
					{
						result = false;
					}
					else
					{
						int value = StaticPacker.epStuff(module.EntryPoint);
						bool flag4 = value == 0;
						if (flag4)
						{
							result = false;
						}
						else
						{
							byte[] epstuff = module.ReadBlob((uint)value);
							bool flag5 = epstuff == null;
							if (flag5)
							{
								result = false;
							}
							else
							{
								StaticPacker.epToken = ((int)epstuff[0] | (int)epstuff[1] << 8 | (int)epstuff[2] << 16 | (int)epstuff[3] << 24);
								Form1.module = ModuleDefMD.Load(val4);
								Form1.module.EntryPoint = (Form1.module.ResolveToken(StaticPacker.epToken) as MethodDef);
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006F38 File Offset: 0x00005138
		public static void PopolateArrays(ulong key, out ulong conv)
		{
			StaticPacker.dst = new uint[16];
			StaticPacker.src = new uint[16];
			ulong decryptionKey = key;
			for (int i = 0; i < 16; i++)
			{
				decryptionKey = decryptionKey * decryptionKey % 339722377UL;
				StaticPacker.src[i] = (uint)decryptionKey;
				StaticPacker.dst[i] = (uint)(decryptionKey * decryptionKey % 1145919227UL);
			}
			conv = decryptionKey;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006F9C File Offset: 0x0000519C
		public static int epStuff(MethodDef method)
		{
			for (int i = 38; i < method.Body.Instructions.Count; i++)
			{
				bool flag = method.Body.Instructions[i].IsLdcI4();
				if (flag)
				{
					bool flag2 = method.Body.Instructions[i + 1].OpCode == OpCodes.Callvirt && method.Body.Instructions[i + 1].Operand.ToString().Contains("ResolveSignature");
					if (flag2)
					{
						return method.Body.Instructions[i].GetLdcI4Value();
					}
				}
			}
			return 0;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000705C File Offset: 0x0000525C
		private static byte[] Decrypt(MethodDef meth, uint[] array, uint num)
		{
			ulong conv;
			StaticPacker.PopolateArrays((ulong)num, out conv);
			uint[] uii = StaticPacker.DeriveKey(meth, StaticPacker.dst, StaticPacker.src);
			byte[] fgfff = StaticPacker.decryptDataArray(array);
			byte[] arr = Lzma.Decompress(fgfff);
			return StaticPacker.decryptDecompData(arr, conv);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000070A0 File Offset: 0x000052A0
		public static byte[] decryptDecompData(byte[] arr, ulong conv)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] ^= (byte)conv;
				bool flag = (i & 255) == 0;
				if (flag)
				{
					conv = conv * conv % 9067703UL;
				}
			}
			return arr;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000070F4 File Offset: 0x000052F4
		public static byte[] decryptDataArray(uint[] DataField)
		{
			byte[] buffer = new byte[DataField.Length << 2];
			uint index = 0U;
			for (int i = 0; i < DataField.Length; i++)
			{
				uint decryption_key = DataField[i] ^ StaticPacker.dst[i & 15];
				StaticPacker.dst[i & 15] = (StaticPacker.dst[i & 15] ^ decryption_key) + 1037772825U;
				buffer[(int)index] = (byte)decryption_key;
				buffer[(int)(index + 1U)] = (byte)(decryption_key >> 8);
				buffer[(int)(index + 2U)] = (byte)(decryption_key >> 16);
				buffer[(int)(index + 3U)] = (byte)(decryption_key >> 24);
				index += 4U;
			}
			return buffer;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00007180 File Offset: 0x00005380
		private static uint[] DeriveKey(MethodDef DecryptMethod, uint[] dst, uint[] src)
		{
			Instruction[] bodyInstr = DecryptMethod.Body.Instructions.ToArray<Instruction>();
			bool flag = bodyInstr[48].IsLdcI4();
			int valCheck;
			if (flag)
			{
				valCheck = 48;
			}
			else
			{
				valCheck = 50;
			}
			int num = 0;
			for (int i = valCheck; i < 240; i += 12)
			{
				uint operand2 = (uint)((int)bodyInstr[i].Operand);
				bool flag2 = bodyInstr[i - 1].OpCode.Equals(OpCodes.Add);
				if (flag2)
				{
					dst[num] += src[num];
				}
				bool flag3 = bodyInstr[i - 1].OpCode.Equals(OpCodes.Mul);
				if (flag3)
				{
					dst[num] *= src[num];
				}
				bool flag4 = bodyInstr[i - 1].OpCode.Equals(OpCodes.Xor);
				if (flag4)
				{
					dst[num] ^= src[num];
				}
				bool flag5 = bodyInstr[i + 1].OpCode.Equals(OpCodes.Add);
				if (flag5)
				{
					dst[num] += operand2;
				}
				bool flag6 = bodyInstr[i + 1].OpCode.Equals(OpCodes.Mul);
				if (flag6)
				{
					dst[num] *= operand2;
				}
				bool flag7 = bodyInstr[i + 1].OpCode.Equals(OpCodes.Xor);
				if (flag7)
				{
					dst[num] ^= operand2;
				}
				num++;
			}
			return dst;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000072F8 File Offset: 0x000054F8
		public static uint findLocal()
		{
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
										StaticPacker.decryptMethod = (entryPoint.Body.Instructions[j - 1].Operand as MethodDef);
										return (uint)entryPoint.Body.Instructions[j - 2].GetLdcI4Value();
									}
								}
							}
						}
					}
				}
			}
			return 0U;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000074B0 File Offset: 0x000056B0
		private static uint[] arrayFinder()
		{
			MethodDef entryPoint = Form1.module.EntryPoint;
			for (int i = 0; i < entryPoint.Body.Instructions.Count; i++)
			{
				bool flag = entryPoint.Body.Instructions[i].OpCode == OpCodes.Stloc_0;
				if (flag)
				{
					bool flag2 = entryPoint.Body.Instructions[i - 1].OpCode == OpCodes.Call && entryPoint.Body.Instructions[i - 2].OpCode == OpCodes.Ldtoken;
					if (flag2)
					{
						FieldDef tester = entryPoint.Body.Instructions[i - 2].Operand as FieldDef;
						byte[] aa = tester.InitialValue;
						uint[] decoded = new uint[aa.Length / 4];
						Buffer.BlockCopy(aa, 0, decoded, 0, aa.Length);
						return decoded;
					}
				}
			}
			return null;
		}

		// Token: 0x04000047 RID: 71
		private static byte[] initialValue;

		// Token: 0x04000048 RID: 72
		private static uint[] dst;

		// Token: 0x04000049 RID: 73
		private static uint[] src;

		// Token: 0x0400004A RID: 74
		private static MethodDef decryptMethod;

		// Token: 0x0400004B RID: 75
		public static int epToken;
	}
}
