using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;

namespace MM_Localization {
  public class StringToHex4Converter : IValueConverter {

    public object Convert(object value, Type targetType,
                          object parameter, CultureInfo culture) {
      return ((ushort)value).ToString("X4");
    }

    public object ConvertBack(object value, Type targetType,
                              object parameter, CultureInfo culture) {
      try { return System.Convert.ToUInt16((string)value, 16); } catch { }
      return 0;
    }
  }

  public class text {
    public addrPair addrOfAddr { get; set; }
    public int addrOfSeg { get; set; }
    public ushort addrInSeg { get; set; }
    public string originalText { get; set; }
    public ushort newAddrInSeg { get; set; }
    public string localizedText { get; set; }
  }

  public class locText {

    public locText() {}

    public locText(string name) {
      fName = name;
      dt = new ObservableCollection<text>();
    }

    public string fName;
    public ObservableCollection<text> dt;
  }

  public class addrPair {

    public addrPair() { }

    public addrPair(int addr) { h = addr + 1; l = addr; }

    public addrPair(int h, int l) { this.h = h; this.l = l; }

    public int h;
    public int l;
  }

  public class txtAddresses {

    public txtAddresses(string name, addrPair[] addr) {
      fName = name;
      addresses = addr;
    }

    public string fName;
    public addrPair[] addresses;
  }

  public class textsTextsViewModel {

    public textsTextsViewModel() {
      dt = new ObservableCollection<text>();
    }

    private static int getStrLen(byte[] bArr, int index) {
      int j = 0;
      for (int i = index; i < bArr.Length; i++, j++)
        if (bArr[i] == 0x00) break;
      return j;
    }

    private const int seg000 = 0x00000200;
    private const int seg001 = 0x000109B0;

