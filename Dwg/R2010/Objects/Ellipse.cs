// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.Ellipse
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class Ellipse : CommonEntityData2010
  {
    public Ellipse(DwgBitArray ba)
      : base(ba)
    {
      this.LoadEllipse(ba);
      this.LoadCommonEntityHandleData(ba);
      Console.WriteLine("");
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      po.AddEllipse(this.Center, this.SMAxisVec, this.AxisRatio, this.BegAngle, this.EndAngle, this.Extrusion);
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      double num = this.SMAxisVec.Length();
      boundingBox.SetXY(this.Center.x + num * this.AxisRatio, this.Center.y + num);
      boundingBox.SetXY(this.Center.x - num, this.Center.y - num);
      return boundingBox;
    }

    public Point3D Center { get; set; }

    public Point3D SMAxisVec { get; set; }

    public Point3D Extrusion { get; set; }

    public double AxisRatio { get; set; }

    public double BegAngle { get; set; }

    public double EndAngle { get; set; }

    private void LoadEllipse(DwgBitArray ba)
    {
      this.Center = ba.Read3BD();
      Console.WriteLine(string.Format("Center: {0}", (object) this.Center));
      this.SMAxisVec = ba.Read3BD();
      Console.WriteLine(string.Format("SMAxisVec: {0}", (object) this.SMAxisVec));
      this.Extrusion = ba.Read3BD();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.AxisRatio = ba.ReadBD();
      Console.WriteLine(string.Format("AxisRatio: {0}", (object) this.AxisRatio));
      this.BegAngle = ba.ReadBD();
      Console.WriteLine(string.Format("BegAngle: {0}", (object) this.BegAngle));
      this.EndAngle = ba.ReadBD();
      Console.WriteLine(string.Format("EndAngle: {0}", (object) this.EndAngle));
      ++ba.bitindex;
    }
  }
}
