// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.IEntity
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using dqgToPdf.Pdf.Contents;

namespace dqgToPdf.Dxf
{
  public interface IEntity
  {
    BoundingBox GetBoundingBox();

    void WritePdf(PageObject po, int lineType, int lineWidth, int colorIndex);

    bool IsEnableLineStyle { get; set; }
  }
}
