// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.BlockControl
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class BlockControl : CommonNonEntityData
  {
    public int ObjSize { get; set; }

    public int NumEntries { get; set; }

    public bool HasBinaryData { get; set; }

    public HandleReference Null { get; set; }

    public List<HandleReference> BlockHeadersHandles { get; set; } = new List<HandleReference>();

    public HandleReference ModelSpaceHandle { get; set; }

    public HandleReference PaperSpaceHandle { get; set; }

    public BlockControl(DwgBitArray ba)
      : base(ba)
    {
      this.LoadBlockControlData(ba);
    }

    public void LoadBlockControlData(DwgBitArray ba)
    {
      this.HasBinaryData = ba.ReadB();
      Console.WriteLine(string.Format("HasBinaryData:{0}", (object) this.HasBinaryData));
      this.NumEntries = ba.ReadBL();
      Console.WriteLine(string.Format("NumEntries:{0}", (object) this.NumEntries));
      ba.ReadB();
      this.Null = ba.ReadH();
      Console.WriteLine(string.Format("Null:{0}", (object) this.Null));
      for (int index = 0; index < this.NumReactors; ++index)
        this.ReactorHandles.Add(ba.ReadH());
      if (!this.XdicMissingFlag)
        this.XdicObjHandle = ba.ReadH();
      for (int index = 0; index < this.NumEntries; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("BlockHeadersHandle: {0}", (object) handleReference));
        this.BlockHeadersHandles.Add(handleReference);
      }
      Console.WriteLine("currentBitIndex:" + ba.bitindex.ToString());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      this.ModelSpaceHandle = ba.ReadH();
      Console.WriteLine(string.Format("ModelSpaceHandle: {0}", (object) this.ModelSpaceHandle));
      this.PaperSpaceHandle = ba.ReadH();
      Console.WriteLine(string.Format("PaperSpaceHandle: {0}", (object) this.PaperSpaceHandle));
      Console.WriteLine("currentBitIndex:" + ba.bitindex.ToString());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
    }
  }
}
