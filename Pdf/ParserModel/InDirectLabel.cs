﻿// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.ParserModel.InDirectLabel
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.IO;

namespace dqgToPdf.Pdf.ParserModel
{
  public class InDirectLabel : IWrite
  {
    public int ObjectNumber { get; set; }

    public int GenerationNumber { get; set; }

    public void Write(StreamWriter sw)
    {
      sw.Write(this.ObjectNumber.ToString() + " 0 R");
    }
  }
}
