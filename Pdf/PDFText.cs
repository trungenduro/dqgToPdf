// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.PDFText
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.ParserModel;

namespace dqgToPdf.Pdf
{
  public class PDFText
  {
    public double linewidth { get; set; }

    public double ctma { get; set; } = 1.0;

    public double ctmb { get; set; }

    public double ctmc { get; set; }

    public double ctmd { get; set; } = 1.0;

    public double ctme { get; set; }

    public double ctmf { get; set; }

    public double a { get; set; } = 1.0;

    public double b { get; set; }

    public double c { get; set; }

    public double d { get; set; } = 1.0;

    public double e { get; set; }

    public double f { get; set; }

    public double red { get; set; }

    public double green { get; set; }

    public double blue { get; set; }

    public double fontsize { get; set; }

    public string text { get; set; }

    public int LinkTarget { get; set; } = -1;

    public string targetRelativePath { get; set; }

    public Stream parentStream { get; set; }

    public PDFText Clone()
    {
      return new PDFText()
      {
        ctma = this.ctma,
        ctmb = this.ctmb,
        ctmc = this.ctmc,
        ctmd = this.ctmd,
        ctme = this.ctme,
        ctmf = this.ctmf,
        a = this.a,
        b = this.b,
        c = this.c,
        d = this.d,
        e = this.e,
        f = this.f,
        red = this.red,
        green = this.green,
        blue = this.blue,
        linewidth = this.linewidth,
        fontsize = this.fontsize,
        text = "",
        parentStream = this.parentStream
      };
    }

    public override string ToString()
    {
      return this.text;
    }
  }
}
