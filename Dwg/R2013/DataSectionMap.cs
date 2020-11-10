// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.DataSectionMap
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace dqgToPdf.Dwg.R2013
{
  public class DataSectionMap
  {
    public ulong SizeOfSection { get; set; }

    public uint PageCount { get; set; }

    public uint MaxDecompressedSize { get; set; }

    public uint Unknown { get; set; }

    public uint Compressed { get; set; }

    public uint SectionID { get; set; }

    public uint Encrypted { get; set; }

    public string SectionName { get; set; }

    public List<SectionPageMapData> SectionPageMapDatas { get; set; } = new List<SectionPageMapData>();

    public byte[] GetObjectSectionBytes()
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream))
        {
          foreach (SectionPageMapData sectionPageMapData in this.SectionPageMapDatas)
            binaryWriter.Write(sectionPageMapData.theBytes);
          return memoryStream.ToArray();
        }
      }
    }

    public Dictionary<int, int> GetObjectMap()
    {
      if (this.SectionName != "AcDb:Handles")
        throw new Exception();
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream))
        {
          foreach (SectionPageMapData sectionPageMapData in this.SectionPageMapDatas)
            binaryWriter.Write(sectionPageMapData.theBytes);
          using (BinaryReader br = new BinaryReader((Stream) memoryStream))
          {
            br.BaseStream.Seek(0L, SeekOrigin.Begin);
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            while (true)
            {
              int key = 0;
              int num1 = 0;
              int num2 = (int) br.ReadByte() * 256 + (int) br.ReadByte();
              if (num2 != 2)
              {
                long position = br.BaseStream.Position;
                while ((long) num2 - (br.BaseStream.Position - position) > 2L)
                {
                  key += DwgUtility.ReadModuleChars(br, true, (List<byte>) null);
                  int num3 = DwgUtility.ReadModuleChars(br, false, (List<byte>) null);
                  num1 += num3;
                  dictionary.Add(key, num1);
                }
                int num4 = (int) br.ReadByte();
                int num5 = (int) br.ReadByte();
              }
              else
                break;
            }
            return dictionary;
          }
        }
      }
    }
  }
}
