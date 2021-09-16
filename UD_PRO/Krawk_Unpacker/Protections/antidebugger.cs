using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000005 RID: 5
	internal static class antidebugger
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002238 File Offset: 0x00000438
		internal static bool Run(ModuleDefMD krawk)
		{
			IList<Instruction> instructions = krawk.GlobalType.FindStaticConstructor().Body.Instructions;
			foreach (Instruction instruction in instructions)
			{
				bool flag = instruction.OpCode != OpCodes.Call;
				bool flag6 = !flag;
				if (flag6)
				{
					MethodDef methodDef = instruction.Operand as MethodDef;
					bool flag2 = methodDef == null;
					bool flag7 = !flag2;
					if (flag7)
					{
						bool flag3 = methodDef.FindInstructionsNumber(OpCodes.Ldstr, "ENABLE_PROFILING") != 1;
						bool flag8 = !flag3;
						if (flag8)
						{
							bool flag4 = methodDef.FindInstructionsNumber(OpCodes.Ldstr, "GetEnvironmentVariable") != 1;
							bool flag9 = !flag4;
							if (flag9)
							{
								bool flag5 = methodDef.FindInstructionsNumber(OpCodes.Call, "System.Environment::FailFast(System.String)") != 1;
								bool flag10 = !flag5;
								if (flag10)
								{
									instruction.OpCode = OpCodes.Nop;
									instruction.Operand = null;
									return true;
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
