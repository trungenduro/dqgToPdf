// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.Line
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class Line : dqgToPdf.Dwg.R2000.CommonEntityData
  {
    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      po.AddLine(this.StartPt.x, this.StartPt.y, this.EndPt.x, this.EndPt.y, 0, 0, 0);
    }

    public Point3D StartPt { get; set; } = new Point3D();

    public Point3D EndPt { get; set; } = new Point3D();

    public bool ZsAreZeroBit { get; set; }

    public double Thickness { get; set; }

    public Point3D Extrusion { get; set; }

    public Line(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLineData(ba);
      this.LoadCommonEntityHandleData(ba);
      ba.DumpBitIndex();
      Console.WriteLine();
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetXY(this.StartPt.x, this.StartPt.y);
      boundingBox.SetXY(this.EndPt.x, this.EndPt.y);
      return boundingBox;
    }

    public void LoadLineData(DwgBitArray ba)
    {
      this.ZsAreZeroBit = ba.ReadB();
      this.StartPt.x = ba.ReadRD();
      this.EndPt.x = ba.ReadDD(this.StartPt.x);
      this.StartPt.y = ba.ReadRD();
      this.EndPt.y = ba.ReadDD(this.StartPt.y);
      if (!this.ZsAreZeroBit)
      {
        this.StartPt.z = ba.ReadRD();
        this.EndPt.z = ba.ReadDD(this.StartPt.z);
      }
      this.Thickness = ba.ReadBT();
      this.Extrusion = ba.ReadBE();
      Console.WriteLine("StartPoint");
      Console.WriteLine((object) this.StartPt);
      Console.WriteLine("EndPoint");
      Console.WriteLine((object) this.EndPt);
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
    }
  }
}
