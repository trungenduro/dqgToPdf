// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.MLeader
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class MLeader : dqgToPdf.Dwg.R2004.CommonEntityData
  {
    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      return base.GetBoundingBox(objMap);
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      foreach (LeaderRoot leaderRoot in this.MLeaderAnnotContext.LeaderRoots)
      {
        Point2D point2d1 = leaderRoot.ConnectionPoint.ToPoint2d();
        po.StartStroke(point2d1);
        foreach (LeaderLine leaderLine in leaderRoot.LeaderLines)
        {
          foreach (Point3D point in leaderLine.Points)
          {
            Point2D point2d2 = point.ToPoint2d();
            po.StrokeLine(point2d2);
          }
          po.EndStroke();
        }
        Point2D point2d3 = leaderRoot.ConnectionPoint.ToPoint2d();
        po.StartStroke(point2d3);
        Point2D point2d4 = this.MLeaderAnnotContext.ContentBasePoint.ToPoint2d();
        po.StrokeLine(point2d4);
        po.EndStroke();
      }
      string unifontName = (string) null;
      string bigfontName = (string) null;
      if (this.MLeaderAnnotContext.TextStyleHandle != null)
      {
        int targetHandle = this.MLeaderAnnotContext.TextStyleHandle.getTargetHandle(this.ObjId);
        if (targetHandle != 0)
        {
          ShapeFile shapeFile = (ShapeFile) objMap[targetHandle];
          unifontName = shapeFile.FontName;
          bigfontName = shapeFile.BigFontName;
        }
      }
      MLeaderAnnotContext mleaderAnnotContext = this.MLeaderAnnotContext;
      po.AddText("%%U" + mleaderAnnotContext.TextLabel, mleaderAnnotContext.ContentBasePoint.ToPoint2d(), mleaderAnnotContext.Direction.ToPoint2d(), mleaderAnnotContext.TextHeight, mleaderAnnotContext.TextHeight, unifontName, bigfontName);
    }

    public MLeader(DwgBitArray ba)
      : base(ba)
    {
      this.loadMLeaderData(ba);
    }

    public int Version { get; set; }

    public HandleReference LeaderStyleHandle { get; set; }

    public int OverrideFlags { get; set; }

    public int LeaderType { get; set; }

    public CmColor LeaderColor { get; set; }

    public HandleReference LeaderLineTypeHandle { get; set; }

    public int LineWeight { get; set; }

    public bool LandingEnabled { get; set; }

    public bool DogLegEnabled { get; set; }

    public double LandingDistance { get; set; }

    public HandleReference ArrowHeadHandle { get; set; }

    public double DefaultArrowHeadSize { get; set; }

    public int StyleContentType { get; set; }

    public HandleReference StyleTextStyleHandle { get; set; }

    public int StyleLeftTextAttachmentType { get; set; }

    public int StyleRightTextAttachment { get; set; }

    public int StyleTextAngleType { get; set; }

    public int Unknown { get; set; }

    public CmColor StyleTextColor { get; set; }

    public bool StyleTextFrameEnabled { get; set; }

    public HandleReference StyleBlockHandle { get; set; }

    public CmColor StyleBlockColor { get; set; }

    public Point3D StyleBlockScaleVector { get; set; }

    public double StyleBlockRotation { get; set; }

    public int StyleAttachmentType { get; set; }

    public bool IsAnnotative { get; set; }

    public int NumberOfArrowHeads { get; set; }

    public bool IsTextDirectionNegative { get; set; }

    public int IPEAlign { get; set; }

    public int Justification { get; set; }

    public double ScaleFactor { get; set; }

    public int AttachmentDirection { get; set; }

    public int NumberOfBlockLabels { get; set; }

    public int StyleTopTextAttachment { get; set; }

    public int StyleBottomTextAttachmentType { get; set; }

    public bool LeaderExtendedToText { get; set; }

    public AcDbAnnotScaleObjectContextData annotScaleObjContextData { get; set; }

    public MLeaderAnnotContext MLeaderAnnotContext { get; set; }

    private void loadMLeaderData(DwgBitArray ba)
    {
      this.MLeaderAnnotContext = new MLeaderAnnotContext(ba);
      ba.DumpBitIndex();
      this.OverrideFlags = ba.ReadBL();
      Console.WriteLine(string.Format("OverrideFlags: {0}", (object) this.OverrideFlags));
      this.LeaderType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("LeaderType: {0}", (object) this.LeaderType));
      this.LeaderColor = ba.ReadCMC();
      Console.WriteLine(string.Format("LeaderColor: {0}", (object) this.LeaderColor));
      this.LineWeight = ba.ReadBL();
      Console.WriteLine(string.Format("LineWeight: {0}", (object) this.LineWeight));
      this.LandingEnabled = ba.ReadB();
      Console.WriteLine(string.Format("LandingEnabled: {0}", (object) this.LandingEnabled));
      this.DogLegEnabled = ba.ReadB();
      Console.WriteLine(string.Format("DogLegEnabled: {0}", (object) this.DogLegEnabled));
      this.LandingDistance = ba.ReadBD();
      Console.WriteLine(string.Format("LandingDistance: {0}", (object) this.LandingDistance));
      this.DefaultArrowHeadSize = ba.ReadBD();
      Console.WriteLine(string.Format("DefaultArrowHeadSize: {0}", (object) this.DefaultArrowHeadSize));
      this.StyleContentType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleContentType: {0}", (object) this.StyleContentType));
      this.StyleLeftTextAttachmentType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleLeftTextAttachmentType: {0}", (object) this.StyleLeftTextAttachmentType));
      this.StyleRightTextAttachment = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleRightTextAttachment: {0}", (object) this.StyleRightTextAttachment));
      this.StyleTextAngleType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleTextAngleType: {0}", (object) this.StyleTextAngleType));
      this.Unknown = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Unknown: {0}", (object) this.Unknown));
      this.StyleTextColor = ba.ReadCMC();
      Console.WriteLine(string.Format("StyleTextColor: {0}", (object) this.StyleTextColor));
      this.StyleTextFrameEnabled = ba.ReadB();
      Console.WriteLine(string.Format("StyleTextFrameEnabled: {0}", (object) this.StyleTextFrameEnabled));
      this.StyleBlockColor = ba.ReadCMC();
      Console.WriteLine(string.Format("StyleBlockColor: {0}", (object) this.StyleBlockColor));
      this.StyleBlockScaleVector = ba.Read3BD();
      Console.WriteLine(string.Format("StyleBlockScaleVector: {0}", (object) this.StyleBlockScaleVector));
      this.StyleBlockRotation = ba.ReadBD();
      Console.WriteLine(string.Format("StyleBlockRotation: {0}", (object) this.StyleBlockRotation));
      this.StyleAttachmentType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleAttachmentType: {0}", (object) this.StyleAttachmentType));
      this.IsAnnotative = ba.ReadB();
      Console.WriteLine(string.Format("IsAnnotative: {0}", (object) this.IsAnnotative));
      this.NumberOfArrowHeads = ba.ReadBL();
      Console.WriteLine(string.Format("NumberOfArrowHeads: {0}", (object) this.NumberOfArrowHeads));
      if (this.NumberOfArrowHeads > 0)
        throw new NotImplementedException();
      this.NumberOfBlockLabels = ba.ReadBL();
      Console.WriteLine(string.Format("NumberOfBlockLabels: {0}", (object) this.NumberOfBlockLabels));
      if (this.NumberOfBlockLabels > 0)
        throw new NotImplementedException();
      this.IsTextDirectionNegative = ba.ReadB();
      Console.WriteLine(string.Format("IsTextDirectionNegative: {0}", (object) this.IsTextDirectionNegative));
      this.IPEAlign = (int) ba.ReadBS();
      Console.WriteLine(string.Format("IPEAlign: {0}", (object) this.IPEAlign));
      this.Justification = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Justification: {0}", (object) this.Justification));
      this.ScaleFactor = ba.ReadBD();
      Console.WriteLine(string.Format("ScaleFactor: {0}", (object) this.ScaleFactor));
      ba.DumpBitIndex();
      this.LoadCommonEntityHandleData(ba);
      if (!this.MLeaderAnnotContext.HasTextContents)
        throw new NotImplementedException();
      this.MLeaderAnnotContext.TextStyleHandle = ba.ReadH();
      Console.WriteLine(string.Format("MLeaderAnnotContext.TextStyleHandle: {0}", (object) this.MLeaderAnnotContext.TextStyleHandle));
      this.LeaderStyleHandle = ba.ReadH();
      Console.WriteLine(string.Format("LeaderStyleHandle: {0}", (object) this.LeaderStyleHandle));
      this.LeaderLineTypeHandle = ba.ReadH();
      Console.WriteLine(string.Format("LeaderLineTypeHandle: {0}", (object) this.LeaderLineTypeHandle));
      this.ArrowHeadHandle = ba.ReadH();
      Console.WriteLine(string.Format("ArrowHeadHandle: {0}", (object) this.ArrowHeadHandle));
      this.StyleTextStyleHandle = ba.ReadH();
      Console.WriteLine(string.Format("StyleTextStyleHandle: {0}", (object) this.StyleTextStyleHandle));
      ba.DumpBitIndex();
      Console.WriteLine("");
    }
  }
}
