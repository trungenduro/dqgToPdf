// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.Point
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class Point : dqgToPdf.Dwg.R2000.CommonEntityData
  {
    public Point(DwgBitArray ba)
      : base(ba)
    {
      this.LoadPointData(ba);
      this.LoadCommonEntityHandleData(ba);
      Console.WriteLine();
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetXY(this.Pt.x, this.Pt.y);
      return boundingBox;
    }

    public Point3D Pt { get; set; }

    public double Thickness { get; set; }

    public Point3D Extrusion { get; set; }

    public double XAxisAng { get; set; }

    private void LoadPointData(DwgBitArray ba)
    {
      this.Pt = ba.Read3BD();
      Console.WriteLine(string.Format("Pt: {0}", (object) this.Pt));
      this.Thickness = ba.ReadBT();
      Console.WriteLine(string.Format("Thickness: {0}", (object) this.Thickness));
      this.Extrusion = ba.ReadBE();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.XAxisAng = ba.ReadBD();
      Console.WriteLine(string.Format("XAxisAng: {0}", (object) this.XAxisAng));
    }
  }
}
