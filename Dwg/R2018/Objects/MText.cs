// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2018.Objects.MText
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace dqgToPdf.Dwg.R2018.Objects
{
  public class MText : CommonEntityData
  {
    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      return base.GetBoundingBox(objMap);
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      string unifontName = (string) null;
      string bigfontName = (string) null;
      if (this.StyleHandle != null)
      {
        int targetHandle = this.StyleHandle.getTargetHandle(this.ObjId);
        if (targetHandle != 0 && objMap.ContainsKey(targetHandle))
        {
          ShapeFile shapeFile = (ShapeFile) objMap[targetHandle];
          unifontName = shapeFile.FontName;
          bigfontName = shapeFile.BigFontName;
        }
      }
      string[] strArray = Regex.Replace(this.Text, "^\\\\A\\d;", "").Split(new string[1]
      {
        "\\P"
      }, StringSplitOptions.None);
      Point2D point2D = this.XAxisDir.ToPoint2d().Rotate(3.0 * Math.PI / 2.0);
      Point2D InsertPt = this.InsertPt.ToPoint2d() + point2D * this.TextHeight / 2.0;
      point2D.Normlize();
      foreach (string text1 in strArray)
      {
        if (text1.StartsWith("\\S"))
        {
          string str = text1.Replace("\\S", "");
          string[] separator = new string[1]{ "^" };
          foreach (string text2 in str.Split(separator, StringSplitOptions.None))
          {
            po.AddText(text2, InsertPt, this.XAxisDir.ToPoint2d(), this.TextHeight, this.TextHeight * 1.0, unifontName, bigfontName);
            InsertPt = InsertPt + point2D * this.TextHeight + point2D * this.TextHeight / 2.0;
          }
        }
        else
        {
          po.AddText(text1, InsertPt, this.XAxisDir.ToPoint2d(), this.TextHeight, this.TextHeight * 1.0, unifontName, bigfontName);
          InsertPt += point2D * this.TextHeight;
        }
        InsertPt += point2D * this.TextHeight;
      }
    }

    public MText(DwgBitArray ba)
      : base(ba)
    {
      this.LoadMTextData(ba);
      this.LoadCommonEntityHandleData(ba);
      this.StyleHandle = ba.ReadH();
      Console.WriteLine(string.Format("StyleHandle: {0}", (object) this.StyleHandle));
      if (this.IsNotAnotative)
      {
        this.RegisteredApplication_Redundant = ba.ReadH();
        Console.WriteLine(string.Format("RegisteredApplication_Redundant: {0}", (object) this.RegisteredApplication_Redundant));
      }
      ba.DumpBitIndex();
      Console.WriteLine();
    }

    public Point3D InsertPt { get; set; }

    public Point3D Extrusion { get; set; }

    public Point3D XAxisDir { get; set; }

    public double RectWidth { get; set; }

    public double RectHeight { get; set; }

    public double TextHeight { get; set; }

    public int Attachment { get; set; }

    public int DrawingDir { get; set; }

    public double ExtentsHeight { get; set; }

    public double ExtentsWidth { get; set; }

    public string Text { get; set; }

    public HandleReference StyleHandle { get; set; }

    public int LineSpacingStyle { get; set; }

    public double LinespacingFactor { get; set; }

    public bool UnknownBit { get; set; }

    public int BackgroundFlags { get; set; }

    public int BackgroundScaleFactor { get; set; }

    public CmColor BackgroundColor { get; set; }

    public int BackgroundTrasParency { get; set; }

    public bool IsNotAnotative { get; set; }

    public int Version { get; set; }

    public bool DefaultFlag { get; set; }

    public HandleReference RegisteredApplication_Redundant { get; set; }

    public int AttachmentPoint_Redundant { get; set; }

    public Point3D XaxisDir_Redundant { get; set; }

    public Point3D InsertionPoint_Redundant { get; set; }

    public double RectWidth_Redundant { get; set; }

    public double RectHeight_Redundant { get; set; }

    public double ExtentsWidth_Redaudant { get; set; }

    public double ExtentsHeight_Redaudant { get; set; }

    public int ColumnType { get; set; }

    public int ColumnHeightCount { get; set; }

    public double ColumnWidth { get; set; }

    public double Gutter { get; set; }

    public bool AutoHeight { get; set; }

    public bool FlowReversed { get; set; }

    public List<double> ColumnHeights { get; set; } = new List<double>();

    private void LoadMTextData(DwgBitArray ba)
    {
      this.InsertPt = ba.Read3BD();
      Console.WriteLine(string.Format("InsertPt: {0}", (object) this.InsertPt));
      this.Extrusion = ba.Read3BD();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.XAxisDir = ba.Read3BD();
      Console.WriteLine(string.Format("XAxisDir: {0}", (object) this.XAxisDir));
      this.RectWidth = ba.ReadBD();
      Console.WriteLine(string.Format("RectWidth: {0}", (object) this.RectWidth));
      this.RectHeight = ba.ReadBD();
      Console.WriteLine(string.Format("RectHeight: {0}", (object) this.RectHeight));
      this.TextHeight = ba.ReadBD();
      Console.WriteLine(string.Format("TextHeight: {0}", (object) this.TextHeight));
      this.Attachment = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Attachment: {0}", (object) this.Attachment));
      this.DrawingDir = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DrawingDir: {0}", (object) this.DrawingDir));
      this.ExtentsHeight = ba.ReadBD();
      Console.WriteLine(string.Format("ExtentsHeight: {0}", (object) this.ExtentsHeight));
      this.ExtentsWidth = ba.ReadBD();
      Console.WriteLine(string.Format("ExtentsWidth: {0}", (object) this.ExtentsWidth));
      this.LineSpacingStyle = (int) ba.ReadBS();
      Console.WriteLine(string.Format("LineSpacingStyle: {0}", (object) this.LineSpacingStyle));
      this.LinespacingFactor = ba.ReadBD();
      Console.WriteLine(string.Format("LinespacingFactor: {0}", (object) this.LinespacingFactor));
      this.UnknownBit = ba.ReadB();
      Console.WriteLine(string.Format("UnknownBit: {0}", (object) this.UnknownBit));
      this.BackgroundFlags = ba.ReadBL();
      Console.WriteLine(string.Format("BackgroundFlags: {0}", (object) this.BackgroundFlags));
      if ((this.BackgroundFlags & 1) != 0)
      {
        Console.WriteLine(string.Format("BackgroundScaleFactor: {0}", (object) ba.ReadBD()));
        this.BackgroundColor = ba.ReadCMC();
        Console.WriteLine(string.Format("BackgroundColor: {0}", (object) this.BackgroundColor));
        this.BackgroundTrasParency = ba.ReadBL();
        Console.WriteLine(string.Format("BackgroundTrasParency: {0}", (object) this.BackgroundTrasParency));
      }
      this.IsNotAnotative = ba.ReadB();
      Console.WriteLine(string.Format("IsNotAnotative: {0}", (object) this.IsNotAnotative));
      if (this.IsNotAnotative)
      {
        this.Version = (int) ba.ReadBS();
        Console.WriteLine(string.Format("Version: {0}", (object) this.Version));
        this.DefaultFlag = ba.ReadB();
        Console.WriteLine(string.Format("DefaultFlag: {0}", (object) this.DefaultFlag));
        this.AttachmentPoint_Redundant = ba.ReadBL();
        Console.WriteLine(string.Format("AttachmentPoint_Redundant: {0}", (object) this.AttachmentPoint_Redundant));
        this.XaxisDir_Redundant = ba.Read3BD();
        Console.WriteLine(string.Format("XaxisDir_Redundant: {0}", (object) this.XaxisDir_Redundant));
        this.InsertionPoint_Redundant = ba.Read3BD();
        Console.WriteLine(string.Format("InsertionPoint_Redundant: {0}", (object) this.InsertionPoint_Redundant));
        this.RectWidth_Redundant = ba.ReadBD();
        Console.WriteLine(string.Format("RectWidth_Redundant: {0}", (object) this.RectWidth_Redundant));
        this.RectHeight = ba.ReadBD();
        Console.WriteLine(string.Format("RectHeight: {0}", (object) this.RectHeight));
        this.ExtentsWidth_Redaudant = ba.ReadBD();
        Console.WriteLine(string.Format("ExtentsWidth_Redaudant: {0}", (object) this.ExtentsWidth_Redaudant));
        this.ExtentsHeight_Redaudant = ba.ReadBD();
        Console.WriteLine(string.Format("ExtentsHeight_Redaudant: {0}", (object) this.ExtentsHeight_Redaudant));
        this.ColumnType = (int) ba.ReadBS();
        Console.WriteLine(string.Format("ColumnType: {0}", (object) this.ColumnType));
        if (this.ColumnType != 0)
        {
          this.ColumnHeightCount = ba.ReadBL();
          Console.WriteLine(string.Format("ColumnHeightCount: {0}", (object) this.ColumnHeightCount));
          this.ColumnWidth = ba.ReadBD();
          Console.WriteLine(string.Format("ColumnWidth: {0}", (object) this.ColumnWidth));
          this.Gutter = ba.ReadBD();
          Console.WriteLine(string.Format("Gutter: {0}", (object) this.Gutter));
          this.AutoHeight = ba.ReadB();
          Console.WriteLine(string.Format("AutoHeight: {0}", (object) this.AutoHeight));
          this.FlowReversed = ba.ReadB();
          Console.WriteLine(string.Format("FlowReversed: {0}", (object) this.FlowReversed));
          if (!this.AutoHeight && this.ColumnType == 2)
          {
            for (int index = 0; index < this.ColumnHeightCount; ++index)
            {
              double num = ba.ReadBD();
              Console.WriteLine(string.Format("columnHeight: {0}", (object) num));
              this.ColumnHeights.Add(num);
            }
          }
        }
      }
      this.Text = ba.ReadTU();
      Console.WriteLine("Text: " + this.Text);
      ba.bitindex += 17;
      ba.DumpBitIndex();
    }
  }
}
