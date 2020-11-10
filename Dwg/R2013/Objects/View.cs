// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.View
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class View : CommonNonEntityData
  {
    public View(DwgBitArray ba)
      : base(ba)
    {
      this.LoadViewData(ba);
    }

    public bool Flag64 { get; set; }

    public int XrefIndexPlus1 { get; set; }

    private void LoadViewData(DwgBitArray ba)
    {
      this.Flag64 = ba.ReadB();
      Console.WriteLine(string.Format("Flag64: {0}", (object) this.Flag64));
      this.XrefIndexPlus1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("XrefIndexPlus1: {0}", (object) this.XrefIndexPlus1));
    }
  }
}
