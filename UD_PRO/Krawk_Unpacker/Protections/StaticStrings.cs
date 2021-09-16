using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Attribute_KILLER__WINDOWS_FORMS_APP_;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000016 RID: 22
	internal class StaticStrings
	{
		// Token: 0x06000063 RID: 99 RVA: 0x000075B0 File Offset: 0x000057B0
		public static int Run(ModuleDefMD module)
		{
			MethodDef correct = StaticStrings.firstStep(module);
			uint shit = StaticStrings.getShit(module, correct);
			bool flag = shit == 0U;
			bool flag5 = flag;
			int result;
			if (flag5)
			{
				result = 0;
			}
			else
			{
				string arrayName = StaticStrings.getArrayName(module, correct);
				bool flag2 = arrayName == null;
				bool flag6 = flag2;
				if (flag6)
				{
					result = 0;
				}
				else
				{
					uint[] array = StaticStrings.getArray(module, arrayName);
					bool flag3 = array == null;
					bool flag7 = flag3;
					if (flag7)
					{
						result = 0;
					}
					else
					{
						uint finalShit = StaticStrings.getFinalShit(module, correct);
						bool flag4 = finalShit == 0U;
						bool flag8 = flag4;
						if (flag8)
						{
							result = 0;
						}
						else
						{
							StaticStrings.smethod_1(shit, array, finalShit);
							StaticStrings.FindString(module);
							result = StaticStrings.StringsDecrypted;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00007664 File Offset: 0x00005864
		public static MethodDef firstStep(ModuleDefMD module)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag11 = !flag;
					if (flag11)
					{
						bool flag2 = !methodDef.IsConstructor;
						bool flag12 = !flag2;
						if (flag12)
						{
							bool flag3 = !methodDef.FullName.ToLower().Contains("module");
							bool flag13 = !flag3;
							if (flag13)
							{
								for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
								{
									bool flag4 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call;
									bool flag14 = flag4;
									if (flag14)
									{
										MethodDef methodDef2 = (MethodDef)methodDef.Body.Instructions[i].Operand;
										bool flag5 = !methodDef2.HasBody;
										bool flag15 = !flag5;
										if (flag15)
										{
											bool flag6 = methodDef2.Body.Instructions.Count < 300;
											bool flag16 = !flag6;
											if (flag16)
											{
												for (int j = 0; j < methodDef2.Body.Instructions.Count; j++)
												{
													bool flag7 = methodDef2.Body.Instructions[j].OpCode == OpCodes.Stloc_0;
													bool flag17 = flag7;
													if (flag17)
													{
														bool flag8 = methodDef2.Body.Instructions[j - 1].IsLdcI4();
														bool flag18 = flag8;
														if (flag18)
														{
															StaticStrings.C.Clear();
															bool flag9 = StaticStrings.dthfs(module, methodDef2);
															bool flag10 = !flag9;
															bool flag19 = !flag10;
															if (flag19)
															{
																return methodDef2;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000078E8 File Offset: 0x00005AE8
		public static bool dthfs(ModuleDefMD module, MethodDef method)
		{
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				bool flag = method.Body.Instructions[i].OpCode == OpCodes.Call;
				bool flag2 = flag;
				if (flag2)
				{
					StaticStrings.C.Add(method.Body.Instructions[i]);
				}
			}
			return StaticStrings.SortList();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00007964 File Offset: 0x00005B64
		public static bool SortList()
		{
			string value = "System.Reflection.Assembly System.Reflection.Assembly::Load(System.Byte[])";
			for (int i = 0; i < StaticStrings.C.Count; i++)
			{
				bool flag = StaticStrings.C[i].Operand.ToString().Contains(value);
				bool flag2 = flag;
				if (flag2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000079C4 File Offset: 0x00005BC4
		public static uint getFinalShit(ModuleDefMD module, MethodDef correct)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag9 = !flag;
					if (flag9)
					{
						bool flag2 = !methodDef.IsConstructor;
						bool flag10 = !flag2;
						if (flag10)
						{
							bool flag3 = !methodDef.FullName.ToLower().Contains("module");
							bool flag11 = !flag3;
							if (flag11)
							{
								for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
								{
									bool flag4 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call;
									bool flag12 = flag4;
									if (flag12)
									{
										MethodDef methodDef2 = (MethodDef)methodDef.Body.Instructions[i].Operand;
										bool flag5 = methodDef2 != correct;
										bool flag13 = !flag5;
										if (flag13)
										{
											for (int j = 0; j < methodDef2.Body.Instructions.Count; j++)
											{
												bool flag6 = methodDef2.Body.Instructions[j].OpCode == OpCodes.Stloc_3;
												bool flag14 = flag6;
												if (flag14)
												{
													bool flag7 = methodDef2.Body.Instructions[j - 1].IsLdcI4();
													bool flag15 = flag7;
													if (flag15)
													{
														bool flag8 = methodDef2.Body.Instructions[j - 1].GetLdcI4Value() == 0;
														bool flag16 = !flag8;
														if (flag16)
														{
															return (uint)methodDef2.Body.Instructions[j - 1].GetLdcI4Value();
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return 0U;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00007C34 File Offset: 0x00005E34
		public static void FindString(ModuleDefMD module)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag6 = !flag;
					if (flag6)
					{
						for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
						{
							bool flag2 = i < 1;
							bool flag7 = !flag2;
							if (flag7)
							{
								bool flag3 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call && methodDef.Body.Instructions[i - 1].IsLdcI4();
								bool flag8 = flag3;
								if (flag8)
								{
									try
									{
										StaticStrings.DecryptionMethod = (MethodSpec)methodDef.Body.Instructions[i].Operand;
										bool flag4 = StaticStrings.DecryptionMethod.FullName.ToLower().Contains("string");
										bool flag9 = flag4;
										if (flag9)
										{
											int ldcI4Value = methodDef.Body.Instructions[i - 1].GetLdcI4Value();
											string paramValues = StaticStrings.GetParamValues(module, StaticStrings.DecryptionMethod, (uint)ldcI4Value);
											bool flag5 = paramValues != null;
											bool flag10 = flag5;
											if (flag10)
											{
												methodDef.Body.Instructions[i].OpCode = OpCodes.Nop;
												methodDef.Body.Instructions[i - 1].OpCode = OpCodes.Ldstr;
												methodDef.Body.Instructions[i - 1].Operand = paramValues;
												bool veryVerbose = Form1.veryVerbose;
												bool flag11 = veryVerbose;
												if (flag11)
												{
													Console.ForegroundColor = ConsoleColor.Cyan;
													Console.WriteLine(string.Format("Encrypted String Found In Method {0} With Param of {1} the decrypted string is {2}", methodDef.Name, ldcI4Value.ToString(), paramValues));
													Console.ForegroundColor = ConsoleColor.Green;
												}
												StaticStrings.StringsDecrypted++;
											}
										}
									}
									catch (Exception ex)
									{
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00007ED0 File Offset: 0x000060D0
		public static string GetParamValues(ModuleDefMD module, MethodSpec decryption, uint param)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag5 = !flag;
					if (flag5)
					{
						bool flag2 = !methodDef.FullName.Contains(decryption.Name);
						bool flag6 = !flag2;
						if (flag6)
						{
							for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
							{
								bool flag3 = methodDef.Body.Instructions[i].OpCode == OpCodes.Mul;
								bool flag7 = flag3;
								if (flag7)
								{
									bool flag4 = methodDef.Body.Instructions[i - 1].IsLdcI4() && methodDef.Body.Instructions[i + 1].IsLdcI4();
									bool flag8 = flag4;
									if (flag8)
									{
										return StaticStrings.smethod_6<string>(param, (uint)methodDef.Body.Instructions[i - 1].GetLdcI4Value(), (uint)methodDef.Body.Instructions[i + 1].GetLdcI4Value());
									}
								}
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000080A0 File Offset: 0x000062A0
		internal static T smethod_6<T>(uint uint_0, uint param1, uint param2)
		{
			uint_0 = (uint_0 * param1 ^ param2);
			uint num = uint_0 >> 30;
			T result = default(T);
			uint_0 &= 1073741823U;
			uint_0 <<= 2;
			num = 3U;
			bool flag = (ulong)num == 3UL;
			bool flag4 = flag;
			if (flag4)
			{
				int count = (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 8 | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 16 | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 24;
				result = (T)((object)string.Intern(Encoding.UTF8.GetString(StaticStrings.byte_0, (int)uint_0, count)));
			}
			else
			{
				bool flag2 = (ulong)num == 2UL;
				bool flag5 = flag2;
				if (flag5)
				{
					T[] array = new T[1];
					Buffer.BlockCopy(StaticStrings.byte_0, (int)uint_0, array, 0, Marshal.SizeOf<T>(default(T)));
					result = array[0];
				}
				else
				{
					bool flag3 = (ulong)num == 0UL;
					bool flag6 = flag3;
					if (flag6)
					{
						int num2 = (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 8 | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 16 | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 24;
						int length = (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 8 | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 16 | (int)StaticStrings.byte_0[(int)((uint)((UIntPtr)(uint_0++)))] << 24;
						Array array2 = Array.CreateInstance(typeof(T).GetElementType(), length);
						Buffer.BlockCopy(StaticStrings.byte_0, (int)uint_0, array2, 0, num2 - 4);
						result = (T)((object)array2);
					}
				}
			}
			return result;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000082D0 File Offset: 0x000064D0
		public static uint getShit(ModuleDefMD module, MethodDef correct)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag9 = !flag;
					if (flag9)
					{
						bool flag2 = !methodDef.IsConstructor;
						bool flag10 = !flag2;
						if (flag10)
						{
							bool flag3 = !methodDef.FullName.ToLower().Contains("module");
							bool flag11 = !flag3;
							if (flag11)
							{
								for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
								{
									bool flag4 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call;
									bool flag12 = flag4;
									if (flag12)
									{
										MethodDef methodDef2 = (MethodDef)methodDef.Body.Instructions[i].Operand;
										bool flag5 = methodDef2 != correct;
										bool flag13 = !flag5;
										if (flag13)
										{
											for (int j = 0; j < methodDef2.Body.Instructions.Count; j++)
											{
												bool flag6 = methodDef2.Body.Instructions[j].OpCode == OpCodes.Stloc_0;
												bool flag14 = flag6;
												if (flag14)
												{
													bool flag7 = methodDef2.Body.Instructions[j - 1].IsLdcI4();
													bool flag15 = flag7;
													if (flag15)
													{
														bool flag8 = methodDef2.Body.Instructions[j - 1].GetLdcI4Value() == 0;
														bool flag16 = !flag8;
														if (flag16)
														{
															return (uint)methodDef2.Body.Instructions[j - 1].GetLdcI4Value();
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return 0U;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00008540 File Offset: 0x00006740
		public static string getArrayName(ModuleDefMD module, MethodDef correct)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag8 = !flag;
					if (flag8)
					{
						bool flag2 = !methodDef.IsConstructor;
						bool flag9 = !flag2;
						if (flag9)
						{
							bool flag3 = !methodDef.FullName.ToLower().Contains("module");
							bool flag10 = !flag3;
							if (flag10)
							{
								for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
								{
									bool flag4 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call;
									bool flag11 = flag4;
									if (flag11)
									{
										MethodDef methodDef2 = (MethodDef)methodDef.Body.Instructions[i].Operand;
										bool flag5 = methodDef2 != correct;
										bool flag12 = !flag5;
										if (flag12)
										{
											for (int j = 0; j < methodDef2.Body.Instructions.Count; j++)
											{
												bool flag6 = methodDef2.Body.Instructions[j].OpCode == OpCodes.Stloc_1;
												bool flag13 = flag6;
												if (flag13)
												{
													bool flag7 = methodDef2.Body.Instructions[j - 2].OpCode == OpCodes.Ldtoken;
													bool flag14 = flag7;
													if (flag14)
													{
														return methodDef2.Body.Instructions[j - 2].Operand.ToString();
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00008790 File Offset: 0x00006990
		public static uint[] getArray(ModuleDefMD module, string fieldName)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					bool flag = !fieldName.ToLower().Contains(fieldDef.Name.ToLower());
					bool flag7 = !flag;
					if (flag7)
					{
						bool flag2 = !fieldDef.HasFieldRVA;
						bool flag8 = !flag2;
						if (flag8)
						{
							bool flag3 = fieldDef.InitialValue.Length == 0;
							bool flag9 = !flag3;
							if (flag9)
							{
								bool flag4 = !fieldDef.FullName.ToLower().Contains("module");
								bool flag10 = !flag4;
								if (flag10)
								{
									bool flag5 = !fieldDef.IsStatic;
									bool flag11 = !flag5;
									if (flag11)
									{
										bool flag6 = !fieldDef.IsAssembly;
										bool flag12 = !flag6;
										if (flag12)
										{
											byte[] initialValue = fieldDef.InitialValue;
											uint[] array = new uint[initialValue.Length / 4];
											Buffer.BlockCopy(initialValue, 0, array, 0, initialValue.Length);
											return array;
										}
									}
								}
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00008928 File Offset: 0x00006B28
		internal static void smethod_1(uint numis, uint[] arrayy, uint val3)
		{
			uint[] array = new uint[16];
			uint num = val3;
			for (int i = 0; i < 16; i++)
			{
				num ^= num >> 12;
				num ^= num << 25;
				num ^= num >> 27;
				array[i] = num;
			}
			int num2 = 0;
			int num3 = 0;
			uint[] array2 = new uint[16];
			byte[] array3 = new byte[numis * 4U];
			while ((long)num2 < (long)((ulong)numis))
			{
				for (int j = 0; j < 16; j++)
				{
					array2[j] = arrayy[num2 + j];
				}
				array2[0] = (array2[0] ^ array[0]);
				array2[1] = (array2[1] ^ array[1]);
				array2[2] = (array2[2] ^ array[2]);
				array2[3] = (array2[3] ^ array[3]);
				array2[4] = (array2[4] ^ array[4]);
				array2[5] = (array2[5] ^ array[5]);
				array2[6] = (array2[6] ^ array[6]);
				array2[7] = (array2[7] ^ array[7]);
				array2[8] = (array2[8] ^ array[8]);
				array2[9] = (array2[9] ^ array[9]);
				array2[10] = (array2[10] ^ array[10]);
				array2[11] = (array2[11] ^ array[11]);
				array2[12] = (array2[12] ^ array[12]);
				array2[13] = (array2[13] ^ array[13]);
				array2[14] = (array2[14] ^ array[14]);
				array2[15] = (array2[15] ^ array[15]);
				for (int k = 0; k < 16; k++)
				{
					uint num4 = array2[k];
					array3[num3++] = (byte)num4;
					array3[num3++] = (byte)(num4 >> 8);
					array3[num3++] = (byte)(num4 >> 16);
					array3[num3++] = (byte)(num4 >> 24);
					array[k] ^= num4;
				}
				num2 += 16;
			}
			StaticStrings.byte_0 = StaticStrings.smethod_0(array3);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00008B0C File Offset: 0x00006D0C
		internal static byte[] smethod_0(byte[] byte_1)
		{
			MemoryStream memoryStream = new MemoryStream(byte_1);
			Class1 @class = new Class1();
			byte[] buffer = new byte[5];
			memoryStream.Read(buffer, 0, 5);
			@class.method_5(buffer);
			long num = 0L;
			for (int i = 0; i < 8; i++)
			{
				int num2 = memoryStream.ReadByte();
				num |= (long)((long)((ulong)((byte)num2)) << 8 * i);
			}
			byte[] array = new byte[(int)num];
			MemoryStream stream_ = new MemoryStream(array, true);
			long long_ = memoryStream.Length - 13L;
			@class.method_4(memoryStream, stream_, long_, num);
			return array;
		}

		// Token: 0x0400004C RID: 76
		public static List<Instruction> C = new List<Instruction>();

		// Token: 0x0400004D RID: 77
		public static int StringsDecrypted = 0;

		// Token: 0x0400004E RID: 78
		private static byte[] byte_0;

		// Token: 0x0400004F RID: 79
		private static MethodSpec DecryptionMethod;
	}
}
