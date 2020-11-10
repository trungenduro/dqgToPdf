// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.ClassSection
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace dqgToPdf.Dwg
{
  public class ClassSection
  {
    private DwgBitArray _dwgBitArray;
    public List<ClassSectionSet> _dataSets;

    private byte MaintenanceVersion { get; }

    public ClassSection(byte[] ba)
    {
      this._dwgBitArray = new DwgBitArray(ba, 0);
      this.loadVariables();
    }

    private void loadVariables()
    {
      this._dataSets = new List<ClassSectionSet>();
      while (this._dwgBitArray.BitMaxLength - this._dwgBitArray.bitindex > 8)
        this._dataSets.Add(new ClassSectionSet()
        {
          ClassNum = this._dwgBitArray.ReadBS(),
          Version = this._dwgBitArray.ReadBS(),
          AppName = this._dwgBitArray.ReadT(0),
          CppName = this._dwgBitArray.ReadT(0),
          ClassDxfName = this._dwgBitArray.ReadT(0),
          WasaZombie = this._dwgBitArray.ReadB(),
          ItemClassID = this._dwgBitArray.ReadBS()
        });
    }

    private void loadVer2013()
    {
      DwgBitArray dwgBitArray = this._dwgBitArray;
      if (!((IEnumerable<byte>) dwgBitArray.ReadBytes(16)).SequenceEqual<byte>((IEnumerable<byte>) new byte[16]
      {
        (byte) 141,
        (byte) 161,
        (byte) 196,
        (byte) 184,
        (byte) 196,
        (byte) 169,
        (byte) 248,
        (byte) 197,
        (byte) 192,
        (byte) 220,
        (byte) 244,
        (byte) 95,
        (byte) 231,
        (byte) 207,
        (byte) 182,
        (byte) 138
      }))
        throw new FormatException();
      int num1 = dwgBitArray.ReadRL();
      if (this.MaintenanceVersion > (byte) 3)
        dwgBitArray.ReadRL();
      int num2 = (int) dwgBitArray.ReadBS();
      int num3 = (int) dwgBitArray.ReadByte();
      int num4 = (int) dwgBitArray.ReadByte();
      dwgBitArray.ReadB();
      int bitindex = dwgBitArray.bitindex;
      while (num1 - (dwgBitArray.bitindex - bitindex) / 8 > 8)
      {
        int num5 = (int) dwgBitArray.ReadBS();
        int num6 = (int) dwgBitArray.ReadBS();
        int num7 = (int) dwgBitArray.ReadBS();
        int num8 = (int) dwgBitArray.ReadBS();
        int num9 = (int) dwgBitArray.ReadBS();
        dwgBitArray.ReadB();
        int num10 = (int) dwgBitArray.ReadBS();
        dwgBitArray.ReadBL();
        dwgBitArray.ReadBL();
        int num11 = (int) dwgBitArray.ReadBS();
        dwgBitArray.ReadBL();
        dwgBitArray.ReadBL();
      }
    }
  }
}
