// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.LineStyle
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dxf
{
  public class LineStyle
  {
    public bool IsHide { get; set; }

    public bool IsDisable { get; set; }

    public string LayerName { get; set; }

    public LineType _LineType { get; set; }

    public LineWidth _LineWidth { get; set; } = LineWidth._0_1000;

    public Color _Color { get; set; }

    public int GetLineType()
    {
      switch (this._LineType)
      {
        case LineType.実線:
          return 0;
        case LineType.点線:
          return 1;
        case LineType.一点鎖線:
          return 2;
        case LineType.二点鎖線:
          return 3;
        default:
          throw new Exception();
      }
    }

    public int GetLayerColor()
    {
      switch (this._Color)
      {
        case Color.黒:
          return 0;
        case Color.赤:
          return 1;
        case Color.緑:
          return 3;
        case Color.青:
          return 5;
        case Color.黄:
          return 2;
        case Color.シアン:
          return 4;
        case Color.マゼンタ:
          return 6;
        default:
          return 0;
      }
    }

    public double GetLineWeight()
    {
      switch (this._LineWidth)
      {
        case LineWidth._0_0000:
          return 0.0;
        case LineWidth._0_0500:
          return 0.05;
        case LineWidth._0_0900:
          return 0.09;
        case LineWidth._0_1000:
          return 0.1;
        case LineWidth._0_1300:
          return 0.13;
        case LineWidth._0_1500:
          return 0.15;
        case LineWidth._0_1800:
          return 0.18;
        case LineWidth._0_2000:
          return 0.2;
        case LineWidth._0_2500:
          return 0.25;
        case LineWidth._0_3000:
          return 0.3;
        case LineWidth._0_3500:
          return 0.35;
        case LineWidth._0_4000:
          return 0.4;
        case LineWidth._0_4500:
          return 0.45;
        case LineWidth._0_5000:
          return 0.5;
        case LineWidth._0_5300:
          return 0.53;
        case LineWidth._0_6000:
          return 0.6;
        case LineWidth._0_6500:
          return 0.65;
        case LineWidth._0_7000:
          return 0.7;
        case LineWidth._0_8000:
          return 0.8;
        case LineWidth._0_9000:
          return 0.9;
        case LineWidth._1_0000:
          return 1.0;
        case LineWidth._1_0600:
          return 1.06;
        case LineWidth._1_2000:
          return 1.2;
        case LineWidth._1_4000:
          return 1.4;
        case LineWidth._1_5800:
          return 1.5;
        case LineWidth._2_0000:
          return 2.0;
        case LineWidth._2_1100:
          return 2.11;
        default:
          throw new Exception();
      }
    }
  }
}
