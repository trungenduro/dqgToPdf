// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.AcDbLine
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using dqgToPdf.Pdf.Contents;
using System;
using System.IO;

namespace dqgToPdf.Dxf
{
  public class AcDbLine : IEntity
  {
    public int LineWeight { get; set; }

    public double? StartPointX { get; set; }

    public double? StartPointY { get; set; }

    public double? StartPointZ { get; set; }

    public double? EndPointX { get; set; }

    public double? EndPointY { get; set; }

    public double? EndPointZ { get; set; }

    public int ColorIndex { get; set; }

    public AcDbLine()
    {
    }

    public AcDbLine(StreamReader sr)
    {
      while (!sr.EndOfStream)
      {
        switch (sr.ReadLine())
        {
          case " 10":
            this.StartPointX = new double?(double.Parse(sr.ReadLine()));
            break;
          case " 20":
            this.StartPointY = new double?(double.Parse(sr.ReadLine()));
            break;
          case " 30":
            this.StartPointZ = new double?(double.Parse(sr.ReadLine()));
            break;
          case " 11":
            this.EndPointX = new double?(double.Parse(sr.ReadLine()));
            break;
          case " 21":
            this.EndPointY = new double?(double.Parse(sr.ReadLine()));
            break;
          case " 31":
            this.EndPointZ = new double?(double.Parse(sr.ReadLine()));
            break;
        }
        if (this.StartPointX.HasValue && this.StartPointY.HasValue && (this.StartPointZ.HasValue && this.EndPointX.HasValue) && (this.EndPointY.HasValue && this.EndPointZ.HasValue))
          return;
      }
      throw new Exception();
    }

    public BoundingBox GetBoundingBox()
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetX(this.StartPointX.Value);
      boundingBox.SetX(this.EndPointX.Value);
      boundingBox.SetY(this.StartPointY.Value);
      boundingBox.SetY(this.EndPointY.Value);
      return boundingBox;
    }

    public void WritePdf(PageObject po, int lineType, int lineWidth, int colorIndex)
    {
      if (this.IsEnableLineStyle)
        po.AddLine(this.StartPointX.Value, this.StartPointY.Value, this.EndPointX.Value, this.EndPointY.Value, colorIndex, lineWidth, lineType);
      else
        po.AddLineWithLineWeight(this.StartPointX.Value, this.StartPointY.Value, this.EndPointX.Value, this.EndPointY.Value, this.ColorIndex, this.LineWeight);
    }

    public bool IsEnableLineStyle { get; set; }
  }
}
