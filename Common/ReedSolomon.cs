// Decompiled with JetBrains decompiler
// Type: dqgToPdf.Common.ReedSolomon
// Assembly: dqgToPdf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62F9A02F-9825-49FD-9C39-99200611E8E8
// Assembly location: Z:\0_TRUNG\ToDHF20200809\PDFJump\PDFJump200808\dqgToPdf.dll

using System;

namespace dqgToPdf.Common
{
  public static class ReedSolomon
  {
    private static int mm = 4;
    private static int nn = 15;
    private static int tt = 3;
    private static int kk = 9;
    private static int[] pp = new int[5]{ 1, 1, 0, 0, 1 };
    private static int[] alpha_to = new int[ReedSolomon.nn + 1];
    private static int[] index_of = new int[ReedSolomon.nn + 1];
    private static int[] gg = new int[ReedSolomon.nn - ReedSolomon.kk + 1];
    public static int[] recd = new int[ReedSolomon.nn];
    public static int[] data = new int[ReedSolomon.kk];
    public static int[] bb = new int[ReedSolomon.nn - ReedSolomon.kk];

    public static void generate_gf()
    {
      int num1 = 1;
      ReedSolomon.alpha_to[ReedSolomon.mm] = 0;
      for (int index = 0; index < ReedSolomon.mm; ++index)
      {
        ReedSolomon.alpha_to[index] = num1;
        ReedSolomon.index_of[ReedSolomon.alpha_to[index]] = index;
        if (ReedSolomon.pp[index] != 0)
          ReedSolomon.alpha_to[ReedSolomon.mm] ^= num1;
        num1 <<= 1;
      }
      ReedSolomon.index_of[ReedSolomon.alpha_to[ReedSolomon.mm]] = ReedSolomon.mm;
      int num2 = num1 >> 1;
      for (int index = ReedSolomon.mm + 1; index < ReedSolomon.nn; ++index)
      {
        ReedSolomon.alpha_to[index] = ReedSolomon.alpha_to[index - 1] < num2 ? ReedSolomon.alpha_to[index - 1] << 1 : ReedSolomon.alpha_to[ReedSolomon.mm] ^ (ReedSolomon.alpha_to[index - 1] ^ num2) << 1;
        ReedSolomon.index_of[ReedSolomon.alpha_to[index]] = index;
      }
      ReedSolomon.index_of[0] = -1;
    }

    public static void gen_poly()
    {
      ReedSolomon.gg[0] = 2;
      ReedSolomon.gg[1] = 1;
      for (int index1 = 2; index1 <= ReedSolomon.nn - ReedSolomon.kk; ++index1)
      {
        ReedSolomon.gg[index1] = 1;
        for (int index2 = index1 - 1; index2 > 0; --index2)
          ReedSolomon.gg[index2] = ReedSolomon.gg[index2] == 0 ? ReedSolomon.gg[index2 - 1] : ReedSolomon.gg[index2 - 1] ^ ReedSolomon.alpha_to[(ReedSolomon.index_of[ReedSolomon.gg[index2]] + index1) % ReedSolomon.nn];
        ReedSolomon.gg[0] = ReedSolomon.alpha_to[(ReedSolomon.index_of[ReedSolomon.gg[0]] + index1) % ReedSolomon.nn];
      }
      for (int index = 0; index <= ReedSolomon.nn - ReedSolomon.kk; ++index)
        ReedSolomon.gg[index] = ReedSolomon.index_of[ReedSolomon.gg[index]];
    }

