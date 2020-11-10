// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2000.AcDbClasses
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace dqgToPdf.Dwg.R2000
{
  public class AcDbClasses
  {
    public List<ClassData> ClassDataList = new List<ClassData>();

    public AcDbClasses(DwgBitArray ba)
    {
      this.LoadAcdbClasses(ba);
    }

    public int SizeInBytes { get; set; }

    public int SizeInBits { get; set; }

    public int MaximumClassNumber { get; set; }

    public bool BoolValue { get; set; }

    public bool StringStreamBool { get; set; }

    private void LoadAcdbClasses(DwgBitArray ba)
    {
      Console.WriteLine(string.Join(" ", ((IEnumerable<byte>) ba.ReadBytes(16)).Select<byte, string>((Func<byte, string>) (x => x.ToString("x2")))));
      this.SizeInBytes = ba.ReadRL();
      Console.WriteLine(string.Format("SizeInBytes: {0}", (object) this.SizeInBytes));
      this.LoadClassData(ba);
    }

    private void LoadClassData(DwgBitArray ba)
    {
      while (true)
      {
        ClassData classData = new ClassData();
        classData.ClassNum = (int) ba.ReadBS();
        Console.WriteLine(string.Format("cd.ClassNum: {0}", (object) classData.ClassNum));
        classData.ProxyFlags = (int) ba.ReadBS();
        Console.WriteLine(string.Format("cd.ProxyFlags: {0}", (object) classData.ProxyFlags));
        classData.AppName = ba.ReadSJIS();
        Console.WriteLine("cd.AppName: " + classData.AppName);
        classData.CppClassName = ba.ReadSJIS();
        Console.WriteLine("cd.CppClassName: " + classData.CppClassName);
        classData.ClassDxfName = ba.ReadSJIS();
        Console.WriteLine("cd.ClassDxfName: " + classData.ClassDxfName);
        classData.WasAZombie = ba.ReadB();
        Console.WriteLine(string.Format("cd.WasAZombie: {0}", (object) classData.WasAZombie));
        classData.ItemClassId = (int) ba.ReadBS();
        Console.WriteLine(string.Format("cd.ItemClassId: {0}", (object) classData.ItemClassId));
        this.ClassDataList.Add(classData);
        if (ba.Residual > 152)
          Console.WriteLine("");
        else
          break;
      }
      ba.DumpBitIndex();
      Console.WriteLine("");
    }
  }
}
