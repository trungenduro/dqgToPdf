// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.ShapeFile
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class ShapeFile : dqgToPdf.Dwg.R2004.CommonNonEntityData
  {
    public ShapeFile(DwgBitArray ba)
      : base(ba)
    {
      this.LoadShapeFileData(ba);
    }

    public string EntryName { get; set; }

    public bool Flag64 { get; set; }

    public int XrefIndexPlus1 { get; set; }

    public bool Xdep { get; set; }

    public bool Vertical { get; set; }

    public bool IsShapefile { get; set; }

    public double FixedHeight { get; set; }

    public double WidthFactor { get; set; }

    public double ObliqueAngle { get; set; }

    public int Genaration { get; set; }

    public double LastHeight { get; set; }

    public string FontName { get; set; }

    public string BigFontName { get; set; }

    public HandleReference ShapefileControlHandle { get; set; }

    public HandleReference ExtReferenceBlockHandle { get; set; }

    private void LoadShapeFileData(DwgBitArray ba)
    {
      this.EntryName = ba.ReadSJIS();
      Console.WriteLine("EntryName: " + this.EntryName);
      this.Flag64 = ba.ReadB();
      Console.WriteLine("Flag64: " + this.Flag64.ToString());
      this.XrefIndexPlus1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("XrefIndexPlus1: {0}", (object) this.XrefIndexPlus1));
      this.Xdep = ba.ReadB();
      Console.WriteLine(string.Format("Xdep: {0}", (object) this.Xdep));
      this.Vertical = ba.ReadB();
      Console.WriteLine(string.Format("Vertical: {0}", (object) this.Vertical));
      this.IsShapefile = ba.ReadB();
      Console.WriteLine(string.Format("IsShapefile: {0}", (object) this.IsShapefile));
      ba.DumpBitIndex();
      this.FixedHeight = ba.ReadBD();
      Console.WriteLine(string.Format("FixedHeight: {0}", (object) this.FixedHeight));
      this.WidthFactor = ba.ReadBD();
      Console.WriteLine(string.Format("WidthFactor: {0}", (object) this.WidthFactor));
      this.ObliqueAngle = ba.ReadBD();
      Console.WriteLine(string.Format("ObliqueAngle: {0}", (object) this.ObliqueAngle));
      this.Genaration = (int) ba.ReadByte();
      Console.WriteLine(string.Format("Genaration: {0}", (object) this.Genaration));
      this.LastHeight = ba.ReadBD();
      Console.WriteLine(string.Format("LastHeight: {0}", (object) this.LastHeight));
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      this.FontName = ba.ReadSJIS();
      Console.WriteLine("FontName: " + this.FontName);
      this.BigFontName = ba.ReadSJIS();
      Console.WriteLine("BigFontName: " + this.BigFontName);
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine(string.Format("ShapefileControlHandle: {0}", (object) ba.ReadH()));
      for (int index = 0; index < this.NumReactors; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        this.ReactorHandles.Add(handleReference);
        Console.WriteLine("ShapefileObjHandle:" + handleReference?.ToString());
      }
      if (!this.XdicMissingFlag)
      {
        this.XdicObjHandle = ba.ReadH();
        Console.WriteLine(string.Format("XdicObjHandle: {0}", (object) this.XdicObjHandle));
      }
      this.ExtReferenceBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("ExtReferenceBlockHandle: {0}", (object) this.ExtReferenceBlockHandle));
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("");
    }
  }
}
