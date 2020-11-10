// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.Table_Vport
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class Table_Vport : CommonNonEntityData
  {
    public Table_Vport(DwgBitArray ba)
      : base(ba)
    {
      this.LoadTableData(ba);
    }

    public int NumEntries { get; set; }

    public HandleReference Null { get; set; }

    public List<HandleReference> VportHandles { get; set; } = new List<HandleReference>();

    private void LoadTableData(DwgBitArray ba)
    {
      this.NumEntries = ba.ReadBL();
      Console.WriteLine(string.Format("NumEntries: {0}", (object) this.NumEntries));
      Console.WriteLine(string.Format("RemainBits: {0}", (object) ba.Residual));
      ++ba.bitindex;
      this.Null = ba.ReadH();
      Console.WriteLine(string.Format("Null: {0}", (object) this.Null));
      this.LoadXdicHandle(ba);
      for (int index = 0; index < this.NumEntries; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("VportHandle: {0}", (object) handleReference));
        this.VportHandles.Add(handleReference);
      }
      Console.WriteLine(string.Format("RemainBits: {0}", (object) ba.Residual));
    }
  }
}
