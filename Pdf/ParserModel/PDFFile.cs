﻿// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.ParserModel.PDFFile
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.Collections.Generic;

namespace dqgToPdf.Pdf.ParserModel
{
  public class PDFFile
  {
    public PdfReader.PDF_VER FileHeaderVersion { get; set; }

    public IEnumerable<PDFBody> Bodys { get; set; }
  }
}
