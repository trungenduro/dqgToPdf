// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.ShapeFileControl
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class ShapeFileControl : dqgToPdf.Dwg.R2000.CommonNonEntityData
  {
    public ShapeFileControl(DwgBitArray ba)
      : base(ba)
    {
      this.LoadSHapeFileControlData(ba);
    }

    public int NumEntries { get; set; }

    public HandleReference Null { get; set; }

    public List<HandleReference> ShapefileObjHandles { get; set; } = new List<HandleReference>();

    public void LoadSHapeFileControlData(DwgBitArray ba)
    {
      Console.WriteLine("currentBitIndex:" + ba.bitindex.ToString());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      this.NumEntries = ba.ReadBL();
      Console.WriteLine(string.Format("NumEntries: {0}", (object) this.NumEntries));
      Console.WriteLine("currentBitIndex:" + ba.bitindex.ToString());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      this.Null = ba.ReadH();
      Console.WriteLine(string.Format("Null: {0}", (object) this.Null));
      if (!this.XdicMissingFlag)
      {
        this.XdicObjHandle = ba.ReadH();
        Console.WriteLine(string.Format("XdicObjHandle: {0}", (object) this.XdicObjHandle));
      }
      for (int index = 0; index < this.NumEntries; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        this.ShapefileObjHandles.Add(handleReference);
        Console.WriteLine("ShapefileObjHandle:" + handleReference?.ToString());
      }
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("");
    }
  }
}
