// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.BlockHeader
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class BlockHeader : dqgToPdf.Dwg.R2004.CommonNonEntityData
  {
    public string EntryName { get; set; }

    public bool Flag64 { get; set; }

    public int XrefIndexPlus1 { get; set; }

    public bool Xdep { get; set; }

    public bool Anonymous { get; set; }

    public bool Hasatts { get; set; }

    public bool Blkisxref { get; set; }

    public bool Xrefoverlaid { get; set; }

    public bool LoadedBit { get; set; }

    public int OwnedObjectCount { get; set; }

    public Point3D BasePt { get; set; }

    public string XrefPname { get; set; }

    public int InsertCount { get; set; }

    public string BlockDescription { get; set; }

    public int SizeOfPreviewData { get; set; }

    public byte[] BinaryPreviewData { get; set; }

    public HandleReference BlockControlHandle { get; set; }

    public HandleReference Null { get; set; }

    public HandleReference BlockEntitylHandle { get; set; }

    public HandleReference EndblkEntitylHandle { get; set; }

    public HandleReference LayoutHandle { get; set; }

    public List<HandleReference> OwnedObjectHandles { get; set; } = new List<HandleReference>();

    public List<HandleReference> InsertHandles { get; set; } = new List<HandleReference>();

    public BlockHeader(DwgBitArray ba)
      : base(ba)
    {
      this.LoadBlockHeaderData(ba);
    }

    private new void LoadTextData(DwgBitArray ba)
    {
      ba.bitindex = ba.BitMaxLength - this.SizeInBitsHandle;
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("---------------");
      --ba.bitindex;
      bool flag = ba.ReadB();
      Console.WriteLine(string.Format("StringStreamFlag: {0}", (object) flag));
      if (!flag)
        return;
      int num1 = 0;
      --ba.bitindex;
      int num2;
      while (true)
      {
        ba.bitindex -= 16;
        int num3 = (int) ba.ReadByte() + (int) ba.ReadByte() * 256;
        ba.bitindex -= 16;
        num2 = (num1 << 15) + num3;
        if (num3 > 32768)
          num1 = num2 - 32768;
        else
          break;
      }
      ba.bitindex -= num2;
      Console.WriteLine("t: " + ba.ReadTU());
    }

    private void LoadBlockHeaderData(DwgBitArray ba)
    {
      this.EntryName = ba.ReadSJIS();
      Console.WriteLine("EntryName: " + this.EntryName);
      this.Flag64 = ba.ReadB();
      Console.WriteLine(string.Format("Flag64: {0}", (object) this.Flag64));
      this.XrefIndexPlus1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("XrefIndexPlus1: {0}", (object) this.XrefIndexPlus1));
      this.Xdep = ba.ReadB();
      Console.WriteLine(string.Format("Xdep: {0}", (object) this.Xdep));
      this.Anonymous = ba.ReadB();
      Console.WriteLine(string.Format("Anonymous: {0}", (object) this.Anonymous));
      this.Hasatts = ba.ReadB();
      Console.WriteLine(string.Format("Hasatts: {0}", (object) this.Hasatts));
      this.Blkisxref = ba.ReadB();
      Console.WriteLine(string.Format("Blkisxref: {0}", (object) this.Blkisxref));
      this.Xrefoverlaid = ba.ReadB();
      Console.WriteLine(string.Format("Xrefoverlaid: {0}", (object) this.Xrefoverlaid));
      this.LoadedBit = ba.ReadB();
      Console.WriteLine(string.Format("LoadedBit: {0}", (object) this.LoadedBit));
      this.OwnedObjectCount = ba.ReadBL();
      Console.WriteLine(string.Format("OwnedObjectCount: {0}", (object) this.OwnedObjectCount));
      this.BasePt = ba.Read3BD();
      Console.WriteLine(string.Format("BasePt: {0}", (object) this.BasePt));
      this.XrefPname = ba.ReadSJIS();
      Console.WriteLine("XrefPname: " + this.XrefPname);
      this.InsertCount = 0;
      while (true)
      {
        byte num = ba.ReadByte();
        if (num != (byte) 0)
          this.InsertCount += (int) num;
        else
          break;
      }
      Console.WriteLine(string.Format("insertCount: {0}", (object) this.InsertCount));
      this.BlockDescription = ba.ReadSJIS();
      Console.WriteLine("BlockDescription: " + this.BlockDescription);
      this.SizeOfPreviewData = ba.ReadBL();
      Console.WriteLine(string.Format("SizeOfPreviewData: {0}", (object) this.SizeOfPreviewData));
      this.BinaryPreviewData = new byte[this.SizeOfPreviewData];
      for (int index = 0; index < this.SizeOfPreviewData; ++index)
        this.BinaryPreviewData[index] = ba.ReadByte();
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      this.BlockControlHandle = ba.ReadH();
      Console.WriteLine(string.Format("BlockControlHandle: {0}", (object) this.BlockControlHandle));
      for (int index = 0; index < this.NumReactors; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        this.ReactorHandles.Add(handleReference);
        Console.WriteLine(string.Format("reactr: {0}", (object) handleReference));
      }
      if (!this.XdicMissingFlag)
      {
        this.XdicObjHandle = ba.ReadH();
        Console.WriteLine(string.Format("XdicObjHandle: {0}", (object) this.XdicObjHandle));
      }
      this.Null = ba.ReadH();
      Console.WriteLine(string.Format("Null: {0}", (object) this.Null));
      this.BlockEntitylHandle = ba.ReadH();
      Console.WriteLine(string.Format("BlockEntitylHandle: {0}", (object) this.BlockEntitylHandle));
      for (int index = 0; index < this.OwnedObjectCount; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("OwnedObjectHandle: {0}", (object) handleReference));
        this.OwnedObjectHandles.Add(handleReference);
      }
      for (int index = 0; index < this.InsertCount; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("InsertHandle: {0}", (object) handleReference));
        this.InsertHandles.Add(handleReference);
      }
      this.EndblkEntitylHandle = ba.ReadH();
      Console.WriteLine(string.Format("EndblkEntitylHandle: {0}", (object) this.EndblkEntitylHandle));
      this.LayoutHandle = ba.ReadH();
      Console.WriteLine(string.Format("LayoutHandle: {0}", (object) this.LayoutHandle));
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("");
    }
  }
}
