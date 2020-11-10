// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2004.Objects.Layout
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dwgToPdfTest.Dwg;
using System;
using System.Collections.Generic;

namespace dqgToPdf.Dwg.R2004.Objects
{
  public class Layout : dqgToPdf.Dwg.R2004.CommonNonEntityData
  {
    public Layout(DwgBitArray ba)
      : base(ba)
    {
      this.LoadLayoutData(ba);
    }

    public string PageSetupName { get; set; }

    public string Printer_Config { get; set; }

    public int PlotLayoutFlags { get; set; }

    public double LeftMargin { get; set; }

    public double BottomMargin { get; set; }

    public double RightMargin { get; set; }

    public double TopMargin { get; set; }

    public double PaperWidth { get; set; }

    public double PaperHeight { get; set; }

    public string PaperSize { get; set; }

    public Point2D PlotOrigin { get; set; }

    public int PaperUnits { get; set; }

    public int PlotRotation { get; set; }

    public int PlotType { get; set; }

    public Point2D WindowMin { get; set; }

    public Point2D WindowMax { get; set; }

    public double RealWorldUnits { get; set; }

    public double DrawingUnits { get; set; }

    public string CurrentStyleSheet { get; set; }

    public int ScaleType { get; set; }

    public double ScaleFactor { get; set; }

    public Point2D PaperImageOrigin { get; set; }

    public int ShadePlotMode { get; set; }

    public int ShadePlotRes_Level { get; set; }

    public int ShadePlotCustomDPI { get; set; }

    public string LayoutName { get; set; }

    public int TabOrder { get; set; }

    public int Flag { get; set; }

    public Point3D UcsOrigin { get; set; }

    public Point2D Limmin { get; set; }

    public Point2D Limmax { get; set; }

    public Point3D Inspoint { get; set; }

    public Point3D UcsXAxis { get; set; }

    public Point3D UcsYAxis { get; set; }

    public double Elevation { get; set; }

    public int OrthoviewType { get; set; }

    public Point3D Extmin { get; set; }

    public Point3D Extmax { get; set; }

    public int ViewportCount { get; set; }

    public HandleReference ParentHandle { get; set; }

    public HandleReference PlotViewHandle { get; set; }

    public HandleReference AssociatedPaperSpaceBlockrecordHandle { get; set; }

    public HandleReference LastActiveViewportHandle { get; set; }

    public HandleReference BaseUcsHandle { get; set; }

    public HandleReference NamedUcsHandle { get; set; }

    public List<HandleReference> ViewPortHandles { get; set; } = new List<HandleReference>();

