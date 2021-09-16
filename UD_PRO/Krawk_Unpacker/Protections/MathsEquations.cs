using System;
using Attribute_KILLER__WINDOWS_FORMS_APP_;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000011 RID: 17
	internal class MathsEquations
	{
		internal static uint ComputeStringHash(string s)
		{
			uint num = 0;
			if (s != null)
			{
				num = 2166136261U;
				for (int i = 0; i < s.Length; i++)
				{
					num = ((uint)s[i] ^ num) * 16777619U;
				}
			}
			return num;
		}
		// Token: 0x06000048 RID: 72 RVA: 0x000050FC File Offset: 0x000032FC
		public static void SizeofRemove(ModuleDef module)
		{
			foreach (TypeDef type in module.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					bool flag = method.HasBody && method.Body.HasInstructions;
					if (flag)
					{
						for (int i = 1; i < method.Body.Instructions.Count - 1; i++)
						{
							bool flag2 = method.Body.Instructions[i].OpCode == OpCodes.Sizeof;
							if (flag2)
							{
								try
								{
									string siz = method.Body.Instructions[i].Operand.ToString();
									string text = siz;
									uint num = ComputeStringHash(text);
									if (num <= 1741144581U)
									{
										if (num <= 942540437U)
										{
											if (num <= 749531509U)
											{
												if (num != 347085918U)
												{
													if (num == 749531509U)
													{
														if (text == "System.Convert")
														{
															method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
															method.Body.Instructions[i].Operand = 4;
														}
													}
												}
												else if (text == "System.Boolean")
												{
													method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
													method.Body.Instructions[i].Operand = 1;
												}
											}
											else if (num != 848225627U)
											{
												if (num != 875577056U)
												{
													if (num == 942540437U)
													{
														if (text == "System.UInt16")
														{
															method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
															method.Body.Instructions[i].Operand = 2;
														}
													}
												}
												else if (text == "System.UInt64")
												{
													method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
													method.Body.Instructions[i].Operand = 8;
												}
											}
											else if (text == "System.Double")
											{
												method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
												method.Body.Instructions[i].Operand = 8;
											}
										}
										else if (num <= 1599499907U)
										{
											if (num != 1541528931U)
											{
												if (num == 1599499907U)
												{
													if (text == "System.IntPtr")
													{
														method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
														method.Body.Instructions[i].Operand = 4;
													}
												}
											}
											else if (text == "System.DateTime")
											{
												method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
												method.Body.Instructions[i].Operand = 8;
											}
										}
										else if (num != 1688798982U)
										{
											if (num != 1697786220U)
											{
												if (num == 1741144581U)
												{
													if (text == "System.Decimal")
													{
														method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
														method.Body.Instructions[i].Operand = 16;
													}
												}
											}
											else if (text == "System.Int16")
											{
												method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
												method.Body.Instructions[i].Operand = 2;
											}
										}
										else if (text == "System.Type")
										{
											method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
											method.Body.Instructions[i].Operand = 4;
										}
									}
									else if (num <= 3079944380U)
									{
										if (num <= 2185383742U)
										{
											if (num != 1764058053U)
											{
												if (num == 2185383742U)
												{
													if (text == "System.Single")
													{
														method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
														method.Body.Instructions[i].Operand = 4;
													}
												}
											}
											else if (text == "System.Int64")
											{
												method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
												method.Body.Instructions[i].Operand = 8;
											}
										}
										else if (num != 2736390927U)
										{
											if (num != 2747029693U)
											{
												if (num == 3079944380U)
												{
													if (text == "System.Byte")
													{
														method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
														method.Body.Instructions[i].Operand = 1;
													}
												}
											}
											else if (text == "System.SByte")
											{
												method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
												method.Body.Instructions[i].Operand = 1;
											}
										}
										else if (text == "System.Guid")
										{
											method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
											method.Body.Instructions[i].Operand = 16;
										}
									}
									else if (num <= 3482805428U)
									{
										if (num != 3291009739U)
										{
											if (num != 3376699151U)
											{
												if (num == 3482805428U)
												{
													if (text == "System.UIntPtr")
													{
														method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
														method.Body.Instructions[i].Operand = 4;
													}
												}
											}
											else if (text == "System.Console")
											{
												method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
												method.Body.Instructions[i].Operand = 2;
											}
										}
										else if (text == "System.UInt32")
										{
											method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
											method.Body.Instructions[i].Operand = 4;
										}
									}
									else if (num != 4059290250U)
									{
										if (num != 4180476474U)
										{
											if (num == 4201364391U)
											{
												if (text == "System.String")
												{
													method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
													method.Body.Instructions[i].Operand = 1;
												}
											}
										}
										else if (text == "System.Int32")
										{
											method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
											method.Body.Instructions[i].Operand = 4;
										}
									}
									else if (text == "System.Windows.Forms.RightToLeft")
									{
										method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
										method.Body.Instructions[i].Operand = 2;
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
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005AC4 File Offset: 0x00003CC4
		public static void MathsFixer(ModuleDefMD module)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag8 = !flag;
					if (flag8)
					{
						for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
						{
							bool flag2 = methodDef.Body.Instructions[i].OpCode == OpCodes.Add;
							bool flag9 = flag2;
							if (flag9)
							{
								bool flag3 = methodDef.Body.Instructions[i - 1].IsLdcI4() && methodDef.Body.Instructions[i - 2].IsLdcI4();
								bool flag10 = flag3;
								if (flag10)
								{
									int num = methodDef.Body.Instructions[i - 2].GetLdcI4Value() + methodDef.Body.Instructions[i - 1].GetLdcI4Value();
									methodDef.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
									methodDef.Body.Instructions[i].Operand = num;
									methodDef.Body.Instructions[i - 2].OpCode = OpCodes.Nop;
									methodDef.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
									Form1.MathsAmount++;
								}
							}
							else
							{
								bool flag4 = methodDef.Body.Instructions[i].OpCode == OpCodes.Mul;
								bool flag11 = flag4;
								if (flag11)
								{
									bool flag5 = methodDef.Body.Instructions[i - 1].IsLdcI4() && methodDef.Body.Instructions[i - 2].IsLdcI4();
									bool flag12 = flag5;
									if (flag12)
									{
										int num2 = methodDef.Body.Instructions[i - 2].GetLdcI4Value() * methodDef.Body.Instructions[i - 1].GetLdcI4Value();
										methodDef.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
										methodDef.Body.Instructions[i].Operand = num2;
										methodDef.Body.Instructions[i - 2].OpCode = OpCodes.Nop;
										methodDef.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
										Form1.MathsAmount++;
									}
								}
								else
								{
									bool flag6 = methodDef.Body.Instructions[i].OpCode == OpCodes.Sub;
									bool flag13 = flag6;
									if (flag13)
									{
										bool flag7 = methodDef.Body.Instructions[i - 1].IsLdcI4() && methodDef.Body.Instructions[i - 2].IsLdcI4();
										bool flag14 = flag7;
										if (flag14)
										{
											int num3 = methodDef.Body.Instructions[i - 2].GetLdcI4Value() - methodDef.Body.Instructions[i - 1].GetLdcI4Value();
											methodDef.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
											methodDef.Body.Instructions[i].Operand = num3;
											methodDef.Body.Instructions[i - 2].OpCode = OpCodes.Nop;
											methodDef.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
											Form1.MathsAmount++;
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
