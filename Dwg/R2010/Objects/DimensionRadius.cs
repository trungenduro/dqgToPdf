// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.DimensionRadius
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class DimensionRadius : Dimension
  {
    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetXY(this.pt10.x, this.pt10.y);
      boundingBox.SetXY(this.pt15.x, this.pt15.y);
      return boundingBox;
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      this.SetDimensionColor(po, objMap);
      this.DrawAnonymousBlock(po, objMap);
    }

    public DimensionRadius(DwgBitArray ba)
      : base(ba)
    {
      this.LoadDimensionRadiusData(ba);
      ba.DumpBitIndex();
      Console.WriteLine();
    }

    public Point3D pt10 { get; set; }

    public Point3D pt15 { get; set; }

    public double LeaderLen { get; set; }

    private void LoadDimensionRadiusData(DwgBitArray ba)
    {
      this.pt10 = ba.Read3BD();
      Console.WriteLine(string.Format("pt10: {0}", (object) this.pt10));
      this.pt15 = ba.Read3BD();
      Console.WriteLine(string.Format("pt15: {0}", (object) this.pt15));
      this.LeaderLen = ba.ReadBD();
      Console.WriteLine(string.Format("LeaderLen: {0}", (object) this.LeaderLen));
      this.UserText = ba.ReadTU();
      Console.WriteLine("UserText: " + this.UserText);
      ba.bitindex += 17;
      this.LoadCommonEntityHandleData(ba);
      this.LoadDimensionHandle(ba);
    }
  }
}
