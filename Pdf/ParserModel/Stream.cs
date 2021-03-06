﻿// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.ParserModel.Stream
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.IO;

namespace dqgToPdf.Pdf.ParserModel
{
  public class Stream : IWrite
  {
    public Dictionary dic { get; set; }

    public byte[] streamContent { get; set; }

    public byte[] ordinaryContent { get; set; }

    public void Write(StreamWriter sw)
    {
      this.dic.Write(sw);
      sw.WriteLine();
      sw.WriteLine("stream");
      sw.Flush();
      foreach (byte num in this.streamContent)
        sw.BaseStream.WriteByte(num);
      sw.BaseStream.Flush();
      sw.WriteLine();
      sw.Write("endstream");
    }
  }
}
