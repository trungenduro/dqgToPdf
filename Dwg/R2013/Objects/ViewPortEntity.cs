// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.ViewPortEntity
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class ViewPortEntity : CommonEntityData
  {
    public Point3D Center { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public Point3D ViewTarget { get; set; }

    public Point3D ViewDirection { get; set; }

    public double TwistAngle { get; set; }

    public double ViewHeight { get; set; }

    public ViewPortEntity(DwgBitArray ba)
      : base(ba)
    {
    }
  }
}
