using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace picPack {

  internal class Program {

    private enum bColor {
      bBlack = 0x00,
      bRed,
      bGreen,
      bWhite
    }

    private static byte cv8bppTo2bpp(byte b, int pos) {
      byte retB = 0x00;
      switch (b % 8) {
        case 0x00: retB = (byte)bColor.bBlack; break;
        case 0x01: retB = (byte)bColor.bGreen; break;
        case 0x02: retB = (byte)bColor.bRed; break;
        case 0x07: retB = (byte)bColor.bWhite; break;
        default:
          break;
      }

      return (byte)(retB << pos * 2);
    }

    private static void Main(string[] args) {
      const string fPrefix = "screen";
      for (int fileN = 0; fileN < 10; fileN++) {
        Bitmap bmp = new Bitmap(fPrefix + fileN.ToString() + "_.bmp");

        // Считаем, что PixelFormat 8 бит/пиксель
        int bmp8bppL = bmp.Size.Width * bmp.Size.Height;
        byte[] bbBmp8bpp = new byte[bmp8bppL];

        BitmapData bmpData = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), ImageLockMode.ReadOnly, bmp.PixelFormat);
        Marshal.Copy(bmpData.Scan0, bbBmp8bpp, 0, bmp8bppL);
        bmp.UnlockBits(bmpData);

        // Преобразовать 8 бит/пиксель в 2 бит/пиксель
        int bmp2bppL = bmp8bppL / 4;
        byte[] bbBmp2bpp = new byte[bmp2bppL];
        for (int i = 0; i < bmp2bppL; i++) for (int j = 3; j >= 0; j--)
            bbBmp2bpp[i] += cv8bppTo2bpp(bbBmp8bpp[i * 4 + 3 - j], j);
        //File.WriteAllBytes(fPrefix + fileN.ToString() + ".b8", bbBmp8bpp.ToArray());
        //File.WriteAllBytes(fPrefix + fileN.ToString() + ".b2", bbBmp2bpp.ToArray());

        // Транспонировать матрицу
        byte[] bbBmp2bppT = new byte[bmp2bppL];
        const int bmpW = 80;
        const int bmpH = 200;
        for (int x = 0; x < bmpH; x++) for (int y = 0; y < bmpW; y++)
            bbBmp2bppT[x + y * bmpH] = bbBmp2bpp[y + x * bmpW];
        //File.WriteAllBytes(fPrefix + fileN.ToString() + ".b2T", bbBmp2bppT.ToArray());

        // Сжать картинку
        List<byte> resBuf = new List<byte>();
        resBuf.Add(0x00);
        resBuf.Add(0x00);

        byte lastByte = 0x00;
        byte byteCnt = 0x00;

        for (int i = 0; i < bmp2bppL; i++) {
          if (i > 0) {
            if (bbBmp2bppT[i] == lastByte) byteCnt++;
            else {
              if (byteCnt > 2) {
                resBuf.Add(0x7B);
                resBuf.Add(byteCnt);
                resBuf.Add(lastByte);
                //lastByte = bbBmp2bppT[i];
                byteCnt = 0x00;
              } else if (lastByte == 0x7B) {
                resBuf.Add(0x7B);
                resBuf.Add(byteCnt);
                resBuf.Add(lastByte);
                byteCnt = 0x00;
              } else {
                resBuf.Add(lastByte);
                for (int j = 0; j < byteCnt; j++) resBuf.Add(lastByte);
                byteCnt = 0x00;
              }
            }
          }
          lastByte = bbBmp2bppT[i];
        }

        if (byteCnt > 2) {
          resBuf.Add(0x7B);
          resBuf.Add(byteCnt);
          resBuf.Add(lastByte);
          //lastByte = bbBmp2bppT[i];
          byteCnt = 0x00;
        } else if (lastByte == 0x7B) {
          resBuf.Add(0x7B);
          resBuf.Add(byteCnt);
          resBuf.Add(lastByte);
          byteCnt = 0x00;
        } else {
          resBuf.Add(lastByte);
          for (int j = 0; j < byteCnt; j++) resBuf.Add(lastByte);
          byteCnt = 0x00;
        }

        resBuf[0] = (byte)(resBuf.Capacity % 0x100);
        resBuf[1] = (byte)(resBuf.Capacity / 0x100);

        // Сохранить
        File.WriteAllBytes(fPrefix + fileN.ToString(), resBuf.ToArray());
      }
    }
  }
}