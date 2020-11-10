// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Spline
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Common;
using dqgToPdf.Pdf.Contents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Spline : CommonEntityData
  {
    public Spline(DwgBitArray ba)
      : base(ba)
    {
      this.LoadSpline(ba);
      this.LoadCommonEntityHandleData(ba);
      Console.WriteLine();
    }

    public override void WritePdf(PageObject po, Dictionary<int, object> objMap)
    {
      if (this.Scenario == 1 && this.KnotParameter != 15)
      {
        List<Point3D> fitPts = new List<Point3D>();
        foreach (Point3D fitPt in this.FitPts)
          fitPts.Add(fitPt);
        po.AddFitSpline(this.BegTanVec, this.EndTanVec, fitPts);
      }
      else
      {
        List<Point2D> xYs = BSpline.CalcBspline(this.CtrlPts.Select<CtrlPt, Point3D>((Func<CtrlPt, Point3D>) (x => x.ControlPt)).ToList<Point3D>(), this.Knots, this.Degree, this.CtrlPts.Count * this.Degree * 2);
        po.AddPolyLine(xYs);
      }
    }

    public override BoundingBox GetBoundingBox(Dictionary<int, object> objMap = null)
    {
      BoundingBox boundingBox = new BoundingBox();
      foreach (Point3D fitPt in this.FitPts)
        boundingBox.SetXY(fitPt.x, fitPt.y);
      foreach (CtrlPt ctrlPt in this.CtrlPts)
        boundingBox.SetXY(ctrlPt.ControlPt.x, ctrlPt.ControlPt.y);
      return boundingBox;
    }

    public int Scenario { get; set; }

    public int SplineFlags1 { get; set; }

    public int KnotParameter { get; set; }

    public int Degree { get; set; }

    public double FitTol { get; set; }

    public Point3D BegTanVec { get; set; }

    public Point3D EndTanVec { get; set; }

    public int NumFitPts { get; set; }

    public bool Rational { get; set; }

    public bool Closed { get; set; }

    public bool Periodic { get; set; }

    public double KnotTol { get; set; }

    public double CtrlTol { get; set; }

    public int NumKnots { get; set; }

    public int NumCtrlPts { get; set; }

    public bool Weight { get; set; }

    public List<double> Knots { get; set; } = new List<double>();

    public List<CtrlPt> CtrlPts { get; set; } = new List<CtrlPt>();

    public List<Point3D> FitPts { get; set; } = new List<Point3D>();

    private void LoadSpline(DwgBitArray ba)
    {
      this.Scenario = ba.ReadBL();
      Console.WriteLine(string.Format("Scenario: {0}", (object) this.Scenario));
      this.SplineFlags1 = ba.ReadBL();
      Console.WriteLine(string.Format("SplineFlags1: {0}", (object) this.SplineFlags1));
      this.KnotParameter = ba.ReadBL();
      Console.WriteLine(string.Format("KnotParameter: {0}", (object) this.KnotParameter));
      this.Degree = ba.ReadBL();
      Console.WriteLine(string.Format("Degree: {0}", (object) this.Degree));
      if (this.Scenario == 1 && this.KnotParameter != 15)
      {
        this.FitTol = ba.ReadBD();
        Console.WriteLine(string.Format("FitTol: {0}", (object) this.FitTol));
        this.BegTanVec = ba.Read3BD();
        Console.WriteLine(string.Format("BegTanVec: {0}", (object) this.BegTanVec));
        this.EndTanVec = ba.Read3BD();
        Console.WriteLine(string.Format("EndTanVec: {0}", (object) this.EndTanVec));
        this.NumFitPts = ba.ReadBL();
        Console.WriteLine(string.Format("NumFitPts: {0}", (object) this.NumFitPts));
      }
      else
      {
        this.Rational = ba.ReadB();
        Console.WriteLine(string.Format("Rational: {0}", (object) this.Rational));
        this.Closed = ba.ReadB();
        Console.WriteLine(string.Format("Closed: {0}", (object) this.Closed));
        this.Periodic = ba.ReadB();
        Console.WriteLine(string.Format("Periodic: {0}", (object) this.Periodic));
        this.KnotTol = ba.ReadBD();
        Console.WriteLine(string.Format("KnotTol: {0}", (object) this.KnotTol));
        this.CtrlTol = ba.ReadBD();
        Console.WriteLine(string.Format("CtrlTol: {0}", (object) this.CtrlTol));
        this.NumKnots = ba.ReadBL();
        Console.WriteLine(string.Format("NumKnots: {0}", (object) this.NumKnots));
        this.NumCtrlPts = ba.ReadBL();
        Console.WriteLine(string.Format("NumCtrlPts: {0}", (object) this.NumCtrlPts));
        this.Weight = ba.ReadB();
        Console.WriteLine(string.Format("Weight: {0}", (object) this.Weight));
      }
      for (int index = 0; index < this.NumKnots; ++index)
      {
        double num = ba.ReadBD();
        Console.WriteLine(string.Format("knot: {0}", (object) num));
        this.Knots.Add(num);
      }
      for (int index = 0; index < this.NumCtrlPts; ++index)
      {
        CtrlPt ctrlPt = new CtrlPt();
        ctrlPt.ControlPt = ba.Read3BD();
        Console.WriteLine(string.Format("controlPt.ControlPt: {0}", (object) ctrlPt.ControlPt));
        if (this.Weight)
        {
          ctrlPt.Weight = ba.ReadBD();
          Console.WriteLine(string.Format("controlPt.Weight: {0}", (object) ctrlPt.Weight));
        }
        this.CtrlPts.Add(ctrlPt);
      }
      for (int index = 0; index < this.NumFitPts; ++index)
      {
        Point3D point3D = ba.Read3BD();
        Console.WriteLine(string.Format("fitPt: {0}", (object) point3D));
        this.FitPts.Add(point3D);
      }
      ++ba.bitindex;
    }
  }
}
