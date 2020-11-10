// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.Point2D
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg
{
  public class Point2D
  {
    public double x { get; set; }

    public double y { get; set; }

    public double RotateAngle
    {
      get
      {
        this.Normlize();
        double num = Math.Acos(this.x);
        if (this.y < 0.0)
          num = 2.0 * Math.PI - num;
        return num;
      }
    }

    public override bool Equals(object obj)
    {
      return obj is Point2D point2D && point2D.x == this.x && point2D.y == this.y;
    }

    public override string ToString()
    {
      return string.Format("\r\n    x: {0}\r\n    y: {1}", (object) this.x, (object) this.y);
    }

    public Point2D RotateAndShift(double rotateAngle, Point2D shift)
    {
      this.Rotate(rotateAngle);
      this.x += shift.x;
      this.y += shift.y;
      return this;
    }

    public Point2D Rotate(double radian)
    {
      double x = this.x;
      double y = this.y;
      this.x = x * Math.Cos(radian) - y * Math.Sin(radian);
      this.y = x * Math.Sin(radian) + y * Math.Cos(radian);
      return this;
    }

    public Point2D Add(Point2D addP)
    {
      this.x += addP.x;
      this.y += addP.y;
      return this;
    }

    public Point2D Rotate(Point2D uvec)
    {
      uvec.Normlize();
      double x = this.x;
      double y = this.y;
      this.x = x * uvec.x - y * uvec.y;
      this.y = x * uvec.y + y * uvec.x;
      return this;
    }

    public Point2D Mirror(Point2D mirrorLineVec)
    {
      mirrorLineVec.Normlize();
      double x = this.x;
      double y = this.y;
      this.x = x * (Math.Pow(mirrorLineVec.x, 2.0) - Math.Pow(mirrorLineVec.y, 2.0)) + y * 2.0 * mirrorLineVec.x * mirrorLineVec.y;
      this.y = x * 2.0 * mirrorLineVec.x * mirrorLineVec.y + y * (Math.Pow(mirrorLineVec.y, 2.0) - Math.Pow(mirrorLineVec.x, 2.0));
      return this;
    }

    public void Scale(Point2D direction, double scaleRate)
    {
      double x = this.x;
      double y = this.y;
      direction.Normlize();
      double num1 = Math.Pow(direction.x, 2.0) * scaleRate + Math.Pow(direction.y, 2.0);
      double num2 = direction.x * direction.y * (scaleRate - 1.0);
      double num3 = num2;
      double num4 = Math.Pow(direction.x, 2.0) + scaleRate * Math.Pow(direction.y, 2.0);
      this.x = num1 * x + num2 * y;
      this.y = num3 * x + num4 * y;
    }

    public double Dot(Point2D rhs)
    {
      return this.x * rhs.x + this.y * rhs.y;
    }

    public double Length()
    {
      return Math.Sqrt(Math.Pow(this.x, 2.0) + Math.Pow(this.y, 2.0));
    }

    public Point2D Normlize()
    {
      double num = this.Length();
      if (num != 0.0)
      {
        this.x /= num;
        this.y /= num;
      }
      return this;
    }

    public Point2D Clone()
    {
      return new Point2D() { x = this.x, y = this.y };
    }

    public void Scale(Point2D scale)
    {
      this.x *= scale.x;
      this.y *= scale.y;
    }

    public static Point2D operator +(Point2D lhs, Point2D rhs)
    {
      return new Point2D()
      {
        x = lhs.x + rhs.x,
        y = lhs.y + rhs.y
      };
    }

    public static Point2D operator -(Point2D lhs, Point2D rhs)
    {
      return new Point2D()
      {
        x = lhs.x - rhs.x,
        y = lhs.y - rhs.y
      };
    }

    public static Point2D operator -(Point2D rhs)
    {
      return new Point2D() { x = -rhs.x, y = -rhs.y };
    }

    public static Point2D operator /(Point2D lhs, double rhs)
    {
      return new Point2D()
      {
        x = lhs.x / rhs,
        y = lhs.y / rhs
      };
    }

    public static Point2D operator *(Point2D lhs, double rhs)
    {
      return new Point2D()
      {
        x = lhs.x * rhs,
        y = lhs.y * rhs
      };
    }

    public static Point2D operator *(double lhs, Point2D rhs)
    {
      return new Point2D()
      {
        x = lhs * rhs.x,
        y = lhs * rhs.y
      };
    }
  }
}
