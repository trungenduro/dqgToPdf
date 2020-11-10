// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.Path
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class Path
  {
    public int PathFlag { get; set; }

    public int NumPathSegs { get; set; }

    public List<PathSeg> PathSegs { get; set; } = new List<PathSeg>();

    public List<Bulge> Bulges { get; set; } = new List<Bulge>();

    public bool BulgePresent { get; set; }

    public bool Closed { get; set; }

    public int NumBoundayObjHandles { get; set; }
  }
}
