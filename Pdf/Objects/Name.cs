// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Objects.Name
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Pdf.Objects
{
  public class Name : BaseObject
  {
    public string name { get; set; }

    public Name(string name)
      : base(false)
    {
      this.name = name.TrimStart('/');
    }

    public override bool Equals(object obj)
    {
      return obj is Name name && name.name == this.name;
    }

    public override string DirectExpresion()
    {
      return "/" + this.name;
    }
  }
}
