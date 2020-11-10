// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2010.Objects.MLeaderAnnotContext
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2010.Objects
{
  public class MLeaderAnnotContext
  {
    public MLeaderAnnotContext(DwgBitArray ba)
    {
      this.loadMLeaderAnnotContextData(ba);
    }

    public int NumberOfLeaderRoots { get; set; }

    public List<LeaderRoot> LeaderRoots { get; set; } = new List<LeaderRoot>();

    public double OverallScale { get; set; }

    public Point3D ContentBasePoint { get; set; }

    public double TextHeight { get; set; }

    public double ArrowHeadSize { get; set; }

    public double LandingGap { get; set; }

    public int StyleLeftTextAttachmentType { get; set; }

    public int StyleRightTextAttachmentType { get; set; }

    public int TextAlignType { get; set; }

    public int AttachmentType { get; set; }

    public bool HasTextContents { get; set; }

    public string TextLabel { get; set; }

    public Point3D NormalVector { get; set; }

    public HandleReference TextStyleHandle { get; set; }

    public Point3D Location { get; set; }

    public Point3D Direction { get; set; }

    public double Rotation { get; set; }

    public double BoundaryWidth { get; set; }

    public double BoundaryHeight { get; set; }

    public double LineSpacingFactor { get; set; }

    public int LinSpacingStyle { get; set; }

    public CmColor TextColor { get; set; }

    public int Alignment { get; set; }

    public int FlowDirection { get; set; }

    public CmColor BackgroundFillColor { get; set; }

    public double BackgroundScaleFactor { get; set; }

    public int BackgroundTrasparency { get; set; }

    public bool IsBackgroundFillEnabled { get; set; }

    public bool IsBackgroundMaskFillon { get; set; }

    public int ColumnType { get; set; }

    public bool IsTextHeightAutomatic { get; set; }

    public double ColumnWidth { get; set; }

    public double ColumnGutter { get; set; }

    public bool ColumnFlowReversed { get; set; }

    public int ColumnSizesCount { get; set; }

    public List<double> ColumnSizes { get; set; } = new List<double>();

    public bool WordBreak { get; set; }

    public bool Unknown { get; set; }

    public bool HasContentBlock { get; set; }

    public HandleReference AcDbBlockTableRecordHandle { get; set; }

    public Point3D ScaleVector { get; set; }

    public CmColor BlockColor { get; set; }

    public double[] TransformationMatrix { get; set; } = new double[16];

    public Point3D BasePt { get; set; }

    public Point3D BaseDirection { get; set; }

    public Point3D BaseVertical { get; set; }

    public bool IsNormalReversed { get; set; }

    public int StyleTopAttachment { get; set; }

    public int StyleBottomAttachment { get; set; }

    private void loadMLeaderAnnotContextData(DwgBitArray ba)
    {
      this.NumberOfLeaderRoots = ba.ReadBL();
      Console.WriteLine(string.Format("NumberOfLeaderRoots: {0}", (object) this.NumberOfLeaderRoots));
      for (int index1 = 0; index1 < this.NumberOfLeaderRoots; ++index1)
      {
        LeaderRoot leaderRoot = new LeaderRoot();
        leaderRoot.IsContentValid = ba.ReadB();
        Console.WriteLine(string.Format("lr.IsContentValid: {0}", (object) leaderRoot.IsContentValid));
        leaderRoot.Unknown = ba.ReadB();
        Console.WriteLine(string.Format("lr.Unknown: {0}", (object) leaderRoot.Unknown));
        leaderRoot.ConnectionPoint = ba.Read3BD();
        Console.WriteLine(string.Format("lr.ConnectionPoint: {0}", (object) leaderRoot.ConnectionPoint));
        leaderRoot.Direction = ba.Read3BD();
        Console.WriteLine(string.Format("lr.Direction: {0}", (object) leaderRoot.Direction));
        leaderRoot.NumOfBreakStartEndPointPairs = ba.ReadBL();
        Console.WriteLine(string.Format("lr.NumOfBreakStartEndPointPairs: {0}", (object) leaderRoot.NumOfBreakStartEndPointPairs));
        for (int index2 = 0; index2 < leaderRoot.NumOfBreakStartEndPointPairs; ++index2)
        {
          PointPair pointPair = new PointPair();
          pointPair.StartPoint = ba.Read3BD();
          Console.WriteLine(string.Format("breakpp.BreakStartPoint: {0}", (object) pointPair.StartPoint));
          pointPair.EndPoint = ba.Read3BD();
          Console.WriteLine(string.Format("breakpp.BreakEndPoint: {0}", (object) pointPair.EndPoint));
          leaderRoot.BreakStartEndPointPairs.Add(pointPair);
        }
        leaderRoot.LeaderIndex = ba.ReadBL();
        Console.WriteLine(string.Format("lr.LeaderIndex: {0}", (object) leaderRoot.LeaderIndex));
        leaderRoot.LandingDistance = ba.ReadBD();
        Console.WriteLine(string.Format("lr.LandingDistance: {0}", (object) leaderRoot.LandingDistance));
        leaderRoot.NumOfLeaderLines = ba.ReadBL();
        Console.WriteLine(string.Format("lr.NumOfLeaderLines: {0}", (object) leaderRoot.NumOfLeaderLines));
        for (int index2 = 0; index2 < leaderRoot.NumOfLeaderLines; ++index2)
        {
          LeaderLine leaderLine = new LeaderLine();
          leaderLine.NumOfPoints = ba.ReadBL();
          Console.WriteLine(string.Format("ll.NumOfPoints: {0}", (object) leaderLine.NumOfPoints));
          for (int index3 = 0; index3 < leaderLine.NumOfPoints; ++index3)
          {
            Point3D point3D = ba.Read3BD();
            Console.WriteLine(string.Format("pt: {0}", (object) point3D));
            leaderLine.Points.Add(point3D);
          }
          leaderLine.BreakInfoCount = ba.ReadBL();
          Console.WriteLine(string.Format("ll.BreakInfoCount: {0}", (object) leaderLine.BreakInfoCount));
          leaderLine.SegmentIndex = ba.ReadBL();
          Console.WriteLine(string.Format("ll.SegmentIndex: {0}", (object) leaderLine.SegmentIndex));
          leaderLine.StartEndPointPairCount = ba.ReadBL();
          Console.WriteLine(string.Format("ll.StartEndPointPairCount: {0}", (object) leaderLine.StartEndPointPairCount));
          ba.DumpBitIndex();
          DwgBitArray dwgBitArray = ba;
          dwgBitArray.bitindex = dwgBitArray.bitindex;
          leaderLine.LineColor = ba.ReadCMC();
          Console.WriteLine(string.Format("ll.LineColor: {0}", (object) leaderLine.LineColor));
          leaderLine.LineWeight = ba.ReadBL();
          Console.WriteLine(string.Format("ll.LineWeight: {0}", (object) leaderLine.LineWeight));
          leaderLine.ArrowSize = ba.ReadBD();
          Console.WriteLine(string.Format("ll.ArrowSize: {0}", (object) leaderLine.ArrowSize));
          leaderLine.OverrideFlags = ba.ReadBL();
          Console.WriteLine(string.Format("ll.OverrideFlags: {0}", (object) leaderLine.OverrideFlags));
          leaderRoot.LeaderLines.Add(leaderLine);
        }
        leaderRoot.AttachmentDirection = (int) ba.ReadBS();
        Console.WriteLine(string.Format("lr.AttachmentDirection: {0}", (object) leaderRoot.AttachmentDirection));
        this.LeaderRoots.Add(leaderRoot);
      }
      Console.WriteLine("");
      this.OverallScale = ba.ReadBD();
      Console.WriteLine(string.Format("OverallScale: {0}", (object) this.OverallScale));
      this.ContentBasePoint = ba.Read3BD();
      Console.WriteLine(string.Format("ContentBasePoint: {0}", (object) this.ContentBasePoint));
      this.TextHeight = ba.ReadBD();
      Console.WriteLine(string.Format("TextHeight: {0}", (object) this.TextHeight));
      this.ArrowHeadSize = ba.ReadBD();
      Console.WriteLine(string.Format("ArrowHeadSize: {0}", (object) this.ArrowHeadSize));
      this.LandingGap = ba.ReadBD();
      Console.WriteLine(string.Format("LandingGap: {0}", (object) this.LandingGap));
      this.StyleLeftTextAttachmentType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleLeftTextAttachmentType: {0}", (object) this.StyleLeftTextAttachmentType));
      this.StyleRightTextAttachmentType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleRightTextAttachmentType: {0}", (object) this.StyleRightTextAttachmentType));
      this.TextAlignType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("TextAlignType: {0}", (object) this.TextAlignType));
      this.AttachmentType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("AttachmentType: {0}", (object) this.AttachmentType));
      this.HasTextContents = ba.ReadB();
      Console.WriteLine(string.Format("HasTextContents: {0}", (object) this.HasTextContents));
      if (this.HasTextContents)
      {
        this.NormalVector = ba.Read3BD();
        Console.WriteLine(string.Format("NormalVector: {0}", (object) this.NormalVector));
        this.Location = ba.Read3BD();
        Console.WriteLine(string.Format("Location: {0}", (object) this.Location));
        this.Direction = ba.Read3BD();
        Console.WriteLine(string.Format("Direction: {0}", (object) this.Direction));
        this.Rotation = ba.ReadBD();
        Console.WriteLine(string.Format("Rotation: {0}", (object) this.Rotation));
        this.BoundaryWidth = ba.ReadBD();
        Console.WriteLine(string.Format("BoundaryWidth: {0}", (object) this.BoundaryWidth));
        this.BoundaryHeight = ba.ReadBD();
        Console.WriteLine(string.Format("BoundaryHeight: {0}", (object) this.BoundaryHeight));
        this.LineSpacingFactor = ba.ReadBD();
        Console.WriteLine(string.Format("LineSpacingFactor: {0}", (object) this.LineSpacingFactor));
        this.LinSpacingStyle = (int) ba.ReadBS();
        Console.WriteLine(string.Format("LinSpacingStyle: {0}", (object) this.LinSpacingStyle));
        this.TextColor = ba.ReadCMC();
        Console.WriteLine(string.Format("TextColor: {0}", (object) this.TextColor));
        this.Alignment = (int) ba.ReadBS();
        Console.WriteLine(string.Format("Alignment: {0}", (object) this.Alignment));
        this.FlowDirection = (int) ba.ReadBS();
        Console.WriteLine(string.Format("FlowDirection: {0}", (object) this.FlowDirection));
        this.BackgroundFillColor = ba.ReadCMC();
        Console.WriteLine(string.Format("BackgroundFillColor: {0}", (object) this.BackgroundFillColor));
        this.BackgroundScaleFactor = ba.ReadBD();
        Console.WriteLine(string.Format("BackgroundScaleFactor: {0}", (object) this.BackgroundScaleFactor));
        this.BackgroundTrasparency = ba.ReadBL();
        Console.WriteLine(string.Format("BackgroundTrasparency: {0}", (object) this.BackgroundTrasparency));
        this.IsBackgroundFillEnabled = ba.ReadB();
        Console.WriteLine(string.Format("IsBackgroundFillEnabled: {0}", (object) this.IsBackgroundFillEnabled));
        this.IsBackgroundMaskFillon = ba.ReadB();
        Console.WriteLine(string.Format("IsBackgroundMaskFillon: {0}", (object) this.IsBackgroundMaskFillon));
        this.ColumnType = (int) ba.ReadBS();
        Console.WriteLine(string.Format("ColumnType: {0}", (object) this.ColumnType));
        this.IsTextHeightAutomatic = ba.ReadB();
        Console.WriteLine(string.Format("IsTextHeightAutomatic: {0}", (object) this.IsTextHeightAutomatic));
        this.ColumnWidth = ba.ReadBD();
        Console.WriteLine(string.Format("ColumnWidth: {0}", (object) this.ColumnWidth));
        this.ColumnGutter = ba.ReadBD();
        Console.WriteLine(string.Format("ColumnGutter: {0}", (object) this.ColumnGutter));
        this.ColumnFlowReversed = ba.ReadB();
        Console.WriteLine(string.Format("ColumnFlowReversed: {0}", (object) this.ColumnFlowReversed));
        this.ColumnSizesCount = ba.ReadBL();
        Console.WriteLine(string.Format("ColumnSizesCount: {0}", (object) this.ColumnSizesCount));
        for (int index = 0; index < this.ColumnSizesCount; ++index)
        {
          double num = ba.ReadBD();
          Console.WriteLine(string.Format("columnSize: {0}", (object) num));
          this.ColumnSizes.Add(num);
        }
        this.WordBreak = ba.ReadB();
        Console.WriteLine(string.Format("WordBreak: {0}", (object) this.WordBreak));
        this.Unknown = ba.ReadB();
        Console.WriteLine(string.Format("Unknown: {0}", (object) this.Unknown));
      }
      else
      {
        this.HasContentBlock = ba.ReadB();
        Console.WriteLine(string.Format("HasContentBlock: {0}", (object) this.HasContentBlock));
        if (this.HasContentBlock)
          throw new NotImplementedException();
      }
      this.BasePt = ba.Read3BD();
      Console.WriteLine(string.Format("BasePt: {0}", (object) this.BasePt));
      this.BaseDirection = ba.Read3BD();
      Console.WriteLine(string.Format("BaseDirection: {0}", (object) this.BaseDirection));
      this.BaseVertical = ba.Read3BD();
      Console.WriteLine(string.Format("BaseVertical: {0}", (object) this.BaseVertical));
      this.IsNormalReversed = ba.ReadB();
      Console.WriteLine(string.Format("IsNormalReversed: {0}", (object) this.IsNormalReversed));
      this.StyleTopAttachment = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleTopAttachment: {0}", (object) this.StyleTopAttachment));
      this.StyleBottomAttachment = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleBottomAttachment: {0}", (object) this.StyleBottomAttachment));
    }
  }
}