    private void LoadLayoutData(DwgBitArray ba)
    {
      this.PageSetupName = ba.ReadSJIS();
      Console.WriteLine("PageSetupName: " + this.PageSetupName);
      this.Printer_Config = ba.ReadSJIS();
      Console.WriteLine("Printer_Config: " + this.Printer_Config);
      this.PlotLayoutFlags = (int) ba.ReadBS();
      Console.WriteLine(string.Format("PlotLayoutFlags: {0:x2}", (object) this.PlotLayoutFlags));
      this.LeftMargin = ba.ReadBD();
      Console.WriteLine(string.Format("LeftMargin: {0}", (object) this.LeftMargin));
      this.BottomMargin = ba.ReadBD();
      Console.WriteLine(string.Format("BottomMargin: {0}", (object) this.BottomMargin));
      this.RightMargin = ba.ReadBD();
      Console.WriteLine(string.Format("RightMargin: {0}", (object) this.RightMargin));
      this.TopMargin = ba.ReadBD();
      Console.WriteLine(string.Format("TopMargin: {0}", (object) this.TopMargin));
      this.PaperWidth = ba.ReadBD();
      Console.WriteLine(string.Format("PaperWidth: {0}", (object) this.PaperWidth));
      this.PaperHeight = ba.ReadBD();
      Console.WriteLine(string.Format("PaperHeight: {0}", (object) this.PaperHeight));
      this.PaperSize = ba.ReadSJIS();
      Console.WriteLine("PaperSize: " + this.PaperSize);
      this.PlotOrigin = ba.Read2BD();
      Console.WriteLine(string.Format("PlotOrigin: {0}", (object) this.PlotOrigin));
      this.PaperUnits = (int) ba.ReadBS();
      Console.WriteLine(string.Format("PaperUnits: {0}", (object) this.PaperUnits));
      this.PlotRotation = (int) ba.ReadBS();
      Console.WriteLine(string.Format("PlotRotation: {0}", (object) this.PlotRotation));
      this.PlotType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("PlotType: {0}", (object) this.PlotType));
      this.WindowMin = ba.Read2BD();
      Console.WriteLine(string.Format("WindowMin: {0}", (object) this.WindowMin));
      this.WindowMax = ba.Read2BD();
      Console.WriteLine(string.Format("WindowMax: {0}", (object) this.WindowMax));
      this.RealWorldUnits = ba.ReadBD();
      Console.WriteLine(string.Format("RealWorldUnits: {0}", (object) this.RealWorldUnits));
      this.DrawingUnits = ba.ReadBD();
      Console.WriteLine(string.Format("DrawingUnits: {0}", (object) this.DrawingUnits));
      this.CurrentStyleSheet = ba.ReadSJIS();
      Console.WriteLine("CurrentStyleSheet: " + this.CurrentStyleSheet);
      this.ScaleType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("ScaleType: {0}", (object) this.ScaleType));
      this.ScaleFactor = ba.ReadBD();
      Console.WriteLine(string.Format("ScaleFactor: {0}", (object) this.ScaleFactor));
      this.PaperImageOrigin = ba.Read2BD();
      Console.WriteLine(string.Format("PaperImageOrigin: {0}", (object) this.PaperImageOrigin));
      this.ShadePlotMode = (int) ba.ReadBS();
      Console.WriteLine(string.Format("ShadePlotMode: {0}", (object) this.ShadePlotMode));
      this.ShadePlotRes_Level = (int) ba.ReadBS();
      Console.WriteLine(string.Format("ShadePlotRes_Level: {0}", (object) this.ShadePlotRes_Level));
      this.ShadePlotCustomDPI = (int) ba.ReadBS();
      Console.WriteLine(string.Format("ShadePlotCustomDPI: {0}", (object) this.ShadePlotCustomDPI));
      this.LayoutName = ba.ReadSJIS();
      Console.WriteLine("LayoutName: " + this.LayoutName);
      this.TabOrder = ba.ReadBL();
      Console.WriteLine(string.Format("TabOrder: {0}", (object) this.TabOrder));
      this.Flag = (int) ba.ReadBS();
      Console.WriteLine(string.Format("Flag: {0}", (object) this.Flag));
      this.UcsOrigin = ba.Read3BD();
      Console.WriteLine(string.Format("UcsOrigin: {0}", (object) this.UcsOrigin));
      this.Limmin = ba.Read2RD();
      Console.WriteLine(string.Format("Limmin: {0}", (object) this.Limmin));
      this.Limmax = ba.Read2RD();
      Console.WriteLine(string.Format("Limmax: {0}", (object) this.Limmax));
      this.Inspoint = ba.Read3BD();
      Console.WriteLine(string.Format("Inspoint: {0}", (object) this.Inspoint));
      this.UcsXAxis = ba.Read3BD();
      Console.WriteLine(string.Format("UcsXAxis: {0}", (object) this.UcsXAxis));
      this.UcsYAxis = ba.Read3BD();
      Console.WriteLine(string.Format("UcsYAxis: {0}", (object) this.UcsYAxis));
      this.Elevation = ba.ReadBD();
      Console.WriteLine(string.Format("Elevation: {0}", (object) this.Elevation));
      this.OrthoviewType = (int) ba.ReadBS();
      Console.WriteLine(string.Format("OrthoviewType: {0}", (object) this.OrthoviewType));
      this.Extmin = ba.Read3BD();
      Console.WriteLine(string.Format("Extmin: {0}", (object) this.Extmin));
      this.Extmax = ba.Read3BD();
      Console.WriteLine(string.Format("Extmax: {0}", (object) this.Extmax));
      this.ViewportCount = ba.ReadBL();
      Console.WriteLine(string.Format("ViewportCount: {0}", (object) this.ViewportCount));
      ba.DumpBitIndex();
      this.ParentHandle = ba.ReadH();
      Console.WriteLine(string.Format("ParentHandle: {0}", (object) this.ParentHandle));
      this.LoadReactors(ba);
      this.LoadXdicHandle(ba);
      this.PlotViewHandle = ba.ReadH();
      Console.WriteLine(string.Format("PlotViewHandle: {0}", (object) this.PlotViewHandle));
      this.AssociatedPaperSpaceBlockrecordHandle = ba.ReadH();
      Console.WriteLine(string.Format("AssociatedPaperSpaceBlockrecordHandle: {0}", (object) this.AssociatedPaperSpaceBlockrecordHandle));
      this.LastActiveViewportHandle = ba.ReadH();
      Console.WriteLine(string.Format("LastActiveViewportHandle: {0}", (object) this.LastActiveViewportHandle));
      this.BaseUcsHandle = ba.ReadH();
      Console.WriteLine(string.Format("BaseUcsHandle: {0}", (object) this.BaseUcsHandle));
      this.NamedUcsHandle = ba.ReadH();
      Console.WriteLine(string.Format("NamedUcsHandle: {0}", (object) this.NamedUcsHandle));
      for (int index = 0; index < this.ViewportCount; ++index)
      {
        HandleReference handleReference = ba.ReadH();
        Console.WriteLine(string.Format("ViewPortHandle: {0}", (object) handleReference));
        this.ViewPortHandles.Add(handleReference);
      }
      ba.DumpBitIndex();
      Console.WriteLine();
    }
  }
}
