// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.CommonNonEntityData
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg.R2004
{
  public class CommonNonEntityData : dqgToPdf.Dwg.CommonNonEntityData
  {
    public CommonNonEntityData()
    {
    }

    public CommonNonEntityData(DwgBitArray ba)
    {
      this.LoadCommonNonEntityData(ba);
    }

    public override void LoadCommonNonEntityData(DwgBitArray ba)
    {
      Console.WriteLine("CommonNonEntityData Starts-----------------------:");
      Console.WriteLine(string.Format("RemainBits:{0}", (object) ba.Residual));
      this.ObjectType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("ObjectType:{0}", (object) this.ObjectType));
      Console.WriteLine(string.Format("SizeInBit:{0}", (object) ba.ReadRL()));
      this.Handle = ba.ReadH();
      Console.WriteLine(string.Format("ObjectHandle:{0}", (object) this.Handle));
      this.EED = ba.ReadEED();
      this.NumReactors = ba.ReadBL();
      Console.WriteLine(string.Format("NumReactors:{0}", (object) this.NumReactors));
      this.XdicMissingFlag = ba.ReadB();
      Console.WriteLine(string.Format("XdicMissingFlag:{0}", (object) this.XdicMissingFlag));
      Console.WriteLine("CommonNonEntityData Ends-----------------------------:");
    }
  }
}