    private List<txtAddresses> textAddresses = new List<txtAddresses> {
      new txtAddresses("mm.exe",       new addrPair[] {
        new addrPair(seg000+0x03F2),      //0062; INSERT MIGHT & MAGIC DISK
        new addrPair(seg000+0x0405),      //007D;IN DRIVE A AND PRESS 'ENTER'
        //...
        new addrPair(seg000+0x1A83),      //:0D14;  ARE YOU READY?
        new addrPair(seg000+0x1A96),      //:0D26;THEN PRESS ENTER!
        //...
        new addrPair(seg000+0x271B),      //:0DAE;NO RUMORS TODAY.
        new addrPair(seg000+0x262B),      //:0DBF;GREAT STUFF!
        new addrPair(seg000+0x261F),      //:0DCC;YOU FEEL SICK!!
        new addrPair(seg000+0x267A),      //:0DDC;HAVE A DRINK, THEN WE'LL T...
        new addrPair(seg000+0x2698),      //:0DFB;THANKS A LOT, HAVE ANOTHER...
        new addrPair(seg000+0x2759),      //:0E1D;YOU LOOK TERRIBLE, GO SEE ...
        //...
        //seg000:27BD;0E4F;>>5F0E E60E A60F 6C10 0911 7711 D111 4512
        new addrPair(seg001+0x0E4F+0x00), //:0E5F;SERVICES RENDERED, SECRETS...
        new addrPair(seg001+0x0E4F+0x02), //:0EE6;SEEK THE WIZARD RANALOU\nI...
        new addrPair(seg001+0x0E4F+0x04), //:0FA6;ONE BY WATER, ONE BY LAND\...
        new addrPair(seg001+0x0E4F+0x06), //:106C;THERE ARE MANY DUNGEONS LI...
        new addrPair(seg001+0x0E4F+0x08), //:1109;IN HONOR OF CORAK...\n\nFO...
        new addrPair(seg001+0x0E4F+0x0A), //:1177; IN HONOR OF GALA...\n\nFO...
        new addrPair(seg001+0x0E4F+0x0C), //:11D1; IN MEMORY OF A TIME LONG ...
        new addrPair(seg001+0x0E4F+0x0E), //:1245;THIS BEAST ONCE ROAMED THE...
        new addrPair(seg000+0x2780),      //:1296;ON THIS STONE STATUE OF
        new addrPair(seg000+0x279F),      //:12AF;A PLAQUE READS...
        //seg000+0x2789:12C1;>>D112 E012 F012 FF12 3713 4713 5613 6413
        new addrPair(seg001+0x12C1+0x00), //:12D1;A HUMAN KNIGHT
        new addrPair(seg001+0x12C1+0x02), //:12E0;AN ELVEN WIZARD
        new addrPair(seg001+0x12C1+0x04), //:12F0;A GNOME ROBBER
        new addrPair(seg001+0x12C1+0x06), //:12FF;A DWARF PALADIN\nPAINTED A...
        new addrPair(seg001+0x12C1+0x08), //:1337;AN H-ORC ARCHER
        new addrPair(seg001+0x12C1+0x0A), //:1347;A HUMAN CLERIC
        new addrPair(seg001+0x12C1+0x0C), //:1356;A BLUE DRAGON
        new addrPair(seg001+0x12C1+0x0E), //:1364;A GRAY MINOTAUR
        //...
        new addrPair(seg000+0x1D60),      //:137E;CONGRATULATIONS! YOU ARE N...
        new addrPair(seg000+0x1D98),      //:13A2;YOU GAINED
        new addrPair(seg000+0x1DC6),      //:13AE;HIT POINTS!
        new addrPair(seg000+0x1DE0),      //:13BA;YOU GAINED NEW SPELLS!
        //...
        new addrPair(seg000+0x1E0A),      //:13DB;SPECIAL TODAY,ALL YOU CAN ...
        new addrPair(seg000+0x1E48),      //:13FB;GP/EA
        new addrPair(seg000+0x1E5B),      //:1401;WILL YOU PAY(Y/N)?
        new addrPair(seg000+0x1EB9),      //:1415;NO GOLD, NO FOOD!
        new addrPair(seg000+0x1EC2),      //:1427;THANK YOU, COME AGAIN!
        //...
        new addrPair(seg000+0x2158),      //:1441;THANK YOU!
        new addrPair(seg000+0x2174),      //:144C;*** TODAY YOU SHALL BE PRO...
        //...
        new addrPair(seg000+0x243B),      //:1475;*** NOT ENOUGH GOLD ***
        new addrPair(seg000+0x2431),      //:148D; THANK YOU!
        new addrPair(seg000+0x245D),      //:1498;*** BACKPACK FULL ***
        //...
        new addrPair(seg000+0x2489),      //:14B1;*** CHECK CONDITION ***
        //???:14C9;WELCOME:
        new addrPair(seg000+0x2516),      //:14D2;'A'-'F' TO BUY\n(- = CANT ...
        new addrPair(seg000+0x251F),      //:14F0;'A'-'F' TO SELL
        new addrPair(seg000+0x24B9),      //:1500;GOLD=
        new addrPair(seg000+0x252B),      //:1507;'G' GATHER GOLD\n'#' OTHER...
        new addrPair(seg000+0x253E),      //:1526;'ESC' TO GO BACK
        //...
        new addrPair(seg000+0x27E3),      //:15E6;A) BUY WEAPONS\n
        new addrPair(seg000+0x27F1),      //:15F6;B) BUY ARMOR\n
        new addrPair(seg000+0x27FF),      //:1604;C) BUY MISC\n
        new addrPair(seg000+0x280D),      //:1611;D) SELL ITEM
        new addrPair(seg000+0x2837),      //:161E;WEAPONS     PRICE
        new addrPair(seg000+0x28D0),      //:1630;ARMOR      PRICE
        new addrPair(seg000+0x28EC),      //:1641;MISC       PRICE
        new addrPair(seg000+0x2908),      //:1652;BACKPACK     PRICE
        new addrPair(seg000+0x2A87),      //:1665;NO WAY!
        new addrPair(seg000+0x2A48),      //:166D;TRAINING FOR LEVEL
        new addrPair(seg000+0x2BE2),      //:1681;COST
        new addrPair(seg000+0x2C16),      //:1687;GOLD
        new addrPair(seg000+0x2C29),      //:168C;A) COMMENCE TRAINING
        new addrPair(seg000+0x2C6D),      //:16A1;NEED
        new addrPair(seg000+0x2CAD),      //:16A7;MORE
        new addrPair(seg000+0x2CC0),      //:16AC;EXPERIENCE POINTS
        new addrPair(seg000+0x2CD9),      //:16BE;SERVICE        COST
        new addrPair(seg000+0x2DBF),      //:16D2;A) RESTORE HEALTH
        new addrPair(seg000+0x2DF9),      //:16E4;B) UNCURSE ITEMS
        new addrPair(seg000+0x2E33),      //:16F5;C) RESTORE ALIGN
        new addrPair(seg000+0x2E81),      //:1706;D) MAKE DONATION
        //...
        new addrPair(seg000+0x2EA5),      //:174F;----
        //...
        //seg000:2F44:175F;>>6917 7617 8117 8C17 9B17
        new addrPair(seg001+0x175F+0x00), //:1769;--TRAINING--
        new addrPair(seg001+0x175F+0x02), //:1776;--MARKET--
        new addrPair(seg001+0x175F+0x04), //:1781;--TEMPLE--
        new addrPair(seg001+0x175F+0x06), //:178C;--BLACKSMITH--
        new addrPair(seg001+0x175F+0x08), //:179B;--TAVERN--
        new addrPair(seg000+0x2F65),      //:17A6;A) HAVE A DRINK\n
        new addrPair(seg000+0x2F73),      //:17B7;B) TIP BARTENDER\n
        new addrPair(seg000+0x2F81),      //:17C9;C) LISTEN FOR RUMORS
        //...
        new addrPair(seg000+0x32CF),      //:17E3;OPTIONS:  'A' ATTACK  'R' ...
        new addrPair(seg000+0x32E1),      //:1805;'B' BRIBE   'S' SURRENDER
        new addrPair(seg000+0x327E),      //:181F; YOU SURPRISED A GROUP OF ...
        new addrPair(seg000+0x3290),      //:1842;APPROACH(Y/N)?
        new addrPair(seg000+0x32B1),      //:1852;THE MONSTERS SURPRISED YOU!
        new addrPair(seg000+0x354C),      //:186E;COMBAT!
        new addrPair(seg000+0x3345),      //:1876;NOWHERE TO RUN
        new addrPair(seg000+0x336D),      //:1885; THE MONSTERS SURROUND YOU!
        new addrPair(seg000+0x33B0),      //:18A0;THE MONSTERS DON'T TAKE PR...
        new addrPair(seg000+0x3432),      //:18C3;NO RESPONSE
        new addrPair(seg000+0x3463),      //:18CF;GIVE UP ALL YOUR XXXX(Y/N)?
        new addrPair(seg000+0x3483),      //:18EC;GOLD
        new addrPair(seg000+0x34A1),      //:18F1;GEMS
        new addrPair(seg000+0x3492),      //:18F6; FOOD
        new addrPair(seg000+0x34E0),      //:18FB;NOT ENOUGH
        new addrPair(seg000+0x320F),      //:1906;
        new addrPair(seg000+0x3566),      //:1910;*** ALIGNMENT SLIPS ***
        new addrPair(seg000+0x358F),      //:1928;
        //...
        new addrPair(seg000+0x3893),      //:1941;IT OPENS!
        //???:194B;RECEIVES
        new addrPair(seg000+0x38B0),      //:1954;EACH SHARE IS WORTH
        new addrPair(seg000+0x3916),      //:1969;GOLD
        new addrPair(seg000+0x39BC),      //:196E;FOUND
        new addrPair(seg000+0x3B23),
        new addrPair(seg000+0x39ED),      //:1975; GEMS
        // ...
        new addrPair(seg000+0x37D5),      //:197C;OPTIONS:           1) OPEN IT
        new addrPair(seg000+0x37E7),      //:199A;2) FIND/REMOVE TRAP
        new addrPair(seg000+0x37FC),      //:19AE;3) DETECT MAGIC/TRAP
        new addrPair(seg000+0x3BA5),      //:19C3;'ESC' TO GO BACK
        new addrPair(seg000+0x3C42),      //:19D4;MAGIC(N)  TRAP(N)
        new addrPair(seg000+0x3C9B),      //:19E8;*** BAD CLASS ***
        new addrPair(seg000+0x3CBF),      //:19FA;*** NO SPELL POINTS ***
        new addrPair(seg000+0x3D4C),      //:1A12;*** CHECK CONDITION ***
        new addrPair(seg000+0x3CEB),      //:1A2A;WHO WILL TRY '1'-'
        //; Это массив 11 строк длиной 0x0D
        new addrPair(seg000+0x37AA),      //:1A3D; CLOTH SACK
        //seg000+0x37AA+0x01*0x0D,  //:1A4A;LEATHER SACK
        //seg000+0x37AA+0x02*0x0D,  //:1A57; WOODEN BOX
        //seg000+0x37AA+0x03*0x0D,  //:1A64;WOODEN CHEST
        //seg000+0x37AA+0x04*0x0D,  //:1A71;  IRON BOX
        //seg000+0x37AA+0x05*0x0D,  //:1A7E; IRON CHEST
        //seg000+0x37AA+0x06*0x0D,  //:1A8B; SILVER BOX
        //seg000+0x37AA+0x07*0x0D,  //:1A98;SILVER CHEST
        //seg000+0x37AA+0x08*0x0D,  //:1AA5;  GOLD BOX
        //seg000+0x37AA+0x09*0x0D,  //:1AB2; GOLD CHEST
        //seg000+0x37AA+0x0A*0x0D,  //:1AC0; BLACK BOX
        //...
        //; Массив строк.Строки, начиная со второй, начинаются с байта 0xFF
        new addrPair(seg000+0x3D76),      //:180D; DARTS!! A SWARM OF POISON...
        //:1B46;яSPIKES!! DEADLY SPIKES SPRING FORTH!
        //:1B6C;яARROWS!! A SUDDEN ONSLAUGHT OF POISONOUS         ARROWS PER...
        //:1BB9;яBLADES!! RAZOR SHARP BLADES SLICE\n         THROUGH THE PAR...
        //:1BF8;яBOILING OIL!! STREAMS OF BOILING OIL\n              COVER T...
        //:1C3D;яGAS!! A FAINT HISS CAN BE HEARD AS\n      NOXIOUS FUMES FIL...
        //:1C83;яFIREBALL!! A FIERY EXPLOSION ENGULFS\n           THE AREA! ...
        //:1CBE;яLIGHTNING BOLT!! ELECTRIC CURRENTS\n                 SINGE ...
        //:1D04;яACID!! A FINE MIST OF VOLATILE ACID\n       SPRAYS THE PART...
        //:1D42;яICE STORM!! PARTICLES OF SPLINTERED ICE\n            HAIL T...
        //:1D8D;яDEATH RAY!! A BLINDING LIGHT SEARS\n            THROUGH THE...
        //...
        //seg000:4238:1DD2;>>F21D FD1D FF1D 0A1E 151E 1D1E 261E 2E1E 381E 431E 4E1E 591E 641E 6F1E 7A1E 851E
        new addrPair(seg001+0x1DD2+0x00), //:1DF2;` COMMANDS
        new addrPair(seg001+0x1DD2+0x02), //:1DFD;`
        new addrPair(seg001+0x1DD2+0x04), //:1DFF;`[ FORWARD
        new addrPair(seg001+0x1DD2+0x06), //:1E0A;`\ BACK
        new addrPair(seg001+0x1DD2+0x08), //:1E15;`] TURN
        new addrPair(seg001+0x1DD2+0x0A), //:1E1D;`   LEFT
        new addrPair(seg001+0x1DD2+0x0C), //:1E26;`^ TURN
        new addrPair(seg001+0x1DD2+0x0E), //:1E2E;`   RIGHT
        new addrPair(seg001+0x1DD2+0x10), //:1E38;`O ORDER
        new addrPair(seg001+0x1DD2+0x12), //:1E43;`P PROTECT
        new addrPair(seg001+0x1DD2+0x14), //:1E4E;`R REST
        new addrPair(seg001+0x1DD2+0x16), //:1E59;`S SEARCH
        new addrPair(seg001+0x1DD2+0x18), //:1E64;`B BASH
        new addrPair(seg001+0x1DD2+0x1A), //:1E6F;`U UNLOCK
        new addrPair(seg001+0x1DD2+0x1C), //:1E7A;`Q QUIKREF
        new addrPair(seg001+0x1DD2+0x1E), //:1E85;`# VIEW CH
        //...
        new addrPair(seg000+0x4607),      //:1EE0; ENCOUNTER!
        new addrPair(seg000+0x4FB5),      //:1EED;  BARRIER!
        new addrPair(seg000+0x479B),      //:1EFA; RE-ORDER PARTY  NEW  1  2...
        new addrPair(seg000+0x47AE),      //:1F21;OLD ^
        //seg000+0x476C:1F27;>>331F 401F 4D1F 5A1F 671F 741F
        new addrPair(seg001+0x1F27+0x00), //:1F33;   SOLID!
        new addrPair(seg001+0x1F27+0x02), //:1F40;   LOCKED!
        new addrPair(seg001+0x1F27+0x04), //:1F4D; TOO DENSE!
        new addrPair(seg001+0x1F27+0x06), //:1F5A; IMPASSABLE
        new addrPair(seg001+0x1F27+0x08), //:1F67; ROUGH SEAS
        new addrPair(seg001+0x1F27+0x0A), //:1F74; TOO WINDY!
        //...
        new addrPair(seg000+0x48CA),      //:1F82;PROTECT:  SPELLS CURRENTLY...
        new addrPair(seg000+0x499E),      //:1FA4;PROTECTION FROM:
        new addrPair(seg000+0x4983),      //:1FB5;TO ATTACKS
        new addrPair(seg000+0x47C1),      //:1FC0;'ESC' TO GO BACK
        new addrPair(seg000+0x49E2),
        new addrPair(seg000+0x4AF1),
        new addrPair(seg000+0x49F6),      //:1FD1;VOLUME: ON
        new addrPair(seg000+0x4A07),      //:1FDC;VOLUME: OFF
        //...
        //seg000:48E8/4908/493C:1FEA;>>0E20 1320 1820 1D20 2420 2920 2E20 3420 3C20 4920 5220 6020 6A20 7D20 8320 9020 9720 A420
        new addrPair(seg001+0x1FEA+0x00), //:200E;FEAR
        new addrPair(seg001+0x1FEA+0x02), //:2013;COLD
        new addrPair(seg001+0x1FEA+0x04), //:2018;FIRE
        new addrPair(seg001+0x1FEA+0x06), //:201D;POISON
        new addrPair(seg001+0x1FEA+0x08), //:2024;ACID
        new addrPair(seg001+0x1FEA+0x0A), //:2029;ELEC
        new addrPair(seg001+0x1FEA+0x0C), //:202E;MAGIC
        new addrPair(seg001+0x1FEA+0x0E), //:2034;LIGHT(
        new addrPair(seg001+0x1FEA+0x10), //:203C; LEATHER SKIN
        new addrPair(seg001+0x1FEA+0x12), //:2049;LEVITATE
        new addrPair(seg001+0x1FEA+0x14), //:2052;WALK ON WATER
        new addrPair(seg001+0x1FEA+0x16), //:2060;GUARD DOG
        new addrPair(seg001+0x1FEA+0x18), //:206A;PSYCHIC PROTECTION
        new addrPair(seg001+0x1FEA+0x1A), //:207D;BLESS
        new addrPair(seg001+0x1FEA+0x1C), //:2083;INVISIBILITY
        new addrPair(seg001+0x1FEA+0x1E), //:2090;SHIELD
        new addrPair(seg001+0x1FEA+0x20), //:2097;POWER SHIELD
        new addrPair(seg001+0x1FEA+0x22), //:20A4;*** CURSED -
        new addrPair(seg000+0x4A39),      //:20B1;SEARCH:
        new addrPair(seg000+0x4A54),      //:20BB;NOTHING
        new addrPair(seg000+0x4A5F),      //:20C3;YOU FOUND...
        new addrPair(seg000+0x4ACB),      //:20D0; WHO WILL TRY '1'-'
        new addrPair(seg000+0x4BA8),      //:20E3;UNLOCK FAILED
        new addrPair(seg000+0x4BDD),      //:20F1;SUCCESS!
        new addrPair(seg000+0x4CB8),      //:20FA;OOPS A TRAP!
        new addrPair(seg000+0x4DE4),      //:2107; CAN'T SWIM
        new addrPair(seg000+0x50C6),      //:2114;
        new addrPair(seg000+0x461A),      //:2116;
        new addrPair(seg000+0x4FD0),
        new addrPair(seg000+0x50BD),      //:2123; PLEASE WAIT
        //...
        new addrPair(seg000+0x522B),      //:2148; MIGHT AND MAGIC
        new addrPair(seg000+0x5250),      //:2158; SECRET OF THE INNER SANCTUM
        new addrPair(seg000+0x5267),      //:2174; OPTIONS
        new addrPair(seg000+0x527E),      //:217C;-------
        new addrPair(seg000+0x5295),      //:2184;'C'.......CREATE NEW CHARA...
        new addrPair(seg000+0x5BE0),      //:218E;CREATE NEW CHARACTERS
        new addrPair(seg000+0x52AC),      //:21A4;'V'.......VIEW ALL CHARACTERS
        new addrPair(seg000+0x5CD9),      //:21AE;VIEW ALL CHARACTERS
        new addrPair(seg000+0x52C3),      //:21C2;'#'.......GO TO TOWN
        new addrPair(seg000+0x52D8),      //:21D7; COPR. 1986,1987-JON VAN C...
        new addrPair(seg000+0x52EE),      //:21F8;ALL RIGHTS RESERVED
        new addrPair(seg000+0x5CAA),      //:220C;'ESC' TO GO BACK
        new addrPair(seg000+0x544F),      //:221D;'ESC' START OVER
        //...
        new addrPair(seg000+0x5B05),      //:2231;1) KNIGHT
        new addrPair(seg000+0x537A),      //:2234;KNIGHT
        new addrPair(seg000+0x5DAE),
        //...
        new addrPair(seg000+0x5B2F),      //:223E;2) PALADIN
        new addrPair(seg000+0x5387),      //:2241;PALADIN
        new addrPair(seg000+0x5DBE),
        new addrPair(seg000+0x5B58),      //:224A;3) ARCHER
        new addrPair(seg000+0x5394),      //:224D;ARCHER
        new addrPair(seg000+0x5DCE),
        new addrPair(seg000+0x5B7A),      //:2256;4) CLERIC
        new addrPair(seg000+0x53A1),      //:2259;CLERIC
        new addrPair(seg000+0x5DDE),
        new addrPair(seg000+0x5B9C),      //:2262;5) SORCERER
        new addrPair(seg000+0x53AE),      //:2265;SORCERER
        new addrPair(seg000+0x5DEE),
        new addrPair(seg000+0x5BB7),      //:226E;6) ROBBER
        new addrPair(seg000+0x53B7),      //:2271;ROBBER
        new addrPair(seg000+0x5DFE),
        new addrPair(seg000+0x536A),      //:227A;CLASS.=
        new addrPair(seg000+0x5496),      //:2282:RACE..=
        new addrPair(seg000+0x55C5),      //:228A;ALGN..=
        new addrPair(seg000+0x5688),      //:2292;SEX...=
        new addrPair(seg000+0x56D4),      //:229A;NAME:
        new addrPair(seg000+0x53DB),      //:22A9;1) HUMAN
        new addrPair(seg000+0x54A6),      //:22AC;HUMAN
        new addrPair(seg000+0x53EC),      //:22B6;2) ELF
        new addrPair(seg000+0x54B3),      //:22B9;ELF
        new addrPair(seg000+0x53FD),      //:22C3;3) DWARF
        new addrPair(seg000+0x54D0),      //:22C6;DWARF
        new addrPair(seg000+0x540E),      //:22D0;4) GNOME
        new addrPair(seg000+0x54ED),      //:22D3; GNOME
        new addrPair(seg000+0x541F),      //:22DD;5) HALF-ORC
        new addrPair(seg000+0x5506),      //:22E0; HALF-ORC
        new addrPair(seg000+0x5549),      //:22EA;1) GOOD
        new addrPair(seg000+0x55D5),      //:22ED; GOOD
        new addrPair(seg000+0x555A),      //:22F7;2) NEUT
        new addrPair(seg000+0x55E2),      //:22FA;NEUT
        new addrPair(seg000+0x556B),      //:2304;3) EVIL
        new addrPair(seg000+0x55EB),      //:2307;EVIL
        new addrPair(seg000+0x560F),      //:2311;1) MALE
        new addrPair(seg000+0x5698),      //:2314; MALE
        new addrPair(seg000+0x5620),      //:231E;2) FEMALE
        new addrPair(seg000+0x56A1),      //:2321;FEMALE
        new addrPair(seg000+0x5437),      //:232B;SELECT A RACE
        new addrPair(seg000+0x5595),      //:233A;SELECT ALIGNMENT
        new addrPair(seg000+0x5639),      //:234B;  SELECT A SEX
        new addrPair(seg000+0x578D),      //:235C;SAVE CHARACTER
        new addrPair(seg000+0x57A4),      //:236B;     (Y/N)?
        new addrPair(seg000+0x626B),      //:237C;
        new addrPair(seg000+0x5466),      //:2384;
        new addrPair(seg000+0x56FD),
        new addrPair(seg000+0x5F38),
        new addrPair(seg000+0x5FE5),
        new addrPair(seg000+0x6230),
        new addrPair(seg000+0x53C7),      //:2388;
        new addrPair(seg000+0x5536),
        new addrPair(seg000+0x557C),
        new addrPair(seg000+0x55FC),
        new addrPair(seg000+0x56B2),
        new addrPair(seg000+0x56C3),
        new addrPair(seg000+0x5712),
        new addrPair(seg000+0x5BC5),
        //...
        new addrPair(seg000+0x5E56),      //:23D4;'A'-'
        new addrPair(seg000+0x5E6E),      //:23DA;' TO VIEW A CHARACTER
        new addrPair(seg000+0x5E0A),      //:23F0;NONE
        new addrPair(seg000+0x5EDC),      //:23F5;(CTRL)-'N' RE-NAME CHARACTER
        new addrPair(seg000+0x5EF0),      //:2412;(CTRL)-'D' DELETE CHARACTER
        new addrPair(seg000+0x5FD1),      //:242E;    ARE YOU SURE(Y/N)?
        new addrPair(seg000+0x5F24),      //:2450;NAME: _
        new addrPair(seg000+0x5C93),      //:246F;*** ROSTER IS FULL***
        //???:2486;CREATE NEW CHARACTERS
        new addrPair(seg000+0x5BF9),      //:249C;INTELLECT...=
        new addrPair(seg000+0x5C0E),      //:24AA;MIGHT.......=
        new addrPair(seg000+0x5C23),      //:24B8;PERSONALITY.=
        new addrPair(seg000+0x5C38),      //:24C6;ENDURANCE...=
        new addrPair(seg000+0x5C4D),      //:24D4;SPEED.......=      SELECT ...
        new addrPair(seg000+0x5C62),      //:24F6;ACCURACY....=          (1-6)
        new addrPair(seg000+0x5C77),      //:2513;LUCK........=     'ENT' TO...
        //...
        new addrPair(seg000+0x657A),      //:2538;+-------------------------...
        new addrPair(seg000+0x6611),
        new addrPair(seg000+0x658D),      //:2561;THE SHADOW OF DEATH
        new addrPair(seg000+0x65A3),      //:2575;HAS FALLEN UPON YOUR PARTY!
        new addrPair(seg000+0x65B9),      //:2591;FORTUNATELY, YOU MAY RENEW
        new addrPair(seg000+0x65CF),      //:25AC;YOUR QUEST FROM THE LAST
        new addrPair(seg000+0x65E5),      //:25C5;INN IN WHICH YOU STAYED
        new addrPair(seg000+0x65FB),      //:25DD;BY PRESSING 'ENTER'
        new addrPair(seg000+0x6262),      //:25F1;*** PARTY IS FULL ***
        new addrPair(seg000+0x6059),      //:2607;) INN OF
        new addrPair(seg000+0x6070),      //:2611;SORPIGAL
        new addrPair(seg000+0x607D),      //:261A;PORTSMITH
        new addrPair(seg000+0x608A),      //:2624;ALGARY
        new addrPair(seg000+0x6097),      //:262B;DUSK
        new addrPair(seg000+0x60A4),      //:2630;ERLIQUIN
        new addrPair(seg000+0x60DD),      //:2639;AVAILABLE CHARACTERS
        new addrPair(seg000+0x60FF),
        new addrPair(seg000+0x61D0),      //:264E;'A'-'
        new addrPair(seg000+0x61DF),      //:2654;' TO VIEW
        new addrPair(seg000+0x61F3),      //:265E;(CTRL)-'A'-'
        new addrPair(seg000+0x6202),      //:266B;' ADD/REMOVE
        new addrPair(seg000+0x6239),      //:2678;'X' EXIT INN
        //...
        new addrPair(seg000+0x686E),      //:2687; NONE
        new addrPair(seg000+0x68C8),
        new addrPair(seg000+0x692F),
        new addrPair(seg000+0x684B),      //:268C;GOOD
        new addrPair(seg000+0x696C),
        new addrPair(seg000+0x6858),      //:2691; NEUT
        new addrPair(seg000+0x6865),      //:2696; EVIL
        new addrPair(seg000+0x688B),      //:269B;HUMAN
        new addrPair(seg000+0x6898),      //:26A1;ELF
        new addrPair(seg000+0x68A5),      //:26A5;DWARF
        new addrPair(seg000+0x68B2),      //:26AB;GNOME
        new addrPair(seg000+0x68BF),      //:26B1;H-ORC
        new addrPair(seg000+0x68E5),      //:26B7;KNIGHT
        new addrPair(seg000+0x68F2),      //:26BE;PALADIN
        new addrPair(seg000+0x68FF),      //:26C6;ARCHER
        new addrPair(seg000+0x690C),      //:26CD;CLERIC
        new addrPair(seg000+0x6919),      //:26D4; SORCERER
        new addrPair(seg000+0x6926),      //:26DD;ROBBER
        new addrPair(seg000+0x697E),      //:26E4; ERADICATED
        new addrPair(seg000+0x6993),      //:26EF;DEAD,
        new addrPair(seg000+0x69A2),      //:26F5;STONE,
        new addrPair(seg000+0x69C0),      //:26FC;UNCONSCIOUS,
        new addrPair(seg000+0x69CF),      //:2709;PARALYZED,
        new addrPair(seg000+0x69DE),      //:2714;POISONED,
        new addrPair(seg000+0x69ED),      //:271E;DISEASED,
        new addrPair(seg000+0x69FC),      //:2728;SILENCED,
        new addrPair(seg000+0x6A0B),      //:2732;BLINDED,
        new addrPair(seg000+0x6A1A),      //:273B;ASLEEP,
        new addrPair(seg000+0x694F),      //:2743;COND=
        new addrPair(seg000+0x6A76),      //:2749;INT=
        new addrPair(seg000+0x6A93),      //:274E;LEVEL=
        new addrPair(seg000+0x6AB0),      //:2755;AGE=
        new addrPair(seg000+0x6ACD),      //:275A;EXP=
        new addrPair(seg000+0x6B04),      //:275F;MGT=
        new addrPair(seg000+0x6B24),      //:2764;PER=
        new addrPair(seg000+0x6B41),      //:2769;SP=
        new addrPair(seg000+0x6BA6),      //:276D;GEMS=
        new addrPair(seg000+0x6BD1),      //:2773;END=
        new addrPair(seg000+0x6BF1),      //:2778;SPD=
        new addrPair(seg000+0x6C0E),      //:277D;HP=
        new addrPair(seg000+0x6C50),      //:2781;GOLD=
        new addrPair(seg000+0x6C81),      //:2787;ACY=
        new addrPair(seg000+0x6CA1),      //:278C;LUC=
        new addrPair(seg000+0x6CBE),      //:2791;AC=
        new addrPair(seg000+0x6784),      //:2795;FOOD=
        new addrPair(seg000+0x6CDB),
        new addrPair(seg000+0x6D0B),      //:279B;-----<EQUIPPED>----------<...
        new addrPair(seg000+0x6653),      //:27C4;#     NAME        HIT PTS ...
        new addrPair(seg000+0x67C7),      //:27ED;'1'-'
        new addrPair(seg000+0x67D6),      //:27F3;' TO VIEW
        new addrPair(seg000+0x67E9),      //:27FD;'ESC' TO GO BACK
        //...
        new addrPair(seg000+0x6DFB),      //:2810;'Q' QUICK REF     'C' CAST...
        new addrPair(seg000+0x6E10),      //:2839; # VIEW OTHER     'D' DISC...
        new addrPair(seg000+0x6E25),      //:2861;                  'E' EQUI...
        new addrPair(seg000+0x6E3A),      //:2889;'ESC' TO GO BACK  'G' GATH...
        new addrPair(seg000+0x6EF8),      //:28AF;*** TOO DANGEROUS TO REST ...
        new addrPair(seg000+0x6F1A),      //:28CF;REST HERE(Y/N)?
        new addrPair(seg000+0x6FF5),      //:28E0;REST COMPLETE: NO ENCOUNTERS!
        //...
        new addrPair(seg000+0x7455),      //:2922;DISCARD WHICH ITEM: 'A'-'F'?
        new addrPair(seg000+0x7569),      //:293F;*** 40 FOOD MAX ***
        new addrPair(seg000+0x7774),      //:2953;SHARE ALL:
        //...
        new addrPair(seg000+0x7DE9),      //:296A;*** ALREADY HAVE WEAPON ***
        new addrPair(seg000+0x7DF7),      //:2986;*** AREADY HAVE MISSILE WE...
        new addrPair(seg000+0x7E05),      //:29A9;*** CANNOT WITH SHIELD ***
        new addrPair(seg000+0x7E13),      //:29C4;*** ALREADY WEARING ARMOR ***
        new addrPair(seg000+0x7E21),      //:29E2;*** CANNOT WITH TWO-HANDED...
        new addrPair(seg000+0x7E2F),      //:2A08;*** ALREADY HAVE ONE ***
        new addrPair(seg000+0x7E3D),      //:2A21;*** FULL ***
        new addrPair(seg000+0x8018),
        new addrPair(seg000+0x83DD),
        new addrPair(seg000+0x7E4B),      //:2A2E;*** NOT EQUIPPED ***
        new addrPair(seg000+0x86F2),
        new addrPair(seg000+0x7DCD),      //:2A43;*** WRONG ALIGNMENT ***
        new addrPair(seg000+0x7DDB),      //:2A5B;*** WRONG CLASS ***
        new addrPair(seg000+0x7A94),      //:2A6F;EQUIP WHICH ITEM: 'A'-'F'?
        new addrPair(seg000+0x80BB),      //:2A75;WHICH ITEM: 'A'-'F'?
        new addrPair(seg000+0x9559),
        new addrPair(seg000+0x9639),
        //...
        new addrPair(seg000+0x8002),      //:2A92;*** CURSED ***
        new addrPair(seg000+0x7EA8),      //:2AA1;REMOVE WHICH ITEM: '1'-'6'?
        new addrPair(seg000+0x82A3),      //:2ABD;*** YOU DON'T HAVE THAT MU...
        new addrPair(seg000+0x8040),      //:2ADE;TRADE WHICH:
        new addrPair(seg000+0x8059),      //:2AEB;4) ITEM
        new addrPair(seg000+0x82BC),      //:2AF3;TRADE WITH: '1'-'
        new addrPair(seg000+0x8339),      //:2B05;'ESC' TO GO BACK
        new addrPair(seg000+0x834D),      //:2B16;1) GEMS
        new addrPair(seg000+0x835F),      //:2B1E;2) GOLD
        new addrPair(seg000+0x8371),      //:2B26;3) FOOD
        new addrPair(seg000+0x74CD),      //:2B2E;GATHER ALL:
        //...
        new addrPair(seg000+0x848C),      //:2B43;HOW MUCH: _
        //...
        new addrPair(seg000+0x862F),      //:2B53;USE WHICH 'A'-'F','1'-'6'?
        new addrPair(seg000+0x86D8),      //:2B6E;*** NO SPECIAL POWER ***
        new addrPair(seg000+0x870F),      //:2B87;*** NO CHARGES LEFT ***
        new addrPair(seg000+0x87D4),      //:2B9F;CAST SPELL:  LEVEL= _
        new addrPair(seg000+0x8812),      //:2BB5;NUMBER= _
        new addrPair(seg000+0x8A48),      //:2BBF;*** DONE ***
        new addrPair(seg000+0x89C3),      //:2BCC;CAST ON: '1'-'
        new addrPair(seg000+0x89DB),      //:2BDB;'ENTER' TO CAST
        new addrPair(seg000+0x93A8),
        new addrPair(seg000+0x94A7),
        //...
        new addrPair(seg000+0x8F3C),      //:2CAD; WHICH TOWN(1-5)?
        //...
        new addrPair(seg000+0x902B),      //:2CC2;MAGIC(CHARGES)
        new addrPair(seg000+0x912D),      //:2CD2;LOCATION:
        new addrPair(seg000+0x9148),      //:2CDD;UNKNOWN
        new addrPair(seg000+0x9158),      //:2CE5;IN TOWN
        new addrPair(seg000+0x9161),      //:2CED;IN CASTLE
        new addrPair(seg000+0x916A),      //:2CF7;OUTDOORS
        new addrPair(seg000+0x9181),      //:2D00;0' UNDER
        new addrPair(seg000+0x918F),      //:2D09;MAP SECTOR:
        new addrPair(seg000+0x91C0),      //:2D16;SURFACE: X=
        new addrPair(seg000+0x920B),      //:2D22;INSIDE: X=
        new addrPair(seg000+0x9240),      //:2D2D;FACING:
        //...
        new addrPair(seg000+0x9342),      //:2D38;FLY TO(A-E): _
        new addrPair(seg000+0x937A),      //:2D48;(1-4): _
        //...
        new addrPair(seg000+0x9442),      //:2D53;DIRECTION(N, E, S, W):_
        new addrPair(seg000+0x947B),      //:2D69;# OF SQUARES (0-9):_
        //...
        new addrPair(seg000+0x8903),      //:2DE6;*** NOT ENOUGH SPELL POINT...
        new addrPair(seg000+0x894A),      //:2E06;*** NOT ENOUGH GEMS ***
        new addrPair(seg000+0x899A),      //:2E1E;*** OUTDOOR ONLY ***
        new addrPair(seg000+0x8970),      //:2E33;*** COMBAT ONLY ***
        new addrPair(seg000+0x8A6F),      //:2E47;*** MAGIC DOESN'T WORK HER...
        new addrPair(seg000+0x9727),      //:2E67;*** SPELL FAILED ***
        //...
        new addrPair(seg000+0xA0F4),      //:3060;! FOR DEFEATING THE MONSTE...
        new addrPair(seg000+0xA107),      //:307F;!   EACH SURVIVOR RECEIVES...
        new addrPair(seg000+0xA133),      //:309E;EXPERIENCE POINTS.
        new addrPair(seg000+0xA085),      //:30B1;+-------------------------...
        new addrPair(seg000+0xA146),
        //...
        new addrPair(seg000+0x9B52),      //:30D6;RUNS AWAY...
        //...
        new addrPair(seg000+0x9C1C),      //:30E4; INFILTRATES THE RANKS!
        //; массив 15 строк, разделенных 0x00
        new addrPair(seg000+0x9C58),      //:30FB;ATTACKS
        //           :3103;FIGHTS
        //           :310A;CHARGES
        //           :3112;ASSAULTS
        //           :311B;BATTLES
        //           :3123;STABS AT
        //           :312C;FLAILS AT
        //           :3136; LUNGES AT
        //           :3140; SWINGS AT
        //           :314A;CHOPS AT
        //           :3153; HACKS AT
        //           :315C;THRUSTS AT
        //           :3167; SLASHES AT
        //           :3172; STRIKES AT
        //           :317D; THRASHES AT
        // ...
        new addrPair(seg000+0xA608),      //:319B; WEAPON HAS NO EFFECT!
        //...
        new addrPair(seg000+0xAC1E),      //:31B3;AND
        //...
        new addrPair(seg000+0xACD8),      //:31B9; ADVANCES!
        //...
        new addrPair(seg000+0xAE4F),      //:31CE;SOME MONSTERS REGENERATE!
        new addrPair(seg000+0xAE79),      //:31E8;SOME MONSTERS OVERCOME SPE...
        new addrPair(seg000+0xAF23),      //:3207; WAITS FOR AN OPENING.
        new addrPair(seg000+0xAF1A),      //:321E; SHOOTS AT
        //...
        new addrPair(seg000+0xA83D),      //:325B; TAKES FOOD
        new addrPair(seg000+0xA850),      //:3266;INFLICTS DISEASE
        new addrPair(seg000+0xA869),      //:3277;CAUSES PARALYSIS
        new addrPair(seg000+0xA882),      //:3288;INDUCES POISON
        new addrPair(seg000+0xA8D2),      //:3297;STEALS SOME GEMS
        new addrPair(seg000+0xA8FC),      //:32A8;REDUCES ENDURANCE
        new addrPair(seg000+0xA919),      //:32BA;INDUCES SLEEP
        new addrPair(seg000+0xA97A),      //:32C8;STEALS SOME GOLD
        new addrPair(seg000+0xA9AA),      //:32D9;STEALS SOMETHING
        new addrPair(seg000+0xA9C0),      //:32EA;CAUSES BLINDNESS
        new addrPair(seg000+0xA9F3),      //:32FB;DRAINS LIFEFORCE
        new addrPair(seg000+0xAA8D),
        new addrPair(seg000+0xAA24),      //:330C;IS TURNED TO STONE
        new addrPair(seg000+0xAA54),      //:331F;CAUSES RAPID AGING
        new addrPair(seg000+0xAABE),      //:3332;IS KILLED
        new addrPair(seg000+0xD8F9),
        new addrPair(seg000+0xAAD7),      //:333C;INDUCES UNCONSCIOUSNESS
        new addrPair(seg000+0xAB07),      //:3354;DRAINS MIGHT
        new addrPair(seg000+0xAB58),      //:3361;DRAINS ABILITIES
        new addrPair(seg000+0xAB7D),      //:3372;STEALS BACKPACK
        new addrPair(seg000+0xABC0),      //:3382;STEALS GOLD AND GEMS
        new addrPair(seg000+0xABE6),      //:3397;IS ERADICATED
        new addrPair(seg000+0xAC05),      //:33A5;DRAINS SPELL POINTS
        //...
        new addrPair(seg000+0xAF59),      //:33BD;WANDERS AIMLESSLY
        //...
        new addrPair(seg000+0xAFEA),      //:340F; A CURSE
        new addrPair(seg000+0xB003),      //:3417;ENERGY BLAST
        new addrPair(seg000+0xB021),      //:3424;FIRE
        new addrPair(seg000+0xB1C2),
        new addrPair(seg000+0xB054),      //:3429;BLINDNESS
        new addrPair(seg000+0xB06D),      //:3433;SPRAYS POISON
        new addrPair(seg000+0xB087),      //:3441;SPRAYS ACID
        new addrPair(seg000+0xB0A7),      //:344D;SLEEP
        new addrPair(seg000+0xB0C8),      //:3453;PARALYZE
        new addrPair(seg000+0xB0F7),      //:345C;DISPELL
        new addrPair(seg000+0xB107),      //:3464;LIGHTNING BOLT
        new addrPair(seg000+0xB12E),      //:3473;STRANGE GAS
        new addrPair(seg000+0xB148),      //:347F;EXPLODE
        new addrPair(seg000+0xB17F),      //:3487;FIRE BALL
        new addrPair(seg000+0xB1FB),      //:3491;GAZES
        new addrPair(seg000+0xB213),      //:3497;ACID ARROW
        new addrPair(seg000+0xB237),      //:34A2;CALLS UPPON THE ELEMENTS
        new addrPair(seg000+0xB255),      //:34BB;COLD BEAM
        new addrPair(seg000+0xB27C),      //:34C5;DANCING SWORD
        new addrPair(seg000+0xB29A),      //:34D3;MAGIC DRAIN
        new addrPair(seg000+0xB2E3),      //:34DF;FINGER OF DEATH
        new addrPair(seg000+0xB2FF),      //:34EF;SUN RAY
        new addrPair(seg000+0xB321),      //:34F7;DISINTEGRATION
        new addrPair(seg000+0xB33A),      //:3506;COMMANDS ENERGY
        //...
        //seg000:B398:3517;>>2535 2C35 3635 3C35 4335 4835 4D35
        new addrPair(seg001+0x3517+0x00), //:3525;POISON
        new addrPair(seg001+0x3517+0x02), //:352C;LIGHTNING
        new addrPair(seg001+0x3517+0x04), //:3536; FROST
        new addrPair(seg001+0x3517+0x06), //:353C;SPIKES
        new addrPair(seg001+0x3517+0x08), //:3543; ACID
        new addrPair(seg001+0x3517+0x0A), //:3548;FIRE
        new addrPair(seg001+0x3517+0x0C), //:354D;ENERGY
        new addrPair(seg000+0xB3B5),      //:3554;SWARM
        new addrPair(seg000+0xB3CD),      //:355A;BREATHES
        new addrPair(seg000+0xB3E9),      //:3564;FAILS TO CAST A SPELL
        new addrPair(seg000+0xB3F4),      //:357A;CASTS
        // ...
        new addrPair(seg000+0xB428),      //:3583;TAKES
        new addrPair(seg000+0xB43E),      //:358A;POINT
        new addrPair(seg000+0xB46A),      //:3590;OF DAMAGE!
        //seg000:B4E4:359B;>>B135 BA35 C535 D135 DD35 E935 F635 3233 0C33 9733 0E36
        new addrPair(seg001+0x359B+0x00), //:35B1;IS SLEPT
        new addrPair(seg001+0x359B+0x02), //:35BA;IS BLINDED
        new addrPair(seg001+0x359B+0x04), //:35C5;IS SILENCED
        new addrPair(seg001+0x359B+0x06), //:35D1;IS DISEASED
        new addrPair(seg001+0x359B+0x08), //:35DD;IS POISONED
        new addrPair(seg001+0x359B+0x0A), //:35E9;IS PARALYZED
        new addrPair(seg001+0x359B+0x0C), //:35F6;IS RENDERED UNCONSCIOUS
        new addrPair(seg001+0x359B+0x0E), //:360E;IS AFFECTED
        new addrPair(seg000+0xB5F1),      //:361A;IS NOT AFFECTED!
        new addrPair(seg000+0xD908),
        new addrPair(seg000+0xB6DD),      //:362B;COMBAT
        new addrPair(seg000+0xAD3B),      //:3632;ROUND #:
        new addrPair(seg000+0xB6F1),
        new addrPair(seg000+0xB708),      //:363B;D DELAY
        new addrPair(seg000+0xB71C),      //:3643;P PROTECT
        new addrPair(seg000+0xB730),      //:364D;Q QUICKREF
        new addrPair(seg000+0xB744),      //:3658;# VIEW CH
        new addrPair(seg000+0xB75C),      //:3662;HANDICAP
        new addrPair(seg000+0xB8B9),      //:366B;MONSTER +
        new addrPair(seg000+0xB8C5),      //:3675;PARTY +
        new addrPair(seg000+0xB8D1),      //:367D;EVEN
        new addrPair(seg000+0xBE15),      //:3682;OPTIONS FOR:
        new addrPair(seg000+0xBF18),      //:3690;'E' EXCHANGE  'U' USE
        new addrPair(seg000+0xBF2C),      //:36A6;'R' RETREAT   'B' BLOCK
        new addrPair(seg000+0xBF44),      //:36BE;'A' ATTACK(A)
        new addrPair(seg000+0xBF58),      //:36CC;'F' FIGHT(+)
        new addrPair(seg000+0xBF70),      //:36D9;'S' SHOOT
        new addrPair(seg000+0xBF88),      //:36E3;'C' CAST
        new addrPair(seg000+0xA542),      //:36EC;ATTACKS
        new addrPair(seg000+0xA54B),      //:36F4;SHOOTS
        new addrPair(seg000+0xC090),      //:36FB;TIMES
        new addrPair(seg000+0xC0F3),
        new addrPair(seg000+0xC07A),      //:3701;ONCE
        new addrPair(seg000+0xC0D9),
        new addrPair(seg000+0xC09D),      //:3706;AND
        new addrPair(seg000+0xC0B1),      //:370A;MISSES
        new addrPair(seg000+0xC0BB),      //:3711;HIT
        new addrPair(seg000+0xC100),      //:3715;FOR
        new addrPair(seg000+0xC11A),      //:3719;POINT
        new addrPair(seg000+0xC149),      //:371F;OF DAMAGE!
        new addrPair(seg000+0xB68E),      //:372A;SET DELAY(0-9):
        new addrPair(seg000+0xB69E),      //:373B;(CURRENTLY=
        new addrPair(seg000+0xC1D4),      //:3748;'1'-'
        new addrPair(seg000+0xC1E6),      //:374E;' TO VIEW
        new addrPair(seg000+0xBFA6),      //:3758;'ESC' TO GO BACK
        new addrPair(seg000+0x9957),      //:3769; EXCHANGE PLACES WITH(1-
        new addrPair(seg000+0x9969),      //:3782;)?
        new addrPair(seg000+0xA2B8),      //:3785;FIGHT WHICH 'A'-'
        new addrPair(seg000+0xA339),      //:3797;SHOOT WHICH 'A'-'
        new addrPair(seg000+0xBA34),      //:37A9;(WOUNDED)
        //seg000+0xBA15:37B4;>>C637 D137 DC37 E737 F237 FD37 0838 1338 1E38
        new addrPair(seg001+0x37B4+0x00), //:37C6;(PARALYZE)
        new addrPair(seg001+0x37B4+0x02), //:37D1;(WEBBED)
        new addrPair(seg001+0x37B4+0x04), //:37DC;(HELD)
        new addrPair(seg001+0x37B4+0x06), //:37E7;(ASLEEP)
        new addrPair(seg001+0x37B4+0x08), //:37F2;(MINDLESS)
        new addrPair(seg001+0x37B4+0x0A), //:37FD;(SILENCED)
        new addrPair(seg001+0x37B4+0x0C), //:3808;(BLINDED)
        new addrPair(seg001+0x37B4+0x0E), //:3813;(AFRAID)
        new addrPair(seg001+0x37B4+0x10), //:381E;(DEAD)
        new addrPair(seg000+0xCD04),      //:3829;AND GOES DOWN!!!
        new addrPair(seg000+0x9E4D),      //:382D;GOES DOWN!!!
        new addrPair(seg000+0x9E88),      //:383A;DIES!
        //...
        new addrPair(seg000+0xBAF9),      //:38BE;
        new addrPair(seg000+0xBAE2),      //:38C9;
        //...
        new addrPair(seg000+0xC5C5),      //:38D9;
        //...
        new addrPair(seg000+0xC913),      //:38DC;NOT ENOUGH SPELL POINTS
        new addrPair(seg000+0xC95A),      //:38F4;NOT ENOUGH GEMS
        new addrPair(seg000+0xC9AA),      //:3904;OUTDOOR ONLY
        new addrPair(seg000+0xC980),      //:3911;NON COMBAT ONLY
        new addrPair(seg000+0xCAA9),      //:3921;MAGIC DOESN'T WORK HERE
        //...
        new addrPair(seg000+0xC649),      //:393C;USE WHICH 'A'-'F','1'-'6'?
        new addrPair(seg000+0xC6EF),      //:3957;NO SPECIAL POWER
        new addrPair(seg000+0xC72B),      //:3968;NO CHARGES LEFT
        new addrPair(seg000+0xC719),      //:3978;NOT EQUIPPED
        new addrPair(seg000+0xC7E0),      //:398B;CAST SPELL:  LEVEL= _
        new addrPair(seg000+0xC81E),      //:39A1;NUMBER= _
        new addrPair(seg000+0xCA7F),      //:39AB;DONE
        new addrPair(seg000+0xC9CB),      //:39B0;CAST ON: '1'-'
        new addrPair(seg000+0xCA03),      //:39BF;'ENTER' TO CAST
        new addrPair(seg000+0xC9EB),      //:39CF;CAST ON: 'A'-'
        new addrPair(seg000+0xCB98),      //:39DE;***
        //...
        //seg000:CC21:3A9E;>>B03A BA35 C535 BA3A B135 C63A CE3A E935 0E36
        new addrPair(seg001+0x3A9E+0x00), //:3AB0;IS SCARED
        new addrPair(seg001+0x3A9E+0x02), //:3ABA;IS MINDLESS
        new addrPair(seg001+0x3A9E+0x04), //:3AC6;IS HELD
        new addrPair(seg001+0x3A9E+0x06), //:3ACE;IS WEBBED
        //...
        new addrPair(seg000+0xCD81),      //:3AD9; CASTS A SPELL:
        //...
        new addrPair(seg000+0xCF77),      //:3AED;SOME MONSTERS WERE DESTROYED!
        new addrPair(seg000+0xCFC4),      //:3B0B;NO EFFECT!
        //...
        new addrPair(seg000+0xD64A),      //:3B1A;MAXIMUM DAMAGE =
        new addrPair(seg000+0xD5FE),      //:3B2C;# OF ATTACKS =
        new addrPair(seg000+0xD576),      //:3B3C;HP =
        new addrPair(seg000+0xD5D1),      //:3B42;BONUS ON TOUCH
        new addrPair(seg000+0xD594),      //:3B54;AC =
        new addrPair(seg000+0xD61B),      //:3B5A;SPECIAL ABILITY
        new addrPair(seg000+0xD5B4),      //:3B6C;SPEED =
        new addrPair(seg000+0xD667),      //:3B75;MAGIC RESISTANCE
        new addrPair(seg000+0xD959),      //:3B87;IS DISINTEGRATED!
        new addrPair(seg000+0xDA3A),      //:3B99;NO SPELL POINTS
        new addrPair(seg000+0xDA05),      //:3BA9;SPELL FAILED
        //...
        new addrPair(seg000+0x40CC),      //:3C0E;
        new addrPair(seg000+0x40DF),
        new addrPair(seg000+0x40F2),
        //...
        new addrPair(seg000+0x2882),      //:3CDA;
        new addrPair(seg000+0x2982),
        new addrPair(seg000+0x3B2C),
        new addrPair(seg000+0x6DA9),
        new addrPair(seg000+0x6DD0),
        //...
        //seg000:46F1:9972;STAFF        ;похоже, что ссылка просто на ББ оружие
        //...
        //>>из кода
        //:C1C2; SEE MAN IN CAVE BELOW(1,2)
        //:C1DE;CHECK WALLS NEAR(12,3)
        //:C1F6;STATUE AT(2,4) IS YOUR FIRST JOB
        //:C218;SIMILAR PIECES OF A PUZZLE MAY NOTЌBELONG TO THE SAME PUZZLE
        //:C255;SEEK QUESTS BEHIND MOONS
        //:C26E;THE QUEEN CAN BE HELPFUL
        //:C287;THE BEASTS ARE ON THE MAP
        //:C2A1;ISLANDS LIKE COLORS ARE UNKNOWNЌUNTIL DISCOVERED
        //:C2D2;ATTACKS SHOULD BE CONCENTRATED
        //:C2F1;DUE NORTH IS THE CAVE OF SQUARE MAGIC
        //:C317;SECRET DOORS ARE ABUNDANT
        //:C331;THE DEMON AND THE MAZE ARE ONE
        //:C250;TELGORAN IS IN S.E.MAZE
        //:C369; SOME ITEMS GIVE PROTECTION
        //:C384;DRAGADUNE HOLDS MANY GEMS
        //:C39E;DONATIONS HELP ON JUDGEMENT DAY
        //:C3BE;AGAR LIVES BEHIND THE INN
        //:C3D8;FIND THE PRISONER
        //:C3EA;BARRIERS GUARD WEALTH
        //:C400;THE MAGIC TOTAL IS 34
        //seg000:273B:C416;ALL PORTALS ARE CONNECTED
        //:C430;SORPIGAL HAS 8 STATUES
        //:C447;THE BROTHERS LIVE BY DOCKS
        //:C462;SOME CAVES HAVE MORE THAN ONE EXIT
        //:C485;THE ICE PRINCESS HAS THE KEY
        //:C4A2;THE DESERT HAS MANY OASES
        //:C4BC;THE SWAMP WAS ONCE A CITY OF GOLD
        //:C4DE;PORTSMITH AND MEN DON'T MIX
        //:C4FA;MOST TOWNS HAVE CAVERNS BELOW
        //:C518;VARN IS NOT WHAT IT APPEARS TO BE
        //:C53A;KILBURN IS NEAR THE WYVERN PEAKS
        //:C55B;A DRAGONS BREATH IS ONLY AS STRONGЌAS IT'S CONDITION
        //:C590;THE KING IS
        //:C59C;IN SECLUSION
        //:C5A9;THE INNER SANCTUM IS A MYTH
        //:C5C5;THE CANINE HAS THE KEY
      }),
      new txtAddresses("sorpigal.ovr", new addrPair[] {
        new addrPair(0x0063), //:C5EC+03E7=C9D3; THE INNKEEPER ASKS:\n"WOULD...
        new addrPair(0x00CC), //:C5EC+041E=CA0A;A SIGN ABOVE THE DOOR READS:...
        new addrPair(0x0095), //:C5EC+043C=CA28;"EULARDS FINE FOODS"        ...
        new addrPair(0x00A7), //:C5EC+0451=CA3D;"B AND B BLACKSMITHS"       ...
        new addrPair(0x00B5), //:C5EC+0467=CA53;"THE INN OF SORPIGAL"       ...
        new addrPair(0x00E0), //:C5EC+047D=CA69;A MAN WEARING A LEATHER APRO...
        new addrPair(0x00F3), //:C5EC+04F2=CADE;BEHIND THE COUNTER, AN OVERW...
        new addrPair(0x012B), //:C5EC+056A=CB56;STEP UP TO THE BAR(Y/N)?    ...
        new addrPair(0x013E), //:C5EC+0584=CB70;SEVERAL ORNATELY ROBED CLERI...
        new addrPair(0x0151), //:C5EC+05DC=CBC8;BEFORE YOU ARE VARIOUS GROUP...
        //...
        new addrPair(0x0176), //:C5EC+0667=CC53; A TENACIOUS LEPRECHAUN APPE...
        new addrPair(0x0225), //:C5EC+0742=CD2E;STAIRS GOING DOWN! TAKE THEM...
        //...
        new addrPair(0x027D),  //:C5EC+0767=CD53;THERE IS A STATUE HERE, SEA...
        new addrPair(0x02A7,0x02A5),  //:C5EC+0790=CD7C;"YE OLDE HOGGE TAVERN"
        new addrPair(0x0297,0x0295),  //:C5EC+07A7=CD93;"TEMPLE MOONSHADOW"
        new addrPair(0x02AF,0x02AD),  //:C5EC+07BB=CDA7;"OTTO'S TRAINING"
        new addrPair(0x029F,0x029D),  //:C5EC+07CD=CDB9;"JAIL, KEEP OUT!"
        new addrPair(0x0106), //:C5EC+07DF=CDCB;A PASSAGE LEADS OUTSIDE, TAK...
        new addrPair(0x02EC), //:C5EC+0807=CDF3;TRAP DOOR!
        new addrPair(0x02FC), //:C5EC+0812=CDFE;, LEVITATION SAVES YOU!
      }),
      new txtAddresses("alamar.ovr",   new addrPair[] {
        new addrPair(0x0061), //:C4EB+04E4=C9CF:A CHUTE...
        new addrPair(0x01F6), //:C4EB+04F0=C9DB:A CATAPULT EJECTS YOU FROM T...
        new addrPair(0x0289), //:C4EB+0516=CA01:OPTIONS:  1) SET THE PRISONE...
        new addrPair(0x0297), //:C4EB+053B=CA26:2) TORMENT THE PRISONER.\n
        new addrPair(0x02A5), //:C4EB+0555=CA40:3) LEAVE WITHOUT DISTURBING.
        new addrPair(0x02C1), //:C4EB+0572=CA5D:THE PRISONER FLEES!
        new addrPair(0x02D6), //:C4EB+0586=CA71:THE PRISONER COWERS!
        new addrPair(0x0280), //:C4EB+059B=CA86:INSIDE A STEEL CAGE,A FAIR M...
        new addrPair(0x024E), //:C4EB+05C6=CAB1:A PASSAGE LEADS OUTSIDE, TAK...
        new addrPair(0x0083), //:C4EB+05EE=CAD9:ETCHED IN SILVER, MESSAGE E ...
        new addrPair(0x01CC), //:C4EB+0626=CB11:"YOU'VE DISCOVERED MY TRUE I...
        new addrPair(0x00E3), //:C4EB+0669=CB54:"MY SAVIORS, YOU'RE ALWAYS W...
        new addrPair(0x0168), //:C4EB+06CE=CBB9:"VARNLINGS, I QUEST THEE TO ...
        new addrPair(0x00FF), //:C4EB+0718=CC03:THE OMNIPOTENT KING ALAMAR S...
        new addrPair(0x00CC), //:C4EB+073D=CC28:KINGS GUARDS APPROACH.\n"NO ...
        new addrPair(0x0385), //:C4EB+0775=CC60:CASTLE GUARDS EXCLAIM,\n"NO ...
        new addrPair(0x023E), //:C4EB+07B2=CC9D:A LOUD SCREAM FROM BEHIND TH...
        new addrPair(0x0219), //:C4EB+07D6=CCC1:SINGE! ACID TRAP.
        new addrPair(0x0236), //:C4EB+07E8=CCD3:BOOM! A FIERY EXPLOSION.
        new addrPair(0x0412), //:C4EB+0801=CCEC:THRONE ROOM
      }),
      new txtAddresses("algary.ovr",   new addrPair[] {
        new addrPair(0x010C       ), // A SIGN ABOVE THE DOOR READS:\n         
        new addrPair(0x0186       ), // STEP UP TO THE BAR (Y/N)?
        new addrPair(0x02E2,0x02E0), // "YE OLD DOCKS"
        new addrPair(0x0158       ), // PASSAGE OUTSIDE, EXIT (Y/N)?
        new addrPair(0x0063       ), // STANDING BEHIND A LARGE DESK, A TALL...
        new addrPair(0x0120       ), // A MAN ENCLOSED IN A STEEL CAGE SAYS,...                                        
        new addrPair(0x02EA,0x02E8), // "ARCON'S SLOP"
        new addrPair(0x02F2,0x02F0), // "SWAMPSIDE SUPPLIES"
        new addrPair(0x02FA,0x02F8), // "THE INN OF ALGARY"
        new addrPair(0x013C       ), // A PUTRID SMELL PERVADES THE ROOM...\...
        new addrPair(0x01A2       ), // AN ANCIENT LOOKING CLERIC STAGGERS U...
        new addrPair(0x01BE       ), // SEVERAL ADVENTURERS ARMORED IN DRAGO...               
        new addrPair(0x030A,0x0308), // "JOLLY JESTER TAVERN"
        new addrPair(0x0302,0x0300), // "TEMPLE HALF-DEAD"
        new addrPair(0x0312,0x0310), // "DRAGONS CLAW TRAINING"
        new addrPair(0x0094       ), // "I AM ZOM, ASTRAL BROTHER OF ZAM.\n
        new addrPair(0x00D3       ), // MY CLUE IS 1-15."
        new addrPair(0x00C6       ), // YOU'RE NOT THE COURIERS!"
        new addrPair(0x01DB       ), // MORANGO THE MYSTIC ASKS,\n"WHO SHALL...
        new addrPair(0x020C       ), // % RESISTANCE FOR 
        new addrPair(0x0227       ), // MAGIC     FIRE     COLD       ELEC\n...
        new addrPair(0x033A       ), // NOTE: ZOM 1,1
        new addrPair(0x0347       ), // SWAZE PIT! JUMP IN (Y/N)?
        new addrPair(0x0364       ), // A MAGIC PORTAL! ENTER (Y/N)?
      }),
      new txtAddresses("areaa1.ovr",   new addrPair[] {
        new addrPair(0x011E), // CARVED ON A BLOCK OF ICE ARE THE WORDS:\nST...
        new addrPair(0x0135), // A SECRET PASSAGE TO DOOM, TAKE IT (Y/N)?
        new addrPair(0x0151), // THE POOL OF HEALTH GRANTS THOSE WHO ARE\nWO...
        new addrPair(0x00B9), // YOU'VE BEEN SURROUNDED BY THE DARK RIDERAND...
        new addrPair(0x01C7), // THE FABELED CASTLE DOOM!\nWILL YOU ENTER (Y...                                               
      }),
      new txtAddresses("areaa2.ovr",   new addrPair[] {
        new addrPair(0x005D), // LAVA FILLS THE VALLEY OF FIRE!
        new addrPair(0x0098), // THE DRAGONS BODY DISAPPEARS, EXCEPT\nFOR A ...
        new addrPair(0x00F3), // A PIRATES SECRET COVE, SEARCH (Y/N)?
        new addrPair(0x01A7), // I AM PERCELLA THE DRUID AND I HAVE WHAT\nYO...
        new addrPair(0x01BE), // THEN MEET MY PETS!
        new addrPair(0x0229), // IT'S HOT!
      }),
      new txtAddresses("areaa3.ovr",   new addrPair[] {
        new addrPair(0x01C0), // LOSER!\n
        new addrPair(0x021F), // GEMS!\n
        new addrPair(0x02BA), // GOLD!\n
        new addrPair(0x0270), // EXP!\n
        new addrPair(0x00D0), // THE WATER ERUPTS VIOLENTLY,\nREVEALING A TR...
        new addrPair(0x011D), // EMBEDDED IN THE SIDE OF THE MOUNTAIN IS\nA ...
      }),
      new txtAddresses("areaa4.ovr",   new addrPair[] {
        new addrPair(0x00F5), // 1) RED THORAC       2) BLUE OGRAM\n3) GREEN...
        new addrPair(0x006D), // A WOODEN BRIDGE EXTENDES ACROSS THE\nOCEAN ...
        new addrPair(0x00E2), // ,WHAT IS YOUR COLOR(1-8)?
        new addrPair(0x0133), // WRONG!
        new addrPair(0x0147), // CORRECT!
        new addrPair(0x005D), // ATOP THIS PEAK 5 ISLANDS CAN BE SEEN\nTO TH...
        new addrPair(0x01C6), // A TIDAL WAVE SWEEPS THE PARTY AWAY!
      }),
      new txtAddresses("areab1.ovr",   new addrPair[] {
        new addrPair(0x0060       ), // CAVERNOUS PASSAGE TO ERLIQUIN,\nTAKE...
        new addrPair(0x0118       ), // A CAVE, ENTER (Y/N)?
        new addrPair(0x0178       ), // CASTLE BLACKRIDGE NORTH, ENTER (Y/N)?
        new addrPair(0x01CD       ), // CASTLE BLACKRIDGE SOUTH, ENTER (Y/N)?
        new addrPair(0x01F4       ), // ANCIENT RUINS OF A DESERTED WIZARDS ...
        new addrPair(0x00B4       ), // THE GATES TO ANOTHER WORLD!\n
        new addrPair(0x00F9       ), // CONGRATULATIONS DISTINGUISHED \nTRAV...
        new addrPair(0x0092,0x0090), // A SIGN POINTING S. READS: BLACKRIDGE N.
        new addrPair(0x009B,0x0099), // A SIGN POINTING E. READS: BLACKRIDGE S.
        new addrPair(0x00A4,0x00A2), // A SIGN POINTING E. READS: ERLIQUIN.      
      }),
      new txtAddresses("areab2.ovr",   new addrPair[] {
        new addrPair(0x0146), // WRONG, YOU'RE TOO YOUNG TO UNDERSTAND.
        new addrPair(0x00D4), // CORRECT!
        new addrPair(0x0161), // CARVED ON A TREE: "9-9 RAVEN'S LAIR"
        new addrPair(0x01F9), // THERE'S A CAVE HERE, ENTER (Y/N)?
        new addrPair(0x022C), // A DESCENDING STAIRCASE IS THE ENTRANCE\nTO ...
        new addrPair(0x0068), // ON A THRONE ADORNED WITH PRECIOUS GEMS\nTHE...
      }),
      new txtAddresses("areab3.ovr",   new addrPair[] {
        new addrPair(0x0073), // PASSAGE TO PORTSMITH, TAKE IT (Y/N)?
        new addrPair(0x011C), // A CAVE, ENTER (Y/N)?
        new addrPair(0x017B), // CASTLE WHITE WOLF, ENTER (Y/N)?
        new addrPair(0x01EE), // YOUR RUBY WHISTLE BEGINS TO GLOW,\nBLOW IT ...
        new addrPair(0x0224), // STAIRS GOING DOWN, ENTER (Y/N)?
        new addrPair(0x019F), // AN ANCIENT TEMPLE CONVERTED TO A\nSTRONGHOL...
        new addrPair(0x00BC), // ATOP THIS PEAK LOOKING:\n\nN= A CAVE BEYOND...
        new addrPair(0x00A1), // A SIGN POINTING N. READS: WHITE WOLF
        new addrPair(0x00A7), // A SIGN POINTING S. READS: PORTSMITH
      }),
      new txtAddresses("areab4.ovr",   new addrPair[] {
        new addrPair(0x012E), // TRIVIA ISLAND! 500 GOLD, ENTER (Y/N)?
        new addrPair(0x019A), // NOT ENOUGH GOLD!
        new addrPair(0x0076), // PIRATE GHOSTSHIP ANARCHIST!
        new addrPair(0x04A9), // WHO RULES CASTLE W.W.?
        new addrPair(0x04AB), // WHO IS THE VOLUPTUOUS ONE?
        new addrPair(0x04AD), // WHO'S LOST SIGHT?
        new addrPair(0x04AF), // WHERE'S THE VERY LATEST?
        new addrPair(0x04B1), // WHO BE YE?
        new addrPair(0x010A), // FREE TRIVIA CHANCE, PULL BRANCH (Y/N)?
        new addrPair(0x02C7), // CORRECT!+50 GEMS
        new addrPair(0x02EE), // WRONG!
      }),
      new txtAddresses("areac1.ovr",   new addrPair[] {
        new addrPair(0x01DA), // AMBUSH!
        new addrPair(0x016B), // DESERTED MERCHANT WAGONS, SEARCH (Y/N)?
        new addrPair(0x02B3), // TODAY SPELLS!
        new addrPair(0x024B), // ARGHHH... POISON!
        new addrPair(0x027F), // TODAY MIGHT!
        new addrPair(0x01F1), // A FOUNTAIN SPEAKS:\n"WILL THE PARTY DRINK (...
        new addrPair(0x009D), // YOU FOUND A CHEST UPON WHICH AN\nINSCRIPTIO...
        new addrPair(0x015E), // ROADSIGN: SORPIGAL S.17, W.1, N.2
      }),
      new txtAddresses("areac2.ovr",   new addrPair[] {
        new addrPair(0x0076), // A CAVERNOUS PASSAGE LEADS TO SORPIGAL,\nTAK...
        new addrPair(0x0128), // A PIT!....
        new addrPair(0x0138), // YOUR LEVITATION SAVED YOU!
        new addrPair(0x0145), // AN AMBUSH!
        new addrPair(0x0189), // A GLOWING WHITE COLUMN, TOUCH IT (Y/N)?
        new addrPair(0x01B5), // STATUES BLOCK THE PATH,SMASH THEM (Y/N)?
        new addrPair(0x022B), // A STRANGE FOUNTAIN, DRINK (Y/N)?
        new addrPair(0x027E), // CHEERS!
        new addrPair(0x0295), // AVALANCHE!
        new addrPair(0x02D5), // THERE'S A CAVE HERE, ENTER (Y/N)?
        new addrPair(0x00A7), // A TOOTHLESS GYPSY SEER ASKS,"WHO WOULD\nLIK...
        new addrPair(0x00FC), // "YOUR SIGN IS THE 
        new addrPair(0x05AC), // RED THORAC"
        new addrPair(0x05AE), // BLUE OGRAM"
        new addrPair(0x05B0), // GREEN BAGAR"
        new addrPair(0x05B2), // YELLOW LIMRA"
        new addrPair(0x05B4), // PURPLE SAGRAN"
        new addrPair(0x05B6), // ORANGE OOLAK"
        new addrPair(0x05B8), // BLACK DRESIDION"
        new addrPair(0x05BA), // WHITE DILITHIUM"
        new addrPair(0x003B), // LOOK OUT!
      }),
      new txtAddresses("areac3.ovr",   new addrPair[] {
        new addrPair(0x0135), // WYVERNS ATTACK FROM ABOVE!
        new addrPair(0x00B0), // ONE OF THE WYVERN'S EYES BEGINS TO GLOW!TAK...
        new addrPair(0x0060), // ROADSIGN: SORPIGAL N.22, W.2, N.2
        new addrPair(0x0075), // THE EXILED LORD KILBURN SPEAKS:\n"TAKE THIS...
        new addrPair(0x01A0), // *** BACKPACKS FULL!
        new addrPair(0x00D3), // A WYVERN'S LAIR, INVESTIGATE (Y/N)?
        new addrPair(0x0151), // PAINTED IN A BLACK AND WHITE PATTERN,\nA SI...
        new addrPair(0x01CA), // THE HERMIT SAYS: "TRADE WARES (Y/N)?"
      }),
      new txtAddresses("areac4.ovr",   new addrPair[] {
        new addrPair(0x008F), // A LARGE SLAB OF CORAL BLOCKS A PASSAGE!\n
        new addrPair(0x00D8), // YOUR CORAL KEY FITS PERFECTLY\nIN THE LOCK,...
        new addrPair(0x018B), // AT THE WATERS EDGE ARE THE DECAYING\nREMAIN...
        new addrPair(0x0226), // CRAZED NATIVES ATTACK!
        new addrPair(0x02AF), // THE VOLCANO ERUPTS!
        new addrPair(0x0275), // PIRATES ATTACK!
        new addrPair(0x020E), // MYSTERIOUS WEEPING ECHOES THROUGHOUT!
        new addrPair(0x01BC), // THE JOLLY RAVEN!
        new addrPair(0x005D), // PORTAL OF POWER, ENTER (Y/N)?
      }),
      new txtAddresses("aread1.ovr",   new addrPair[] {
        new addrPair(0x00CA), // SUDDENLY, A GARGANTUAN SCORPION ATTACKS!
        new addrPair(0x0121), // A SMALL TRIBE OF DESERT NOMADS HAVE\nESTABL...
        new addrPair(0x0152), // YOUR LEADER HAS NOTHING TO TRADE!
        new addrPair(0x0177), // KILBURN,C-3 6-14
        new addrPair(0x0184), // IT'S HOT... 
        new addrPair(0x0242), // YOU'RE LOST!!!
        new addrPair(0x02EE), // A WHIRLWIND SWOOPS THE PARTY AWAY!
        new addrPair(0x0315), // A VIOLENT SANDSTORM BLASTS THE PARTY!
      }),
      new txtAddresses("aread2.ovr",   new addrPair[] {
        new addrPair(0x0073), // THE POOL OF WISDOM GRANTS THOSE WHO ARE\nWO...
        new addrPair(0x00D0), // CLERICAL RETREAT
        new addrPair(0x0212), // WE ARE THE CLERICS OF THE 
        new addrPair(0x00E2), // YOUR PARTY IS CURED!
        new addrPair(0x014C), // YOUR ALIGNMENT IS RESTORED!
        new addrPair(0x018F), // ALL CURSES ARE REMOVED!
        new addrPair(0x0202), // THE CLERICS OF THE S. SHALL DEEM YOU\nWORTH...
        new addrPair(0x022C), // IT'S HOT... 
        new addrPair(0x0301), // YOU'RE LOST!!!
      }),
      new txtAddresses("aread3.ovr",   new addrPair[] {
        new addrPair(0x00DA), // A CAVE, ENTER (Y/N)?
        new addrPair(0x013B), // CLIMB TREE (Y/N)?
        new addrPair(0x0071), // I AM ARENKO GUIRE AND THIS IS MY GROVE.\nCL...
        new addrPair(0x0095), // WELL DONE! WHAT IS YOUR PLEASURE?\nA) GOLD ...
        new addrPair(0x024C), // +5 FOOD
        new addrPair(0x0126), // POISON THORNS
        new addrPair(0x0118), // YOU FELL
        new addrPair(0x0211), // LIGHTNING
        new addrPair(0x0205), // INFECTIOUS SAP
        new addrPair(0x01F7), // FLASH
        new addrPair(0x019A), // POOF
        new addrPair(0x012C), // NOTHING HERE.
        new addrPair(0x0191), // CURSED
        new addrPair(0x008A), // KEEP CLIMBING.
        new addrPair(0x02E8), // ROADSIGN: ALGARY S.9
      }),
      new txtAddresses("aread4.ovr",   new addrPair[] {
        new addrPair(0x005D), // ALGARY, ENTER (Y/N)?
        new addrPair(0x0156), // PAUL PEAD AND HIS MEN ATTACK!
        new addrPair(0x00FF), // A HUGE WINGED BEAST EXCLAIMS,\n"THIS SWAMP ...
        new addrPair(0x0204), // OG SAYS, "BEGONE!"
        new addrPair(0x0248), // PAINTED ON THESE GROUNDS IS A BLACK &\nWHIT... 
        new addrPair(0x02AF), // YOU HAVE RESTORED MY SIGHT! (+25000 EXP)I S...                                              
      }),
      new txtAddresses("areae1.ovr",   new addrPair[] {
        new addrPair(0x005D), // PASSAGE TO DUSK, ENTER (Y/N)?
        new addrPair(0x008D), // RUINS OF CASTLE DRAGADUNE, ENTER (Y/N)?
        new addrPair(0x00D0), // IT'S HOT... 
        new addrPair(0x018E), // YOU'RE LOST!!!
        new addrPair(0x023A), // A WHIRLWIND SWOOPS THE PARTY AWAY!
        new addrPair(0x0261), // A VIOLENT SANDSTORM BLASTS THE PARTY!
        new addrPair(0x02C4), // AT THE CENTER OF THE LAND THAT TIME\nFORGOT...
        new addrPair(0x0369), // NOT WORTHY!
        new addrPair(0x0376), // YOUR ACTIONS REFLECT YOUR VIEWS   OF 6\n+
        new addrPair(0x0323), // STATUE OF A GIANT HOLDING THE SCALE OF\nJUD...
        new addrPair(0x0636), // INTELLECT
        new addrPair(0x0638), // MIGHT
        new addrPair(0x063A), // PERSONALITY
        new addrPair(0x063C), // ENDURANCE
        new addrPair(0x063E), // SPEED
        new addrPair(0x0640), // ACCURACY
        new addrPair(0x0642), // LUCK
        new addrPair(0x03C8), // EXPERIENCE
      }),
      new txtAddresses("areae2.ovr",   new addrPair[] {
        new addrPair(0x01B5), // IT'S HOT... 
        new addrPair(0x0282), // YOU'RE LOST!!!
        new addrPair(0x005D), // STRANGE ALIEN DEVICE GRANTS THOSE WHO\nARE ...
        new addrPair(0x00F4), // SCATTERED REMAINS OF A METALLIC CRAFT!\nAN ...
        new addrPair(0x00E5), // A BRIGHT FLASH!
        new addrPair(0x010F), // "VARNLINGS TAKE HEED! OUR PRISONER HAS\nESC...
        new addrPair(0x018D), // POOF!
      }),
      new txtAddresses("areae3.ovr",   new addrPair[] {
        new addrPair(0x01F7), // KING ALAMAR'S CASTLE, ENTER (Y/N)?
        new addrPair(0x008E), // A DIAMOND DOOR!
        new addrPair(0x00C4), //  USE YOUR KEY (Y/N)?
        new addrPair(0x00F2), // STATUE OF A LION GROWLS,"PASSWORD?"\nRESPON...
        new addrPair(0x01AE), // IS THE PASSWORD FOR TODAY,\nLEAVE THE AREA ...
        new addrPair(0x017E), // HERATIO HARPER SINGS:\n"
        new addrPair(0x004F), // DISTANT HARP MUSIC...
        new addrPair(0x03C2), // MUSICAL
        new addrPair(0x03C4), // TONES
        new addrPair(0x03C6), // TOGETHER
        new addrPair(0x03C8), // CLERICS
        new addrPair(0x03CA), // SOUTH
        new addrPair(0x03CC), // DEEM
        new addrPair(0x03CE), // WORTHY
        new addrPair(0x0060), // TRESPASSING!
        new addrPair(0x015F), // CORRECT! YOU MAY PASS.
      }),
      new txtAddresses("areae4.ovr",   new addrPair[] {
        new addrPair(0x0159), // THE FABLED BUILDING OF GOLD,\nENTER (Y/N)?
        new addrPair(0x0218), // ECTOPLASMIC SLIME SLUSHES BENEATH YOU!\n
        new addrPair(0x01E4), // TOPPLED TOMBSTONES ABOUND!
        new addrPair(0x00A8), // UNEARTHED COFFIN! EXAMINE (Y/N)?
        new addrPair(0x0114), // OPEN CRYPT! EXAMINE (Y/N)?
        new addrPair(0x012A), // HALF BURIED CORPSE ASKS FOR HELP!\nASSIST (...
        new addrPair(0x005D), // DRAGON CITY, TOWN MEETING...\nDISRUPT (Y/N)?
        new addrPair(0x0273), // QUICKSAND!
        new addrPair(0x0142), // THANKS! IT AIN'T EASY BEING A CORPSE!\nTAKE...
      }),
      new txtAddresses("astral.ovr",   new addrPair[] {
        new addrPair(0x0097), // ASTRAL PROJECTOR # 
        new addrPair(0x00A8), //  , ZAP!
        new addrPair(0x0062), // THERE'S A SMALL SLOT IN THE DOOR.\n
        new addrPair(0x0127), // NO ADMITTANCE!
        new addrPair(0x0165), // KEY CARD IS REJECTED!
        new addrPair(0x006E), // KEY CARD IS ACCEPTED!
        new addrPair(0x007B), // THE METALLIC ROOM IS DIMLY LIT BY\nA PULSAT...
        new addrPair(0x019A), // IN A SERENE VOICE, THE DATA KEEPER SAYS,"WE...
        new addrPair(0x0275), // "YOU ARE NOT YET WORTHY FOR TRANSFER.   RET...
        new addrPair(0x01A6), // EXCELLENT RATING! THIS IS A RARE        OCC...
        new addrPair(0x0173), // A METALLIC PANEL SLIDES OPEN, REVEALING\nA ...
        new addrPair(0x0187), // :::INNER SANCTUM:::
      }),
      new txtAddresses("blackrn.ovr",  new addrPair[] {
        new addrPair(0x0063), // EXIT CASTLE, (Y/N)?
        new addrPair(0x01A7), // CASTLE GUARDS EXCLAIM,\n"NO MERCHANTS PASS!...
        new addrPair(0x023B), // WELL DONE, QUEST COMPLETE! +
        new addrPair(0x0259), //  EXP
        new addrPair(0x05AF), // FIND THE ANCIENT RUINS IN THE\nQUIVERING FO...
        new addrPair(0x05B1), // VISIT BLITHES PEAK, AND REPORT
        new addrPair(0x05B3), // THE PEOPLE OF THE DESERT HAVE MUCH TO\nTRAD...
        new addrPair(0x05B5), // FIND THE SHRINE OF OKZAR IN THE\nCAVES BELO...                           
        new addrPair(0x05B7), // FIND THE FABLED FOUNTAIN IN DRAGADUNE
        new addrPair(0x05B9), // SOLVE THE RIDDLE OF THE RUBY
        new addrPair(0x05BB), // DEFEAT THE STRONGHOLD\nIN THE ENCHANTED FOR...
        new addrPair(0x029C), // LORD INSPECTRON SPEAKS:\n
        new addrPair(0x02E1), // "YOUR SERVICES ARE NEEDED!"ACCEPT (Y/N)?
        new addrPair(0x0287), // "RETURN NOT UNTIL THY QUEST IS COMPLETE"
        new addrPair(0x02CA), // "SORRY, BUT SINCE YOU ARE CURRENTLY\nQUESTE...
        new addrPair(0x00AB), // OPTIONS:  1) SET THE PRISONER FREE.\n
        new addrPair(0x00B9), // 2) TORMENT THE PRISONER.\n
        new addrPair(0x00C7), // 3) LEAVE WITHOUT DISTURBING.
        new addrPair(0x00EA), // THE PRISONER FLEES!
        new addrPair(0x00F8), // THE PRISONER COWERS!
        new addrPair(0x00A2), // MAN IN SHACKLES MOANS IN AGONY!\n\n
        new addrPair(0x0088), // ETCHED IN SILVER, MESSAGE A READS:\nATIS-19...
        new addrPair(0x0446), // A SLIDE!
        new addrPair(0x0465), // EMPTY VAULT, ALARM!
      }),
      new txtAddresses("blackrs.ovr",  new addrPair[] {
        new addrPair(0x0063), // EXIT CASTLE, (Y/N)?
        new addrPair(0x01B5), // CASTLE GUARDS EXCLAIM,"BEGONE PEASANTS!"
        new addrPair(0x0243), // WELL DONE, QUEST COMPLETE! +
        new addrPair(0x0261), //  EXP
        new addrPair(0x045B), // MY BREW IS COMPLETE, GUARDS TAKE THEIR\nITE...
        new addrPair(0x02E9), // "YOUR SERVICES ARE NEEDED!"ACCEPT (Y/N)?
        new addrPair(0x028F), // "RETURN NOT UNTIL THY QUEST IS COMPLETE"(LE...
        new addrPair(0x02D2), // "SORRY, YOU'RE ALREADY QUESTED.
        new addrPair(0x00B9), // OPTIONS:  1) SET THE PRISONER FREE.\n
        new addrPair(0x00C7), // 2) TORMENT THE PRISONER.\n
        new addrPair(0x00D5), // 3) LEAVE WITHOUT DISTURBING.
        new addrPair(0x00F8), // THE PRISONER FLEES!
        new addrPair(0x0106), // THE PRISONER COWERS!
        new addrPair(0x0481), // A SLIDE!
        new addrPair(0x0495), // THE PIT OF PERIL...
        new addrPair(0x04BF), // EMPTY VAULT, ALARM!
        new addrPair(0x034D), // BRING ME 
        new addrPair(0x0608), // GARLIC
        new addrPair(0x060A), // WOLFSBANE
        new addrPair(0x060C), // BELLADONNA
        new addrPair(0x060E), // THE HEAD OF A MEDUSA
        new addrPair(0x0610), // AN EYE OF A WYVERN
        new addrPair(0x0612), // A DRAGONS TOOTH
        new addrPair(0x0614), // THE RING OF OKIRM
        new addrPair(0x02A4), // LORD HACKER SPEAKS:\n
        new addrPair(0x00B0), // A MYSTERIOUS CLOAKED FIGURE, BOUND AND\nGAG...
        new addrPair(0x0088), // ETCHED IN SILVER, MESSAGE C READS:\nIACI1;-...
      }),
      new txtAddresses("cave1.ovr",    new addrPair[] {
        new addrPair(0x0060), // STAIRS GOING UP! TAKE THEM (Y/N)?
        new addrPair(0x0127), // AN ELDERLY MAN BEHIND A DESK SPEAKS:\"I AM ...
        new addrPair(0x0141), // "I SEE YOU HAVEN'T DELIVERED MY MESSAGE,\CA...
        new addrPair(0x016B), // "GOOD! TAKE THIS SCROLL TO THE\WIZARD AGAR ...
        new addrPair(0x01A8), // "THE ARENA"
        new addrPair(0x01BF), // AROUND THE ROOM THERE ARE SEVERAL\BALCONIES...
        new addrPair(0x0256), // A SIGN ABOVE THE DOOR READS:
        new addrPair(0x0323), // *** BACK PACKS FULL ***
        new addrPair(0x0177), // A SHIMMERING BLUE AND WHITE PORTAL\APPEARS!...
        new addrPair(0x03A4), // SCRAWLED ON THE WALL, A MESSAGE READS:\
        new addrPair(0x0228), // DON'T TURN AROUND!
        new addrPair(0x0213), // THE JAIL ABOVE HAS MANY CELLS.
      }),
      new txtAddresses("cave2.ovr",    new addrPair[] {
        new addrPair(0x005D), // SHIMMERING BLUE AND WHITE PORTAL,\ENTER (Y/N)?
        new addrPair(0x0090), // A SLIDE!
        new addrPair(0x00C8), // SPLASH! A POOL OF ACID!
        new addrPair(0x0136), // BUTTON ON THE WALL, PRESS IT (Y/N)?
        new addrPair(0x0156), // POOF!
        new addrPair(0x0175), // A BANNER READS:\CORRIDOR OF ENDLESS ENCOUNT...
        new addrPair(0x01D7), // A CRAZED WIZARD EXCLAIMS,\"ENCOUNTER THE 13...
        new addrPair(0x0204), // PASSAGE OUTSIDE, EXIT (Y/N)?
      }),
      new txtAddresses("cave3.ovr",    new addrPair[] {}),
      new txtAddresses("cave4.ovr",    new addrPair[] {}),
      new txtAddresses("cave5.ovr",    new addrPair[] {}),
      new txtAddresses("cave6.ovr",    new addrPair[] {}),
      new txtAddresses("cave7.ovr",    new addrPair[] {}),
      new txtAddresses("cave8.ovr",    new addrPair[] {}),
      new txtAddresses("cave9.ovr",    new addrPair[] {}),
      new txtAddresses("demon.ovr",    new addrPair[] {}),
      new txtAddresses("doom.ovr",     new addrPair[] {}),
      new txtAddresses("dragad.ovr",   new addrPair[] {}),
      new txtAddresses("dusk.ovr",     new addrPair[] {}),
      new txtAddresses("enf1.ovr",     new addrPair[] {}),
      new txtAddresses("enf2.ovr",     new addrPair[] {}),
      new txtAddresses("erliquin.ovr", new addrPair[] {}),
      new txtAddresses("mm.exe",       new addrPair[] {}),
      new txtAddresses("portsmit.ovr", new addrPair[] {}),
      new txtAddresses("pp1.ovr",      new addrPair[] {}),
      new txtAddresses("pp2.ovr",      new addrPair[] {}),
      new txtAddresses("pp3.ovr",      new addrPair[] {}),
      new txtAddresses("pp4.ovr",      new addrPair[] {}),
      new txtAddresses("qvl1.ovr",     new addrPair[] {}),
      new txtAddresses("qvl2.ovr",     new addrPair[] {}),
      new txtAddresses("rwl1.ovr",     new addrPair[] {}),
      new txtAddresses("rwl2.ovr",     new addrPair[] {}),
      new txtAddresses("udrag1.ovr",   new addrPair[] {}),
      new txtAddresses("udrag2.ovr",   new addrPair[] {}),
      new txtAddresses("udrag3.ovr",   new addrPair[] {}),
      new txtAddresses("whitew.ovr",   new addrPair[] {}),
    };

