// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2018.Objects.Image
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg.R2018.Objects
{
  public class Image : CommonEntityData
  {
    public int Classversion { get; set; }

    public Point3D pt0 { get; set; }

    public Point3D uvec { get; set; }

    public Point3D vvec { get; set; }

    public Point2D size { get; set; }

    public int displayprops { get; set; }

    public bool clipping { get; set; }

    public int brightness { get; set; }

    public int contrast { get; set; }

    public int fade { get; set; }

    public bool clipmode { get; set; }

    public int clipbndtype { get; set; }

    public Point2D pt02d { get; set; }

    public Point2D pt12d { get; set; }

    public int numclipverts { get; set; }

    public Image(DwgBitArray ba)
      : base(ba)
    {
      this.LoadImageData(ba);
      this.LoadCommonEntityHandleData(ba);
    }

    private void LoadImageData(DwgBitArray ba)
    {
      this.Classversion = ba.ReadBL();
      Console.WriteLine(string.Format("Classversion: {0}", (object) this.Classversion));
      this.pt0 = ba.Read3BD();
      Console.WriteLine(string.Format("pt0: {0}", (object) this.pt0));
    }
  }
}
