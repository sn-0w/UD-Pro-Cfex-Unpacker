using System;
using System.IO;

namespace Krawk_Unpacker.Protections
{
	// Token: 0x02000010 RID: 16
	internal static class Lzma
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00005060 File Offset: 0x00003260
		public static byte[] Decompress(byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream(data);
			Lzma.LzmaDecoder lzmaDecoder = new Lzma.LzmaDecoder();
			byte[] array = new byte[5];
			memoryStream.Read(array, 0, 5);
			lzmaDecoder.SetDecoderProperties(array);
			long num = 0L;
			for (int i = 0; i < 8; i++)
			{
				int num2 = memoryStream.ReadByte();
				num |= (long)((long)((ulong)((byte)num2)) << 8 * i);
			}
			byte[] array2 = new byte[num];
			MemoryStream outStream = new MemoryStream(array2, true);
			long inSize = memoryStream.Length - 13L;
			lzmaDecoder.Code(memoryStream, outStream, inSize, num);
			return array2;
		}

		// Token: 0x04000031 RID: 49
		private const uint kAlignTableSize = 16U;

		// Token: 0x04000032 RID: 50
		private const uint kEndPosModelIndex = 14U;

		// Token: 0x04000033 RID: 51
		private const uint kMatchMinLen = 2U;

		// Token: 0x04000034 RID: 52
		private const int kNumAlignBits = 4;

		// Token: 0x04000035 RID: 53
		private const uint kNumFullDistances = 128U;

		// Token: 0x04000036 RID: 54
		private const int kNumHighLenBits = 8;

		// Token: 0x04000037 RID: 55
		private const uint kNumLenToPosStates = 4U;

		// Token: 0x04000038 RID: 56
		private const int kNumLowLenBits = 3;

		// Token: 0x04000039 RID: 57
		private const uint kNumLowLenSymbols = 8U;

		// Token: 0x0400003A RID: 58
		private const int kNumMidLenBits = 3;

		// Token: 0x0400003B RID: 59
		private const uint kNumMidLenSymbols = 8U;

		// Token: 0x0400003C RID: 60
		private const int kNumPosSlotBits = 6;

		// Token: 0x0400003D RID: 61
		private const int kNumPosStatesBitsMax = 4;

		// Token: 0x0400003E RID: 62
		private const uint kNumPosStatesMax = 16U;

		// Token: 0x0400003F RID: 63
		private const uint kNumStates = 12U;

		// Token: 0x04000040 RID: 64
		private const uint kStartPosModelIndex = 4U;

		// Token: 0x0200001F RID: 31
		private struct BitDecoder
		{
			// Token: 0x0600009A RID: 154 RVA: 0x0000ADDF File Offset: 0x00008FDF
			public void Init()
			{
				this.Prob = 1024U;
			}

			// Token: 0x0600009B RID: 155 RVA: 0x0000ADF0 File Offset: 0x00008FF0
			public uint Decode(Lzma.Decoder rangeDecoder)
			{
				uint num = (rangeDecoder.Range >> 11) * this.Prob;
				bool flag = rangeDecoder.Code < num;
				bool flag4 = flag;
				uint result;
				if (flag4)
				{
					rangeDecoder.Range = num;
					this.Prob += 2048U - this.Prob >> 5;
					bool flag2 = rangeDecoder.Range < 16777216U;
					bool flag5 = flag2;
					if (flag5)
					{
						rangeDecoder.Code = (rangeDecoder.Code << 8 | (uint)((byte)rangeDecoder.Stream.ReadByte()));
						rangeDecoder.Range <<= 8;
					}
					result = 0U;
				}
				else
				{
					rangeDecoder.Range -= num;
					rangeDecoder.Code -= num;
					this.Prob -= this.Prob >> 5;
					bool flag3 = rangeDecoder.Range < 16777216U;
					bool flag6 = flag3;
					if (flag6)
					{
						rangeDecoder.Code = (rangeDecoder.Code << 8 | (uint)((byte)rangeDecoder.Stream.ReadByte()));
						rangeDecoder.Range <<= 8;
					}
					result = 1U;
				}
				return result;
			}

