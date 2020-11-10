// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.Block
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class Block : dqgToPdf.Dwg.R2000.CommonEntityData
  {
    public string BlockName { get; set; }

    public Block(DwgBitArray ba)
      : base(ba)
    {
      this.BlockName = ba.ReadSJIS();
      Console.WriteLine(this.BlockName);
      this.LoadCommonEntityHandleData(ba);
      ba.DumpBitIndex();
      Console.WriteLine("");
    }
  }
}
