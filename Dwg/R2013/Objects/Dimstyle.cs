// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2013.Objects.Dimstyle
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;

namespace dqgToPdf.Dwg.R2013.Objects
{
  public class Dimstyle : CommonNonEntityData
  {
    public Dimstyle(DwgBitArray ba)
      : base(ba)
    {
      this.LoadDimStyle(ba);
    }

    public string ENtryName { get; set; }

    public bool Flag64 { get; set; }

    public int XrefIndexPlus1 { get; set; }

    public bool Xdep { get; set; }

    public string DimPost { get; set; }

    public string DimApost { get; set; }

    public double DimScale { get; set; }

    public double DimAsz { get; set; }

    public double DimExo { get; set; }

    public double DimDli { get; set; }

    public double DimExe { get; set; }

    public double DimRnd { get; set; }

    public double DimDle { get; set; }

    public double DimTp { get; set; }

    public double DimTm { get; set; }

    public double DimFxl { get; set; }

    public double DimJogang { get; set; }

    public double DimTfill { get; set; }

    public CmColor DimTfillclr { get; set; }

    public bool DimTol { get; set; }

    public bool DimLim { get; set; }

    public bool DimTih { get; set; }

    public bool DimToh { get; set; }

    public bool DimSe1 { get; set; }

    public bool DimSe2 { get; set; }

    public int DimTad { get; set; }

    public int DimZin { get; set; }

    public int DimAzin { get; set; }

    public int DimArcSym { get; set; }

    public double DimTxt { get; set; }

    public double DimCen { get; set; }

    public double DimTsz { get; set; }

    public double DimAltf { get; set; }

    public double DimLfaC { get; set; }

    public double DimTvp { get; set; }

    public double DimTfac { get; set; }

    public double DimGap { get; set; }

    public double DimAltrnd { get; set; }

    public bool DimAlt { get; set; }

    public int DimAltd { get; set; }

    public bool DimTofl { get; set; }

    public bool DimSah { get; set; }

    public bool DimTix { get; set; }

    public bool DimSoxd { get; set; }

    public int DimClrd { get; set; }

    public int DimClre { get; set; }

    public int DimClrt { get; set; }

    public int DimAdec { get; set; }

    public int DimDec { get; set; }

    public int DimTdec { get; set; }

    public int DimAltu { get; set; }

    public int DimAlttd { get; set; }

    public int DimAunit { get; set; }

    public int DimFrac { get; set; }

    public int DimLunit { get; set; }

    public int DimDesp { get; set; }

    public int DimTmove { get; set; }

    public int DimJust { get; set; }

    public bool DimSd1 { get; set; }

    public bool DimSd2 { get; set; }

    public int DimTolj { get; set; }

    public int DimTzin { get; set; }

    public int DimAltz { get; set; }

    public int DimAlttz { get; set; }

    public bool DimUpt { get; set; }

    public int DimFit { get; set; }

    public bool DimFxlon { get; set; }

    public bool DimTxtDirection { get; set; }

    public double DimaltMzf { get; set; }

    public double DimMzf { get; set; }

    public string DimAltmzs { get; set; }

    public string DimMzs { get; set; }

    public int DimLwd { get; set; }

    public int DimLwe { get; set; }

    public bool Unknown { get; set; }

