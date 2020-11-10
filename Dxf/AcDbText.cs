// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.AcDbText
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using dqgToPdf.Pdf.Contents;
using System;
using System.IO;

namespace dqgToPdf.Dxf
{
  public class AcDbText : IEntity
  {
    public double? FirstAlignX { get; set; }

    public double? FirstAlignY { get; set; }

    public double? FirstAlignZ { get; set; }

    public double? TextHeight { get; set; }

    public double? WidthFactor { get; set; }

    public int LineWidth { get; set; }

    public int ColorIndex { get; set; }

    public string Value { get; set; }

    public double? Textrotation { get; set; } = new double?(0.0);

    public string FontName { get; set; }

    public string BigfontName { get; set; }

    public AcDbText()
    {
    }

    public AcDbText(StreamReader sr)
    {
      while (!sr.EndOfStream)
      {
        switch (sr.ReadLine())
        {
          case "  1":
            this.Value = sr.ReadLine();
            continue;
          case " 10":
            this.FirstAlignX = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 20":
            this.FirstAlignY = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 30":
            this.FirstAlignZ = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 40":
            this.TextHeight = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 50":
            this.Textrotation = new double?(double.Parse(sr.ReadLine()));
            continue;
          case "100":
            return;
          default:
            continue;
        }
      }
      throw new Exception();
    }

    public BoundingBox GetBoundingBox()
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetX(this.FirstAlignX.Value);
      boundingBox.SetY(this.FirstAlignY.Value);
      return boundingBox;
    }

    public void WritePdf(PageObject po, int lineType, int lineWidth, int colorIndex)
    {
    }

    public bool IsEnableLineStyle { get; set; }

    public void AddRemoteLink(PageObject po, string targetpath)
    {
      double num = this.TextHeight.Value * 0.75;
      double x = this.FirstAlignX.Value;
      double y = this.FirstAlignY.Value;
      po.AddRemoteLink(x, y, x + (double) this.Value.Length * num, y + num, targetpath, this.Textrotation.Value / 180.0 * Math.PI);
    }
  }
}