    public string[] lstFNames = {
      "alamar.ovr",
      "algary.ovr",
      "areaa1.ovr",
      "areaa2.ovr",
      "areaa3.ovr",
      "areaa4.ovr",
      "areab1.ovr",
      "areab2.ovr",
      "areab3.ovr",
      "areab4.ovr",
      "areac1.ovr",
      "areac2.ovr",
      "areac3.ovr",
      "areac4.ovr",
      "aread1.ovr",
      "aread2.ovr",
      "aread3.ovr",
      "aread4.ovr",
      "areae1.ovr",
      "areae2.ovr",
      "areae3.ovr",
      "areae4.ovr",
      "astral.ovr",
      "blackrn.ovr",
      "blackrs.ovr",
      "cave1.ovr",
      "cave2.ovr",
      "cave3.ovr",
      "cave4.ovr",
      "cave5.ovr",
      "cave6.ovr",
      "cave7.ovr",
      "cave8.ovr",
      "cave9.ovr",
      "demon.ovr",
      "doom.ovr",
      "dragad.ovr",
      "dusk.ovr",
      "enf1.ovr",
      "enf2.ovr",
      "erliquin.ovr",
      "mm.exe",
      "portsmit.ovr",
      "pp1.ovr",
      "pp2.ovr",
      "pp3.ovr",
      "pp4.ovr",
      "qvl1.ovr",
      "qvl2.ovr",
      "rwl1.ovr",
      "rwl2.ovr",
      "sorpigal.ovr",
      "udrag1.ovr",
      "udrag2.ovr",
      "udrag3.ovr",
      "whitew.ovr"
    };

