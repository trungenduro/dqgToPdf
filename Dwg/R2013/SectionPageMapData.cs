// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.SectionPageMapData
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System.Collections.Generic;
using System.IO;

namespace dqgToPdf.Dwg.R2013
{
  public class SectionPageMapData
  {
    public uint PageNumber { get; set; }

    public uint DataSizeForThisPage { get; set; }

    public ulong StartOffsetForThisPage { get; set; }

    public byte[] theBytes { get; set; }

    public void DecompressData(
      BinaryReader br,
      Dictionary<int, uint> SectionPageMap,
      int maxDecompressDataSize,
      bool isCompressed)
    {
      br.BaseStream.Seek((long) SectionPageMap[(int) this.PageNumber], SeekOrigin.Begin);
      br.ReadBytes(32);
      if (isCompressed)
        this.theBytes = DwgUtility.decompress(br.ReadBytes((int) this.DataSizeForThisPage), maxDecompressDataSize);
      else
        this.theBytes = br.ReadBytes((int) this.DataSizeForThisPage);
    }
  }
}
