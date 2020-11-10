// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Objects.Boolean
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Pdf.Objects
{
  public class Boolean : BaseObject
  {
    public bool Val { get; set; }

    public Boolean(bool val)
      : base(false)
    {
      this.Val = val;
    }

    public override string DirectExpresion()
    {
      return !this.Val ? "false" : "true";
    }
  }
}
