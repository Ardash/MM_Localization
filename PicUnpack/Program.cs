using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace PicUnpack {

  internal class Program {

    private static ushort BBToShort(byte byteL, byte byteH) {
      return (ushort)((byteH << 8) + byteL);
    }

    private static ushort BBToShort(byte[] bArr, int offset) {
      return BBToShort(bArr[offset], bArr[offset + 1]);
    }

    private static byte getBitPairFromByte(byte inByte, int n) {
      return (byte)((inByte & 0x03 << n * 2) >> n * 2);
    }

    private static byte getColor(byte inByte) {
      const byte red = 0x01;
      const byte green = 0x02;
      const byte black = 0x00;
      const byte white = 0x0F;

      switch (inByte) {
        case 0x00: return black;
        case 0x01: return green;
        case 0x02: return red;
        case 0x03:
        default:
          break;
      }
      return white;
    }

    private static void Main(string[] args) {
      if (args.Length == 0) return;

      for (int i = 0; i < 10; i++) {
        byte[] bb = File.ReadAllBytes(args[0] + i.ToString());
        ushort arrPicL = BBToShort(bb, 0);

        List<byte> bbRes = new List<byte>();
        for (ushort N = 2; N < arrPicL + 2;) {
          if (bb[N] == 0x7B) {
            bb[N + 1]++;
            for (; bb[N + 1] > 0; bb[N + 1]--) bbRes.Add(bb[N + 2]);
            N += 3;
          } else
            bbRes.Add(bb[N++]);
        }
        //File.WriteAllBytes(args[0] + i.ToString() + ".pic", bbRes.ToArray());

        const int imgW = 80;
        const int imgH = 200;

        // Транспонируем матрицу
        byte[] bbResArr = new byte[bbRes.Count];
        for (int x = 0; x < imgW; x++)
          for (int y = 0; y < imgH; y++)
            bbResArr[y * imgW + x] = bbRes[x * imgH + y];
        //File.WriteAllBytes(args[0] + i.ToString() + ".pic2", bbResArr);

        // Преобразуем 2 бита/пиксель в 8 бит/пиксель
        int bbResArrL = bbResArr.Length;

        List<byte> bbBmpList = new List<byte>();
        for (int j = 0; j < bbResArrL; j++)
          for (int k = 3; k >= 0; k--)
            bbBmpList.Add(getColor(getBitPairFromByte(bbResArr[j], k)));

        // Сохраним в bmp
        byte[] bbBmp = bbBmpList.ToArray();
        int bbBmpL = bbBmp.Length;

        Bitmap bmp = new Bitmap(imgW * 4, imgH, PixelFormat.Format8bppIndexed);
        BitmapData bmpData = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), ImageLockMode.ReadWrite, bmp.PixelFormat);
        Marshal.Copy(bbBmp, 0, bmpData.Scan0, bbBmpL);
        bmp.UnlockBits(bmpData);
        bmp.Save(args[0] + i.ToString() + ".bmp", ImageFormat.Bmp);
      }
    }
  }
}