			// Token: 0x04000079 RID: 121
			public const int kNumBitModelTotalBits = 11;

			// Token: 0x0400007A RID: 122
			public const uint kBitModelTotal = 2048U;

			// Token: 0x0400007B RID: 123
			private const int kNumMoveBits = 5;

			// Token: 0x0400007C RID: 124
			private uint Prob;
		}

		// Token: 0x02000020 RID: 32
		private struct BitTreeDecoder
		{
			// Token: 0x0600009C RID: 156 RVA: 0x0000AF06 File Offset: 0x00009106
			public BitTreeDecoder(int numBitLevels)
			{
				this.NumBitLevels = numBitLevels;
				this.Models = new Lzma.BitDecoder[1 << numBitLevels];
			}

			// Token: 0x0600009D RID: 157 RVA: 0x0000AF24 File Offset: 0x00009124
			public void Init()
			{
				uint num = 1U;
				while ((ulong)num < 1UL << (this.NumBitLevels & 31))
				{
					this.Models[(int)num].Init();
					num += 1U;
				}
			}

			// Token: 0x0600009E RID: 158 RVA: 0x0000AF68 File Offset: 0x00009168
			public uint Decode(Lzma.Decoder rangeDecoder)
			{
				uint num = 1U;
				for (int i = this.NumBitLevels; i > 0; i--)
				{
					num = (num << 1) + this.Models[(int)num].Decode(rangeDecoder);
				}
				return num - (1U << this.NumBitLevels);
			}

			// Token: 0x0600009F RID: 159 RVA: 0x0000AFB8 File Offset: 0x000091B8
			public uint ReverseDecode(Lzma.Decoder rangeDecoder)
			{
				uint num = 1U;
				uint num2 = 0U;
				for (int i = 0; i < this.NumBitLevels; i++)
				{
					uint num3 = this.Models[(int)num].Decode(rangeDecoder);
					num <<= 1;
					num += num3;
					num2 |= num3 << i;
				}
				return num2;
			}

			// Token: 0x060000A0 RID: 160 RVA: 0x0000B010 File Offset: 0x00009210
			public static uint ReverseDecode(Lzma.BitDecoder[] Models, uint startIndex, Lzma.Decoder rangeDecoder, int NumBitLevels)
			{
				uint num = 1U;
				uint num2 = 0U;
				for (int i = 0; i < NumBitLevels; i++)
				{
					uint num3 = Models[(int)(startIndex + num)].Decode(rangeDecoder);
					num <<= 1;
					num += num3;
					num2 |= num3 << i;
				}
				return num2;
			}

			// Token: 0x0400007D RID: 125
			private readonly Lzma.BitDecoder[] Models;

			// Token: 0x0400007E RID: 126
			private readonly int NumBitLevels;
		}

		// Token: 0x02000021 RID: 33
		private class Decoder
		{
			// Token: 0x060000A1 RID: 161 RVA: 0x0000B060 File Offset: 0x00009260
			public uint DecodeDirectBits(int numTotalBits)
			{
				uint num = this.Range;
				uint num2 = this.Code;
				uint num3 = 0U;
				for (int i = numTotalBits; i > 0; i--)
				{
					num >>= 1;
					uint num4 = num2 - num >> 31;
					num2 -= (num & num4 - 1U);
					num3 = (num3 << 1 | 1U - num4);
					bool flag = num < 16777216U;
					bool flag2 = flag;
					if (flag2)
					{
						num2 = (num2 << 8 | (uint)((byte)this.Stream.ReadByte()));
						num <<= 8;
					}
				}
				this.Range = num;
				this.Code = num2;
				return num3;
			}

			// Token: 0x060000A2 RID: 162 RVA: 0x0000B0F0 File Offset: 0x000092F0
			public void Init(Stream stream)
			{
				this.Stream = stream;
				this.Code = 0U;
				this.Range = uint.MaxValue;
				for (int i = 0; i < 5; i++)
				{
					this.Code = (this.Code << 8 | (uint)((byte)this.Stream.ReadByte()));
				}
			}

