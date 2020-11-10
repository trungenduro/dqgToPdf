// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Block
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Block : CommonEntityData
  {
    public string BlockName { get; set; }

    public Block(DwgBitArray ba)
      : base(ba)
    {
      this.BlockName = ba.ReadTU();
      Console.WriteLine(this.BlockName);
      ba.bitindex += 17;
      this.LoadCommonEntityHandleData(ba);
      ba.DumpBitIndex();
      Console.WriteLine("");
    }
  }
}
