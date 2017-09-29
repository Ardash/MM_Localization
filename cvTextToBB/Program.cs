namespace cvTextToBB {
  class Program {
    static byte convertChar(char c) {
      byte retC = (byte)' ';
      c = char.ToUpper(c);
      switch (c) {
        case '\n': retC = 0x0D; break;
        case ' ':
        case '!':
        case '"':
        case '#':
        case '$':
        case '%':
        case '&':
        case '\'':
        case '(':
        case ')':
        case '*':
        case '+':
        case ',':
        case '-':
        case '.':
        case '/':
        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
        case '5':
        case '6':
        case '7':
        case '8':
        case '9':
        case ':':
        case ';':
        case '<':
        case '=':
        case '>':
        case '?':
        case '@':
        case 'A':
        case 'B':
        case 'C':
        case 'D':
        case 'E':
        case 'F':
        case 'G':
        case 'H':
        case 'I':
        case 'J':
        case 'K':
        case 'L':
        case 'M':
        case 'N':
        case 'O':
        case 'P':
        case 'Q':
        case 'R':
        case 'S':
        case 'T':
        case 'U':
        case 'V':
        case 'W':
        case 'X':
        case 'Y':
        case 'Z':
        case '[':
        case '\\':
        case ']':
        case '^':
        case '_': retC = (byte)c; break;
        case 'А': retC = 0x40 + 0x20; break;
        case 'Б': retC = 0x41 + 0x20; break;
        case 'В': retC = 0x42 + 0x20; break;
        case 'Г': retC = 0x43 + 0x20; break;
        case 'Д': retC = 0x44 + 0x20; break;
        case 'Е': retC = 0x45 + 0x20; break;
        case 'Ж': retC = 0x46 + 0x20; break;
        case 'З': retC = 0x47 + 0x20; break;
        case 'И': retC = 0x48 + 0x20; break;
        case 'Й': retC = 0x49 + 0x20; break;
        case 'К': retC = 0x4A + 0x20; break;
        case 'Л': retC = 0x4B + 0x20; break;
        case 'М': retC = 0x4C + 0x20; break;
        case 'Н': retC = 0x4D + 0x20; break;
        case 'О': retC = 0x4E + 0x20; break;
        case 'П': retC = 0x4F + 0x20; break;
        case 'Р': retC = 0x50 + 0x20; break;
        case 'С': retC = 0x51 + 0x20; break;
        case 'Т': retC = 0x52 + 0x20; break;
        case 'У': retC = 0x53 + 0x20; break;
        case 'Ф': retC = 0x54 + 0x20; break;
        case 'Х': retC = 0x55 + 0x20; break;
        case 'Ц': retC = 0x56 + 0x20; break;
        case 'Ч': retC = 0x57 + 0x20; break;
        case 'Ш': retC = 0x58 + 0x20; break;
        case 'Щ': retC = 0x59 + 0x20; break;
        case 'Ъ': retC = 0x5A + 0x20; break;
        case 'Ы': retC = 0x5B + 0x20; break;
        case 'Ь': retC = 0x5C + 0x20; break;
        case 'Э': retC = 0x5D + 0x20; break;
        case 'Ю': retC = 0x5E + 0x20; break;
        case 'Я': retC = 0x5F + 0x20; break;
        default: retC = (byte)' '; break;
      }
      return retC;
    }
    static void Main(string[] args) {
      string text = "Ключ у пса";
      byte[] bb = new byte[300];
      for (int i = 0; i < text.Length; i++)
        bb[i] = convertChar(text[i]);
      bb[text.Length] = 0x00;

      int j = 0;
    }
  }
}