    public static void encode_rs()
    {
      for (int index = 0; index < ReedSolomon.nn - ReedSolomon.kk; ++index)
        ReedSolomon.bb[index] = 0;
      for (int index1 = ReedSolomon.kk - 1; index1 >= 0; --index1)
      {
        int num = ReedSolomon.index_of[ReedSolomon.data[index1] ^ ReedSolomon.bb[ReedSolomon.nn - ReedSolomon.kk - 1]];
        if (num != -1)
        {
          for (int index2 = ReedSolomon.nn - ReedSolomon.kk - 1; index2 > 0; --index2)
            ReedSolomon.bb[index2] = ReedSolomon.gg[index2] == -1 ? ReedSolomon.bb[index2 - 1] : ReedSolomon.bb[index2 - 1] ^ ReedSolomon.alpha_to[(ReedSolomon.gg[index2] + num) % ReedSolomon.nn];
          ReedSolomon.bb[0] = ReedSolomon.alpha_to[(ReedSolomon.gg[0] + num) % ReedSolomon.nn];
        }
        else
        {
          for (int index2 = ReedSolomon.nn - ReedSolomon.kk - 1; index2 > 0; --index2)
            ReedSolomon.bb[index2] = ReedSolomon.bb[index2 - 1];
          ReedSolomon.bb[0] = 0;
        }
      }
    }

    public static byte[] Decode(byte[] encodedbyte, int n, int k, int m, int t, int[] p)
    {
      ReedSolomon.nn = n;
      ReedSolomon.kk = k;
      ReedSolomon.mm = m;
      ReedSolomon.tt = t;
      ReedSolomon.pp = p;
      ReedSolomon.alpha_to = new int[ReedSolomon.nn + 1];
      ReedSolomon.index_of = new int[ReedSolomon.nn + 1];
      ReedSolomon.gg = new int[ReedSolomon.nn - ReedSolomon.kk + 1];
      ReedSolomon.recd = new int[ReedSolomon.nn];
      ReedSolomon.data = new int[ReedSolomon.kk];
      ReedSolomon.bb = new int[ReedSolomon.nn - ReedSolomon.kk];
      ReedSolomon.generate_gf();
      Console.Write("Look-up tables for GF(2**%2d)\n", (object) ReedSolomon.mm);
      Console.Write("  i   alpha_to[i]  index_of[i]\n");
      for (int index = 0; index <= ReedSolomon.nn; ++index)
        Console.Write(string.Format("{0:d3}      {1:d3}          {2:d3}\n", (object) index, (object) ReedSolomon.alpha_to[index], (object) ReedSolomon.index_of[index]));
      Console.Write("\n\n");
      ReedSolomon.gen_poly();
      ReedSolomon.data = Array.ConvertAll<byte, int>(encodedbyte, (Converter<byte, int>) (s => (int) s));
      ReedSolomon.encode_rs();
      for (int index = 0; index < ReedSolomon.nn - ReedSolomon.kk; ++index)
        ReedSolomon.recd[index] = ReedSolomon.bb[index];
      for (int index = 0; index < ReedSolomon.kk; ++index)
        ReedSolomon.recd[index + ReedSolomon.nn - ReedSolomon.kk] = ReedSolomon.data[index];
      for (int index = 0; index < ReedSolomon.nn; ++index)
        ReedSolomon.recd[index] = ReedSolomon.index_of[ReedSolomon.recd[index]];
      ReedSolomon.decode_rs();
      Console.Write("Results for Reed-Solomon code (n={0}, k={1}, t= {2})\n\n", (object) ReedSolomon.nn, (object) ReedSolomon.kk, (object) ReedSolomon.tt);
      Console.Write("  i  data[i]   recd[i](decoded)   (data, recd in polynomial form)\n");
      for (int index = 0; index < ReedSolomon.nn - ReedSolomon.kk; ++index)
        Console.Write(string.Format("{0:d3}    {1:d3}      {2:d3}\n", (object) index, (object) ReedSolomon.bb[index], (object) ReedSolomon.recd[index]));
      for (int index = ReedSolomon.nn - ReedSolomon.kk; index < ReedSolomon.nn; ++index)
        Console.Write(string.Format("{0:d3}    {1:d3}      {2:d3}\n", (object) index, (object) ReedSolomon.data[index - ReedSolomon.nn + ReedSolomon.kk], (object) ReedSolomon.recd[index]));
      return Array.ConvertAll<int, byte>(ReedSolomon.data, (Converter<int, byte>) (s => (byte) s));
    }

