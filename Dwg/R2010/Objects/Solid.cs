// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.Solid
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class Solid : CommonEntityData2010
  {
    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      po.AddLine(this.Corner1st.x, this.Corner1st.y, this.Corner2nd.x, this.Corner2nd.y, 0, 0, 0);
      po.AddLine(this.Corner2nd.x, this.Corner2nd.y, this.Corner3rd.x, this.Corner3rd.y, 0, 0, 0);
      po.AddLine(this.Corner3rd.x, this.Corner3rd.y, this.Corner4th.x, this.Corner4th.y, 0, 0, 0);
      po.AddLine(this.Corner4th.x, this.Corner4th.y, this.Corner1st.x, this.Corner1st.y, 0, 0, 0);
    }

    public Solid(DwgBitArray ba)
      : base(ba)
    {
      this.LoadSolidData(ba);
      this.LoadCommonEntityHandleData(ba);
      ba.DumpBitIndex();
      Console.WriteLine("");
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetXY(this.Corner1st.x, this.Corner1st.y);
      boundingBox.SetXY(this.Corner2nd.x, this.Corner2nd.y);
      boundingBox.SetXY(this.Corner3rd.x, this.Corner3rd.y);
      boundingBox.SetXY(this.Corner4th.x, this.Corner4th.y);
      return boundingBox;
    }

    public double Thickness { get; set; }

    public double Elevation { get; set; }

    public Point2D Corner1st { get; set; }

    public Point2D Corner2nd { get; set; }

    public Point2D Corner3rd { get; set; }

    public Point2D Corner4th { get; set; }

    public Point3D Extrusion { get; set; }

    private void LoadSolidData(DwgBitArray ba)
    {
      this.Thickness = ba.ReadBT();
      Console.WriteLine(string.Format("Thickness: {0}", (object) this.Thickness));
      this.Elevation = ba.ReadBD();
      Console.WriteLine(string.Format("Elevation: {0}", (object) this.Elevation));
      this.Corner1st = ba.Read2RD();
      Console.WriteLine(string.Format("Corner1st: {0}", (object) this.Corner1st));
      this.Corner2nd = ba.Read2RD();
      Console.WriteLine(string.Format("Corner2nd: {0}", (object) this.Corner2nd));
      this.Corner3rd = ba.Read2RD();
      Console.WriteLine(string.Format("Corner3rd: {0}", (object) this.Corner3rd));
      this.Corner4th = ba.Read2RD();
      Console.WriteLine(string.Format("Corner4th: {0}", (object) this.Corner4th));
      this.Extrusion = ba.ReadBE();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      ++ba.bitindex;
    }
  }
}
