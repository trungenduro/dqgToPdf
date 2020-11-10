// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.CommonNonEntityData
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg
{
  public class CommonNonEntityData
  {
    public int SizeInBitsHandle { get; set; }

    public int ObjectType { get; set; }

    public HandleReference Handle { get; set; }

    public HandleReference XdicObjHandle { get; set; }

    public List<ExtendedEntityData> EED { get; set; } = new List<ExtendedEntityData>();

    public int NumReactors { get; set; }

    public bool XdicMissingFlag { get; set; }

    public List<HandleReference> ReactorHandles { get; set; } = new List<HandleReference>();

    public int ObjId
    {
      get
      {
        return this.Handle.GetHandleOffsetVal();
      }
    }

    public CommonNonEntityData()
    {
    }

    public CommonNonEntityData(DwgBitArray ba)
    {
      this.LoadCommonNonEntityData(ba);
    }

    public virtual void LoadCommonNonEntityData(DwgBitArray ba)
    {
      Console.WriteLine("CommonNonEntityData Starts-----------------------:");
      this.SizeInBitsHandle = ba.ReadModuleChars(false);
      Console.WriteLine(string.Format("SizeInBitsHandle:{0}", (object) this.SizeInBitsHandle));
      Console.WriteLine(string.Format("RemainBits:{0}", (object) ba.Residual));
      this.ObjectType = ba.ReadOT();
      Console.WriteLine(string.Format("ObjectType:{0}", (object) this.ObjectType));
      this.Handle = ba.ReadH();
      Console.WriteLine(string.Format("ObjectHandle:{0}", (object) this.Handle));
      this.EED = ba.ReadEED();
      this.NumReactors = ba.ReadBL();
      Console.WriteLine(string.Format("NumReactors:{0}", (object) this.NumReactors));
      this.XdicMissingFlag = ba.ReadB();
      Console.WriteLine(string.Format("XdicMissingFlag:{0}", (object) this.XdicMissingFlag));
      Console.WriteLine("CommonNonEntityData Ends-----------------------------:");
    }

    public void LoadXdicHandle(DwgBitArray ba)
    {
      if (this.XdicMissingFlag)
        return;
      this.XdicObjHandle = ba.ReadH();
      Console.WriteLine(string.Format("XdicObjHandle: {0}", (object) this.XdicObjHandle));
    }

    public void LoadReactors(DwgBitArray ba)
    {
      for (int index = 0; index < this.NumReactors; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("ReactorHandle: {0}", (object) handleReference));
        this.ReactorHandles.Add(handleReference);
      }
    }

    public void LoadTextData(DwgBitArray ba)
    {
      ba.bitindex = ba.BitMaxLength - this.SizeInBitsHandle;
      Console.WriteLine("---------------TEXT-----");
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      --ba.bitindex;
      bool flag = ba.ReadB();
      Console.WriteLine(string.Format("StringStreamFlag: {0}", (object) flag));
      if (!flag)
        return;
      int num1 = 0;
      --ba.bitindex;
      int num2;
      while (true)
      {
        ba.bitindex -= 16;
        int num3 = (int) ba.ReadByte() + (int) ba.ReadByte() * 256;
        ba.bitindex -= 16;
        num2 = (num1 << 15) + num3;
        if (num3 > 32768)
          num1 = num2 - 32768;
        else
          break;
      }
      ba.bitindex -= num2;
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("text: " + ba.ReadTU());
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
    }
  }
}
