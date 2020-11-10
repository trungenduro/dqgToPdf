// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Text
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Text : CommonEntityData, IText
  {
    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      string unifontName = (string) null;
      string bigfontName = (string) null;
      if (this.StyleHandle != null)
      {
        int targetHandle = this.StyleHandle.getTargetHandle(this.ObjId);
        if (targetHandle != 0)
        {
          ShapeFile shapeFile = (ShapeFile) objMap[targetHandle];
          unifontName = shapeFile.FontName;
          bigfontName = shapeFile.BigFontName;
        }
      }
      Point2D inspt = this.InsertionPt.Clone();
      po.AddText(this.TextValue, inspt.x, inspt.y, this.RotationAng, this.Height, this.Height * this.WidthFactor, unifontName, bigfontName);
      Console.WriteLine(this.TextValue);
      if (string.IsNullOrEmpty(this.LinkTargetPath))
        return;
      double height = this.Height;
      po.AddRemoteLink(inspt, this.Height * this.WidthFactor * (double) this.TextValue.Length, this.Height, this.LinkTargetPath, this.RotationAng);
    }

    public override void LinkInfoItem(LinkInfo li, Matrix matrix, Dictionary<int, object> objMap = null)
    {
      if (string.IsNullOrEmpty(this.LinkTargetPath))
        return;
      LinkItem linkItem = new LinkItem();
      linkItem.Target = this.LinkTargetPath;
      double height = this.Height;
      PointF[] pointFArray = new PointF[4]
      {
        new PointF(0.0f, 0.0f),
        new PointF((float) (this.Height * this.WidthFactor) * (float) this.TextValue.Length, 0.0f),
        new PointF((float) (this.Height * this.WidthFactor) * (float) this.TextValue.Length, (float) this.Height),
        new PointF(0.0f, (float) this.Height)
      };
      float num1 = (float) Math.Cos(this.RotationAng);
      float num2 = (float) Math.Sin(this.RotationAng);
      PointF[] pts = new PointF[4]
      {
        new PointF((float) ((double) pointFArray[0].X * (double) num1 - (double) num2 * (double) pointFArray[0].Y), (float) ((double) num2 * (double) pointFArray[0].X + (double) num1 * (double) pointFArray[0].Y)),
        new PointF((float) ((double) pointFArray[1].X * (double) num1 - (double) num2 * (double) pointFArray[1].Y), (float) ((double) num2 * (double) pointFArray[1].X + (double) num1 * (double) pointFArray[1].Y)),
        new PointF((float) ((double) pointFArray[2].X * (double) num1 - (double) num2 * (double) pointFArray[2].Y), (float) ((double) num2 * (double) pointFArray[2].X + (double) num1 * (double) pointFArray[2].Y)),
        new PointF((float) ((double) pointFArray[3].X * (double) num1 - (double) num2 * (double) pointFArray[3].Y), (float) ((double) num2 * (double) pointFArray[3].X + (double) num1 * (double) pointFArray[3].Y))
      };
      pts[0].X += (float) this.InsertionPt.x;
      pts[0].Y += (float) this.InsertionPt.y;
      pts[1].X += (float) this.InsertionPt.x;
      pts[1].Y += (float) this.InsertionPt.y;
      pts[2].X += (float) this.InsertionPt.x;
      pts[2].Y += (float) this.InsertionPt.y;
      pts[3].X += (float) this.InsertionPt.x;
      pts[3].Y += (float) this.InsertionPt.y;
      matrix.TransformPoints(pts);
      linkItem.Box = new double[8]
      {
        (double) pts[0].X,
        (double) pts[0].Y,
        (double) pts[1].X,
        (double) pts[1].Y,
        (double) pts[2].X,
        (double) pts[2].Y,
        (double) pts[3].X,
        (double) pts[3].Y
      };
      linkItem.Text = this.TextValue;
      li.LinkItems.Add(linkItem);
    }

    public byte DataFlags { get; set; }

    public double Elevation { get; set; }

    public Point2D InsertionPt { get; set; } = new Point2D();

    public Point2D AlignmentPt { get; set; } = new Point2D();

    public Point3D Extrusion { get; set; } = new Point3D();

    public double Thickness { get; set; }

    public double ObliqueAng { get; set; }

    public double RotationAng { get; set; }

    public double Height { get; set; }

    public double WidthFactor { get; set; } = 1.0;

    public int CharacterLength { get; set; }

    public string TextValue { get; set; }

    public int Generation { get; set; }

    public int HorizAlign { get; set; }

    public int VertAlign { get; set; }

    public HandleReference StyleHandle { get; set; }

    public int LinkTarget { get; set; }

    public string LinkTargetPath { get; set; }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      boundingBox.SetXY(this.InsertionPt.x, this.InsertionPt.y);
      return boundingBox;
    }

    public Text(DwgBitArray ba)
      : base(ba)
    {
      this.LoadTextData(ba);
      this.LoadCommonEntityHandleData(ba);
      this.StyleHandle = ba.ReadH();
      Console.WriteLine(string.Format("StyleHandle: {0}", (object) this.StyleHandle));
      ba.DumpBitIndex();
      Console.WriteLine("");
    }

    public override string ToString()
    {
      return this.TextValue;
    }

    public void LoadTextData(DwgBitArray ba)
    {
      this.DataFlags = ba.ReadByte();
      Console.WriteLine(string.Format("DataFlags:{0:x2}", (object) this.DataFlags));
      if (((int) this.DataFlags & 1) == 0)
        this.Elevation = ba.ReadRD();
      this.InsertionPt = ba.Read2RD();
      Console.WriteLine(string.Format("InsertionPt:\r\n{0}", (object) this.InsertionPt));
      if (((int) this.DataFlags & 2) == 0)
        this.AlignmentPt = ba.Read2DD(this.InsertionPt.x, this.InsertionPt.y);
      this.Extrusion = ba.ReadBE();
      Console.WriteLine(string.Format("Extrusion:{0}", (object) this.Extrusion));
      this.Thickness = ba.ReadBT();
      Console.WriteLine(string.Format("Thickness:{0}", (object) this.Thickness));
      if (((int) this.DataFlags & 4) == 0)
      {
        this.ObliqueAng = ba.ReadRD();
        Console.WriteLine(string.Format("ObliqueAng:{0}", (object) this.ObliqueAng));
      }
      if (((int) this.DataFlags & 8) == 0)
      {
        this.RotationAng = ba.ReadRD();
        Console.WriteLine(string.Format("RotationAng:{0}", (object) this.RotationAng));
      }
      this.Height = ba.ReadRD();
      Console.WriteLine(string.Format("Height:{0}", (object) this.Height));
      if (((int) this.DataFlags & 16) == 0)
      {
        this.WidthFactor = ba.ReadRD();
        Console.WriteLine(string.Format("WidthFactor:{0}", (object) this.WidthFactor));
      }
      if (((int) this.DataFlags & 32) == 0)
        this.Generation = (int) ba.ReadBS();
      if (((int) this.DataFlags & 64) == 0)
        this.HorizAlign = (int) ba.ReadBS();
      if (((int) this.DataFlags & 128) == 0)
        this.VertAlign = (int) ba.ReadBS();
      this.CharacterLength = (int) ba.ReadBS();
      Console.WriteLine(string.Format("CharacterLength:{0}", (object) this.CharacterLength));
      this.TextValue = Encoding.Unicode.GetString(ba.ReadBytes(2 * this.CharacterLength));
      Console.WriteLine("TextValue:\"" + this.TextValue + "\"");
      ba.DumpBitIndex();
      byte num1 = ba.ReadByte();
      byte num2 = ba.ReadByte();
      bool flag = ba.ReadB();
      Console.WriteLine(string.Format("b1: {0:x2}", (object) num1));
      Console.WriteLine(string.Format("b2: {0:x2}", (object) num2));
      Console.WriteLine(string.Format("b: {0}", (object) flag));
      ba.DumpBitIndex();
      Console.WriteLine("");
    }
  }
}
