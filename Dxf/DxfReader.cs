// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dxf.DxfReader
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dqgToPdf.Dxf
{
  public class DxfReader
  {
    public List<AcDbEntity> Entities { get; set; } = new List<AcDbEntity>();

    public List<LineStyle> LayerStyles { get; set; } = new List<LineStyle>();

    public string Filepath { get; set; }

    public string QRSTR { get; set; }

    public DxfReader(string path, bool isOda = false)
    {
      this.Filepath = path;
      this.LoadDxf(path);
    }

    private Point3D calculateDim1(Point3D p1, Point3D p2, Point3D dim2)
    {
      Point3D point3D1 = dim2 - p2;
      Point2D point2D1 = new Point2D()
      {
        x = point3D1.x,
        y = point3D1.y
      };
      point2D1.Rotate(Math.PI / 2.0);
      point2D1.Normlize();
      Point3D point3D2 = p1 - p2;
      Point2D point2D2 = new Point2D()
      {
        x = point3D2.x,
        y = point3D2.y
      };
      double num = point2D1.x * point2D2.x + point2D1.y * point2D2.y;
      return new Point3D()
      {
        x = dim2.x + num * point2D1.x,
        y = dim2.y + num * point2D1.y,
        z = dim2.z
      };
    }

    private AcDbEntity createAcDbLineEntity(
      string layerName,
      Point3D p1,
      Point3D p2,
      int lineWidth,
      int colorIndex)
    {
      return new AcDbEntity()
      {
        Layer = layerName,
        EntityInstance = (IEntity) new AcDbLine()
        {
          StartPointX = new double?(p1.x),
          StartPointY = new double?(p1.y),
          StartPointZ = new double?(p1.z),
          EndPointX = new double?(p2.x),
          EndPointY = new double?(p2.y),
          EndPointZ = new double?(p2.z),
          LineWeight = lineWidth,
          ColorIndex = colorIndex
        }
      };
    }

    public IEnumerable<AcDbText> Texts
    {
      get
      {
        return this.Entities.Where<AcDbEntity>((Func<AcDbEntity, bool>) (x => x.EntityInstance is AcDbText)).Select<AcDbEntity, AcDbText>((Func<AcDbEntity, AcDbText>) (y => y.EntityInstance as AcDbText));
      }
    }

    public void LoadDxf(string path)
    {
      Encoding encoding = Encoding.UTF8;
      using (StreamReader streamReader = new StreamReader(path, Encoding.GetEncoding(932)))
      {
        while (!streamReader.EndOfStream)
        {
          string str = streamReader.ReadLine();
          if (str.StartsWith("AC"))
          {
            if (str != "AC1027")
            {
              encoding = Encoding.GetEncoding(932);
              break;
            }
            break;
          }
        }
      }
      this.Entities.Clear();
      using (StreamReader sr = new StreamReader(path, encoding))
      {
        this.Skip(sr, "ENTITIES");
        while (!sr.EndOfStream)
        {
          AcDbEntity acDbEntity = this.LoadEntity(sr);
          if (acDbEntity != null)
            this.Entities.Add(acDbEntity);
        }
      }
    }

    public BoundingBox GetBoundingBox()
    {
      BoundingBox boundingBox1 = new BoundingBox();
      foreach (AcDbEntity entity in this.Entities)
      {
        BoundingBox boundingBox2 = entity.EntityInstance.GetBoundingBox();
        if (boundingBox2 != null)
          boundingBox1.AddBoudingBox(boundingBox2);
      }
      return boundingBox1;
    }

    public AcDbEntity LoadEntity(StreamReader sr)
    {
      AcDbEntity acDbEntity = new AcDbEntity();
      this.Skip(sr, "AcDbEntity");
      while (!sr.EndOfStream)
      {
        string str = sr.ReadLine();
        if (str == "  8")
          acDbEntity.Layer = sr.ReadLine();
        else if (str == "100")
        {
          switch (sr.ReadLine())
          {
            case "AcDbLine":
              acDbEntity.EntityInstance = (IEntity) new AcDbLine(sr);
              return acDbEntity;
            case "AcDbText":
              acDbEntity.EntityInstance = (IEntity) new AcDbText(sr);
              break;
            case "AcDbCircle":
              acDbEntity.EntityInstance = (IEntity) new AcDbCircle(sr);
              break;
            default:
              return (AcDbEntity) null;
          }
        }
        if (acDbEntity.Layer != null && acDbEntity.EntityInstance != null)
          return acDbEntity;
      }
      return (AcDbEntity) null;
    }

    private bool Skip(StreamReader sr, string s)
    {
      while (!sr.EndOfStream)
      {
        if (sr.ReadLine() == s)
          return true;
      }
      return false;
    }
  }
}
