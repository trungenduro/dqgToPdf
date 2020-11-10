// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.Polyline2D
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class Polyline2D : dqgToPdf.Dwg.R2000.CommonEntityData
  {
    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      return base.GetBoundingBox(objMap);
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      if (this.VertexeHandles.Count == 0)
        return;
      Vertex2D vertex2D1 = objMap[this.VertexeHandles.FirstOrDefault<HandleReference>().getTargetHandle(this.ObjId)] as Vertex2D;
      po.StartStroke(vertex2D1.Point.ToPoint2d());
      for (int index = 1; index < this.VertexeHandles.Count; ++index)
      {
        Vertex2D vertex2D2 = objMap[this.VertexeHandles.FirstOrDefault<HandleReference>().getTargetHandle(this.ObjId)] as Vertex2D;
        po.StrokeLine(vertex2D2.Point.ToPoint2d());
      }
      po.EndStroke();
    }

    public Polyline2D(DwgBitArray ba)
      : base(ba)
    {
      this.LoadPolyline2d(ba);
      this.LoadCommonEntityHandleData(ba);
      this.SeqEndHandle = ba.ReadH();
      Console.WriteLine(string.Format("SeqEndHandle: {0}", (object) this.SeqEndHandle));
      ba.DumpBitIndex();
      Console.WriteLine("");
    }

    private void LoadPolyline2d(DwgBitArray ba)
    {
      this.Flags = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Flags: {0}", (object) this.Flags));
      this.CurveType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("CurveType: {0}", (object) this.CurveType));
      this.StartWidth = ba.ReadBD();
      Console.WriteLine(string.Format("StartWidth: {0}", (object) this.StartWidth));
      this.EndWidth = ba.ReadBD();
      Console.WriteLine(string.Format("EndWidth: {0}", (object) this.EndWidth));
      this.Thickness = ba.ReadBT();
      Console.WriteLine(string.Format("Thickness: {0}", (object) this.Thickness));
      this.Elevation = ba.ReadBD();
      Console.WriteLine(string.Format("Elevation: {0}", (object) this.Elevation));
      this.Extrusion = ba.ReadBE();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
    }

    public int Flags { get; set; }

    public int CurveType { get; set; }

    public double StartWidth { get; set; }

    public double EndWidth { get; set; }

    public double Thickness { get; set; }

    public double Elevation { get; set; }

    public Point3D Extrusion { get; set; }

    public List<HandleReference> VertexeHandles { get; set; } = new List<HandleReference>();

    public HandleReference SeqEndHandle { get; set; }
  }
}
