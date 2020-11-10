// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.LineTypeControl
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class LineTypeControl : dqgToPdf.Dwg.R2000.CommonNonEntityData
  {
    public LineTypeControl(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLineTypeControlData(ba);
    }

    public int NumEntries { get; set; }

    public HandleReference Null { get; set; }

    public HandleReference ByLayerHandle { get; set; }

    public HandleReference ByBlockHandle { get; set; }

    public List<HandleReference> LineTypesHandles { get; set; } = new List<HandleReference>();

    private void LoadLineTypeControlData(DwgBitArray ba)
    {
      this.NumEntries = ba.ReadBL();
      Console.WriteLine(string.Format("NumEntries: {0}", (object) this.NumEntries));
      this.Null = ba.ReadH();
      Console.WriteLine(string.Format("Null: {0}", (object) this.Null));
      if (!this.XdicMissingFlag)
      {
        this.XdicObjHandle = ba.ReadH();
        Console.WriteLine(string.Format("XdicObjHandle: {0}", (object) this.XdicObjHandle));
      }
      Console.WriteLine(string.Format("RemainBits: {0}", (object) ba.Residual));
      for (int index = 0; index < this.NumEntries; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("LineTypesHandle: {0}", (object) handleReference));
        this.LineTypesHandles.Add(handleReference);
      }
      this.ByLayerHandle = ba.ReadH();
      Console.WriteLine(string.Format("ByLayerHandle: {0}", (object) this.ByLayerHandle));
      this.ByBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("ByBlockHandle: {0}", (object) this.ByBlockHandle));
      Console.WriteLine(string.Format("RemainBits: {0}", (object) ba.Residual));
      Console.WriteLine("");
    }
  }
}
