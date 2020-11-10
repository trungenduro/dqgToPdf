// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.CmColor
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Dwg
{
  public class CmColor
  {
    public short ColorIndex { get; set; }

    public int RGBValue { get; set; }

    public int colorByte { get; set; }

    public string ColorName { get; set; }

    public string BookName { get; set; }

    public override string ToString()
    {
      return string.Format("CmColor\r\n    ColorIndex: {0}\r\n    RGBValue: {1:x8}\r\n    ColorBookName: {2}\r\n    BookName: {3}", (object) this.ColorIndex, (object) this.RGBValue, (object) this.ColorName, (object) this.BookName);
    }
  }
}
