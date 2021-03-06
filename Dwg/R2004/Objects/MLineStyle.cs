﻿// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.MLineStyle
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class MLineStyle : dqgToPdf.Dwg.R2004.CommonNonEntityData
  {
    public MLineStyle(DwgBitArray ba)
      : base(ba)
    {
      this.LoadMLineStyle(ba);
    }

    public string Name { get; set; }

    public string Desc { get; set; }

    public int Flags { get; set; }

    public CmColor FillColor { get; set; }

    public double StartAng { get; set; }

    public double EndAng { get; set; }

    public int NumLinesInStyle { get; set; }

    public List<LineInStyle> LinesInStyle { get; set; } = new List<LineInStyle>();

    public HandleReference ParentHandle { get; set; }

    private void LoadMLineStyle(DwgBitArray ba)
    {
      this.Name = ba.ReadSJIS();
      Console.WriteLine("Name: " + this.Name);
      this.Desc = ba.ReadSJIS();
      Console.WriteLine("Desc: " + this.Desc);
      this.Flags = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Flags: {0}", (object) this.Flags));
      this.FillColor = ba.ReadCMC();
      Console.WriteLine(string.Format("FillColor: {0}", (object) this.FillColor));
      this.StartAng = ba.ReadBD();
      Console.WriteLine(string.Format("StartAng: {0}", (object) this.StartAng));
      this.EndAng = ba.ReadBD();
      Console.WriteLine(string.Format("EndAng: {0}", (object) this.EndAng));
      this.NumLinesInStyle = (int) ba.ReadByte();
      Console.WriteLine(string.Format("NumLinesInStyle: {0}", (object) this.NumLinesInStyle));
      for (int index = 0; index < this.NumLinesInStyle; ++index)
      {
        Console.WriteLine("-----------------------------");
        LineInStyle lineInStyle = new LineInStyle();
        lineInStyle.Offset = ba.ReadBD();
        Console.WriteLine(string.Format("line.Offset: {0}", (object) lineInStyle.Offset));
        lineInStyle.Color = ba.ReadCMC();
        Console.WriteLine(string.Format("line.Color: {0}", (object) lineInStyle.Color));
        lineInStyle.Ltindex = (int) ba.ReadBS();
        Console.WriteLine(string.Format("line.Ltindex: {0}", (object) lineInStyle.Ltindex));
        this.LinesInStyle.Add(lineInStyle);
      }
      ba.DumpBitIndex();
      this.ParentHandle = ba.ReadH();
      Console.WriteLine(string.Format("ParentHandle: {0}", (object) this.ParentHandle));
      this.LoadReactors(ba);
      this.LoadXdicHandle(ba);
      Console.WriteLine(string.Format("Remainbits: {0}", (object) ba.Residual));
    }
  }
}
