// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.PDFReadingUtility
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Pdf.Objects;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace dqgToPdf.Pdf
{
  public static class PDFReadingUtility
  {
    public static BaseObject ReadObject(
      StreamReader sr,
      MemoryStream ms,
      PdfReader.PDF_VER ver = PdfReader.PDF_VER.PDF_1_7)
    {
      return (BaseObject) null;
    }

    public static BaseObject ReadObjectWithoutObjectNumber(
      StreamReader sr,
      MemoryStream ms,
      int objectNum,
      PdfReader.PDF_VER ver = PdfReader.PDF_VER.PDF_1_7)
    {
      return (BaseObject) null;
    }

    public static byte[] StrToByteArray(string str)
    {
      str = str.ToUpper();
      if (str.Length % 2 == 1)
        str += "0";
      byte[] numArray = new byte[str.Length / 2];
      for (int startIndex = 0; startIndex < str.Length; startIndex += 2)
      {
        string str1 = str.Substring(startIndex, 2);
        numArray[startIndex / 2] = Convert.ToByte(str1, 16);
      }
      return numArray;
    }

    public static string DecodeFlate(byte[] ba)
    {
      byte[] buffer = new byte[ba.Length - 2];
      System.Array.Copy((System.Array) ba, 2, (System.Array) buffer, 0, buffer.Length);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (DeflateStream deflateStream = new DeflateStream((System.IO.Stream) new MemoryStream(buffer), CompressionMode.Decompress))
        {
          deflateStream.CopyTo((System.IO.Stream) memoryStream);
          return Encoding.ASCII.GetString(memoryStream.ToArray());
        }
      }
    }

    public static void DumpString(string str, string filename)
    {
      using (StreamWriter streamWriter = new StreamWriter(filename))
        streamWriter.WriteLine(str);
    }

    public static bool IsObject(this string line)
    {
      return new Regex("\\d+\\s+\\d+\\s+obj").IsMatch(line);
    }

    public static int GetObjectNumber(this string line)
    {
      return int.Parse(new Regex("(\\d+)\\s+\\d+\\s+obj").Match(line).Groups[1].Value);
    }

    public static bool IsEOF(this string line)
    {
      return line.Trim() == "%%EOF";
    }

    public static bool IsXref(this string line)
    {
      return line.Trim() == "xref";
    }

    public static bool IsStartXref(this string line)
    {
      return line.Trim() == "startxref";
    }

    public static bool IsTrailer(this string line)
    {
      return line.Trim() == "trailer";
    }
  }
}
