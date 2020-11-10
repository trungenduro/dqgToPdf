// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.DwgBitArray
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dqgToPdf.Dwg
{
  public class DwgBitArray
  {
    private BitArray bitArray;
    public int bitindex;

    public DwgBitArray()
    {
    }

    public DwgBitArray(byte[] barr, int offset = 0)
    {
      this.bitArray = new BitArray(barr);
      this.bitindex = offset;
    }

    public void DumpAll(string filename)
    {
      using (FileStream fileStream = new FileStream(filename, FileMode.Create))
        this.DumpAll((Stream) fileStream);
    }

    public void DumpFromFirst(string filename)
    {
      int bitindex = this.bitindex;
      this.bitindex = 0;
      using (FileStream fileStream = new FileStream(filename, FileMode.Create))
        this.DumpAll((Stream) fileStream);
      this.bitindex = bitindex;
    }

    public int ReadMS()
    {
      List<ushort> shorts = new List<ushort>();
      ushort num;
      do
      {
        num = this.ReadURS();
        shorts.Add(num);
      }
      while (((int) num & 32768) != 0);
      return this.DecodModuleShorts(shorts);
    }

    public int DecodModuleShorts(List<ushort> shorts)
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

    public void DumpAll(Stream output)
    {
      using (StreamWriter streamWriter = new StreamWriter(output))
      {
        streamWriter.WriteLine("index,B,BS,BL,BLL,BD,RB,RS,RL,RD");
        int bitindex1 = this.bitindex;
        for (; this.BitMaxLength > this.bitindex; ++this.bitindex)
        {
          int bitindex2 = this.bitindex;
          streamWriter.Write(bitindex2.ToString() + ",");
          streamWriter.Write(this.ReadB() ? "1," : "0,");
          this.bitindex = bitindex2;
          try
          {
            short num = this.ReadBS();
            streamWriter.Write(num.ToString() + ",");
          }
          catch (Exception ex)
          {
            streamWriter.Write("error,");
          }
          this.bitindex = bitindex2;
          try
          {
            int num = this.ReadBL();
            streamWriter.Write(num.ToString() + ",");
          }
          catch (Exception ex)
          {
            streamWriter.Write("error,");
          }
          this.bitindex = bitindex2;
          try
          {
            long num = this.ReadBLL();
            streamWriter.Write(num.ToString() + ",");
          }
          catch
          {
            streamWriter.Write("error,");
          }
          this.bitindex = bitindex2;
          try
          {
            double num = this.ReadBD();
            streamWriter.Write(num.ToString() + ",");
          }
          catch
          {
            streamWriter.Write("error,");
          }
          this.bitindex = bitindex2;
          try
          {
            byte num = this.ReadByte();
            streamWriter.Write(num.ToString() + ",");
          }
          catch
          {
            streamWriter.Write("error,");
          }
          this.bitindex = bitindex2;
          try
          {
            short num = this.ReadRS();
            streamWriter.Write(num.ToString() + ",");
          }
          catch (Exception ex)
          {
            streamWriter.Write("error,");
          }
          try
          {
            int num = this.ReadRL();
            streamWriter.Write(num.ToString() + ",");
          }
          catch (Exception ex)
          {
            streamWriter.Write("error,");
          }
          this.bitindex = bitindex2;
          try
          {
            double num = this.ReadRD();
            streamWriter.Write(num);
          }
          catch (Exception ex)
          {
            streamWriter.Write("error");
          }
          streamWriter.WriteLine();
          this.bitindex = bitindex2;
        }
        this.bitindex = bitindex1;
      }
    }

    public DwgBitArray Clone()
    {
      return new DwgBitArray()
      {
        bitArray = this.bitArray.Clone() as BitArray,
        bitindex = this.bitindex
      };
    }

    public bool ReadBit()
    {
      int index = this.bitindex / 8 * 8 + (7 - this.bitindex % 8);
      ++this.bitindex;
      return this.bitArray[index];
    }

    public int BitMaxLength
    {
      get
      {
        return this.bitArray.Count;
      }
    }

    public byte ReadByte()
    {
      byte num = 0;
      if (this.ReadBit())
        num += (byte) 128;
      if (this.ReadBit())
        num += (byte) 64;
      if (this.ReadBit())
        num += (byte) 32;
      if (this.ReadBit())
        num += (byte) 16;
      if (this.ReadBit())
        num += (byte) 8;
      if (this.ReadBit())
        num += (byte) 4;
      if (this.ReadBit())
        num += (byte) 2;
      if (this.ReadBit())
        ++num;
      return num;
    }

    public byte Read4B()
    {
      byte num = 0;
      if (this.ReadBit())
        num += (byte) 8;
      if (this.ReadBit())
        num += (byte) 4;
      if (this.ReadBit())
        num += (byte) 2;
      if (this.ReadBit())
        ++num;
      return num;
    }

    public bool ReadB()
    {
      return this.ReadBit();
    }

    public int ReadBB()
    {
      int num = 0;
      if (this.ReadBit())
        num += 2;
      if (this.ReadBit())
        ++num;
      return num;
    }

    public int Read3B()
    {
      int num = 0;
      if (this.ReadBit())
        num += 4;
      if (this.ReadBit())
        num += 2;
      if (this.ReadBit())
        ++num;
      return num;
    }

    public long ReadBLL()
    {
      int num1 = this.Read3B();
      long num2 = 0;
      for (int index = 0; index < num1; ++index)
      {
        long num3 = (long) this.ReadByte();
        num2 += num3 << index * 8;
      }
      return num2;
    }

    public int ReadRL()
    {
      return BitConverter.ToInt32(new byte[4]
      {
        this.ReadByte(),
        this.ReadByte(),
        this.ReadByte(),
        this.ReadByte()
      }, 0);
    }

    public short ReadRS()
    {
      return BitConverter.ToInt16(new byte[2]
      {
        this.ReadByte(),
        this.ReadByte()
      }, 0);
    }

    public ushort ReadURS()
    {
      return BitConverter.ToUInt16(new byte[2]
      {
        this.ReadByte(),
        this.ReadByte()
      }, 0);
    }

    public ushort ReadRUS()
    {
      return BitConverter.ToUInt16(new byte[2]
      {
        this.ReadByte(),
        this.ReadByte()
      }, 0);
    }

    public ushort ReadBUS()
    {
      bool flag1 = this.ReadBit();
      bool flag2 = this.ReadBit();
      if (!flag1 && !flag2)
        return BitConverter.ToUInt16(new byte[2]
        {
          this.ReadByte(),
          this.ReadByte()
        }, 0);
      if (!flag1 & flag2)
        return (ushort) this.ReadByte();
      return flag1 && !flag2 ? (ushort) 0 : (ushort) 256;
    }

    public short ReadBS()
    {
      bool flag1 = this.ReadBit();
      bool flag2 = this.ReadBit();
      if (!flag1 && !flag2)
        return BitConverter.ToInt16(new byte[2]
        {
          this.ReadByte(),
          this.ReadByte()
        }, 0);
      if (!flag1 & flag2)
        return (short) this.ReadByte();
      return flag1 && !flag2 ? (short) 0 : (short) 256;
    }

    public int Residual
    {
      get
      {
        return this.bitArray.Count - this.bitindex;
      }
    }

    public int ReadBL()
    {
      bool flag1 = this.ReadBit();
      bool flag2 = this.ReadBit();
      if (!flag1 && !flag2)
        return this.ReadRL();
      if (!flag1 & flag2)
        return (int) this.ReadByte();
      if (flag1 && !flag2)
        return 0;
      throw new FormatException();
    }

    public double ReadRD()
    {
      return BitConverter.ToDouble(new byte[8]
      {
        this.ReadByte(),
        this.ReadByte(),
        this.ReadByte(),
        this.ReadByte(),
        this.ReadByte(),
        this.ReadByte(),
        this.ReadByte(),
        this.ReadByte()
      }, 0);
    }

    public double ReadBF()
    {
      bool flag1 = this.ReadBit();
      bool flag2 = this.ReadBit();
      if (!flag1 && !flag2)
        return (double) BitConverter.ToSingle(new byte[4]
        {
          this.ReadByte(),
          this.ReadByte(),
          this.ReadByte(),
          this.ReadByte()
        }, 0);
      if (!flag1 & flag2)
        return 1.0;
      if (flag1 && !flag2)
        return 0.0;
      throw new FormatException();
    }

    public double ReadBD()
    {
      bool flag1 = this.ReadBit();
      bool flag2 = this.ReadBit();
      if (!flag1 && !flag2)
        return BitConverter.ToDouble(new byte[8]
        {
          this.ReadByte(),
          this.ReadByte(),
          this.ReadByte(),
          this.ReadByte(),
          this.ReadByte(),
          this.ReadByte(),
          this.ReadByte(),
          this.ReadByte()
        }, 0);
      if (!flag1 & flag2)
        return 1.0;
      if (flag1 && !flag2)
        return 0.0;
      throw new FormatException();
    }

    public double ReadBT()
    {
      return this.ReadB() ? 0.0 : this.ReadBD();
    }

    public Point3D ReadBE()
    {
      if (!this.ReadB())
        return this.Read3BD();
      return new Point3D() { x = 0.0, y = 0.0, z = 1.0 };
    }

    public double ReadDD(double defaultDouble)
    {
      bool flag1 = this.ReadBit();
      bool flag2 = this.ReadBit();
      if (!flag1 && !flag2)
        return defaultDouble;
      if (!flag1 & flag2)
      {
        byte[] bytes = BitConverter.GetBytes(defaultDouble);
        byte[] numArray = this.ReadBytes(4);
        for (int index = 0; index < 4; ++index)
          bytes[index] = numArray[index];
        return BitConverter.ToDouble(bytes, 0);
      }
      if (!flag1 || flag2)
        return this.ReadRD();
      byte[] bytes1 = BitConverter.GetBytes(defaultDouble);
      byte[] numArray1 = this.ReadBytes(6);
      bytes1[4] = numArray1[0];
      bytes1[5] = numArray1[1];
      for (int index = 2; index < 6; ++index)
        bytes1[index - 2] = numArray1[index];
      return BitConverter.ToDouble(bytes1, 0);
    }

    public Point3D Read3BD()
    {
      return new Point3D()
      {
        x = this.ReadBD(),
        y = this.ReadBD(),
        z = this.ReadBD()
      };
    }

    public Point3D Read3RD()
    {
      return new Point3D()
      {
        x = this.ReadRD(),
        y = this.ReadRD(),
        z = this.ReadRD()
      };
    }

    public Point3D Read3RD(byte[] bytes, int index)
    {
      return new Point3D()
      {
        x = BitConverter.ToDouble(bytes, index),
        y = BitConverter.ToDouble(bytes, index + 8),
        z = BitConverter.ToDouble(bytes, index + 16)
      };
    }

    public Point2D Read2RD()
    {
      return new Point2D()
      {
        x = this.ReadRD(),
        y = this.ReadRD()
      };
    }

    public Point2D Read2BD()
    {
      return new Point2D()
      {
        x = this.ReadBD(),
        y = this.ReadBD()
      };
    }

    public Point2D Read2DD(double defaultVal1, double defaultVal2)
    {
      return new Point2D()
      {
        x = this.ReadDD(defaultVal1),
        y = this.ReadDD(defaultVal2)
      };
    }

    public Point3D Read3DD(double defaultVal1, double defaultVal2, double defaultVal3)
    {
      return new Point3D()
      {
        x = this.ReadDD(defaultVal1),
        y = this.ReadDD(defaultVal2),
        z = this.ReadDD(defaultVal3)
      };
    }

    public int ReadOT()
    {
      int num = this.ReadBB();
      if (num == 0)
        return (int) (short) this.ReadByte();
      if (num == 1)
        return (int) (short) (496 + (int) this.ReadByte());
      if (num == 2)
        return (int) (short) (598 * (int) this.ReadByte() + (int) this.ReadByte());
      throw new Exception("");
    }

    public string ReadSJIS()
    {
      short num = this.ReadBS();
      if (num == (short) 0)
        return "";
      if (num < (short) 0)
        throw new NotImplementedException();
      return Encoding.GetEncoding(932).GetString(this.ReadBytes((int) num)).TrimEnd(new char[1]);
    }

    public string ReadT(int codepage = 0)
    {
      short num = this.ReadBS();
      if (num == (short) 0)
        return "";
      if (num < (short) 0)
        throw new FormatException();
      byte[] bytes = new byte[(int) num];
      for (int index = 0; index < (int) num; ++index)
        bytes[index] = this.ReadByte();
      return codepage == 0 ? Encoding.ASCII.GetString(bytes) : Encoding.GetEncoding(codepage).GetString(bytes);
    }

    public int ReadModuleChars(bool noNegation = false)
    {
      List<byte> bytes = new List<byte>();
      byte num;
      do
      {
        num = this.ReadByte();
        bytes.Add(num);
      }
      while (((int) num & 128) != 0);
      return this.DecodeModuleChars(bytes, noNegation);
    }

    private int DecodeModuleChars(List<byte> bytes, bool noNegation = false)
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

    public string ReadTU(int codepage = 0)
    {
      short num = this.ReadBS();
      if (num == (short) 0)
        return "";
      if (num < (short) 0)
        throw new FormatException();
      byte[] bytes = new byte[(int) num];
      for (int index = 0; index < (int) num; ++index)
        bytes[index] = this.ReadByte();
      return codepage == 0 ? Encoding.ASCII.GetString(bytes) : Encoding.GetEncoding(codepage).GetString(bytes);
    }

    public void DumpBitIndex()
    {
      Console.WriteLine(string.Format("Bitindex: {0}, RemainBit:{1}", (object) this.bitindex, (object) this.Residual));
    }

    public string ReadTU()
    {
      short num = (short) ((int) this.ReadBS() * 2);
      if (num == (short) 0)
        return "";
      if (num < (short) 0)
        throw new FormatException();
      byte[] bytes = new byte[(int) num];
      for (int index = 0; index < (int) num; ++index)
        bytes[index] = this.ReadByte();
      return Encoding.Unicode.GetString(bytes);
    }

    public CmColor ReadCMC()
    {
      short num1 = this.ReadBS();
      int num2 = this.ReadBL();
      int num3 = (int) this.ReadByte();
      string str1 = (string) null;
      string str2 = (string) null;
      if ((num3 & 1) > 0)
        str2 = this.ReadTU();
      if ((num3 & 1) > 0)
        str1 = this.ReadTU();
      return new CmColor()
      {
        ColorIndex = num1,
        RGBValue = num2,
        ColorName = str2,
        BookName = str1
      };
    }

    public HandleReference ReadH()
    {
      byte code = this.Read4B();
      byte counter = this.Read4B();
      byte[] handleoffset = new byte[(int) counter];
      for (int index = 0; index < (int) counter; ++index)
        handleoffset[index] = this.ReadByte();
      return new HandleReference(code, counter, handleoffset);
    }

    public byte[] ReadBytes(int n)
    {
      byte[] numArray = new byte[n];
      for (int index = 0; index < n; ++index)
        numArray[index] = this.ReadByte();
      return numArray;
    }

    public DataItem ReadDataItem(byte[] bytes)
    {
      int num1 = 0;
      DataItem dataItem = new DataItem();
      byte[] numArray1 = bytes;
      int index1 = num1;
      int num2 = index1 + 1;
      byte num3 = numArray1[index1];
      dataItem.type = num3;
      int num4;
      switch (num3)
      {
        case 0:
          byte[] numArray2 = bytes;
          int index2 = num2;
          int startIndex = index2 + 1;
          byte num5 = numArray2[index2];
          int int16_1 = (int) BitConverter.ToInt16(bytes, startIndex);
          int index3 = startIndex + 2;
          string str = Encoding.ASCII.GetString(bytes, index3, (int) num5);
          dataItem.str = str;
          break;
        case 1:
          throw new FormatException();
        case 2:
          byte[] numArray3 = bytes;
          int index4 = num2;
          num4 = index4 + 1;
          byte num6 = numArray3[index4];
          dataItem.str = num6 == (byte) 0 ? "{" : "}";
          break;
        case 3:
          byte[] numArray4 = new byte[8];
          for (int index5 = 0; index5 < 8; ++index5)
            numArray4[index5] = bytes[num2 + index5];
          dataItem.bytes = numArray4;
          num4 = num2 + 8;
          break;
        case 4:
          byte[] numArray5 = bytes;
          int index6 = num2;
          int num7 = index6 + 1;
          byte num8 = numArray5[index6];
          byte[] numArray6 = new byte[(int) num8];
          for (int index5 = 0; index5 < (int) num8; ++index5)
            numArray6[index5] = bytes[num7 + index5];
          dataItem.bytes = numArray6;
          num4 = num7 + (int) num8;
          break;
        case 5:
          byte[] numArray7 = new byte[8];
          for (int index5 = 0; index5 < 8; ++index5)
            numArray7[index5] = bytes[num2 + index5];
          dataItem.bytes = numArray7;
          break;
        case 10:
        case 11:
        case 12:
        case 13:
          Point3D point3D = this.Read3RD(bytes, num2);
          dataItem.point3D = point3D;
          break;
        case 40:
        case 41:
        case 42:
          double num9 = BitConverter.ToDouble(bytes, num2);
          dataItem.real = num9;
          break;
        case 70:
          short int16_2 = BitConverter.ToInt16(bytes, num2);
          dataItem.shortint = int16_2;
          break;
        case 71:
          int int32 = BitConverter.ToInt32(bytes, num2);
          dataItem.longint = int32;
          break;
        default:
          throw new FormatException();
      }
      return dataItem;
    }

    public DataItem ReadDataItem()
    {
      DataItem dataItem = new DataItem();
      byte num1 = this.ReadByte();
      dataItem.type = num1;
      switch (num1)
      {
        case 0:
          byte num2 = this.ReadByte();
          int num3 = (int) this.ReadRS();
          string str = Encoding.ASCII.GetString(this.ReadBytes((int) num2));
          dataItem.str = str;
          break;
        case 1:
          throw new FormatException();
        case 2:
          byte num4 = this.ReadByte();
          dataItem.str = num4 == (byte) 0 ? "{" : "}";
          break;
        case 3:
          byte[] numArray1 = this.ReadBytes(8);
          dataItem.bytes = numArray1;
          break;
        case 4:
          byte[] numArray2 = new byte[(int) this.ReadByte()];
          dataItem.bytes = numArray2;
          break;
        case 5:
          byte[] numArray3 = this.ReadBytes(8);
          dataItem.bytes = numArray3;
          break;
        case 10:
        case 11:
        case 12:
        case 13:
          Point3D point3D = this.Read3RD();
          dataItem.point3D = point3D;
          break;
        case 40:
        case 41:
        case 42:
          double num5 = this.ReadRD();
          dataItem.real = num5;
          break;
        case 70:
          short num6 = this.ReadRS();
          dataItem.shortint = num6;
          break;
        case 71:
          int num7 = this.ReadRL();
          dataItem.longint = num7;
          break;
        default:
          throw new FormatException();
      }
      return dataItem;
    }

    public List<ExtendedEntityData> ReadEED()
    {
      List<ExtendedEntityData> extendedEntityDataList = new List<ExtendedEntityData>();
      while (true)
      {
        ExtendedEntityData extendedEntityData = new ExtendedEntityData();
        extendedEntityData.Length = this.ReadBS();
        if (extendedEntityData.Length != (short) 0)
        {
          extendedEntityData.AppHandle = this.ReadH();
          byte[] bytes = this.ReadBytes((int) extendedEntityData.Length);
          extendedEntityData.dataItem = this.ReadDataItem(bytes);
          extendedEntityDataList.Add(extendedEntityData);
        }
        else
          break;
      }
      return extendedEntityDataList;
    }
  }
}