			// Token: 0x060000A3 RID: 163 RVA: 0x0000B140 File Offset: 0x00009340
			public void Normalize()
			{
				while (this.Range < 16777216U)
				{
					this.Code = (this.Code << 8 | (uint)((byte)this.Stream.ReadByte()));
					this.Range <<= 8;
				}
			}

			// Token: 0x060000A4 RID: 164 RVA: 0x0000B18C File Offset: 0x0000938C
			public void ReleaseStream()
			{
				this.Stream = null;
			}

			// Token: 0x0400007F RID: 127
			public uint Code;

			// Token: 0x04000080 RID: 128
			public const uint kTopValue = 16777216U;

			// Token: 0x04000081 RID: 129
			public uint Range;

			// Token: 0x04000082 RID: 130
			public Stream Stream;
		}

		// Token: 0x02000022 RID: 34
		private class LzmaDecoder
		{
			// Token: 0x060000A6 RID: 166 RVA: 0x0000B198 File Offset: 0x00009398
			public LzmaDecoder()
			{
				int num = 0;
				while ((long)num < 4L)
				{
					this.m_PosSlotDecoder[num] = new Lzma.BitTreeDecoder(6);
					num++;
				}
			}

			// Token: 0x060000A7 RID: 167 RVA: 0x0000B294 File Offset: 0x00009494
			public void Code(Stream inStream, Stream outStream, long inSize, long outSize)
			{
				this.Init(inStream, outStream);
				Lzma.State state = default(Lzma.State);
				state.Init();
				uint num = 0U;
				uint num2 = 0U;
				uint num3 = 0U;
				uint num4 = 0U;
				ulong num5 = 0UL;
				bool flag = num5 < (ulong)outSize;
				bool flag12 = flag;
				if (flag12)
				{
					this.m_IsMatchDecoders[(int)((int)state.Index << 4)].Decode(this.m_RangeDecoder);
					state.UpdateChar();
					byte b = this.m_LiteralDecoder.DecodeNormal(this.m_RangeDecoder, 0U, 0);
					this.m_OutWindow.PutByte(b);
					num5 += 1UL;
				}
				while (num5 < (ulong)outSize)
				{
					uint num6 = (uint)num5 & this.m_PosStateMask;
					bool flag2 = this.m_IsMatchDecoders[(int)((state.Index << 4) + num6)].Decode(this.m_RangeDecoder) == 0U;
					bool flag13 = flag2;
					if (flag13)
					{
						byte @byte = this.m_OutWindow.GetByte(0U);
						bool flag3 = !state.IsCharState();
						bool flag14 = flag3;
						byte b2;
						if (flag14)
						{
							b2 = this.m_LiteralDecoder.DecodeWithMatchByte(this.m_RangeDecoder, (uint)num5, @byte, this.m_OutWindow.GetByte(num));
						}
						else
						{
							b2 = this.m_LiteralDecoder.DecodeNormal(this.m_RangeDecoder, (uint)num5, @byte);
						}
						this.m_OutWindow.PutByte(b2);
						state.UpdateChar();
						num5 += 1UL;
					}
					else
					{
						bool flag4 = this.m_IsRepDecoders[(int)state.Index].Decode(this.m_RangeDecoder) == 1U;
						bool flag15 = flag4;
						uint num8;
						if (flag15)
						{
							bool flag5 = this.m_IsRepG0Decoders[(int)state.Index].Decode(this.m_RangeDecoder) == 0U;
							bool flag16 = flag5;
							if (flag16)
							{
								bool flag6 = this.m_IsRep0LongDecoders[(int)((state.Index << 4) + num6)].Decode(this.m_RangeDecoder) == 0U;
								bool flag17 = flag6;
								if (flag17)
								{
									state.UpdateShortRep();
									this.m_OutWindow.PutByte(this.m_OutWindow.GetByte(num));
									num5 += 1UL;
									continue;
								}
							}
							else
							{
								bool flag7 = this.m_IsRepG1Decoders[(int)state.Index].Decode(this.m_RangeDecoder) == 0U;
								bool flag18 = flag7;
								uint num7;
								if (flag18)
								{
									num7 = num2;
								}
								else
								{
									bool flag8 = this.m_IsRepG2Decoders[(int)state.Index].Decode(this.m_RangeDecoder) == 0U;
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
							num8 = this.m_RepLenDecoder.Decode(this.m_RangeDecoder, num6) + 2U;
							state.UpdateRep();
						}
						else
						{
							num4 = num3;
							num3 = num2;
							num2 = num;
							num8 = 2U + this.m_LenDecoder.Decode(this.m_RangeDecoder, num6);
							state.UpdateMatch();
							uint num9 = this.m_PosSlotDecoder[(int)Lzma.LzmaDecoder.GetLenToPosState(num8)].Decode(this.m_RangeDecoder);
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
									num += Lzma.BitTreeDecoder.ReverseDecode(this.m_PosDecoders, num - num9 - 1U, this.m_RangeDecoder, num10);
								}
								else
								{
									num += this.m_RangeDecoder.DecodeDirectBits(num10 - 4) << 4;
									num += this.m_PosAlignDecoder.ReverseDecode(this.m_RangeDecoder);
								}
							}
							else
							{
								num = num9;
							}
						}
						bool flag11 = ((ulong)num >= num5 || num >= this.m_DictionarySizeCheck) && num == uint.MaxValue;
						bool flag22 = flag11;
						if (flag22)
						{
							break;
						}
						this.m_OutWindow.CopyBlock(num, num8);
						num5 += (ulong)num8;
					}
				}
				this.m_OutWindow.Flush();
				this.m_OutWindow.ReleaseStream();
				this.m_RangeDecoder.ReleaseStream();
			}

