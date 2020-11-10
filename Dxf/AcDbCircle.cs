// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.AcDbCircle
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using dqgToPdf.Pdf.Contents;
using System;
using System.IO;

namespace dqgToPdf.Dxf
{
  public class AcDbCircle : IEntity
  {
    public double? CenterPointX { get; set; }

    public double? CenterPointY { get; set; }

    public double? CenterPointZ { get; set; }

    public double? Radius { get; set; }

    public double? StartAngle { get; set; }

    public double? EndAngle { get; set; }

    public int LineWeight { get; set; }

    public int ColorIndex { get; set; }

    public AcDbCircle()
    {
    }

    public AcDbCircle(StreamReader sr)
    {
      while (!sr.EndOfStream)
      {
        switch (sr.ReadLine())
        {
          case "  0":
            return;
          case " 10":
            this.CenterPointX = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 20":
            this.CenterPointY = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 30":
            this.CenterPointZ = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 40":
            this.Radius = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 50":
            this.StartAngle = new double?(double.Parse(sr.ReadLine()));
            continue;
          case " 51":
            this.EndAngle = new double?(double.Parse(sr.ReadLine()));
            continue;
          default:
            continue;
        }
      }
      throw new Exception();
    }

    public BoundingBox GetBoundingBox()
    {
      if (this.StartAngle.HasValue)
      {
        double num1 = this.StartAngle.Value / 180.0 * Math.PI;
        double num2 = this.EndAngle.Value / 180.0 * Math.PI;
        double num3 = this.CenterPointX.Value;
        double num4 = this.CenterPointY.Value;
        if (num1 > num2)
          num1 -= 2.0 * Math.PI;
        BoundingBox boundingBox1 = new BoundingBox();
        boundingBox1.AddBoudingBox(num3 + Math.Cos(num1) * this.Radius.Value, num4 + Math.Sin(num1) * this.Radius.Value);
        BoundingBox boundingBox2 = boundingBox1;
        double num5 = num3;
        double num6 = Math.Cos(num2);
        double? radius = this.Radius;
        double num7 = radius.Value;
        double num8 = num6 * num7;
        double x1 = num5 + num8;
        double num9 = num4;
        double num10 = Math.Sin(num2);
        radius = this.Radius;
        double num11 = radius.Value;
        double num12 = num10 * num11;
        double y1 = num9 + num12;
        boundingBox2.AddBoudingBox(x1, y1);
        double num13 = num1 + Math.PI / 2.0;
        for (double num14 = num13 - Math.Abs(num13 % (Math.PI / 2.0)); num14 < num2; num14 += Math.PI / 2.0)
        {
          BoundingBox boundingBox3 = boundingBox1;
          double num15 = num3;
          double num16 = Math.Cos(num14);
          radius = this.Radius;
          double num17 = radius.Value;
          double num18 = num16 * num17;
          double x2 = num15 + num18;
          double num19 = num4;
          double num20 = Math.Sin(num14);
          radius = this.Radius;
          double num21 = radius.Value;
          double num22 = num20 * num21;
          double y2 = num19 + num22;
          boundingBox3.AddBoudingBox(x2, y2);
        }
        return boundingBox1;
      }
      BoundingBox boundingBox = new BoundingBox();
      double? nullable = this.CenterPointX;
      double num23 = nullable.Value;
      nullable = this.Radius;
      double num24 = nullable.Value;
      boundingBox.Left = num23 - num24;
      nullable = this.CenterPointX;
      double num25 = nullable.Value;
      nullable = this.Radius;
      double num26 = nullable.Value;
      boundingBox.Right = num25 + num26;
      nullable = this.CenterPointY;
      double num27 = nullable.Value;
      nullable = this.Radius;
      double num28 = nullable.Value;
      boundingBox.Top = num27 + num28;
      nullable = this.CenterPointY;
      double num29 = nullable.Value;
      nullable = this.Radius;
      double num30 = nullable.Value;
      boundingBox.Bottom = num29 - num30;
      return boundingBox;
    }

    public void WritePdf(PageObject po, int lineType, int lineWidth, int colorIndex)
    {
    }

    public bool IsEnableLineStyle { get; set; }
  }
}
