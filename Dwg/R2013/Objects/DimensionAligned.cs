// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.DimensionAligned
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class DimensionAligned : Dimension
  {
    public DimensionAligned(DwgBitArray ba)
      : base(ba)
    {
      this.LoadDimensionAligned(ba);
      ba.DumpBitIndex();
      Console.WriteLine("");
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      this.SetDimensionColor(po, objMap);
      this.DrawAnonymousBlock(po, objMap);
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetXY(this.pt13.x, this.pt13.y);
      boundingBox.SetXY(this.pt14.x, this.pt14.y);
      boundingBox.SetXY(this.pt10.x, this.pt10.y);
      return boundingBox;
    }

    public bool HasBinaryData { get; set; }

    public Point3D pt13 { get; set; }

    public Point3D pt14 { get; set; }

    public Point3D pt10 { get; set; }

    public double ExtLnRot { get; set; }

    private void LoadDimensionAligned(DwgBitArray ba)
    {
      this.pt13 = ba.Read3BD();
      Console.WriteLine(string.Format("pt13: {0}", (object) this.pt13));
      this.pt14 = ba.Read3BD();
      Console.WriteLine(string.Format("pt14: {0}", (object) this.pt14));
      this.pt10 = ba.Read3BD();
      Console.WriteLine(string.Format("pt10: {0}", (object) this.pt10));
      this.ExtLnRot = ba.ReadBD();
      Console.WriteLine(string.Format("ExtLnRot: {0}", (object) this.ExtLnRot));
      this.UserText = ba.ReadTU();
      Console.WriteLine("UserText: " + this.UserText);
      ba.bitindex += 17;
      this.LoadCommonEntityHandleData(ba);
      this.LoadDimensionHandle(ba);
    }
  }
}
