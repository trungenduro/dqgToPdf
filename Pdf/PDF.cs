// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.PDF
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Objects;
using System;
using System.Collections.Generic;
using System.IO;

namespace dqgToPdf.Pdf
{
  public class PDF
  {
    protected Dictionary<int, BaseObject> _objectMap = new Dictionary<int, BaseObject>();
    protected string topFileHeader;

    public Dictionary<int, BaseObject> ObjectMap
    {
      get
      {
        return this._objectMap;
      }
      set
      {
        this._objectMap = value;
      }
    }

    protected int ObjectNumber { get; set; }

    public dqgToPdf.Pdf.Objects.Array CreateArray()
    {
      ++this.ObjectNumber;
      dqgToPdf.Pdf.Objects.Array array = new dqgToPdf.Pdf.Objects.Array(true);
      array.ObjectNumber = this.ObjectNumber;
      this._objectMap.Add(this.ObjectNumber, (BaseObject) array);
      return array;
    }

    public Dictionary CreateDictionary()
    {
      ++this.ObjectNumber;
      Dictionary dictionary = new Dictionary(true);
      dictionary.ObjectNumber = this.ObjectNumber;
      this._objectMap.Add(this.ObjectNumber, (BaseObject) dictionary);
      return dictionary;
    }

    public Dictionary CreateDocumentCatalog()
    {
      Dictionary dictionary = this.CreateDictionary();
      dictionary.Add("/Type", (object) "/Catalog");
      return dictionary;
    }

    public Dictionary CreatePageTree()
    {
      Dictionary dictionary = this.CreateDictionary();
      dictionary.Add("/Type", (object) "/Pages");
      return dictionary;
    }

    public dqgToPdf.Pdf.Objects.Stream CreateStream()
    {
      ++this.ObjectNumber;
      dqgToPdf.Pdf.Objects.Stream stream = new dqgToPdf.Pdf.Objects.Stream(true);
      stream.ObjectNumber = this.ObjectNumber;
      this._objectMap.Add(this.ObjectNumber, (BaseObject) stream);
      return stream;
    }

    public void RegiserObject(BaseObject bo)
    {
      if (!bo.isIndirect)
        throw new FormatException();
      bo.isIndirect = true;
      ++this.ObjectNumber;
      bo.ObjectNumber = this.ObjectNumber;
      this._objectMap.Add(this.ObjectNumber, bo);
    }

    private void WriteIndirectObjects(StreamWriter sw)
    {
      foreach (KeyValuePair<int, BaseObject> keyValuePair in this._objectMap)
      {
        keyValuePair.Value.Write(sw, true);
        sw.WriteLine();
      }
    }

    private void WriteCrossReferenceTable(StreamWriter sw)
    {
      sw.Flush();
      long position = sw.BaseStream.Position;
      sw.WriteLine("xref");
      sw.WriteLine("0 " + (this.ObjectNumber + 1).ToString());
      sw.WriteLine("0000000000 65535 f");
      foreach (KeyValuePair<int, BaseObject> keyValuePair in this._objectMap)
        sw.WriteLine(keyValuePair.Value.StartPosition.ToString("D10") + " 00000 n");
      sw.WriteLine("trailer");
      Dictionary dictionary = new Dictionary(false);
      dictionary.Add("/Root", (object) this._objectMap[1]);
      dictionary.Add("/Size", (object) (this.ObjectNumber + 1));
      sw.WriteLine(dictionary.Expression(false));
      sw.WriteLine("startxref");
      sw.WriteLine(position);
    }

    public void WritePdf(System.IO.Stream strm)
    {
      using (StreamWriter sw = new StreamWriter(strm))
      {
        sw.WriteLine("%PDF-1.6");
        this.WriteIndirectObjects(sw);
        this.WriteCrossReferenceTable(sw);
        sw.WriteLine("%%EOF");
      }
    }
  }
}
