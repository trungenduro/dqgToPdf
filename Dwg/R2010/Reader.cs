// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Reader
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg.R2010.Objects;
using dqgToPdf.Dwg.R2013;
using dqgToPdf.Dxf;
using dqgToPdf.Pdf.Contents;
using dqgToPdf.Pdf.Objects;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;

namespace dqgToPdf.Dwg.R2010
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

    public string Filepath { get; set; }

    public string QRSTR { get; set; }

    private System.Collections.Generic.Dictionary<int, uint> SectionPageMap { get; set; } = new System.Collections.Generic.Dictionary<int, uint>();

    private List<DataSectionMap> DataSectionMaps { get; set; } = new List<DataSectionMap>();

    public System.Collections.Generic.Dictionary<int, object> ObjectMap { get; set; } = new System.Collections.Generic.Dictionary<int, object>();

    public string Filename { get; set; }

    private AcDbClasses AcDbClasses { get; set; }

    public Reader(string dwgfile)
    {
      using (BinaryReader binaryReader = new BinaryReader((System.IO.Stream) new FileStream(dwgfile, FileMode.Open, FileAccess.Read)))
      {
        this.dwgfile = dwgfile;
        this.Filename = dwgfile;
        this.br = binaryReader;
        this.Header();
        this.SectionPage();
        this.SectionMap();
        this.DecompressDataSection();
        this.LoadClasses();
        this.LoadObjects();
      }
    }

    public Reader(BinaryReader br, string dwgfile)
    {
      this.dwgfile = dwgfile;
      this.Filename = dwgfile;
      this.br = br;
      this.Header();
      this.SectionPage();
      this.SectionMap();
      this.DecompressDataSection();
      this.LoadClasses();
      this.LoadObjects();
    }

    private void LoadClasses()
    {
      this.AcDbClasses = new AcDbClasses(new DwgBitArray(this.DataSectionMaps.FirstOrDefault<DataSectionMap>((Func<DataSectionMap, bool>) (x => x.SectionName == "AcDb:Classes")).GetObjectSectionBytes(), 0));
    }

    private void LoadObjects()
    {
      System.Collections.Generic.Dictionary<int, int> objectMap = this.DataSectionMaps.FirstOrDefault<DataSectionMap>((Func<DataSectionMap, bool>) (x => x.SectionName == "AcDb:Handles")).GetObjectMap();
      using (BinaryReader br = new BinaryReader((System.IO.Stream) new MemoryStream(this.DataSectionMaps.FirstOrDefault<DataSectionMap>((Func<DataSectionMap, bool>) (x => x.SectionName == "AcDb:AcDbObjects")).GetObjectSectionBytes())))
      {
        foreach (KeyValuePair<int, int> keyValuePair in objectMap)
        {
          br.BaseStream.Seek((long) keyValuePair.Value, SeekOrigin.Begin);
          List<byte> bl = new List<byte>();
          int count = DwgUtility.readModuleShorts(br, (List<ushort>) null);
          DwgUtility.ReadModuleChars(br, false, bl);
          byte[] barr = br.ReadBytes(count);
          DwgBitArray dwgBitArray = new DwgBitArray(barr, 0);
          short type;
          switch (dwgBitArray.ReadBB())
          {
            case 0:
              type = (short) dwgBitArray.ReadByte();
              break;
            case 1:
              type = (short) (496 + (int) dwgBitArray.ReadByte());
              break;
            case 2:
              type = (short) (598 * (int) dwgBitArray.ReadByte() + (int) dwgBitArray.ReadByte());
              break;
            default:
              throw new Exception("");
          }
          byte[] binaryData = new byte[bl.Count + barr.Length];
          for (int index = 0; index < bl.Count; ++index)
            binaryData[index] = bl[index];
          barr.CopyTo((System.Array) binaryData, bl.Count);
          this.ObjectMap.Add(keyValuePair.Key, this.ConverObject(type, binaryData));
        }
      }
    }

    private object ConverObject(short type, byte[] binaryData)
    {
      DwgBitArray ba = new DwgBitArray(binaryData, 0);
      switch (type)
      {
        case 1:
          return (object) new dqgToPdf.Dwg.R2010.Objects.Text(ba);
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
          return (object) new dqgToPdf.Dwg.R2010.Objects.Dictionary(ba);
        case 44:
          return (object) new MText(ba);
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

    private void SectionMap()
    {
      foreach (KeyValuePair<int, uint> sectionPage in this.SectionPageMap)
      {
        this.br.BaseStream.Seek((long) sectionPage.Value, SeekOrigin.Begin);
        if (this.br.ReadUInt32() == 1097007163U)
        {
          this.br.BaseStream.Seek((long) (int) sectionPage.Value, SeekOrigin.Begin);
          int num1 = (int) this.br.ReadUInt32();
          uint num2 = this.br.ReadUInt32();
          uint num3 = this.br.ReadUInt32();
          int num4 = (int) this.br.ReadUInt32();
          int num5 = (int) this.br.ReadUInt32();
          using (BinaryReader binaryReader = new BinaryReader((System.IO.Stream) new MemoryStream(DwgUtility.decompress(this.br.ReadBytes((int) num3), (int) num2))))
          {
            uint num6 = binaryReader.ReadUInt32();
            int num7 = (int) binaryReader.ReadUInt32();
            int num8 = (int) binaryReader.ReadUInt32();
            int num9 = (int) binaryReader.ReadUInt32();
            int num10 = (int) binaryReader.ReadUInt32();
            for (int index1 = 0; (long) index1 < (long) num6; ++index1)
            {
              DataSectionMap dataSectionMap = new DataSectionMap();
              ulong num11;
              dataSectionMap.SizeOfSection = num11 = binaryReader.ReadUInt64();
              uint num12 = dataSectionMap.PageCount = binaryReader.ReadUInt32();
              uint num13;
              dataSectionMap.MaxDecompressedSize = num13 = binaryReader.ReadUInt32();
              dataSectionMap.Unknown = num13 = binaryReader.ReadUInt32();
              dataSectionMap.Compressed = num13 = binaryReader.ReadUInt32();
              dataSectionMap.SectionID = num13 = binaryReader.ReadUInt32();
              dataSectionMap.Encrypted = num13 = binaryReader.ReadUInt32();
              byte[] numArray = binaryReader.ReadBytes(64);
              int length = 0;
              for (int index2 = 0; index2 < numArray.Length; ++index2)
              {
                if (numArray[index2] == (byte) 0)
                {
                  length = index2;
                  break;
                }
              }
              byte[] bytes = new byte[length];
              for (int index2 = 0; index2 < length; ++index2)
                bytes[index2] = numArray[index2];
              string str = Encoding.ASCII.GetString(bytes);
              dataSectionMap.SectionName = str;
              for (int index2 = 0; (long) index2 < (long) num12; ++index2)
              {
                SectionPageMapData sectionPageMapData = new SectionPageMapData();
                sectionPageMapData.PageNumber = num13 = binaryReader.ReadUInt32();
                sectionPageMapData.DataSizeForThisPage = num13 = binaryReader.ReadUInt32();
                sectionPageMapData.StartOffsetForThisPage = num11 = binaryReader.ReadUInt64();
                dataSectionMap.SectionPageMapDatas.Add((dqgToPdf.Dwg.R2013.SectionPageMapData) sectionPageMapData);
              }
              this.DataSectionMaps.Add(dataSectionMap);
            }
          }
        }
      }
    }

    private void SectionPage()
    {
      this.br.BaseStream.Seek((long) (int) this.SectionPageMapAddress, SeekOrigin.Begin);
      int num1 = (int) this.br.ReadUInt32();
      uint num2 = this.br.ReadUInt32();
      uint num3 = this.br.ReadUInt32();
      int num4 = (int) this.br.ReadUInt32();
      int num5 = (int) this.br.ReadUInt32();
      byte[] numArray = DwgUtility.decompress(this.br.ReadBytes((int) num3), (int) num2);
      System.Collections.Generic.Dictionary<int, uint> dictionary = new System.Collections.Generic.Dictionary<int, uint>();
      uint num6 = 256;
      int startIndex1 = 0;
      while (numArray.Length - startIndex1 >= 8)
      {
        int int32 = BitConverter.ToInt32(numArray, startIndex1);
        int startIndex2 = startIndex1 + 4;
        uint uint32_1 = BitConverter.ToUInt32(numArray, startIndex2);
        startIndex1 = startIndex2 + 4;
        if (int32 < 0)
        {
          int uint32_2 = (int) BitConverter.ToUInt32(numArray, startIndex1);
          int startIndex3 = startIndex1 + 4;
          int uint32_3 = (int) BitConverter.ToUInt32(numArray, startIndex3);
          int startIndex4 = startIndex3 + 4;
          int uint32_4 = (int) BitConverter.ToUInt32(numArray, startIndex4);
          int startIndex5 = startIndex4 + 4;
          int uint32_5 = (int) BitConverter.ToUInt32(numArray, startIndex5);
          startIndex1 = startIndex5 + 4;
        }
        else
        {
          dictionary.Add(int32, uint32_1);
          this.SectionPageMap.Add(int32, num6);
        }
        num6 += uint32_1;
      }
    }

    private void Header()
    {
      this.SeekZero();
      byte[] headerBytes = this.br.ReadBytes(236);
      int length = 108;
      byte[] numArray = new byte[length];
      int num = 1;
      for (int index = 0; index < length; ++index)
      {
        num = num * 214013 + 2531011;
        numArray[index] = (byte) (num >> 16);
      }
      for (int index = 0; index < length; ++index)
        headerBytes[128 + index] ^= numArray[index];
      this.SectionPageMapAddress = BitConverter.ToUInt64(headerBytes, 212) + 256UL;
      this.fileHeader = new FileHeader(headerBytes);
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
      BlockHeader bh = this.GetModelSpace();
      foreach (CommonEntityData commonEntityData in bh.OwnedObjectHandles.Select<HandleReference, int>((Func<HandleReference, int>) (elem => elem.getTargetHandle(bh.ObjId))).Where<int>((Func<int, bool>) (x => (uint) x > 0U)).Select<int, object>((Func<int, object>) (elem => this.ObjectMap[elem])))
      {
        BoundingBox boundingBox2 = commonEntityData?.GetBoundingBox(this.ObjectMap);
        if (boundingBox2 != null)
        {
          Console.WriteLine(string.Format("object: {0}", (object) commonEntityData));
          Point3D basePt = bh.BasePt;
          boundingBox2.Left += basePt.x;
          boundingBox2.Right += basePt.x;
          boundingBox2.Top += basePt.y;
          boundingBox2.Bottom += basePt.y;
          Console.WriteLine(string.Format("{0:x} boundingBox: {1}", (object) commonEntityData.ObjId, (object) boundingBox2));
          boundingBox1.AddBoudingBox(boundingBox2);
        }
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
        int? colorIndex = ced.ColorIndex;
        int num = 256;
        if (colorIndex.GetValueOrDefault() == num & colorIndex.HasValue)
        {
          int coloridx = ((Layer) objmap[ced.LayerHandle.getTargetHandle(ced.ObjId)]).ColorIndex.RGBValue & (int) byte.MaxValue;
          po.SetColor(coloridx);
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

    public static void DrawBlockHeader(
      BlockHeader blockHeader,
      PageObject po,
      System.Collections.Generic.Dictionary<int, object> objmap,
      Point3D insertPt,
      Point3D scale,
      double rotation,
      bool isInsert = false)
    {
      po.ShiftAndRotate(insertPt.ToPoint2d(), scale.ToPoint2d(), rotation);
      foreach (CommonEntityData ced in blockHeader.OwnedObjectHandles.Select<HandleReference, int>((Func<HandleReference, int>) (elem => elem.getTargetHandle(blockHeader.ObjId))).Where<int>((Func<int, bool>) (x => (uint) x > 0U)).Select<int, object>((Func<int, object>) (elem => objmap[elem])))
      {
        if (ced != null)
        {
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
        }
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
        public static void GetLinkItem(
      BlockHeader blockHeader,
      LinkInfo li,
      Matrix matrix,
      System.Collections.Generic.Dictionary<int, object> objMap = null)
    {
      foreach (CommonEntityData commonEntityData in blockHeader.OwnedObjectHandles.Select<HandleReference, int>((Func<HandleReference, int>) (elem => elem.getTargetHandle(blockHeader.ObjId))).Where<int>((Func<int, bool>) (x => (uint) x > 0U)).Select<int, object>((Func<int, object>) (elem => objMap[elem])))
        commonEntityData?.LinkInfoItem(li, matrix, objMap);
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
  }
}
