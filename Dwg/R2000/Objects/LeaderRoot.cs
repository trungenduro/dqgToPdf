// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.LeaderRoot
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class LeaderRoot
  {
    public bool IsContentValid { get; set; }

    public bool Unknown { get; set; }

    public Point3D ConnectionPoint { get; set; }

    public Point3D Direction { get; set; }

    public int NumOfBreakStartEndPointPairs { get; set; }

    public List<PointPair> BreakStartEndPointPairs { get; set; } = new List<PointPair>();

    public int LeaderIndex { get; set; }

    public double LandingDistance { get; set; }

    public int NumOfLeaderLines { get; set; }

    public List<LeaderLine> LeaderLines { get; set; } = new List<LeaderLine>();

    public int AttachmentDirection { get; set; }
  }
}
