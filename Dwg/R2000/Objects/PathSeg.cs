// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.PathSeg
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class PathSeg
  {
    public int PathTypeStatus { get; set; }

    public Point2D Pt0 { get; set; }

    public Point2D Pt1 { get; set; }

    public double Radius { get; set; }

    public double StartAngle { get; set; }

    public double EndAngle { get; set; }

    public bool IsCcw { get; set; }

    public Point2D EndPoint { get; set; }

    public double MinorMajorRatio { get; set; }

    public int Degree { get; set; }

    public bool IsRational { get; set; }

    public bool IsPeriodic { get; set; }

    public int NumKnots { get; set; }

    public int NumControlPoints { get; set; }

    public List<double> Knots { get; set; } = new List<double>();

    public List<CtlPt> CtlPts { get; set; } = new List<CtlPt>();
  }
}
