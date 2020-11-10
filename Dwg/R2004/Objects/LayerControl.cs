// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.LayerControl
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class LayerControl : dqgToPdf.Dwg.R2004.CommonNonEntityData
  {
    public int NumEntries { get; set; }

    public HandleReference Null { get; set; }

    public List<HandleReference> LayerObjsHandles { get; set; } = new List<HandleReference>();

    public LayerControl(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLayerControlData(ba);
    }

    private void LoadLayerControlData(DwgBitArray ba)
    {
      this.NumEntries = ba.ReadBL();
      Console.WriteLine(string.Format("NumEntries:{0}", (object) this.NumEntries));
      this.Null = ba.ReadH();
      Console.WriteLine(string.Format("Null: {0}", (object) this.Null));
      for (int index = 0; index < this.NumReactors; ++index)
        this.ReactorHandles.Add(ba.ReadH());
      if (!this.XdicMissingFlag)
        this.XdicObjHandle = ba.ReadH();
      for (int index = 0; index < this.NumEntries; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("LayerObjsHandle: {0}", (object) handleReference));
        this.LayerObjsHandles.Add(handleReference);
      }
      Console.WriteLine("currentBitIndex:" + ba.bitindex.ToString());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
    }
  }
}
