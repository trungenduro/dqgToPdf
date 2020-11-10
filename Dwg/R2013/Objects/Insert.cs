// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Insert
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Insert : CommonEntityData
  {
    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      Reader.DrawBlockHeader(objMap[this.BlockHeaderHandle.getTargetHandle(this.ObjId)] as BlockHeader, po, objMap, this.InsPt, this.ScaleData, this.Rotation, true);
    }

    public override void LinkInfoItem(LinkInfo li, Matrix matrix, Dictionary<int, object> objMap = null)
    {
      BlockHeader blockHeader = objMap[this.BlockHeaderHandle.getTargetHandle(this.ObjId)] as BlockHeader;
      Matrix matrix1 = matrix.Clone();
      matrix1.Rotate((float) (this.Rotation / Math.PI * 180.0), MatrixOrder.Append);
      matrix1.Scale((float) this.ScaleData.x, (float) this.ScaleData.y, MatrixOrder.Append);
      matrix1.Translate((float) this.InsPt.x, (float) this.InsPt.y, MatrixOrder.Append);
      LinkInfo li1 = li;
      Matrix matrix2 = matrix;
      Dictionary<int, object> objMap1 = objMap;
      Reader.GetLinkItem(blockHeader, li1, matrix2, objMap1);
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BlockHeader blockHeader = objMap[this.BlockHeaderHandle.getTargetHandle(this.ObjId)] as BlockHeader;
      BoundingBox boundingBox1 = new BoundingBox();
      foreach (CommonEntityData commonEntityData in blockHeader.OwnedObjectHandles.Select<HandleReference, int>((Func<HandleReference, int>) (elem => elem.getTargetHandle(blockHeader.ObjId))).Where<int>((Func<int, bool>) (x => (uint) x > 0U)).Select<int, object>((Func<int, object>) (elem => objMap[elem])))
      {
        BoundingBox boundingBox2 = commonEntityData?.GetBoundingBox(objMap);
        if (boundingBox2 != null)
          boundingBox1.AddBoudingBox(boundingBox2);
      }
      double left = boundingBox1.Left;
      double right = boundingBox1.Right;
      double top = boundingBox1.Top;
      double bottom = boundingBox1.Bottom;
      double num1 = Math.Cos(this.Rotation);
      double num2 = Math.Sin(this.Rotation);
      double x1 = this.ScaleData.x;
      double y = this.ScaleData.y;
      Point2D point2D1 = new Point2D()
      {
        x = num1 * right * x1 - num2 * top * y,
        y = num2 * right * x1 + num1 * top * y
      };
      Point2D point2D2 = new Point2D()
      {
        x = num1 * left * x1 - num2 * top * y,
        y = num2 * left * x1 + num1 * top * y
      };
      Point2D point2D3 = new Point2D()
      {
        x = num1 * left * x1 - num2 * bottom * y,
        y = num2 * left * x1 + num1 * bottom * y
      };
      Point2D point2D4 = new Point2D()
      {
        x = num1 * right * x1 - num2 * bottom * y,
        y = num2 * right * x1 + num1 * bottom * y
      };
      boundingBox1.Left = Math.Min(Math.Min(point2D1.x, point2D2.x), Math.Min(point2D3.x, point2D4.x)) + this.InsPt.x;
      boundingBox1.Right = Math.Max(Math.Max(point2D1.x, point2D2.x), Math.Max(point2D3.x, point2D4.x)) + this.InsPt.x;
      boundingBox1.Top = Math.Max(Math.Max(point2D1.y, point2D2.y), Math.Max(point2D3.y, point2D4.y)) + this.InsPt.y;
      boundingBox1.Bottom = Math.Min(Math.Min(point2D1.y, point2D2.y), Math.Min(point2D3.y, point2D4.y)) + this.InsPt.y;
      return boundingBox1;
    }

    public Insert(DwgBitArray ba)
      : base(ba)
    {
      this.LoadInsertData(ba);
      Console.WriteLine();
    }

    public bool HasBinaryData { get; set; }

    public Point3D InsPt { get; set; }

    public int DataFlags { get; set; }

    public Point3D ScaleData { get; set; }

    public double Rotation { get; set; }

    public Point3D Extrusion { get; set; }

    public bool HasAttribs { get; set; }

    public int OwnedObjectCount { get; set; }

    public HandleReference BlockHeaderHandle { get; set; }

    public HandleReference SeqendHandle { get; set; }

    public List<HandleReference> Attribs { get; set; } = new List<HandleReference>();

    private void LoadInsertData(DwgBitArray ba)
    {
      this.InsPt = ba.Read3BD();
      Console.WriteLine(string.Format("InsPt: {0}", (object) this.InsPt));
      this.DataFlags = ba.ReadBB();
      Console.WriteLine(string.Format("DataFlags: {0}", (object) this.DataFlags));
      if (this.DataFlags == 3)
        this.ScaleData = new Point3D()
        {
          x = 1.0,
          y = 1.0,
          z = 1.0
        };
      else if (this.DataFlags == 1)
        this.ScaleData = new Point3D()
        {
          x = 1.0,
          y = ba.ReadDD(1.0),
          z = ba.ReadDD(1.0)
        };
      else if (this.DataFlags == 2)
      {
        double num = ba.ReadRD();
        this.ScaleData = new Point3D()
        {
          x = num,
          y = num,
          z = num
        };
      }
      else if (this.DataFlags == 0)
      {
        double defaultDouble = ba.ReadRD();
        this.ScaleData = new Point3D()
        {
          x = defaultDouble,
          y = ba.ReadDD(defaultDouble),
          z = ba.ReadDD(defaultDouble)
        };
      }
      Console.WriteLine(string.Format("ScaleData: {0}", (object) this.ScaleData));
      this.Rotation = ba.ReadBD();
      Console.WriteLine(string.Format("Rotation: {0}", (object) this.Rotation));
      this.Extrusion = ba.Read3BD();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.HasAttribs = ba.ReadB();
      Console.WriteLine(string.Format("HasAttribs: {0}", (object) this.HasAttribs));
      if (this.HasAttribs)
      {
        this.OwnedObjectCount = ba.ReadBL();
        Console.WriteLine(string.Format("OwnedObjectCount: {0}", (object) this.OwnedObjectCount));
      }
      ++ba.bitindex;
      ba.DumpBitIndex();
      this.LoadCommonEntityHandleData(ba);
      this.BlockHeaderHandle = ba.ReadH();
      Console.WriteLine(string.Format("BlockHeaderHandle: {0}", (object) this.BlockHeaderHandle));
      for (int index = 0; index < this.OwnedObjectCount; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("attrib: {0}", (object) handleReference));
        this.Attribs.Add(handleReference);
      }
      if (this.HasAttribs)
      {
        this.SeqendHandle = ba.ReadH();
        Console.WriteLine(string.Format("SeqendHandle: {0}", (object) this.SeqendHandle));
      }
      ba.DumpBitIndex();
    }
  }
}
