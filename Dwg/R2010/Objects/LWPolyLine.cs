// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.LWPolyLine
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class LWPolyLine : CommonEntityData2010
  {
    public LWPolyLine(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLWPliyLine(ba);
      this.LoadCommonEntityHandleData(ba);
      Console.WriteLine();
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      List<Point2D> xYs = new List<Point2D>();
      foreach (Point2D point2D in this.XY)
        xYs.Add(point2D.Clone());
      if ((this.FLag & 512) != 0)
        xYs.Add(this.pt0.Clone());
      po.AddPolyLine(this.pt0, xYs);
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.AddBoudingBox(this.pt0.x, this.pt0.y);
      foreach (Point2D point2D in this.XY)
        boundingBox.AddBoudingBox(point2D.x, point2D.y);
      return boundingBox;
    }

    public int FLag { get; set; }

    public double ConstWidth { get; set; }

    public double Elevation { get; set; }

    public double Thickness { get; set; }

    public Point3D Normal { get; set; }

    public int NumPoints { get; set; }

    public int NumBulges { get; set; }

    public int VertexIdCount { get; set; }

    public int NumWidths { get; set; }

    public Point2D pt0 { get; set; }

    public List<Point2D> XY { get; set; } = new List<Point2D>();

    public List<double> Bulges { get; set; } = new List<double>();

    public List<int> VertexIds { get; set; } = new List<int>();

    public List<Point2D> Widths { get; set; } = new List<Point2D>();

    private void LoadLWPliyLine(DwgBitArray ba)
    {
      this.FLag = (int) ba.ReadBS();
      Console.WriteLine(string.Format("FLag: {0}", (object) this.FLag));
      if ((this.FLag & 4) != 0)
      {
        this.ConstWidth = ba.ReadBD();
        Console.WriteLine(string.Format("ConstWidth: {0}", (object) this.ConstWidth));
      }
      if ((this.FLag & 8) != 0)
      {
        this.Elevation = ba.ReadBD();
        Console.WriteLine(string.Format("Elevation: {0}", (object) this.Elevation));
      }
      if ((this.FLag & 2) != 0)
      {
        this.Thickness = ba.ReadBD();
        Console.WriteLine(string.Format("Thickness: {0}", (object) this.Thickness));
      }
      if ((this.FLag & 1) != 0)
      {
        this.Normal = ba.Read3BD();
        Console.WriteLine(string.Format("Normal: {0}", (object) this.Normal));
      }
      this.NumPoints = ba.ReadBL();
      Console.WriteLine(string.Format("NumPoints: {0}", (object) this.NumPoints));
      if ((this.FLag & 16) != 0)
      {
        this.NumBulges = ba.ReadBL();
        Console.WriteLine(string.Format("NumBulges: {0}", (object) this.NumBulges));
      }
      if ((this.FLag & 1024) != 0)
      {
        this.VertexIdCount = ba.ReadBL();
        Console.WriteLine(string.Format("VertexIdCount: {0}", (object) this.VertexIdCount));
      }
      if ((this.FLag & 32) != 0)
      {
        this.NumWidths = ba.ReadBL();
        Console.WriteLine(string.Format("NumWidths: {0}", (object) this.NumWidths));
      }
      this.pt0 = ba.Read2RD();
      Console.WriteLine(string.Format("pt0: {0}", (object) this.pt0));
      Point2D point2D1 = this.pt0.Clone();
      for (int index = 0; index < this.NumPoints - 1; ++index)
      {
        Point2D point2D2 = ba.Read2DD(point2D1.x, point2D1.y);
        Console.WriteLine(string.Format("xy: {0}", (object) point2D2));
        this.XY.Add(point2D2);
        point2D1 = point2D2.Clone();
      }
      for (int index = 0; index < this.NumBulges; ++index)
      {
        double num = ba.ReadBD();
        Console.WriteLine(string.Format("bulge: {0}", (object) num));
        this.Bulges.Add(num);
      }
      for (int index = 0; index < this.VertexIdCount; ++index)
      {
        int num = ba.ReadBL();
        Console.WriteLine(string.Format("vertexId: {0}", (object) num));
        this.VertexIds.Add(num);
      }
      for (int index = 0; index < this.NumWidths; ++index)
      {
        Point2D point2D2 = ba.Read2BD();
        Console.WriteLine(string.Format("width: {0}", (object) point2D2));
        this.Widths.Add(point2D2);
      }
      ++ba.bitindex;
    }
  }
}
