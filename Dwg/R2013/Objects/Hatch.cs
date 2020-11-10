// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Hatch
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Common;
using dqgToPdf.Pdf.Contents;
using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Hatch : CommonEntityData
  {
    public override void WritePdf(PageObject po, Dictionary<int, object> objMap = null)
    {
      bool flag = false;
      for (int index1 = 0; index1 < this.Paths.Count; ++index1)
      {
        Path path = this.Paths[index1];
        if ((path.PathFlag & 2) == 0)
        {
          foreach (PathSeg pathSeg in path.PathSegs)
          {
            switch (pathSeg.PathTypeStatus)
            {
              case 1:
                Console.WriteLine(string.Format("ps.Pt0: {0}", (object) pathSeg.Pt0));
                Console.WriteLine(string.Format("ps.Pt1: {0}", (object) pathSeg.Pt1));
                po.StrokeLine(pathSeg.Pt0, ref flag);
                po.StrokeLine(pathSeg.Pt1);
                continue;
              case 2:
                Console.WriteLine(string.Format("ps.Pt0: {0}", (object) pathSeg.Pt0));
                Console.WriteLine(string.Format("ps.Radius: {0}", (object) pathSeg.Radius));
                Console.WriteLine(string.Format("ps.StartAngle: {0}", (object) pathSeg.StartAngle));
                Console.WriteLine(string.Format("ps.EndAngle: {0}", (object) pathSeg.EndAngle));
                Console.WriteLine(string.Format("ps.IsCcw: {0}", (object) pathSeg.IsCcw));
                Point2D pt0 = pathSeg.Pt0;
                po.AddArcWithIsCcw(pt0, pathSeg.Radius, pathSeg.StartAngle, pathSeg.EndAngle, pathSeg.IsCcw, ref flag);
                continue;
              case 3:
                Console.WriteLine(string.Format("ps.Pt0: {0}", (object) pathSeg.Pt0));
                Console.WriteLine(string.Format("ps.EndPoint: {0}", (object) pathSeg.EndPoint));
                Console.WriteLine(string.Format("ps.MinorMajorRatio: {0}", (object) pathSeg.MinorMajorRatio));
                Console.WriteLine(string.Format("ps.StartAngle: {0}", (object) pathSeg.StartAngle));
                Console.WriteLine(string.Format("ps.EndAngle: {0}", (object) pathSeg.EndAngle));
                Console.WriteLine(string.Format("ps.IsCcw: {0}", (object) pathSeg.IsCcw));
                po.StrokeElliticalArc(pathSeg.Pt0, pathSeg.EndPoint, pathSeg.MinorMajorRatio, pathSeg.StartAngle, pathSeg.EndAngle, pathSeg.IsCcw, ref flag);
                continue;
              case 4:
                Console.WriteLine(string.Format("ps.Degree: {0}", (object) pathSeg.Degree));
                Console.WriteLine(string.Format("ps.IsRational: {0}", (object) pathSeg.IsRational));
                Console.WriteLine(string.Format("ps.IsPeriodic: {0}", (object) pathSeg.IsPeriodic));
                Console.WriteLine(string.Format("ps.NumKnots: {0}", (object) pathSeg.NumKnots));
                Console.WriteLine(string.Format("ps.NumControlPoints: {0}", (object) pathSeg.NumControlPoints));
                List<Point2D> ControlPts = new List<Point2D>();
                foreach (CtlPt ctlPt in pathSeg.CtlPts)
                  ControlPts.Add(ctlPt.Pt0);
                List<double> knots = new List<double>();
                foreach (double knot in pathSeg.Knots)
                  knots.Add(knot);
                List<Point2D> source = BSpline.CalcBspline(ControlPts, knots, pathSeg.Degree, pathSeg.NumControlPoints * 4);
                foreach (Point2D p in source)
                  po.StrokeLine(p, ref flag);
                if ((source.First<Point2D>() - source.Last<Point2D>()).Length() < 1E-13)
                {
                  po.CloseSubpath();
                  flag = false;
                  continue;
                }
                continue;
              default:
                throw new NotImplementedException();
            }
          }
        }
        else if (this.SeedPoints.Count != 0)
        {
          if (!path.BulgePresent)
          {
            for (int index2 = 0; index2 < path.Bulges.Count; ++index2)
              po.StrokeLine(path.Bulges[index2].Pt0, ref flag);
          }
        }
        else if (!path.BulgePresent)
        {
          for (int index2 = 0; index2 < path.Bulges.Count; ++index2)
            po.StrokeLine(path.Bulges[index2].Pt0, ref flag);
        }
        if (path.Closed)
        {
          po.CloseSubpath();
          flag = false;
        }
        Console.WriteLine(string.Format("path.NumBoundayObjHandles: {0}", (object) path.NumBoundayObjHandles));
      }
      po.EndStroke(this.Solidfill);
      if (!this.Solidfill)
      {
        Console.WriteLine(string.Format("Angle: {0}", (object) this.Angle));
        Console.WriteLine(string.Format("ScaleOrSpacing: {0}", (object) this.ScaleOrSpacing));
        Console.WriteLine(string.Format("DoubleHatch: {0}", (object) this.DoubleHatch));
        Console.WriteLine(string.Format("NumDefLines: {0}", (object) this.NumDefLines));
        foreach (DefLine defLine in this.DefLines)
        {
          Console.WriteLine(string.Format("defLine.Angle: {0}", (object) defLine.Angle));
          Console.WriteLine(string.Format("defLine.Pt0: {0}", (object) defLine.Pt0));
          Console.WriteLine(string.Format("defLine.Offset: {0}", (object) defLine.Offset));
          Console.WriteLine(string.Format("defLine.NumDashes: {0}", (object) defLine.NumDashes));
          foreach (double dashLength in defLine.DashLengths)
            Console.WriteLine(string.Format("dashlength: {0}", (object) dashLength));
        }
      }
      foreach (object seedPoint in this.SeedPoints)
        Console.WriteLine(string.Format("pt_0: {0}", seedPoint));
    }

    public Hatch(DwgBitArray ba)
      : base(ba)
    {
      this.LoadHatchData(ba);
      this.LoadCommonEntityHandleData(ba);
      int num = this.Paths.Select<Path, int>((Func<Path, int>) (x => x.NumBoundayObjHandles)).Aggregate<int>((Func<int, int, int>) ((x, y) => x + y));
      Console.WriteLine(string.Format("totalBoundItems: {0}", (object) num));
      for (int index = 0; index < num; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("boundaryHandle: {0}", (object) handleReference));
        this.BoundaryHandles.Add(handleReference);
      }
      ba.DumpBitIndex();
      Console.WriteLine();
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      foreach (Path path in this.Paths)
      {
        if ((path.PathFlag & 2) == 0)
        {
          foreach (PathSeg pathSeg in path.PathSegs)
          {
            switch (pathSeg.PathTypeStatus)
            {
              case 1:
                boundingBox.SetXY(pathSeg.Pt0.x, pathSeg.Pt0.y);
                boundingBox.SetXY(pathSeg.Pt1.x, pathSeg.Pt1.y);
                continue;
              case 2:
                boundingBox.SetXY(pathSeg.Pt0.x, pathSeg.Pt0.y);
                continue;
              case 3:
                boundingBox.SetXY(pathSeg.Pt0.x, pathSeg.Pt0.y);
                boundingBox.SetXY(pathSeg.EndPoint.x, pathSeg.EndPoint.y);
                continue;
              case 4:
                using (List<CtlPt>.Enumerator enumerator = pathSeg.CtlPts.GetEnumerator())
                {
                  while (enumerator.MoveNext())
                  {
                    Point2D pt0 = enumerator.Current.Pt0;
                    boundingBox.AddBoudingBox(pt0.x, pt0.y);
                  }
                  continue;
                }
              default:
                throw new NotImplementedException();
            }
          }
        }
        else
        {
          foreach (Bulge bulge in path.Bulges)
            boundingBox.SetXY(bulge.Pt0.x, bulge.Pt0.y);
        }
      }
      return boundingBox;
    }

    public int IsGradientFill { get; set; }

    public int Reserved { get; set; }

    public double GradientAngle { get; set; }

    public double GradientShift { get; set; }

    public int SingleColorGrad { get; set; }

    public double GradientTint { get; set; }

    public int NumGradientColors { get; set; }

    public List<GradientColor> GradientColors { get; set; } = new List<GradientColor>();

    public string GradientName { get; set; }

    public double Zcoord { get; set; }

    public Point3D Extrusion { get; set; }

    public string Name { get; set; }

    public bool Solidfill { get; set; }

    public bool Associative { get; set; }

    public int NumPaths { get; set; }

    public List<Path> Paths { get; set; } = new List<Path>();

    public int StyleOfHatch { get; set; }

    public int PatternType { get; set; }

    public double Angle { get; set; }

    public double ScaleOrSpacing { get; set; }

    public bool DoubleHatch { get; set; }

    public int NumDefLines { get; set; }

    public List<DefLine> DefLines { get; set; } = new List<DefLine>();

    public bool AnyPathFlags { get; set; }

    public double PixelSize { get; set; }

    public int NumSeedPoints { get; set; }

    public List<Point2D> SeedPoints { get; set; } = new List<Point2D>();

    public List<HandleReference> BoundaryHandles { get; set; } = new List<HandleReference>();

    private void LoadHatchData(DwgBitArray ba)
    {
      this.IsGradientFill = ba.ReadBL();
      Console.WriteLine(string.Format("IsGradientFill: {0}", (object) this.IsGradientFill));
      this.Reserved = ba.ReadBL();
      Console.WriteLine(string.Format("Reserved: {0}", (object) this.Reserved));
      this.GradientAngle = ba.ReadBD();
      Console.WriteLine(string.Format("GradientAngle: {0}", (object) this.GradientAngle));
      this.GradientShift = ba.ReadBD();
      Console.WriteLine(string.Format("GradientShift: {0}", (object) this.GradientShift));
      this.SingleColorGrad = ba.ReadBL();
      Console.WriteLine(string.Format("SingleColorGrad: {0}", (object) this.SingleColorGrad));
      this.GradientTint = ba.ReadBD();
      Console.WriteLine(string.Format("GradientTint: {0}", (object) this.GradientTint));
      this.NumGradientColors = ba.ReadBL();
      Console.WriteLine(string.Format("NumGradientColors: {0}", (object) this.NumGradientColors));
      for (int index = 0; index < this.NumGradientColors; ++index)
      {
        GradientColor gradientColor = new GradientColor();
        gradientColor.UnknownDouble = ba.ReadBD();
        Console.WriteLine(string.Format("gc.UnknownDouble: {0}", (object) gradientColor.UnknownDouble));
        gradientColor.UnknownShort = (int) ba.ReadBS();
        Console.WriteLine(string.Format("gc.UnknownShort: {0}", (object) gradientColor.UnknownShort));
        gradientColor.RGBColor = ba.ReadBL();
        Console.WriteLine(string.Format("gc.RGBColor: {0}", (object) gradientColor.RGBColor));
        gradientColor.IgnoredColorByte = ba.ReadByte();
        Console.WriteLine(string.Format("gc.IgnoredColorByte: {0}", (object) gradientColor.IgnoredColorByte));
        this.GradientColors.Add(gradientColor);
      }
      this.Zcoord = ba.ReadBD();
      Console.WriteLine(string.Format("Zcoord: {0}", (object) this.Zcoord));
      this.Extrusion = ba.Read3BD();
      Console.WriteLine(string.Format("Extrusion: {0}", (object) this.Extrusion));
      this.Solidfill = ba.ReadB();
      Console.WriteLine(string.Format("Solidfill: {0}", (object) this.Solidfill));
      this.Associative = ba.ReadB();
      Console.WriteLine(string.Format("Associative: {0}", (object) this.Associative));
      this.NumPaths = ba.ReadBL();
      Console.WriteLine(string.Format("NumPaths: {0}", (object) this.NumPaths));
      this.LoadPaths(ba);
      this.StyleOfHatch = (int) ba.ReadBS();
      Console.WriteLine(string.Format("StyleOfHatch: {0}", (object) this.StyleOfHatch));
      this.PatternType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("PatternType: {0}", (object) this.PatternType));
      if (!this.Solidfill)
      {
        this.Angle = ba.ReadBD();
        Console.WriteLine(string.Format("Angle: {0}", (object) this.Angle));
        this.ScaleOrSpacing = ba.ReadBD();
        Console.WriteLine(string.Format("ScaleOrSpacing: {0}", (object) this.ScaleOrSpacing));
        this.DoubleHatch = ba.ReadB();
        Console.WriteLine(string.Format("DoubleHatch: {0}", (object) this.DoubleHatch));
        this.NumDefLines = (int) ba.ReadBS();
        Console.WriteLine(string.Format("NumDefLines: {0}", (object) this.NumDefLines));
        for (int index1 = 0; index1 < this.NumDefLines; ++index1)
        {
          DefLine defLine = new DefLine();
          defLine.Angle = ba.ReadBD();
          Console.WriteLine(string.Format("defLine.Angle: {0}", (object) defLine.Angle));
          defLine.Pt0 = ba.Read2BD();
          Console.WriteLine(string.Format("defLine.Pt0: {0}", (object) defLine.Pt0));
          defLine.Offset = ba.Read2BD();
          Console.WriteLine(string.Format("defLine.Offset: {0}", (object) defLine.Offset));
          defLine.NumDashes = (int) ba.ReadBS();
          Console.WriteLine(string.Format("defLine.NumDashes: {0}", (object) defLine.NumDashes));
          for (int index2 = 0; index2 < defLine.NumDashes; ++index2)
          {
            double num = ba.ReadBD();
            Console.WriteLine(string.Format("dashlength: {0}", (object) num));
            defLine.DashLengths.Add(num);
          }
          this.DefLines.Add(defLine);
        }
      }
      if (this.AnyPathFlags)
      {
        this.PixelSize = ba.ReadBD();
        Console.WriteLine(string.Format("PixelSize: {0}", (object) this.PixelSize));
      }
      this.NumSeedPoints = ba.ReadBL();
      Console.WriteLine(string.Format("NumSeedPoints: {0}", (object) this.NumSeedPoints));
      ba.DumpBitIndex();
      for (int index = 0; index < this.NumSeedPoints; ++index)
      {
        Point2D point2D = ba.Read2RD();
        Console.WriteLine(string.Format("pt_0: {0}", (object) point2D));
        this.SeedPoints.Add(point2D);
      }
      ba.DumpBitIndex();
      this.GradientName = ba.ReadTU();
      Console.WriteLine("GradientName: " + this.GradientName);
      this.Name = ba.ReadTU();
      Console.WriteLine("Name: " + this.Name);
      ba.bitindex += 17;
    }

    private void LoadPaths(DwgBitArray ba)
    {
      for (int index1 = 0; index1 < this.NumPaths; ++index1)
      {
        Console.WriteLine("-------------------Path Start-------------");
        Path path = new Path();
        path.PathFlag = ba.ReadBL();
        Console.WriteLine(string.Format("path.PathFlag: {0}", (object) path.PathFlag));
        if ((path.PathFlag & 4) != 0)
          this.AnyPathFlags = true;
        if ((path.PathFlag & 2) == 0)
        {
          path.NumPathSegs = ba.ReadBL();
          Console.WriteLine(string.Format("path.NumPathSegs: {0}", (object) path.NumPathSegs));
          for (int index2 = 0; index2 < path.NumPathSegs; ++index2)
          {
            PathSeg pathSeg = new PathSeg();
            pathSeg.PathTypeStatus = (int) ba.ReadByte();
            Console.WriteLine(string.Format("ps.PathTypeStatus: {0}", (object) pathSeg.PathTypeStatus));
            Hatch.PathType pathTypeStatus = (Hatch.PathType) pathSeg.PathTypeStatus;
            Console.WriteLine(string.Format("type: {0}", (object) pathTypeStatus));
            switch (pathTypeStatus)
            {
              case Hatch.PathType.LINE:
                pathSeg.Pt0 = ba.Read2RD();
                Console.WriteLine(string.Format("ps.Pt0: {0}", (object) pathSeg.Pt0));
                pathSeg.Pt1 = ba.Read2RD();
                Console.WriteLine(string.Format("ps.Pt1: {0}", (object) pathSeg.Pt1));
                break;
              case Hatch.PathType.CIRCULAR_ARC:
                pathSeg.Pt0 = ba.Read2RD();
                Console.WriteLine(string.Format("ps.Pt0: {0}", (object) pathSeg.Pt0));
                pathSeg.Radius = ba.ReadBD();
                Console.WriteLine(string.Format("ps.Radius: {0}", (object) pathSeg.Radius));
                pathSeg.StartAngle = ba.ReadBD();
                Console.WriteLine(string.Format("ps.StartAngle: {0}", (object) pathSeg.StartAngle));
                pathSeg.EndAngle = ba.ReadBD();
                Console.WriteLine(string.Format("ps.EndAngle: {0}", (object) pathSeg.EndAngle));
                pathSeg.IsCcw = ba.ReadB();
                Console.WriteLine(string.Format("ps.IsCcw: {0}", (object) pathSeg.IsCcw));
                break;
              case Hatch.PathType.ELLIPTICAL_ARC:
                pathSeg.Pt0 = ba.Read2RD();
                Console.WriteLine(string.Format("ps.Pt0: {0}", (object) pathSeg.Pt0));
                pathSeg.EndPoint = ba.Read2RD();
                Console.WriteLine(string.Format("ps.EndPoint: {0}", (object) pathSeg.EndPoint));
                pathSeg.MinorMajorRatio = ba.ReadBD();
                Console.WriteLine(string.Format("ps.MinorMajorRatio: {0}", (object) pathSeg.MinorMajorRatio));
                pathSeg.StartAngle = ba.ReadBD();
                Console.WriteLine(string.Format("ps.StartAngle: {0}", (object) pathSeg.StartAngle));
                pathSeg.EndAngle = ba.ReadBD();
                Console.WriteLine(string.Format("ps.EndAngle: {0}", (object) pathSeg.EndAngle));
                pathSeg.IsCcw = ba.ReadB();
                Console.WriteLine(string.Format("ps.IsCcw: {0}", (object) pathSeg.IsCcw));
                break;
              case Hatch.PathType.SPLINE:
                pathSeg.Degree = ba.ReadBL();
                Console.WriteLine(string.Format("ps.Degree: {0}", (object) pathSeg.Degree));
                pathSeg.IsRational = ba.ReadB();
                Console.WriteLine(string.Format("ps.IsRational: {0}", (object) pathSeg.IsRational));
                pathSeg.IsPeriodic = ba.ReadB();
                Console.WriteLine(string.Format("ps.IsPeriodic: {0}", (object) pathSeg.IsPeriodic));
                pathSeg.NumKnots = ba.ReadBL();
                Console.WriteLine(string.Format("ps.NumKnots: {0}", (object) pathSeg.NumKnots));
                pathSeg.NumControlPoints = ba.ReadBL();
                Console.WriteLine(string.Format("ps.NumControlPoints: {0}", (object) pathSeg.NumControlPoints));
                for (int index3 = 0; index3 < pathSeg.NumKnots; ++index3)
                {
                  double num = ba.ReadBD();
                  pathSeg.Knots.Add(num);
                  Console.WriteLine(string.Format("knot: {0}", (object) num));
                }
                for (int index3 = 0; index3 < pathSeg.NumControlPoints; ++index3)
                {
                  CtlPt ctlPt = new CtlPt();
                  ctlPt.Pt0 = ba.Read2RD();
                  Console.WriteLine(string.Format("cp.Pt0: {0}", (object) ctlPt.Pt0));
                  if (pathSeg.IsRational)
                  {
                    ctlPt.Weight = ba.ReadBD();
                    Console.WriteLine(string.Format("cp.Weight: {0}", (object) ctlPt.Weight));
                  }
                  pathSeg.CtlPts.Add(ctlPt);
                }
                int num1 = ba.ReadBL();
                Console.WriteLine(string.Format("ps.fitpts: {0}", (object) num1));
                if (0 < num1)
                  throw new NotImplementedException();
                break;
              default:
                throw new NotImplementedException();
            }
            path.PathSegs.Add(pathSeg);
          }
        }
        else
        {
          Console.WriteLine("Polyline Path");
          path.BulgePresent = ba.ReadB();
          Console.WriteLine(string.Format("path.BulgePresent: {0}", (object) path.BulgePresent));
          path.Closed = ba.ReadB();
          Console.WriteLine(string.Format("path.Closed: {0}", (object) path.Closed));
          path.NumPathSegs = ba.ReadBL();
          Console.WriteLine(string.Format("path.NumPathSegs: {0}", (object) path.NumPathSegs));
          for (int index2 = 0; index2 < path.NumPathSegs; ++index2)
          {
            Bulge bulge = new Bulge();
            bulge.Pt0 = ba.Read2RD();
            Console.WriteLine(string.Format("bulge.Pt0: {0}", (object) bulge.Pt0));
            if (path.BulgePresent)
            {
              bulge._Bulge = ba.ReadBD();
              Console.WriteLine(string.Format("bulge._Bulge: {0}", (object) bulge._Bulge));
            }
            path.Bulges.Add(bulge);
          }
        }
        path.NumBoundayObjHandles = ba.ReadBL();
        Console.WriteLine(string.Format("path.NumBoundayObjHandles: {0}", (object) path.NumBoundayObjHandles));
        this.Paths.Add(path);
        Console.WriteLine("-------------------Path End---------------");
      }
    }

    public enum PathType
    {
      LINE = 1,
      CIRCULAR_ARC = 2,
      ELLIPTICAL_ARC = 3,
      SPLINE = 4,
    }
  }
}
