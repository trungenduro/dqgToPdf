// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.XRecord
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class XRecord : CommonNonEntityData
  {
    public XRecord(DwgBitArray ba)
      : base(ba)
    {
      this.LoadXRecordData(ba);
    }

    public bool HasBinaryData { get; set; }

    public int NumDataBytes { get; set; }

    public byte[] DataBytes { get; set; }

    public int CloningFlag { get; set; }

    public HandleReference ParentHandle { get; set; }

    public List<HandleReference> ObjIdObjectHandles { get; set; } = new List<HandleReference>();

    private void LoadXRecordData(DwgBitArray ba)
    {
      this.HasBinaryData = ba.ReadB();
      Console.WriteLine(string.Format("HasBinaryData: {0}", (object) this.HasBinaryData));
      this.NumDataBytes = ba.ReadBL();
      Console.WriteLine(string.Format("NumDataBytes: {0}", (object) this.NumDataBytes));
      this.DataBytes = ba.ReadBytes(this.NumDataBytes);
      this.CloningFlag = (int) ba.ReadBS();
      Console.WriteLine(string.Format("CloningFlag: {0}", (object) this.CloningFlag));
      ++ba.bitindex;
      this.ParentHandle = ba.ReadH();
      Console.WriteLine(string.Format("ParentHandle: {0}", (object) this.ParentHandle));
      this.LoadReactors(ba);
      this.LoadXdicHandle(ba);
      ba.DumpBitIndex();
      while (ba.Residual >= 8)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("ObjIdObjectHandle: {0}", (object) handleReference));
        this.ObjIdObjectHandles.Add(handleReference);
      }
      ba.DumpBitIndex();
      Console.WriteLine("");
    }
  }
}