    public ObservableCollection<text> dt { get; set; }
    public List<locText> locTexts = new List<locText>();

    public void changeFile(string fName) {
      locText lt = locTexts.Find(x => x.fName == fName);
      if (lt != null) dt = lt.dt; else dt.Clear();
    }

    public void FillCollectionFromFiles(string origPath) {
      collectionFile = "";
      dt.Clear();

      foreach (string s in lstFNames) {
        locText lt = new locText(s);
        locTexts.Add(lt);
        byte[] bb;
        try {
          bb = File.ReadAllBytes(Path.Combine(origPath, s));
        } catch { return; }

        txtAddresses ta = textAddresses.Find(x => x.fName == s);
        if (ta == null) continue;

        foreach (addrPair i in ta.addresses) {
          bool mmexe = s == "mm.exe";
          text txt = new text();
          txt.addrOfAddr = i;
          txt.addrOfSeg = mmexe ? seg001 : 0;
          var tmpOffset = 0xC940 - BBToShort(bb, 4) - 0x0E;
          txt.addrInSeg = (ushort)
            (BBToShort(bb[i.l], bb[i.h]) - (mmexe ? 0 : tmpOffset));

          int strAddr = txt.addrOfSeg + txt.addrInSeg;
          int strAddrL = getStrLen(bb, strAddr);
          txt.originalText = strAddrL > 0 ?
            Encoding.ASCII.GetString(bb, strAddr, strAddrL) : "";

          // DEBUG
          switch (txt.addrInSeg) {
            case 0x0E5F: txt.newAddrInSeg = 0x4D0C; txt.localizedText = "TEST0"; break;
            case 0x0EE6: txt.newAddrInSeg = 0x4D14; txt.localizedText = "TEST1"; break;
            case 0x0FA6: txt.newAddrInSeg = 0x4D1C; txt.localizedText = "TEST2"; break;
            case 0x106C: txt.newAddrInSeg = 0x4D24; txt.localizedText = "TEST3"; break;
            case 0x1109: txt.newAddrInSeg = 0x4D2C; txt.localizedText = "TEST4"; break;
          }

          lt.dt.Add(txt);
          if (mmexe) dt = lt.dt;
        }
      }
    }

