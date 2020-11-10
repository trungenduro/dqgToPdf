// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.Insert
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class Insert : dqgToPdf.Dwg.R2004.CommonEntityData
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
      foreach (dqgToPdf.Dwg.CommonEntityData commonEntityData in blockHeader.OwnedObjectHandles.Select<HandleReference, int>((Func<HandleReference, int>) (elem => elem.getTargetHandle(blockHeader.ObjId))).Where<int>((Func<int, bool>) (x => (uint) x > 0U)).Select<int, object>((Func<int, object>) (elem => objMap[elem])))
      {
        BoundingBox boundingBox2 = commonEntityData?.GetBoundingBox(objMap);
        if (boundingBox2 != null)
          boundingBox1.AddBoudingBox(boundingBox2);
      }
      double num1 = Math.Abs(this.ScaleData.x);
      double num2 = Math.Abs(this.ScaleData.y);
      boundingBox1.Left = boundingBox1.Left * num1 + this.InsPt.x;
      boundingBox1.Right = boundingBox1.Right * num1 + this.InsPt.x;
      boundingBox1.Top = boundingBox1.Top * num2 + this.InsPt.y;
      boundingBox1.Bottom = boundingBox1.Bottom * num2 + this.InsPt.y;
      return boundingBox1;
    }

    public Insert(DwgBitArray ba)
      : base(ba)
    {
      this.LoadInsertData(ba);
      Console.WriteLine();
    }

    public Point3D InsPt { get; set; }

    public int DataFlags { get; set; }

    public Point3D ScaleData { get; set; }

    public double Rotation { get; set; }

    public Point3D Extrusion { get; set; }

    public bool HasAttribs { get; set; }

    public int OwnedObjectCount { get; set; }

    public HandleReference BlockHeaderHandle { get; set; }

    public HandleReference SeqendHandle { get; set; }

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
      ba.DumpBitIndex();
      this.LoadCommonEntityHandleData(ba);
      this.BlockHeaderHandle = ba.ReadH();
      Console.WriteLine(string.Format("BlockHeaderHandle: {0}", (object) this.BlockHeaderHandle));
      if (this.HasAttribs)
      {
        this.SeqendHandle = ba.ReadH();
        Console.WriteLine(string.Format("SeqendHandle: {0}", (object) this.SeqendHandle));
      }
      ba.DumpBitIndex();
    }
  }
}
