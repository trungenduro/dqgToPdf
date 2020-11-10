// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.POCO.CurrentTransformationMatrix
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Pdf.POCO
{
  public class CurrentTransformationMatrix
  {
    public double a { get; set; }

    public double b { get; set; }

    public double c { get; set; }

    public double d { get; set; }

    public double e { get; set; }

    public double f { get; set; }

    public static CurrentTransformationMatrix operator *(
      CurrentTransformationMatrix ctm1,
      CurrentTransformationMatrix ctm2)
    {
      return new CurrentTransformationMatrix()
      {
        a = ctm1.a * ctm2.a + ctm1.b * ctm2.c,
        b = ctm1.a * ctm2.b + ctm1.b * ctm2.d,
        c = ctm1.c * ctm2.a + ctm1.d * ctm2.c,
        d = ctm1.c * ctm2.b + ctm1.d * ctm2.d,
        e = ctm1.e * ctm2.a + ctm1.f * ctm2.c + ctm2.e,
        f = ctm1.e * ctm2.b + ctm1.f * ctm2.d + ctm2.f
      };
    }
  }
}
