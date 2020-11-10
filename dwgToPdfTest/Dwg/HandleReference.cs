// Decompiled with JetBrains decompiler
// Type: dwgToPdfTest.Dwg.HandleReference
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dwgToPdfTest.Dwg
{
  public class HandleReference
  {
    public byte Code { get; set; }

    public byte Counter { get; set; }

    public byte[] handleoffset { get; set; }

    public HandleReference(byte code, byte counter, byte[] handleoffset)
    {
      this.Code = code;
      this.Counter = counter;
      this.handleoffset = handleoffset;
    }

    public int GetHandleOffsetVal()
    {
      int num1 = 0;
      foreach (byte num2 in this.handleoffset)
        num1 = (num1 << 8) + (int) num2;
      return num1;
    }

    public override string ToString()
    {
      return string.Format(" \r\n    Code: {0}\r\n    Counter: {1}\r\n    HandleOffset: {2:x}", (object) this.Code, (object) this.Counter, (object) this.GetHandleOffsetVal());
    }

    public int getTargetHandle(int objectId)
    {
      switch (this.Code)
      {
        case 2:
        case 3:
        case 4:
        case 5:
          return this.GetHandleOffsetVal();
        case 6:
          return objectId + 1;
        case 8:
          return objectId - 1;
        case 10:
          return objectId + this.GetHandleOffsetVal();
        case 12:
          return objectId - this.GetHandleOffsetVal();
        default:
          throw new FormatException();
      }
    }
  }
}