			// Token: 0x060000A8 RID: 168 RVA: 0x0000B688 File Offset: 0x00009888
			private static uint GetLenToPosState(uint len)
			{
				len -= 2U;
				bool flag = len < 4U;
				bool flag2 = flag;
				uint result;
				if (flag2)
				{
					result = len;
				}
				else
				{
					result = 3U;
				}
				return result;
			}

			// Token: 0x060000A9 RID: 169 RVA: 0x0000B6B4 File Offset: 0x000098B4
			private void Init(Stream inStream, Stream outStream)
			{
				this.m_RangeDecoder.Init(inStream);
				this.m_OutWindow.Init(outStream, this._solid);
				for (uint num = 0U; num < 12U; num += 1U)
				{
					for (uint num2 = 0U; num2 <= this.m_PosStateMask; num2 += 1U)
					{
						uint num3 = (num << 4) + num2;
						this.m_IsMatchDecoders[(int)num3].Init();
						this.m_IsRep0LongDecoders[(int)num3].Init();
					}
					this.m_IsRepDecoders[(int)num].Init();
					this.m_IsRepG0Decoders[(int)num].Init();
					this.m_IsRepG1Decoders[(int)num].Init();
					this.m_IsRepG2Decoders[(int)num].Init();
				}
				this.m_LiteralDecoder.Init();
				for (uint num4 = 0U; num4 < 4U; num4 += 1U)
				{
					this.m_PosSlotDecoder[(int)num4].Init();
				}
				for (uint num5 = 0U; num5 < 114U; num5 += 1U)
				{
					this.m_PosDecoders[(int)num5].Init();
				}
				this.m_LenDecoder.Init();
				this.m_RepLenDecoder.Init();
				this.m_PosAlignDecoder.Init();
			}

			// Token: 0x060000AA RID: 170 RVA: 0x0000B810 File Offset: 0x00009A10
			public void SetDecoderProperties(byte[] properties)
			{
				int lc = (int)(properties[0] % 9);
				int num = (int)(properties[0] / 9);
				int lp = num % 5;
				int posBitsProperties = num / 5;
				uint num2 = 0U;
				for (int i = 0; i < 4; i++)
				{
					num2 += (uint)((uint)properties[1 + i] << i * 8);
				}
				this.SetDictionarySize(num2);
				this.SetLiteralProperties(lp, lc);
				this.SetPosBitsProperties(posBitsProperties);
			}

			// Token: 0x060000AB RID: 171 RVA: 0x0000B87C File Offset: 0x00009A7C
			private void SetDictionarySize(uint dictionarySize)
			{
				bool flag = this.m_DictionarySize != dictionarySize;
				bool flag2 = flag;
				if (flag2)
				{
					this.m_DictionarySize = dictionarySize;
					this.m_DictionarySizeCheck = Math.Max(this.m_DictionarySize, 1U);
					uint windowSize = Math.Max(this.m_DictionarySizeCheck, 4096U);
					this.m_OutWindow.Create(windowSize);
				}
			}

