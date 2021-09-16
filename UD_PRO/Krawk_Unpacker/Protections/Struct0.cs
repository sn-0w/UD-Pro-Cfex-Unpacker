using System;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000017 RID: 23
	internal struct Struct0
	{
		// Token: 0x06000072 RID: 114 RVA: 0x00008BB8 File Offset: 0x00006DB8
		internal void method_0()
		{
			this.uint_0 = 1024U;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00008BC8 File Offset: 0x00006DC8
		internal uint method_1(Class0 class0_0)
		{
			uint num = (class0_0.uint_1 >> 11) * this.uint_0;
			bool flag = class0_0.uint_0 < num;
			bool flag4 = flag;
			uint result;
			if (flag4)
			{
				class0_0.uint_1 = num;
				this.uint_0 += 2048U - this.uint_0 >> 5;
				bool flag2 = class0_0.uint_1 < 16777216U;
				bool flag5 = flag2;
				if (flag5)
				{
					class0_0.uint_0 = (class0_0.uint_0 << 8 | (uint)((byte)class0_0.stream_0.ReadByte()));
					class0_0.uint_1 <<= 8;
				}
				result = 0U;
			}
			else
			{
				class0_0.uint_1 -= num;
				class0_0.uint_0 -= num;
				this.uint_0 -= this.uint_0 >> 5;
				bool flag3 = class0_0.uint_1 < 16777216U;
				bool flag6 = flag3;
				if (flag6)
				{
					class0_0.uint_0 = (class0_0.uint_0 << 8 | (uint)((byte)class0_0.stream_0.ReadByte()));
					class0_0.uint_1 <<= 8;
				}
				result = 1U;
			}
			return result;
		}

		// Token: 0x04000050 RID: 80
		internal uint uint_0;
	}
}
