// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.Dictionary
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class Dictionary : CommonNonEntityData
  {
    public Dictionary(DwgBitArray ba)
      : base(ba)
    {
      this.LoadDictionaryData(ba);
    }

    public int NumItems { get; set; }

    public int CloningFlag { get; set; }

    public int HardOwnerFlag { get; set; }

    public List<string> Texts { get; set; } = new List<string>();

    public List<HandleReference> Handles { get; set; } = new List<HandleReference>();

    public List<HandleReference> Reactors { get; set; } = new List<HandleReference>();

    public HandleReference ParentHandle { get; set; }

    private void LoadDictionaryData(DwgBitArray ba)
    {
      this.NumItems = ba.ReadBL();
      Console.WriteLine(string.Format("NumItems:{0}", (object) this.NumItems));
      this.CloningFlag = (int) ba.ReadBS();
      Console.WriteLine(string.Format("CloningFlag:{0}", (object) this.CloningFlag));
      this.HardOwnerFlag = (int) ba.ReadByte();
      Console.WriteLine(string.Format("HardOwnerFlag:{0}", (object) this.HardOwnerFlag));
      for (int index = 0; index < this.NumItems; ++index)
      {
        string str = ba.ReadTU();
        Console.WriteLine("TextValue:\"" + str + "\"");
        this.Texts.Add(str);
      }
      ba.DumpBitIndex();
      Console.WriteLine("-------------------------");
      if (this.NumItems > 0)
        ba.bitindex += 17;
      else
        ++ba.bitindex;
      ba.DumpBitIndex();
      Console.WriteLine(string.Format("HandleIndex: {0}", (object) this.Handle.GetHandleOffsetVal()));
      this.ParentHandle = ba.ReadH();
      Console.WriteLine(string.Format("ParentHandle: {0}", (object) this.ParentHandle));
      this.LoadReactors(ba);
      this.LoadXdicHandle(ba);
      for (int index = 0; index < this.NumItems; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("Handle:\"{0}\"", (object) handleReference));
        this.Handles.Add(handleReference);
      }
      Console.WriteLine(string.Format("bit remain: {0}", (object) ba.Residual));
      Console.WriteLine("------------------------------------------------");
      Console.WriteLine("");
      Console.WriteLine("");
    }
  }
}
