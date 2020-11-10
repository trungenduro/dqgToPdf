// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Contents.DocumentCatalog
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Objects;

namespace dqgToPdf.Pdf.Contents
{
  public class DocumentCatalog
  {
    protected PDF pdf;
    protected Dictionary contents;
    protected PageTree pagetrees;

    public DocumentCatalog()
    {
      this.pdf = new PDF();
      this.contents = this.pdf.CreateDictionary();
      this.contents.Add("/Type", (object) "/Catalog");
    }

    public PageTree AddPageTree()
    {
      this.pagetrees = new PageTree(this.pdf, this.contents.Add("/Pages", this.pdf.CreateDictionary()));
      return this.pagetrees;
    }

    public void WritePdf(System.IO.Stream stream)
    {
      this.pdf.WritePdf(stream);
    }
  }
}
