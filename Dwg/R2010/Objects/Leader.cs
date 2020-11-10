// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.Leader
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class Leader : CommonEntityData
  {
    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      if (this.numpts < 2)
        return;
      List<Point2D> xYs = new List<Point2D>();
      Point2D point2d = this.Points[0].ToPoint2d();
      for (int index = 1; index < this.Points.Count; ++index)
        xYs.Add(this.Points[index].ToPoint2d());
      po.AddPolyLine(point2d, xYs);
    }

    public Leader(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLeaderData(ba);
      this.LoadCommonEntityHandleData(ba);
      this.AssociatedAnnotation = ba.ReadH();
      Console.WriteLine(string.Format("AssociatedAnnotation: {0}", (object) this.AssociatedAnnotation));
      this.Dimstyle = ba.ReadH();
      Console.WriteLine(string.Format("Dimstyle: {0}", (object) this.Dimstyle));
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("");
      Console.WriteLine("");
    }

    public bool UnknownBit { get; set; }

    public int AnnotType { get; set; }

    public int PathType { get; set; }

    public int numpts { get; set; }

    public List<Point3D> Points { get; set; } = new List<Point3D>();

    public Point3D EndptProj { get; set; }

    public Point3D Extrusion { get; set; }

    public Point3D XDirection { get; set; }

    public Point3D OffsetOblockInsPt { get; set; }

    public Point3D Unknow { get; set; }

    public double BoxHeight { get; set; }

    public double BoxWidth { get; set; }

    public bool HooklineonXdir { get; set; }

    public bool ArrowHeadon { get; set; }

    public int ArrowHedType { get; set; }

    public int Unknown1 { get; set; }

    public bool Unknown2 { get; set; }

    public bool Unknown3 { get; set; }

    public HandleReference AssociatedAnnotation { get; set; }

    public HandleReference Dimstyle { get; set; }

    private void LoadLeaderData(DwgBitArray ba)
    {
      this.UnknownBit = ba.ReadB();
      Console.WriteLine(string.Format("UnknownBit: {0}", (object) this.UnknownBit));
      this.AnnotType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("AnnotType: {0}", (object) this.AnnotType));
      this.PathType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("PathType: {0}", (object) this.PathType));
      this.numpts = ba.ReadBL();
      Console.WriteLine(string.Format("numpts: {0}", (object) this.numpts));
      for (int index = 0; index < this.numpts; ++index)
      {
        Point3D point3D = ba.Read3BD();
        Console.WriteLine(string.Format("point: {0}", (object) point3D));
        this.Points.Add(point3D);
      }
      this.EndptProj = ba.Read3BD();
      Console.WriteLine(string.Format("EndptProj: {0}", (object) this.EndptProj));
      this.Extrusion = ba.Read3BD();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.XDirection = ba.Read3BD();
      Console.WriteLine(string.Format("XDirection: {0}", (object) this.XDirection));
      this.OffsetOblockInsPt = ba.Read3BD();
      Console.WriteLine(string.Format("OffsetOblockInsPt: {0}", (object) this.OffsetOblockInsPt));
      this.BoxHeight = ba.ReadBD();
      Console.WriteLine(string.Format("BoxHeight: {0}", (object) this.BoxHeight));
      this.BoxWidth = ba.ReadBD();
      Console.WriteLine(string.Format("BoxWidth: {0}", (object) this.BoxWidth));
      this.HooklineonXdir = ba.ReadB();
      Console.WriteLine(string.Format("HooklineonXdir: {0}", (object) this.HooklineonXdir));
      this.ArrowHeadon = ba.ReadB();
      Console.WriteLine(string.Format("ArrowHeadon: {0}", (object) this.ArrowHeadon));
      this.ArrowHedType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("ArrowHedType: {0}", (object) this.ArrowHedType));
      this.Unknown1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Unknown1: {0}", (object) this.Unknown1));
      this.Unknown2 = ba.ReadB();
      Console.WriteLine(string.Format("Unknown2: {0}", (object) this.Unknown2));
      this.Unknown3 = ba.ReadB();
      Console.WriteLine(string.Format("Unknown3: {0}", (object) this.Unknown3));
      ++ba.bitindex;
    }
  }
}
