// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Objects.Array
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace dqgToPdf.Pdf.Objects
{
  public class Array : BaseObject
  {
    public List<BaseObject> Val { get; set; } = new List<BaseObject>();

    public Array(bool isIndirect = false)
      : base(isIndirect)
    {
    }

    public override string DirectExpresion()
    {
      return "[" + string.Join(" ", this.Val.Select<BaseObject, string>((Func<BaseObject, int, string>) ((o, i) => o.Expression(false)))) + "]";
    }

    public Dictionary Add(Dictionary dic)
    {
      this.Val.Add((BaseObject) dic);
      return dic;
    }

    public Array Add(Array dic)
    {
      this.Val.Add((BaseObject) dic);
      return dic;
    }

    public Stream Add(Stream dic)
    {
      this.Val.Add((BaseObject) dic);
      return dic;
    }

    public void Add(object obj)
    {
      switch (obj)
      {
        case null:
          this.Val.Add((BaseObject) new Null());
          break;
        case string str:
          if (str.StartsWith("/"))
          {
            this.Val.Add((BaseObject) new Name(str));
            break;
          }
          this.Val.Add((BaseObject) new Text(str, false));
          break;
        case double number:
          this.Val.Add((BaseObject) new RealNumber(number));
          break;
        case int num:
          this.Val.Add((BaseObject) new RealNumber((double) num));
          break;
        case bool val:
          this.Val.Add((BaseObject) new Boolean(val));
          break;
        case BaseObject baseObject:
          this.Val.Add(baseObject);
          break;
        default:
          throw new FormatException();
      }
    }
  }
}
