// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.Arc
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class Arc : dqgToPdf.Dwg.R2000.CommonEntityData
  {
    public Arc(DwgBitArray ba)
      : base(ba)
    {
      this.LoadArc(ba);
      this.LoadCommonEntityHandleData(ba);
      Console.WriteLine("");
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      po.AddArc(this.Center.x, this.Center.y, this.Radius, this.StartAngle, this.EndAngle, this.Extrusion);
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      double startAngle = this.StartAngle;
      double endAngle = this.EndAngle;
      if (startAngle > endAngle)
        startAngle -= 2.0 * Math.PI;
      if (this.Center == null)
        return (BoundingBox) null;
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.AddBoudingBox(this.Center.x + Math.Cos(startAngle) * this.Radius, this.Center.y + Math.Sin(startAngle) * this.Radius);
      boundingBox.AddBoudingBox(this.Center.x + Math.Cos(endAngle) * this.Radius, this.Center.y + Math.Sin(endAngle) * this.Radius);
      return boundingBox;
    }

    public Point3D Center { get; set; }

    public double Radius { get; set; }

    public double Thickness { get; set; }

    public Point3D Extrusion { get; set; }

    public double StartAngle { get; set; }

    public double EndAngle { get; set; }

    private void LoadArc(DwgBitArray ba)
    {
      this.Center = ba.Read3BD();
      Console.WriteLine(string.Format("Center: {0}", (object) this.Center));
      this.Radius = ba.ReadBD();
      Console.WriteLine(string.Format("Radius: {0}", (object) this.Radius));
      this.Thickness = ba.ReadBT();
      Console.WriteLine(string.Format("Thickness: {0}", (object) this.Thickness));
      this.Extrusion = ba.ReadBE();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.StartAngle = ba.ReadBD();
      Console.WriteLine(string.Format("StartAngle: {0}", (object) this.StartAngle));
      this.EndAngle = ba.ReadBD();
      Console.WriteLine(string.Format("EndAngle: {0}", (object) this.EndAngle));
    }
  }
}
