// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.CommonEntityData
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;

namespace dqgToPdf.Dwg.R2000
{
  public class CommonEntityData : dqgToPdf.Dwg.CommonEntityData
  {
    public CommonEntityData()
    {
    }

    public CommonEntityData(DwgBitArray ba)
    {
      this.LoadCommonEntityData(ba);
    }

    public bool NoLinks { get; set; }

    public HandleReference PreviousEntityHandle { get; set; }

    public HandleReference NextEntityHandle { get; set; }

    public override void LoadCommonEntityData(DwgBitArray ba)
    {
      Console.WriteLine(string.Format("LoadCommonEntityData Starts: --------------{0}--------", (object) ba.Residual));
      this.Type = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Type:{0}", (object) this.Type));
      Console.WriteLine(string.Format("SizeOfObjectDataInBits:{0}", (object) ba.ReadRL()));
      this.ObjectsHandle = ba.ReadH();
      Console.WriteLine(string.Format("ObjectsHandle:{0}", (object) this.ObjectsHandle));
      this.EED = ba.ReadEED();
      this.FlagGraphicImage = ba.ReadB();
      Console.WriteLine(string.Format("FlagGraphicImage:{0}", (object) this.FlagGraphicImage));
      if (this.FlagGraphicImage)
      {
        this.SizeOfGraphicImageInBytes = (long) ba.ReadRL();
        Console.WriteLine(string.Format("SizeOfGraphicImageInBytes:{0}", (object) this.SizeOfGraphicImageInBytes));
        this.TheGraphicImage = ba.ReadBytes((int) this.SizeOfGraphicImageInBytes);
      }
      this.EntMode = ba.ReadBB();
      Console.WriteLine(string.Format("EntMode: {0:x2}", (object) this.EntMode));
      this.NumReactors = ba.ReadBL();
      Console.WriteLine(string.Format("NumReactors: {0}", (object) this.NumReactors));
      this.NoLinks = ba.ReadB();
      Console.WriteLine(string.Format("XdicMissingFlag: {0}", (object) this.XdicMissingFlag));
      this.Entitycolor = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Entitycolor: {0:x}", (object) this.Entitycolor));
      if ((this.Entitycolor & 32768) != 0)
      {
        int num = (int) ba.ReadBS();
        this.RGBValue = new int?((this.Entitycolor & (int) byte.MaxValue) << 16 + (int) ba.ReadBUS());
        Console.WriteLine(string.Format("RGBValue: {0:x}", (object) this.RGBValue));
      }
      if ((this.Entitycolor & 16384) != 0)
      {
        NotImplementedException implementedException = new NotImplementedException();
      }
      if ((this.Entitycolor & 8192) != 0)
      {
        this.TransParency = new int?(ba.ReadBL());
        Console.WriteLine(string.Format("TransParency: {0:x}", (object) this.TransParency));
      }
      if ((this.Entitycolor & 61440) == 0)
      {
        this.ColorIndex = new int?(this.Entitycolor);
        Console.WriteLine(string.Format("ColorIndex: {0}", (object) this.ColorIndex));
      }
      this.LinetypeScale = ba.ReadBD();
      Console.WriteLine(string.Format("LinetypeScale:{0}", (object) this.LinetypeScale));
      this.LineTypeFlags = ba.ReadBB();
      this.PlotstyleFlags = ba.ReadBB();
      Console.WriteLine(string.Format("LineTypeFlags:{0:x2}", (object) this.LineTypeFlags));
      Console.WriteLine(string.Format("PlotstyleFlags:{0:x2}", (object) this.PlotstyleFlags));
      this.Invisibility = (int) ba.ReadBS();
      Console.WriteLine("Invisibility:" + this.Invisibility.ToString());
      this.LineWeight = ba.ReadByte();
      Console.WriteLine("LineWeight:" + this.LineWeight.ToString());
      Console.WriteLine("remains:" + ba.Residual.ToString());
      Console.WriteLine("LoadCommonEntityData Ends: ----------------------");
    }

    public override void LoadCommonEntityHandleData(DwgBitArray ba)
    {
      Console.WriteLine("LoadCommonEntityHandleData Starts: ----------------------");
      ba.DumpBitIndex();
      if (this.EntMode == 0)
      {
        this.OwnereRefHandle = ba.ReadH();
        Console.WriteLine(string.Format("OwnereRefHandle: {0}", (object) this.OwnereRefHandle));
      }
      for (int index = 0; index < this.NumReactors; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        this.Reactors.Add(handleReference);
        Console.WriteLine(string.Format("Reactor: {0}", (object) handleReference));
      }
      this.xDicobjHandle = ba.ReadH();
      Console.WriteLine(string.Format("xDicobjHandle: {0}", (object) this.xDicobjHandle));
      if (!this.NoLinks)
      {
        this.PreviousEntityHandle = ba.ReadH();
        Console.WriteLine(string.Format("PreviousEntityHandle: {0}", (object) this.PreviousEntityHandle));
        this.NextEntityHandle = ba.ReadH();
        Console.WriteLine(string.Format("NextEntityHandle: {0}", (object) this.NextEntityHandle));
      }
      if ((this.Entitycolor & 16384) != 0)
      {
        this.ColorBookColorHandle = ba.ReadH();
        Console.WriteLine(string.Format("ColorBookColorHandle: {0}", (object) this.ColorBookColorHandle));
      }
      this.LayerHandle = ba.ReadH();
      Console.WriteLine(string.Format("LayerHandle: {0}", (object) this.LayerHandle));
      if (this.LineTypeFlags == 3)
      {
        this.LtypeHandle = ba.ReadH();
        Console.WriteLine(string.Format("LtypeHandle: {0}", (object) this.LtypeHandle));
      }
      if (this.PlotstyleFlags == 3)
      {
        this.PlotStyleHandle = ba.ReadH();
        Console.WriteLine(string.Format("PlotStyleHandle: {0}", (object) this.PlotStyleHandle));
      }
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      int residual = ba.Residual;
    }
  }
}
