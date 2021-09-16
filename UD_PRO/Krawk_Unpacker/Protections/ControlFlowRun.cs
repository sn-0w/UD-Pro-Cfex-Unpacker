using System;
using System.Collections.Generic;
using Attribute_KILLER__WINDOWS_FORMS_APP_;
using de4dot.blocks;
using de4dot.blocks.cflow;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x0200000E RID: 14
	internal class ControlFlowRun
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00004CAC File Offset: 0x00002EAC
		public static void DeobfuscateCflow(MethodDef meth)
		{
			for (int i = 0; i < 2; i++)
			{
				ControlFlowRun.CfDeob = new BlocksCflowDeobfuscator();
				Blocks blocks = new Blocks(meth);
				List<Block> test = blocks.MethodBlocks.GetAllBlocks();
				blocks.RemoveDeadBlocks();
				blocks.RepartitionBlocks();
				blocks.UpdateBlocks();
				blocks.Method.Body.SimplifyBranches();
				blocks.Method.Body.OptimizeBranches();
				ControlFlowRun.CfDeob.Initialize(blocks);
				ControlFlowRun.CfDeob.Add(new ControlFlow());
				ControlFlowRun.CfDeob.Deobfuscate();
				blocks.RepartitionBlocks();
				IList<Instruction> instructions;
				IList<ExceptionHandler> exceptionHandlers;
				blocks.GetCode(out instructions, out exceptionHandlers);
				DotNetUtils.RestoreBody(meth, instructions, exceptionHandlers);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00004D6C File Offset: 0x00002F6C
		public static bool hasCflow(MethodDef methods)
		{
			for (int i = 0; i < methods.Body.Instructions.Count; i++)
			{
				bool flag = methods.Body.Instructions[i].OpCode == OpCodes.Switch;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00004DC8 File Offset: 0x00002FC8
		public static void cleaner(ModuleDefMD module)
		{
			foreach (TypeDef types in module.GetTypes())
			{
				foreach (MethodDef methods in types.Methods)
				{
					bool flag = !methods.HasBody;
					if (!flag)
					{
						bool flag2 = ControlFlowRun.hasCflow(methods);
						if (flag2)
						{
							bool veryVerbose = Form1.veryVerbose;
							if (veryVerbose)
							{
							}
							ControlFlowRun.DeobfuscateCflow(methods);
							bool veryVerbose2 = Form1.veryVerbose;
							if (veryVerbose2)
							{
								Console.WriteLine();
							}
						}
					}
				}
			}
		}

		// Token: 0x04000030 RID: 48
		private static BlocksCflowDeobfuscator CfDeob;
	}
}
