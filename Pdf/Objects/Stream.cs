// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Objects.Stream
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace dqgToPdf.Pdf.Objects
{
  public class Stream : BaseObject
  {
    public string Val = "";
    public Dictionary Dic = new Dictionary(false);

    public Stream(bool isIndirect = false)
      : base(isIndirect)
    {
    }

    public override string DirectExpresion()
    {
      Dictionary dictionary = new Dictionary(false);
      byte[] bytes = Encoding.UTF8.GetBytes(this.Val);
      dictionary.Add("Length", (object) bytes.Length);
      foreach (KeyValuePair<Name, BaseObject> keyValuePair in this.Dic.Val)
        dictionary.Add(keyValuePair.Key.name, (object) keyValuePair.Value);
      return dictionary.Expression(false) + Environment.NewLine + "stream" + Environment.NewLine + Encoding.ASCII.GetString(bytes) + Environment.NewLine + "endstream";
    }
  }
}
