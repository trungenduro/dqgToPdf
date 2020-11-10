// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Objects.Text
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dqgToPdf.Pdf.Objects
{
  public class Text : BaseObject
  {
    protected Encoding _encoding = Encoding.GetEncoding(932);
    protected bool isHex;

    public string text { get; set; }

    public Text(string text, bool isHex = false)
      : base(false)
    {
      this.text = text;
      this.isHex = isHex;
    }

    public override string DirectExpresion()
    {
      return !this.isHex ? "(" + this.text + ")" : "<" + string.Join("", ((IEnumerable<byte>) this._encoding.GetBytes(this.text)).Select<byte, string>((Func<byte, int, string>) ((b, i) => b.ToString("X2").ToLower()))) + ">";
    }

    public string Expression(Encoding enc)
    {
      this._encoding = enc;
      return this.Expression(false);
    }
  }
}
