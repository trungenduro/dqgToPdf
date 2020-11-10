// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Reader
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg.R2000.Objects;
using dqgToPdf.Dxf;
using dqgToPdf.Pdf.Contents;
using dqgToPdf.Pdf.Objects;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace dqgToPdf.Dwg.R2000
{
  public class Reader : IReader
  {
    private static List<LineStyle> tempLayerStyles;
    private string dwgfile;
    private BinaryReader br;
    private ulong SectionPageMapAddress;
    private FileHeader fileHeader;
    private static bool isLayerStyle;

    public List<AcDbEntity> Entities { get; set; } = new List<AcDbEntity>();

    public List<LineStyle> LayerStyles { get; set; } = new List<LineStyle>();

    private System.Collections.Generic.Dictionary<int, Reader.Locator> Locators { get; set; } = new System.Collections.Generic.Dictionary<int, Reader.Locator>();

    public string Filepath { get; set; }

    public string QRSTR { get; set; }

    private System.Collections.Generic.Dictionary<int, uint> SectionPageMap { get; set; } = new System.Collections.Generic.Dictionary<int, uint>();

    private List<DataSectionMap> DataSectionMaps { get; set; } = new List<DataSectionMap>();

    public System.Collections.Generic.Dictionary<int, object> ObjectMap { get; set; } = new System.Collections.Generic.Dictionary<int, object>();

    public System.Collections.Generic.Dictionary<int, int> ObjectAddressMap { get; set; } = new System.Collections.Generic.Dictionary<int, int>();

    public string Filename { get; set; }

    private AcDbClasses AcDbClasses { get; set; }

    public Reader(string dwgfile)
    {
      using (BinaryReader binaryReader = new BinaryReader((System.IO.Stream) new FileStream(dwgfile, FileMode.Open, FileAccess.Read)))
      {
        this.dwgfile = dwgfile;
        this.Filename = dwgfile;
        this.br = binaryReader;
        this.init();
      }
    }

    private void init()
    {
      this.Seeker();
      this.Classes();
      this._ObjectMap();
      this.LoadObjects();
    }

    private void _ObjectMap()
    {
      this.br.BaseStream.Seek((long) this.Locators[2].Seeker, SeekOrigin.Begin);
      DwgBitArray dwgBitArray = new DwgBitArray(this.br.ReadBytes(this.Locators[2].Size), 0);
      while (dwgBitArray.Residual > 16)
      {
        int num1 = (int) dwgBitArray.ReadByte() * 256 + (int) dwgBitArray.ReadByte();
        int key = 0;
        int num2 = 0;
        int residual1 = dwgBitArray.Residual;
        while (residual1 - dwgBitArray.Residual - (num1 * 8 - 16) < 0)
        {
          int residual2 = dwgBitArray.Residual;
          int num3 = dwgBitArray.ReadModuleChars(true);
          int num4 = dwgBitArray.ReadModuleChars(false);
          key += num3;
          num2 += num4;
          Console.WriteLine(string.Format("{0:d4}, {1:x8}", (object) key, (object) num2));
          this.ObjectAddressMap.Add(key, num2);
        }
        dwgBitArray.ReadBytes(2);
      }
    }

    private void Classes()
    {
      this.br.BaseStream.Seek((long) this.Locators[1].Seeker, SeekOrigin.Begin);
      this.AcDbClasses = new AcDbClasses(new DwgBitArray(this.br.ReadBytes(this.Locators[1].Size), 0));
    }

    public Reader(BinaryReader br, string dwgfile)
    {
      this.dwgfile = dwgfile;
      this.Filename = dwgfile;
      this.br = br;
      this.init();
    }

    private void LoadClasses()
    {
      this.AcDbClasses = new AcDbClasses(new DwgBitArray(this.DataSectionMaps.FirstOrDefault<DataSectionMap>((Func<DataSectionMap, bool>) (x => x.SectionName == "AcDb:Classes")).GetObjectSectionBytes(), 0));
    }

    private void LoadObjects()
    {
      foreach (KeyValuePair<int, int> objectAddress in this.ObjectAddressMap)
      {
        this.br.BaseStream.Seek((long) objectAddress.Value, SeekOrigin.Begin);
        List<byte> byteList = new List<byte>();
        byte[] barr = this.br.ReadBytes(DwgUtility.readModuleShorts(this.br, (List<ushort>) null));
        short type = new DwgBitArray(barr, 0).ReadBS();
        byte[] binaryData = new byte[byteList.Count + barr.Length];
        for (int index = 0; index < byteList.Count; ++index)
          binaryData[index] = byteList[index];
        barr.CopyTo((System.Array) binaryData, byteList.Count);
        this.ObjectMap.Add(objectAddress.Key, this.ConverObject(type, binaryData));
      }
    }

    private object ConverObject(short type, byte[] binaryData)
    {
      DwgBitArray ba = new DwgBitArray(binaryData, 0);
      switch (type)
      {
        case 1:
          return (object) new dqgToPdf.Dwg.R2000.Objects.Text(ba);
        case 2:
          return (object) new Attrib(ba);
        case 3:
          return (object) new Attdef(ba);
        case 4:
          return (object) new Block(ba);
        case 5:
          return (object) new Endblk(ba);
        case 6:
          return (object) new Seqend(ba);
        case 7:
          return (object) new Insert(ba);
        case 10:
          return (object) new Vertex2D(ba);
        case 17:
          return (object) new Arc(ba);
        case 18:
          return (object) new Circle(ba);
        case 19:
          return (object) new Line(ba);
        case 21:
          return (object) new DimensionLinear(ba);
        case 22:
          return (object) new DimensionAligned(ba);
        case 24:
          return (object) new DimensionAngular2Line(ba);
        case 25:
          return (object) new DimensionRadius(ba);
        case 26:
          return (object) new DimensionDiameter(ba);
        case 27:
          return (object) new Point(ba);
        case 31:
          return (object) new Solid(ba);
        case 35:
          return (object) new Ellipse(ba);
        case 36:
          return (object) new Spline(ba);
        case 42:
          return (object) new dqgToPdf.Dwg.R2000.Objects.Dictionary(ba);
        case 44:
          return (object) new MText(ba);
        case 45:
          return (object) new Leader(ba);
        case 48:
          return (object) new BlockControl(ba);
        case 49:
          return (object) new BlockHeader(ba);
        case 50:
          return (object) new LayerControl(ba);
        case 51:
          return (object) new Layer(ba);
        case 52:
          return (object) new ShapeFileControl(ba);
        case 53:
          return (object) new ShapeFile(ba);
        case 56:
          return (object) new LineTypeControl(ba);
        case 57:
          return (object) new Ltype(ba);
        case 60:
          return (object) new ViewControl(ba);
        case 62:
          return (object) new UCSControl(ba);
        case 64:
          return (object) new Table_Vport(ba);
        case 65:
          return (object) new Vport(ba);
        case 66:
          return (object) new TableAppID(ba);
        case 67:
          return (object) new AppID(ba);
        case 68:
          return (object) new DimstyleControl(ba);
        case 69:
          return (object) new Dimstyle(ba);
        case 73:
          return (object) new MLineStyle(ba);
        case 77:
          return (object) new LWPolyLine(ba);
        case 78:
          return (object) new Hatch(ba);
        case 79:
          return (object) new XRecord(ba);
        case 82:
          return (object) new Layout(ba);
        default:
          ClassData classData = this.AcDbClasses.ClassDataList.FirstOrDefault<ClassData>((Func<ClassData, bool>) (x => x.ClassNum == (int) type));
          if (classData != null)
          {
            switch (classData.ClassDxfName)
            {
              case "MULTILEADER":
                return (object) new MLeader(ba);
            }
          }
          return (object) null;
      }
    }

    private void DecompressDataSection()
    {
      foreach (DataSectionMap dataSectionMap in this.DataSectionMaps)
      {
        if (!string.IsNullOrEmpty(dataSectionMap.SectionName))
        {
          for (int index = 0; index < dataSectionMap.SectionPageMapDatas.Count; ++index)
            dataSectionMap.SectionPageMapDatas[index].DecompressData(this.br, this.SectionPageMap, (int) dataSectionMap.MaxDecompressedSize, dataSectionMap.Compressed == 2U);
        }
      }
    }

    private void SeekZero()
    {
      this.br.BaseStream.Seek(0L, SeekOrigin.Begin);
    }

    private void Seeker()
    {
      this.br.BaseStream.Seek(21L, SeekOrigin.Begin);
      int num = this.br.ReadInt32();
      for (int index = 0; index < num; ++index)
      {
        Reader.Locator locator = new Reader.Locator();
        locator.RecordNumber = (int) this.br.ReadByte();
        locator.Seeker = this.br.ReadInt32();
        locator.Size = this.br.ReadInt32();
        this.Locators.Add(locator.RecordNumber, locator);
        Console.WriteLine(string.Format("Record Number: {0}\r\nSeeker: {1:x}\r\nSize: {2:x}\r\n", (object) locator.RecordNumber, (object) locator.Seeker, (object) locator.Size));
      }
    }

    private BlockControl GetBlockControl()
    {
      return (BlockControl) this.ObjectMap.First<KeyValuePair<int, object>>((Func<KeyValuePair<int, object>, bool>) (x => x.Value is BlockControl)).Value;
    }

    private BlockHeader GetModelSpace()
    {
      return (BlockHeader) this.ObjectMap[this.GetBlockControl().ModelSpaceHandle.getTargetHandle(this.GetBlockControl().ObjId)];
    }

    private BlockHeader GetPaperSpace()
    {
      return (BlockHeader) this.ObjectMap[this.GetBlockControl().PaperSpaceHandle.getTargetHandle(this.GetBlockControl().ObjId)];
    }

    public BoundingBox GetBoundingBox()
    {
      this.GetBlockControl();
      BoundingBox boundingBox1 = new BoundingBox();
      BlockHeader modelSpace = this.GetModelSpace();
      int targetHandle = modelSpace.FirstEntityHandle.getTargetHandle(modelSpace.ObjId);
      while (targetHandle != 0 && this.ObjectMap[targetHandle] is CommonEntityData commonEntityData)
      {
        BoundingBox boundingBox2 = commonEntityData?.GetBoundingBox(this.ObjectMap);
        if (boundingBox2 != null)
        {
          Console.WriteLine(string.Format("object: {0}", (object) commonEntityData));
          Point3D basePt = modelSpace.BasePt;
          boundingBox2.Left += basePt.x;
          boundingBox2.Right += basePt.x;
          boundingBox2.Top += basePt.y;
          boundingBox2.Bottom += basePt.y;
          Console.WriteLine(string.Format("{0:x} boundingBox: {1}", (object) commonEntityData.ObjId, (object) boundingBox2));
          boundingBox1.AddBoudingBox(boundingBox2);
        }
        if (commonEntityData.NoLinks)
          ++targetHandle;
        else
          targetHandle = commonEntityData.NextEntityHandle.getTargetHandle(commonEntityData.ObjId);
      }
      return boundingBox1;
    }

    public List<string> GetLayerNames()
    {
      List<string> stringList = new List<string>();
      LayerControl layerControl = (LayerControl) this.ObjectMap.First<KeyValuePair<int, object>>((Func<KeyValuePair<int, object>, bool>) (x => x.Value is LayerControl)).Value;
      foreach (int index in layerControl.LayerObjsHandles.Select<HandleReference, int>((Func<HandleReference, int>) (x => x.getTargetHandle(layerControl.ObjId))))
      {
        if (index != 0)
        {
          Layer layer = (Layer) this.ObjectMap[index];
          stringList.Add(layer.EntryName);
        }
      }
      return stringList;
    }

    public List<IText> GetTextLists()
    {
      List<IText> textList = new List<IText>();
      foreach (KeyValuePair<int, object> keyValuePair in this.ObjectMap)
      {
        if (keyValuePair.Value is IText text)
          textList.Add(text);
      }
      return textList;
    }

    private static void SetColorAndWeightAccordingToDwg(
      CommonEntityData ced,
      PageObject po,
      System.Collections.Generic.Dictionary<int, object> objmap,
      Point3D scale,
      bool isInsert)
    {
      if (!isInsert)
      {
        po.SetLinestyle(0);
        Reader.setColor(ced, po, objmap);
      }
      po.SetLineWeight((double) ced.LineWeight / 100.0 / Math.Abs(scale.x));
    }

    private static void setColor(
      CommonEntityData ced,
      PageObject po,
      System.Collections.Generic.Dictionary<int, object> objmap)
    {
      if (ced != null && ced.ColorIndex.HasValue)
      {
        int? colorIndex1 = ced.ColorIndex;
        int num = 256;
        if (colorIndex1.GetValueOrDefault() == num & colorIndex1.HasValue)
        {
          int colorIndex2 = ((Layer) objmap[ced.LayerHandle.getTargetHandle(ced.ObjId)]).ColorIndex;
          po.SetColor(colorIndex2);
        }
        else
          po.SetColor(ced.ColorIndex.Value);
      }
      else
      {
        if (ced == null || !ced.TransParency.HasValue)
          return;
        int num = ced.TransParency.Value;
        int R = num & (int) byte.MaxValue;
        int G = (num & 65280) >> 8;
        int B = (num & 16711680) >> 16;
        int Alpha = (int) (((long) num & 4278190080L) >> 24);
        po.SetColor(R, G, B, Alpha);
      }
    }

    public static void GetLinkItem(
      BlockHeader blockHeader,
      LinkInfo li,
      Matrix matrix,
      System.Collections.Generic.Dictionary<int, object> objMap = null)
    {
      BlockHeader blockHeader1 = blockHeader;
      int targetHandle = blockHeader1.FirstEntityHandle.getTargetHandle(blockHeader1.ObjId);
      while (targetHandle != 0 && objMap[targetHandle] is CommonEntityData commonEntityData)
      {
        commonEntityData?.GetBoundingBox(objMap);
        commonEntityData?.LinkInfoItem(li, matrix, objMap);
        if (commonEntityData.NoLinks)
          ++targetHandle;
        else
          targetHandle = commonEntityData.NextEntityHandle.getTargetHandle(commonEntityData.ObjId);
      }
    }

    public static void DrawBlockHeader(
      BlockHeader blockHeader,
      PageObject po,
      System.Collections.Generic.Dictionary<int, object> objmap,
      Point3D insertPt,
      Point3D scale,
      double rotation,
      bool isInsert = false)
    {
      BlockHeader blockHeader1 = blockHeader;
      int targetHandle = blockHeader1.FirstEntityHandle.getTargetHandle(blockHeader1.ObjId);
      po.ShiftAndRotate(insertPt.ToPoint2d(), scale.ToPoint2d(), rotation);
      while (targetHandle != 0 && objmap[targetHandle] is CommonEntityData ced)
      {
        ced?.GetBoundingBox(objmap);
        if (Reader.isLayerStyle)
        {
          Layer layer = (Layer) objmap[ced.LayerHandle.getTargetHandle(ced.ObjId)];
          LineStyle lineStyle = Reader.tempLayerStyles.FirstOrDefault<LineStyle>((Func<LineStyle, bool>) (x => x.LayerName == layer.EntryName));
          if (lineStyle != null)
          {
            if (!lineStyle.IsHide)
            {
              if (lineStyle.IsDisable)
              {
                Reader.SetColorAndWeightAccordingToDwg(ced, po, objmap, scale, isInsert);
              }
              else
              {
                po.SetColor(lineStyle.GetLayerColor());
                po.SetLineWeight(lineStyle.GetLineWeight() / Math.Abs(scale.x));
                po.SetLinestyle(lineStyle.GetLineType());
              }
            }
            else
              continue;
          }
          else
          {
            po.SetColor(0);
            po.SetLineWeight(0.05 / Math.Abs(scale.x));
            po.SetLinestyle(0);
          }
        }
        else
          Reader.SetColorAndWeightAccordingToDwg(ced, po, objmap, scale, isInsert);
        Console.WriteLine((object) ced);
        if (ced is LWPolyLine lwPolyLine && (lwPolyLine.FLag & 4) != 0)
          po.SetLineWeight(lwPolyLine.ConstWidth / Math.Abs(scale.x));
        ced?.WritePdf(po, objmap);
        if (ced.NoLinks)
          ++targetHandle;
        else
          targetHandle = ced.NextEntityHandle.getTargetHandle(ced.ObjId);
      }
      po.RestoreState();
    }

    public void WritePdf(PageObject po, bool isEnableLineStyle = false)
    {
      Reader.isLayerStyle = isEnableLineStyle;
      Reader.tempLayerStyles = this.LayerStyles;
      Reader.DrawBlockHeader(this.GetModelSpace(), po, this.ObjectMap, new Point3D(), new Point3D()
      {
        x = 1.0,
        y = 1.0
      }, 0.0, false);
      po.AddWatemark();
      po.refleshText();
    }

        public void WritePdfLayout(PageObject po, bool isEnableLineStyle = false)
        {
            Reader.isLayerStyle = isEnableLineStyle;
            Reader.tempLayerStyles = this.LayerStyles;
            Reader.DrawBlockHeader(this.GetPaperSpace(), po, this.ObjectMap, new Point3D(), new Point3D()
            {
                x = 1.0,
                y = 1.0
            }, 0.0, false);
            po.AddWatemark();
            po.refleshText();

        }
        public LinkInfo GetLinkInfo(double scale, dqgToPdf.Pdf.Objects.Array mediabox)
    {
      LinkInfo li = new LinkInfo();
      li.PDFFilename = this.Filename;
      li.Mediabox = new double[4];
      li.Mediabox[0] = ((RealNumber) mediabox.Val[0]).number;
      li.Mediabox[1] = ((RealNumber) mediabox.Val[1]).number;
      li.Mediabox[2] = ((RealNumber) mediabox.Val[2]).number;
      li.Mediabox[3] = ((RealNumber) mediabox.Val[3]).number;
      li.LinkItems = new List<LinkItem>();
      Matrix matrix = new Matrix();
      matrix.Scale((float) scale, (float) scale, MatrixOrder.Append);
      Reader.GetLinkItem(this.GetModelSpace(), li, matrix, this.ObjectMap);
      return li;
    }

    public class Locator
    {
      public int RecordNumber { get; set; }

      public int Seeker { get; set; }

      public int Size { get; set; }
    }
  }
}
