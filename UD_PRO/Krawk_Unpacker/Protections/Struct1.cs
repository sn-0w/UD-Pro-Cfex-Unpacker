using System;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000018 RID: 24
	internal class Struct1
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00008CDE File Offset: 0x00006EDE
		internal Struct1(int int_1)
		{
			this.int_0 = int_1;
			this.struct0_0 = new Struct0[1 << int_1];
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00008D00 File Offset: 0x00006F00
		internal void method_0()
		{
			uint num = 1U;
			while ((ulong)num < 1UL << (this.int_0 & 31))
			{
				this.struct0_0[(int)((uint)((UIntPtr)num))].method_0();
				num += 1U;
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00008D4C File Offset: 0x00006F4C
		internal uint method_1(Class0 class0_0)
		{
			uint num = 1U;
			for (int i = this.int_0; i > 0; i--)
			{
				num = (num << 1) + this.struct0_0[(int)((uint)((UIntPtr)num))].method_1(class0_0);
			}
			return num - (1U << this.int_0);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00008DA8 File Offset: 0x00006FA8
		internal uint method_2(Class0 class0_0)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < this.int_0; i++)
			{
				uint num3 = this.struct0_0[(int)((uint)((UIntPtr)num))].method_1(class0_0);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00008E08 File Offset: 0x00007008
		internal static uint smethod_0(Struct0[] struct0_1, uint uint_0, Class0 class0_0, int int_1)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < int_1; i++)
			{
				uint num3 = struct0_1[(int)((uint)((UIntPtr)(uint_0 + num)))].method_1(class0_0);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x04000051 RID: 81
		internal readonly Struct0[] struct0_0;

		// Token: 0x04000052 RID: 82
		internal readonly int int_0;
	}
}
