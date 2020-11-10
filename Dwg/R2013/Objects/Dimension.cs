// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Dimension
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Dimension : CommonEntityData
  {
    public Dimension(DwgBitArray ba)
      : base(ba)
    {
      this.LoadCommonDimensionData(ba);
    }

    protected void SetDimensionColor(PageObject po, Dictionary<int, object> objMap)
    {
    }

    protected void DrawAnonymousBlock(PageObject po, Dictionary<int, object> objMap)
    {
      BlockHeader blockHeader = (BlockHeader) objMap[this.AnonymousBlockHandle.getTargetHandle(this.ObjId)];
      PageObject po1 = po;
      Dictionary<int, object> objmap = objMap;
      Point3D insertPt = new Point3D();
      Point3D scale = new Point3D();
      scale.x = this.InsXScale;
      scale.y = this.InsYScale;
      scale.z = this.InsZScale;
      double insRotation = this.InsRotation;
      Reader.DrawBlockHeader(blockHeader, po1, objmap, insertPt, scale, insRotation, false);
    }

    public int Version { get; set; }

    public Point3D Extrusion { get; set; }

    public Point2D TextMidPt { get; set; }

    public double Elevation { get; set; }

    public int Flags1 { get; set; }

    public string UserText { get; set; }

    public double TextRotation { get; set; }

    public double HorizDir { get; set; }

    public double InsXScale { get; set; }

    public double InsYScale { get; set; }

    public double InsZScale { get; set; }

    public double InsRotation { get; set; }

    public double InRotation { get; set; }

    public int AttachmentPoint { get; set; }

    public int LinespacingStyle { get; set; }

    public double LinespacingFactor { get; set; }

    public double ActualMeasurement { get; set; }

    public bool Unknow { get; set; }

    public bool FlipArrowl { get; set; }

    public bool FlipArrow2 { get; set; }

    public Point2D pt12 { get; set; }

    private void LoadCommonDimensionData(DwgBitArray ba)
    {
      this.Version = (int) ba.ReadByte();
      Console.WriteLine(string.Format("Version: {0}", (object) this.Version));
      this.Extrusion = ba.Read3BD();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.TextMidPt = ba.Read2RD();
      Console.WriteLine(string.Format("TextMidPt: {0}", (object) this.TextMidPt));
      this.Elevation = ba.ReadBD();
      Console.WriteLine(string.Format("Elevation: {0}", (object) this.Elevation));
      this.Flags1 = (int) ba.ReadByte();
      Console.WriteLine(string.Format("Flags1: {0}", (object) this.Flags1));
      this.TextRotation = ba.ReadBD();
      Console.WriteLine(string.Format("TextRotation: {0}", (object) this.TextRotation));
      this.HorizDir = ba.ReadBD();
      Console.WriteLine(string.Format("HorizDir: {0}", (object) this.HorizDir));
      this.InsXScale = ba.ReadBD();
      Console.WriteLine(string.Format("InsXScale: {0}", (object) this.InsXScale));
      this.InsYScale = ba.ReadBD();
      Console.WriteLine(string.Format("InsYScale: {0}", (object) this.InsYScale));
      this.InsZScale = ba.ReadBD();
      Console.WriteLine(string.Format("InsZScale: {0}", (object) this.InsZScale));
      this.InsRotation = ba.ReadBD();
      Console.WriteLine(string.Format("InsRotation: {0}", (object) this.InsRotation));
      this.AttachmentPoint = (int) ba.ReadBS();
      Console.WriteLine(string.Format("AttachmentPoint: {0}", (object) this.AttachmentPoint));
      this.LinespacingStyle = (int) ba.ReadBS();
      Console.WriteLine(string.Format("LinespacingStyle: {0}", (object) this.LinespacingStyle));
      this.LinespacingFactor = ba.ReadBD();
      Console.WriteLine(string.Format("LinespacingFactor: {0}", (object) this.LinespacingFactor));
      this.ActualMeasurement = ba.ReadBD();
      Console.WriteLine(string.Format("ActualMeasurement: {0}", (object) this.ActualMeasurement));
      this.Unknow = ba.ReadB();
      Console.WriteLine(string.Format("Unknow: {0}", (object) this.Unknow));
      this.FlipArrowl = ba.ReadB();
      Console.WriteLine(string.Format("FlipArrowl: {0}", (object) this.FlipArrowl));
      this.FlipArrow2 = ba.ReadB();
      Console.WriteLine(string.Format("FlipArrow2: {0}", (object) this.FlipArrow2));
      this.pt12 = ba.Read2RD();
      Console.WriteLine(string.Format("pt12: {0}", (object) this.pt12));
    }

    public HandleReference DimstyleHandle { get; set; }

    public HandleReference AnonymousBlockHandle { get; set; }

    protected void LoadDimensionHandle(DwgBitArray ba)
    {
      this.DimstyleHandle = ba.ReadH();
      Console.WriteLine(string.Format("DimStyleHandle: {0}", (object) this.DimstyleHandle));
      this.AnonymousBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("AnonymousBlockHandle: {0}", (object) this.AnonymousBlockHandle));
    }
  }
}
