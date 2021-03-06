﻿// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.UCSControl
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class UCSControl : CommonNonEntityData
  {
    public UCSControl(DwgBitArray ba)
      : base(ba)
    {
      this.LoadUcsControlData(ba);
    }

    public bool HasBinartyData { get; set; }

    public int NumEntries { get; set; }

    public HandleReference Null { get; set; }

    public List<HandleReference> UcsHandles { get; set; } = new List<HandleReference>();

    public int LinkTarget { get; set; }

    private void LoadUcsControlData(DwgBitArray ba)
    {
      this.HasBinartyData = ba.ReadB();
      Console.WriteLine(string.Format("HasBinartyData: {0}", (object) this.HasBinartyData));
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
        Console.WriteLine(string.Format("UcsHandle: {0}", (object) handleReference));
        this.UcsHandles.Add(handleReference);
      }
      Console.WriteLine(string.Format("RemainBits: {0}", (object) ba.Residual));
    }
  }
}
