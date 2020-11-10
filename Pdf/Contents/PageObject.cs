// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Pdf.Contents.PageObject
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using dqgToPdf.Dwg;
using dqgToPdf.Pdf.Objects;
using ShxVectorlize;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace dqgToPdf.Pdf.Contents
{
  public class PageObject
  {
    private string header = "BT\r\n/F0 1.5 Tf\r\n";
    private string footer = "ET";
    private StringBuilder contentText = new StringBuilder();
    public double scale = 1.0;
    public readonly Color[] AutoCadColors = new Color[256]
    {
      new Color() { R = (byte) 0, G = (byte) 0, B = (byte) 0 },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 0,
        B = (byte) 0
      },
      new Color()
      {
        R = byte.MaxValue,
        G = byte.MaxValue,
        B = (byte) 0
      },
      new Color()
      {
        R = (byte) 0,
        G = byte.MaxValue,
        B = (byte) 0
      },
      new Color()
      {
        R = (byte) 0,
        G = byte.MaxValue,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 0,
        G = (byte) 0,
        B = byte.MaxValue
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 0,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 0, G = (byte) 0, B = (byte) 0 },
      new Color() { R = (byte) 65, G = (byte) 65, B = (byte) 65 },
      new Color()
      {
        R = (byte) 128,
        G = (byte) 128,
        B = (byte) 128
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 0,
        B = (byte) 0
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 170,
        B = (byte) 170
      },
      new Color() { R = (byte) 189, G = (byte) 0, B = (byte) 0 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 126,
        B = (byte) 126
      },
      new Color() { R = (byte) 129, G = (byte) 0, B = (byte) 0 },
      new Color() { R = (byte) 129, G = (byte) 86, B = (byte) 86 },
      new Color() { R = (byte) 104, G = (byte) 0, B = (byte) 0 },
      new Color() { R = (byte) 104, G = (byte) 69, B = (byte) 69 },
      new Color() { R = (byte) 79, G = (byte) 0, B = (byte) 0 },
      new Color() { R = (byte) 79, G = (byte) 53, B = (byte) 53 },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 63,
        B = (byte) 0
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 191,
        B = (byte) 170
      },
      new Color() { R = (byte) 189, G = (byte) 46, B = (byte) 0 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 141,
        B = (byte) 126
      },
      new Color() { R = (byte) 129, G = (byte) 31, B = (byte) 0 },
      new Color() { R = (byte) 129, G = (byte) 96, B = (byte) 86 },
      new Color() { R = (byte) 104, G = (byte) 25, B = (byte) 0 },
      new Color() { R = (byte) 104, G = (byte) 78, B = (byte) 69 },
      new Color() { R = (byte) 79, G = (byte) 19, B = (byte) 0 },
      new Color() { R = (byte) 79, G = (byte) 59, B = (byte) 53 },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 127,
        B = (byte) 0
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 212,
        B = (byte) 170
      },
      new Color() { R = (byte) 189, G = (byte) 94, B = (byte) 0 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 157,
        B = (byte) 126
      },
      new Color() { R = (byte) 129, G = (byte) 64, B = (byte) 0 },
      new Color()
      {
        R = (byte) 129,
        G = (byte) 107,
        B = (byte) 86
      },
      new Color() { R = (byte) 104, G = (byte) 52, B = (byte) 0 },
      new Color() { R = (byte) 104, G = (byte) 86, B = (byte) 69 },
      new Color() { R = (byte) 79, G = (byte) 39, B = (byte) 0 },
      new Color() { R = (byte) 79, G = (byte) 66, B = (byte) 53 },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 191,
        B = (byte) 0
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 234,
        B = (byte) 170
      },
      new Color() { R = (byte) 189, G = (byte) 141, B = (byte) 0 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 173,
        B = (byte) 126
      },
      new Color() { R = (byte) 129, G = (byte) 96, B = (byte) 0 },
      new Color()
      {
        R = (byte) 129,
        G = (byte) 118,
        B = (byte) 86
      },
      new Color() { R = (byte) 104, G = (byte) 78, B = (byte) 0 },
      new Color() { R = (byte) 104, G = (byte) 95, B = (byte) 69 },
      new Color() { R = (byte) 79, G = (byte) 59, B = (byte) 0 },
      new Color() { R = (byte) 79, G = (byte) 73, B = (byte) 53 },
      new Color()
      {
        R = byte.MaxValue,
        G = byte.MaxValue,
        B = (byte) 0
      },
      new Color()
      {
        R = byte.MaxValue,
        G = byte.MaxValue,
        B = (byte) 170
      },
      new Color() { R = (byte) 189, G = (byte) 189, B = (byte) 0 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 189,
        B = (byte) 126
      },
      new Color() { R = (byte) 129, G = (byte) 129, B = (byte) 0 },
      new Color()
      {
        R = (byte) 129,
        G = (byte) 129,
        B = (byte) 86
      },
      new Color() { R = (byte) 104, G = (byte) 104, B = (byte) 0 },
      new Color()
      {
        R = (byte) 104,
        G = (byte) 104,
        B = (byte) 69
      },
      new Color() { R = (byte) 79, G = (byte) 79, B = (byte) 0 },
      new Color() { R = (byte) 79, G = (byte) 79, B = (byte) 53 },
      new Color()
      {
        R = (byte) 191,
        G = byte.MaxValue,
        B = (byte) 0
      },
      new Color()
      {
        R = (byte) 234,
        G = byte.MaxValue,
        B = (byte) 170
      },
      new Color() { R = (byte) 141, G = (byte) 189, B = (byte) 0 },
      new Color()
      {
        R = (byte) 173,
        G = (byte) 189,
        B = (byte) 126
      },
      new Color() { R = (byte) 96, G = (byte) 129, B = (byte) 0 },
      new Color()
      {
        R = (byte) 118,
        G = (byte) 129,
        B = (byte) 86
      },
      new Color() { R = (byte) 78, G = (byte) 104, B = (byte) 0 },
      new Color() { R = (byte) 95, G = (byte) 104, B = (byte) 69 },
      new Color() { R = (byte) 59, G = (byte) 79, B = (byte) 0 },
      new Color() { R = (byte) 73, G = (byte) 79, B = (byte) 53 },
      new Color()
      {
        R = (byte) 127,
        G = byte.MaxValue,
        B = (byte) 0
      },
      new Color()
      {
        R = (byte) 212,
        G = byte.MaxValue,
        B = (byte) 170
      },
      new Color() { R = (byte) 94, G = (byte) 189, B = (byte) 0 },
      new Color()
      {
        R = (byte) 157,
        G = (byte) 189,
        B = (byte) 126
      },
      new Color() { R = (byte) 64, G = (byte) 129, B = (byte) 0 },
      new Color()
      {
        R = (byte) 107,
        G = (byte) 129,
        B = (byte) 86
      },
      new Color() { R = (byte) 52, G = (byte) 104, B = (byte) 0 },
      new Color() { R = (byte) 86, G = (byte) 104, B = (byte) 69 },
      new Color() { R = (byte) 39, G = (byte) 79, B = (byte) 0 },
      new Color() { R = (byte) 66, G = (byte) 79, B = (byte) 53 },
      new Color()
      {
        R = (byte) 63,
        G = byte.MaxValue,
        B = (byte) 0
      },
      new Color()
      {
        R = (byte) 191,
        G = byte.MaxValue,
        B = (byte) 170
      },
      new Color() { R = (byte) 46, G = (byte) 189, B = (byte) 0 },
      new Color()
      {
        R = (byte) 141,
        G = (byte) 189,
        B = (byte) 126
      },
      new Color() { R = (byte) 31, G = (byte) 129, B = (byte) 0 },
      new Color() { R = (byte) 96, G = (byte) 129, B = (byte) 86 },
      new Color() { R = (byte) 25, G = (byte) 104, B = (byte) 0 },
      new Color() { R = (byte) 78, G = (byte) 104, B = (byte) 69 },
      new Color() { R = (byte) 19, G = (byte) 79, B = (byte) 0 },
      new Color() { R = (byte) 59, G = (byte) 79, B = (byte) 53 },
      new Color()
      {
        R = (byte) 0,
        G = byte.MaxValue,
        B = (byte) 0
      },
      new Color()
      {
        R = (byte) 170,
        G = byte.MaxValue,
        B = (byte) 170
      },
      new Color() { R = (byte) 0, G = (byte) 189, B = (byte) 0 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 189,
        B = (byte) 126
      },
      new Color() { R = (byte) 0, G = (byte) 129, B = (byte) 0 },
      new Color() { R = (byte) 86, G = (byte) 129, B = (byte) 86 },
      new Color() { R = (byte) 0, G = (byte) 104, B = (byte) 0 },
      new Color() { R = (byte) 69, G = (byte) 104, B = (byte) 69 },
      new Color() { R = (byte) 0, G = (byte) 79, B = (byte) 0 },
      new Color() { R = (byte) 53, G = (byte) 79, B = (byte) 53 },
      new Color()
      {
        R = (byte) 0,
        G = byte.MaxValue,
        B = (byte) 63
      },
      new Color()
      {
        R = (byte) 170,
        G = byte.MaxValue,
        B = (byte) 191
      },
      new Color() { R = (byte) 0, G = (byte) 189, B = (byte) 46 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 189,
        B = (byte) 141
      },
      new Color() { R = (byte) 0, G = (byte) 129, B = (byte) 31 },
      new Color() { R = (byte) 86, G = (byte) 129, B = (byte) 96 },
      new Color() { R = (byte) 0, G = (byte) 104, B = (byte) 25 },
      new Color() { R = (byte) 69, G = (byte) 104, B = (byte) 78 },
      new Color() { R = (byte) 0, G = (byte) 79, B = (byte) 19 },
      new Color() { R = (byte) 53, G = (byte) 79, B = (byte) 59 },
      new Color()
      {
        R = (byte) 0,
        G = byte.MaxValue,
        B = (byte) 127
      },
      new Color()
      {
        R = (byte) 170,
        G = byte.MaxValue,
        B = (byte) 212
      },
      new Color() { R = (byte) 0, G = (byte) 189, B = (byte) 94 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 189,
        B = (byte) 157
      },
      new Color() { R = (byte) 0, G = (byte) 129, B = (byte) 64 },
      new Color()
      {
        R = (byte) 86,
        G = (byte) 129,
        B = (byte) 107
      },
      new Color() { R = (byte) 0, G = (byte) 104, B = (byte) 52 },
      new Color() { R = (byte) 69, G = (byte) 104, B = (byte) 86 },
      new Color() { R = (byte) 0, G = (byte) 79, B = (byte) 39 },
      new Color() { R = (byte) 53, G = (byte) 79, B = (byte) 66 },
      new Color()
      {
        R = (byte) 0,
        G = byte.MaxValue,
        B = (byte) 191
      },
      new Color()
      {
        R = (byte) 170,
        G = byte.MaxValue,
        B = (byte) 234
      },
      new Color() { R = (byte) 0, G = (byte) 189, B = (byte) 141 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 189,
        B = (byte) 173
      },
      new Color() { R = (byte) 0, G = (byte) 129, B = (byte) 96 },
      new Color()
      {
        R = (byte) 86,
        G = (byte) 129,
        B = (byte) 118
      },
      new Color() { R = (byte) 0, G = (byte) 104, B = (byte) 78 },
      new Color() { R = (byte) 69, G = (byte) 104, B = (byte) 95 },
      new Color() { R = (byte) 0, G = (byte) 79, B = (byte) 59 },
      new Color() { R = (byte) 53, G = (byte) 79, B = (byte) 73 },
      new Color()
      {
        R = (byte) 0,
        G = byte.MaxValue,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 170,
        G = byte.MaxValue,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 0, G = (byte) 189, B = (byte) 189 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 189,
        B = (byte) 189
      },
      new Color() { R = (byte) 0, G = (byte) 129, B = (byte) 129 },
      new Color()
      {
        R = (byte) 86,
        G = (byte) 129,
        B = (byte) 129
      },
      new Color() { R = (byte) 0, G = (byte) 104, B = (byte) 104 },
      new Color()
      {
        R = (byte) 69,
        G = (byte) 104,
        B = (byte) 104
      },
      new Color() { R = (byte) 0, G = (byte) 79, B = (byte) 79 },
      new Color() { R = (byte) 53, G = (byte) 79, B = (byte) 79 },
      new Color()
      {
        R = (byte) 0,
        G = (byte) 191,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 170,
        G = (byte) 234,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 0, G = (byte) 141, B = (byte) 189 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 173,
        B = (byte) 189
      },
      new Color() { R = (byte) 0, G = (byte) 96, B = (byte) 129 },
      new Color()
      {
        R = (byte) 86,
        G = (byte) 118,
        B = (byte) 129
      },
      new Color() { R = (byte) 0, G = (byte) 78, B = (byte) 104 },
      new Color() { R = (byte) 69, G = (byte) 95, B = (byte) 104 },
      new Color() { R = (byte) 0, G = (byte) 59, B = (byte) 79 },
      new Color() { R = (byte) 53, G = (byte) 73, B = (byte) 79 },
      new Color()
      {
        R = (byte) 0,
        G = (byte) 127,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 170,
        G = (byte) 212,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 0, G = (byte) 94, B = (byte) 189 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 157,
        B = (byte) 189
      },
      new Color() { R = (byte) 0, G = (byte) 64, B = (byte) 129 },
      new Color()
      {
        R = (byte) 86,
        G = (byte) 107,
        B = (byte) 129
      },
      new Color() { R = (byte) 0, G = (byte) 52, B = (byte) 104 },
      new Color() { R = (byte) 69, G = (byte) 86, B = (byte) 104 },
      new Color() { R = (byte) 0, G = (byte) 39, B = (byte) 79 },
      new Color() { R = (byte) 53, G = (byte) 66, B = (byte) 79 },
      new Color()
      {
        R = (byte) 0,
        G = (byte) 63,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 170,
        G = (byte) 191,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 0, G = (byte) 46, B = (byte) 189 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 141,
        B = (byte) 189
      },
      new Color() { R = (byte) 0, G = (byte) 31, B = (byte) 129 },
      new Color() { R = (byte) 86, G = (byte) 96, B = (byte) 129 },
      new Color() { R = (byte) 0, G = (byte) 25, B = (byte) 104 },
      new Color() { R = (byte) 69, G = (byte) 78, B = (byte) 104 },
      new Color() { R = (byte) 0, G = (byte) 19, B = (byte) 79 },
      new Color() { R = (byte) 53, G = (byte) 59, B = (byte) 79 },
      new Color()
      {
        R = (byte) 0,
        G = (byte) 0,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 170,
        G = (byte) 170,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 0, G = (byte) 0, B = (byte) 189 },
      new Color()
      {
        R = (byte) 126,
        G = (byte) 126,
        B = (byte) 189
      },
      new Color() { R = (byte) 0, G = (byte) 0, B = (byte) 129 },
      new Color() { R = (byte) 86, G = (byte) 86, B = (byte) 129 },
      new Color() { R = (byte) 0, G = (byte) 0, B = (byte) 104 },
      new Color() { R = (byte) 69, G = (byte) 69, B = (byte) 104 },
      new Color() { R = (byte) 0, G = (byte) 0, B = (byte) 79 },
      new Color() { R = (byte) 53, G = (byte) 53, B = (byte) 79 },
      new Color()
      {
        R = (byte) 63,
        G = (byte) 0,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 191,
        G = (byte) 170,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 46, G = (byte) 0, B = (byte) 189 },
      new Color()
      {
        R = (byte) 141,
        G = (byte) 126,
        B = (byte) 189
      },
      new Color() { R = (byte) 31, G = (byte) 0, B = (byte) 129 },
      new Color() { R = (byte) 96, G = (byte) 86, B = (byte) 129 },
      new Color() { R = (byte) 25, G = (byte) 0, B = (byte) 104 },
      new Color() { R = (byte) 78, G = (byte) 69, B = (byte) 104 },
      new Color() { R = (byte) 19, G = (byte) 0, B = (byte) 79 },
      new Color() { R = (byte) 59, G = (byte) 53, B = (byte) 79 },
      new Color()
      {
        R = (byte) 127,
        G = (byte) 0,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 212,
        G = (byte) 170,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 94, G = (byte) 0, B = (byte) 189 },
      new Color()
      {
        R = (byte) 157,
        G = (byte) 126,
        B = (byte) 189
      },
      new Color() { R = (byte) 64, G = (byte) 0, B = (byte) 129 },
      new Color()
      {
        R = (byte) 107,
        G = (byte) 86,
        B = (byte) 129
      },
      new Color() { R = (byte) 52, G = (byte) 0, B = (byte) 104 },
      new Color() { R = (byte) 86, G = (byte) 69, B = (byte) 104 },
      new Color() { R = (byte) 39, G = (byte) 0, B = (byte) 79 },
      new Color() { R = (byte) 66, G = (byte) 53, B = (byte) 79 },
      new Color()
      {
        R = (byte) 191,
        G = (byte) 0,
        B = byte.MaxValue
      },
      new Color()
      {
        R = (byte) 234,
        G = (byte) 170,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 141, G = (byte) 0, B = (byte) 189 },
      new Color()
      {
        R = (byte) 173,
        G = (byte) 126,
        B = (byte) 189
      },
      new Color() { R = (byte) 96, G = (byte) 0, B = (byte) 129 },
      new Color()
      {
        R = (byte) 118,
        G = (byte) 86,
        B = (byte) 129
      },
      new Color() { R = (byte) 78, G = (byte) 0, B = (byte) 104 },
      new Color() { R = (byte) 95, G = (byte) 69, B = (byte) 104 },
      new Color() { R = (byte) 59, G = (byte) 0, B = (byte) 79 },
      new Color() { R = (byte) 73, G = (byte) 53, B = (byte) 79 },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 0,
        B = byte.MaxValue
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 170,
        B = byte.MaxValue
      },
      new Color() { R = (byte) 189, G = (byte) 0, B = (byte) 189 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 126,
        B = (byte) 189
      },
      new Color() { R = (byte) 129, G = (byte) 0, B = (byte) 129 },
      new Color()
      {
        R = (byte) 129,
        G = (byte) 86,
        B = (byte) 129
      },
      new Color() { R = (byte) 104, G = (byte) 0, B = (byte) 104 },
      new Color()
      {
        R = (byte) 104,
        G = (byte) 69,
        B = (byte) 104
      },
      new Color() { R = (byte) 79, G = (byte) 0, B = (byte) 79 },
      new Color() { R = (byte) 79, G = (byte) 53, B = (byte) 79 },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 0,
        B = (byte) 191
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 170,
        B = (byte) 234
      },
      new Color() { R = (byte) 189, G = (byte) 0, B = (byte) 141 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 126,
        B = (byte) 173
      },
      new Color() { R = (byte) 129, G = (byte) 0, B = (byte) 96 },
      new Color()
      {
        R = (byte) 129,
        G = (byte) 86,
        B = (byte) 118
      },
      new Color() { R = (byte) 104, G = (byte) 0, B = (byte) 78 },
      new Color() { R = (byte) 104, G = (byte) 69, B = (byte) 95 },
      new Color() { R = (byte) 79, G = (byte) 0, B = (byte) 59 },
      new Color() { R = (byte) 79, G = (byte) 53, B = (byte) 73 },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 0,
        B = (byte) 127
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 170,
        B = (byte) 212
      },
      new Color() { R = (byte) 189, G = (byte) 0, B = (byte) 94 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 126,
        B = (byte) 157
      },
      new Color() { R = (byte) 129, G = (byte) 0, B = (byte) 64 },
      new Color()
      {
        R = (byte) 129,
        G = (byte) 86,
        B = (byte) 107
      },
      new Color() { R = (byte) 104, G = (byte) 0, B = (byte) 52 },
      new Color() { R = (byte) 104, G = (byte) 69, B = (byte) 86 },
      new Color() { R = (byte) 79, G = (byte) 0, B = (byte) 39 },
      new Color() { R = (byte) 79, G = (byte) 53, B = (byte) 66 },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 0,
        B = (byte) 63
      },
      new Color()
      {
        R = byte.MaxValue,
        G = (byte) 170,
        B = (byte) 191
      },
      new Color() { R = (byte) 189, G = (byte) 0, B = (byte) 46 },
      new Color()
      {
        R = (byte) 189,
        G = (byte) 126,
        B = (byte) 141
      },
      new Color() { R = (byte) 129, G = (byte) 0, B = (byte) 31 },
      new Color() { R = (byte) 129, G = (byte) 86, B = (byte) 96 },
      new Color() { R = (byte) 104, G = (byte) 0, B = (byte) 25 },
      new Color() { R = (byte) 104, G = (byte) 69, B = (byte) 78 },
      new Color() { R = (byte) 79, G = (byte) 0, B = (byte) 19 },
      new Color() { R = (byte) 79, G = (byte) 53, B = (byte) 59 },
      new Color() { R = (byte) 51, G = (byte) 51, B = (byte) 51 },
      new Color() { R = (byte) 80, G = (byte) 80, B = (byte) 80 },
      new Color()
      {
        R = (byte) 105,
        G = (byte) 105,
        B = (byte) 105
      },
      new Color()
      {
        R = (byte) 130,
        G = (byte) 130,
        B = (byte) 130
      },
      new Color()
      {
        R = (byte) 190,
        G = (byte) 190,
        B = (byte) 190
      },
      new Color() { R = (byte) 0, G = (byte) 0, B = (byte) 0 }
    };
    public Dictionary dictionary;
    public dqgToPdf.Pdf.Objects.Array mediaBox;
    protected Dictionary resources;
    protected dqgToPdf.Pdf.Objects.Stream contents;
    protected dqgToPdf.Pdf.Objects.Array annots;
    protected PDF pdf;

    public bool IsEnableLineStyle { get; set; }

    public PageObject(
      PDF pdf,
      Dictionary contents,
      dqgToPdf.Dwg.Point2D pageSize,
      double scale,
      dqgToPdf.Pdf.Objects.Array mediabox)
    {
      this.pdf = pdf;
      this.dictionary = contents;
      this.mediaBox = new dqgToPdf.Pdf.Objects.Array(false);
      this.mediaBox = mediabox;
      this.scale = scale;
      this.initprocess();
    }

    public void ShiftAndRotate(dqgToPdf.Dwg.Point2D shift, dqgToPdf.Dwg.Point2D dwgscale, double rotate)
    {
      dqgToPdf.Dwg.Point2D point2D = shift * this.scale;
      this.contentText.Append(string.Format(" q {0:f} {1:f} {2:f} {3:f} {4:f} {5:f} cm", (object) (Math.Cos(rotate) * dwgscale.x), (object) (Math.Sin(rotate) * dwgscale.x), (object) (-Math.Sin(rotate) * dwgscale.y), (object) (Math.Cos(rotate) * dwgscale.y), (object) point2D.x, (object) point2D.y) + Environment.NewLine);
    }

    public void RestoreState()
    {
      this.contentText.Append(" Q" + Environment.NewLine);
    }

    public void AddQRCode(string str, double x, double y)
    {
      Bitmap bitmap = new QRCodeEncoder().Encode(str);
      byte[] array1;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        bitmap.Save((System.IO.Stream) memoryStream, ImageFormat.Jpeg);
        array1 = memoryStream.ToArray();
      }
      Dictionary dic = new Dictionary(false);
      this.resources.Add("/XObject", dic);
      dqgToPdf.Pdf.Objects.Stream stream = dic.Add("/Im1", this.pdf.CreateStream());
      stream.Dic.Add("/Type", (object) "/XObject");
      stream.Dic.Add("/Subtype", (object) "/Image");
      stream.Dic.Add("/Width", (object) bitmap.Width);
      stream.Dic.Add("/Height", (object) bitmap.Height);
      stream.Dic.Add("/ColorSpace", (object) "/DeviceRGB");
      stream.Dic.Add("/BitsPerComponent", (object) 8);
      dqgToPdf.Pdf.Objects.Array array2 = stream.Dic.Add("/Filter", new dqgToPdf.Pdf.Objects.Array(false));
      array2.Add((object) "/ASCIIHexDecode");
      array2.Add((object) "/DCTDecode");
      stream.Val = string.Join("", ((IEnumerable<byte>) array1).Select<byte, string>((Func<byte, string>) (b => b.ToString("x2")))) + ">";
      int num = 40;
      this.contentText.Append(string.Format("{0} 0 0 {1} {2} {3} cm ", (object) num, (object) num, (object) x, (object) y) + Environment.NewLine);
      this.contentText.Append("/Im1 Do" + Environment.NewLine);
      this.refleshText();
    }

    private void initprocess()
    {
      this.resources = this.pdf.CreateDictionary();
      Dictionary dictionary1 = this.resources.Add("/Font", new Dictionary(false)).Add("/F0", new Dictionary(false));
      dictionary1.Add("/Type", (object) "/Font");
      dictionary1.Add("/Encoding", (object) "/90ms-RKSJ-H");
      dictionary1.Add("/BaseFont", (object) "/HeiseiMin-WS-90ms-RKSJ-H");
      dictionary1.Add("/Subtype", (object) "/Type0");
      Dictionary dictionary2 = dictionary1.Add("/DescendantFonts", new dqgToPdf.Pdf.Objects.Array(false)).Add(this.pdf.CreateDictionary());
      dictionary2.Add("/Type", (object) "/Font");
      dictionary2.Add("/Subtype", (object) "/CIDFontType0");
      dictionary2.Add("/BaseFont", (object) "/HeiseiMin-WS-90ms-RKSJ-H");
      Dictionary dictionary3 = dictionary2.Add("/CIDSystemInfo", new Dictionary(false));
      dictionary3.Add("/Registry", (object) "Adobe");
      dictionary3.Add("/Ordering", (object) "Japan1");
      dictionary3.Add("/Supplement", (object) 0);
      Dictionary dictionary4 = dictionary2.Add("/FontDescriptor", this.pdf.CreateDictionary());
      dictionary4.Add("/Type", (object) "/FontDescriptor");
      dictionary4.Add("/FontName", (object) "/HeiseiMin-WS-90ms-RKSJ-H");
      dictionary4.Add("/Flags", (object) 4);
      dqgToPdf.Pdf.Objects.Array array = dictionary4.Add("/FontBBox", new dqgToPdf.Pdf.Objects.Array(false));
      array.Add((object) -437);
      array.Add((object) -340);
      array.Add((object) 1147);
      array.Add((object) 1317);
      dictionary4.Add("/ItalicAngle", (object) 0);
      dictionary4.Add("/Ascent", (object) 1317);
      dictionary4.Add("/Descent", (object) -349);
      dictionary4.Add("/CapHeight", (object) 742);
      dictionary4.Add("/StemV", (object) 80);
      dictionary4.Add("/StemH", (object) 10);
      dictionary4.Add("/MaxWidth", (object) 10);
      this.contents = this.pdf.CreateStream();
      this.dictionary.Add("/Type", (object) "/Page");
      this.dictionary.Add("/Resources", this.resources);
      this.dictionary.Add("/MediaBox", this.mediaBox);
      this.dictionary.Add("/Contents", this.contents);
      this.annots = this.dictionary.Add("/Annots", new dqgToPdf.Pdf.Objects.Array(false));
    }

    public void SetLineWeight(double lineweight)
    {
      this.contentText.AppendLine((lineweight * 72.0 / 25.4).ToString("f8") + " w 1 j 1 J ");
    }

    public void SetColor(int coloridx)
    {
      Color autoCadColor = this.AutoCadColors[coloridx];
      this.contentText.AppendLine(((double) autoCadColor.R / (double) byte.MaxValue).ToString() + " " + ((double) autoCadColor.G / (double) byte.MaxValue).ToString() + " " + ((double) autoCadColor.B / (double) byte.MaxValue).ToString() + " RG ");
      this.contentText.AppendLine(((double) autoCadColor.R / (double) byte.MaxValue).ToString() + " " + ((double) autoCadColor.G / (double) byte.MaxValue).ToString() + " " + ((double) autoCadColor.B / (double) byte.MaxValue).ToString() + " rg ");
    }

    public void SetColor(int R, int G, int B, int Alpha)
    {
      this.contentText.AppendLine(((double) R / (double) byte.MaxValue).ToString() + " " + ((double) G / (double) byte.MaxValue).ToString() + " " + ((double) B / (double) byte.MaxValue).ToString() + " RG ");
      this.contentText.AppendLine(((double) R / (double) byte.MaxValue).ToString() + " " + ((double) G / (double) byte.MaxValue).ToString() + " " + ((double) B / (double) byte.MaxValue).ToString() + " rg ");
    }

    private void AddColor(int coloridx, bool isStroke = false)
    {
      Color color = this.AutoCadColors[0];
      switch (coloridx)
      {
        case 1:
          color = new Color()
          {
            R = byte.MaxValue,
            G = (byte) 0,
            B = (byte) 0
          };
          break;
        case 2:
          color = new Color()
          {
            R = (byte) 0,
            G = byte.MaxValue,
            B = (byte) 0
          };
          break;
        case 3:
          color = new Color()
          {
            R = (byte) 0,
            G = (byte) 0,
            B = byte.MaxValue
          };
          break;
        case 4:
          color = new Color()
          {
            R = byte.MaxValue,
            G = byte.MaxValue,
            B = (byte) 0
          };
          break;
        case 5:
          color = new Color()
          {
            R = (byte) 0,
            G = byte.MaxValue,
            B = byte.MaxValue
          };
          break;
        case 6:
          color = new Color()
          {
            R = byte.MaxValue,
            G = (byte) 0,
            B = byte.MaxValue
          };
          break;
      }
      this.contentText.AppendLine(((double) color.R / (double) byte.MaxValue).ToString() + " " + ((double) color.G / (double) byte.MaxValue).ToString() + " " + ((double) color.B / (double) byte.MaxValue).ToString() + " " + (isStroke ? "RG" : "rg"));
    }

    public void SetLinestyle(int styleidx = 0)
    {
      switch (styleidx)
      {
        case 0:
          this.contentText.Append("[] 0 d" + Environment.NewLine);
          break;
        case 1:
          this.contentText.Append("[3] 1 d" + Environment.NewLine);
          break;
        case 2:
          this.contentText.Append("[2 1] 1 d" + Environment.NewLine);
          break;
        case 3:
          this.contentText.Append("[1 2 3] 1 d 0 j 0 J " + Environment.NewLine);
          break;
      }
    }

    private void AddLineWidth(int widthIdx = 0)
    {
      double num = 0.14;
      switch (widthIdx)
      {
        case 0:
          num = 0.14;
          break;
        case 1:
          num = 0.56;
          break;
        case 2:
          num = 2.24;
          break;
      }
      this.contentText.AppendLine(num.ToString("f") + " w");
    }

    public void AddText(
      string text,
      dqgToPdf.Dwg.Point2D InsertPt,
      dqgToPdf.Dwg.Point2D xaxisDir,
      double fontSize,
      double fontWidth,
      string unifontName,
      string bigfontName)
    {
      double num1 = InsertPt.x * this.scale;
      double num2 = InsertPt.y * this.scale;
      fontSize *= this.scale;
      fontWidth *= this.scale;
      dqgToPdf.Dwg.Point2D point2D = xaxisDir.Clone().Normlize();
      double rotateAngle = point2D.RotateAngle;
      text = text.Replace("%%D", "°");
      text = text.Replace("%%P", "±");
      text = text.Replace("%%C", "∅");
      string str = text;
      string unifontName1 = unifontName;
      string bigfontName1 = bigfontName;
      ShxVectorlize.Point2D InsertionPoint = new ShxVectorlize.Point2D();
      InsertionPoint.x = num1;
      InsertionPoint.y = num2;
      double TextHeight = fontSize;
      double TextWidth = fontWidth;
      double rotaiton = rotateAngle;
      string pdfText = Vectorrizer.createPdfText(str, unifontName1, bigfontName1, InsertionPoint, TextHeight, TextWidth, rotaiton, false);
      if (pdfText == null)
      {
        this.contentText.AppendLine("/F0 " + fontSize.ToString() + " Tf");
        this.contentText.AppendLine(string.Format("{0:f} {1:f} {2:f} {3:f} {4:f} {5:f} Tm", (object) point2D.x, (object) point2D.y, (object) -point2D.y, (object) point2D.x, (object) num1, (object) num2));
        this.contentText.Append(this.ToHexText(text, (Encoding) null) + " Tj" + Environment.NewLine);
      }
      this.contentText.AppendLine(" 1 j 1 J ");
      this.contentText.AppendLine(pdfText);
      this.contentText.AppendLine(" 0 j 0 J ");
    }

    public void AddText(
      string text,
      double x,
      double y,
      double rotateAng,
      double fontSize,
      double fontWidth,
      string unifontName,
      string bigfontName)
    {
      string text1 = text;
      dqgToPdf.Dwg.Point2D InsertPt = new dqgToPdf.Dwg.Point2D();
      InsertPt.x = x;
      InsertPt.y = y;
      dqgToPdf.Dwg.Point2D xaxisDir = new dqgToPdf.Dwg.Point2D();
      xaxisDir.x = Math.Cos(rotateAng);
      xaxisDir.y = Math.Sin(rotateAng);
      double fontSize1 = fontSize;
      double fontWidth1 = fontWidth;
      string unifontName1 = unifontName;
      string bigfontName1 = bigfontName;
      this.AddText(text1, InsertPt, xaxisDir, fontSize1, fontWidth1, unifontName1, bigfontName1);
    }

    private string ToHexText(string text, Encoding _encoding = null)
    {
      if (_encoding == null)
        _encoding = Encoding.GetEncoding(932);
      return "<" + string.Join("", ((IEnumerable<byte>) _encoding.GetBytes(text)).Select<byte, string>((Func<byte, int, string>) ((b, i) => b.ToString("X2").ToLower()))) + ">";
    }

    private bool addShxTextContext(
      string text,
      string unifontName,
      string bigfontName,
      double x,
      double y,
      double rotateAng,
      double fontSize,
      double fontWidth,
      int colorIdx = -1,
      int widthidx = -1,
      int lineType = -1)
    {
      text?.StartsWith("%%U 5）");
      if (unifontName == null)
        return false;
      string str = text;
      string unifontName1 = unifontName;
      string bigfontName1 = bigfontName;
      ShxVectorlize.Point2D InsertionPoint = new ShxVectorlize.Point2D();
      InsertionPoint.x = x * this.scale;
      InsertionPoint.y = y * this.scale;
      double TextHeight = fontSize * this.scale;
      double TextWidth = fontWidth * this.scale;
      double rotaiton = rotateAng;
      string pdfText = Vectorrizer.createPdfText(str, unifontName1, bigfontName1, InsertionPoint, TextHeight, TextWidth, rotaiton, false);
      if (pdfText == null)
      {
        Console.WriteLine("unifont: " + unifontName + " , bigfont: " + bigfontName);
        return false;
      }
      this.contentText.AppendLine(" 1 j 1 J ");
      this.contentText.AppendLine(pdfText);
      return true;
    }

    public void AddWatemark()
    {
    }

    public void AddRemoteLink(
      dqgToPdf.Dwg.Point2D inspt,
      double width,
      double height,
      string targetpath,
      double rotate = 0.0)
    {
      this.AddRemoteLink(inspt.x, inspt.y, inspt.x + width, inspt.y + height, targetpath, rotate);
    }

    public void AddRemoteLink(
      double x,
      double y,
      double maxX,
      double maxY,
      string targetpath,
      double rotate = 0.0)
    {
      x *= this.scale;
      y *= this.scale;
      maxX *= this.scale;
      maxY *= this.scale;
      Dictionary dictionary = this.annots.Add(this.pdf.CreateDictionary());
      dictionary.Add("/Type", (object) "/Annot");
      dictionary.Add("/Subtype", (object) "/Link");
      dqgToPdf.Pdf.Objects.Array dic1 = new dqgToPdf.Pdf.Objects.Array(false);
      if (rotate != 0.0)
      {
        double num1 = Math.Cos(rotate);
        double num2 = Math.Sin(rotate);
        double num3 = maxX - x;
        double num4 = maxY - y;
        double val1_1 = x;
        double val1_2 = y;
        double val2_1 = -num2 * num4 + x;
        double val2_2 = num1 * num4 + y;
        double val1_3 = num1 * num3 - num2 * num4 + x;
        double val1_4 = num2 * num3 + num1 * num4 + y;
        double val2_3 = num1 * num3 + x;
        double val2_4 = num2 * num3 + y;
        x = Math.Min(Math.Min(val1_1, val2_3), Math.Min(val1_3, val2_1)) - 0.1;
        y = Math.Min(Math.Min(val1_2, val2_4), Math.Min(val1_4, val2_2)) - 0.1;
        maxX = Math.Max(Math.Max(val1_1, val2_3), Math.Max(val1_3, val2_1)) + 0.1;
        maxY = Math.Max(Math.Max(val1_2, val2_4), Math.Max(val1_4, val2_2)) + 0.1;
        dqgToPdf.Pdf.Objects.Array dic2 = new dqgToPdf.Pdf.Objects.Array(false);
        dic2.Add((object) val1_1);
        dic2.Add((object) val1_2);
        dic2.Add((object) val2_3);
        dic2.Add((object) val2_4);
        dic2.Add((object) val1_3);
        dic2.Add((object) val1_4);
        dic2.Add((object) val2_1);
        dic2.Add((object) val2_2);
        dictionary.Add("/QuadPoints", dic2);
      }
      dic1.Add((object) x);
      dic1.Add((object) y);
      dic1.Add((object) maxX);
      dic1.Add((object) maxY);
      dictionary.Add("/Rect", dic1);
      dqgToPdf.Pdf.Objects.Array dic3 = new dqgToPdf.Pdf.Objects.Array(false);
      dic3.Add((object) 0);
      dic3.Add((object) 0);
      dic3.Add((object) 1);
      dictionary.Add("/Border", dic3);
      Dictionary dic4 = new Dictionary(false);
      dic4.Add("/Type", (object) "/Action");
      dic4.Add("/S", (object) "/GoToR");
      dic4.Add("/F", (object) new dqgToPdf.Pdf.Objects.Text(targetpath, true));
      dic4.Add("/D", (object) 0);
      dictionary.Add("/A", dic4);
    }

    public void AddLink(
      dqgToPdf.Dwg.Point2D inspt,
      double width,
      double height,
      Dictionary targetPage,
      double rotate = 0.0)
    {
      this.AddLink(inspt.x, inspt.y, inspt.x + width, inspt.y + height, targetPage, rotate);
    }

    public void AddLink(
      double x,
      double y,
      double maxX,
      double maxY,
      Dictionary targetPage,
      double rotate = 0.0)
    {
      x *= this.scale;
      y *= this.scale;
      maxX *= this.scale;
      maxY *= this.scale;
      Dictionary dictionary = this.annots.Add(this.pdf.CreateDictionary());
      dictionary.Add("/Type", (object) "/Annot");
      dictionary.Add("/Subtype", (object) "/Link");
      dqgToPdf.Pdf.Objects.Array dic1 = new dqgToPdf.Pdf.Objects.Array(false);
      if (rotate != 0.0)
      {
        double num1 = Math.Cos(rotate);
        double num2 = Math.Sin(rotate);
        double num3 = maxX - x;
        double num4 = maxY - y;
        double val1_1 = x;
        double val1_2 = y;
        double val2_1 = -num2 * num4 + x;
        double val2_2 = num1 * num4 + y;
        double val1_3 = num1 * num3 - num2 * num4 + x;
        double val1_4 = num2 * num3 + num1 * num4 + y;
        double val2_3 = num1 * num3 + x;
        double val2_4 = num2 * num3 + y;
        x = Math.Min(Math.Min(val1_1, val2_3), Math.Min(val1_3, val2_1)) - 0.1;
        y = Math.Min(Math.Min(val1_2, val2_4), Math.Min(val1_4, val2_2)) - 0.1;
        maxX = Math.Max(Math.Max(val1_1, val2_3), Math.Max(val1_3, val2_1)) + 0.1;
        maxY = Math.Max(Math.Max(val1_2, val2_4), Math.Max(val1_4, val2_2)) + 0.1;
        dqgToPdf.Pdf.Objects.Array dic2 = new dqgToPdf.Pdf.Objects.Array(false);
        dic2.Add((object) val1_1);
        dic2.Add((object) val1_2);
        dic2.Add((object) val2_3);
        dic2.Add((object) val2_4);
        dic2.Add((object) val1_3);
        dic2.Add((object) val1_4);
        dic2.Add((object) val2_1);
        dic2.Add((object) val2_2);
        dictionary.Add("/QuadPoints", dic2);
      }
      dic1.Add((object) x);
      dic1.Add((object) y);
      dic1.Add((object) maxX);
      dic1.Add((object) maxY);
      dictionary.Add("/Rect", dic1);
      dqgToPdf.Pdf.Objects.Array dic3 = new dqgToPdf.Pdf.Objects.Array(false);
      dic3.Add((object) 0);
      dic3.Add((object) 0);
      dic3.Add((object) 1);
      dictionary.Add("/Border", dic3);
      dqgToPdf.Pdf.Objects.Array dic4 = new dqgToPdf.Pdf.Objects.Array(false);
      dic4.Add(targetPage);
      dic4.Add((object) "/FitH");
      dic4.Add((object) 0);
      dictionary.Add("/Dest", dic4);
    }

    private void addSplieContext(List<Point3D> controlPoints)
    {
      Point3D point3D1 = controlPoints[0] * this.scale;
      this.contentText.Append(string.Format("{0:f} {1:f} m", (object) point3D1.x, (object) point3D1.y) + Environment.NewLine);
      for (int index = 0; index < controlPoints.Count - 2; ++index)
      {
        Point3D point3D2 = controlPoints[index] * this.scale;
        Point3D point3D3 = controlPoints[index + 1] * this.scale;
        Point3D point3D4 = controlPoints[index + 2] * this.scale;
        Point3D point3D5 = point3D3;
        Point3D point3D6 = (point3D2 + point3D5) / 2.0;
        Point3D point3D7 = (point3D3 + point3D4) / 2.0;
        Point3D point3D8 = (point3D6 + point3D7) / 2.0;
        this.contentText.Append(string.Format("{0:f} {1:f} {2:f} {3:f} v", (object) point3D6.x, (object) point3D6.y, (object) point3D8.x, (object) point3D8.y) + Environment.NewLine);
        if (index == controlPoints.Count - 3)
          this.contentText.Append(string.Format("{0:f} {1:f} {2:f} {3:f} y S", (object) point3D7.x, (object) point3D7.y, (object) point3D4.x, (object) point3D4.y) + Environment.NewLine);
      }
    }

    public void AddSpline(List<Point3D> controlPoints)
    {
      this.addSplieContext(controlPoints);
    }

    public void AddSplineWithLineWeight(
      List<Point3D> controlPoints,
      int colorIndex,
      int lineWeight)
    {
      this.addLineWeightSetting(colorIndex, lineWeight);
      this.addSplieContext(controlPoints);
    }

    private void addSolidContext(Point3D[] corners)
    {
      this.contentText.Append(string.Format("{0:f} {1:f} m {2:f} {3:f} l \r\n{4:f} {5:f} l {6:f} {7:f} l b", (object) (corners[0].x * this.scale), (object) (corners[0].y * this.scale), (object) (corners[1].x * this.scale), (object) (corners[1].y * this.scale), (object) (corners[2].x * this.scale), (object) (corners[2].y * this.scale), (object) (corners[3].x * this.scale), (object) (corners[3].y * this.scale)) + Environment.NewLine);
    }

    public void AddSolid(Point3D[] corners, int colorIdx = 0, int lineWidth = 0, int lineType = 0)
    {
      this.AddColor(colorIdx, true);
      this.AddLineWidth(lineWidth);
      this.SetLinestyle(lineType);
      this.addSolidContext(corners);
    }

    public void AddSolidWithLineWeight(Point3D[] corners, int colorIndex, int lineWeight)
    {
      this.addLineWeightSetting(colorIndex, lineWeight);
      this.addSolidContext(corners);
    }

    public void AddLineWithLineWeight(
      double startX,
      double startY,
      double endX,
      double endY,
      int colorIndex,
      int lineWeight)
    {
      this.addLineWeightSetting(colorIndex, lineWeight);
      startX *= this.scale;
      startY *= this.scale;
      endX *= this.scale;
      endY *= this.scale;
      this.contentText.Append(string.Format("{0:f} {1:f} m {2:f} {3:f} l S", (object) startX, (object) startY, (object) endX, (object) endY) + Environment.NewLine);
    }

    public void AddLine(
      double startX,
      double startY,
      double endX,
      double endY,
      int colorIdx = 0,
      int lineWidth = 0,
      int lineType = 0)
    {
      startX *= this.scale;
      startY *= this.scale;
      endX *= this.scale;
      endY *= this.scale;
      this.contentText.Append(string.Format("{0:f} {1:f} m {2:f} {3:f} l S", (object) startX, (object) startY, (object) endX, (object) endY) + Environment.NewLine);
    }

    public void AddLine(dqgToPdf.Dwg.Point2D startPt, dqgToPdf.Dwg.Point2D endPt)
    {
      this.AddLine(startPt.x, startPt.y, endPt.x, endPt.y, 0, 0, 0);
    }

    public void AddLine(Point3D startPt, Point3D endPt)
    {
      this.AddLine(startPt.x, startPt.y, endPt.x, endPt.y, 0, 0, 0);
    }

    public void AddArcWithIsCcw(
      dqgToPdf.Dwg.Point2D center,
      double radius,
      double startAngle,
      double endAngle,
      bool isCcw,
      ref bool isStroking)
    {
      center *= this.scale;
      radius *= this.scale;
      if (radius < 1E-05)
        return;
      startAngle %= 2.0 * Math.PI;
      endAngle %= 2.0 * Math.PI;
      List<dqgToPdf.Dwg.Point2D> point2DList = new List<dqgToPdf.Dwg.Point2D>();
      double num1;
      if (isCcw)
      {
        num1 = endAngle - startAngle;
        if (num1 <= 0.0)
          num1 += 2.0 * Math.PI;
      }
      else
      {
        num1 = endAngle - startAngle;
        if (num1 > 0.0)
          num1 -= 2.0 * Math.PI;
      }
      int num2 = (int) Math.Floor(Math.Abs(num1) / (Math.PI / 2.0)) + 1;
      double num3 = num1 / (double) num2;
      double num4 = 4.0 / 3.0 * Math.Tan(num3 / 4.0);
      for (int index = 0; index < num2; ++index)
      {
        double num5 = startAngle + (double) index * num3;
        double num6 = startAngle + (double) (index + 1) * num3;
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = radius * Math.Cos(num5),
          y = radius * Math.Sin(num5)
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = radius * Math.Cos(num5) - Math.Sin(num5) * radius * num4,
          y = radius * Math.Sin(num5) + Math.Cos(num5) * radius * num4
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = radius * Math.Cos(num6) + Math.Sin(num6) * radius * num4,
          y = radius * Math.Sin(num6) - Math.Cos(num6) * radius * num4
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = radius * Math.Cos(num6),
          y = radius * Math.Sin(num6)
        });
      }
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x => x.Add(center)));
      if (!isStroking)
      {
        this.contentText.AppendLine(string.Format("{0:f} {1:f} m ", (object) point2DList[0].x, (object) point2DList[0].y));
        isStroking = true;
      }
      for (int index = 0; index < point2DList.Count / 4; ++index)
      {
        this.contentText.Append(string.Format("{0:f} {1:f} {2:f} {3:f} {4:f} {5:f}", (object) point2DList[index * 4 + 1].x, (object) point2DList[index * 4 + 1].y, (object) point2DList[index * 4 + 2].x, (object) point2DList[index * 4 + 2].y, (object) point2DList[index * 4 + 3].x, (object) point2DList[index * 4 + 3].y));
        this.contentText.Append(" c" + Environment.NewLine);
      }
    }

    private void arcContext(
      double centerX,
      double centerY,
      double radius,
      double startAngle,
      double EndAngle,
      Point3D extrusion)
    {
      centerX *= this.scale;
      centerY *= this.scale;
      radius *= this.scale;
      if (radius < 1E-05)
        return;
      if (startAngle > EndAngle)
        startAngle -= 2.0 * Math.PI;
      List<dqgToPdf.Dwg.Point2D> point2DList = new List<dqgToPdf.Dwg.Point2D>();
      double num1 = EndAngle - startAngle;
      int num2 = (int) Math.Floor((EndAngle - startAngle) / (Math.PI / 2.0)) + 1;
      double num3 = (double) num2;
      double num4 = num1 / num3;
      double num5 = 4.0 / 3.0 * Math.Tan(num4 / 4.0);
      dqgToPdf.Dwg.Point2D center = new dqgToPdf.Dwg.Point2D()
      {
        x = centerX,
        y = centerY
      };
      for (int index = 0; index < num2; ++index)
      {
        double num6 = startAngle + (double) index * num4;
        double num7 = startAngle + (double) (index + 1) * num4;
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = radius * Math.Cos(num6),
          y = radius * Math.Sin(num6)
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = radius * Math.Cos(num6) - Math.Sin(num6) * radius * num5,
          y = radius * Math.Sin(num6) + Math.Cos(num6) * radius * num5
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = radius * Math.Cos(num7) + Math.Sin(num7) * radius * num5,
          y = radius * Math.Sin(num7) - Math.Cos(num7) * radius * num5
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = radius * Math.Cos(num7),
          y = radius * Math.Sin(num7)
        });
      }
      if (extrusion.z < 0.0)
        point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x => x.x = -x.x));
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x => x.Add(center)));
      this.contentText.AppendLine(point2DList[0].x.ToString("f") + " " + (centerY + radius * Math.Sin(startAngle)).ToString("f") + " m ");
      for (int index = 0; index < point2DList.Count / 4; ++index)
      {
        this.contentText.Append(string.Format("{0:f} {1:f} {2:f} {3:f} {4:f} {5:f}", (object) point2DList[index * 4 + 1].x, (object) point2DList[index * 4 + 1].y, (object) point2DList[index * 4 + 2].x, (object) point2DList[index * 4 + 2].y, (object) point2DList[index * 4 + 3].x, (object) point2DList[index * 4 + 3].y));
        this.contentText.Append(" c" + Environment.NewLine);
      }
      this.contentText.AppendLine(" S ");
    }

    private void addLineWeightSetting(int colorIndex, int lineweight)
    {
      Color autoCadColor = this.AutoCadColors[colorIndex];
      this.contentText.AppendLine(((double) autoCadColor.R / (double) byte.MaxValue).ToString() + " " + ((double) autoCadColor.G / (double) byte.MaxValue).ToString() + " " + ((double) autoCadColor.B / (double) byte.MaxValue).ToString() + " RG");
      if (lineweight == -3)
        lineweight = 25;
      this.contentText.AppendLine(((double) lineweight / 1000.0 * 72.0 / 2.54).ToString("f") + " w");
      this.contentText.Append("[] 0 d" + Environment.NewLine);
    }

    public void AddArc(
      double centerX,
      double centerY,
      double radius,
      double startAngle,
      double EndAngle,
      Point3D extrusion)
    {
      this.arcContext(centerX, centerY, radius, startAngle, EndAngle, extrusion);
    }

    public void AddContentText(string str)
    {
      this.contentText.Append(str);
    }

    private void addCircleContext(double centerX, double centerY, double radius)
    {
      centerX *= this.scale;
      centerY *= this.scale;
      radius *= this.scale;
      this.contentText.Append((centerX - radius).ToString("f") + " " + centerY.ToString("f") + " m" + Environment.NewLine);
      this.contentText.Append((centerX - radius).ToString("f") + " " + (centerY + radius * 0.55228).ToString("f") + " " + (centerX - radius * 0.55228).ToString("f") + " " + (centerY + radius).ToString("f") + " " + centerX.ToString("f") + " " + (centerY + radius).ToString("f") + " c" + Environment.NewLine);
      this.contentText.Append((centerX + radius * 0.55228).ToString("f") + " " + (centerY + radius).ToString("f") + " " + (centerX + radius).ToString("f") + " " + (centerY + radius * 0.55228).ToString("f") + " " + (centerX + radius).ToString("f") + " " + centerY.ToString("f") + " c" + Environment.NewLine);
      this.contentText.Append((centerX + radius).ToString("f") + " " + (centerY - radius * 0.55228).ToString("f") + " " + (centerX + radius * 0.55228).ToString("f") + " " + (centerY - radius).ToString("f") + " " + centerX.ToString("f") + " " + (centerY - radius).ToString("f") + " c" + Environment.NewLine);
      this.contentText.Append((centerX - radius * 0.55228).ToString("f") + " " + (centerY - radius).ToString("f") + " " + (centerX - radius).ToString("f") + " " + (centerY - radius * 0.55228).ToString("f") + " " + (centerX - radius).ToString("f") + " " + centerY.ToString("f") + " c S" + Environment.NewLine);
    }

    public void AddCircleWithLineweight(
      double centerX,
      double centerY,
      double radius,
      int colorindex,
      int lineweight)
    {
      this.addLineWeightSetting(colorindex, lineweight);
      this.addCircleContext(centerX, centerY, radius);
    }

    public void AddCircle(
      double centerX,
      double centerY,
      double radius,
      int colorIdx = 0,
      int widthidx = 0,
      int lineType = 0)
    {
      this.addCircleContext(centerX, centerY, radius);
    }

    public void refleshText()
    {
      this.contents.Val = this.header + this.contentText?.ToString() + this.footer;
    }

    internal void AddEllipse(
      Point3D Center,
      Point3D sMAxisVec,
      double axisRatio,
      double begAngle,
      double endAngle,
      Point3D extrusion)
    {
      if (begAngle == endAngle)
        endAngle = 6.28318529717959;
      else if (endAngle < begAngle)
        throw new FormatException();
      dqgToPdf.Dwg.Point2D point2D1 = new dqgToPdf.Dwg.Point2D()
      {
        x = Center.x,
        y = Center.y
      } * this.scale;
      dqgToPdf.Dwg.Point2D point2D2 = new dqgToPdf.Dwg.Point2D()
      {
        x = sMAxisVec.x,
        y = sMAxisVec.y
      } * this.scale;
      double a = point2D2.Length();
      double b = a * axisRatio;
      double num1 = endAngle - begAngle;
      int num2 = (int) Math.Floor(Math.Abs(num1) / (Math.PI / 2.0)) + 1;
      double num3 = num1 / (double) num2;
      double num4 = 4.0 / 3.0 * Math.Tan(Math.Abs(num3) / 4.0);
      List<dqgToPdf.Dwg.Point2D> point2DList = new List<dqgToPdf.Dwg.Point2D>();
      for (int index = 0; index < num2; ++index)
      {
        double num5 = begAngle + (double) index * num3;
        double num6 = begAngle + (double) (index + 1) * num3;
        dqgToPdf.Dwg.Point2D point2D3 = new dqgToPdf.Dwg.Point2D()
        {
          x = Math.Cos(num5),
          y = Math.Sin(num5)
        };
        dqgToPdf.Dwg.Point2D point2D4 = new dqgToPdf.Dwg.Point2D()
        {
          x = Math.Cos(num6),
          y = Math.Sin(num6)
        };
        double num7 = num5 + Math.PI / 2.0;
        double num8 = num6 - Math.PI / 2.0;
        dqgToPdf.Dwg.Point2D point2D5 = point2D3 + new dqgToPdf.Dwg.Point2D()
        {
          x = Math.Cos(num7),
          y = Math.Sin(num7)
        } * num4;
        dqgToPdf.Dwg.Point2D point2D6 = point2D4 + new dqgToPdf.Dwg.Point2D()
        {
          x = Math.Cos(num8),
          y = Math.Sin(num8)
        } * num4;
        point2DList.Add(point2D3);
        point2DList.Add(point2D5);
        point2DList.Add(point2D6);
        point2DList.Add(point2D4);
      }
      dqgToPdf.Dwg.Point2D longAxisNormal = point2D2.Clone();
      longAxisNormal.Normlize();
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x =>
      {
        dqgToPdf.Dwg.Point2D point2D3 = x;
        dqgToPdf.Dwg.Point2D direction = new dqgToPdf.Dwg.Point2D();
        direction.x = 1.0;
        direction.y = 0.0;
        double scaleRate = a;
        point2D3.Scale(direction, scaleRate);
      }));
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x =>
      {
        dqgToPdf.Dwg.Point2D point2D3 = x;
        dqgToPdf.Dwg.Point2D direction = new dqgToPdf.Dwg.Point2D();
        direction.x = 0.0;
        direction.y = 1.0;
        double scaleRate = b;
        point2D3.Scale(direction, scaleRate);
      }));
      if (extrusion.z < 0.0)
        point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x => x.y = -x.y));
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x => x.Rotate(longAxisNormal)));
      for (int index = 0; index < point2DList.Count; ++index)
        point2DList[index] += point2D1;
      StringBuilder contentText1 = this.contentText;
      double num9 = point2DList[0].x;
      string str1 = num9.ToString("f");
      num9 = point2DList[0].y;
      string str2 = num9.ToString("f");
      string str3 = str1 + " " + str2 + " m ";
      contentText1.AppendLine(str3);
      for (int index = 0; index < point2DList.Count / 4; ++index)
      {
        StringBuilder contentText2 = this.contentText;
        string[] strArray = new string[13];
        num9 = point2DList[index * 4 + 1].x;
        strArray[0] = num9.ToString("f");
        strArray[1] = " ";
        num9 = point2DList[index * 4 + 1].y;
        strArray[2] = num9.ToString("f");
        strArray[3] = " ";
        num9 = point2DList[index * 4 + 2].x;
        strArray[4] = num9.ToString("f");
        strArray[5] = " ";
        num9 = point2DList[index * 4 + 2].y;
        strArray[6] = num9.ToString("f");
        strArray[7] = " ";
        num9 = point2DList[index * 4 + 3].x;
        strArray[8] = num9.ToString("f");
        strArray[9] = " ";
        num9 = point2DList[index * 4 + 3].y;
        strArray[10] = num9.ToString("f");
        strArray[11] = " c ";
        strArray[12] = Environment.NewLine;
        string str4 = string.Concat(strArray);
        contentText2.Append(str4);
      }
      this.contentText.Append(" S" + Environment.NewLine);
    }

    internal void AddFitSpline(Point3D begTanVec, Point3D endTanVec, List<Point3D> fitPts)
    {
      dqgToPdf.Dwg.Point2D point2d1 = begTanVec.ToPoint2d();
      dqgToPdf.Dwg.Point2D point2d2 = begTanVec.ToPoint2d();
      List<dqgToPdf.Dwg.Point2D> point2DList1 = new List<dqgToPdf.Dwg.Point2D>();
      point2DList1.Add(point2d1.Clone().Normlize());
      for (int index = 1; index < fitPts.Count - 1; ++index)
        point2DList1.Add((fitPts[index + 1] - fitPts[index - 1]).ToPoint2d().Normlize());
      point2DList1.Add(point2d2.Clone().Normlize());
      List<dqgToPdf.Dwg.Point2D> point2DList2 = new List<dqgToPdf.Dwg.Point2D>();
      for (int index = 0; index < fitPts.Count - 1; ++index)
      {
        dqgToPdf.Dwg.Point2D point2d3 = fitPts[index].ToPoint2d();
        dqgToPdf.Dwg.Point2D point2d4 = fitPts[index + 1].ToPoint2d();
        dqgToPdf.Dwg.Point2D point2D1 = point2d4 - point2d3;
        dqgToPdf.Dwg.Point2D rhs = point2D1.Clone().Normlize();
        dqgToPdf.Dwg.Point2D point2D2 = point2d3 + point2D1.Length() / 3.0 * point2DList1[index] * point2DList1[index].Dot(rhs);
        dqgToPdf.Dwg.Point2D point2D3 = point2d4 - point2D1.Length() / 3.0 * point2DList1[index + 1] * point2DList1[index + 1].Dot(rhs);
        point2DList2.Add(point2d3);
        point2DList2.Add(point2D2);
        point2DList2.Add(point2D3);
        point2DList2.Add(point2d4);
      }
      this.contentText.AppendLine((point2DList2[0].x * this.scale).ToString("f") + " " + (point2DList2[0].y * this.scale).ToString("f") + " m ");
      for (int index = 0; index < point2DList2.Count / 4; ++index)
      {
        StringBuilder contentText = this.contentText;
        string[] strArray = new string[13];
        double num = point2DList2[index * 4 + 1].x * this.scale;
        strArray[0] = num.ToString("f");
        strArray[1] = " ";
        num = point2DList2[index * 4 + 1].y * this.scale;
        strArray[2] = num.ToString("f");
        strArray[3] = " ";
        num = point2DList2[index * 4 + 2].x * this.scale;
        strArray[4] = num.ToString("f");
        strArray[5] = " ";
        num = point2DList2[index * 4 + 2].y * this.scale;
        strArray[6] = num.ToString("f");
        strArray[7] = " ";
        num = point2DList2[index * 4 + 3].x * this.scale;
        strArray[8] = num.ToString("f");
        strArray[9] = " ";
        num = point2DList2[index * 4 + 3].y * this.scale;
        strArray[10] = num.ToString("f");
        strArray[11] = " c ";
        strArray[12] = Environment.NewLine;
        string str = string.Concat(strArray);
        contentText.Append(str);
      }
      this.contentText.Append(" S" + Environment.NewLine);
    }

    internal void AddPolyLine(dqgToPdf.Dwg.Point2D pt0, List<dqgToPdf.Dwg.Point2D> xYs)
    {
      StringBuilder contentText = this.contentText;
      double num = pt0.x * this.scale;
      string str1 = num.ToString("f");
      num = pt0.y * this.scale;
      string str2 = num.ToString("f");
      string str3 = str1 + " " + str2 + " m ";
      contentText.AppendLine(str3);
      dqgToPdf.Dwg.Point2D point2D1 = pt0.Clone();
      foreach (dqgToPdf.Dwg.Point2D xY in xYs)
      {
        dqgToPdf.Dwg.Point2D point2D2 = point2D1 + xY;
        this.contentText.AppendLine((xY.x * this.scale).ToString("f") + " " + (xY.y * this.scale).ToString("f") + " l ");
      }
      this.contentText.Append(" S" + Environment.NewLine);
    }

    internal void AddPolyLine(List<dqgToPdf.Dwg.Point2D> xYs)
    {
      StringBuilder contentText1 = this.contentText;
      double num1 = xYs[0].x * this.scale;
      string str1 = num1.ToString("f");
      num1 = xYs[0].y * this.scale;
      string str2 = num1.ToString("f");
      string str3 = str1 + " " + str2 + " m ";
      contentText1.AppendLine(str3);
      for (int index = 1; index < xYs.Count; ++index)
      {
        StringBuilder contentText2 = this.contentText;
        double num2 = xYs[index].x * this.scale;
        string str4 = num2.ToString("f");
        num2 = xYs[index].y * this.scale;
        string str5 = num2.ToString("f");
        string str6 = str4 + " " + str5 + " l ";
        contentText2.AppendLine(str6);
      }
      this.contentText.Append(" S" + Environment.NewLine);
    }

    public void StartStroke(dqgToPdf.Dwg.Point2D pt0)
    {
      StringBuilder contentText = this.contentText;
      double num = pt0.x * this.scale;
      string str1 = num.ToString("f");
      num = pt0.y * this.scale;
      string str2 = num.ToString("f");
      string str3 = str1 + " " + str2 + " m ";
      contentText.AppendLine(str3);
    }

    public void CloseSubpath()
    {
      this.contentText.Append(" h" + Environment.NewLine);
    }

    public void EndStroke()
    {
      this.contentText.Append(" S" + Environment.NewLine);
    }

    public void EndStroke(bool isFill)
    {
      if (isFill)
        this.contentText.Append(" f*" + Environment.NewLine);
      else
        this.contentText.Append(" S" + Environment.NewLine);
    }

    public void EndFillStroke()
    {
      this.contentText.Append(" f" + Environment.NewLine);
    }

    public void StrokeLine(dqgToPdf.Dwg.Point2D p)
    {
      StringBuilder contentText = this.contentText;
      double num = p.x * this.scale;
      string str1 = num.ToString("f");
      num = p.y * this.scale;
      string str2 = num.ToString("f");
      string str3 = str1 + " " + str2 + " l ";
      contentText.AppendLine(str3);
    }

    public void StrokeLine(dqgToPdf.Dwg.Point2D p, ref bool IsStroking)
    {
      if (IsStroking)
      {
        this.StrokeLine(p);
      }
      else
      {
        this.StartStroke(p);
        IsStroking = true;
      }
    }

    public void StrokeElliticalArc(
      dqgToPdf.Dwg.Point2D Center,
      dqgToPdf.Dwg.Point2D SMAxisVec,
      double axisRatio,
      double begAngle,
      double endAngle,
      bool isCcw,
      ref bool isStroking)
    {
      Center *= this.scale;
      double a = SMAxisVec.Length();
      double b = a * axisRatio;
      a *= this.scale;
      b *= this.scale;
      if (a < 1E-05)
        return;
      begAngle %= 2.0 * Math.PI;
      endAngle %= 2.0 * Math.PI;
      double num1 = endAngle - begAngle;
      if (num1 < 0.0)
        num1 += 2.0 * Math.PI;
      if (!isCcw)
        num1 = -num1;
      if (Math.Abs(num1) > 2.0 * Math.PI)
        throw new Exception();
      int num2 = (int) Math.Floor(Math.Abs(num1) / (Math.PI / 2.0)) + 1;
      double num3 = num1 / (double) num2;
      double num4 = 4.0 / 3.0 * Math.Tan(num3 / 4.0);
      List<dqgToPdf.Dwg.Point2D> point2DList = new List<dqgToPdf.Dwg.Point2D>();
      for (int index = 0; index < num2; ++index)
      {
        double num5 = (double) index * num3;
        double num6 = (double) (index + 1) * num3;
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = Math.Cos(num5),
          y = Math.Sin(num5)
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = Math.Cos(num5) - Math.Sin(num5) * num4,
          y = Math.Sin(num5) + Math.Cos(num5) * num4
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = Math.Cos(num6) + Math.Sin(num6) * num4,
          y = Math.Sin(num6) - Math.Cos(num6) * num4
        });
        point2DList.Add(new dqgToPdf.Dwg.Point2D()
        {
          x = Math.Cos(num6),
          y = Math.Sin(num6)
        });
      }
      if (!isCcw)
        point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x => x.y = -x.y));
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x =>
      {
        dqgToPdf.Dwg.Point2D point2D = x;
        dqgToPdf.Dwg.Point2D direction = new dqgToPdf.Dwg.Point2D();
        direction.x = 1.0;
        direction.y = 0.0;
        double scaleRate = a;
        point2D.Scale(direction, scaleRate);
      }));
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x =>
      {
        dqgToPdf.Dwg.Point2D point2D = x;
        dqgToPdf.Dwg.Point2D direction = new dqgToPdf.Dwg.Point2D();
        direction.x = 0.0;
        direction.y = 1.0;
        double scaleRate = b;
        point2D.Scale(direction, scaleRate);
      }));
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x => x.Rotate(SMAxisVec.Clone().Normlize())));
      point2DList.ForEach((Action<dqgToPdf.Dwg.Point2D>) (x => x.Add(Center)));
      if (!isStroking)
      {
        this.contentText.AppendLine(string.Format("{0:f} {1:f} m ", (object) point2DList[0].x, (object) point2DList[0].y));
        isStroking = true;
      }
      for (int index = 0; index < point2DList.Count / 4; ++index)
      {
        this.contentText.Append(string.Format("{0:f} {1:f} {2:f} {3:f} {4:f} {5:f}", (object) point2DList[index * 4 + 1].x, (object) point2DList[index * 4 + 1].y, (object) point2DList[index * 4 + 2].x, (object) point2DList[index * 4 + 2].y, (object) point2DList[index * 4 + 3].x, (object) point2DList[index * 4 + 3].y));
        this.contentText.Append(" c" + Environment.NewLine);
      }
    }
  }
}
