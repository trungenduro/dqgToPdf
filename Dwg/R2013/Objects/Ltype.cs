// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Ltype
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Ltype : CommonNonEntityData
  {
    public Ltype(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLtypeData(ba);
    }

    public string EntryName { get; set; }

    public bool Flag64 { get; set; }

    public int XrefIndexPlus1 { get; set; }

    public bool Xdep { get; set; }

    public string Description { get; set; }

    public double PatternLen { get; set; }

    public int Alignement { get; set; }

    public int NumDashes { get; set; }

    public List<Ltype.Dash> Dashes { get; set; } = new List<Ltype.Dash>();

    public HandleReference LtypeControl { get; set; }

    public HandleReference ExterenalReferenceBlockHandle { get; set; }

    public List<HandleReference> ShapefileForDash { get; set; } = new List<HandleReference>();

    public List<HandleReference> ShapefileForShape { get; set; }

    private void LoadLtypeData(DwgBitArray ba)
    {
      this.Flag64 = ba.ReadB();
      Console.WriteLine(string.Format("Flag64: {0}", (object) this.Flag64));
      this.XrefIndexPlus1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("XrefIndexPlus1: {0}", (object) this.XrefIndexPlus1));
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      this.PatternLen = ba.ReadBD();
      Console.WriteLine(string.Format("PatternLen: {0}", (object) this.PatternLen));
      this.Alignement = (int) ba.ReadByte();
      Console.WriteLine(string.Format("Alignement: {0}", (object) this.Alignement));
      this.NumDashes = (int) ba.ReadByte();
      Console.WriteLine(string.Format("NumDashes: {0}", (object) this.NumDashes));
      for (int index = 0; index < this.NumDashes; ++index)
      {
        Ltype.Dash dash = new Ltype.Dash();
        dash.DashLength = ba.ReadBD();
        Console.WriteLine(string.Format("DashLength: {0}", (object) dash.DashLength));
        dash.ComplesShapeCode = (int) ba.ReadBS();
        Console.WriteLine(string.Format("ComplesShapeCode: {0}", (object) dash.ComplesShapeCode));
        dash.Xoffset = ba.ReadRD();
        Console.WriteLine(string.Format("Xoffset: {0}", (object) dash.Xoffset));
        dash.Yoffset = ba.ReadRD();
        Console.WriteLine(string.Format("Yoffset: {0}", (object) dash.Yoffset));
        dash.Scale = ba.ReadBD();
        Console.WriteLine(string.Format("Scale: {0}", (object) dash.Scale));
        dash.Rotation = ba.ReadBD();
        Console.WriteLine(string.Format("Rotation: {0}", (object) dash.Rotation));
        dash.Shapeflag = (int) ba.ReadBS();
        Console.WriteLine(string.Format("Shapeflag: {0}", (object) dash.Shapeflag));
        if (dash.Shapeflag != 0)
          throw new NotImplementedException();
        this.Dashes.Add(dash);
      }
      this.EntryName = ba.ReadTU();
      Console.WriteLine("EntryName: " + this.EntryName);
      this.Description = ba.ReadTU();
      Console.WriteLine("Description: " + this.Description);
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      ba.bitindex += 17;
      this.LtypeControl = ba.ReadH();
      Console.WriteLine("LtypeControl:" + this.LtypeControl?.ToString());
      this.LoadReactors(ba);
      this.LoadXdicHandle(ba);
      this.ExterenalReferenceBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("ExterenalReferenceBlockHandle: {0}", (object) this.ExterenalReferenceBlockHandle));
      for (int index = 0; index < this.NumDashes; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("ShapefileForDash: {0}", (object) handleReference));
        this.ShapefileForDash.Add(handleReference);
      }
      Console.WriteLine(string.Format("Remain Bits: {0}", (object) ba.Residual));
      Console.WriteLine("");
    }

    public class Dash
    {
      public double DashLength { get; set; }

      public int ComplesShapeCode { get; set; }

      public double Xoffset { get; set; }

      public double Yoffset { get; set; }

      public double Scale { get; set; }

      public double Rotation { get; set; }

      public int Shapeflag { get; set; }
    }
  }
}