    private byte[] fontArr = {
      // Оригинальный шрифт
      0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 000 - Пробел
      0x18,0x18,0x18,0x18,0x00,0x18,0x18,0x00, // 001 - !
      0x66,0x66,0x66,0x00,0x00,0x00,0x00,0x00, // 002 - "
      0x00,0x66,0xFF,0x66,0x66,0xFF,0x66,0x00, // 003 - #
      0x18,0x3E,0x60,0x3C,0x06,0x7C,0x18,0x00, // 004 - $
      0x00,0x66,0x6C,0x18,0x30,0x66,0x46,0x00, // 005 - %
      0x1C,0x36,0x1C,0x38,0x6F,0x66,0x3B,0x00, // 006 - &
      0x18,0x18,0x18,0x00,0x00,0x00,0x00,0x00, // 007 - '
      0x0E,0x1C,0x18,0x18,0x18,0x1C,0x0E,0x00, // 008 - (
      0x70,0x38,0x18,0x18,0x18,0x38,0x70,0x00, // 009 - )
      0x00,0x66,0x3C,0xFF,0x3C,0x66,0x00,0x00, // 00A - *
      0x00,0x18,0x18,0x7E,0x18,0x18,0x00,0x00, // 00B - +
      0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x30, // 00C - ,
      0x00,0x00,0x00,0x7E,0x00,0x00,0x00,0x00, // 00D - -
      0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x00, // 00E - .
      0x02,0x06,0x0C,0x18,0x30,0x60,0x40,0x00, // 00F - /
      0x3C,0x66,0x6E,0x7E,0x76,0x66,0x3C,0x00, // 010 - 0
      0x18,0x38,0x18,0x18,0x18,0x18,0x7E,0x00, // 011 - 1
      0x3C,0x66,0x06,0x0C,0x18,0x30,0x7E,0x00, // 012 - 2
      0x7E,0x0C,0x18,0x0C,0x06,0x66,0x3C,0x00, // 013 - 3
      0x0C,0x1C,0x3C,0x6C,0x6C,0x7E,0x0C,0x00, // 014 - 4
      0x7E,0x60,0x7C,0x06,0x06,0x66,0x3C,0x00, // 015 - 5
      0x3C,0x60,0x60,0x7C,0x66,0x66,0x3C,0x00, // 016 - 6
      0x7E,0x06,0x0C,0x18,0x30,0x30,0x30,0x00, // 017 - 7
      0x3C,0x66,0x66,0x3C,0x66,0x66,0x3C,0x00, // 018 - 8
      0x3C,0x66,0x66,0x3E,0x06,0x0C,0x38,0x00, // 019 - 9
      0x00,0x18,0x18,0x00,0x00,0x18,0x18,0x00, // 01A - :
      0x00,0x18,0x18,0x00,0x00,0x18,0x18,0x30, // 01B - ;
      0x06,0x0C,0x18,0x30,0x18,0x0C,0x06,0x00, // 01C - <
      0x00,0x00,0x7E,0x00,0x00,0x7E,0x00,0x00, // 01D - =
      0x60,0x30,0x18,0x0C,0x18,0x30,0x60,0x00, // 01E - >
      0x3C,0x66,0x04,0x0C,0x18,0x00,0x18,0x00, // 01F - ?
      0x7C,0x82,0x9E,0xA2,0x9E,0x80,0x7E,0x00, // 020 - @
      0x18,0x3C,0x66,0x66,0x7E,0x66,0x66,0x00, // 021 - A
      0x7C,0x66,0x66,0x7C,0x66,0x66,0x7C,0x00, // 022 - B
      0x3C,0x66,0x60,0x60,0x60,0x66,0x3C,0x00, // 023 - C
      0x78,0x6C,0x66,0x66,0x66,0x6C,0x78,0x00, // 024 - D
      0x7E,0x60,0x60,0x7C,0x60,0x60,0x7E,0x00, // 025 - E
      0x7E,0x60,0x60,0x7C,0x60,0x60,0x60,0x00, // 026 - F
      0x3E,0x60,0x60,0x6E,0x66,0x66,0x3E,0x00, // 027 - G
      0x66,0x66,0x66,0x7E,0x66,0x66,0x66,0x00, // 028 - H
      0x7E,0x18,0x18,0x18,0x18,0x18,0x7E,0x00, // 029 - I
      0x06,0x06,0x06,0x06,0x06,0x66,0x3C,0x00, // 02A - J
      0x66,0x6C,0x78,0x78,0x6C,0x66,0x66,0x00, // 02B - K
      0x60,0x60,0x60,0x60,0x60,0x60,0x7E,0x00, // 02C - L
      0x63,0x77,0x7F,0x6B,0x63,0x63,0x63,0x00, // 02D - M
      0x66,0x76,0x7E,0x7E,0x6E,0x66,0x66,0x00, // 02E - N
      0x3C,0x66,0x66,0x66,0x66,0x66,0x3C,0x00, // 02F - O
      0x7C,0x66,0x66,0x66,0x7C,0x60,0x60,0x00, // 030 - P
      0x3C,0x66,0x66,0x66,0x66,0x6C,0x36,0x00, // 031 - Q
      0x7C,0x66,0x66,0x7C,0x6C,0x66,0x66,0x00, // 032 - R
      0x3C,0x60,0x60,0x3C,0x06,0x06,0x3C,0x00, // 033 - S
      0x7E,0x18,0x18,0x18,0x18,0x18,0x18,0x00, // 034 - T
      0x66,0x66,0x66,0x66,0x66,0x66,0x7E,0x00, // 035 - U
      0x66,0x66,0x66,0x66,0x66,0x3C,0x18,0x00, // 036 - V
      0x63,0x63,0x63,0x6B,0x7F,0x77,0x63,0x00, // 037 - W
      0x66,0x66,0x3C,0x3C,0x66,0x66,0x66,0x00, // 038 - X
      0x66,0x66,0x66,0x3C,0x18,0x18,0x18,0x00, // 039 - Y
      0x7E,0x0C,0x18,0x30,0x60,0x60,0x7E,0x00, // 03A - Z
      0x00,0x18,0x3C,0x7E,0x18,0x18,0x18,0x00, // 03B - стрелка вверх
      0x00,0x18,0x18,0x18,0x7E,0x3C,0x18,0x00, // 03C - стрелка вниз
      0x00,0x18,0x30,0x7E,0x30,0x18,0x00,0x00, // 03D - стрелка влево
      0x00,0x18,0x0C,0x7E,0x0C,0x18,0x00,0x00, // 03E - стрелка вправо
      0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00, // 03F - _
      // Кириллица
      0x1E,0x36,0x66,0x66,0x7E,0x66,0x66,0x00, // 040 - А
      0x7C,0x60,0x60,0x7C,0x66,0x66,0x7C,0x00, // 041 - Б
      0x7C,0x66,0x66,0x7C,0x66,0x66,0x7C,0x00, // 042 - В
      0x7E,0x60,0x60,0x60,0x60,0x60,0x60,0x00, // 043 - Г
      0x38,0x6C,0x6C,0x6C,0x6C,0x6C,0xFE,0xC6, // 044 - Д
      0x7E,0x60,0x60,0x7C,0x60,0x60,0x7E,0x00, // 045 - Е
      0xDB,0xDB,0x7E,0x3C,0x7E,0xDB,0xDB,0x00, // 046 - Ж
      0x3C,0x66,0x06,0x1C,0x06,0x66,0x3C,0x00, // 047 - З
      0x66,0x66,0x6E,0x7E,0x76,0x66,0x66,0x00, // 048 - И
      0x3C,0x66,0x6E,0x7E,0x76,0x66,0x66,0x00, // 049 - Й
      0x66,0x6C,0x78,0x70,0x78,0x6C,0x66,0x00, // 04A - К
      0x1E,0x36,0x66,0x66,0x66,0x66,0x66,0x00, // 04B - Л
      0xC6,0xEE,0xFE,0xFE,0xD6,0xC6,0xC6,0x00, // 04C - М
      0x66,0x66,0x66,0x7E,0x66,0x66,0x66,0x00, // 04D - Н
      0x3C,0x66,0x66,0x66,0x66,0x66,0x3C,0x00, // 04E - О
      0x7E,0x66,0x66,0x66,0x66,0x66,0x66,0x00, // 04F - П
      0x7C,0x66,0x66,0x66,0x7C,0x60,0x60,0x00, // 050 - Р
      0x3C,0x66,0x60,0x60,0x60,0x66,0x3C,0x00, // 051 - С
      0x7E,0x18,0x18,0x18,0x18,0x18,0x18,0x00, // 052 - Т
      0x66,0x66,0x66,0x3E,0x06,0x66,0x3C,0x00, // 053 - У
      0x7E,0xDB,0xDB,0xDB,0x7E,0x18,0x18,0x00, // 054 - Ф
      0x66,0x66,0x3C,0x18,0x3C,0x66,0x66,0x00, // 055 - Х
      0x66,0x66,0x66,0x66,0x66,0x66,0x7F,0x03, // 056 - Ц
      0x66,0x66,0x66,0x3E,0x06,0x06,0x06,0x00, // 057 - Ч
      0xDB,0xDB,0xDB,0xDB,0xDB,0xDB,0xFF,0x00, // 058 - Ш
      0xDB,0xDB,0xDB,0xDB,0xDB,0xDB,0xFF,0x03, // 059 - Щ
      0xE0,0x60,0x60,0x7C,0x66,0x66,0x7C,0x00, // 05A - Ъ
      0xC6,0xC6,0xC6,0xF6,0xDE,0xDE,0xF6,0x00, // 05B - Ы
      0x60,0x60,0x60,0x7C,0x66,0x66,0x7C,0x00, // 05C - Ь
      0x78,0x8C,0x06,0x3E,0x06,0x8C,0x78,0x00, // 05D - Э
      0xCE,0xDB,0xDB,0xFB,0xDB,0xDB,0xCE,0x00, // 05E - Ю
      0x3E,0x66,0x66,0x66,0x3E,0x36,0x66,0x00, // 05F - Я
    };

