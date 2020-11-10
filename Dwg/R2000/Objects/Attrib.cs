// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.Attrib
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class Attrib : dqgToPdf.Dwg.R2000.CommonEntityData
  {
    public int DataFlags { get; set; }

    public double Elevation { get; set; }

    public Point2D InsertionPt { get; set; }

    public Point2D AlignmentPt { get; set; }

    public Point3D Extrusion { get; set; }

    public double Thickness { get; set; }

    public double ObliqueAng { get; set; }

    public double RotationAng { get; set; }

    public double Height { get; set; }

    public double WidthFactor { get; set; }

    public string TextValue { get; set; }

    public int Generation { get; set; }

    public int HorizAlign { get; set; }

    public int VertAlign { get; set; }

    public string Tag { get; set; }

    public int FieldLength { get; set; }

    public int Flags { get; set; }

    public HandleReference StyleHandle { get; set; }

    public Attrib(DwgBitArray ba)
      : base(ba)
    {
      this.LoadAttrib(ba);
      this.LoadCommonEntityHandleData(ba);
      this.StyleHandle = ba.ReadH();
      Console.WriteLine(string.Format("StyleHandle: {0}", (object) this.StyleHandle));
      ba.DumpBitIndex();
      Console.WriteLine();
    }

    private void LoadAttrib(DwgBitArray ba)
    {
      this.DataFlags = (int) ba.ReadByte();
      Console.WriteLine(string.Format("DataFlags: {0}", (object) this.DataFlags));
      if ((this.DataFlags & 1) == 0)
      {
        this.Elevation = ba.ReadRD();
        Console.WriteLine(string.Format("Elevation: {0}", (object) this.Elevation));
      }
      this.InsertionPt = ba.Read2RD();
      Console.WriteLine(string.Format("InsertionPt: {0}", (object) this.InsertionPt));
      if ((this.DataFlags & 2) == 0)
      {
        this.AlignmentPt = ba.Read2DD(this.InsertionPt.x, this.InsertionPt.y);
        Console.WriteLine(string.Format("AlignmentPt: {0}", (object) this.AlignmentPt));
      }
      this.Extrusion = ba.ReadBE();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.Thickness = ba.ReadBT();
      Console.WriteLine(string.Format("Thickness: {0}", (object) this.Thickness));
      if ((this.DataFlags & 4) == 0)
      {
        this.ObliqueAng = ba.ReadRD();
        Console.WriteLine(string.Format("ObliqueAng: {0}", (object) this.ObliqueAng));
      }
      if ((this.DataFlags & 8) == 0)
      {
        this.RotationAng = ba.ReadRD();
        Console.WriteLine(string.Format("RotationAng: {0}", (object) this.RotationAng));
      }
      this.Height = ba.ReadRD();
      Console.WriteLine(string.Format("Height: {0}", (object) this.Height));
      if ((this.DataFlags & 16) == 0)
      {
        this.WidthFactor = ba.ReadRD();
        Console.WriteLine(string.Format("WidthFactor: {0}", (object) this.WidthFactor));
      }
      this.TextValue = ba.ReadSJIS();
      Console.WriteLine("TextValue: " + this.TextValue);
      if ((this.DataFlags & 32) == 0)
      {
        this.Generation = (int) ba.ReadBS();
        Console.WriteLine(string.Format("Generation: {0}", (object) this.Generation));
      }
      if ((this.DataFlags & 64) == 0)
      {
        this.HorizAlign = (int) ba.ReadBS();
        Console.WriteLine(string.Format("HorizAlign: {0}", (object) this.HorizAlign));
      }
      if ((this.DataFlags & 128) == 0)
      {
        this.VertAlign = (int) ba.ReadBS();
        Console.WriteLine(string.Format("VertAlign: {0}", (object) this.VertAlign));
      }
      this.Tag = ba.ReadSJIS();
      Console.WriteLine("Tag: " + this.Tag);
      this.FieldLength = (int) ba.ReadBS();
      Console.WriteLine(string.Format("FieldLength: {0}", (object) this.FieldLength));
      this.Flags = (int) ba.ReadByte();
      Console.WriteLine(string.Format("Flags: {0}", (object) this.Flags));
      ba.DumpBitIndex();
    }
  }
}
