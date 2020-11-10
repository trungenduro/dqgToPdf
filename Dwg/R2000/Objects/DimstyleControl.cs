// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.DimstyleControl
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class DimstyleControl : dqgToPdf.Dwg.R2000.CommonNonEntityData
  {
    public DimstyleControl(DwgBitArray ba)
      : base(ba)
    {
      this.LoadDimStyleControl(ba);
    }

    public int NumEntries { get; set; }

    public HandleReference Null { get; set; }

    public List<HandleReference> DimStyleHandles { get; set; } = new List<HandleReference>();

    private void LoadDimStyleControl(DwgBitArray ba)
    {
      this.NumEntries = ba.ReadBL();
      Console.WriteLine(string.Format("NumEntries: {0}", (object) this.NumEntries));
      byte num = ba.ReadByte();
      Console.WriteLine("@byte:" + num.ToString());
      this.Null = ba.ReadH();
      Console.WriteLine(string.Format("Null: {0}", (object) this.Null));
      this.LoadXdicHandle(ba);
      this.LoadReactors(ba);
      ba.DumpBitIndex();
      for (int index = 0; index < this.NumEntries; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine("DimStyleHandle:" + handleReference?.ToString());
        this.DimStyleHandles.Add(handleReference);
      }
      if (num == (byte) 1)
        Console.WriteLine("h2:" + ba.ReadH()?.ToString());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("");
    }
  }
}
