// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Objects.RealNumber
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Pdf.Objects
{
  public class RealNumber : BaseObject
  {
    public double number { get; set; }

    public RealNumber(double number)
      : base(false)
    {
      this.number = number;
    }

    public override string DirectExpresion()
    {
      return this.number.ToString();
    }
  }
}
