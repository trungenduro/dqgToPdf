// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.AcDbEntity
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Dxf
{
  public class AcDbEntity
  {
    public AcDbEntity()
    {
    }

    public AcDbEntity(string layer, IEntity entInstance)
    {
      this.Layer = layer;
      this.EntityInstance = entInstance;
    }

    public string Layer { get; set; }

    public IEntity EntityInstance { get; set; }
  }
}
