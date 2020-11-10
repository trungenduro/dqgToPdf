// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.AcDbSolid
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using dqgToPdf.Pdf.Contents;

namespace dqgToPdf.Dxf
{
  public class AcDbSolid : IEntity
  {
    public Point3D[] Corner { get; set; } = new Point3D[4];

    public double? thickness { get; set; }

    public int LineWeight { get; set; }

    public int ColorIndex { get; set; }

    public BoundingBox GetBoundingBox()
    {
      BoundingBox boundingBox = new BoundingBox();
      for (int index = 0; index < 4; ++index)
      {
        boundingBox.SetX(this.Corner[index].x);
        boundingBox.SetY(this.Corner[index].y);
      }
      return boundingBox;
    }

    public void WritePdf(PageObject po, int lineType, int lineWidth, int colorIndex)
    {
      if (this.IsEnableLineStyle)
        po.AddSolid(this.Corner, colorIndex, lineWidth, lineType);
      else
        po.AddSolidWithLineWeight(this.Corner, this.ColorIndex, this.LineWeight);
    }

    public bool IsEnableLineStyle { get; set; }
  }
}
