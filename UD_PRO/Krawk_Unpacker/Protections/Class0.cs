using System;
using System.IO;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000009 RID: 9
	internal class Class0
	{
		// Token: 0x0600001D RID: 29 RVA: 0x000030D8 File Offset: 0x000012D8
		internal void method_0(Stream stream_1)
		{
			this.stream_0 = stream_1;
			this.uint_0 = 0U;
			this.uint_1 = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				this.uint_0 = (this.uint_0 << 8 | (uint)((byte)this.stream_0.ReadByte()));
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003128 File Offset: 0x00001328
		internal void method_1()
		{
			this.stream_0 = null;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003134 File Offset: 0x00001334
		internal void method_2()
		{
			while (this.uint_1 < 16777216U)
			{
				this.uint_0 = (this.uint_0 << 8 | (uint)((byte)this.stream_0.ReadByte()));
				this.uint_1 <<= 8;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003180 File Offset: 0x00001380
		internal uint method_3(int int_0)
		{
			uint num = this.uint_1;
			uint num2 = this.uint_0;
			uint num3 = 0U;
			for (int i = int_0; i > 0; i--)
			{
				num >>= 1;
				uint num4 = num2 - num >> 31;
				num2 -= (num & num4 - 1U);
				num3 = (num3 << 1 | 1U - num4);
				bool flag = num < 16777216U;
				bool flag2 = flag;
				if (flag2)
				{
					num2 = (num2 << 8 | (uint)((byte)this.stream_0.ReadByte()));
					num <<= 8;
				}
			}
			this.uint_1 = num;
			this.uint_0 = num2;
			return num3;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000218C File Offset: 0x0000038C
		internal Class0()
		{
		}

		// Token: 0x0400000F RID: 15
		internal uint uint_0;

		// Token: 0x04000010 RID: 16
		internal uint uint_1;

		// Token: 0x04000011 RID: 17
		internal Stream stream_0;
	}
}
