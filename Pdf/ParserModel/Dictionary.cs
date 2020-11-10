// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.ParserModel.Dictionary
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dqgToPdf.Pdf.ParserModel
{
  public class Dictionary : IWrite
  {
    public List<DictionaryItem> Val { get; set; }

    public object this[string name]
    {
      get
      {
        return this.Val.FirstOrDefault<DictionaryItem>((Func<DictionaryItem, bool>) (x => x.name.Val == name))?.Val;
      }
    }

    public void Write(StreamWriter sw)
    {
      sw.WriteLine("<<");
      foreach (IWrite write in this.Val)
      {
        write.Write(sw);
        sw.WriteLine();
      }
      sw.Write(">>");
    }
  }
}
