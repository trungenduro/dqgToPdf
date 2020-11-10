// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Common.BSpline
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using System.Collections.Generic;

namespace dqgToPdf.Common
{
  public class BSpline
  {
    public static List<Point2D> CalcBspline(
      List<Point2D> ControlPts,
      List<double> knots,
      int degree,
      int numpoint)
    {
      List<Point2D> point2DList = new List<Point2D>();
      double knot = knots[0];
      double num = (knots[knots.Count - 1] - knot) / ((double) numpoint - 1.0);
      point2DList.Add(ControlPts[0]);
      for (int index = 1; index < numpoint - 1; ++index)
        point2DList.Add(BSpline.CalcPoint(knot + (double) index * num, degree, knots, ControlPts));
      point2DList.Add(ControlPts[ControlPts.Count - 1]);
      return point2DList;
    }

    public static List<Point2D> CalcBspline(
      List<Point3D> ControlPts,
      List<double> knots,
      int degree,
      int numpoint)
    {
      List<Point2D> point2DList = new List<Point2D>();
      double knot = knots[0];
      double num = (knots[knots.Count - 1] - knot) / ((double) numpoint - 1.0);
      point2DList.Add(ControlPts[0].ToPoint2d());
      for (int index = 1; index < numpoint - 1; ++index)
        point2DList.Add(BSpline.CalcPoint(knot + (double) index * num, degree, knots, ControlPts));
      point2DList.Add(ControlPts[ControlPts.Count - 1].ToPoint2d());
      return point2DList;
    }

    public static Point2D CalcPoint(
      double t,
      int degree,
      List<double> knots,
      List<Point2D> ControlPts)
    {
      Point2D point2D = new Point2D();
      for (int j = 0; j < ControlPts.Count; ++j)
      {
        double num = BSpline.BsplineBasicFunc(j, degree, t, knots);
        point2D += num * ControlPts[j];
      }
      return point2D;
    }

    public static Point2D CalcPoint(
      double t,
      int degree,
      List<double> knots,
      List<Point3D> ControlPts)
    {
      Point2D point2D = new Point2D();
      for (int j = 0; j < ControlPts.Count; ++j)
      {
        double num = BSpline.BsplineBasicFunc(j, degree, t, knots);
        point2D += num * ControlPts[j].ToPoint2d();
      }
      return point2D;
    }

    public static double BsplineBasicFunc(int j, int n, double t, List<double> knots)
    {
      if (n == 0)
        return knots[j] <= t && t < knots[j + 1] ? 1.0 : 0.0;
      double num1 = BSpline.BsplineBasicFunc(j, n - 1, t, knots);
      double num2 = BSpline.BsplineBasicFunc(j + 1, n - 1, t, knots);
      double num3 = 0.0;
      if (num1 != 0.0)
        num3 += (t - knots[j]) / (knots[j + n] - knots[j]) * num1;
      if (num2 != 0.0)
        num3 += (knots[j + n + 1] - t) / (knots[j + n + 1] - knots[j + 1]) * num2;
      return num3;
    }
  }
}
