// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.LeaderLine
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class LeaderLine
  {
    public int NumOfPoints { get; set; }

    public List<Point3D> Points { get; set; } = new List<Point3D>();

    public int BreakInfoCount { get; set; }

    public int SegmentIndex { get; set; }

    public int StartEndPointPairCount { get; set; }

    public List<PointPair> StartEndPointPairs { get; set; } = new List<PointPair>();

    public int LeaderLineIndex { get; set; }

    public int LeaderType { get; set; }

    public CmColor LineColor { get; set; }

    public HandleReference LineTypeHandle { get; set; }

    public int LineWeight { get; set; }

    public double ArrowSize { get; set; }

    public HandleReference ArrowSymbolHandle { get; set; }

    public int OverrideFlags { get; set; }
  }
}