			// Token: 0x060000AC RID: 172 RVA: 0x0000B8D5 File Offset: 0x00009AD5
			private void SetLiteralProperties(int lp, int lc)
			{
				this.m_LiteralDecoder.Create(lp, lc);
			}

			// Token: 0x060000AD RID: 173 RVA: 0x0000B8E8 File Offset: 0x00009AE8
			private void SetPosBitsProperties(int pb)
			{
				uint num = 1U << pb;
				this.m_LenDecoder.Create(num);
				this.m_RepLenDecoder.Create(num);
				this.m_PosStateMask = num - 1U;
			}

			// Token: 0x04000083 RID: 131
			private bool _solid = false;

			// Token: 0x04000084 RID: 132
			private uint m_DictionarySize = uint.MaxValue;

			// Token: 0x04000085 RID: 133
			private uint m_DictionarySizeCheck;

			// Token: 0x04000086 RID: 134
			private readonly Lzma.BitDecoder[] m_IsMatchDecoders = new Lzma.BitDecoder[192];

			// Token: 0x04000087 RID: 135
			private readonly Lzma.BitDecoder[] m_IsRep0LongDecoders = new Lzma.BitDecoder[192];

			// Token: 0x04000088 RID: 136
			private readonly Lzma.BitDecoder[] m_IsRepDecoders = new Lzma.BitDecoder[12];

			// Token: 0x04000089 RID: 137
			private readonly Lzma.BitDecoder[] m_IsRepG0Decoders = new Lzma.BitDecoder[12];

			// Token: 0x0400008A RID: 138
			private readonly Lzma.BitDecoder[] m_IsRepG1Decoders = new Lzma.BitDecoder[12];

			// Token: 0x0400008B RID: 139
			private readonly Lzma.BitDecoder[] m_IsRepG2Decoders = new Lzma.BitDecoder[12];

			// Token: 0x0400008C RID: 140
			private readonly Lzma.LzmaDecoder.LenDecoder m_LenDecoder = new Lzma.LzmaDecoder.LenDecoder();

			// Token: 0x0400008D RID: 141
			private readonly Lzma.LzmaDecoder.LiteralDecoder m_LiteralDecoder = new Lzma.LzmaDecoder.LiteralDecoder();

			// Token: 0x0400008E RID: 142
			private readonly Lzma.OutWindow m_OutWindow = new Lzma.OutWindow();

			// Token: 0x0400008F RID: 143
			private Lzma.BitTreeDecoder m_PosAlignDecoder = new Lzma.BitTreeDecoder(4);

			// Token: 0x04000090 RID: 144
			private readonly Lzma.BitDecoder[] m_PosDecoders = new Lzma.BitDecoder[114];

			// Token: 0x04000091 RID: 145
			private readonly Lzma.BitTreeDecoder[] m_PosSlotDecoder = new Lzma.BitTreeDecoder[4];

			// Token: 0x04000092 RID: 146
			private uint m_PosStateMask;

			// Token: 0x04000093 RID: 147
			private readonly Lzma.Decoder m_RangeDecoder = new Lzma.Decoder();

			// Token: 0x04000094 RID: 148
			private readonly Lzma.LzmaDecoder.LenDecoder m_RepLenDecoder = new Lzma.LzmaDecoder.LenDecoder();

			// Token: 0x0200002B RID: 43
			private class LenDecoder
			{
				// Token: 0x060000D0 RID: 208 RVA: 0x0000BE50 File Offset: 0x0000A050
				public void Create(uint numPosStates)
				{
					for (uint num = this.m_NumPosStates; num < numPosStates; num += 1U)
					{
						this.m_LowCoder[(int)num] = new Lzma.BitTreeDecoder(3);
						this.m_MidCoder[(int)num] = new Lzma.BitTreeDecoder(3);
					}
					this.m_NumPosStates = numPosStates;
				}

