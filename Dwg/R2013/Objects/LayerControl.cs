// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.LayerControl
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class LayerControl : CommonNonEntityData
  {
    public int NumEntries { get; set; }

    public bool HasBinaryData { get; set; }

    public HandleReference Null { get; set; }

    public List<HandleReference> LayerObjsHandles { get; set; } = new List<HandleReference>();

    public LayerControl(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLayerControlData(ba);
    }

    private void LoadLayerControlData(DwgBitArray ba)
    {
      this.HasBinaryData = ba.ReadB();
      Console.WriteLine(string.Format("HasBinaryData:{0}", (object) this.HasBinaryData));
      this.NumEntries = ba.ReadBL();
      Console.WriteLine(string.Format("NumEntries:{0}", (object) this.NumEntries));
      ba.ReadB();
      Console.WriteLine(string.Format("RemainBits:{0}", (object) ba.Residual));
      this.Null = ba.ReadH();
      for (int index = 0; index < this.NumReactors; ++index)
        this.ReactorHandles.Add(ba.ReadH());
      if (!this.XdicMissingFlag)
        this.XdicObjHandle = ba.ReadH();
      for (int index = 0; index < this.NumEntries; ++index)
        this.LayerObjsHandles.Add(ba.ReadH());
      Console.WriteLine("currentBitIndex:" + ba.bitindex.ToString());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
    }
  }
}