    public static void decode_rs()
    {
      int[,] numArray1 = new int[ReedSolomon.nn - ReedSolomon.kk + 2, ReedSolomon.nn - ReedSolomon.kk];
      int[] numArray2 = new int[ReedSolomon.nn - ReedSolomon.kk + 2];
      int[] numArray3 = new int[ReedSolomon.nn - ReedSolomon.kk + 2];
      int[] numArray4 = new int[ReedSolomon.nn - ReedSolomon.kk + 2];
      int[] numArray5 = new int[ReedSolomon.nn - ReedSolomon.kk + 1];
      int num1 = 0;
      int[] numArray6 = new int[ReedSolomon.tt];
      int[] numArray7 = new int[ReedSolomon.tt];
      int[] numArray8 = new int[ReedSolomon.tt + 1];
      int[] numArray9 = new int[ReedSolomon.nn];
      int[] numArray10 = new int[ReedSolomon.tt + 1];
      for (int index1 = 1; index1 <= ReedSolomon.nn - ReedSolomon.kk; ++index1)
      {
        numArray5[index1] = 0;
        for (int index2 = 0; index2 < ReedSolomon.nn; ++index2)
        {
          if (ReedSolomon.recd[index2] != -1)
            numArray5[index1] ^= ReedSolomon.alpha_to[(ReedSolomon.recd[index2] + index1 * index2) % ReedSolomon.nn];
        }
        if (numArray5[index1] != 0)
          num1 = 1;
        numArray5[index1] = ReedSolomon.index_of[numArray5[index1]];
      }
      if (num1 != 0)
      {
        numArray2[0] = 0;
        numArray2[1] = numArray5[1];
        numArray1[0, 0] = 0;
        numArray1[1, 0] = 1;
        for (int index = 1; index < ReedSolomon.nn - ReedSolomon.kk; ++index)
        {
          numArray1[0, index] = -1;
          numArray1[1, index] = 0;
        }
        numArray3[0] = 0;
        numArray3[1] = 0;
        numArray4[0] = -1;
        numArray4[1] = 0;
        int index1 = 0;
        do
        {
          ++index1;
          if (numArray2[index1] == -1)
          {
            numArray3[index1 + 1] = numArray3[index1];
            for (int index2 = 0; index2 <= numArray3[index1]; ++index2)
            {
              numArray1[index1 + 1, index2] = numArray1[index1, index2];
              numArray1[index1, index2] = ReedSolomon.index_of[numArray1[index1, index2]];
            }
          }
          else
          {
            int index2 = index1 - 1;
            while (numArray2[index2] == -1 && index2 > 0)
              --index2;
            if (index2 > 0)
            {
              int index3 = index2;
              do
              {
                --index3;
                if (numArray2[index3] != -1 && numArray4[index2] < numArray4[index3])
                  index2 = index3;
              }
              while (index3 > 0);
            }
            numArray3[index1 + 1] = numArray3[index1] <= numArray3[index2] + index1 - index2 ? numArray3[index2] + index1 - index2 : numArray3[index1];
            for (int index3 = 0; index3 < ReedSolomon.nn - ReedSolomon.kk; ++index3)
              numArray1[index1 + 1, index3] = 0;
            for (int index3 = 0; index3 <= numArray3[index2]; ++index3)
            {
              if (numArray1[index2, index3] != -1)
                numArray1[index1 + 1, index3 + index1 - index2] = ReedSolomon.alpha_to[(numArray2[index1] + ReedSolomon.nn - numArray2[index2] + numArray1[index2, index3]) % ReedSolomon.nn];
            }
            for (int index3 = 0; index3 <= numArray3[index1]; ++index3)
            {
              numArray1[index1 + 1, index3] ^= numArray1[index1, index3];
              numArray1[index1, index3] = ReedSolomon.index_of[numArray1[index1, index3]];
            }
          }
          numArray4[index1 + 1] = index1 - numArray3[index1 + 1];
          if (index1 < ReedSolomon.nn - ReedSolomon.kk)
          {
            numArray2[index1 + 1] = numArray5[index1 + 1] == -1 ? 0 : ReedSolomon.alpha_to[numArray5[index1 + 1]];
            for (int index2 = 1; index2 <= numArray3[index1 + 1]; ++index2)
            {
              if (numArray5[index1 + 1 - index2] != -1 && numArray1[index1 + 1, index2] != 0)
                numArray2[index1 + 1] ^= ReedSolomon.alpha_to[(numArray5[index1 + 1 - index2] + ReedSolomon.index_of[numArray1[index1 + 1, index2]]) % ReedSolomon.nn];
            }
            numArray2[index1 + 1] = ReedSolomon.index_of[numArray2[index1 + 1]];
          }
        }
        while (index1 < ReedSolomon.nn - ReedSolomon.kk && numArray3[index1 + 1] <= ReedSolomon.tt);
        int index4 = index1 + 1;
        if (numArray3[index4] <= ReedSolomon.tt)
        {
          for (int index2 = 0; index2 <= numArray3[index4]; ++index2)
            numArray1[index4, index2] = ReedSolomon.index_of[numArray1[index4, index2]];
          for (int index2 = 1; index2 <= numArray3[index4]; ++index2)
            numArray10[index2] = numArray1[index4, index2];
          int index3 = 0;
          for (int index2 = 1; index2 <= ReedSolomon.nn; ++index2)
          {
            int num2 = 1;
            for (int index5 = 1; index5 <= numArray3[index4]; ++index5)
            {
              if (numArray10[index5] != -1)
              {
                numArray10[index5] = (numArray10[index5] + index5) % ReedSolomon.nn;
                num2 ^= ReedSolomon.alpha_to[numArray10[index5]];
              }
            }
            if (num2 == 0)
            {
              numArray6[index3] = index2;
              numArray7[index3] = ReedSolomon.nn - index2;
              ++index3;
            }
          }
          if (index3 == numArray3[index4])
          {
            for (int index2 = 1; index2 <= numArray3[index4]; ++index2)
            {
              numArray8[index2] = numArray5[index2] == -1 || numArray1[index4, index2] == -1 ? (numArray5[index2] == -1 || numArray1[index4, index2] != -1 ? (numArray5[index2] != -1 || numArray1[index4, index2] == -1 ? 0 : ReedSolomon.alpha_to[numArray1[index4, index2]]) : ReedSolomon.alpha_to[numArray5[index2]]) : ReedSolomon.alpha_to[numArray5[index2]] ^ ReedSolomon.alpha_to[numArray1[index4, index2]];
              for (int index5 = 1; index5 < index2; ++index5)
              {
                if (numArray5[index5] != -1 && numArray1[index4, index2 - index5] != -1)
                  numArray8[index2] ^= ReedSolomon.alpha_to[(numArray1[index4, index2 - index5] + numArray5[index5]) % ReedSolomon.nn];
              }
              numArray8[index2] = ReedSolomon.index_of[numArray8[index2]];
            }
            for (int index2 = 0; index2 < ReedSolomon.nn; ++index2)
            {
              numArray9[index2] = 0;
              ReedSolomon.recd[index2] = ReedSolomon.recd[index2] == -1 ? 0 : ReedSolomon.alpha_to[ReedSolomon.recd[index2]];
            }
            for (int index2 = 0; index2 < numArray3[index4]; ++index2)
            {
              numArray9[numArray7[index2]] = 1;
              for (int index5 = 1; index5 <= numArray3[index4]; ++index5)
              {
                if (numArray8[index5] != -1)
                  numArray9[numArray7[index2]] ^= ReedSolomon.alpha_to[(numArray8[index5] + index5 * numArray6[index2]) % ReedSolomon.nn];
              }
              if (numArray9[numArray7[index2]] != 0)
              {
                numArray9[numArray7[index2]] = ReedSolomon.index_of[numArray9[numArray7[index2]]];
                int num2 = 0;
                for (int index5 = 0; index5 < numArray3[index4]; ++index5)
                {
                  if (index5 != index2)
                    num2 += ReedSolomon.index_of[1 ^ ReedSolomon.alpha_to[(numArray7[index5] + numArray6[index2]) % ReedSolomon.nn]];
                }
                int num3 = num2 % ReedSolomon.nn;
                numArray9[numArray7[index2]] = ReedSolomon.alpha_to[(numArray9[numArray7[index2]] - num3 + ReedSolomon.nn) % ReedSolomon.nn];
                ReedSolomon.recd[numArray7[index2]] ^= numArray9[numArray7[index2]];
              }
            }
          }
          else
          {
            for (int index2 = 0; index2 < ReedSolomon.nn; ++index2)
              ReedSolomon.recd[index2] = ReedSolomon.recd[index2] == -1 ? 0 : ReedSolomon.alpha_to[ReedSolomon.recd[index2]];
          }
        }
        else
        {
          for (int index2 = 0; index2 < ReedSolomon.nn; ++index2)
            ReedSolomon.recd[index2] = ReedSolomon.recd[index2] == -1 ? 0 : ReedSolomon.alpha_to[ReedSolomon.recd[index2]];
        }
      }
      else
      {
        for (int index = 0; index < ReedSolomon.nn; ++index)
          ReedSolomon.recd[index] = ReedSolomon.recd[index] == -1 ? 0 : ReedSolomon.alpha_to[ReedSolomon.recd[index]];
      }
    }

