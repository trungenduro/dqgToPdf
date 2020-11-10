// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.Vport
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class Vport : dqgToPdf.Dwg.R2004.CommonNonEntityData
  {
    public Vport(DwgBitArray ba)
      : base(ba)
    {
      this.LoadVportData(ba);
    }

    public string ENtryName { get; set; }

    public bool Flag64 { get; set; }

    public int XrefIndexPlus1 { get; set; }

    public bool Xdep { get; set; }

    public double ViewHeight { get; set; }

    public double AspectRatio { get; set; }

    public Point2D ViewCenter { get; set; }

    public Point3D ViewTarget { get; set; }

    public Point3D ViewDir { get; set; }

    public double ViewTwist { get; set; }

    public double LensLength { get; set; }

    public double FrontClip { get; set; }

    public double BackClip { get; set; }

    public int ViewMode { get; set; }

    public int RenderMode { get; set; }

    public bool UseDefaultLights { get; set; }

    public int DefaultLighitingType { get; set; }

    public double Brightness { get; set; }

    public double Constrast { get; set; }

    public int AmbientColorIndex { get; set; }

    public Point2D LowerLeft { get; set; }

    public Point2D UpperRight { get; set; }

    public bool UcsFollow { get; set; }

    public int CircleZoom { get; set; }

    public bool FastZoom { get; set; }

    public int UCSICON { get; set; }

    public bool GridOnOff { get; set; }

    public Point2D GrdSpacing { get; set; }

    public bool SnapOnOff { get; set; }

    public bool SnapStyle { get; set; }

    public int SnapIsopair { get; set; }

    public double SnapRot { get; set; }

    public Point2D SnapBase { get; set; }

    public Point2D SnapSpacing { get; set; }

    public bool Unknown { get; set; }

    public bool UcsPerViewport { get; set; }

    public Point3D UcsOrigin { get; set; }

    public Point3D UcsXAxis { get; set; }

    public Point3D UcsYAxis { get; set; }

    public double UcsElevation { get; set; }

    public int UcsOrthographicType { get; set; }

    public int GridFlags { get; set; }

    public int GridMajor { get; set; }

    public HandleReference VportControlHandle { get; set; }

    public HandleReference ExternalReferenceBlockHandle { get; set; }

    public HandleReference BackgroundHandle { get; set; }

    public HandleReference VisualStyleHandle { get; set; }

    public HandleReference SunHandle { get; set; }

    public HandleReference NamedUcsHandle { get; set; }

    public HandleReference BaseUcsHandle { get; set; }

    private void LoadVportData(DwgBitArray ba)
    {
      this.ENtryName = ba.ReadSJIS();
      Console.WriteLine("ENtryName: " + this.ENtryName);
      this.Flag64 = ba.ReadB();
      Console.WriteLine(string.Format("Flag64: {0}", (object) this.Flag64));
      this.XrefIndexPlus1 = (int) ba.ReadBS();
      Console.WriteLine(string.Format("XrefIndexPlus1: {0}", (object) this.XrefIndexPlus1));
      this.Xdep = ba.ReadB();
      Console.WriteLine(string.Format("Xdep: {0}", (object) this.Xdep));
      this.ViewHeight = ba.ReadBD();
      Console.WriteLine(string.Format("ViewHeight: {0}", (object) this.ViewHeight));
      this.AspectRatio = ba.ReadBD();
      Console.WriteLine(string.Format("AspectRatio: {0}", (object) this.AspectRatio));
      this.ViewCenter = ba.Read2RD();
      Console.WriteLine(string.Format("ViewCenter: {0}", (object) this.ViewCenter));
      this.ViewTarget = ba.Read3BD();
      Console.WriteLine(string.Format("ViewTarget: {0}", (object) this.ViewTarget));
      this.ViewDir = ba.Read3BD();
      Console.WriteLine(string.Format("ViewDir: {0}", (object) this.ViewDir));
      this.ViewTwist = ba.ReadBD();
      Console.WriteLine(string.Format("ViewTwist: {0}", (object) this.ViewTwist));
      this.LensLength = ba.ReadBD();
      Console.WriteLine(string.Format("LensLength: {0}", (object) this.LensLength));
      this.FrontClip = ba.ReadBD();
      Console.WriteLine(string.Format("LensLength: {0}", (object) this.LensLength));
      this.BackClip = ba.ReadBD();
      Console.WriteLine(string.Format("BackClip: {0}", (object) this.BackClip));
      this.ViewMode = (ba.ReadB() ? 8 : 0) + (ba.ReadB() ? 4 : 0) + (ba.ReadB() ? 2 : 0) + (ba.ReadB() ? 1 : 0);
      Console.WriteLine(string.Format("ViewMode: {0}", (object) this.ViewMode));
      this.RenderMode = (int) ba.ReadByte();
      Console.WriteLine(string.Format("RenderMode: {0}", (object) this.RenderMode));
      this.LowerLeft = ba.Read2RD();
      Console.WriteLine(string.Format("LowerLeft: {0}", (object) this.LowerLeft));
      this.UpperRight = ba.Read2RD();
      Console.WriteLine(string.Format("UpperRight: {0}", (object) this.UpperRight));
      this.UcsFollow = ba.ReadB();
      Console.WriteLine(string.Format("UcsFollow: {0}", (object) this.UcsFollow));
      this.CircleZoom = (int) ba.ReadBS();
      Console.WriteLine(string.Format("CircleZoom: {0}", (object) this.CircleZoom));
      this.FastZoom = ba.ReadB();
      Console.WriteLine(string.Format("FastZoom: {0}", (object) this.FastZoom));
      this.UCSICON = (ba.ReadB() ? 2 : 0) + (ba.ReadB() ? 1 : 0);
      Console.WriteLine(string.Format("UCSICON: {0}", (object) this.UCSICON));
      this.GridOnOff = ba.ReadB();
      Console.WriteLine(string.Format("GridOnOff: {0}", (object) this.GridOnOff));
      this.GrdSpacing = ba.Read2RD();
      Console.WriteLine(string.Format("GrdSpacing: {0}", (object) this.GrdSpacing));
      this.SnapOnOff = ba.ReadB();
      Console.WriteLine(string.Format("SnapOnOff: {0}", (object) this.SnapOnOff));
      this.SnapStyle = ba.ReadB();
      Console.WriteLine(string.Format("SnapStyle: {0}", (object) this.SnapStyle));
      this.SnapIsopair = (int) ba.ReadBS();
      Console.WriteLine(string.Format("SnapIsopair: {0}", (object) this.SnapIsopair));
      this.SnapRot = ba.ReadBD();
      Console.WriteLine(string.Format("SnapRot: {0}", (object) this.SnapRot));
      this.SnapBase = ba.Read2RD();
      Console.WriteLine(string.Format("SnapBase: {0}", (object) this.SnapBase));
      this.SnapSpacing = ba.Read2RD();
      Console.WriteLine(string.Format("SnapSpacing: {0}", (object) this.SnapSpacing));
      this.Unknown = ba.ReadB();
      Console.WriteLine(string.Format("Unknown: {0}", (object) this.Unknown));
      this.UcsPerViewport = ba.ReadB();
      Console.WriteLine(string.Format("UcsPerViewport: {0}", (object) this.UcsPerViewport));
      this.UcsOrigin = ba.Read3BD();
      Console.WriteLine(string.Format("UcsOrigin: {0}", (object) this.UcsOrigin));
      this.UcsXAxis = ba.Read3BD();
      Console.WriteLine(string.Format("UcsXAxis: {0}", (object) this.UcsXAxis));
      this.UcsYAxis = ba.Read3BD();
      Console.WriteLine(string.Format("UcsYAxis: {0}", (object) this.UcsYAxis));
      this.UcsElevation = ba.ReadBD();
      Console.WriteLine(string.Format("UcsElevation: {0}", (object) this.UcsElevation));
      this.UcsOrthographicType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("UcsOrthographicType: {0}", (object) this.UcsOrthographicType));
      this.VportControlHandle = ba.ReadH();
      Console.WriteLine(string.Format("VportControlHandle: {0}", (object) this.VportControlHandle));
      this.LoadReactors(ba);
      this.LoadXdicHandle(ba);
      this.ExternalReferenceBlockHandle = ba.ReadH();
      Console.WriteLine(string.Format("ExternalReferenceBlockHandle: {0}", (object) this.ExternalReferenceBlockHandle));
      this.NamedUcsHandle = ba.ReadH();
      Console.WriteLine(string.Format("NamedUcsHandle: {0}", (object) this.NamedUcsHandle));
      this.BaseUcsHandle = ba.ReadH();
      Console.WriteLine(string.Format("BaseUcsHandle: {0}", (object) this.BaseUcsHandle));
      ba.DumpBitIndex();
      Console.WriteLine("");
    }
  }
}
