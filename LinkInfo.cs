// Decompiled with JetBrains decompiler
// Type: dqgToPdf.LinkInfo
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.Collections.Generic;

namespace dqgToPdf
{
  public class LinkInfo
  {
    public double[] Mediabox = new double[4];
    public List<LinkItem> LinkItems = new List<LinkItem>();

    public string PDFFilename { get; set; }
  }
}