				// Token: 0x060000D1 RID: 209 RVA: 0x0000BEA0 File Offset: 0x0000A0A0
				public uint Decode(Lzma.Decoder rangeDecoder, uint posState)
				{
					bool flag = this.m_Choice.Decode(rangeDecoder) == 0U;
					bool flag3 = flag;
					uint result;
					if (flag3)
					{
						result = this.m_LowCoder[(int)posState].Decode(rangeDecoder);
					}
					else
					{
						uint num = 8U;
						bool flag2 = this.m_Choice2.Decode(rangeDecoder) == 0U;
						bool flag4 = flag2;
						if (flag4)
						{
							num += this.m_MidCoder[(int)posState].Decode(rangeDecoder);
						}
						else
						{
							num += 8U;
							num += this.m_HighCoder.Decode(rangeDecoder);
						}
						result = num;
					}
					return result;
				}

				// Token: 0x060000D2 RID: 210 RVA: 0x0000BF30 File Offset: 0x0000A130
				public void Init()
				{
					this.m_Choice.Init();
					for (uint num = 0U; num < this.m_NumPosStates; num += 1U)
					{
						this.m_LowCoder[(int)num].Init();
						this.m_MidCoder[(int)num].Init();
					}
					this.m_Choice2.Init();
					this.m_HighCoder.Init();
				}

				// Token: 0x040000A8 RID: 168
				private Lzma.BitDecoder m_Choice = default(Lzma.BitDecoder);

				// Token: 0x040000A9 RID: 169
				private Lzma.BitDecoder m_Choice2 = default(Lzma.BitDecoder);

				// Token: 0x040000AA RID: 170
				private Lzma.BitTreeDecoder m_HighCoder = new Lzma.BitTreeDecoder(8);

				// Token: 0x040000AB RID: 171
				private readonly Lzma.BitTreeDecoder[] m_LowCoder = new Lzma.BitTreeDecoder[16];

				// Token: 0x040000AC RID: 172
				private readonly Lzma.BitTreeDecoder[] m_MidCoder = new Lzma.BitTreeDecoder[16];

				// Token: 0x040000AD RID: 173
				private uint m_NumPosStates;
			}

			// Token: 0x0200002C RID: 44
			private class LiteralDecoder
			{
				// Token: 0x060000D4 RID: 212 RVA: 0x0000BFF4 File Offset: 0x0000A1F4
				public void Create(int numPosBits, int numPrevBits)
				{
					bool flag = this.m_Coders == null || this.m_NumPrevBits != numPrevBits || this.m_NumPosBits != numPosBits;
					bool flag2 = flag;
					if (flag2)
					{
						this.m_NumPosBits = numPosBits;
						this.m_PosMask = (1U << numPosBits) - 1U;
						this.m_NumPrevBits = numPrevBits;
						uint num = 1U << this.m_NumPrevBits + this.m_NumPosBits;
						this.m_Coders = new Lzma.LzmaDecoder.LiteralDecoder.Decoder2[num];
						for (uint num2 = 0U; num2 < num; num2 += 1U)
						{
							this.m_Coders[(int)num2].Create();
						}
					}
				}

				// Token: 0x060000D5 RID: 213 RVA: 0x0000C08C File Offset: 0x0000A28C
				public byte DecodeNormal(Lzma.Decoder rangeDecoder, uint pos, byte prevByte)
				{
					return this.m_Coders[(int)this.GetState(pos, prevByte)].DecodeNormal(rangeDecoder);
				}

				// Token: 0x060000D6 RID: 214 RVA: 0x0000C0B8 File Offset: 0x0000A2B8
				public byte DecodeWithMatchByte(Lzma.Decoder rangeDecoder, uint pos, byte prevByte, byte matchByte)
				{
					return this.m_Coders[(int)this.GetState(pos, prevByte)].DecodeWithMatchByte(rangeDecoder, matchByte);
				}

				// Token: 0x060000D7 RID: 215 RVA: 0x0000C0E8 File Offset: 0x0000A2E8
				private uint GetState(uint pos, byte prevByte)
				{
					return ((pos & this.m_PosMask) << this.m_NumPrevBits) + (uint)(prevByte >> 8 - this.m_NumPrevBits);
				}

