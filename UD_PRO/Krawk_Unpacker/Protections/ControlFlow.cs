using System;
using System.Collections.Generic;
using Attribute_KILLER__WINDOWS_FORMS_APP_;
using de4dot.blocks;
using de4dot.blocks.cflow;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x0200000D RID: 13
	internal class ControlFlow : BlockDeobfuscator
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00003FD0 File Offset: 0x000021D0
		protected override bool Deobfuscate(Block block)
		{
			bool flag = false;
			bool flag2 = block.LastInstr.OpCode == OpCodes.Switch;
			bool flag5 = flag2;
			if (flag5)
			{
				this.allVars = this.blocks.Method.Body.Variables;
				this.isSwitchBlock(block);
				bool flag3 = this.switchBlock != null && this.localSwitch != null;
				bool flag6 = flag3;
				if (flag6)
				{
					this.ins.Initialize(this.blocks.Method);
					flag |= this.Cleaner();
				}
				this.isExpressionBlock(block);
				bool flag4 = this.switchBlock != null || this.localSwitch != null;
				bool flag7 = flag4;
				if (flag7)
				{
					this.ins.Initialize(this.blocks.Method);
					flag |= this.Cleaner();
					while (this.Cleaner())
					{
						flag |= this.Cleaner();
					}
				}
			}
			return flag;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000040C8 File Offset: 0x000022C8
		private bool Cleaner()
		{
			bool result = false;
			List<Block> list = new List<Block>();
			foreach (Block block in this.allBlocks)
			{
				bool flag = block.FallThrough == this.switchBlock;
				bool flag12 = flag;
				if (flag12)
				{
					list.Add(block);
				}
			}
			List<Block> list2 = new List<Block>();
			list2 = this.switchBlock.Targets;
			foreach (Block block2 in list)
			{
				bool flag2 = block2.LastInstr.IsLdcI4();
				bool flag13 = flag2;
				if (flag13)
				{
					int ldcI4Value = block2.LastInstr.GetLdcI4Value();
					this.ins.Push(new Int32Value(ldcI4Value));
					int locVal;
					int num = this.emulateCase(out locVal);
					bool veryVerbose = Form1.veryVerbose;
					bool flag14 = veryVerbose;
					if (flag14)
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.Write(num + ",");
						Console.ForegroundColor = ConsoleColor.Green;
					}
					block2.ReplaceLastNonBranchWithBranch(0, list2[num]);
					this.replace(list2[num], locVal);
					block2.Instructions.Add(new Instr(new Instruction(OpCodes.Pop)));
					result = true;
				}
				else
				{
					bool flag3 = this.isXor(block2);
					bool flag15 = flag3;
					if (flag15)
					{
						this.ins.Emulate(block2.Instructions, block2.Instructions.Count - 5, block2.Instructions.Count);
						Int32Value int32Value = (Int32Value)this.ins.Pop();
						this.ins.Push(int32Value);
						int locVal2;
						int num2 = this.emulateCase(out locVal2);
						bool veryVerbose2 = Form1.veryVerbose;
						bool flag16 = veryVerbose2;
						if (flag16)
						{
							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.Write(num2 + ",");
							Console.ForegroundColor = ConsoleColor.Green;
						}
						block2.ReplaceLastNonBranchWithBranch(0, list2[num2]);
						this.replace(list2[num2], locVal2);
						block2.Instructions.Add(new Instr(new Instruction(OpCodes.Pop)));
						result = true;
					}
					else
					{
						bool flag4 = block2.Sources.Count == 2 && block2.Instructions.Count == 1;
						bool flag17 = flag4;
						if (flag17)
						{
							List<Block> list3 = new List<Block>(block2.Sources);
							foreach (Block block3 in list3)
							{
								bool flag5 = block3.FirstInstr.IsLdcI4();
								bool flag18 = flag5;
								if (flag18)
								{
									int ldcI4Value2 = block3.FirstInstr.GetLdcI4Value();
									this.ins.Push(new Int32Value(ldcI4Value2));
									int locVal3;
									int num3 = this.emulateCase(out locVal3);
									bool veryVerbose3 = Form1.veryVerbose;
									bool flag19 = veryVerbose3;
									if (flag19)
									{
										Console.ForegroundColor = ConsoleColor.Cyan;
										bool flag6 = block3 == list3[0];
										bool flag20 = flag6;
										if (flag20)
										{
											Console.Write("True: " + num3 + ",");
										}
										else
										{
											Console.Write("False: " + num3 + ",");
										}
										Console.ForegroundColor = ConsoleColor.Green;
									}
									block3.ReplaceLastNonBranchWithBranch(0, list2[num3]);
									this.replace(list2[num3], locVal3);
									block3.Instructions[1] = new Instr(new Instruction(OpCodes.Pop));
									result = true;
								}
							}
						}
						else
						{
							bool flag7 = block2.LastInstr.OpCode == OpCodes.Xor;
							bool flag21 = flag7;
							if (flag21)
							{
								bool flag8 = block2.Instructions[block2.Instructions.Count - 2].OpCode == OpCodes.Mul;
								bool flag22 = flag8;
								if (flag22)
								{
									List<Instr> instructions = block2.Instructions;
									int num4 = instructions.Count;
									bool flag9 = !instructions[num4 - 4].IsLdcI4();
									bool flag23 = !flag9;
									if (flag23)
									{
										List<Block> list4 = new List<Block>(block2.Sources);
										foreach (Block block4 in list4)
										{
											bool flag10 = block4.FirstInstr.IsLdcI4();
											bool flag24 = flag10;
											if (flag24)
											{
												int ldcI4Value3 = block4.FirstInstr.GetLdcI4Value();
												try
												{
													instructions[num4 - 5] = new Instr(new Instruction(OpCodes.Ldc_I4, ldcI4Value3));
												}
												catch
												{
													instructions.Insert(num4 - 4, new Instr(new Instruction(OpCodes.Ldc_I4, ldcI4Value3)));
													num4++;
												}
												this.ins.Emulate(instructions, num4 - 5, num4);
												int locVal4;
												int num5 = this.emulateCase(out locVal4);
												bool veryVerbose4 = Form1.veryVerbose;
												bool flag25 = veryVerbose4;
												if (flag25)
												{
													Console.ForegroundColor = ConsoleColor.Cyan;
													bool flag11 = block4 == list4[0];
													bool flag26 = flag11;
													if (flag26)
													{
														Console.Write("True: " + num5 + ",");
													}
													else
													{
														Console.Write("False: " + num5 + ",");
													}
													Console.ForegroundColor = ConsoleColor.Green;
												}
												block4.ReplaceLastNonBranchWithBranch(0, list2[num5]);
												this.replace(list2[num5], locVal4);
												try
												{
													block4.Instructions[1] = new Instr(new Instruction(OpCodes.Pop));
												}
												catch
												{
													block4.Instructions.Add(new Instr(new Instruction(OpCodes.Pop)));
												}
												result = true;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000478C File Offset: 0x0000298C
		private bool replace(Block test, int locVal)
		{
			bool flag = test.IsConditionalBranch();
			bool flag6 = flag;
			if (flag6)
			{
				bool flag2 = test.FallThrough.FallThrough == this.switchBlock;
				bool flag7 = flag2;
				if (flag7)
				{
					test = test.FallThrough;
				}
				else
				{
					test = test.FallThrough.FallThrough;
				}
			}
			bool flag3 = test.LastInstr.OpCode == OpCodes.Switch;
			bool flag8 = flag3;
			if (flag8)
			{
				test = test.FallThrough;
			}
			bool flag4 = test == this.switchBlock;
			bool flag9 = flag4;
			bool result;
			if (flag9)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < test.Instructions.Count; i++)
				{
					bool flag5 = test.Instructions[i].Instruction.GetLocal(this.blocks.Method.Body.Variables) == this.localSwitch;
					bool flag10 = flag5;
					if (flag10)
					{
						test.Instructions[i] = new Instr(Instruction.CreateLdcI4(locVal));
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000048AC File Offset: 0x00002AAC
		public int emulateCase(out int localValueasInt)
		{
			this.ins.Emulate(this.switchBlock.Instructions, 0, this.switchBlock.Instructions.Count - 1);
			Int32Value int32Value = this.ins.GetLocal(this.localSwitch) as Int32Value;
			localValueasInt = int32Value.Value;
			return ((Int32Value)this.ins.Pop()).Value;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000491C File Offset: 0x00002B1C
		private bool isXor(Block block)
		{
			int num = block.Instructions.Count - 1;
			List<Instr> instructions = block.Instructions;
			bool flag = num < 4;
			bool flag7 = flag;
			bool result;
			if (flag7)
			{
				result = false;
			}
			else
			{
				bool flag2 = instructions[num].OpCode != OpCodes.Xor;
				bool flag8 = flag2;
				if (flag8)
				{
					result = false;
				}
				else
				{
					bool flag3 = !instructions[num - 1].IsLdcI4();
					bool flag9 = flag3;
					if (flag9)
					{
						result = false;
					}
					else
					{
						bool flag4 = instructions[num - 2].OpCode != OpCodes.Mul;
						bool flag10 = flag4;
						if (flag10)
						{
							result = false;
						}
						else
						{
							bool flag5 = !instructions[num - 3].IsLdcI4();
							bool flag11 = flag5;
							if (flag11)
							{
								result = false;
							}
							else
							{
								bool flag6 = !instructions[num - 4].IsLdcI4();
								result = !flag6;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004A14 File Offset: 0x00002C14
		private void isExpressionBlock(Block block)
		{
			bool flag = block.Instructions.Count < 7;
			bool flag3 = !flag;
			if (flag3)
			{
				bool flag2 = !block.FirstInstr.IsStloc();
				bool flag4 = !flag2;
				if (flag4)
				{
					this.switchBlock = block;
					this.localSwitch = Instr.GetLocalVar(this.blocks.Method.Body.Variables.Locals, block.Instructions[block.Instructions.Count - 4]);
				}
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004A98 File Offset: 0x00002C98
		private void isNative(Block block)
		{
			bool flag = block.Instructions.Count <= 5;
			bool flag3 = !flag;
			if (flag3)
			{
				bool flag2 = block.FirstInstr.OpCode != OpCodes.Call;
				bool flag4 = !flag2;
				if (flag4)
				{
					this.switchBlock = block;
					this.native = true;
					this.localSwitch = Instr.GetLocalVar(this.allVars, block.Instructions[block.Instructions.Count - 4]);
				}
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004B1C File Offset: 0x00002D1C
		private void isolderCflow(Block block)
		{
			bool flag = block.Instructions.Count <= 2;
			bool flag3 = !flag;
			if (flag3)
			{
				bool flag2 = !block.FirstInstr.IsLdcI4();
				bool flag4 = !flag2;
				if (flag4)
				{
					this.isolder = true;
					this.switchBlock = block;
				}
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004B70 File Offset: 0x00002D70
		private void isolderNatCflow(Block block)
		{
			bool flag = block.Instructions.Count != 2;
			bool flag3 = !flag;
			if (flag3)
			{
				bool flag2 = block.FirstInstr.OpCode != OpCodes.Call;
				bool flag4 = !flag2;
				if (flag4)
				{
					this.isolder = true;
					this.switchBlock = block;
					this.native = true;
				}
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004BD0 File Offset: 0x00002DD0
		private void isolderExpCflow(Block block)
		{
			bool flag = block.Instructions.Count <= 2;
			bool flag3 = !flag;
			if (flag3)
			{
				bool flag2 = !block.FirstInstr.IsStloc();
				bool flag4 = !flag2;
				if (flag4)
				{
					this.isolder = true;
					this.switchBlock = block;
				}
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004C24 File Offset: 0x00002E24
		private void isSwitchBlock(Block block)
		{
			bool flag = block.Instructions.Count <= 6;
			bool flag3 = !flag;
			if (flag3)
			{
				bool flag2 = !block.FirstInstr.IsLdcI4();
				bool flag4 = !flag2;
				if (flag4)
				{
					this.switchBlock = block;
					this.localSwitch = Instr.GetLocalVar(this.allVars, block.Instructions[block.Instructions.Count - 4]);
				}
			}
		}

		// Token: 0x04000029 RID: 41
		private Block switchBlock;

		// Token: 0x0400002A RID: 42
		private Local localSwitch;

		// Token: 0x0400002B RID: 43
		private bool native;

		// Token: 0x0400002C RID: 44
		private bool isolder;

		// Token: 0x0400002D RID: 45
		public MethodDef currentMethod;

		// Token: 0x0400002E RID: 46
		public InstructionEmulator ins = new InstructionEmulator();

		// Token: 0x0400002F RID: 47
		private IList<Local> allVars;
	}
}