    private byte[] ShortToBB(ushort sh) {
      return new byte[] { (byte)(sh % 0x100), (byte)(sh / 0x100) };
    }

    private ushort BBToShort(byte[] bArr, int offset) {
      return BBToShort(bArr[offset], bArr[offset + 1]);
    }

    private static ushort BBToShort(byte byteL, byte byteH) {
      return (ushort)((byteH << 8) + byteL);
    }

    private byte convertChar(char c) {
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

    public void SaveLocalizedFiles(string origPath, string savePath) {
      foreach (locText lt in locTexts) {
        byte[] bb;
        try {
          bb = File.ReadAllBytes(Path.Combine(origPath, lt.fName));
        } catch { return; }
        bool mmexe = lt.fName == "mm.exe";
        if (mmexe) {
          // Помещаем шрифт в свободное место
          Array.Copy(fontArr, 0, bb, 0x0001180F, fontArr.Length);
          //  и правим ссылку
          Array.Copy(ShortToBB(0x0E5F), 0, bb, 0x00000F05, 2);
        }

        foreach (text t in lt.dt)
          if (t.newAddrInSeg != 0) {
            for (int i = 0; i < t.localizedText.Length; i++)
              bb[t.addrOfSeg + t.newAddrInSeg + i] =
                convertChar(t.localizedText[i]);
            bb[t.addrOfSeg + t.newAddrInSeg + t.localizedText.Length] = 0x00;
            var tmpOffset = 0xC940 - BBToShort(bb, 4) - 0x0E;
            byte[] tmpBB =
              ShortToBB((ushort)(t.newAddrInSeg + (mmexe ? 0 : tmpOffset)));
            bb[t.addrOfAddr.l] = tmpBB[0];
            bb[t.addrOfAddr.h] = tmpBB[1];
          }
        if (!Directory.Exists(savePath))
          try { Directory.CreateDirectory(savePath); } catch { return; }
        File.WriteAllBytes(Path.Combine(savePath, lt.fName), bb);
      }
    }

    public string CheckProgress() {
      int i = 0;
      foreach (text t in dt) if (t.newAddrInSeg != 0) i++;
      return i + "/" + dt.Count;
    }

    public void saveCollectionToFile(string path) {
      if (string.IsNullOrEmpty(path))
        using (var dialog = new System.Windows.Forms.SaveFileDialog()) {
          dialog.InitialDirectory = appPath();
          dialog.Filter = "Localization XML|*.xml";
          if (System.Windows.Forms.DialogResult.OK != dialog.ShowDialog())
            return;
          path = dialog.FileName;
        }

      collectionFile = path;
      XmlSerializer formatter = new XmlSerializer(typeof(List<locText>));
      using (var fs = new FileStream(collectionFile, FileMode.OpenOrCreate)) {
        formatter.Serialize(fs, locTexts);
        fs.SetLength(fs.Position);
      }
    }

    private string collectionFile = "";
    public string getCollectionFileName { get { return collectionFile; } }

    public void ReadCollectionFromFile() {
      using (var dialog = new System.Windows.Forms.OpenFileDialog()) {
        dialog.InitialDirectory = appPath();
        if (System.Windows.Forms.DialogResult.OK == dialog.ShowDialog())
          collectionFile = dialog.FileName;
      }

      if (!string.IsNullOrEmpty(collectionFile)) {
        try {
          var t = typeof(List<locText>);
          XmlSerializer serializer = new XmlSerializer(t);
          using (StreamReader reader = new StreamReader(collectionFile)) {
            locTexts = (List<locText>)serializer.Deserialize(reader);
          }
          foreach (locText lt in locTexts)
            foreach (text txt in lt.dt)
              if (txt.newAddrInSeg == 0 &&
                  string.IsNullOrEmpty(txt.localizedText))
                txt.localizedText = txt.originalText;
        } catch { collectionFile = ""; }
      }
    }

    private string appPath() {
      return AppDomain.CurrentDomain.BaseDirectory;
    }
  }

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    public class config {
      public string originalGameFolder;
      public string saveLocalizedTo;
    }

