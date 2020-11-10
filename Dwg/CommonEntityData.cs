// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.CommonEntityData
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace dqgToPdf.Dwg
{
  public class CommonEntityData
  {
    public List<HandleReference> Reactors = new List<HandleReference>();
    public HandleReference OwnereRefHandle;
    public HandleReference PSpaceEntHandle;
    public HandleReference MSpaceEntHandle;
    public HandleReference xDicobjHandle;
    public HandleReference ColorBookColorHandle;
    public HandleReference LayerHandle;
    public HandleReference LtypeHandle;
    public HandleReference MaterialHandle;
    public HandleReference PlotStyleHandle;
    public HandleReference FullVisualStyleHandle;
    public HandleReference FaceVisualStyleHandle;
    public HandleReference EdgeVisualStyleHandle;

    public CommonEntityData()
    {
    }

    public CommonEntityData(DwgBitArray ba)
    {
      this.LoadCommonEntityData(ba);
    }

    public virtual BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      return (BoundingBox) null;
    }

    public virtual void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
    }

    public virtual void LinkInfoItem(LinkInfo li, Matrix matrix, Dictionary<int, object> objMap = null)
    {
    }

    public int ObjId
    {
      get
      {
        return this.ObjectsHandle.GetHandleOffsetVal();
      }
    }

    public virtual void LoadCommonEntityHandleData(DwgBitArray ba)
    {
      Console.WriteLine("LoadCommonEntityHandleData Starts: ----------------------");
      ba.DumpBitIndex();
      if (ba.Residual != this.SizeInBitsHandle)
        Console.WriteLine("Bit Exception");
      if (this.EntMode == 0)
      {
        this.OwnereRefHandle = ba.ReadH();
        Console.WriteLine(string.Format("OwnereRefHandle: {0}", (object) this.OwnereRefHandle));
        ba.DumpBitIndex();
      }
      for (int index = 0; index < this.NumReactors; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        this.Reactors.Add(handleReference);
        Console.WriteLine(string.Format("Reactor: {0}", (object) handleReference));
        ba.DumpBitIndex();
      }
      if (!this.XdicMissingFlag)
      {
        this.xDicobjHandle = ba.ReadH();
        Console.WriteLine(string.Format("xDicobjHandle: {0}", (object) this.xDicobjHandle));
        ba.DumpBitIndex();
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
      if (this.MaterialFlags == 3)
      {
        this.MaterialHandle = ba.ReadH();
        Console.WriteLine(string.Format("MaterialHandle: {0}", (object) this.MaterialHandle));
      }
      if (this.PlotstyleFlags == 3)
      {
        this.PlotStyleHandle = ba.ReadH();
        Console.WriteLine(string.Format("PlotStyleHandle: {0}", (object) this.PlotStyleHandle));
      }
      if (this.HasFullVisualStyle)
      {
        this.FullVisualStyleHandle = ba.ReadH();
        Console.WriteLine(string.Format("FullVisualStyleHandle: {0}", (object) this.FullVisualStyleHandle));
      }
      if (this.HasFaceVisualStyle)
      {
        this.FaceVisualStyleHandle = ba.ReadH();
        Console.WriteLine(string.Format("FaceVisualStyleHandle: {0}", (object) this.FaceVisualStyleHandle));
      }
      if (this.HasEdgeVisualStyle)
      {
        this.EdgeVisualStyleHandle = ba.ReadH();
        Console.WriteLine(string.Format("EdgeVisualStyleHandle: {0}", (object) this.EdgeVisualStyleHandle));
      }
      Console.WriteLine("Remain Bits:" + ba.Residual.ToString());
      Console.WriteLine("---------------");
      int residual = ba.Residual;
    }

    public virtual void LoadCommonEntityData(DwgBitArray ba)
    {
      Console.WriteLine(string.Format("LoadCommonEntityData Starts: --------------{0}--------", (object) ba.Residual));
      this.SizeInBitsHandle = ba.ReadModuleChars(false);
      Console.WriteLine(string.Format("SizeInBitsHandle:{0}", (object) this.SizeInBitsHandle));
      this.Type = ba.ReadOT();
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
      this.HasDsBinaryData = ba.ReadB();
      Console.WriteLine(string.Format("HasDsBinaryData:{0}", (object) this.HasDsBinaryData));
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
      this.MaterialFlags = ba.ReadBB();
      Console.WriteLine(string.Format("LineTypeFlags:{0:x2}", (object) this.LineTypeFlags));
      Console.WriteLine(string.Format("PlotstyleFlags:{0:x2}", (object) this.PlotstyleFlags));
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

    public int Type { get; set; }

    public int SizeInBitsHandle { get; set; }

    public HandleReference ObjectsHandle { get; set; }

    public int SizeOfExtendedObjData { get; set; }

    public List<ExtendedEntityData> EED { get; set; }

    public bool FlagGraphicImage { get; set; }

    public long SizeOfGraphicImageInBytes { get; set; }

    public byte[] TheGraphicImage { get; set; }

    public bool nextLinkersArePresent { get; set; }

    public int EntMode { get; set; }

    public int NumReactors { get; set; }

    public bool XdicMissingFlag { get; set; }

    public bool HasDsBinaryData { get; set; }

    public int Entitycolor { get; set; }

    public int? ColorIndex { get; set; }

    public int? RGBValue { get; set; }

    public int? TransParency { get; set; }

    public double LinetypeScale { get; set; }

    public int LineTypeFlags { get; set; }

    public int PlotstyleFlags { get; set; }

    public int MaterialFlags { get; set; }

    public int ShadowFlags { get; set; }

    public bool HasFullVisualStyle { get; set; }

    public bool HasFaceVisualStyle { get; set; }

    public bool HasEdgeVisualStyle { get; set; }

    public int Invisibility { get; set; }

    public byte LineWeight { get; set; }
  }
}
