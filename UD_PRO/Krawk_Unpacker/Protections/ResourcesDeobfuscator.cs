using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000014 RID: 20
	internal static class ResourcesDeobfuscator
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00006878 File Offset: 0x00004A78
		internal static bool Deobfuscate(ModuleDefMD module)
		{
			MethodDef decrypterMethod = ResourcesDeobfuscator.GetDecrypterMethod(module);
			bool flag = decrypterMethod == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				MethodDef cctor = module.GlobalType.FindStaticConstructor();
				foreach (Instruction instr in cctor.Body.Instructions)
				{
					bool flag2 = instr.OpCode != OpCodes.Call || instr.Operand as MethodDef != decrypterMethod;
					if (!flag2)
					{
						instr.OpCode = OpCodes.Nop;
						instr.Operand = null;
					}
				}
				ResourcesDeobfuscator.ModifyMethod(decrypterMethod);
				using (MemoryStream stream = new MemoryStream())
				{
					module.Write(stream, new ModuleWriterOptions
					{
						Logger = DummyLogger.NoThrowInstance
					});
					Assembly asm = Assembly.Load(stream.ToArray());
					MethodBase method = asm.ManifestModule.ResolveMethod(decrypterMethod.MDToken.ToInt32());
					byte[] moduleDecrypted = (byte[])method.Invoke(null, null);
					ResourceCollection resources = ModuleDefMD.Load(moduleDecrypted).Resources;
					ResourcesDeobfuscator.totalResources = module.Resources.Count;
					foreach (Resource resource in resources)
					{
						bool flag3 = !module.Resources.Remove(module.Resources.Find(resource.Name));
						if (!flag3)
						{
							module.Resources.Add(resource);
							ResourcesDeobfuscator.resourcesDecrypted++;
						}
					}
					ResourcesDeobfuscator.RemoveMethod(decrypterMethod);
				}
				result = (ResourcesDeobfuscator.totalResources > 0);
			}
			return result;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006A60 File Offset: 0x00004C60
		private static MethodDef GetDecrypterMethod(ModuleDef module)
		{
			MethodDef cctor = module.GlobalType.FindStaticConstructor();
			IList<Instruction> instructions = cctor.Body.Instructions;
			foreach (Instruction instruction in instructions)
			{
				bool flag = instruction.OpCode != OpCodes.Call;
				if (!flag)
				{
					MethodDef initializeMethod = instruction.Operand as MethodDef;
					bool flag2 = initializeMethod == null;
					if (!flag2)
					{
						bool flag3 = !initializeMethod.DeclaringType.IsGlobalModuleType;
						if (!flag3)
						{
							bool flag4 = initializeMethod.Attributes != (dnlib.DotNet.MethodAttributes.Private | dnlib.DotNet.MethodAttributes.FamANDAssem | dnlib.DotNet.MethodAttributes.Static | dnlib.DotNet.MethodAttributes.HideBySig);
							if (!flag4)
							{
								bool flag5 = initializeMethod.ReturnType.ElementType != ElementType.Void;
								if (!flag5)
								{
									bool hasParamDefs = initializeMethod.HasParamDefs;
									if (!hasParamDefs)
									{
										bool flag6 = initializeMethod.FindInstructionsNumber(OpCodes.Call, "System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(System.Array,System.RuntimeFieldHandle)") != 1;
										if (!flag6)
										{
											FieldDef field = ResourcesDeobfuscator.FindAssemblyField(module);
											string operand = (from instr in initializeMethod.Body.Instructions
											where instr.OpCode == OpCodes.Stsfld
											let fieldArray = instr.Operand as FieldDef
											where fieldArray != null
											where field == fieldArray
											select instr.Operand.ToString()).FirstOrDefault<string>();
											bool flag7 = initializeMethod.FindInstructionsNumber(OpCodes.Stsfld, operand) != 1;
											if (!flag7)
											{
												return initializeMethod;
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

		// Token: 0x06000056 RID: 86 RVA: 0x00006C80 File Offset: 0x00004E80
		private static FieldDef FindAssemblyField(ModuleDef module)
		{
			foreach (FieldDef field in module.GlobalType.Fields)
			{
				bool flag = field.Attributes != (dnlib.DotNet.FieldAttributes.Private | dnlib.DotNet.FieldAttributes.FamANDAssem | dnlib.DotNet.FieldAttributes.Static);
				if (!flag)
				{
					bool flag2 = !field.DeclaringType.IsGlobalModuleType;
					if (!flag2)
					{
						bool flag3 = field.FieldType.ElementType != ElementType.Class;
						if (!flag3)
						{
							bool flag4 = field.FieldType.FullName != "System.Reflection.Assembly";
							if (!flag4)
							{
								return field;
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00006D3C File Offset: 0x00004F3C
		private static void ModifyMethod(MethodDef method)
		{
			ITypeDefOrRef corLib = method.Module.Import(typeof(byte[]));
			method.ReturnType = corLib.ToTypeSig(true);
			IList<Instruction> instructions = method.Body.Instructions;
			foreach (Instruction instruction in instructions)
			{
				bool flag = instruction.OpCode != OpCodes.Call;
				if (!flag)
				{
					string operand = instruction.Operand.ToString();
					bool flag2 = !operand.Contains("System.Reflection.Assembly::Load(System.Byte[])");
					if (!flag2)
					{
						instruction.OpCode = OpCodes.Ret;
						instruction.Operand = null;
					}
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00006E00 File Offset: 0x00005000
		private static void RemoveMethod(MethodDef method)
		{
			CilBody body = new CilBody
			{
				Instructions = 
				{
					Instruction.Create(OpCodes.Ldnull),
					Instruction.Create(OpCodes.Ret)
				}
			};
			method.Body = body;
		}

		// Token: 0x04000045 RID: 69
		internal static int resourcesDecrypted;

		// Token: 0x04000046 RID: 70
		internal static int totalResources;
	}
}