    private config cfg = new config();
    private textsTextsViewModel textsViewModel = new textsTextsViewModel();
    private string cfgFileName = "config.xml";
    private string appPath = "";
    private string wdwTitle = "";

    private List<RadioButton> rbFiles = new List<RadioButton>();

    public MainWindow() {
      InitializeComponent();
      int i = 0;
      foreach (string s in textsViewModel.lstFNames) {
        RadioButton rb = new RadioButton() { Content = s };
        rb.Checked += Rb_Click;
        rbFiles.Add(rb);
        lstGrid.Items.Add(rb);
      }

      wdwTitle = Title;

      appPath = AppDomain.CurrentDomain.BaseDirectory;

      loadConfig();

      if (string.IsNullOrEmpty(cfg.originalGameFolder) ||
        string.IsNullOrEmpty(cfg.saveLocalizedTo)) {
        wdwOptions options = new wdwOptions(ref cfg);
        if (options.ShowDialog() == true) saveConfig();
      }
    }

    private void Rb_Click(object sender, RoutedEventArgs e) {
      DataContext = null;
      textsViewModel.changeFile((sender as RadioButton).Content as string);
      DataContext = textsViewModel;
    }

    private void loadConfig() {
      try {
        var cfgFile = Path.Combine(appPath, cfgFileName);
        XmlSerializer serializer = new XmlSerializer(typeof(config));
        using (StreamReader reader = new StreamReader(cfgFile)) {
          cfg = (config)serializer.Deserialize(reader);
        }
      } catch { }
    }

