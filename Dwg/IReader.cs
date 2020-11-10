// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.IReader
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dxf;
using dqgToPdf.Pdf.Contents;
using dqgToPdf.Pdf.Objects;
using System.Collections.Generic;

namespace dqgToPdf.Dwg
{
  public interface IReader
  {
    List<string> GetLayerNames();

    List<IText> GetTextLists();

    string Filename { get; set; }

    Dictionary<int, object> ObjectMap { get; set; }

    BoundingBox GetBoundingBox();

    List<LineStyle> LayerStyles { get; set; }

    void WritePdf(PageObject po, bool isEnableLineStyle = false);
    void WritePdfLayout(PageObject po, bool isEnableLineStyle = false);

    LinkInfo GetLinkInfo(double scale, Array mediabox);
  }
}
