// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.AppID
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class AppID : dqgToPdf.Dwg.R2000.CommonNonEntityData
  {
    public AppID(DwgBitArray ba)
      : base(ba)
    {
      this.LoadAppID(ba);
    }

    public bool Flag64 { get; set; }

    public int XrefIndexPlus1 { get; set; }

    public bool Xdep { get; set; }

    public int Unknown { get; set; }

    public string EntryName { get; set; }

    public HandleReference AppControlHandle { get; set; }

    public HandleReference ExternalReferenceBlockHandle { get; set; }

    private void LoadAppID(DwgBitArray ba)
    {
      this.EntryName = ba.ReadSJIS();
      Console.WriteLine("EntryName: " + this.EntryName);
      this.Flag64 = ba.ReadB();
      Console.WriteLine(string.Format("Flag64: {0}", (object) this.Flag64));
      this.XrefIndexPlus1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("XrefIndexPlus1: {0}", (object) this.XrefIndexPlus1));
      this.Xdep = ba.ReadB();
      Console.WriteLine(string.Format("Xdep: {0}", (object) this.Xdep));
      this.Unknown = (int) ba.ReadByte();
      Console.WriteLine(string.Format("Unknown: {0}", (object) this.Unknown));
      this.AppControlHandle = ba.ReadH();
      Console.WriteLine(string.Format("AppControlHandle: {0}", (object) this.AppControlHandle));
      this.LoadReactors(ba);
      this.LoadXdicHandle(ba);
      this.ExternalReferenceBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("ExternalReferenceBlockHandle: {0}", (object) this.ExternalReferenceBlockHandle));
      Console.WriteLine(string.Format("Remainbits: {0}", (object) ba.Residual));
      Console.WriteLine();
    }
  }
}
