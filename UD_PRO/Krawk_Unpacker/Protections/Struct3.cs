using System;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000019 RID: 25
	internal struct Struct3
	{
		// Token: 0x06000079 RID: 121 RVA: 0x00008E60 File Offset: 0x00007060
		internal void method_0()
		{
			this.uint_0 = 0U;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00008E6C File Offset: 0x0000706C
		internal void method_1()
		{
			bool flag = this.uint_0 < 4U;
			bool flag3 = flag;
			if (flag3)
			{
				this.uint_0 = 0U;
			}
			else
			{
				bool flag2 = this.uint_0 < 10U;
				bool flag4 = flag2;
				if (flag4)
				{
					this.uint_0 -= 3U;
				}
				else
				{
					this.uint_0 -= 6U;
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00008EC8 File Offset: 0x000070C8
		internal void method_2()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 7U : 10U);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00008EDF File Offset: 0x000070DF
		internal void method_3()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 8U : 11U);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00008EF6 File Offset: 0x000070F6
		internal void method_4()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 9U : 11U);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00008F10 File Offset: 0x00007110
		internal bool method_5()
		{
			return this.uint_0 < 7U;
		}

		// Token: 0x04000053 RID: 83
		internal uint uint_0;
	}
}
