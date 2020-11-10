// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.DefLine
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class DefLine
  {
    public double Angle { get; set; }

    public Point2D Pt0 { get; set; }

    public Point2D Offset { get; set; }

    public int NumDashes { get; set; }

    public List<double> DashLengths { get; set; } = new List<double>();
  }
}
