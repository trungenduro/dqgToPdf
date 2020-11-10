// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Seqend
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Seqend : CommonEntityData
  {
    public Seqend(DwgBitArray ba)
      : base(ba)
    {
      this.LoadSeqendData(ba);
      this.LoadCommonEntityHandleData(ba);
    }

    private void LoadSeqendData(DwgBitArray ba)
    {
      ++ba.bitindex;
    }
  }
}
