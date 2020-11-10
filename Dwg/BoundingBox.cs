// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.BoundingBox
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Dwg
{
  public class BoundingBox
  {
    public double Left { get; set; } = double.NaN;

    public double Top { get; set; } = double.NaN;

    public double Right { get; set; } = double.NaN;

    public double Bottom { get; set; } = double.NaN;

    public override string ToString()
    {
      return string.Format("BoundingBox\r\n    Left: {0}\r\n    Top: {1}\r\n    Right: {2}\r\n    Bottom: {3}\r\n", (object) this.Left, (object) this.Top, (object) this.Right, (object) this.Bottom);
    }

    public void SetX(double x)
    {
      if (double.IsNaN(this.Left))
        this.Left = x;
      else if (this.Left > x)
        this.Left = x;
      if (double.IsNaN(this.Right))
      {
        this.Right = x;
      }
      else
      {
        if (this.Right >= x)
          return;
        this.Right = x;
      }
    }

    public void SetY(double y)
    {
      if (double.IsNaN(this.Bottom))
        this.Bottom = y;
      else if (this.Bottom > y)
        this.Bottom = y;
      if (double.IsNaN(this.Top))
      {
        this.Top = y;
      }
      else
      {
        if (this.Top >= y)
          return;
        this.Top = y;
      }
    }

    public void AddBoudingBox(BoundingBox bb)
    {
      this.SetX(bb.Left);
      this.SetX(bb.Right);
      this.SetY(bb.Top);
      this.SetY(bb.Bottom);
    }

    public void AddBoudingBox(Point2D p2)
    {
      if (p2 == null)
        return;
      this.SetX(p2.x);
      this.SetY(p2.y);
    }

    public void AddBoudingBox(double x, double y)
    {
      this.SetX(x);
      this.SetY(y);
    }

    public void SetXY(double x, double y)
    {
      this.SetX(x);
      this.SetY(y);
    }
  }
}
