// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Objects.BaseObject
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.IO;

namespace dqgToPdf.Pdf.Objects
{
  public abstract class BaseObject
  {
    public int ObjectNumber { get; set; }

    public long StartPosition { get; set; }

    public bool isIndirect { get; set; }

    public BaseObject(bool isInirect = false)
    {
      this.isIndirect = isInirect;
    }

    public void Write(StreamWriter sw, bool direct = false)
    {
      if (!this.isIndirect)
        sw.Write(this.DirectExpresion());
      else if (direct)
      {
        sw.Flush();
        this.StartPosition = sw.BaseStream.Position;
        sw.WriteLine(this.ObjectNumber.ToString() + " 0 obj");
        sw.Write(this.DirectExpresion());
        sw.WriteLine("");
        sw.WriteLine("endobj");
      }
      else
        sw.Write(this.InDirectExpression());
    }

    public string Expression(bool isDirect = false)
    {
      return !this.isIndirect | isDirect ? this.DirectExpresion() : this.InDirectExpression();
    }

    public string InDirectExpression()
    {
      return this.ObjectNumber.ToString() + " 0 R";
    }

    public abstract string DirectExpresion();
  }
}
