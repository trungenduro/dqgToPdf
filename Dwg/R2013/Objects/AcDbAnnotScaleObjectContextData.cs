// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.AcDbAnnotScaleObjectContextData
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class AcDbAnnotScaleObjectContextData : CommonNonEntityData
  {
    public AcDbAnnotScaleObjectContextData(DwgBitArray ba)
      : base(ba)
    {
      this.loadAcDbAnnotScaleOcjectContextData(ba);
    }

    public HandleReference ScaleObjectHandle { get; set; }

    private void loadAcDbAnnotScaleOcjectContextData(DwgBitArray ba)
    {
      this.ScaleObjectHandle = ba.ReadH();
      Console.WriteLine(string.Format("ScaleObjectHandle: {0}", (object) this.ScaleObjectHandle));
    }
  }
}
