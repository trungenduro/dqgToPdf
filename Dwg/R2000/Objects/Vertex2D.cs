// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.Objects.Vertex2D
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Dwg.R2000.Objects
{
  public class Vertex2D : dqgToPdf.Dwg.R2000.CommonEntityData
  {
    public Vertex2D(DwgBitArray ba)
      : base(ba)
    {
      this.LoadVertex2D(ba);
      this.LoadCommonEntityHandleData(ba);
      ba.DumpBitIndex();
      Console.WriteLine("");
    }

    public int Flags { get; set; }

    public Point3D Point { get; set; }

    public double StartWidth { get; set; }

    public double EndWidth { get; set; }

    public double Bulge { get; set; }

    public int VertexId { get; set; }

    public double TangentDir { get; set; }

    private void LoadVertex2D(DwgBitArray ba)
    {
      this.Flags = (int) ba.ReadByte();
      Console.WriteLine(string.Format("Flags: {0}", (object) this.Flags));
      this.Point = ba.Read3BD();
      Console.WriteLine(string.Format("Point: {0}", (object) this.Point));
      this.StartWidth = ba.ReadBD();
      Console.WriteLine(string.Format("StartWidth: {0}", (object) this.StartWidth));
      this.EndWidth = ba.ReadBD();
      Console.WriteLine(string.Format("EndWidth: {0}", (object) this.EndWidth));
      this.Bulge = ba.ReadBD();
      Console.WriteLine(string.Format("Bulge: {0}", (object) this.Bulge));
      this.TangentDir = ba.ReadBD();
      Console.WriteLine(string.Format("TangentDir: {0}", (object) this.TangentDir));
    }
  }
}
