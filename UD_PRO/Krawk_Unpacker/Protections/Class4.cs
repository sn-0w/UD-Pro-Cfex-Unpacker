using System;
using System.IO;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x0200000B RID: 11
	internal class Class4
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00003A80 File Offset: 0x00001C80
		internal void method_0(uint uint_3)
		{
			bool flag = this.uint_2 != uint_3;
			bool flag2 = flag;
			if (flag2)
			{
				this.byte_0 = new byte[uint_3];
			}
			this.uint_2 = uint_3;
			this.uint_0 = 0U;
			this.uint_1 = 0U;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003AC4 File Offset: 0x00001CC4
		internal void method_1(Stream stream_1, bool bool_0)
		{
			this.method_2();
			this.stream_0 = stream_1;
			bool flag = !bool_0;
			bool flag2 = flag;
			if (flag2)
			{
				this.uint_1 = 0U;
				this.uint_0 = 0U;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003AFA File Offset: 0x00001CFA
		internal void method_2()
		{
			this.method_3();
			this.stream_0 = null;
			Buffer.BlockCopy(new byte[this.byte_0.Length], 0, this.byte_0, 0, this.byte_0.Length);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003B30 File Offset: 0x00001D30
		internal void method_3()
		{
			uint num = this.uint_0 - this.uint_1;
			bool flag = num == 0U;
			bool flag3 = !flag;
			if (flag3)
			{
				this.stream_0.Write(this.byte_0, (int)this.uint_1, (int)num);
				bool flag2 = this.uint_0 >= this.uint_2;
				bool flag4 = flag2;
				if (flag4)
				{
					this.uint_0 = 0U;
				}
				this.uint_1 = this.uint_0;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003BA4 File Offset: 0x00001DA4
		internal void method_4(uint uint_3, uint uint_4)
		{
			uint num = this.uint_0 - uint_3 - 1U;
			bool flag = num >= this.uint_2;
			bool flag4 = flag;
			if (flag4)
			{
				num += this.uint_2;
			}
			while (uint_4 > 0U)
			{
				bool flag2 = num >= this.uint_2;
				bool flag5 = flag2;
				if (flag5)
				{
					num = 0U;
				}
				byte[] array = this.byte_0;
				uint num2 = this.uint_0;
				this.uint_0 = num2 + 1U;
				array[(int)((uint)((UIntPtr)num2))] = this.byte_0[(int)((uint)((UIntPtr)(num++)))];
				bool flag3 = this.uint_0 >= this.uint_2;
				bool flag6 = flag3;
				if (flag6)
				{
					this.method_3();
				}
				uint_4 -= 1U;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003C70 File Offset: 0x00001E70
		internal void method_5(byte byte_1)
		{
			byte[] array = this.byte_0;
			uint num = this.uint_0;
			this.uint_0 = num + 1U;
			array[(int)((uint)((UIntPtr)num))] = byte_1;
			bool flag = this.uint_0 >= this.uint_2;
			bool flag2 = flag;
			if (flag2)
			{
				this.method_3();
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003CC4 File Offset: 0x00001EC4
		internal byte method_6(uint uint_3)
		{
			uint num = this.uint_0 - uint_3 - 1U;
			bool flag = num >= this.uint_2;
			bool flag2 = flag;
			if (flag2)
			{
				num += this.uint_2;
			}
			return this.byte_0[(int)((uint)((UIntPtr)num))];
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000218C File Offset: 0x0000038C
		internal Class4()
		{
		}

		// Token: 0x04000024 RID: 36
		internal byte[] byte_0;

		// Token: 0x04000025 RID: 37
		internal uint uint_0;

		// Token: 0x04000026 RID: 38
		internal Stream stream_0;

		// Token: 0x04000027 RID: 39
		internal uint uint_1;

		// Token: 0x04000028 RID: 40
		internal uint uint_2;
	}
}
