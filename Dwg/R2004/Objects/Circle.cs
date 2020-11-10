// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.Circle
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class Circle : dqgToPdf.Dwg.R2004.CommonEntityData
  {
    public Circle(DwgBitArray ba)
      : base(ba)
    {
      this.LoadCircleData(ba);
      this.LoadCommonEntityHandleData(ba);
      Console.WriteLine("");
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      po.AddCircle(this.Center.x, this.Center.y, this.Radius, 0, 0, 0);
    }

    public Point3D Center { get; set; }

    public double Radius { get; set; }

    public double Thickness { get; set; }

    public Point3D Extrusion { get; set; }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetXY(this.Center.x + this.Radius, this.Center.y + this.Radius);
      boundingBox.SetXY(this.Center.x - this.Radius, this.Center.y - this.Radius);
      return boundingBox;
    }

    private void LoadCircleData(DwgBitArray ba)
    {
      this.Center = ba.Read3BD();
      Console.WriteLine(string.Format("Center: {0}", (object) this.Center));
      this.Radius = ba.ReadBD();
      Console.WriteLine(string.Format("Radius: {0}", (object) this.Radius));
      this.Thickness = ba.ReadBT();
      Console.WriteLine(string.Format("Thickness: {0}", (object) this.Thickness));
      this.Extrusion = ba.ReadBE();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
    }
  }
}
