// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.CommonEntityData2010
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg
{
  public class CommonEntityData2010 : CommonEntityData
  {
    public CommonEntityData2010()
    {
    }

    public CommonEntityData2010(DwgBitArray ba)
    {
      this.LoadCommonEntityData(ba);
    }

    public override void LoadCommonEntityData(DwgBitArray ba)
    {
      Console.WriteLine(string.Format("LoadCommonEntityData Starts: --------------{0}--------", (object) ba.Residual));
      this.SizeInBitsHandle = ba.ReadModuleChars(false);
      Console.WriteLine(string.Format("SizeInBitsHandle:{0}", (object) this.SizeInBitsHandle));
      this.Type = ba.ReadOT();
      Console.WriteLine(string.Format("Type:{0}", (object) this.Type));
      this.ObjectsHandle = ba.ReadH();
      Console.WriteLine(string.Format("ObjectsHandle:{0}", (object) this.ObjectsHandle));
      this.EED = ba.ReadEED();
      this.FlagGraphicImage = ba.ReadB();
      Console.WriteLine(string.Format("FlagGraphicImage:{0}", (object) this.FlagGraphicImage));
      if (this.FlagGraphicImage)
      {
        this.SizeOfGraphicImageInBytes = ba.ReadBLL();
        Console.WriteLine(string.Format("SizeOfGraphicImageInBytes:{0}", (object) this.SizeOfGraphicImageInBytes));
        this.TheGraphicImage = ba.ReadBytes((int) this.SizeOfGraphicImageInBytes);
      }
      this.EntMode = ba.ReadBB();
      Console.WriteLine(string.Format("EntMode:{0:x2}", (object) this.EntMode));
      this.NumReactors = ba.ReadBL();
      Console.WriteLine(string.Format("NumReactors:{0}", (object) this.NumReactors));
      this.XdicMissingFlag = ba.ReadB();
      Console.WriteLine(string.Format("XdicMissingFlag:{0}", (object) this.XdicMissingFlag));
      this.Entitycolor = (int) ba.ReadBUS();
      Console.WriteLine(string.Format("Entitycolor: {0:x}", (object) this.Entitycolor));
      if ((this.Entitycolor & 32768) != 0)
      {
        this.RGBValue = new int?(ba.ReadBL());
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
      this.MaterialFlags = ba.ReadBB();
      Console.WriteLine(string.Format("MaterialFlags:{0:x2}", (object) this.MaterialFlags));
      this.ShadowFlags = (int) ba.ReadByte();
      Console.WriteLine("ShadowFlags:" + this.ShadowFlags.ToString());
      this.HasFullVisualStyle = ba.ReadB();
      this.HasFaceVisualStyle = ba.ReadB();
      this.HasEdgeVisualStyle = ba.ReadB();
      Console.WriteLine("HasFullVisualStyle:" + this.HasFullVisualStyle.ToString());
      Console.WriteLine("HasFaceVisualStyle:" + this.HasFaceVisualStyle.ToString());
      Console.WriteLine("HasEdgeVisualStyle:" + this.HasEdgeVisualStyle.ToString());
      this.Invisibility = (int) ba.ReadBS();
      Console.WriteLine("Invisibility:" + this.Invisibility.ToString());
      this.LineWeight = ba.ReadByte();
      Console.WriteLine("LineWeight:" + this.LineWeight.ToString());
      Console.WriteLine("remains:" + ba.Residual.ToString());
      Console.WriteLine("LoadCommonEntityData Ends: ----------------------");
    }
  }
}
