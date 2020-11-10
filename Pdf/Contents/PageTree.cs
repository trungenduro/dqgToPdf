// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Contents.PageTree
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using dqgToPdf.Pdf.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dqgToPdf.Pdf.Contents
{
  public class PageTree
  {
    public static Dictionary<string, Point2D> PaperDictionary = new Dictionary<string, Point2D>()
    {
      {
        "A0",
        new Point2D() { x = 841.0, y = 1189.0 }
      },
      {
        "A1",
        new Point2D() { x = 594.0, y = 841.0 }
      },
      {
        "A2",
        new Point2D() { x = 420.0, y = 594.0 }
      },
      {
        "A3",
        new Point2D() { x = 297.0, y = 420.0 }
      },
      {
        "A4",
        new Point2D() { x = 210.0, y = 297.0 }
      },
      {
        "A5",
        new Point2D() { x = 148.0, y = 210.0 }
      },
      {
        "B0",
        new Point2D() { x = 1030.0, y = 1456.0 }
      },
      {
        "B1",
        new Point2D() { x = 728.0, y = 1030.0 }
      },
      {
        "B2",
        new Point2D() { x = 515.0, y = 728.0 }
      },
      {
        "B3",
        new Point2D() { x = 364.0, y = 515.0 }
      },
      {
        "B4",
        new Point2D() { x = 257.0, y = 364.0 }
      },
      {
        "B5",
        new Point2D() { x = 182.0, y = 257.0 }
      }
    };
    protected PDF pdf;
    protected Dictionary contents;
    protected RealNumber count;
    protected dqgToPdf.Pdf.Objects.Array kids;

    protected List<PageObject> _pageObjects { get; set; } = new List<PageObject>();

    public PageTree(PDF pdf, Dictionary contents)
    {
      this.pdf = pdf;
      this.contents = contents;
      this.kids = new dqgToPdf.Pdf.Objects.Array(false);
      this.count = new RealNumber(0.0);
      this.contents.Add("/Kids", this.kids);
      this.contents.Add("/Count", (object) this.count);
      this.contents.Add("/Type", (object) "/Pages");
    }

    public Point2D ChoicePaperSize(BoundingBox bb, int PaperSizeConmboIndex = 1)
    {
      double right = bb.Right;
      double top = bb.Top;
      Point2D point2D1;
      if (bb.Top > bb.Right)
      {
        point2D1 = PageTree.PaperDictionary.Select<KeyValuePair<string, Point2D>, Point2D>((Func<KeyValuePair<string, Point2D>, Point2D>) (e => e.Value)).OrderBy<Point2D, double>((Func<Point2D, double>) (e => Math.Abs(e.x - bb.Right) + Math.Abs(e.y - bb.Top))).First<Point2D>().Clone();
      }
      else
      {
        Point2D point2D2 = PageTree.PaperDictionary.Select<KeyValuePair<string, Point2D>, Point2D>((Func<KeyValuePair<string, Point2D>, Point2D>) (e => e.Value)).OrderBy<Point2D, double>((Func<Point2D, double>) (e => Math.Abs(e.y - bb.Right) + Math.Abs(e.x - bb.Top))).First<Point2D>().Clone();
        point2D1 = new Point2D()
        {
          x = point2D2.y,
          y = point2D2.x
        };
      }
      if (Math.Abs(point2D1.x - right) + Math.Abs(point2D1.y - top) < 200.0)
        return point2D1;
      double num1 = right - bb.Left;
      double num2 = top - bb.Bottom;
      Point2D point2D3 = PageTree.PaperDictionary["A0"].Clone();
      Point2D point2D4 = PageTree.PaperDictionary["B0"].Clone();
      Point2D point2D5 = (Point2D) null;
      Point2D point2D6 = (Point2D) null;
      int num3 = 1;
      while (point2D5 == null || point2D6 == null)
      {
        if (point2D5 == null)
        {
          double num4 = point2D3.x * (double) num3;
          double num5 = point2D3.y * (double) num3;
          if (num4 > num1 && num5 > num2)
            point2D5 = new Point2D() { x = num4, y = num5 };
        }
        if (point2D6 == null)
        {
          double num4 = point2D4.x * (double) num3;
          double num5 = point2D4.y * (double) num3;
          if (num4 > num1 && num5 > num2)
            point2D6 = new Point2D() { x = num4, y = num5 };
        }
        ++num3;
      }
      if (Math.Abs(point2D5.x - num1) + Math.Abs(point2D5.y - num2) < Math.Abs(point2D6.x - num1) + Math.Abs(point2D6.y - num2))
      {
        if (bb.Top - bb.Bottom > bb.Right - bb.Left)
          return point2D5;
        return new Point2D()
        {
          x = point2D5.y,
          y = point2D5.x
        };
      }
      if (bb.Top - bb.Bottom > bb.Right - bb.Left)
        return point2D6;
      return new Point2D()
      {
        x = point2D6.y,
        y = point2D6.x
      };
    }

    private Point2D getTargetPP(int paperSizeComoboIndex)
    {
      Point2D point2D = new Point2D();
      switch (paperSizeComoboIndex)
      {
        case 0:
          point2D = PageTree.PaperDictionary["A0"].Clone();
          break;
        case 1:
          point2D = PageTree.PaperDictionary["A1"].Clone();
          break;
        case 2:
          point2D = PageTree.PaperDictionary["A2"].Clone();
          break;
        case 3:
          point2D = PageTree.PaperDictionary["A3"].Clone();
          break;
        case 4:
          point2D = PageTree.PaperDictionary["A4"].Clone();
          break;
      }
      return point2D;
    }

    public PageObject AddPageObject(BoundingBox bb, int paperSizeComoboIndex)
    {
      Dictionary dictionary = this.pdf.CreateDictionary();
      this.kids.Add(dictionary);
      this.count.number = (double) this.kids.Val.Count;
      dictionary.Add("/Parent", this.contents);
      Point2D targetPp = this.getTargetPP(paperSizeComoboIndex);
      Point2D point2D = this.ChoicePaperSize(bb, 1);
      if (point2D.x > point2D.y)
      {
        double y = targetPp.y;
        targetPp.y = targetPp.x;
        targetPp.x = y;
      }
      Point2D pageSize = targetPp * (360.0 / (double) sbyte.MaxValue);
      double num1 = bb.Top - bb.Bottom;
      double num2 = bb.Right - bb.Left;
      double val1 = pageSize.y / num1;
      double val2 = pageSize.x / num2;
      double scale = Math.Min(val1, val2) * (1.0 - GlobalVariables.PaperMarginRate);
      double num3;
      double num4;
      if (val1 < val2)
      {
        num3 = bb.Bottom * scale - pageSize.y * GlobalVariables.PaperMarginRate / 2.0;
        num4 = bb.Left * scale - (pageSize.x - num2 * scale) / 2.0;
      }
      else
      {
        num4 = bb.Left * scale - pageSize.x * GlobalVariables.PaperMarginRate / 2.0;
        num3 = bb.Bottom * scale - (pageSize.y - num1 * scale) / 2.0;
      }
      dqgToPdf.Pdf.Objects.Array mediabox = new dqgToPdf.Pdf.Objects.Array(false);
      mediabox.Add((object) num4);
      mediabox.Add((object) num3);
      mediabox.Add((object) (pageSize.x + num4));
      mediabox.Add((object) (pageSize.y + num3));
      PageObject pageObject = new PageObject(this.pdf, dictionary, pageSize, scale, mediabox);
      this._pageObjects.Add(pageObject);
      return pageObject;
    }

    public PageObject IndexOf(int idx)
    {
      return this._pageObjects[idx];
    }
  }
}
