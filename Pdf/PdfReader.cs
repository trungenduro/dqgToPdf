// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.PdfReader
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.ParserModel;
using dqgToPdf.Pdf.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dqgToPdf.Pdf
{
  public class PdfReader
  {
    private byte[] whiteSpaceChars = new byte[6]
    {
      (byte) 0,
      (byte) 9,
      (byte) 10,
      (byte) 12,
      (byte) 13,
      (byte) 32
    };
    public string filename;
    public PDF pdf;
    private PDFFile pdffile;
    private Trailer trailer;
    private System.Collections.Generic.Dictionary<string, Func<string, string>> HexTextConvertDictionary;

    public PdfReader.PDF_VER Version
    {
      get
      {
        return this.pdffile.FileHeaderVersion;
      }
    }

    private System.Collections.Generic.Dictionary<int, InDirectObject> objectDictionary { get; set; }

    private dqgToPdf.Pdf.ParserModel.Array annotArray { get; set; }

    public List<PDFText> textList { get; } = new List<PDFText>();

    private List<dqgToPdf.Pdf.ParserModel.Stream> contentStreams { get; set; } = new List<dqgToPdf.Pdf.ParserModel.Stream>();

    public string Filename
    {
      get
      {
        return this.filename;
      }
    }

    public PdfReader(string filename)
    {
      this.filename = filename;
    }

    private System.Collections.Generic.Dictionary<string, Func<string, string>> createHexTextConvertDictionary(
      IEnumerable<DictionaryItem> fontDicItems)
    {
      System.Collections.Generic.Dictionary<string, Func<string, string>> dictionary = new System.Collections.Generic.Dictionary<string, Func<string, string>>();
      if (fontDicItems == null)
        return dictionary;
      foreach (DictionaryItem fontDicItem in fontDicItems)
      {
        string val1 = fontDicItem.name.Val;
        string val2 = (this.getObject((this.getObject(fontDicItem.Val) as dqgToPdf.Pdf.ParserModel.Dictionary)["Encoding"]) as dqgToPdf.Pdf.ParserModel.Name).Val;
        if (val2.StartsWith("90ms-"))
          dictionary.Add(val1, (Func<string, string>) (bytes => string.Join("", ((IEnumerable<byte>) Encoding.BigEndianUnicode.GetBytes(Encoding.GetEncoding(932).GetString(PDFReadingUtility.StrToByteArray(bytes)))).Select<byte, string>((Func<byte, string>) (x => x.ToString("x2"))))));
        else if (val2.StartsWith("WinAnsi"))
        {
          dictionary.Add(val1, (Func<string, string>) (bytes => string.Join("", ((IEnumerable<byte>) Encoding.BigEndianUnicode.GetBytes(Encoding.ASCII.GetString(PDFReadingUtility.StrToByteArray(bytes)))).Select<byte, string>((Func<byte, string>) (x => x.ToString("x2"))))));
        }
        else
        {
          using (StreamReader streamReader = new StreamReader((System.IO.Stream) new MemoryStream((this.getObject((this.getObject(fontDicItem.Val) as dqgToPdf.Pdf.ParserModel.Dictionary)["ToUnicode"]) as dqgToPdf.Pdf.ParserModel.Stream).streamContent)))
          {
            System.Collections.Generic.Dictionary<string, string> charTable = new System.Collections.Generic.Dictionary<string, string>();
            while (!streamReader.EndOfStream)
            {
              if (new Regex("\\d+\\sbeginbfchar").IsMatch(streamReader.ReadLine()))
              {
                Regex regex = new Regex("<(?<from>.+?)>\\s*?<(?<to>.+?)>");
                string input;
                while ((input = streamReader.ReadLine()) != "endbfchar")
                {
                  Match match = regex.Match(input);
                  if (match.Success)
                  {
                    string lower1 = match.Groups["from"].Value.ToLower();
                    string lower2 = match.Groups["to"].Value.ToLower();
                    charTable.Add(lower1, lower2);
                  }
                }
              }
            }
            Func<string, string> func = (Func<string, string>) (str =>
            {
              string str1 = "";
              for (int startIndex = 0; startIndex < str.Length; startIndex += 4)
              {
                string str2 = str.Substring(startIndex, 4);
                str1 += charTable[str2.ToLower()];
              }
              return str1;
            });
            dictionary.Add(val1, func);
          }
        }
      }
      return dictionary;
    }

    private object getObject(object obj)
    {
      return obj is InDirectLabel inDirectLabel ? this.objectDictionary[inDirectLabel.ObjectNumber].Object : obj;
    }

    public override string ToString()
    {
      return Path.GetFileName(this.filename);
    }

    public void Write(FileStream filestream)
    {
      this.AddLinkAnotation();
      this.WriteToFile(filestream);
    }

    private void WriteToFile(FileStream fileStream)
    {
      using (StreamWriter sw = new StreamWriter((System.IO.Stream) fileStream, Encoding.ASCII))
      {
        System.Collections.Generic.Dictionary<int, long> dictionary = new System.Collections.Generic.Dictionary<int, long>();
        dictionary.Add(0, 0L);
        sw.WriteLine("%PDF-1.6");
        foreach (KeyValuePair<int, InDirectObject> keyValuePair in this.objectDictionary)
        {
          sw.Flush();
          dictionary.Add(keyValuePair.Key, sw.BaseStream.Position);
          keyValuePair.Value.Write(sw);
          sw.WriteLine();
        }
        sw.Flush();
        long position = sw.BaseStream.Position;
        sw.WriteLine("xref");
        for (int index1 = 0; index1 <= this.objectDictionary.Keys.Max(); ++index1)
        {
          int num1 = -1;
          foreach (int num2 in (IEnumerable<int>) dictionary.Keys.OrderBy<int, int>((Func<int, int>) (x => x)))
          {
            if (num1 == -1)
            {
              if (index1 <= num2)
              {
                num1 = num2;
                index1 = num2;
              }
            }
            else if (num2 == index1 + 1)
              ++index1;
          }
          if (num1 != -1)
          {
            sw.WriteLine(num1.ToString() + " " + (index1 - num1 + 1).ToString());
            for (int index2 = num1; index2 <= index1; ++index2)
            {
              if (index2 == 0)
                sw.WriteLine("0000000000 65535 f");
              else
                sw.WriteLine(dictionary[index2].ToString("D10") + " 00000 n");
            }
          }
        }
        sw.WriteLine("trailer");
        sw.WriteLine("<<");
        sw.WriteLine("/Root {0} 0 R", (object) (this.trailer.Dic["Root"] as InDirectLabel).ObjectNumber);
        sw.WriteLine("/Size {0}", (object) this.objectDictionary.Keys.Count);
        sw.WriteLine(">>");
        sw.WriteLine("startxref");
        sw.WriteLine(position);
        sw.WriteLine("%%EOF");
      }
    }

    private void AddWatermarkAnnotation()
    {
      if (this.annotArray == null)
        this.annotArray = new dqgToPdf.Pdf.ParserModel.Array()
        {
          Val = new List<object>()
        };
      List<object> objectList = new List<object>();
      foreach (object obj in this.annotArray.Val)
        objectList.Add(obj);
      dqgToPdf.Pdf.Objects.Stream stream = this.pdf.CreateStream();
      stream.Val = "\r\nBT \r\n    /F1 1 Tf\r\n    36 0 0 36 0 -36 Tm\r\n    (Do Not Build) Tx\r\nET\r\n";
      this.objectDictionary.Add(stream.ObjectNumber, new InDirectObject()
      {
        ObjectNumber = stream.ObjectNumber,
        GenerationNumber = 0,
        Object = (object) stream
      });
      int key = this.objectDictionary.Keys.Max() + 1;
      objectList.Add((object) new InDirectLabel()
      {
        GenerationNumber = 0,
        ObjectNumber = key
      });
      this.annotArray.Val = objectList;
      this.objectDictionary.Add(key, new InDirectObject()
      {
        ObjectNumber = key,
        GenerationNumber = 0,
        Object = (object) new dqgToPdf.Pdf.ParserModel.Dictionary()
        {
          Val = new List<DictionaryItem>()
          {
            new DictionaryItem()
            {
              name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "Type" },
              Val = (object) new dqgToPdf.Pdf.ParserModel.Name() { Val = "Annot" }
            },
            new DictionaryItem()
            {
              name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "Subtype" },
              Val = (object) new dqgToPdf.Pdf.ParserModel.Name()
              {
                Val = "Watermark"
              }
            },
            new DictionaryItem()
            {
              name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "AP" },
              Val = (object) new InDirectLabel()
              {
                GenerationNumber = 0,
                ObjectNumber = stream.ObjectNumber
              }
            }
          }
        }
      });
    }

    private void AddLinkAnotation()
    {
      if (this.annotArray == null)
        this.annotArray = new dqgToPdf.Pdf.ParserModel.Array()
        {
          Val = new List<object>()
        };
      List<object> objectList = new List<object>();
      foreach (object obj in this.annotArray.Val)
        objectList.Add(obj);
      foreach (PDFText text in this.textList)
      {
        if (text.LinkTarget != -1)
        {
          int key = this.objectDictionary.Keys.Max() + 1;
          objectList.Add((object) new InDirectLabel()
          {
            GenerationNumber = 0,
            ObjectNumber = key
          });
          dqgToPdf.Pdf.ParserModel.Dictionary dictionary = new dqgToPdf.Pdf.ParserModel.Dictionary();
          List<DictionaryItem> dictionaryItemList = new List<DictionaryItem>();
          dictionaryItemList.Add(new DictionaryItem()
          {
            name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "Type" },
            Val = (object) new dqgToPdf.Pdf.ParserModel.Name() { Val = "Annot" }
          });
          dictionaryItemList.Add(new DictionaryItem()
          {
            name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "Subtype" },
            Val = (object) new dqgToPdf.Pdf.ParserModel.Name() { Val = "Link" }
          });
          CurrentTransformationMatrix transformationMatrix = new CurrentTransformationMatrix()
          {
            a = text.a,
            b = text.b,
            c = text.c,
            d = text.d,
            e = text.e,
            f = text.f
          } * new CurrentTransformationMatrix()
          {
            a = text.ctma,
            b = text.ctmb,
            c = text.ctmc,
            d = text.ctmd,
            e = text.ctme,
            f = text.ctmf
          };
          double num1 = 0.0;
          double fontsize1 = text.fontsize;
          double num2 = (double) text.text.Length * text.fontsize;
          double fontsize2 = text.fontsize;
          double num3 = (double) text.text.Length * text.fontsize;
          double num4 = 0.0;
          double e = transformationMatrix.e;
          double f = transformationMatrix.f;
          double val2_1 = transformationMatrix.a * num1 + transformationMatrix.c * fontsize1 + transformationMatrix.e;
          double val2_2 = transformationMatrix.b * num1 + transformationMatrix.d * fontsize1 + transformationMatrix.f;
          double val1_1 = transformationMatrix.a * num2 + transformationMatrix.c * fontsize2 + transformationMatrix.e;
          double val1_2 = transformationMatrix.b * num2 + transformationMatrix.d * fontsize2 + transformationMatrix.f;
          double val2_3 = transformationMatrix.a * num3 + transformationMatrix.c * num4 + transformationMatrix.e;
          double val2_4 = transformationMatrix.b * num3 + transformationMatrix.d * num4 + transformationMatrix.f;
          double num5;
          double num6;
          double num7;
          double num8;
          if (transformationMatrix.a != 1.0 || transformationMatrix.b != 0.0 || (transformationMatrix.c != 0.0 || transformationMatrix.d != 1.0))
          {
            DictionaryItem dictionaryItem = new DictionaryItem()
            {
              name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "QuadPoints" }
            };
            dictionaryItem.Val = (object) new dqgToPdf.Pdf.ParserModel.Array()
            {
              Val = new List<object>()
              {
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = e },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = f },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = val2_1 },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = val2_2 },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = val1_1 },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = val1_2 },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = val2_3 },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = val2_4 }
              }
            };
            double num9 = Math.Min(Math.Min(e, val2_1), Math.Min(val1_1, val2_3)) - 0.1;
            double num10 = Math.Max(Math.Max(e, val2_1), Math.Max(val1_1, val2_3)) + 0.1;
            double num11 = Math.Min(Math.Min(f, val2_2), Math.Min(val1_2, val2_4)) - 0.1;
            double num12 = Math.Max(Math.Max(f, val2_2), Math.Max(val1_2, val2_4)) + 0.1;
            num5 = num9;
            num6 = num10;
            num7 = num11;
            num8 = num12;
            dictionaryItemList.Add(dictionaryItem);
          }
          else
          {
            num5 = transformationMatrix.e;
            num7 = transformationMatrix.f;
            num6 = transformationMatrix.a * num2 + transformationMatrix.c * fontsize2 + transformationMatrix.e;
            num8 = transformationMatrix.b * num2 + transformationMatrix.d * fontsize2 + transformationMatrix.f;
          }
          DictionaryItem dictionaryItem1 = new DictionaryItem()
          {
            name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "Rect" }
          };
          dictionaryItem1.Val = (object) new dqgToPdf.Pdf.ParserModel.Array()
          {
            Val = new List<object>()
            {
              (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = num5 },
              (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = num7 },
              (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = num6 },
              (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = num8 }
            }
          };
          dictionaryItemList.Add(dictionaryItem1);
          dictionaryItemList.Add(new DictionaryItem()
          {
            name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "Border" },
            Val = (object) new dqgToPdf.Pdf.ParserModel.Array()
            {
              Val = new List<object>()
              {
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = 0.0 },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = 0.0 },
                (object) new dqgToPdf.Pdf.ParserModel.RealNumber() { Val = 1.0 }
              }
            }
          });
          dictionaryItemList.Add(new DictionaryItem()
          {
            name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "A" },
            Val = (object) new dqgToPdf.Pdf.ParserModel.Dictionary()
            {
              Val = new List<DictionaryItem>()
              {
                new DictionaryItem()
                {
                  name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "Type" },
                  Val = (object) new dqgToPdf.Pdf.ParserModel.Name()
                  {
                    Val = "Action"
                  }
                },
                new DictionaryItem()
                {
                  name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "S" },
                  Val = (object) new dqgToPdf.Pdf.ParserModel.Name()
                  {
                    Val = "GoToR"
                  }
                },
                new DictionaryItem()
                {
                  name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "F" },
                  Val = (object) new dqgToPdf.Pdf.ParserModel.Text()
                  {
                    Val = text.targetRelativePath
                  }
                },
                new DictionaryItem()
                {
                  name = new dqgToPdf.Pdf.ParserModel.Name() { Val = "D" },
                  Val = (object) new dqgToPdf.Pdf.ParserModel.RealNumber()
                  {
                    Val = 0.0
                  }
                }
              }
            }
          });
          dictionary.Val = dictionaryItemList;
          this.objectDictionary.Add(key, new InDirectObject()
          {
            ObjectNumber = key,
            GenerationNumber = 0,
            Object = (object) dictionary
          });
        }
      }
      this.annotArray.Val = objectList;
    }

    public enum PDF_VER
    {
      PDF_1_0,
      PDF_1_1,
      PDF_1_2,
      PDF_1_3,
      PDF_1_4,
      PDF_1_5,
      PDF_1_6,
      PDF_1_7,
    }
  }
}