				// Token: 0x060000D8 RID: 216 RVA: 0x0000C11C File Offset: 0x0000A31C
				public void Init()
				{
					uint num = 1U << this.m_NumPrevBits + this.m_NumPosBits;
					for (uint num2 = 0U; num2 < num; num2 += 1U)
					{
						this.m_Coders[(int)num2].Init();
					}
				}

				// Token: 0x040000AE RID: 174
				private Lzma.LzmaDecoder.LiteralDecoder.Decoder2[] m_Coders;

				// Token: 0x040000AF RID: 175
				private int m_NumPosBits;

				// Token: 0x040000B0 RID: 176
				private int m_NumPrevBits;

				// Token: 0x040000B1 RID: 177
				private uint m_PosMask;

				// Token: 0x0200002D RID: 45
				private struct Decoder2
				{
					// Token: 0x060000DA RID: 218 RVA: 0x0000C161 File Offset: 0x0000A361
					public void Create()
					{
						this.m_Decoders = new Lzma.BitDecoder[768];
					}

					// Token: 0x060000DB RID: 219 RVA: 0x0000C174 File Offset: 0x0000A374
					public void Init()
					{
						for (int i = 0; i < 768; i++)
						{
							this.m_Decoders[i].Init();
						}
					}

					// Token: 0x060000DC RID: 220 RVA: 0x0000C1AC File Offset: 0x0000A3AC
					public byte DecodeNormal(Lzma.Decoder rangeDecoder)
					{
						uint num = 1U;
						do
						{
							num = (num << 1 | this.m_Decoders[(int)num].Decode(rangeDecoder));
						}
						while (num < 256U);
						return (byte)num;
					}

					// Token: 0x060000DD RID: 221 RVA: 0x0000C1E8 File Offset: 0x0000A3E8
					public byte DecodeWithMatchByte(Lzma.Decoder rangeDecoder, byte matchByte)
					{
						uint num = 1U;
						for (;;)
						{
							uint num2 = (uint)(matchByte >> 7 & 1);
							matchByte = (byte)(matchByte << 1);
							uint num3 = this.m_Decoders[(int)((IntPtr)((long)((ulong)((1U + num2 << 8) + num))))].Decode(rangeDecoder);
							num = (num << 1 | num3);
							bool flag = num2 != num3;
							bool flag2 = flag;
							if (flag2)
							{
								break;
							}
							bool flag3 = num >= 256U;
							if (flag3)
							{
								goto Block_2;
							}
						}
						while (num < 256U)
						{
							num = (num << 1 | this.m_Decoders[(int)num].Decode(rangeDecoder));
						}
						Block_2:
						return (byte)num;
					}

					// Token: 0x040000B2 RID: 178
					private Lzma.BitDecoder[] m_Decoders;
				}
			}
		}

		// Token: 0x02000023 RID: 35
		private class OutWindow
		{
			// Token: 0x060000AE RID: 174 RVA: 0x0000B920 File Offset: 0x00009B20
			public void CopyBlock(uint distance, uint len)
			{
				uint num = this._pos - distance - 1U;
				bool flag = num >= this._windowSize;
				bool flag4 = flag;
				if (flag4)
				{
					num += this._windowSize;
				}
				while (len > 0U)
				{
					bool flag2 = num >= this._windowSize;
					bool flag5 = flag2;
					if (flag5)
					{
						num = 0U;
					}
					byte[] buffer = this._buffer;
					uint pos = this._pos;
					this._pos = pos + 1U;
					buffer[(int)pos] = this._buffer[(int)num++];
					bool flag3 = this._pos >= this._windowSize;
					bool flag6 = flag3;
					if (flag6)
					{
						this.Flush();
					}
					len -= 1U;
				}
			}

			// Token: 0x060000AF RID: 175 RVA: 0x0000B9D0 File Offset: 0x00009BD0
			public void Create(uint windowSize)
			{
				bool flag = this._windowSize != windowSize;
				bool flag2 = flag;
				if (flag2)
				{
					this._buffer = new byte[windowSize];
				}
				this._windowSize = windowSize;
				this._pos = 0U;
				this._streamPos = 0U;
			}

