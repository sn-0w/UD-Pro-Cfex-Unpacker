using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000006 RID: 6
	internal static class antidumper
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002370 File Offset: 0x00000570
		internal static int FindInstructionsNumber(this MethodDef method, OpCode opCode, object operand)
		{
			int num = 0;
			foreach (Instruction instruction in method.Body.Instructions)
			{
				bool flag = instruction.OpCode != opCode;
				if (!flag)
				{
					bool flag2 = operand is int;
					if (flag2)
					{
						int value = instruction.GetLdcI4Value();
						bool flag3 = value == (int)operand;
						if (flag3)
						{
							num++;
						}
					}
					else
					{
						bool flag4 = operand is string;
						if (flag4)
						{
							string value2 = instruction.Operand.ToString();
							bool flag5 = value2.Contains(operand.ToString());
							if (flag5)
							{
								num++;
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002444 File Offset: 0x00000644
		internal static bool Run(ModuleDefMD module)
		{
			IList<Instruction> instructions = module.GlobalType.FindStaticConstructor().Body.Instructions;
			foreach (Instruction instr in instructions)
			{
				bool flag = instr.OpCode != OpCodes.Call;
				if (!flag)
				{
					MethodDef dumperMethod = instr.Operand as MethodDef;
					bool flag2 = dumperMethod == null;
					if (!flag2)
					{
						bool flag3 = !dumperMethod.DeclaringType.IsGlobalModuleType;
						if (!flag3)
						{
							bool flag4 = dumperMethod.Attributes != (MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static | MethodAttributes.HideBySig);
							if (!flag4)
							{
								bool flag5 = dumperMethod.CodeType > MethodImplAttributes.IL;
								if (!flag5)
								{
									bool flag6 = dumperMethod.ReturnType.ElementType != ElementType.Void;
									if (!flag6)
									{
										bool flag7 = dumperMethod.FindInstructionsNumber(OpCodes.Call, "(System.Byte*,System.Int32,System.UInt32,System.UInt32&)") != 14;
										if (!flag7)
										{
											instr.OpCode = OpCodes.Nop;
											instr.Operand = null;
											return true;
										}
									}
								}
							}
						}
					}
				}
			}
			return false;
		}
	}
}
