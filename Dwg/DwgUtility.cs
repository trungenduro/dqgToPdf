// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.DwgUtility
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace dqgToPdf.Dwg
{
  public static class DwgUtility
  {
    public static long fuck { get; set; }

    public static byte[] decompress(byte[] compressedBytes, int numDecompressedBytes)
    {
      byte[] numArray1 = new byte[numDecompressedBytes];
      int index1 = 0;
      int length = 0;
      int literalLength = DwgUtility.getLiteralLength(ref index1, compressedBytes);
      for (int index2 = 0; index2 < literalLength; ++index2)
        numArray1[length++] = compressedBytes[index1++];
      CompressionOpcode opcodes;
      while ((opcodes = DwgUtility.getOpcodes(ref index1, compressedBytes)) != null)
      {
        int num = length - 1;
        for (int index2 = 0; index2 < opcodes.CompressedBytes; ++index2)
          numArray1[length++] = numArray1[num - opcodes.CompOffset + index2 % (opcodes.CompOffset + 1)];
        for (int index2 = 0; index2 < opcodes.LitCount; ++index2)
          numArray1[length++] = compressedBytes[index1++];
      }
      if (numArray1.Length > length)
      {
        byte[] numArray2 = new byte[length];
        for (int index2 = 0; index2 < length; ++index2)
          numArray2[index2] = numArray1[index2];
        numArray1 = numArray2;
      }
      return numArray1;
    }

    private static int getLiteralLength(ref int index, byte[] compresseddata)
    {
      int num1 = (int) compresseddata[index++];
      if (num1 == 0)
      {
        int num2 = 15;
        int num3;
        while (true)
        {
          byte[] numArray = compresseddata;
          int index1 = index++;
          if ((num3 = (int) numArray[index1]) == 0)
            num2 += (int) byte.MaxValue;
          else
            break;
        }
        return num2 + (num3 + 3);
      }
      if (num1 < 16)
        return num1 + 3;
      --index;
      return -1;
    }

    private static CompressionOpcode getOpcodes(
      ref int index,
      byte[] compresseddata)
    {
      CompressionOpcode compressionOpcode = new CompressionOpcode();
      int num1 = (int) compresseddata[index++];
      compressionOpcode.opcode1 = (byte) num1;
      switch (num1)
      {
        case 16:
          compressionOpcode.CompressedBytes = DwgUtility.getLongCompressionOffset(ref index, compresseddata) + 9;
          int num2 = (int) compresseddata[index++];
          compressionOpcode.CompOffset = (num2 >> 2 | (int) compresseddata[index++] << 6) + 16383;
          int num3 = num2 & 3;
          compressionOpcode.LitCount = num3 != 0 ? num3 : DwgUtility.getLiteralLength(ref index, compresseddata);
          break;
        case 17:
          return (CompressionOpcode) null;
        default:
          if (num1 >= 18 && num1 <= 31)
          {
            compressionOpcode.CompressedBytes = (num1 & 15) + 2;
            int num4 = (int) compresseddata[index++];
            compressionOpcode.CompOffset = (num4 >> 2 | (int) compresseddata[index++] << 6) + 16383;
            int num5 = num4 & 3;
            compressionOpcode.LitCount = num5 != 0 ? num5 : DwgUtility.getLiteralLength(ref index, compresseddata);
            break;
          }
          if (num1 == 32)
          {
            compressionOpcode.CompressedBytes = DwgUtility.getLongCompressionOffset(ref index, compresseddata) + 33;
            int num4 = (int) compresseddata[index++];
            compressionOpcode.CompOffset = num4 >> 2 | (int) compresseddata[index++] << 6;
            int num5 = num4 & 3;
            compressionOpcode.LitCount = num5 != 0 ? num5 : DwgUtility.getLiteralLength(ref index, compresseddata);
            break;
          }
          if (num1 >= 33 && num1 <= 63)
          {
            compressionOpcode.CompressedBytes = num1 - 30;
            int num4 = (int) compresseddata[index++];
            compressionOpcode.CompOffset = num4 >> 2 | (int) compresseddata[index++] << 6;
            int num5 = num4 & 3;
            compressionOpcode.LitCount = num5 != 0 ? num5 : DwgUtility.getLiteralLength(ref index, compresseddata);
            break;
          }
          if (num1 < 64 || num1 > (int) byte.MaxValue)
            throw new Exception();
          compressionOpcode.CompressedBytes = ((num1 & 240) >> 4) - 1;
          int num6 = (int) compresseddata[index++];
          compressionOpcode.opcode2 = (byte) num6;
          compressionOpcode.CompOffset = num6 << 2 | (num1 & 12) >> 2;
          int num7 = num1 & 3;
          compressionOpcode.LitCount = num7 != 0 ? num7 : DwgUtility.getLiteralLength(ref index, compresseddata);
          break;
      }
      return compressionOpcode;
    }

    private static int getLongCompressionOffset(ref int index, byte[] compresseddata)
    {
      int num1 = 0;
      byte num2;
      while (true)
      {
        byte[] numArray = compresseddata;
        int index1 = index++;
        if ((num2 = numArray[index1]) == (byte) 0)
          num1 += (int) byte.MaxValue;
        else
          break;
      }
      return num1 + (int) num2;
    }

    public static byte[] DecompressFor2007(byte[] compressedBytes, int numDecompressedBytes)
    {
      byte[] dstBuf = new byte[numDecompressedBytes];
      int num = (int) DwgUtility.CopyDecompressedChunks(compressedBytes, 0U, (uint) compressedBytes.Length, dstBuf, 0U);
      return dstBuf;
    }

    private static uint ReadLiteralLengthFor2007(BinaryReader br, uint opCode)
    {
      uint num1 = opCode + 8U;
      if (num1 == 23U)
      {
        uint num2 = (uint) br.ReadByte();
        num1 += num2;
        if (num2 == (uint) byte.MaxValue)
        {
          uint num3;
          do
          {
            num3 = (uint) br.ReadByte() | (uint) br.ReadByte() << 8;
            num1 += num3;
          }
          while (num3 == (uint) ushort.MaxValue);
        }
      }
      return num1;
    }

    private static void ReadInstructions(
      byte[] srcBuf,
      uint srcIndex,
      ref byte opCode,
      out uint sourceOffset,
      out uint length)
    {
      switch ((int) opCode >> 4)
      {
        case 0:
          length = (uint) (((int) opCode & 15) + 19);
          sourceOffset = (uint) srcBuf[(int) srcIndex++];
          opCode = srcBuf[(int) srcIndex++];
          length = (uint) ((int) opCode >> 3 & 16) + length;
          sourceOffset = (uint) ((((int) opCode & 120) << 5) + 1) + sourceOffset;
          break;
        case 1:
          length = (uint) (((int) opCode & 15) + 3);
          sourceOffset = (uint) srcBuf[(int) srcIndex++];
          opCode = srcBuf[(int) srcIndex++];
          sourceOffset = (uint) ((((int) opCode & 248) << 5) + 1) + sourceOffset;
          break;
        case 2:
          sourceOffset = (uint) srcBuf[(int) srcIndex++];
          sourceOffset = (uint) ((int) srcBuf[(int) srcIndex++] << 8 & 65280) | sourceOffset;
          length = (uint) opCode & 7U;
          if (((int) opCode & 8) == 0)
          {
            opCode = srcBuf[(int) srcIndex++];
            length = ((uint) opCode & 248U) + length;
            break;
          }
          ++sourceOffset;
          length = ((uint) srcBuf[(int) srcIndex++] << 3) + length;
          opCode = srcBuf[(int) srcIndex++];
          length = (uint) ((((int) opCode & 248) << 8) + (int) length + 256);
          break;
        default:
          length = (uint) opCode >> 4;
          sourceOffset = (uint) opCode & 15U;
          opCode = srcBuf[(int) srcIndex++];
          sourceOffset = (uint) ((ulong) (((int) opCode & 248) << 1) + (ulong) sourceOffset) + 1U;
          break;
      }
    }

    private static uint CopyDecompressedChunks(
      byte[] srcBuf,
      uint srcIndex,
      uint compressedEndIndexPlusOne,
      byte[] dstBuf,
      uint outputIndex)
    {
      int num1 = 0;
      uint length = 0;
      byte[] numArray = srcBuf;
      int index1 = num1;
      int num2 = index1 + 1;
      byte opCode = numArray[index1];
      int index2 = num2 + 1;
      uint sourceOffset;
      DwgUtility.ReadInstructions(srcBuf, srcIndex, ref opCode, out sourceOffset, out length);
      while (true)
      {
        DwgUtility.CopyBytes(dstBuf, outputIndex, length, sourceOffset);
        outputIndex += length;
        length = (uint) opCode & 7U;
        if (length == 0U && (long) index2 < (long) compressedEndIndexPlusOne)
        {
          opCode = srcBuf[index2];
          ++index2;
          if ((int) opCode >> 4 != 0)
          {
            if ((int) opCode >> 4 == 15)
              opCode &= (byte) 15;
            DwgUtility.ReadInstructions(srcBuf, srcIndex, ref opCode, out sourceOffset, out length);
          }
          else
            break;
        }
        else
          break;
      }
      return outputIndex;
    }

    private static void CopyBytes(byte[] dstBuf, uint outputIndex, uint length, uint sourceOffset)
    {
      uint num;
      for (; length > 0U; length -= num)
      {
        num = length > 32U ? 32U : length;
        switch (num)
        {
          case 1:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 2:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 3:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 2);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 4:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 2);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 3);
            break;
          case 5:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 4);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 0);
            break;
          case 6:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 5);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 7:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 2U, 5);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 8:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 0);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 4);
            break;
          case 9:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 8);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 0);
            break;
          case 10:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 9);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 11:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 2U, 9);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 12:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 8);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 0);
            break;
          case 13:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 12);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 8);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 0);
            break;
          case 14:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 13);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 9);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 15:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 2U, 13);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 9);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 16:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 8);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 0);
            break;
          case 17:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 9);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 8);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 0);
            break;
          case 18:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 17);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 1);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 0);
            break;
          case 19:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 3U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 20:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 21:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 20);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 22:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 2U, 20);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 23:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 3U, 20);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 24:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 25:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 17);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 26:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 25);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 17);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 27:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 2U, 25);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 17);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 28:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 24);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 29:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 28);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 24);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 30:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 2U, 28);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 24);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
          case 31:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 1U, 30);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 4U, 26);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 8U, 18);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 2);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 2U, 0);
            break;
          case 32:
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 16);
            DwgUtility.CopyByteBlock(dstBuf, ref outputIndex, sourceOffset, 16U, 0);
            break;
        }
        sourceOffset += num;
      }
    }

    private static void CopyByteBlock(
      byte[] dstBuf,
      ref uint outputIndex,
      uint sourceOffset,
      uint count,
      int index)
    {
      for (int index1 = 0; (long) index1 < (long) count; ++index1)
        dstBuf[(int) outputIndex++] = dstBuf[(long) sourceOffset + (long) index + (long) index1];
    }

    public static int ReadModuleChars(BinaryReader br, bool noNegation = false, List<byte> bl = null)
    {
      if (bl == null)
        bl = new List<byte>();
      byte num;
      do
      {
        num = br.ReadByte();
        bl.Add(num);
      }
      while (((int) num & 128) != 0);
      return DwgUtility.DecodeModuleChars(bl, noNegation);
    }

    public static int DecodeModuleChars(List<byte> bytes, bool noNegation = false)
    {
      bool flag = ((int) bytes[bytes.Count - 1] & 64) > 0;
      if (!noNegation)
        bytes[bytes.Count - 1] = (byte) ((uint) bytes[bytes.Count - 1] & 63U);
      int num1 = 0;
      for (int index = 0; index < bytes.Count; ++index)
      {
        int num2 = (int) bytes[index] & (int) sbyte.MaxValue;
        int num3 = 7 * index;
        num1 += num2 << num3;
      }
      return !(!noNegation & flag) ? num1 : -num1;
    }

    public static int DecodModuleShorts(List<ushort> shorts)
    {
      int num1 = 0;
      for (int index = 0; index < shorts.Count; ++index)
      {
        int num2 = (int) shorts[index] & (int) short.MaxValue;
        int num3 = 15 * index;
        num1 += num2 << num3;
      }
      return num1;
    }

    public static int readModuleShorts(BinaryReader br, List<ushort> usl = null)
    {
      if (usl == null)
        usl = new List<ushort>();
      ushort num;
      do
      {
        num = br.ReadUInt16();
        usl.Add(num);
      }
      while (((int) num & 32768) != 0);
      return DwgUtility.DecodModuleShorts(usl);
    }

    public static void DumpByteArray(byte[] ba, string filename)
    {
      using (BinaryWriter binaryWriter = new BinaryWriter((Stream) new FileStream(filename, FileMode.CreateNew)))
        binaryWriter.Write(ba);
    }
  }
}
