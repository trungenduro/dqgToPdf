// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.DimensionAngular2Line
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class DimensionAngular2Line : Dimension
  {
    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetXY(this.pt13.x, this.pt13.y);
      boundingBox.SetXY(this.pt14.x, this.pt14.y);
      boundingBox.SetXY(this.pt10.x, this.pt10.y);
      boundingBox.SetXY(this.pt15.x, this.pt15.y);
      boundingBox.SetXY(this.pt16.x, this.pt16.y);
      return boundingBox;
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      this.SetDimensionColor(po, objMap);
      this.DrawAnonymousBlock(po, objMap);
    }

    public DimensionAngular2Line(DwgBitArray ba)
      : base(ba)
    {
      this.LoadDimensionAngular2LineData(ba);
      this.LoadCommonEntityHandleData(ba);
      this.LoadDimensionHandle(ba);
      ba.DumpBitIndex();
      Console.WriteLine("");
    }

    public Point2D pt16 { get; set; }

    public Point3D pt13 { get; set; }

    public Point3D pt14 { get; set; }

    public Point3D pt15 { get; set; }

    public Point3D pt10 { get; set; }

    private void LoadDimensionAngular2LineData(DwgBitArray ba)
    {
      this.pt16 = ba.Read2RD();
      Console.WriteLine(string.Format("pt16: {0}", (object) this.pt16));
      this.pt13 = ba.Read3BD();
      Console.WriteLine(string.Format("pt13: {0}", (object) this.pt13));
      this.pt14 = ba.Read3BD();
      Console.WriteLine(string.Format("pt14: {0}", (object) this.pt14));
      this.pt15 = ba.Read3BD();
      Console.WriteLine(string.Format("pt15: {0}", (object) this.pt15));
      this.pt10 = ba.Read3BD();
      Console.WriteLine(string.Format("pt10: {0}", (object) this.pt10));
      this.UserText = ba.ReadTU();
      Console.WriteLine("UserText: " + this.UserText);
      ba.bitindex += 17;
    }
  }
}