    public static void main()
    {
      ReedSolomon.generate_gf();
      Console.Write("Look-up tables for GF(2**%2d)\n", (object) ReedSolomon.mm);
      Console.Write("  i   alpha_to[i]  index_of[i]\n");
      for (int index = 0; index <= ReedSolomon.nn; ++index)
        Console.Write("{0}      {1}          {2}\n", (object) index, (object) ReedSolomon.alpha_to[index], (object) ReedSolomon.index_of[index]);
      Console.Write("\n\n");
      ReedSolomon.gen_poly();
      for (int index = 0; index < ReedSolomon.kk; ++index)
        ReedSolomon.data[index] = 0;
      ReedSolomon.data[0] = 8;
      ReedSolomon.data[1] = 6;
      ReedSolomon.data[2] = 8;
      ReedSolomon.data[3] = 1;
      ReedSolomon.data[4] = 2;
      ReedSolomon.data[5] = 4;
      ReedSolomon.data[6] = 15;
      ReedSolomon.data[7] = 9;
      ReedSolomon.data[8] = 9;
      ReedSolomon.encode_rs();
      for (int index = 0; index < ReedSolomon.nn - ReedSolomon.kk; ++index)
        ReedSolomon.recd[index] = ReedSolomon.bb[index];
      for (int index = 0; index < ReedSolomon.kk; ++index)
        ReedSolomon.recd[index + ReedSolomon.nn - ReedSolomon.kk] = ReedSolomon.data[index];
      ReedSolomon.data[ReedSolomon.nn - ReedSolomon.nn / 2] = 3;
      for (int index = 0; index < ReedSolomon.nn; ++index)
        ReedSolomon.recd[index] = ReedSolomon.index_of[ReedSolomon.recd[index]];
      ReedSolomon.decode_rs();
      Console.Write("Results for Reed-Solomon code (n={0}, k={1}, t= {2})\n\n", (object) ReedSolomon.nn, (object) ReedSolomon.kk, (object) ReedSolomon.tt);
      Console.Write("  i  data[i]   recd[i](decoded)   (data, recd in polynomial form)\n");
      for (int index = 0; index < ReedSolomon.nn - ReedSolomon.kk; ++index)
        Console.Write("{0}    {1}      {2}\n", (object) index, (object) ReedSolomon.bb[index], (object) ReedSolomon.recd[index]);
      for (int index = ReedSolomon.nn - ReedSolomon.kk; index < ReedSolomon.nn; ++index)
        Console.Write("{0}    {1}      {2}\n", (object) index, (object) ReedSolomon.data[index - ReedSolomon.nn + ReedSolomon.kk], (object) ReedSolomon.recd[index]);
    }
  }
}