    private void saveConfig() {
      try {
        XmlSerializer formatter = new XmlSerializer(typeof(config));
        using (FileStream fs =
          new FileStream(Path.Combine(appPath, cfgFileName),
                         FileMode.OpenOrCreate)) {
          formatter.Serialize(fs, cfg);
          fs.SetLength(fs.Position);
        }
      } catch { }
    }

    private void OpenCommandBinding_Executed(object sender,
                                             ExecutedRoutedEventArgs e) {
      textsViewModel.ReadCollectionFromFile();
      if (string.IsNullOrEmpty(textsViewModel.getCollectionFileName)) return;
      DataContext = null;
      DataContext = textsViewModel;
      Title = wdwTitle + " - " + textsViewModel.getCollectionFileName;
      rbFiles.Find(x => x.Content as string == "mm.exe").IsChecked = true;
    }

    private void SaveCommandBinding_Executed(object sender,
                                             ExecutedRoutedEventArgs e) {
      var t = textsViewModel;
      t.saveCollectionToFile(t.getCollectionFileName);
      Title = wdwTitle + " - " + t.getCollectionFileName;
    }

    private void SaveAsCommandBinding_Executed(object sender,
                                               ExecutedRoutedEventArgs e) {
      textsViewModel.saveCollectionToFile("");
      Title = wdwTitle + " - " + textsViewModel.getCollectionFileName;
    }

    private void ExitCommandBinding_Executed(object sender,
                                             ExecutedRoutedEventArgs e) {
      Application.Current.Shutdown();
    }

    private void GetDataBinding_Executed(object sender,
                                         ExecutedRoutedEventArgs e) {
      Title = wdwTitle;
      DataContext = null;

      if (string.IsNullOrEmpty(cfg.originalGameFolder)) {
        wdwOptions options = new wdwOptions(ref cfg);
        options.Owner = this;
        if (options.ShowDialog() == true) saveConfig();
        if (string.IsNullOrEmpty(cfg.originalGameFolder)) return;
      }

      textsViewModel.FillCollectionFromFiles(cfg.originalGameFolder);
      DataContext = textsViewModel;
      rbFiles.Find(x => x.Content as string == "mm.exe").IsChecked = true;
    }

    private void SaveDataBinding_Executed(object sender,
                                          ExecutedRoutedEventArgs e) {
      if (string.IsNullOrEmpty(cfg.originalGameFolder) ||
          string.IsNullOrEmpty(cfg.saveLocalizedTo)) {
        wdwOptions options = new wdwOptions(ref cfg);
        options.Owner = this;
        if (options.ShowDialog() == true) saveConfig();
        if (string.IsNullOrEmpty(cfg.originalGameFolder) ||
            string.IsNullOrEmpty(cfg.saveLocalizedTo)) return;
      }

      textsViewModel.SaveLocalizedFiles(cfg.originalGameFolder,
                                        cfg.saveLocalizedTo);
    }

    private void OptionsBinding_Executed(object sender,
                                         ExecutedRoutedEventArgs e) {
      wdwOptions options = new wdwOptions(ref cfg);
      options.Owner = this;
      if (options.ShowDialog() == true) saveConfig();
    }

    private void GetProgressBinding_Executed(object sender,
                                         ExecutedRoutedEventArgs e) {
      System.Windows.MessageBox.Show(this, textsViewModel.CheckProgress(),
        "Progress", MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}

namespace MM_Localization.Commands {

  public class MM_Localization_Commands {

    public static RoutedUICommand Open =
      new RoutedUICommand("", "Open", typeof(MM_Localization_Commands));

    public static RoutedUICommand Save =
      new RoutedUICommand("", "Save", typeof(MM_Localization_Commands));

    public static RoutedUICommand SaveAs =
      new RoutedUICommand("", "SaveAs", typeof(MM_Localization_Commands));

    public static RoutedUICommand Close =
      new RoutedUICommand("", "Close", typeof(MM_Localization_Commands));

    public static RoutedUICommand GetData =
      new RoutedUICommand("", "GetData", typeof(MM_Localization_Commands));

    public static RoutedUICommand SaveData =
      new RoutedUICommand("", "SaveData", typeof(MM_Localization_Commands));

    public static RoutedUICommand GetProgress =
      new RoutedUICommand("", "GetProgress", typeof(MM_Localization_Commands));

    public static RoutedUICommand Options =
      new RoutedUICommand("", "Options", typeof(MM_Localization_Commands));
  }
}