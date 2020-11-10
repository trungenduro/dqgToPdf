// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.DataItem
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg
{
  public class DataItem
  {
    public byte type { get; set; }

    public string str { get; set; }

    public byte[] bytes { get; set; }

    public Point3D point3D { get; set; }

    public double real { get; set; }

    public short shortint { get; set; }

    public int longint { get; set; }

    public object val
    {
      get
      {
        switch (this.type)
        {
          case 0:
            return (object) this.str;
          case 1:
            throw new FormatException();
          case 2:
            return (object) this.str;
          case 3:
            return (object) this.bytes;
          case 4:
            return (object) this.bytes;
          case 5:
            return (object) this.bytes;
          case 10:
          case 11:
          case 12:
          case 13:
            return (object) this.point3D;
          case 40:
          case 41:
          case 42:
            return (object) this.real;
          case 70:
            return (object) this.shortint;
          case 71:
            return (object) this.longint;
          default:
            throw new FormatException();
        }
      }
    }
  }
}