    private void LoadDimStyle(DwgBitArray ba)
    {
      this.Flag64 = ba.ReadB();
      Console.WriteLine(string.Format("Flag64: {0}", (object) this.Flag64));
      this.XrefIndexPlus1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("XrefIndexPlus1: {0}", (object) this.XrefIndexPlus1));
      this.DimScale = ba.ReadBD();
      Console.WriteLine(string.Format("ViewHeight: {0}", (object) this.DimScale));
      this.DimAsz = ba.ReadBD();
      Console.WriteLine(string.Format("DimAsz: {0}", (object) this.DimAsz));
      this.DimExo = ba.ReadBD();
      Console.WriteLine(string.Format("DimExo: {0}", (object) this.DimExo));
      this.DimDli = ba.ReadBD();
      Console.WriteLine(string.Format("DimDli: {0}", (object) this.DimDli));
      this.DimExe = ba.ReadBD();
      Console.WriteLine(string.Format("DimExe: {0}", (object) this.DimExe));
      this.DimRnd = ba.ReadBD();
      Console.WriteLine(string.Format("DimRnd: {0}", (object) this.DimRnd));
      this.DimDle = ba.ReadBD();
      Console.WriteLine(string.Format("DimDle: {0}", (object) this.DimDle));
      this.DimTp = ba.ReadBD();
      Console.WriteLine(string.Format("DimTp: {0}", (object) this.DimTp));
      this.DimTm = ba.ReadBD();
      Console.WriteLine(string.Format("DimTm: {0}", (object) this.DimTm));
      this.DimFxl = ba.ReadBD();
      Console.WriteLine(string.Format("DimFxl: {0}", (object) this.DimFxl));
      this.DimJogang = ba.ReadBD();
      Console.WriteLine(string.Format("DimJogang: {0}", (object) this.DimJogang));
      this.DimTfill = (double) ba.ReadBS();
      Console.WriteLine(string.Format("DimTfill: {0}", (object) this.DimTfill));
      this.DimTfillclr = ba.ReadCMC();
      Console.WriteLine(string.Format("DimTfillclr: {0}", (object) this.DimTfillclr));
      this.DimTol = ba.ReadB();
      Console.WriteLine(string.Format("DimTol {0}", (object) this.DimTol));
      this.DimLim = ba.ReadB();
      Console.WriteLine(string.Format("DimLim: {0}", (object) this.DimLim));
      this.DimTih = ba.ReadB();
      Console.WriteLine(string.Format("DimTih: {0}", (object) this.DimTih));
      this.DimToh = ba.ReadB();
      Console.WriteLine(string.Format("DimToh: {0}", (object) this.DimToh));
      this.DimSe1 = ba.ReadB();
      Console.WriteLine(string.Format("DimSe1: {0}", (object) this.DimSe1));
      this.DimSe2 = ba.ReadB();
      Console.WriteLine(string.Format("DimSe2: {0}", (object) this.DimSe2));
      Console.WriteLine(string.Format("RemainBits---------------------: {0}", (object) ba.Residual));
      this.DimTad = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimTad: {0}", (object) this.DimTad));
      this.DimZin = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimZin: {0}", (object) this.DimZin));
      this.DimAzin = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimAzin: {0}", (object) this.DimAzin));
      this.DimArcSym = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimArcSym: {0}", (object) this.DimArcSym));
      Console.WriteLine(string.Format("RemainBits---------------------: {0}", (object) ba.Residual));
      this.DimTxt = ba.ReadBD();
      Console.WriteLine(string.Format("DimTxt: {0}", (object) this.DimTxt));
      this.DimCen = ba.ReadBD();
      Console.WriteLine(string.Format("DimCen: {0}", (object) this.DimCen));
      this.DimTsz = ba.ReadBD();
      Console.WriteLine(string.Format("DimTsz: {0}", (object) this.DimTsz));
      this.DimAltf = ba.ReadBD();
      Console.WriteLine(string.Format("DimAltf: {0}", (object) this.DimAltf));
      this.DimLfaC = ba.ReadBD();
      Console.WriteLine(string.Format("DimLfaC: {0}", (object) this.DimLfaC));
      this.DimTvp = ba.ReadBD();
      Console.WriteLine(string.Format("DimTvp: {0}", (object) this.DimTvp));
      this.DimTfac = ba.ReadBD();
      Console.WriteLine(string.Format("DimTfac: {0}", (object) this.DimTfac));
      this.DimGap = ba.ReadBD();
      Console.WriteLine(string.Format("DimGap: {0}", (object) this.DimGap));
      this.DimAltrnd = ba.ReadBD();
      Console.WriteLine(string.Format("DimAltrnd: {0}", (object) this.DimAltrnd));
      this.DimAlt = ba.ReadB();
      Console.WriteLine(string.Format("DimAlt: {0}", (object) this.DimAlt));
      this.DimAltd = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimAltd: {0}###################", (object) this.DimAltd));
      this.DimTofl = ba.ReadB();
      Console.WriteLine(string.Format("DimTofl: {0}", (object) this.DimTofl));
      this.DimSah = ba.ReadB();
      Console.WriteLine(string.Format("DimSah: {0}", (object) this.DimSah));
      this.DimTix = ba.ReadB();
      Console.WriteLine(string.Format("DimTix: {0}", (object) this.DimTix));
      this.DimSoxd = ba.ReadB();
      Console.WriteLine(string.Format("DimSoxd: {0}", (object) this.DimSoxd));
      DwgBitArray dwgBitArray = ba;
      dwgBitArray.bitindex = dwgBitArray.bitindex;
      this.DimClrd = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimClrd: {0}", (object) this.DimClrd));
      this.DimClre = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimClre: {0}", (object) this.DimClre));
      this.DimClrt = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimClrt: {0}", (object) this.DimClrt));
      this.DimDec = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimDec: {0}", (object) this.DimDec));
      this.DimTdec = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimTdec: {0}", (object) this.DimTdec));
      this.DimAltu = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimAltu: {0}", (object) this.DimAltu));
      this.DimAlttd = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimAlttd: {0}", (object) this.DimAlttd));
      this.DimAunit = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimAunit: {0}", (object) this.DimAunit));
      this.DimFrac = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimFrac: {0}", (object) this.DimFrac));
      this.DimLunit = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimLunit: {0}", (object) this.DimLunit));
      this.DimDesp = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimDesp: {0}", (object) this.DimDesp));
      this.DimTmove = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimTmove: {0}", (object) this.DimTmove));
      this.DimJust = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimJust: {0}", (object) this.DimJust));
      this.DimSd1 = ba.ReadB();
      Console.WriteLine(string.Format("DimSd1: {0}", (object) this.DimSd1));
      this.DimSd2 = ba.ReadB();
      Console.WriteLine(string.Format("DimSd2: {0}", (object) this.DimSd2));
      this.DimTolj = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimTolj: {0}", (object) this.DimTolj));
      this.DimTzin = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimTzin: {0}", (object) this.DimTzin));
      this.DimAltz = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimAltz: {0}", (object) this.DimAltz));
      this.DimAlttz = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimAlttz: {0}", (object) this.DimAlttz));
      this.DimUpt = ba.ReadB();
      Console.WriteLine(string.Format("DimUpt: {0}", (object) this.DimUpt));
      this.DimFit = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimFit: {0}", (object) this.DimFit));
      this.DimFxlon = ba.ReadB();
      Console.WriteLine(string.Format("DimFxlon: {0}", (object) this.DimFxlon));
      this.DimTxtDirection = ba.ReadB();
      Console.WriteLine(string.Format("DimTxtDirection: {0}", (object) this.DimTxtDirection));
      if (this.DimTxtDirection)
        Console.WriteLine(string.Format("nazobaito: {0}", (object) ba.ReadByte()));
      this.DimaltMzf = ba.ReadBD();
      Console.WriteLine(string.Format("DimaltMzf: {0}", (object) this.DimaltMzf));
      this.DimMzf = ba.ReadBD();
      Console.WriteLine(string.Format("DimMzf: {0}", (object) this.DimMzf));
      this.DimLwd = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimLwd: {0}", (object) this.DimLwd));
      this.DimLwe = (int) ba.ReadBS();
      Console.WriteLine(string.Format("DimLwe: {0}", (object) this.DimLwe));
      this.Unknown = ba.ReadB();
      Console.WriteLine(string.Format("Unknown: {0}", (object) this.Unknown));
      Console.WriteLine(string.Format("BitIndex: {0}", (object) ba.bitindex));
      Console.WriteLine(string.Format("RemainBits-------------------------------------: {0}", (object) ba.Residual));
      Console.WriteLine(string.Format("BitIndex: {0}", (object) ba.bitindex));
      Console.WriteLine(string.Format("RemainBits-------------------------------------: {0}", (object) ba.Residual));
      this.ENtryName = ba.ReadTU();
      Console.WriteLine("ENtryName: " + this.ENtryName);
      this.DimPost = ba.ReadTU();
      Console.WriteLine("DimPost: " + this.DimPost);
      this.DimApost = ba.ReadTU();
      Console.WriteLine("DimApost: " + this.DimApost);
      this.DimAltmzs = ba.ReadTU();
      Console.WriteLine("DimAltmzs: " + this.DimAltmzs);
      this.DimMzs = ba.ReadTU();
      Console.WriteLine("DimMzs: " + this.DimMzs);
      Console.WriteLine(string.Format("RemainBits: {0}", (object) ba.Residual));
      ba.bitindex += 17;
      Console.WriteLine(string.Format("RemainBits: {0}", (object) ba.Residual));
      this.DimStyleContorlHandle = ba.ReadH();
      Console.WriteLine(string.Format("DimStyleContorlHandle: {0}", (object) this.DimStyleContorlHandle));
      this.ExternalReferenceBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("ExternalReferenceBlockHandle: {0}", (object) this.ExternalReferenceBlockHandle));
      this.LoadReactors(ba);
      this.LoadXdicHandle(ba);
      this.ShapeFileHandle = ba.ReadH();
      Console.WriteLine(string.Format("ShapeFileHandle: {0}", (object) this.ShapeFileHandle));
      this.LeadrBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("LeadrBlockHandle: {0}", (object) this.LeadrBlockHandle));
      this.DimBlkHandle = ba.ReadH();
      Console.WriteLine(string.Format("DimBlk: {0}", (object) this.DimBlkHandle));
      this.DimBlk1Handle = ba.ReadH();
      Console.WriteLine(string.Format("DimBlk1: {0}", (object) this.DimBlk1Handle));
      this.DimBlk2Handle = ba.ReadH();
      Console.WriteLine(string.Format("DimBlk2: {0}", (object) this.DimBlk2Handle));
      this.DimlTypeHandle = ba.ReadH();
      Console.WriteLine(string.Format("DimlType: {0}", (object) this.DimlTypeHandle));
      this.DimlTex1Handle = ba.ReadH();
      Console.WriteLine(string.Format("DimlTex1: {0}", (object) this.DimlTex1Handle));
      this.DimlTex2Handle = ba.ReadH();
      Console.WriteLine(string.Format("DimlTex2: {0}", (object) this.DimlTex2Handle));
      Console.WriteLine(string.Format("RemainBits: {0}", (object) ba.Residual));
      Console.WriteLine("");
    }

    public HandleReference DimlTex2Handle { get; set; }

    public HandleReference DimlTex1Handle { get; set; }

    public HandleReference DimlTypeHandle { get; set; }

    public HandleReference DimBlk2Handle { get; set; }

    public HandleReference DimBlk1Handle { get; set; }

    public HandleReference DimBlkHandle { get; set; }

    public HandleReference LeadrBlockHandle { get; set; }

    public HandleReference ShapeFileHandle { get; set; }

    public HandleReference ExternalReferenceBlockHandle { get; set; }

    public HandleReference DimStyleContorlHandle { get; set; }
  }
}
