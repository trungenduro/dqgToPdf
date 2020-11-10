// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.Layer
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class Layer : dqgToPdf.Dwg.R2004.CommonNonEntityData
  {
    public Layer(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLayerData(ba);
    }

    public string EntryName { get; set; }

    public bool Flag64 { get; set; }

    public int XrefIndexPlus1 { get; set; }

    public bool Xdep { get; set; }

    public int Values { get; set; }

    public CmColor ColorIndex { get; set; }

    public HandleReference LayerControlHandle { get; set; }

    public HandleReference ExternalReferenceBlockHandle { get; set; }

    public HandleReference PlotstyleHandle { get; set; }

    public HandleReference MaterialHandle { get; set; }

    public HandleReference LineTypeHandle { get; set; }

    private void LoadLayerData(DwgBitArray ba)
    {
      this.EntryName = ba.ReadSJIS();
      Console.WriteLine("EntryName: " + this.EntryName);
      this.Flag64 = ba.ReadB();
      Console.WriteLine(string.Format("Flag64: {0}", (object) this.Flag64));
      this.XrefIndexPlus1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("XrefIndexPlus1: {0}", (object) this.XrefIndexPlus1));
      this.Xdep = ba.ReadB();
      Console.WriteLine(string.Format("Xdep: {0}", (object) this.Xdep));
      this.Values = (int) ba.ReadBUS();
      Console.WriteLine(string.Format("Values: {0:x4}", (object) this.Values));
      ba.DumpBitIndex();
      this.ColorIndex = ba.ReadCMC();
      Console.WriteLine(string.Format("cmc: {0}", (object) this.ColorIndex));
      this.LayerControlHandle = ba.ReadH();
      Console.WriteLine(string.Format("LayerControlHandle: {0}", (object) this.LayerControlHandle));
      for (int index = 0; index < this.NumReactors; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("ReactorHandle: {0}", (object) handleReference));
        this.ReactorHandles.Add(handleReference);
      }
      if (!this.XdicMissingFlag)
      {
        this.XdicObjHandle = ba.ReadH();
        Console.WriteLine(string.Format("XdicObjHandle: {0}", (object) this.XdicObjHandle));
      }
      this.ExternalReferenceBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("ExternalReferenceBlockHandle: {0}", (object) this.ExternalReferenceBlockHandle));
      this.PlotstyleHandle = ba.ReadH();
      Console.WriteLine(string.Format("PlotstyleHandle: {0}", (object) this.PlotstyleHandle));
      this.LineTypeHandle = ba.ReadH();
      Console.WriteLine(string.Format("LineTypeHandle: {0}", (object) this.LineTypeHandle));
      Console.WriteLine("currentBitIndex:" + ba.bitindex.ToString());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("");
    }
  }
}
