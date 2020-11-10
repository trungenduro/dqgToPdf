// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.AcDbSpline
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using dqgToPdf.Pdf.Contents;
using System.Collections.Generic;

namespace dqgToPdf.Dxf
{
  public class AcDbSpline : IEntity
  {
    public List<Point3D> ControlPoints { get; set; } = new List<Point3D>();

    public List<Point3D> FitPoints { get; set; } = new List<Point3D>();

    public int ColorIndex { get; set; }

    public int LineWeight { get; set; }

    public BoundingBox GetBoundingBox()
    {
      BoundingBox boundingBox = new BoundingBox();
      foreach (Point3D controlPoint in this.ControlPoints)
        boundingBox.AddBoudingBox(controlPoint.x, controlPoint.y);
      foreach (Point3D fitPoint in this.FitPoints)
        boundingBox.AddBoudingBox(fitPoint.x, fitPoint.y);
      return boundingBox;
    }

    public void WritePdf(PageObject po, int lineType, int lineWidth, int colorIndex)
    {
      if (this.IsEnableLineStyle)
        return;
      po.AddSplineWithLineWeight(this.ControlPoints, this.ColorIndex, this.LineWeight);
    }

    public bool IsEnableLineStyle { get; set; }
  }
}