			// Token: 0x060000B0 RID: 176 RVA: 0x0000BA14 File Offset: 0x00009C14
			public void Flush()
			{
				uint num = this._pos - this._streamPos;
				bool flag = num > 0U;
				bool flag3 = flag;
				if (flag3)
				{
					this._stream.Write(this._buffer, (int)this._streamPos, (int)num);
					bool flag2 = this._pos >= this._windowSize;
					bool flag4 = flag2;
					if (flag4)
					{
						this._pos = 0U;
					}
					this._streamPos = this._pos;
				}
			}

			// Token: 0x060000B1 RID: 177 RVA: 0x0000BA84 File Offset: 0x00009C84
			public byte GetByte(uint distance)
			{
				uint num = this._pos - distance - 1U;
				bool flag = num >= this._windowSize;
				bool flag2 = flag;
				if (flag2)
				{
					num += this._windowSize;
				}
				return this._buffer[(int)num];
			}

			// Token: 0x060000B2 RID: 178 RVA: 0x0000BAC8 File Offset: 0x00009CC8
			public void Init(Stream stream, bool solid)
			{
				this.ReleaseStream();
				this._stream = stream;
				bool flag = !solid;
				bool flag2 = flag;
				if (flag2)
				{
					this._streamPos = 0U;
					this._pos = 0U;
				}
			}

			// Token: 0x060000B3 RID: 179 RVA: 0x0000BB00 File Offset: 0x00009D00
			public void PutByte(byte b)
			{
				byte[] buffer = this._buffer;
				uint pos = this._pos;
				this._pos = pos + 1U;
				buffer[(int)pos] = b;
				bool flag = this._pos >= this._windowSize;
				bool flag2 = flag;
				if (flag2)
				{
					this.Flush();
				}
			}

			// Token: 0x060000B4 RID: 180 RVA: 0x0000BB49 File Offset: 0x00009D49
			public void ReleaseStream()
			{
				this.Flush();
				this._stream = null;
				Buffer.BlockCopy(new byte[this._buffer.Length], 0, this._buffer, 0, this._buffer.Length);
			}

			// Token: 0x04000095 RID: 149
			private byte[] _buffer;

			// Token: 0x04000096 RID: 150
			private uint _pos;

			// Token: 0x04000097 RID: 151
			private Stream _stream;

			// Token: 0x04000098 RID: 152
			private uint _streamPos;

			// Token: 0x04000099 RID: 153
			private uint _windowSize;
		}

		// Token: 0x02000024 RID: 36
		private struct State
		{
			// Token: 0x060000B6 RID: 182 RVA: 0x0000BB7D File Offset: 0x00009D7D
			public void Init()
			{
				this.Index = 0U;
			}

			// Token: 0x060000B7 RID: 183 RVA: 0x0000BB88 File Offset: 0x00009D88
			public void UpdateChar()
			{
				bool flag = this.Index < 4U;
				bool flag3 = flag;
				if (flag3)
				{
					this.Index = 0U;
				}
				else
				{
					bool flag2 = this.Index < 10U;
					bool flag4 = flag2;
					if (flag4)
					{
						this.Index -= 3U;
					}
					else
					{
						this.Index -= 6U;
					}
				}
			}

			// Token: 0x060000B8 RID: 184 RVA: 0x0000BBE4 File Offset: 0x00009DE4
			public void UpdateMatch()
			{
				this.Index = ((this.Index < 7U) ? 7U : 10U);
			}

			// Token: 0x060000B9 RID: 185 RVA: 0x0000BBFB File Offset: 0x00009DFB
			public void UpdateRep()
			{
				this.Index = ((this.Index < 7U) ? 8U : 11U);
			}

			// Token: 0x060000BA RID: 186 RVA: 0x0000BC12 File Offset: 0x00009E12
			public void UpdateShortRep()
			{
				this.Index = ((this.Index < 7U) ? 9U : 11U);
			}

			// Token: 0x060000BB RID: 187 RVA: 0x0000BC2C File Offset: 0x00009E2C
			public bool IsCharState()
			{
				return this.Index < 7U;
			}

			// Token: 0x0400009A RID: 154
			public uint Index;
		}
	}
}
