// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Dwg.R2007.Decompress
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

namespace dqgToPdf.Dwg.R2007
{
  public class Decompress
  {
    private void ReadInstructions(
      byte[] srcBuf,
      int srcIndex,
      ref byte opCode,
      out uint sourceOffset,
      out uint length)
    {
      switch ((int) opCode >> 4)
      {
        case 0:
          length = (uint) (((int) opCode & 15) + 19);
          sourceOffset = (uint) srcBuf[srcIndex++];
          opCode = srcBuf[srcIndex++];
          length = (uint) ((ulong) ((int) opCode >> 3 & 16) + (ulong) length);
          sourceOffset = (uint) ((ulong) ((((int) opCode & 120) << 5) + 1) + (ulong) sourceOffset);
          break;
        case 1:
          length = (uint) (((int) opCode & 15) + 3);
          sourceOffset = (uint) srcBuf[srcIndex++];
          opCode = srcBuf[srcIndex++];
          sourceOffset = (uint) ((ulong) ((((int) opCode & 248) << 5) + 1) + (ulong) sourceOffset);
          break;
        case 2:
          sourceOffset = (uint) srcBuf[srcIndex++];
          sourceOffset = (uint) ((int) srcBuf[srcIndex++] << 8 & 65280) | sourceOffset;
          length = (uint) opCode & 7U;
          if (((int) opCode & 8) == 0)
          {
            opCode = srcBuf[srcIndex++];
            length = (uint) ((ulong) ((int) opCode & 248) + (ulong) length);
            break;
          }
          ++sourceOffset;
          length = (uint) ((ulong) ((int) srcBuf[srcIndex++] << 3) + (ulong) length);
          opCode = srcBuf[srcIndex++];
          length = (uint) ((ulong) (((int) opCode & 248) << 8) + (ulong) length) + 256U;
          break;
        default:
          length = (uint) opCode >> 4;
          sourceOffset = (uint) opCode & 15U;
          opCode = srcBuf[srcIndex++];
          sourceOffset = (uint) ((ulong) (((int) opCode & 248) << 1) + (ulong) sourceOffset) + 1U;
          break;
      }
    }
  }
}
