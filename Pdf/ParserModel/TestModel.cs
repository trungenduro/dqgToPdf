// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.ParserModel.TestModel
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Pdf.ParserModel
{
  public class TestModel
  {
    private string _id;
    private byte[] _bytes;

    public TestModel(string id, byte[] bytes)
    {
      if (id == null)
        throw new ArgumentException(nameof (id));
      if (bytes == null)
        throw new ArgumentException(nameof (bytes));
      this._bytes = bytes;
      this._id = id;
    }

    public string Id
    {
      get
      {
        return this._id;
      }
    }

    public byte[] Bytes
    {
      get
      {
        return this._bytes;
      }
    }
  }
}
