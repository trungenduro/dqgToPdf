// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Objects.Dictionary
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;

namespace dqgToPdf.Pdf.Objects
{
  public class Dictionary : BaseObject
  {
    protected static int indent;

    public Dictionary<Name, BaseObject> Val { get; set; } = new Dictionary<Name, BaseObject>();

    public override string DirectExpresion()
    {
      string str = "<<" + Environment.NewLine;
      ++Dictionary.indent;
      foreach (KeyValuePair<Name, BaseObject> keyValuePair in this.Val)
      {
        str += this.Indent;
        str = str + keyValuePair.Key.Expression(false) + " " + keyValuePair.Value.Expression(false) + Environment.NewLine;
      }
      --Dictionary.indent;
      return str + this.Indent + ">>";
    }

    public Dictionary(bool isIndirect = false)
      : base(isIndirect)
    {
    }

    protected string Indent
    {
      get
      {
        string str = "";
        for (int index = 0; index < Dictionary.indent; ++index)
          str += "  ";
        return str;
      }
    }

    public Dictionary Add(string name, Dictionary dic)
    {
      this.Val.Add(new Name(name), (BaseObject) dic);
      return dic;
    }

    public Array Add(string name, Array dic)
    {
      this.Val.Add(new Name(name), (BaseObject) dic);
      return dic;
    }

    public Stream Add(string name, Stream dic)
    {
      this.Val.Add(new Name(name), (BaseObject) dic);
      return dic;
    }

    public void Add(string name, object obj)
    {
      Name key = new Name(name);
      switch (obj)
      {
        case null:
          this.Val.Add(key, (BaseObject) new Null());
          break;
        case Text text:
          this.Val.Add(key, (BaseObject) text);
          break;
        case string str:
          if (str.StartsWith("/"))
          {
            this.Val.Add(key, (BaseObject) new Name(str));
            break;
          }
          this.Val.Add(key, (BaseObject) new Text(str, false));
          break;
        case double number:
          this.Val.Add(key, (BaseObject) new RealNumber(number));
          break;
        case int num:
          this.Val.Add(key, (BaseObject) new RealNumber((double) num));
          break;
        case bool val:
          this.Val.Add(key, (BaseObject) new Boolean(val));
          break;
        case BaseObject baseObject:
          this.Val.Add(key, baseObject);
          break;
        default:
          throw new FormatException();
      }
    }
  }
}
