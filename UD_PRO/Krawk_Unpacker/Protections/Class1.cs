using System;
using System.IO;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x0200000A RID: 10
	internal class Class1
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00003210 File Offset: 0x00001410
		internal Class1()
		{
			this.uint_0 = uint.MaxValue;
			int num = 0;
			while ((long)num < 4L)
			{
				this.struct1_0[num] = new Struct1(6);
				num++;
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003300 File Offset: 0x00001500
		internal void method_0(uint uint_3)
		{
			bool flag = this.uint_0 != uint_3;
			bool flag2 = flag;
			if (flag2)
			{
				this.uint_0 = uint_3;
				this.uint_1 = Math.Max(this.uint_0, 1U);
				uint uint_4 = Math.Max(this.uint_1, 4096U);
				this.class4_0.method_0(uint_4);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003359 File Offset: 0x00001559
		internal void method_1(int int_0, int int_1)
		{
			this.class3_0.method_0(int_0, int_1);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000336C File Offset: 0x0000156C
		internal void method_2(int int_0)
		{
			uint num = 1U << int_0;
			this.class2_0.method_0(num);
			this.class2_1.method_0(num);
			this.uint_2 = num - 1U;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000033A4 File Offset: 0x000015A4
		internal void method_3(Stream stream_0, Stream stream_1)
		{
			this.class0_0.method_0(stream_0);
			this.class4_0.method_1(stream_1, this.bool_0);
			for (uint num = 0U; num < 12U; num += 1U)
			{
				for (uint num2 = 0U; num2 <= this.uint_2; num2 += 1U)
				{
					uint value = (num << 4) + num2;
					this.struct0_0[(int)((uint)((UIntPtr)value))].method_0();
					this.struct0_1[(int)((uint)((UIntPtr)value))].method_0();
				}
				this.struct0_2[(int)((uint)((UIntPtr)num))].method_0();
				this.struct0_3[(int)((uint)((UIntPtr)num))].method_0();
				this.struct0_4[(int)((uint)((UIntPtr)num))].method_0();
				this.struct0_5[(int)((uint)((UIntPtr)num))].method_0();
			}
			this.class3_0.method_1();
			for (uint num3 = 0U; num3 < 4U; num3 += 1U)
			{
				this.struct1_0[(int)((uint)((UIntPtr)num3))].method_0();
			}
			for (uint num4 = 0U; num4 < 114U; num4 += 1U)
			{
				this.struct0_6[(int)((uint)((UIntPtr)num4))].method_0();
			}
			this.class2_0.method_1();
			this.class2_1.method_1();
			this.struct1_1.method_0();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000354C File Offset: 0x0000174C
		internal void method_4(Stream stream_0, Stream stream_1, long long_0, long long_1)
		{
			this.method_3(stream_0, stream_1);
			Struct3 @struct = default(Struct3);
			@struct.method_0();
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			uint num4 = 0U;
			ulong num5 = 0UL;
			bool flag = 0L < long_1;
			bool flag12 = flag;
			if (flag12)
			{
				this.struct0_0[(int)((uint)((UIntPtr)(@struct.uint_0 << 4)))].method_1(this.class0_0);
				@struct.method_1();
				byte byte_ = this.class3_0.method_3(this.class0_0, 0U, 0);
				this.class4_0.method_5(byte_);
				num5 += 1UL;
			}
			while (num5 < (ulong)long_1)
			{
				uint num6 = (uint)num5 & this.uint_2;
				bool flag2 = this.struct0_0[(int)((uint)((UIntPtr)((@struct.uint_0 << 4) + num6)))].method_1(this.class0_0) == 0U;
				bool flag13 = flag2;
				if (flag13)
				{
					byte byte_2 = this.class4_0.method_6(0U);
					bool flag3 = !@struct.method_5();
					bool flag14 = flag3;
					byte byte_3;
					if (flag14)
					{
						byte_3 = this.class3_0.method_4(this.class0_0, (uint)num5, byte_2, this.class4_0.method_6(num));
					}
					else
					{
						byte_3 = this.class3_0.method_3(this.class0_0, (uint)num5, byte_2);
					}
					this.class4_0.method_5(byte_3);
					@struct.method_1();
					num5 += 1UL;
				}
				else
				{
					bool flag4 = this.struct0_2[(int)((uint)((UIntPtr)@struct.uint_0))].method_1(this.class0_0) == 1U;
					bool flag15 = flag4;
					uint num8;
					if (flag15)
					{
						bool flag5 = this.struct0_3[(int)((uint)((UIntPtr)@struct.uint_0))].method_1(this.class0_0) == 0U;
						bool flag16 = flag5;
						if (flag16)
						{
							bool flag6 = this.struct0_1[(int)((uint)((UIntPtr)((@struct.uint_0 << 4) + num6)))].method_1(this.class0_0) == 0U;
							bool flag17 = flag6;
							if (flag17)
							{
								@struct.method_4();
								this.class4_0.method_5(this.class4_0.method_6(num));
								num5 += 1UL;
								continue;
							}
						}
						else
						{
							bool flag7 = this.struct0_4[(int)((uint)((UIntPtr)@struct.uint_0))].method_1(this.class0_0) == 0U;
							bool flag18 = flag7;
							uint num7;
							if (flag18)
							{
								num7 = num2;
							}
							else
							{
								bool flag8 = this.struct0_5[(int)((uint)((UIntPtr)@struct.uint_0))].method_1(this.class0_0) == 0U;
								bool flag19 = flag8;
								if (flag19)
								{
									num7 = num3;
								}
								else
								{
									num7 = num4;
									num4 = num3;
								}
								num3 = num2;
							}
							num2 = num;
							num = num7;
						}
						num8 = this.class2_1.method_2(this.class0_0, num6) + 2U;
						@struct.method_3();
					}
					else
					{
						num4 = num3;
						num3 = num2;
						num2 = num;
						num8 = 2U + this.class2_0.method_2(this.class0_0, num6);
						@struct.method_2();
						uint num9 = this.struct1_0[(int)((uint)((UIntPtr)Class1.smethod_0(num8)))].method_1(this.class0_0);
						bool flag9 = num9 >= 4U;
						bool flag20 = flag9;
						if (flag20)
						{
							int num10 = (int)((num9 >> 1) - 1U);
							num = (2U | (num9 & 1U)) << num10;
							bool flag10 = num9 < 14U;
							bool flag21 = flag10;
							if (flag21)
							{
								num += Struct1.smethod_0(this.struct0_6, num - num9 - 1U, this.class0_0, num10);
							}
							else
							{
								num += this.class0_0.method_3(num10 - 4) << 4;
								num += this.struct1_1.method_2(this.class0_0);
							}
						}
						else
						{
							num = num9;
						}
					}
					bool flag11 = ((ulong)num >= num5 || num >= this.uint_1) && num == uint.MaxValue;
					bool flag22 = flag11;
					if (flag22)
					{
						break;
					}
					this.class4_0.method_4(num, num8);
					num5 += (ulong)num8;
				}
			}
			this.class4_0.method_3();
			this.class4_0.method_2();
			this.class0_0.method_1();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000398C File Offset: 0x00001B8C
		internal void method_5(byte[] byte_0)
		{
			int int_ = (int)(byte_0[0] % 9);
			int num = (int)(byte_0[0] / 9);
			int int_2 = num % 5;
			int int_3 = num / 5;
			uint num2 = 0U;
			for (int i = 0; i < 4; i++)
			{
				num2 += (uint)((uint)byte_0[1 + i] << i * 8);
			}
			this.method_0(num2);
			this.method_1(int_2, int_);
			this.method_2(int_3);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000039F8 File Offset: 0x00001BF8
		internal void method_01(uint uint_3)
		{
			bool flag = this.uint_0 != uint_3;
			bool flag2 = flag;
			if (flag2)
			{
				this.uint_0 = uint_3;
				this.uint_1 = Math.Max(this.uint_0, 1U);
				uint uint_4 = Math.Max(this.uint_1, 4096U);
				this.class4_0.method_0(uint_4);
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003A54 File Offset: 0x00001C54
		internal static uint smethod_0(uint uint_3)
		{
			uint_3 -= 2U;
			bool flag = uint_3 < 4U;
			bool flag2 = flag;
			uint result;
			if (flag2)
			{
				result = uint_3;
			}
			else
			{
				result = 3U;
			}
			return result;
		}

		// Token: 0x04000012 RID: 18
		internal readonly Struct0[] struct0_0 = new Struct0[192];

		// Token: 0x04000013 RID: 19
		internal readonly Struct0[] struct0_1 = new Struct0[192];

		// Token: 0x04000014 RID: 20
		internal readonly Struct0[] struct0_2 = new Struct0[12];

		// Token: 0x04000015 RID: 21
		internal readonly Struct0[] struct0_3 = new Struct0[12];

		// Token: 0x04000016 RID: 22
		internal readonly Struct0[] struct0_4 = new Struct0[12];

		// Token: 0x04000017 RID: 23
		internal readonly Struct0[] struct0_5 = new Struct0[12];

		// Token: 0x04000018 RID: 24
		internal readonly Class1.Class2 class2_0 = new Class1.Class2();

		// Token: 0x04000019 RID: 25
		internal readonly Class1.Class3 class3_0 = new Class1.Class3();

		// Token: 0x0400001A RID: 26
		internal readonly Class4 class4_0 = new Class4();

		// Token: 0x0400001B RID: 27
		internal readonly Struct0[] struct0_6 = new Struct0[114];

		// Token: 0x0400001C RID: 28
		internal readonly Struct1[] struct1_0 = new Struct1[4];

		// Token: 0x0400001D RID: 29
		internal readonly Class0 class0_0 = new Class0();

		// Token: 0x0400001E RID: 30
		internal readonly Class1.Class2 class2_1 = new Class1.Class2();

		// Token: 0x0400001F RID: 31
		internal bool bool_0;

		// Token: 0x04000020 RID: 32
		internal uint uint_0;

		// Token: 0x04000021 RID: 33
		internal uint uint_1;

		// Token: 0x04000022 RID: 34
		internal Struct1 struct1_1 = new Struct1(4);

		// Token: 0x04000023 RID: 35
		internal uint uint_2;

		// Token: 0x0200001D RID: 29
		internal class Class2
		{
			// Token: 0x06000090 RID: 144 RVA: 0x0000AA80 File Offset: 0x00008C80
			internal void method_0(uint uint_1)
			{
				for (uint num = this.uint_0; num < uint_1; num += 1U)
				{
					this.struct1_0[(int)((uint)((UIntPtr)num))] = new Struct1(3);
					this.struct1_1[(int)((uint)((UIntPtr)num))] = new Struct1(3);
				}
				this.uint_0 = uint_1;
			}

			// Token: 0x06000091 RID: 145 RVA: 0x0000AADC File Offset: 0x00008CDC
			internal void method_1()
			{
				this.struct0_0.method_0();
				for (uint num = 0U; num < this.uint_0; num += 1U)
				{
					this.struct1_0[(int)((uint)((UIntPtr)num))].method_0();
					this.struct1_1[(int)((uint)((UIntPtr)num))].method_0();
				}
				this.struct0_1.method_0();
				this.struct1_2.method_0();
			}

			// Token: 0x06000092 RID: 146 RVA: 0x0000AB58 File Offset: 0x00008D58
			internal uint method_2(Class0 class0_0, uint uint_1)
			{
				bool flag = this.struct0_0.method_1(class0_0) == 0U;
				bool flag3 = flag;
				uint result;
				if (flag3)
				{
					result = this.struct1_0[(int)((uint)((UIntPtr)uint_1))].method_1(class0_0);
				}
				else
				{
					uint num = 8U;
					bool flag2 = this.struct0_1.method_1(class0_0) == 0U;
					bool flag4 = flag2;
					if (flag4)
					{
						num += this.struct1_1[(int)((uint)((UIntPtr)uint_1))].method_1(class0_0);
					}
					else
					{
						num += 8U;
						num += this.struct1_2.method_1(class0_0);
					}
					result = num;
				}
				return result;
			}

			// Token: 0x06000093 RID: 147 RVA: 0x0000ABF4 File Offset: 0x00008DF4
			internal Class2()
			{
			}

			// Token: 0x0400006F RID: 111
			internal readonly Struct1[] struct1_0 = new Struct1[16];

			// Token: 0x04000070 RID: 112
			internal readonly Struct1[] struct1_1 = new Struct1[16];

			// Token: 0x04000071 RID: 113
			internal Struct0 struct0_0 = default(Struct0);

			// Token: 0x04000072 RID: 114
			internal Struct0 struct0_1 = default(Struct0);

			// Token: 0x04000073 RID: 115
			internal Struct1 struct1_2 = new Struct1(8);

			// Token: 0x04000074 RID: 116
			internal uint uint_0;
		}

		// Token: 0x0200001E RID: 30
		internal class Class3
		{
			// Token: 0x06000094 RID: 148 RVA: 0x0000AC48 File Offset: 0x00008E48
			internal void method_0(int int_2, int int_3)
			{
				bool flag = this.struct2_0 != null && this.int_1 == int_3 && this.int_0 == int_2;
				bool flag2 = !flag;
				if (flag2)
				{
					this.int_0 = int_2;
					this.uint_0 = (1U << int_2) - 1U;
					this.int_1 = int_3;
					uint num = 1U << this.int_1 + this.int_0;
					this.struct2_0 = new Class1.Class3.Struct2[num];
					for (uint num2 = 0U; num2 < num; num2 += 1U)
					{
						this.struct2_0[(int)((uint)((UIntPtr)num2))].method_0();
					}
				}
			}

			// Token: 0x06000095 RID: 149 RVA: 0x0000ACEC File Offset: 0x00008EEC
			internal void method_1()
			{
				uint num = 1U << this.int_1 + this.int_0;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)((uint)((UIntPtr)num2))].method_1();
				}
			}

			// Token: 0x06000096 RID: 150 RVA: 0x0000AD3C File Offset: 0x00008F3C
			internal uint method_2(uint uint_1, byte byte_0)
			{
				return ((uint_1 & this.uint_0) << this.int_1) + (uint)(byte_0 >> 8 - this.int_1);
			}

			// Token: 0x06000097 RID: 151 RVA: 0x0000AD70 File Offset: 0x00008F70
			internal byte method_3(Class0 class0_0, uint uint_1, byte byte_0)
			{
				return this.struct2_0[(int)((uint)((UIntPtr)this.method_2(uint_1, byte_0)))].method_2(class0_0);
			}

			// Token: 0x06000098 RID: 152 RVA: 0x0000ADA8 File Offset: 0x00008FA8
			internal byte method_4(Class0 class0_0, uint uint_1, byte byte_0, byte byte_1)
			{
				return this.struct2_0[(int)((uint)((UIntPtr)this.method_2(uint_1, byte_0)))].method_3(class0_0, byte_1);
			}

			// Token: 0x06000099 RID: 153 RVA: 0x0000218C File Offset: 0x0000038C
			internal Class3()
			{
			}

			// Token: 0x04000075 RID: 117
			internal Class1.Class3.Struct2[] struct2_0;

			// Token: 0x04000076 RID: 118
			internal int int_0;

			// Token: 0x04000077 RID: 119
			internal int int_1;

			// Token: 0x04000078 RID: 120
			internal uint uint_0;

			// Token: 0x0200002A RID: 42
			internal struct Struct2
			{
				// Token: 0x060000CC RID: 204 RVA: 0x0000BD06 File Offset: 0x00009F06
				internal void method_0()
				{
					this.struct0_0 = new Struct0[768];
				}

				// Token: 0x060000CD RID: 205 RVA: 0x0000BD1C File Offset: 0x00009F1C
				internal void method_1()
				{
					for (int i = 0; i < 768; i++)
					{
						this.struct0_0[i].method_0();
					}
				}

				// Token: 0x060000CE RID: 206 RVA: 0x0000BD54 File Offset: 0x00009F54
				internal byte method_2(Class0 class0_0)
				{
					uint num = 1U;
					do
					{
						num = (num << 1 | this.struct0_0[(int)((uint)((UIntPtr)num))].method_1(class0_0));
					}
					while (num < 256U);
					return (byte)num;
				}

				// Token: 0x060000CF RID: 207 RVA: 0x0000BD9C File Offset: 0x00009F9C
				internal byte method_3(Class0 class0_0, byte byte_0)
				{
					uint num = 1U;
					for (;;)
					{
						uint num2 = (uint)(byte_0 >> 7 & 1);
						byte_0 = (byte)(byte_0 << 1);
						uint num3 = this.struct0_0[(int)((uint)((UIntPtr)((1U + num2 << 8) + num)))].method_1(class0_0);
						num = (num << 1 | num3);
						bool flag = num2 != num3;
						bool flag3 = flag;
						if (flag3)
						{
							break;
						}
						bool flag2 = num >= 256U;
						bool flag4 = flag2;
						if (flag4)
						{
							goto Block_2;
						}
					}
					while (num < 256U)
					{
						num = (num << 1 | this.struct0_0[(int)((uint)((UIntPtr)num))].method_1(class0_0));
					}
					Block_2:
					return (byte)num;
				}

				// Token: 0x040000A7 RID: 167
				internal Struct0[] struct0_0;
			}
		}
	}
}
