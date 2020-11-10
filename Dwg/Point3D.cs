// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.Point3D
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg
{
  public class Point3D
  {
    public double x { get; set; }

    public double y { get; set; }

    public double z { get; set; }

    public Point2D ToPoint2d()
    {
      return new Point2D() { x = this.x, y = this.y };
    }

    public Point3D Normalize()
    {
      double num = Math.Sqrt(Math.Pow(this.x, 2.0) + Math.Pow(this.y, 2.0) + Math.Pow(this.z, 2.0));
      this.x /= num;
      this.y /= num;
      this.z /= num;
      return this;
    }

    public double Length()
    {
      return Math.Sqrt(Math.Pow(this.x, 2.0) + Math.Pow(this.y, 2.0) + Math.Pow(this.z, 2.0));
    }

    public override string ToString()
    {
      return string.Format("\r\n    x:{0}\r\n    y:{1}\r\n    z:{2}", (object) this.x, (object) this.y, (object) this.z);
    }

    public Point3D Cross(Point3D rhs)
    {
      return new Point3D()
      {
        x = this.y * rhs.z - this.z * rhs.y,
        y = this.z * rhs.x - this.x * rhs.z,
        z = this.x * rhs.y - this.y * rhs.x
      };
    }

    public Point3D Clone()
    {
      return new Point3D()
      {
        x = this.x,
        y = this.y,
        z = this.z
      };
    }

    public static Point3D operator +(Point3D lhs, Point3D rhs)
    {
      return new Point3D()
      {
        x = lhs.x + rhs.x,
        y = lhs.y + rhs.y,
        z = lhs.z + rhs.z
      };
    }

    public static Point3D operator -(Point3D lhs, Point3D rhs)
    {
      return new Point3D()
      {
        x = lhs.x - rhs.x,
        y = lhs.y - rhs.y,
        z = lhs.z - rhs.z
      };
    }

    public static Point3D operator /(Point3D lhs, double rhs)
    {
      return new Point3D()
      {
        x = lhs.x / rhs,
        y = lhs.y / rhs,
        z = lhs.z / rhs
      };
    }

    public static Point3D operator *(Point3D lhs, double rhs)
    {
      return new Point3D()
      {
        x = lhs.x * rhs,
        y = lhs.y * rhs,
        z = lhs.z * rhs
      };
    }

    public static Point3D operator *(double lhs, Point3D rhs)
    {
      return new Point3D()
      {
        x = lhs * rhs.x,
        y = lhs * rhs.y,
        z = lhs * rhs.z
      };
    }
  }
}
