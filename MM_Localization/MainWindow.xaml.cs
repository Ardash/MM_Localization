using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MM_Localization {

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    public MainWindow() {
      InitializeComponent();
    }

    private const int seg000 = 0x00000200;
    private const int seg001 = 0x000109B0;

    private int[] textAddresses = {
      seg000+0x03F2,      //0062; INSERT MIGHT & MAGIC DISK
      seg000+0x0405,      //007D;IN DRIVE A AND PRESS 'ENTER'
      //...
      seg000+0x1A83,      //:0D14;  ARE YOU READY?
      seg000+0x1A96,      //:0D26;THEN PRESS ENTER!
      //...
      seg000+0x271B,      //:0DAE;NO RUMORS TODAY.
      seg000+0x262B,      //:0DBF;GREAT STUFF!
      seg000+0x261F,      //:0DCC;YOU FEEL SICK!!
      seg000+0x267A,      //:0DDC;HAVE A DRINK, THEN WE'LL TALK.
      seg000+0x2698,      //:0DFB;THANKS A LOT, HAVE ANOTHER ROUND!
      seg000+0x2759,      //:0E1D;YOU LOOK TERRIBLE, GO SEE THE CLERICS.
      //...
      //seg000:27BD;0E4F;>>5F0E E60E A60F 6C10 0911 7711 D111 4512
      seg001+0x0E4F+0x00, //:0E5F;SERVICES RENDERED, SECRETS UNFOLD\nTHE BRO...
      seg001+0x0E4F+0x02, //:0EE6;SEEK THE WIZARD RANALOU\nIN HIS LAIR AT TH...
      seg001+0x0E4F+0x04, //:0FA6;ONE BY WATER, ONE BY LAND\nONE BY AIR, AND...
      seg001+0x0E4F+0x06, //:106C;THERE ARE MANY DUNGEONS LIKE ME\nFIND THE ...
      seg001+0x0E4F+0x08, //:1109;IN HONOR OF CORAK...\n\nFOR HIS MAPPING EX...
      seg001+0x0E4F+0x0A, //:1177; IN HONOR OF GALA...\n\nFOR HER BRAVE ATTE...
      seg001+0x0E4F+0x0C, //:11D1; IN MEMORY OF A TIME LONG AGO...\n\nBEFORE...
      seg001+0x0E4F+0x0E, //:1245;THIS BEAST ONCE ROAMED THE\nENCHANTED FORE...
      seg000+0x2780,      //:1296;ON THIS STONE STATUE OF
      seg000+0x279F,      //:12AF;A PLAQUE READS...
      //seg000+0x2789:12C1;>>D112 E012 F012 FF12 3713 4713 5613 6413
      seg001+0x12C1+0x00, //:12D1;A HUMAN KNIGHT
      seg001+0x12C1+0x02, //:12E0;AN ELVEN WIZARD
      seg001+0x12C1+0x04, //:12F0;A GNOME ROBBER
      seg001+0x12C1+0x06, //:12FF;A DWARF PALADIN\nPAINTED A BLACK & WHITE C...
      seg001+0x12C1+0x08, //:1337;AN H-ORC ARCHER
      seg001+0x12C1+0x0A, //:1347;A HUMAN CLERIC
      seg001+0x12C1+0x0C, //:1356;A BLUE DRAGON
      seg001+0x12C1+0x0E, //:1364;A GRAY MINOTAUR
      //...
      seg000+0x1D60,      //:137E;CONGRATULATIONS! YOU ARE NOW LEVEL
      seg000+0x1D98,      //:13A2;YOU GAINED
      seg000+0x1DC6,      //:13AE;HIT POINTS!
      seg000+0x1DE0,      //:13BA;YOU GAINED NEW SPELLS!
      //...
      seg000+0x1E0A,      //:13DB;SPECIAL TODAY,ALL YOU CAN EAT!
      seg000+0x1E48,      //:13FB;GP/EA
      seg000+0x1E5B,      //:1401;WILL YOU PAY(Y/N)?
      seg000+0x1EB9,      //:1415;NO GOLD, NO FOOD!
      seg000+0x1EC2,      //:1427;THANK YOU, COME AGAIN!
      //...
      seg000+0x2158,      //:1441;THANK YOU!
      seg000+0x2174,      //:144C;*** TODAY YOU SHALL BE PROTECTED!
      //...
      seg000+0x243B,      //:1475;*** NOT ENOUGH GOLD ***
      seg000+0x2431,      //:148D; THANK YOU!
      seg000+0x245D,      //:1498;*** BACKPACK FULL ***
      //...
      seg000+0x2489,      //:14B1;*** CHECK CONDITION ***
      //???:14C9;WELCOME:
      seg000+0x2516,      //:14D2;'A'-'F' TO BUY\n(- = CANT USE)
      seg000+0x251F,      //:14F0;'A'-'F' TO SELL
      seg000+0x24B9,      //:1500;GOLD=
      seg000+0x252B,      //:1507;'G' GATHER GOLD\n'#' OTHER CHAR
      seg000+0x253E,      //:1526;'ESC' TO GO BACK
      //...
      seg000+0x27E3,      //:15E6;A) BUY WEAPONS\n
      seg000+0x27F1,      //:15F6; B) BUY ARMOR\n
      seg000+0x27FF,      //:1604;C) BUY MISC\n
      seg000+0x280D,      //:1611; D) SELL ITEM
      seg000+0x2837,      //:161E;WEAPONS     PRICE
      seg000+0x28D0,      //:1630;ARMOR      PRICE
      seg000+0x28EC,      //:1641;MISC       PRICE
      seg000+0x2908,      //:1652;BACKPACK     PRICE
      seg000+0x2A87,      //:1665;NO WAY!
      seg000+0x2A48,      //:166D;TRAINING FOR LEVEL
      seg000+0x2BE2,      //:1681;COST
      seg000+0x2C16,      //:1687;GOLD
      seg000+0x2C29,      //:168C;A) COMMENCE TRAINING
      seg000+0x2C6D,      //:16A1;NEED
      seg000+0x2CAD,      //:16A7;MORE
      seg000+0x2CC0,      //:16AC;EXPERIENCE POINTS
      seg000+0x2CD9,      //:16BE;SERVICE        COST
      seg000+0x2DBF,      //:16D2;A) RESTORE HEALTH
      seg000+0x2DF5,      //:16E4;B) UNCURSE ITEMS
      seg000+0x2E33,      //:16F5;C) RESTORE ALIGN
      seg000+0x2E81,      //:1706;D) MAKE DONATION
      //...
      seg000+0x2EA5,      //:174F;----
      //...
      //seg000:2F44:175F;>>6917 7617 8117 8C17 9B17
      seg001+0x175F+0x00, //:1769;--TRAINING--
      seg001+0x175F+0x02, //:1776;--MARKET--
      seg001+0x175F+0x04, //:1781;--TEMPLE--
      seg001+0x175F+0x06, //:178C;--BLACKSMITH--
      seg001+0x175F+0x08, //:179B;--TAVERN--
      seg000+0x2F65,      //:17A6;A) HAVE A DRINK\n
      seg000+0x2F73,      //:17B7;B) TIP BARTENDER\n
      seg000+0x2F81,      //:17C9;C) LISTEN FOR RUMORS
      //...
      seg000+0x32CF,      //:17E3;OPTIONS:  'A' ATTACK  'R' RETREAT
      seg000+0x32E1,      //:1805;'B' BRIBE   'S' SURRENDER
      seg000+0x327E,      //:181F; YOU SURPRISED A GROUP OF MONSTERS,
      seg000+0x3290,      //:1842;APPROACH(Y/N)?
      seg000+0x32B1,      //:1852;THE MONSTERS SURPRISED YOU!
      seg000+0x354C,      //:186E;COMBAT!
      seg000+0x3345,      //:1876;NOWHERE TO RUN
      seg000+0x336D,      //:1885; THE MONSTERS SURROUND YOU!
      seg000+0x33B0,      //:18A0;THE MONSTERS DON'T TAKE PRISONERS!
      seg000+0x3432,      //:18C3;NO RESPONSE
      seg000+0x3463,      //:18CF;GIVE UP ALL YOUR XXXX(Y/N)?
      seg000+0x3483,      //:18EC;GOLD
      seg000+0x34A1,      //:18F1;GEMS
      seg000+0x3492,      //:18F6; FOOD
      seg000+0x34E0,      //:18FB;NOT ENOUGH
      seg000+0x320F,      //:1906;
      seg000+0x3566,      //:1910;*** ALIGNMENT SLIPS ***
      seg000+0x358F,      //:1928;
      //...
      seg000+0x3893,      //:1941;IT OPENS!
      //???:194B;RECEIVES
      seg000+0x38B0,      //:1954;EACH SHARE IS WORTH
      seg000+0x3916,      //:1969;GOLD
      seg000+0x39BC,      //:196E;FOUND
      seg000+0x3B23,
      seg000+0x39ED,      //:1975; GEMS
      // ...
      seg000+0x37D5,      //:197C;OPTIONS:           1) OPEN IT
      seg000+0x37E7,      //:199A;2) FIND/REMOVE TRAP
      seg000+0x37FC,      //:19AE;3) DETECT MAGIC/TRAP
      seg000+0x3BA5,      //:19C3;'ESC' TO GO BACK
      seg000+0x3C42,      //:19D4;MAGIC(N)  TRAP(N)
      seg000+0x3C9B,      //:19E8;*** BAD CLASS ***
      seg000+0x3CBF,      //:19FA;*** NO SPELL POINTS ***
      seg000+0x3D4C,      //:1A12;*** CHECK CONDITION ***
      seg000+0x3CEB,      //:1A2A;WHO WILL TRY '1'-'
      //; Это массив 11 строк длиной 0x0D
      seg000+0x37AA,      //:1A3D; CLOTH SACK
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
      seg000+0x3D76,      //:180D; DARTS!! A SWARM OF POISONOUS DARTS\n     ...
      //:1B46;яSPIKES!! DEADLY SPIKES SPRING FORTH!
      //:1B6C;яARROWS!! A SUDDEN ONSLAUGHT OF POISONOUS         ARROWS PERME...
      //:1BB9;яBLADES!! RAZOR SHARP BLADES SLICE\n         THROUGH THE PARTY...
      //:1BF8;яBOILING OIL!! STREAMS OF BOILING OIL\n              COVER THE...
      //:1C3D;яGAS!! A FAINT HISS CAN BE HEARD AS\n      NOXIOUS FUMES FILL ...
      //:1C83;яFIREBALL!! A FIERY EXPLOSION ENGULFS\n           THE AREA!   ...
      //:1CBE;яLIGHTNING BOLT!! ELECTRIC CURRENTS\n                 SINGE TH...
      //:1D04;яACID!! A FINE MIST OF VOLATILE ACID\n       SPRAYS THE PARTY!...
      //:1D42;яICE STORM!! PARTICLES OF SPLINTERED ICE\n            HAIL THR...
      //:1D8D;яDEATH RAY!! A BLINDING LIGHT SEARS\n            THROUGH THE P...
      //...
      //seg000:4238:1DD2;>>F21D FD1D FF1D 0A1E 151E 1D1E 261E 2E1E 381E 431E 4E1E 591E 641E 6F1E 7A1E 851E
      seg001+0x1DD2+0x00, //:1DF2;` COMMANDS
      seg001+0x1DD2+0x02, //:1DFD;`
      seg001+0x1DD2+0x04, //:1DFF;`[ FORWARD
      seg001+0x1DD2+0x06, //:1E0A;`\ BACK
      seg001+0x1DD2+0x08, //:1E15;`] TURN
      seg001+0x1DD2+0x0A, //:1E1D;`   LEFT
      seg001+0x1DD2+0x0C, //:1E26;`^ TURN
      seg001+0x1DD2+0x10, //:1E2E;`   RIGHT
      seg001+0x1DD2+0x12, //:1E38;`O ORDER
      seg001+0x1DD2+0x14, //:1E43;`P PROTECT
      seg001+0x1DD2+0x16, //:1E4E;`R REST
      seg001+0x1DD2+0x18, //:1E59;`S SEARCH
      seg001+0x1DD2+0x1A, //:1E64;`B BASH
      seg001+0x1DD2+0x1C, //:1E6F;`U UNLOCK
      seg001+0x1DD2+0x1E, //:1E7A;`Q QUIKREF
      seg001+0x1DD2+0x20, //:1E85;`# VIEW CH
      //...
      seg000+0x4607,      //:1EE0; ENCOUNTER!
      seg000+0x4FB5,      //:1EED;  BARRIER!
      seg000+0x479B,      //:1EFA; RE-ORDER PARTY  NEW  1  2  3  4  5  6
      seg000+0x47AE,      //:1F21;OLD ^
      //seg000+0x476C:1F27;>>331F 401F 4D1F 5A1F 671F 741F
      seg001+0x1F27+0x00, //:1F33;   SOLID!
      seg001+0x1F27+0x02, //:1F40;   LOCKED!
      seg001+0x1F27+0x04, //:1F4D; TOO DENSE!
      seg001+0x1F27+0x08, //:1F5A; IMPASSABLE
      seg001+0x1F27+0x0A, //:1F67; ROUGH SEAS
      seg001+0x1F27+0x0C, //:1F74; TOO WINDY!
      //...
      seg000+0x48CA,      //:1F82;PROTECT:  SPELLS CURRENTLY ACTIVE
      seg000+0x499E,      //:1FA4;PROTECTION FROM:
      seg000+0x4983,      //:1FB5;TO ATTACKS
      seg000+0x47C1,      //:1FC0;'ESC' TO GO BACK
      seg000+0x49E2,
      seg000+0x4AF1,
      seg000+0x49F6,      //:1FD1;VOLUME: ON
      seg000+0x4A07,      //:1FDC;VOLUME: OFF
      //...
      //seg000:48E8/4908/493C:1FEA;>>0E20 1320 1820 1D20 2420 2920 2E20 3420 3C20 4920 5220 6020 6A20 7D20 8320 9020 9720 A420
      seg001+0x1FEA+0x00, //:200E;FEAR
      seg001+0x1FEA+0x02, //:2013;COLD
      seg001+0x1FEA+0x04, //:2018;FIRE
      seg001+0x1FEA+0x06, //:201D;POISON
      seg001+0x1FEA+0x08, //:2024;ACID
      seg001+0x1FEA+0x0A, //:2029;ELEC
      seg001+0x1FEA+0x0C, //:202E;MAGIC
      seg001+0x1FEA+0x0E, //:2034;LIGHT(
      seg001+0x1FEA+0x10, //:203C; LEATHER SKIN
      seg001+0x1FEA+0x12, //:2049;LEVITATE
      seg001+0x1FEA+0x14, //:2052;WALK ON WATER
      seg001+0x1FEA+0x16, //:2060;GUARD DOG
      seg001+0x1FEA+0x18, //:206A;PSYCHIC PROTECTION
      seg001+0x1FEA+0x1A, //:207D;BLESS
      seg001+0x1FEA+0x1C, //:2083;INVISIBILITY
      seg001+0x1FEA+0x1E, //:2090;SHIELD
      seg001+0x1FEA+0x20, //:2097;POWER SHIELD
      seg001+0x1FEA+0x22, //:20A4;*** CURSED -
      seg000+0x4A39,      //:20B1;SEARCH:
      seg000+0x4A54,      //:20BB;NOTHING
      seg000+0x4A5F,      //:20C3;YOU FOUND...
      seg000+0x4ACB,      //:20D0; WHO WILL TRY '1'-'
      seg000+0x4BA8,      //:20E3;UNLOCK FAILED
      seg000+0x4BDD,      //:20F1;SUCCESS!
      seg000+0x4CB8,      //:20FA;OOPS A TRAP!
      seg000+0x4DE4,      //:2107; CAN'T SWIM
      seg000+0x50C6,      //:2114;
      seg000+0x461A,      //:2116;
      seg000+0x4FD0,
      seg000+0x50BD,      //:2123; PLEASE WAIT
      //...
      seg000+0x522B,      //:2148; MIGHT AND MAGIC
      seg000+0x5250,      //:2158; SECRET OF THE INNER SANCTUM
      seg000+0x5267,      //:2174; OPTIONS
      seg000+0x527E,      //:217C;-------
      seg000+0x5295,      //:2184;'C'.......CREATE NEW CHARACTERS
      seg000+0x5BE0,      //:218E;CREATE NEW CHARACTERS
      seg000+0x52AC,      //:21A4;'V'.......VIEW ALL CHARACTERS
      seg000+0x5CD9,      //:21AE;VIEW ALL CHARACTERS
      seg000+0x52C3,      //:21C2;'#'.......GO TO TOWN
      seg000+0x52D8,      //:21D7; COPR. 1986,1987-JON VAN CANEGHEM
      seg000+0x52EE,      //:21F8;ALL RIGHTS RESERVED
      seg000+0x5CAA,      //:220C;'ESC' TO GO BACK
      seg000+0x544F,      //:221D;'ESC' START OVER
      //...
      seg000+0x5B05,      //:2231;1) KNIGHT
      seg000+0x537A,      //:2234;KNIGHT
      seg000+0x5DAE,
      //...
      seg000+0x5B2F,      //:223E;2) PALADIN
      seg000+0x5387,      //:2241;PALADIN
      seg000+0x5DBE,
      seg000+0x5B58,      //:224A;3) ARCHER
      seg000+0x5394,      //:224D;ARCHER
      seg000+0x5DCE,
      seg000+0x5B7A,      //:2256;4) CLERIC
      seg000+0x53A1,      //:2259;CLERIC
      seg000+0x5DDE,
      seg000+0x5B9C,      //:2262;5) SORCERER
      seg000+0x53AE,      //:2265;SORCERER
      seg000+0x5DEE,
      seg000+0x5BB7,      //:226E;6) ROBBER
      seg000+0x53B7,      //:2271;ROBBER
      seg000+0x5DFE,
      seg000+0x536A,      //:227A;CLASS.=
      seg000+0x5496,      //:2282:RACE..=
      seg000+0x55C5,      //:228A;ALGN..=
      seg000+0x5688,      //:2292;SEX...=
      seg000+0x56D4,      //:229A;NAME:
      seg000+0x53DB,      //:22A9;1) HUMAN
      seg000+0x54A2,      //:22AC;HUMAN
      seg000+0x53EC,      //:22B6;2) ELF
      seg000+0x54B3,      //:22B9;ELF
      seg000+0x53FD,      //:22C3;3) DWARF
      seg000+0x54D0,      //:22C6;DWARF
      seg000+0x540E,      //:22D0;4) GNOME
      seg000+0x54ED,      //:22D3; GNOME
      seg000+0x541F,      //:22DD;5) HALF-ORC
      seg000+0x5506,      //:22E0; HALF-ORC
      seg000+0x5549,      //:22EA;1) GOOD
      seg000+0x55D5,      //:22ED; GOOD
      seg000+0x555A,      //:22F7;2) NEUT
      seg000+0x55E2,      //:22FA;NEUT
      seg000+0x556B,      //:2304;3) EVIL
      seg000+0x55EB,      //:2307;EVIL
      seg000+0x560F,      //:2311;1) MALE
      seg000+0x5698,      //:2314; MALE
      seg000+0x5620,      //:231E;2) FEMALE
      seg000+0x56A1,      //:2321;FEMALE
      seg000+0x5437,      //:232B;SELECT A RACE
      seg000+0x5595,      //:233A;SELECT ALIGNMENT
      seg000+0x5639,      //:234B;  SELECT A SEX
      seg000+0x578D,      //:235C;SAVE CHARACTER
      seg000+0x57A4,      //:236B;     (Y/N)?
      seg000+0x626B,      //:237C;
      seg000+0x5466,      //:2384;
      seg000+0x56FD,
      seg000+0x5F38,
      seg000+0x5FE5,
      seg000+0x6230,
      seg000+0x53C7,      //:2388;
      seg000+0x5536,
      seg000+0x557C,
      seg000+0x55FC,
      seg000+0x56B2,
      seg000+0x56C3,
      seg000+0x5712,
      seg000+0x5BC5,
      //...
      seg000+0x5E56,      //:23D4;'A'-'
      seg000+0x5E6E,      //:23DA;' TO VIEW A CHARACTER
      seg000+0x5E0A,      //:23F0;NONE
      seg000+0x5EDC,      //:23F5;(CTRL)-'N' RE-NAME CHARACTER
      seg000+0x5EF0,      //:2412;(CTRL)-'D' DELETE CHARACTER
      seg000+0x5FD1,      //:242E;    ARE YOU SURE(Y/N)?
      seg000+0x5F24,      //:2450;NAME: _
      seg000+0x5C93,      //:246F;*** ROSTER IS FULL***
      //???:2486;CREATE NEW CHARACTERS
      seg000+0x5BF9,      //:249C;INTELLECT...=
      seg000+0x5C0E,      //:24AA;MIGHT.......=
      seg000+0x5C23,      //:24B8;PERSONALITY.=
      seg000+0x5C38,      //:24C6;ENDURANCE...=
      seg000+0x5C4D,      //:24D4;SPEED.......=      SELECT A CLASS
      seg000+0x5C62,      //:24F6;ACCURACY....=          (1-6)
      seg000+0x5C77,      //:2513;LUCK........=     'ENT' TO RE-ROLL
      //...
      seg000+0x657A,      //:2538;+--------------------------------------+
      seg000+0x6611,
      seg000+0x658D,      //:2561;THE SHADOW OF DEATH
      seg000+0x65A3,      //:2575;HAS FALLEN UPON YOUR PARTY!
      seg000+0x65B9,      //:2591;FORTUNATELY, YOU MAY RENEW
      seg000+0x65CF,      //:25AC;YOUR QUEST FROM THE LAST
      seg000+0x65E5,      //:25C5;INN IN WHICH YOU STAYED
      seg000+0x65FB,      //:25DD;BY PRESSING 'ENTER'
      seg000+0x6262,      //:25F1;*** PARTY IS FULL ***
      seg000+0x6059,      //:2607;) INN OF
      seg000+0x6070,      //:2611;SORPIGAL
      seg000+0x607D,      //:261A;PORTSMITH
      seg000+0x608A,      //:2624;ALGARY
      seg000+0x6097,      //:262B;DUSK
      seg000+0x60A4,      //:2630;ERLIQUIN
      seg000+0x60DD,      //:2639;AVAILABLE CHARACTERS
      seg000+0x60FF,
      seg000+0x61D0,      //:264E;'A'-'
      seg000+0x61DF,      //:2654;' TO VIEW
      seg000+0x61F3,      //:265E;(CTRL)-'A'-'
      seg000+0x6202,      //:266B;' ADD/REMOVE
      seg000+0x6239,      //:2678;'X' EXIT INN
      //...
      seg000+0x686E,      //:2687; NONE
      seg000+0x68C8,
      seg000+0x692F,
      seg000+0x684B,      //:268C;GOOD
      seg000+0x696C,
      seg000+0x6858,      //:2691; NEUT
      seg000+0x6865,      //:2696; EVIL
      seg000+0x688B,      //:269B;HUMAN
      seg000+0x6898,      //:26A1;ELF
      seg000+0x68A5,      //:26A5;DWARF
      seg000+0x68B2,      //:26AB;GNOME
      seg000+0x68BF,      //:26B1;H-ORC
      seg000+0x68E5,      //:26B7;KNIGHT
      seg000+0x68F2,      //:26BE;PALADIN
      seg000+0x68FF,      //:26C6;ARCHER
      seg000+0x690C,      //:26CD;CLERIC
      seg000+0x6919,      //:26D4; SORCERER
      seg000+0x6926,      //:26DD;ROBBER
      seg000+0x697E,      //:26E4; ERADICATED
      seg000+0x6993,      //:26EF; DEAD,
      seg000+0x66A2,      //:26F5;STONE,
      seg000+0x69C0,      //:26FC;UNCONSCIOUS,
      seg000+0x69CF,      //:2709;PARALYZED,
      seg000+0x69DE,      //:2714;POISONED,
      seg000+0x69ED,      //:271E;DISEASED,
      seg000+0x69FC,      //:2728;SILENCED,
      seg000+0x6A0B,      //:2732;BLINDED,
      seg000+0x6A1A,      //:273B;ASLEEP,
      seg000+0x694F,      //:2743;COND=
      seg000+0x6A76,      //:2749;INT=
      seg000+0x6A93,      //:274E;LEVEL=
      seg000+0x6AB0,      //:2755;AGE=
      seg000+0x6ACD,      //:275A;EXP=
      seg000+0x6B04,      //:275F;MGT=
      seg000+0x6B24,      //:2764;PER=
      seg000+0x6B41,      //:2769;SP=
      seg000+0x6BA6,      //:276D;GEMS=
      seg000+0x6BD1,      //:2773;END=
      seg000+0x6BF1,      //:2778;SPD=
      seg000+0x6C0E,      //:277D;HP=
      seg000+0x6C50,      //:2781;GOLD=
      seg000+0x6C81,      //:2787;ACY=
      seg000+0x6CA1,      //:278C;LUC=
      seg000+0x6CBE,      //:2791;AC=
      seg000+0x6784,      //:2795;FOOD=
      seg000+0x6CDB,
      seg000+0x6D0B,      //:279B;-----<EQUIPPED>----------<BACKPACK>-----
      seg000+0x6653,      //:27C4;#     NAME        HIT PTS   SPELL PTS AC
      seg000+0x67C7,      //:27ED;'1'-'
      seg000+0x67D6,      //:27F3;' TO VIEW
      seg000+0x67E9,      //:27FD;'ESC' TO GO BACK
      //...
      seg000+0x6DFB,      //:2810;'Q' QUICK REF     'C' CAST    'R' REMOVE
      seg000+0x6E10,      //:2839; # VIEW OTHER     'D' DISCARD 'S' SHARE
      seg000+0x6E25,      //:2861;                  'E' EQUIP   'T' TRADE
      seg000+0x6E3A,      //:2889;'ESC' TO GO BACK  'G' GATHER  'U' USE
      seg000+0x6EF8,      //:28AF;*** TOO DANGEROUS TO REST HERE!
      seg000+0x6F1A,      //:28CF;REST HERE(Y/N)?
      seg000+0x6FF5,      //:28E0;REST COMPLETE: NO ENCOUNTERS!
      //...
      seg000+0x7455,      //:2922;DISCARD WHICH ITEM: 'A'-'F'?
      seg000+0x7569,      //:293F;*** 40 FOOD MAX ***
      seg000+0x7774,      //:2953;SHARE ALL:
      //...
      seg000+0x7DE9,      //:296A;*** ALREADY HAVE WEAPON ***
      seg000+0x7DF7,      //:2986;*** AREADY HAVE MISSILE WEAPON ***
      seg000+0x7E05,      //:29A9;*** CANNOT WITH SHIELD ***
      seg000+0x7E13,      //:29C4;*** ALREADY WEARING ARMOR ***
      seg000+0x7E21,      //:29E2;*** CANNOT WITH TWO-HANDED WEAPON ***
      seg000+0x7E2F,      //:2A08;*** ALREADY HAVE ONE ***
      seg000+0x7E3D,      //:2A21;*** FULL ***
      seg000+0x8018,
      seg000+0x83DD,
      seg000+0x7E4B,      //:2A2E;*** NOT EQUIPPED ***
      seg000+0x86F2,
      seg000+0x7DCD,      //:2A43;*** WRONG ALIGNMENT ***
      seg000+0x7DDB,      //:2A5B;*** WRONG CLASS ***
      seg000+0x7A94,      //:2A6F;EQUIP WHICH ITEM: 'A'-'F'?
      seg000+0x80BB,      //:2A75;WHICH ITEM: 'A'-'F'?
      seg000+0x9559,
      seg000+0x9639,
      //...
      seg000+0x8002,      //:2A92;*** CURSED ***
      seg000+0x7EA8,      //:2AA1;REMOVE WHICH ITEM: '1'-'6'?
      seg000+0x82A3,      //:2ABD;*** YOU DON'T HAVE THAT MUCH ***
      seg000+0x8040,      //:2ADE;TRADE WHICH:
      seg000+0x8059,      //:2AEB;4) ITEM
      seg000+0x82BC,      //:2AF3;TRADE WITH: '1'-'
      seg000+0x8339,      //:2B05;'ESC' TO GO BACK
      seg000+0x834D,      //:2B16;1) GEMS
      seg000+0x835F,      //:2B1E;2) GOLD
      seg000+0x8371,      //:2B26;3) FOOD
      seg000+0x74CD,      //:2B2E;GATHER ALL:
      //...
      seg000+0x848C,      //:2B43;HOW MUCH: _
      //...
      seg000+0x862F,      //:2B53;USE WHICH 'A'-'F','1'-'6'?
      seg000+0x86D8,      //:2B6E;*** NO SPECIAL POWER ***
      seg000+0x870F,      //:2B87;*** NO CHARGES LEFT ***
      seg000+0x87D4,      //:2B9F;CAST SPELL:  LEVEL= _
      seg000+0x8812,      //:2BB5;NUMBER= _
      seg000+0x8A48,      //:2BBF;*** DONE ***
      seg000+0x89C3,      //:2BCC;CAST ON: '1'-'
      seg000+0x89DB,      //:2BDB;'ENTER' TO CAST
      seg000+0x93A8,
      seg000+0x94A7,
      //...
      seg000+0x8F3C,      //:2CAD; WHICH TOWN(1-5)?
      //...
      seg000+0x902B,      //:2CC2;MAGIC(CHARGES)
      seg000+0x912D,      //:2CD2;LOCATION:
      seg000+0x9148,      //:2CDD;UNKNOWN
      seg000+0x9158,      //:2CE5;IN TOWN
      seg000+0x9161,      //:2CED;IN CASTLE
      seg000+0x916A,      //:2CF7;OUTDOORS
      seg000+0x9181,      //:2D00;0' UNDER
      seg000+0x918F,      //:2D09;MAP SECTOR:
      seg000+0x91C0,      //:2D16;SURFACE: X=
      seg000+0x920B,      //:2D22;INSIDE: X=
      seg000+0x9240,      //:2D2D;FACING:
      //...
      seg000+0x9342,      //:2D38;FLY TO(A-E): _
      seg000+0x937A,      //:2D48;(1-4): _
      //...
      seg000+0x9442,      //:2D53;DIRECTION(N, E, S, W):_
      seg000+0x947B,      //:2D69;# OF SQUARES (0-9):_
      //...
      seg000+0x8903,      //:2DE6;*** NOT ENOUGH SPELL POINTS ***
      seg000+0x894A,      //:2E06;*** NOT ENOUGH GEMS ***
      seg000+0x899A,      //:2E1E;*** OUTDOOR ONLY ***
      seg000+0x8970,      //:2E33;*** COMBAT ONLY ***
      seg000+0x8A6F,      //:2E47;*** MAGIC DOESN'T WORK HERE ***
      seg000+0x9727,      //:2E67;*** SPELL FAILED ***
      //...
      seg000+0xA0F4,      //:3060;! FOR DEFEATING THE MONSTERS !
      seg000+0xA107,      //:307F;!   EACH SURVIVOR RECEIVES   !
      seg000+0xA133,      //:309E;EXPERIENCE POINTS.
      seg000+0xA085,      //:30B1;+----------------------------+
      seg000+0xA146,
      //...
      seg000+0x9B52,      //:30D6;RUNS AWAY...
      //...
      seg000+0x9C1C,      //:30E4; INFILTRATES THE RANKS!
      //; массив 15 строк, разделенных 0x00
      seg000+0x9C58,      //:30FB;ATTACKS
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
      seg000+0xA608,      //:319B; WEAPON HAS NO EFFECT!
      //...
      seg000+0xAC1E,      //:31B3;AND
      //...
      seg000+0xACD8,      //:31B9; ADVANCES!
      //...
      seg000+0xAE4F,      //:31CE;SOME MONSTERS REGENERATE!
      seg000+0xAE79,      //:31E8;SOME MONSTERS OVERCOME SPELLS!
      seg000+0xAF23,      //:3207; WAITS FOR AN OPENING.
      seg000+0xAF1A,      //:321E; SHOOTS AT
      //...
      seg000+0xA83D,      //:325B; TAKES FOOD
      seg000+0xA850,      //:3266;INFLICTS DISEASE
      seg000+0xA869,      //:3277;CAUSES PARALYSIS
      seg000+0xA882,      //:3288;INDUCES POISON
      seg000+0xA8D2,      //:3297;STEALS SOME GEMS
      seg000+0xA8FC,      //:32A8;REDUCES ENDURANCE
      seg000+0xA919,      //:32BA;INDUCES SLEEP
      seg000+0xA97A,      //:32C8;STEALS SOME GOLD
      seg000+0xA9AA,      //:32D9;STEALS SOMETHING
      seg000+0xA9C0,      //:32EA;CAUSES BLINDNESS
      seg000+0xA9F3,      //:32FB;DRAINS LIFEFORCE
      seg000+0xAA8D,
      seg000+0xAA24,      //:330C;IS TURNED TO STONE
      seg000+0xAA54,      //:331F;CAUSES RAPID AGING
      seg000+0xAABE,      //:3332;IS KILLED
      seg000+0xD8F9,
      seg000+0xAAD7,      //:333C;INDUCES UNCONSCIOUSNESS
      seg000+0xAB07,      //:3354;DRAINS MIGHT
      seg000+0xAB58,      //:3361;DRAINS ABILITIES
      seg000+0xAB7D,      //:3372;STEALS BACKPACK
      seg000+0xABC0,      //:3382;STEALS GOLD AND GEMS
      seg000+0xABE6,      //:3397;IS ERADICATED
      seg000+0xAC05,      //:33A5;DRAINS SPELL POINTS
      //...
      seg000+0xAF59,      //:33BD;WANDERS AIMLESSLY
      //...
      seg000+0xAFEA,      //:340F; A CURSE
      seg000+0xB003,      //:3417;ENERGY BLAST
      seg000+0xB021,      //:3424;FIRE
      seg000+0xB1C2,
      seg000+0xB054,      //:3429;BLINDNESS
      seg000+0xB06D,      //:3433;SPRAYS POISON
      seg000+0xB087,      //:3441;SPRAYS ACID
      seg000+0xB0A7,      //:344D;SLEEP
      seg000+0xB0C8,      //:3453;PARALYZE
      seg000+0xB0F7,      //:345C;DISPELL
      seg000+0xB107,      //:3464;LIGHTNING BOLT
      seg000+0xB12E,      //:3473;STRANGE GAS
      seg000+0xB148,      //:347F;EXPLODE
      seg000+0xB17F,      //:3487;FIRE BALL
      seg000+0xB1FB,      //:3491;GAZES
      seg000+0xB213,      //:3497;ACID ARROW
      seg000+0xB237,      //:34A2;CALLS UPPON THE ELEMENTS
      seg000+0xB255,      //:34BB;COLD BEAM
      seg000+0xB27C,      //:34C5;DANCING SWORD
      seg000+0xB29A,      //:34D3;MAGIC DRAIN
      seg000+0xB2E3,      //:34DF;FINGER OF DEATH
      seg000+0xB2FF,      //:34EF;SUN RAY
      seg000+0xB321,      //:34F7;DISINTEGRATION
      seg000+0xB33A,      //:3506;COMMANDS ENERGY
      //...
      //seg000:B398:3517;>>2535 2C35 3635 3C35 4335 4835 4D35
      seg001+0x3517+0x00, //:3525;POISON
      seg001+0x3517+0x02, //:352C;LIGHTNING
      seg001+0x3517+0x04, //:3536; FROST
      seg001+0x3517+0x06, //:353C;SPIKES
      seg001+0x3517+0x08, //:3543; ACID
      seg001+0x3517+0x0A, //:3548;FIRE
      seg001+0x3517+0x0C, //:354D;ENERGY
      seg000+0xB3B5,      //:3554;SWARM
      seg000+0xB3CD,      //:355A;BREATHES
      seg000+0xB3E9,      //:3564;FAILS TO CAST A SPELL
      seg000+0xB3F4,      //:357A;CASTS
      // ...
      seg000+0xB428,      //:3583;TAKES
      seg000+0xB43E,      //:358A;POINT
      seg000+0xB46A,      //:3590;OF DAMAGE!
      //seg000:B4E4:359B;>>B135 BA35 C535 D135 DD35 E935 F635 3233 0C33 9733 0E36
      seg001+0x359B+0x00, //:35B1;IS SLEPT
      seg001+0x359B+0x02, //:35BA;IS BLINDED
      seg001+0x359B+0x04, //:35C5;IS SILENCED
      seg001+0x359B+0x06, //:35D1;IS DISEASED
      seg001+0x359B+0x08, //:35DD;IS POISONED
      seg001+0x359B+0x0A, //:35E9;IS PARALYZED
      seg001+0x359B+0x0C, //:35F6;IS RENDERED UNCONSCIOUS
      seg001+0x359B+0x0E, //:360E;IS AFFECTED
      seg000+0xB5F1,      //:361A;IS NOT AFFECTED!
      seg000+0xD908,
      seg000+0xB6DD,      //:362B;COMBAT
      seg000+0xAD3B,      //:3632;ROUND #:
      seg000+0xB6F1,
      seg000+0xB708,      //:363B;D DELAY
      seg000+0xB71C,      //:3643;P PROTECT
      seg000+0xB730,      //:364D;Q QUICKREF
      seg000+0xB744,      //:3658;# VIEW CH
      seg000+0xB75C,      //:3662;HANDICAP
      seg000+0xB8B9,      //:366B;MONSTER +
      seg000+0xB8C5,      //:3675;PARTY +
      seg000+0xB8D1,      //:367D;EVEN
      seg000+0xBE15,      //:3682;OPTIONS FOR:
      seg000+0xBF18,      //:3690;'E' EXCHANGE  'U' USE
      seg000+0xBF2C,      //:36A6;'R' RETREAT   'B' BLOCK
      seg000+0xBF44,      //:36BE;'A' ATTACK(A)
      seg000+0xBF58,      //:36CC;'F' FIGHT(+)
      seg000+0xBF70,      //:36D9;'S' SHOOT
      seg000+0xBF88,      //:36E3;'C' CAST
      seg000+0xA542,      //:36EC;ATTACKS
      seg000+0xA54B,      //:36F4;SHOOTS
      seg000+0xC090,      //:36FB;TIMES
      seg000+0xC0F3,
      seg000+0xC07A,      //:3701;ONCE
      seg000+0xC0D9,
      seg000+0xC09D,      //:3706;AND
      seg000+0xC0B1,      //:370A;MISSES
      seg000+0xC0BB,      //:3711;HIT
      seg000+0xC100,      //:3715;FOR
      seg000+0xC11A,      //:3719;POINT
      seg000+0xC149,      //:371F;OF DAMAGE!
      seg000+0xB68E,      //:372A;SET DELAY(0-9):
      seg000+0xB69E,      //:373B;(CURRENTLY=
      seg000+0xC1D4,      //:3748;'1'-'
      seg000+0xC1E6,      //:374E;' TO VIEW
      seg000+0xBFA6,      //:3758;'ESC' TO GO BACK
      seg000+0x9957,      //:3769; EXCHANGE PLACES WITH(1-
      seg000+0x9969,      //:3782;)?
      seg000+0xA2B8,      //:3785;FIGHT WHICH 'A'-'
      seg000+0xA339,      //:3797;SHOOT WHICH 'A'-'
      seg000+0xBA34,      //:37A9;(WOUNDED)
      //seg000+0xBA15:37B4;>>C637 D137 DC37 E737 F237 FD37 0838 1338 1E38
      seg001+0x37B4+0x00, //:37C6;(PARALYZE)
      seg001+0x37B4+0x02, //:37D1;(WEBBED)
      seg001+0x37B4+0x04, //:37DC;(HELD)
      seg001+0x37B4+0x06, //:37E7;(ASLEEP)
      seg001+0x37B4+0x08, //:37F2;(MINDLESS)
      seg001+0x37B4+0x0A, //:37FD;(SILENCED)
      seg001+0x37B4+0x0C, //:3808;(BLINDED)
      seg001+0x37B4+0x0E, //:3813;(AFRAID)
      seg001+0x37B4+0x10, //:381E;(DEAD)
      seg000+0xCD04,      //:3829;AND GOES DOWN!!!
      seg000+0x9E4D,      //:382D;GOES DOWN!!!
      seg000+0x9E88,      //:383A;DIES!
      //...
      seg000+0xBAF9,      //:38BE;
      seg000+0xBAE2,      //:38C9;
      //...
      seg000+0xC5C5,      //:38D9;
      //...
      seg000+0xC913,      //:38DC;NOT ENOUGH SPELL POINTS
      seg000+0xC95A,      //:38F4;NOT ENOUGH GEMS
      seg000+0xC9AA,      //:3904;OUTDOOR ONLY
      seg000+0xC980,      //:3911;NON COMBAT ONLY
      seg000+0xCAA9,      //:3921;MAGIC DOESN'T WORK HERE
      //...
      seg000+0xC649,      //:393C;USE WHICH 'A'-'F','1'-'6'?
      seg000+0xC6EF,      //:3957;NO SPECIAL POWER
      seg000+0xC72B,      //:3968;NO CHARGES LEFT
      seg000+0xC719,      //:3978;NOT EQUIPPED
      seg000+0xC7E0,      //:398B;CAST SPELL:  LEVEL= _
      seg000+0xC81E,      //:39A1;NUMBER= _
      seg000+0xCA7F,      //:39AB;DONE
      seg000+0xC9CB,      //:39B0;CAST ON: '1'-'
      seg000+0xCA03,      //:39BF;'ENTER' TO CAST
      seg000+0xC9EB,      //:39CF;CAST ON: 'A'-'
      seg000+0xCB98,      //:39DE;***
      //...
      //seg000:CC21:3A9E;>>B03A BA35 C535 BA3A B135 C63A CE3A E935 0E36
      seg001+0x3A9E+0x00, //:3AB0;IS SCARED
      seg001+0x3A9E+0x02, //:3ABA;IS MINDLESS
      seg001+0x3A9E+0x04, //:3AC6;IS HELD
      seg001+0x3A9E+0x06, //:3ACE;IS WEBBED
      //...
      seg000+0xCD81,      //:3AD9; CASTS A SPELL:
      //...
      seg000+0xCF77,      //:3AED;SOME MONSTERS WERE DESTROYED!
      seg000+0xCFC4,      //:3B0B;NO EFFECT!
      //...
      seg000+0xD64A,      //:3B1A;MAXIMUM DAMAGE =
      seg000+0xD5FE,      //:3B2C;# OF ATTACKS =
      seg000+0xD576,      //:3B3C;HP =
      seg000+0xD5D1,      //:3B42;BONUS ON TOUCH
      seg000+0xD594,      //:3B54;AC =
      seg000+0xD61B,      //:3B5A;SPECIAL ABILITY
      seg000+0xD5B4,      //:3B6C;SPEED =
      seg000+0xD667,      //:3B75;MAGIC RESISTANCE
      seg000+0xD959,      //:3B87;IS DISINTEGRATED!
      seg000+0xDA3A,      //:3B99;NO SPELL POINTS
      seg000+0xDA05,      //:3BA9;SPELL FAILED
      //...
      seg000+0x40CC,      //:3C0E;
      seg000+0x40DF,
      seg000+0x40F2,
      //...
      seg000+0x2882,      //:3CDA;
      seg000+0x2982,
      seg000+0x3B2C,
      seg000+0x6DA9,
      seg000+0x6DD0,
      //...
      //seg000:46F1:9972;STAFF         ;похоже, что ссылка просто на ББ оружие
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
    };

    private static ushort ToShort(byte byte1, byte byte2) {
      return (ushort)((byte2 << 8) + byte1);
    }

    static int getStrLen(byte[] bArr, int index) {
      int j = 0;
      for (int i = index; i < bArr.Length; i++, j++)
        if (bArr[i] == 0x00) break;
      return j;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      byte[] bb = File.ReadAllBytes("c:\\Projects.side\\MM_Localization\\MM_Localization\\bin\\Debug\\MM.exe");
      List<string> strings = new List<string>();
      foreach (int i in textAddresses) {
        int strAddr = seg001 + ToShort(bb[i], bb[i + 1]);
        int strAddrL = getStrLen(bb, strAddr);
        strings.Add(strAddrL > 0 ? System.Text.Encoding.ASCII.GetString(bb, strAddr, strAddrL) : "");
      }
    }
  }
}