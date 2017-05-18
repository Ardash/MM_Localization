#include <stdio.h>

//db 000h, 000h, 000h, 000h, 000h, 000h, 000h, 000h; 000
//db 07Eh, 081h, 0A5h, 081h, 0BDh, 099h, 081h, 07Eh; 001
//db 07Eh, 0FFh, 0DBh, 0FFh, 0C3h, 0E7h, 0FFh, 07Eh; 002
//db 06Ch, 0FEh, 0FEh, 0FEh, 07Ch, 038h, 010h, 000h; 003
//db 010h, 038h, 07Ch, 0FEh, 07Ch, 038h, 010h, 000h; 004
//db 038h, 07Ch, 038h, 0FEh, 0FEh, 07Ch, 038h, 07Ch; 005
//db 010h, 010h, 038h, 07Ch, 0FEh, 07Ch, 038h, 07Ch; 006
//db 000h, 000h, 018h, 03Ch, 03Ch, 018h, 000h, 000h; 007
//db 0FFh, 0FFh, 0E7h, 0C3h, 0C3h, 0E7h, 0FFh, 0FFh; 008
//db 000h, 03Ch, 066h, 042h, 042h, 066h, 03Ch, 000h; 009
//db 0FFh, 0C3h, 099h, 0BDh, 0BDh, 099h, 0C3h, 0FFh; 00A
//db 00Fh, 007h, 00Fh, 07Dh, 0CCh, 0CCh, 0CCh, 078h; 00B
//db 03Ch, 066h, 066h, 066h, 03Ch, 018h, 07Eh, 018h; 00C
//db 03Fh, 033h, 03Fh, 030h, 030h, 070h, 0F0h, 0E0h; 00D
//db 07Fh, 063h, 07Fh, 063h, 063h, 067h, 0E6h, 0C0h; 00E
//db 099h, 05Ah, 03Ch, 0E7h, 0E7h, 03Ch, 05Ah, 099h; 00F
//db 080h, 0E0h, 0F8h, 0FEh, 0F8h, 0E0h, 080h, 000h; 010
//db 002h, 00Eh, 03Eh, 0FEh, 03Eh, 00Eh, 002h, 000h; 011
//db 018h, 03Ch, 07Eh, 018h, 018h, 07Eh, 03Ch, 018h; 012
//db 066h, 066h, 066h, 066h, 066h, 000h, 066h, 000h; 013
//db 07Fh, 0DBh, 0DBh, 07Bh, 01Bh, 01Bh, 01Bh, 000h; 014
//db 03Eh, 063h, 038h, 06Ch, 06Ch, 038h, 0CCh, 078h; 015
//db 000h, 000h, 000h, 000h, 07Eh, 07Eh, 07Eh, 000h; 016
//db 018h, 03Ch, 07Eh, 018h, 07Eh, 03Ch, 018h, 0FFh; 017
//db 018h, 03Ch, 07Eh, 018h, 018h, 018h, 018h, 000h; 018
//db 018h, 018h, 018h, 018h, 07Eh, 03Ch, 018h, 000h; 019
//db 000h, 018h, 00Ch, 0FEh, 00Ch, 018h, 000h, 000h; 01A
//db 000h, 030h, 060h, 0FEh, 060h, 030h, 000h, 000h; 01B
//db 000h, 000h, 0C0h, 0C0h, 0C0h, 0FEh, 000h, 000h; 01C
//db 000h, 024h, 066h, 0FFh, 066h, 024h, 000h, 000h; 01D
//db 000h, 018h, 03Ch, 07Eh, 0FFh, 0FFh, 000h, 000h; 01E
//db 000h, 0FFh, 0FFh, 07Eh, 03Ch, 018h, 000h, 000h; 01F
//db 000h, 000h, 000h, 000h, 000h, 000h, 000h, 000h; 020
//db 030h, 078h, 078h, 030h, 030h, 000h, 030h, 000h; 021
//db 06Ch, 06Ch, 06Ch, 000h, 000h, 000h, 000h, 000h; 022
//db 06Ch, 06Ch, 0FEh, 06Ch, 0FEh, 06Ch, 06Ch, 000h; 023
//db 030h, 07Ch, 0C0h, 078h, 00Ch, 0F8h, 030h, 000h; 024
//db 000h, 0C6h, 0CCh, 018h, 030h, 066h, 0C6h, 000h; 025
//db 038h, 06Ch, 038h, 076h, 0DCh, 0CCh, 076h, 000h; 026
//db 060h, 060h, 0C0h, 000h, 000h, 000h, 000h, 000h; 027
//db 018h, 030h, 060h, 060h, 060h, 030h, 018h, 000h; 028
//db 060h, 030h, 018h, 018h, 018h, 030h, 060h, 000h; 029
//db 000h, 066h, 03Ch, 0FFh, 03Ch, 066h, 000h, 000h; 02A
//db 000h, 030h, 030h, 0FCh, 030h, 030h, 000h, 000h; 02B
//db 000h, 000h, 000h, 000h, 000h, 030h, 030h, 060h; 02C
//db 000h, 000h, 000h, 0FCh, 000h, 000h, 000h, 000h; 02D
//db 000h, 000h, 000h, 000h, 000h, 030h, 030h, 000h; 02E
//db 006h, 00Ch, 018h, 030h, 060h, 0C0h, 080h, 000h; 02F
//db 07Ch, 0C6h, 0CEh, 0DEh, 0F6h, 0E6h, 07Ch, 000h; 030
//db 030h, 070h, 030h, 030h, 030h, 030h, 0FCh, 000h; 031
//db 078h, 0CCh, 00Ch, 038h, 060h, 0CCh, 0FCh, 000h; 032
//db 078h, 0CCh, 00Ch, 038h, 00Ch, 0CCh, 078h, 000h; 033
//db 01Ch, 03Ch, 06Ch, 0CCh, 0FEh, 00Ch, 01Eh, 000h; 034
//db 0FCh, 0C0h, 0F8h, 00Ch, 00Ch, 0CCh, 078h, 000h; 035
//db 038h, 060h, 0C0h, 0F8h, 0CCh, 0CCh, 078h, 000h; 036
//db 0FCh, 0CCh, 00Ch, 018h, 030h, 030h, 030h, 000h; 037
//db 078h, 0CCh, 0CCh, 078h, 0CCh, 0CCh, 078h, 000h; 038
//db 078h, 0CCh, 0CCh, 07Ch, 00Ch, 018h, 070h, 000h; 039
//db 000h, 030h, 030h, 000h, 000h, 030h, 030h, 000h; 03A
//db 000h, 030h, 030h, 000h, 000h, 030h, 030h, 060h; 03B
//db 018h, 030h, 060h, 0C0h, 060h, 030h, 018h, 000h; 03C
//db 000h, 000h, 0FCh, 000h, 000h, 0FCh, 000h, 000h; 03D
//db 060h, 030h, 018h, 00Ch, 018h, 030h, 060h, 000h; 03E
//db 078h, 0CCh, 00Ch, 018h, 030h, 000h, 030h, 000h; 03F
//db 07Ch, 0C6h, 0DEh, 0DEh, 0DEh, 0C0h, 078h, 000h; 040
//db 030h, 078h, 0CCh, 0CCh, 0FCh, 0CCh, 0CCh, 000h; 041
//db 0FCh, 066h, 066h, 07Ch, 066h, 066h, 0FCh, 000h; 042
//db 03Ch, 066h, 0C0h, 0C0h, 0C0h, 066h, 03Ch, 000h; 043
//db 0F8h, 06Ch, 066h, 066h, 066h, 06Ch, 0F8h, 000h; 044
//db 0FEh, 062h, 068h, 078h, 068h, 062h, 0FEh, 000h; 045
//db 0FEh, 062h, 068h, 078h, 068h, 060h, 0F0h, 000h; 046
//db 03Ch, 066h, 0C0h, 0C0h, 0CEh, 066h, 03Eh, 000h; 047
//db 0CCh, 0CCh, 0CCh, 0FCh, 0CCh, 0CCh, 0CCh, 000h; 048
//db 078h, 030h, 030h, 030h, 030h, 030h, 078h, 000h; 049
//db 01Eh, 00Ch, 00Ch, 00Ch, 0CCh, 0CCh, 078h, 000h; 04A
//db 0E6h, 066h, 06Ch, 078h, 06Ch, 066h, 0E6h, 000h; 04B
//db 0F0h, 060h, 060h, 060h, 062h, 066h, 0FEh, 000h; 04C
//db 0C6h, 0EEh, 0FEh, 0FEh, 0D6h, 0C6h, 0C6h, 000h; 04D
//db 0C6h, 0E6h, 0F6h, 0DEh, 0CEh, 0C6h, 0C6h, 000h; 04E
//db 038h, 06Ch, 0C6h, 0C6h, 0C6h, 06Ch, 038h, 000h; 04F
//db 0FCh, 066h, 066h, 07Ch, 060h, 060h, 0F0h, 000h; 050
//db 078h, 0CCh, 0CCh, 0CCh, 0DCh, 078h, 01Ch, 000h; 051
//db 0FCh, 066h, 066h, 07Ch, 06Ch, 066h, 0E6h, 000h; 052
//db 078h, 0CCh, 0E0h, 070h, 01Ch, 0CCh, 078h, 000h; 053
//db 0FCh, 0B4h, 030h, 030h, 030h, 030h, 078h, 000h; 054
//db 0CCh, 0CCh, 0CCh, 0CCh, 0CCh, 0CCh, 0FCh, 000h; 055
//db 0CCh, 0CCh, 0CCh, 0CCh, 0CCh, 078h, 030h, 000h; 056
//db 0C6h, 0C6h, 0C6h, 0D6h, 0FEh, 0EEh, 0C6h, 000h; 057
//db 0C6h, 0C6h, 06Ch, 038h, 038h, 06Ch, 0C6h, 000h; 058
//db 0CCh, 0CCh, 0CCh, 078h, 030h, 030h, 078h, 000h; 059
//db 0FEh, 0C6h, 08Ch, 018h, 032h, 066h, 0FEh, 000h; 05A
//db 078h, 060h, 060h, 060h, 060h, 060h, 078h, 000h; 05B
//db 0C0h, 060h, 030h, 018h, 00Ch, 006h, 002h, 000h; 05C
//db 078h, 018h, 018h, 018h, 018h, 018h, 078h, 000h; 05D
//db 010h, 038h, 06Ch, 0C6h, 000h, 000h, 000h, 000h; 05E
//db 000h, 000h, 000h, 000h, 000h, 000h, 000h, 0FFh; 05F
//db 030h, 030h, 018h, 000h, 000h, 000h, 000h, 000h; 060
//db 000h, 000h, 078h, 00Ch, 07Ch, 0CCh, 076h, 000h; 061
//db 0E0h, 060h, 060h, 07Ch, 066h, 066h, 0DCh, 000h; 062
//db 000h, 000h, 078h, 0CCh, 0C0h, 0CCh, 078h, 000h; 063
//db 01Ch, 00Ch, 00Ch, 07Ch, 0CCh, 0CCh, 076h, 000h; 064
//db 000h, 000h, 078h, 0CCh, 0FCh, 0C0h, 078h, 000h; 065
//db 038h, 06Ch, 060h, 0F0h, 060h, 060h, 0F0h, 000h; 066
//db 000h, 000h, 076h, 0CCh, 0CCh, 07Ch, 00Ch, 0F8h; 067
//db 0E0h, 060h, 06Ch, 076h, 066h, 066h, 0E6h, 000h; 068
//db 030h, 000h, 070h, 030h, 030h, 030h, 078h, 000h; 069
//db 00Ch, 000h, 00Ch, 00Ch, 00Ch, 0CCh, 0CCh, 078h; 06A
//db 0E0h, 060h, 066h, 06Ch, 078h, 06Ch, 0E6h, 000h; 06B
//db 070h, 030h, 030h, 030h, 030h, 030h, 078h, 000h; 06C
//db 000h, 000h, 0CCh, 0FEh, 0FEh, 0D6h, 0C6h, 000h; 06D
//db 000h, 000h, 0F8h, 0CCh, 0CCh, 0CCh, 0CCh, 000h; 06E
//db 000h, 000h, 078h, 0CCh, 0CCh, 0CCh, 078h, 000h; 06F
//db 000h, 000h, 0DCh, 066h, 066h, 07Ch, 060h, 0F0h; 070
//db 000h, 000h, 076h, 0CCh, 0CCh, 07Ch, 00Ch, 01Eh; 071
//db 000h, 000h, 0DCh, 076h, 066h, 060h, 0F0h, 000h; 072
//db 000h, 000h, 07Ch, 0C0h, 078h, 00Ch, 0F8h, 000h; 073
//db 010h, 030h, 07Ch, 030h, 030h, 034h, 018h, 000h; 074
//db 000h, 000h, 0CCh, 0CCh, 0CCh, 0CCh, 076h, 000h; 075
//db 000h, 000h, 0CCh, 0CCh, 0CCh, 078h, 030h, 000h; 076
//db 000h, 000h, 0C6h, 0D6h, 0FEh, 0FEh, 06Ch, 000h; 077
//db 000h, 000h, 0C6h, 06Ch, 038h, 06Ch, 0C6h, 000h; 078
//db 000h, 000h, 0CCh, 0CCh, 0CCh, 07Ch, 00Ch, 0F8h; 079
//db 000h, 000h, 0FCh, 098h, 030h, 064h, 0FCh, 000h; 07A
//db 01Ch, 030h, 030h, 0E0h, 030h, 030h, 01Ch, 000h; 07B
//db 018h, 018h, 018h, 000h, 018h, 018h, 018h, 000h; 07C
//db 0E0h, 030h, 030h, 01Ch, 030h, 030h, 0E0h, 000h; 07D
//db 076h, 0DCh, 000h, 000h, 000h, 000h, 000h, 000h; 07E
//db 000h, 010h, 038h, 06Ch, 0C6h, 0C6h, 0FEh, 000h; 07F
//db 01Eh, 036h, 066h, 066h, 07Eh, 066h, 066h, 000h; 080
//db 07Ch, 060h, 060h, 07Ch, 066h, 066h, 07Ch, 000h; 081
//db 07Ch, 066h, 066h, 07Ch, 066h, 066h, 07Ch, 000h; 082
//db 07Eh, 060h, 060h, 060h, 060h, 060h, 060h, 000h; 083
//db 038h, 06Ch, 06Ch, 06Ch, 06Ch, 06Ch, 0FEh, 0C6h; 084
//db 07Eh, 060h, 060h, 07Ch, 060h, 060h, 07Eh, 000h; 085
//db 0DBh, 0DBh, 07Eh, 03Ch, 07Eh, 0DBh, 0DBh, 000h; 086
//db 03Ch, 066h, 006h, 01Ch, 006h, 066h, 03Ch, 000h; 087
//db 066h, 066h, 06Eh, 07Eh, 076h, 066h, 066h, 000h; 088
//db 03Ch, 066h, 06Eh, 07Eh, 076h, 066h, 066h, 000h; 089
//db 066h, 06Ch, 078h, 070h, 078h, 06Ch, 066h, 000h; 08A
//db 01Eh, 036h, 066h, 066h, 066h, 066h, 066h, 000h; 08B
//db 0C6h, 0EEh, 0FEh, 0FEh, 0D6h, 0C6h, 0C6h, 000h; 08C
//db 066h, 066h, 066h, 07Eh, 066h, 066h, 066h, 000h; 08D
//db 03Ch, 066h, 066h, 066h, 066h, 066h, 03Ch, 000h; 08E
//db 07Eh, 066h, 066h, 066h, 066h, 066h, 066h, 000h; 08F
//db 07Ch, 066h, 066h, 066h, 07Ch, 060h, 060h, 000h; 090
//db 03Ch, 066h, 060h, 060h, 060h, 066h, 03Ch, 000h; 091
//db 07Eh, 018h, 018h, 018h, 018h, 018h, 018h, 000h; 092
//db 066h, 066h, 066h, 03Eh, 006h, 066h, 03Ch, 000h; 093
//db 07Eh, 0DBh, 0DBh, 0DBh, 07Eh, 018h, 018h, 000h; 094
//db 066h, 066h, 03Ch, 018h, 03Ch, 066h, 066h, 000h; 095
//db 066h, 066h, 066h, 066h, 066h, 066h, 07Fh, 003h; 096
//db 066h, 066h, 066h, 03Eh, 006h, 006h, 006h, 000h; 097
//db 0DBh, 0DBh, 0DBh, 0DBh, 0DBh, 0DBh, 0FFh, 000h; 098
//db 0DBh, 0DBh, 0DBh, 0DBh, 0DBh, 0DBh, 0FFh, 003h; 099
//db 0E0h, 060h, 060h, 07Ch, 066h, 066h, 07Ch, 000h; 09A
//db 0C6h, 0C6h, 0C6h, 0F6h, 0DEh, 0DEh, 0F6h, 000h; 09B
//db 060h, 060h, 060h, 07Ch, 066h, 066h, 07Ch, 000h; 09C
//db 078h, 08Ch, 006h, 03Eh, 006h, 08Ch, 078h, 000h; 09D
//db 0CEh, 0DBh, 0DBh, 0FBh, 0DBh, 0DBh, 0CEh, 000h; 09E
//db 03Eh, 066h, 066h, 066h, 03Eh, 036h, 066h, 000h; 09F
//db 000h, 000h, 078h, 00Ch, 07Ch, 0CCh, 076h, 000h; 0A0
//db 000h, 03Ch, 060h, 03Ch, 066h, 066h, 03Ch, 000h; 0A1
//db 000h, 000h, 07Ch, 066h, 07Ch, 066h, 07Ch, 000h; 0A2
//db 000h, 000h, 07Eh, 060h, 060h, 060h, 060h, 000h; 0A3
//db 000h, 000h, 03Ch, 06Ch, 06Ch, 06Ch, 0FEh, 0C6h; 0A4
//db 000h, 000h, 03Ch, 066h, 07Eh, 060h, 03Ch, 000h; 0A5
//db 000h, 000h, 0DBh, 07Eh, 03Ch, 07Eh, 0DBh, 000h; 0A6
//db 000h, 000h, 03Ch, 066h, 00Ch, 066h, 03Ch, 000h; 0A7
//db 000h, 000h, 066h, 06Eh, 07Eh, 076h, 066h, 000h; 0A8
//db 000h, 018h, 066h, 06Eh, 07Eh, 076h, 066h, 000h; 0A9
//db 000h, 000h, 066h, 06Ch, 078h, 06Ch, 066h, 000h; 0AA
//db 000h, 000h, 01Eh, 036h, 066h, 066h, 066h, 000h; 0AB
//db 000h, 000h, 0C6h, 0FEh, 0FEh, 0D6h, 0C6h, 000h; 0AC
//db 000h, 000h, 066h, 066h, 07Eh, 066h, 066h, 000h; 0AD
//db 000h, 000h, 03Ch, 066h, 066h, 066h, 03Ch, 000h; 0AE
//db 000h, 000h, 07Eh, 066h, 066h, 066h, 066h, 000h; 0AF
//db 011h, 044h, 011h, 044h, 011h, 044h, 011h, 044h; 0B0
//db 055h, 0AAh, 055h, 0AAh, 055h, 0AAh, 055h, 0AAh; 0B1
//db 0DDh, 077h, 0DDh, 077h, 0DDh, 077h, 0DDh, 077h; 0B2
//db 018h, 018h, 018h, 018h, 018h, 018h, 018h, 018h; 0B3
//db 018h, 018h, 018h, 0F8h, 018h, 018h, 018h, 018h; 0B4
//db 018h, 0F8h, 018h, 0F8h, 018h, 018h, 018h, 018h; 0B5
//db 036h, 036h, 036h, 0F6h, 036h, 036h, 036h, 036h; 0B6
//db 000h, 000h, 000h, 0FEh, 036h, 036h, 036h, 036h; 0B7
//db 000h, 0F8h, 018h, 0F8h, 018h, 018h, 018h, 018h; 0B8
//db 036h, 0F6h, 006h, 0F6h, 036h, 036h, 036h, 036h; 0B9
//db 036h, 036h, 036h, 036h, 036h, 036h, 036h, 036h; 0BA
//db 000h, 0FEh, 006h, 0F6h, 036h, 036h, 036h, 036h; 0BB
//db 036h, 0F6h, 006h, 0FEh, 000h, 000h, 000h, 000h; 0BC
//db 036h, 036h, 036h, 0FEh, 000h, 000h, 000h, 000h; 0BD
//db 018h, 0F8h, 018h, 0F8h, 000h, 000h, 000h, 000h; 0BE
//db 000h, 000h, 000h, 0F8h, 018h, 018h, 018h, 018h; 0BF
//db 018h, 018h, 018h, 01Fh, 000h, 000h, 000h, 000h; 0C0
//db 018h, 018h, 018h, 0FFh, 000h, 000h, 000h, 000h; 0C1
//db 000h, 000h, 000h, 0FFh, 018h, 018h, 018h, 018h; 0C2
//db 018h, 018h, 018h, 01Fh, 018h, 018h, 018h, 018h; 0C3
//db 000h, 000h, 000h, 0FFh, 000h, 000h, 000h, 000h; 0C4
//db 018h, 018h, 018h, 0FFh, 018h, 018h, 018h, 018h; 0C5
//db 018h, 01Fh, 018h, 01Fh, 018h, 018h, 018h, 018h; 0C6
//db 036h, 036h, 036h, 037h, 036h, 036h, 036h, 036h; 0C7
//db 036h, 037h, 030h, 03Fh, 000h, 000h, 000h, 000h; 0C8
//db 000h, 03Fh, 030h, 037h, 036h, 036h, 036h, 036h; 0C9
//db 036h, 0F7h, 000h, 0FFh, 000h, 000h, 000h, 000h; 0CA
//db 000h, 0FFh, 000h, 0F7h, 036h, 036h, 036h, 036h; 0CB
//db 036h, 037h, 030h, 037h, 036h, 036h, 036h, 036h; 0CC
//db 000h, 0FFh, 000h, 0FFh, 000h, 000h, 000h, 000h; 0CD
//db 036h, 0F7h, 000h, 0F7h, 036h, 036h, 036h, 036h; 0CE
//db 018h, 0FFh, 000h, 0FFh, 000h, 000h, 000h, 000h; 0CF
//db 036h, 036h, 036h, 0FFh, 000h, 000h, 000h, 000h; 0D0
//db 000h, 0FFh, 000h, 0FFh, 018h, 018h, 018h, 018h; 0D1
//db 000h, 000h, 000h, 0FFh, 036h, 036h, 036h, 036h; 0D2
//db 036h, 036h, 036h, 03Fh, 000h, 000h, 000h, 000h; 0D3
//db 018h, 01Fh, 018h, 01Fh, 000h, 000h, 000h, 000h; 0D4
//db 000h, 01Fh, 018h, 01Fh, 018h, 018h, 018h, 018h; 0D5
//db 000h, 000h, 000h, 03Fh, 036h, 036h, 036h, 036h; 0D6
//db 036h, 036h, 036h, 0FFh, 036h, 036h, 036h, 036h; 0D7
//db 018h, 0FFh, 018h, 0FFh, 018h, 018h, 018h, 018h; 0D8
//db 018h, 018h, 018h, 0F8h, 000h, 000h, 000h, 000h; 0D9
//db 000h, 000h, 000h, 01Fh, 018h, 018h, 018h, 018h; 0DA
//db 0FFh, 0FFh, 0FFh, 0FFh, 0FFh, 0FFh, 0FFh, 0FFh; 0DB
//db 000h, 000h, 000h, 0FFh, 0FFh, 0FFh, 0FFh, 0FFh; 0DC
//db 0F0h, 0F0h, 0F0h, 0F0h, 0F0h, 0F0h, 0F0h, 0F0h; 0DD
//db 00Fh, 00Fh, 00Fh, 00Fh, 00Fh, 00Fh, 00Fh, 00Fh; 0DE
//db 0FFh, 0FFh, 0FFh, 000h, 000h, 000h, 000h, 000h; 0DF
//db 000h, 000h, 07Ch, 066h, 066h, 07Ch, 060h, 000h; 0E0
//db 000h, 000h, 03Ch, 066h, 060h, 066h, 03Ch, 000h; 0E1
//db 000h, 000h, 07Eh, 018h, 018h, 018h, 018h, 000h; 0E2
//db 000h, 000h, 066h, 066h, 03Eh, 006h, 03Ch, 000h; 0E3
//db 000h, 000h, 07Eh, 0DBh, 0DBh, 07Eh, 018h, 000h; 0E4
//db 000h, 000h, 066h, 03Ch, 018h, 03Ch, 066h, 000h; 0E5
//db 000h, 000h, 066h, 066h, 066h, 066h, 07Fh, 003h; 0E6
//db 000h, 000h, 066h, 066h, 03Eh, 006h, 006h, 000h; 0E7
//db 000h, 000h, 0DBh, 0DBh, 0DBh, 0DBh, 0FFh, 000h; 0E8
//db 000h, 000h, 0DBh, 0DBh, 0DBh, 0DBh, 0FFh, 003h; 0E9
//db 000h, 000h, 0E0h, 060h, 07Ch, 066h, 07Ch, 000h; 0EA
//db 000h, 000h, 0C6h, 0C6h, 0F6h, 0DEh, 0F6h, 000h; 0EB
//db 000h, 000h, 060h, 060h, 07Ch, 066h, 07Ch, 000h; 0EC
//db 000h, 000h, 07Ch, 006h, 03Eh, 006h, 07Ch, 000h; 0ED
//db 000h, 000h, 0CEh, 0DBh, 0FBh, 0DBh, 0CEh, 000h; 0EE
//db 000h, 000h, 03Eh, 066h, 03Eh, 036h, 066h, 000h; 0EF
//db 06Ch, 0FEh, 080h, 0F8h, 080h, 080h, 0FEh, 000h; 0F0
//db 06Ch, 000h, 07Ch, 082h, 0FEh, 080h, 07Eh, 000h; 0F1
//db 03Ch, 062h, 0C0h, 0F8h, 0C0h, 062h, 03Ch, 000h; 0F2
//db 000h, 000h, 03Eh, 060h, 07Ch, 060h, 03Eh, 000h; 0F3
//db 048h, 078h, 030h, 030h, 030h, 030h, 078h, 000h; 0F4
//db 050h, 000h, 070h, 030h, 030h, 030h, 078h, 000h; 0F5
//db 000h, 018h, 018h, 000h, 07Eh, 000h, 018h, 018h; 0F6
//db 000h, 076h, 0DCh, 000h, 076h, 0DCh, 000h, 000h; 0F7
//db 000h, 038h, 06Ch, 06Ch, 038h, 000h, 000h, 000h; 0F8
//db 000h, 000h, 000h, 000h, 018h, 000h, 000h, 000h; 0F9
//db 000h, 000h, 000h, 038h, 038h, 000h, 000h, 000h; 0FA
//db 003h, 002h, 006h, 004h, 0CCh, 068h, 038h, 010h; 0FB
//db 08Bh, 0CBh, 0E8h, 0B8h, 098h, 088h, 088h, 000h; 0FC
//db 030h, 048h, 010h, 020h, 078h, 000h, 000h, 000h; 0FD
//db 000h, 000h, 07Ch, 07Ch, 07Ch, 07Ch, 000h, 000h; 0FE
//db 000h, 000h, 000h, 000h, 000h, 000h, 000h, 000h; 0FF

// 000 - ������
// 001 - !
// 002 - "
// 003 - #
// 004 - $
// 005 - %
// 006 - &
// 007 - '
// 008 - (
// 009 - )
// 00A - *
// 00B - +
// 00C - ,
// 00D - -
// 00E - .
// 00F - /
// 010 - 0
// 011 - 1
// 012 - 2
// 013 - 3
// 014 - 4
// 015 - 5
// 016 - 6
// 017 - 7
// 018 - 8
// 019 - 9
// 01A - :
// 01B - ;
// 01C - <
// 01D - =
// 01E - >
// 01F - ?
// 020 - @
// ������
// 021 - A - �
// 022 - B - �
// 023 - C - �
// 024 - D - �
// 025 - E - �
// 026 - F - �
// 027 - G - �
// 028 - H - �
// 029 - I - �
// 02A - J - �
// 02B - K - �
// 02C - L - �
// 02D - M - �
// 02E - N - �
// 02F - O - �
// 030 - P - �
// 031 - Q - �
// 032 - R - �
// 033 - S - �
// 034 - T - �
// 035 - U - �
// 036 - V - �
// 037 - W - �
// 038 - X - �
// 039 - Y - �
// 03A - Z - �
// 03B - ������� �����
// 03C - ������� ����
// 03D - ������� �����
// 03E - ������� ������
// 03F - _

unsigned char tmpCC[] = {
   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // 000 - ������
   0x18, 0x18, 0x18, 0x18, 0x00, 0x18, 0x18, 0x00, // 001 - !
   0x66, 0x66, 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, // 002 - "
   0x00, 0x66, 0xFF, 0x66, 0x66, 0xFF, 0x66, 0x00, // 003 - #
   0x18, 0x3E, 0x60, 0x3C, 0x06, 0x7C, 0x18, 0x00, // 004 - $
   0x00, 0x66, 0x6C, 0x18, 0x30, 0x66, 0x46, 0x00, // 005 - %
   0x1C, 0x36, 0x1C, 0x38, 0x6F, 0x66, 0x3B, 0x00, // 006 - &
   0x18, 0x18, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00, // 007 - '
   0x0E, 0x1C, 0x18, 0x18, 0x18, 0x1C, 0x0E, 0x00, // 008 - (
   0x70, 0x38, 0x18, 0x18, 0x18, 0x38, 0x70, 0x00, // 009 - )
   0x00, 0x66, 0x3C, 0xFF, 0x3C, 0x66, 0x00, 0x00, // 00A - *
   0x00, 0x18, 0x18, 0x7E, 0x18, 0x18, 0x00, 0x00, // 00B - +
   0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x18, 0x30, // 00C - ,
   0x00, 0x00, 0x00, 0x7E, 0x00, 0x00, 0x00, 0x00, // 00D - -
   0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x18, 0x00, // 00E - .
   0x02, 0x06, 0x0C, 0x18, 0x30, 0x60, 0x40, 0x00, // 00F - /
   0x3C, 0x66, 0x6E, 0x7E, 0x76, 0x66, 0x3C, 0x00, // 010 - 0
   0x18, 0x38, 0x18, 0x18, 0x18, 0x18, 0x7E, 0x00, // 011 - 1
   0x3C, 0x66, 0x06, 0x0C, 0x18, 0x30, 0x7E, 0x00, // 012 - 2
   0x7E, 0x0C, 0x18, 0x0C, 0x06, 0x66, 0x3C, 0x00, // 013 - 3
   0x0C, 0x1C, 0x3C, 0x6C, 0x6C, 0x7E, 0x0C, 0x00, // 014 - 4
   0x7E, 0x60, 0x7C, 0x06, 0x06, 0x66, 0x3C, 0x00, // 015 - 5
   0x3C, 0x60, 0x60, 0x7C, 0x66, 0x66, 0x3C, 0x00, // 016 - 6
   0x7E, 0x06, 0x0C, 0x18, 0x30, 0x30, 0x30, 0x00, // 017 - 7
   0x3C, 0x66, 0x66, 0x3C, 0x66, 0x66, 0x3C, 0x00, // 018 - 8
   0x3C, 0x66, 0x66, 0x3E, 0x06, 0x0C, 0x38, 0x00, // 019 - 9
   0x00, 0x18, 0x18, 0x00, 0x00, 0x18, 0x18, 0x00, // 01A - :
   0x00, 0x18, 0x18, 0x00, 0x00, 0x18, 0x18, 0x30, // 01B - ;
   0x06, 0x0C, 0x18, 0x30, 0x18, 0x0C, 0x06, 0x00, // 01C - <
   0x00, 0x00, 0x7E, 0x00, 0x00, 0x7E, 0x00, 0x00, // 01D - =
   0x60, 0x30, 0x18, 0x0C, 0x18, 0x30, 0x60, 0x00, // 01E - >
   0x3C, 0x66, 0x04, 0x0C, 0x18, 0x00, 0x18, 0x00, // 01F - ?
   0x7C, 0x82, 0x9E, 0xA2, 0x9E, 0x80, 0x7E, 0x00, // 020 - @
   0x1E, 0x36, 0x66, 0x66, 0x7E, 0x66, 0x66, 0x00, // 021 - A - � 
   0x7C, 0x60, 0x60, 0x7C, 0x66, 0x66, 0x7C, 0x00, // 022 - B - �
   0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x7F, 0x03, // 023 - C - �
   0x38, 0x6C, 0x6C, 0x6C, 0x6C, 0x6C, 0xFE, 0xC6, // 024 - D - �
   0x7E, 0x60, 0x60, 0x7C, 0x60, 0x60, 0x7E, 0x00, // 025 - E - �
   0x7E, 0xDB, 0xDB, 0xDB, 0x7E, 0x18, 0x18, 0x00, // 026 - F - �
   0x7E, 0x60, 0x60, 0x60, 0x60, 0x60, 0x60, 0x00, // 027 - G - �
   0x66, 0x66, 0x3C, 0x18, 0x3C, 0x66, 0x66, 0x00, // 028 - H - �
   0x66, 0x66, 0x6E, 0x7E, 0x76, 0x66, 0x66, 0x00, // 029 - I - �
   0x3C, 0x66, 0x6E, 0x7E, 0x76, 0x66, 0x66, 0x00, // 02A - J - �
   0x66, 0x6C, 0x78, 0x70, 0x78, 0x6C, 0x66, 0x00, // 02B - K - �
   0x1E, 0x36, 0x66, 0x66, 0x66, 0x66, 0x66, 0x00, // 02C - L - �
   0xC6, 0xEE, 0xFE, 0xFE, 0xD6, 0xC6, 0xC6, 0x00, // 02D - M - �
   0x66, 0x66, 0x66, 0x7E, 0x66, 0x66, 0x66, 0x00, // 02E - N - �
   0x3C, 0x66, 0x66, 0x66, 0x66, 0x66, 0x3C, 0x00, // 02F - O - �
   0x7E, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x00, // 030 - P - �
   0x3E, 0x66, 0x66, 0x66, 0x3E, 0x36, 0x66, 0x00, // 031 - Q - �
   0x7C, 0x66, 0x66, 0x66, 0x7C, 0x60, 0x60, 0x00, // 032 - R - �
   0x3C, 0x66, 0x60, 0x60, 0x60, 0x66, 0x3C, 0x00, // 033 - S - �
   0x7E, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x00, // 034 - T - �
   0x66, 0x66, 0x66, 0x3E, 0x06, 0x66, 0x3C, 0x00, // 035 - U - �
   0xDB, 0xDB, 0x7E, 0x3C, 0x7E, 0xDB, 0xDB, 0x00, // 036 - V - �
   0x7C, 0x66, 0x66, 0x7C, 0x66, 0x66, 0x7C, 0x00, // 037 - W - �
   0x60, 0x60, 0x60, 0x7C, 0x66, 0x66, 0x7C, 0x00, // 038 - X - �
   0xC6, 0xC6, 0xC6, 0xF6, 0xDE, 0xDE, 0xF6, 0x00, // 039 - Y - �
   0x3C, 0x66, 0x06, 0x1C, 0x06, 0x66, 0x3C, 0x00, // 03A - Z - �
   0x00, 0x18, 0x3C, 0x7E, 0x18, 0x18, 0x18, 0x00, // 03B - ������� �����
   0x00, 0x18, 0x18, 0x18, 0x7E, 0x3C, 0x18, 0x00, // 03C - ������� ����
   0x00, 0x18, 0x30, 0x7E, 0x30, 0x18, 0x00, 0x00, // 03D - ������� �����
   0x00, 0x18, 0x0C, 0x7E, 0x0C, 0x18, 0x00, 0x00, // 03E - ������� ������
   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, // 03F - _
};

char origChars[] = {
  // ������������ �����
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 000 - ������ 
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
  0x00,0x18,0x3C,0x7E,0x18,0x18,0x18,0x00, // 03B - ������� �����
  0x00,0x18,0x18,0x18,0x7E,0x3C,0x18,0x00, // 03C - ������� ����
  0x00,0x18,0x30,0x7E,0x30,0x18,0x00,0x00, // 03D - ������� �����
  0x00,0x18,0x0C,0x7E,0x0C,0x18,0x00,0x00, // 03E - ������� ������
  0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00, // 03F - _
  // ���������
  0x1E,0x36,0x66,0x66,0x7E,0x66,0x66,0x00, // 040 - �
  0x7C,0x60,0x60,0x7C,0x66,0x66,0x7C,0x00, // 041 - �
  0x7C,0x66,0x66,0x7C,0x66,0x66,0x7C,0x00, // 042 - �
  0x7E,0x60,0x60,0x60,0x60,0x60,0x60,0x00, // 043 - �
  0x38,0x6C,0x6C,0x6C,0x6C,0x6C,0xFE,0xC6, // 044 - �
  0x7E,0x60,0x60,0x7C,0x60,0x60,0x7E,0x00, // 045 - �
  0xDB,0xDB,0x7E,0x3C,0x7E,0xDB,0xDB,0x00, // 046 - �
  0x3C,0x66,0x06,0x1C,0x06,0x66,0x3C,0x00, // 047 - �
  0x66,0x66,0x6E,0x7E,0x76,0x66,0x66,0x00, // 048 - �
  0x3C,0x66,0x6E,0x7E,0x76,0x66,0x66,0x00, // 049 - �
  0x66,0x6C,0x78,0x70,0x78,0x6C,0x66,0x00, // 04A - �
  0x1E,0x36,0x66,0x66,0x66,0x66,0x66,0x00, // 04B - �
  0xC6,0xEE,0xFE,0xFE,0xD6,0xC6,0xC6,0x00, // 04C - �
  0x66,0x66,0x66,0x7E,0x66,0x66,0x66,0x00, // 04D - �
  0x3C,0x66,0x66,0x66,0x66,0x66,0x3C,0x00, // 04E - �
  0x7E,0x66,0x66,0x66,0x66,0x66,0x66,0x00, // 04F - �
  0x7C,0x66,0x66,0x66,0x7C,0x60,0x60,0x00, // 050 - �
  0x3C,0x66,0x60,0x60,0x60,0x66,0x3C,0x00, // 051 - �
  0x7E,0x18,0x18,0x18,0x18,0x18,0x18,0x00, // 052 - �
  0x66,0x66,0x66,0x3E,0x06,0x66,0x3C,0x00, // 053 - �
  0x7E,0xDB,0xDB,0xDB,0x7E,0x18,0x18,0x00, // 054 - �
  0x66,0x66,0x3C,0x18,0x3C,0x66,0x66,0x00, // 055 - �
  0x66,0x66,0x66,0x66,0x66,0x66,0x7F,0x03, // 056 - �
  0x66,0x66,0x66,0x3E,0x06,0x06,0x06,0x00, // 057 - �
  0xDB,0xDB,0xDB,0xDB,0xDB,0xDB,0xFF,0x00, // 058 - �
  0xDB,0xDB,0xDB,0xDB,0xDB,0xDB,0xFF,0x03, // 059 - �
  0xE0,0x60,0x60,0x7C,0x66,0x66,0x7C,0x00, // 05A - �
  0xC6,0xC6,0xC6,0xF6,0xDE,0xDE,0xF6,0x00, // 05B - �
  0x60,0x60,0x60,0x7C,0x66,0x66,0x7C,0x00, // 05C - �
  0x78,0x8C,0x06,0x3E,0x06,0x8C,0x78,0x00, // 05D - �
  0xCE,0xDB,0xDB,0xFB,0xDB,0xDB,0xCE,0x00, // 05E - �
  0x3E,0x66,0x66,0x66,0x3E,0x36,0x66,0x00, // 05F - �
};

unsigned char nullChars[] = {
  0x52,0x45,0x51,0x52,'0', 0x00,0x00,0x00, // 000
  0x52,0x45,0x51,0x52,'1', 0x00,0x00,0x00, // 001
  0x52,0x45,0x51,0x52,'2', 0x00,0x00,0x00, // 002
  0x52,0x45,0x51,0x52,'3', 0x00,0x00,0x00, // 003
  0x52,0x45,0x51,0x52,'4', 0x00,0x00,0x00, // 004
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 005
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 006
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 007
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 008
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 009
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 00A
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 00B
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 00C
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 00D
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 00E
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 00F
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 010
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 011
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 012
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 013
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 014
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 015
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 016
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 017
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 018
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 019
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 01A
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 01B
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 01C
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 01D
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 01E
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 01F
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 020
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 021
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 022
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 023
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 024
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 025
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 026
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 027
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 028
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 029
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 02A
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 02B
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 02C
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 02D
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 02E
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 02F
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 030
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 031
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 032
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 033
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 034
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 035
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 036
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 037
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 038
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 039
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 03A
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 03B
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 03C
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 03D
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 03E
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // 03F
};

// ������� �������
// 0000 00000200

// 0D03 00000F03   8A 87 0C 4D    moval, [bx + 4D0C] ;������ �� ������

// ������� ������
// 0000 000109B0

// ������ 
// 4D0C 000156BC - 0E5F 0001180F
unsigned char addrFonts[] = { 0x5F, 0x0E }; // ����� �����

//0E5F 0001180F - 4D0C 000156BC
unsigned char addrMsg0[] = { 0x0C, 0x4D }; // ����� �����
//������ �� ��������� �� ������ 000117FF
//SERVICES RENDERED, SECRETS UNFOLD\nTHE BROTHERS TOGETHER\nLEAD TO TREASURES UNTOLD\n\nFIVE TOWNS YOU MUST TRAVEL\nFOR THIS QUEST TO UNRAVEL 
//������� ������, ��������� ����\n������ ��������� � ��������� ������ ����\n\n� ���� ������� �������,��� ����� �������

//0EE6 00011896 - 4D14 000156C4
unsigned char addrMsg1[] = { 0x14, 0x4D }; // ����� �����
//������ �� ��������� �� ������ 00011801
//SEEK THE WIZARD RANALOU\nIN HIS LAIR AT THE KORIN BLUFFS\nSIX CASTLES HE WILL SEND YOU TO\nBUT DOOM WILL BE QUITE TOUGH!\nCRUELTY AND KINDNESS\nMEASURED THROUGHOUT\nJUDGEMENT DAY IS THEN SOUGHT OUT
//��� ������� Ranalou\n� ��� ������� � KORIN BLUFFS\n�������� �� ���� � ����� ������\n�� DOOM ����� ����� �������!\n����� � ���, ����������� �����,\n�������� � ������ ����

//0FA6 00011956 - 4D1C 000156CC
unsigned char addrMsg2[] = { 0x1C, 0x4D }; // ����� �����
//������ �� ��������� �� ������  00011803
//ONE BY WATER, ONE BY LAND\nONE BY AIR, AND ONE BY SAND\nTHE WHEEL OF LUCK\nWILL FAVORABLY PAY, THE MORE OF THESE\nMENACING BEASTS YOU SLAY!\nALTHOUGH WISHES MAY COME TRUE\nALL THE BEASTS WILL BECOME ANEW
//���� �� �����, ���� � ����,\n���� � �������, ���� �� �����\n��� ������ ����� ����������,\n��� ����� ������������ ������ �����.\n������� ���������, ������ ������������.

//106C 00011956 - 4D24 000156D4
unsigned char addrMsg3[] = { 0x24, 0x4D }; // ����� �����
//������ �� ��������� �� ������  00011805
//THERE ARE MANY DUNGEONS LIKE ME\nFIND THE RIGHT PAIR\nAND YOU'LL DISCOVER THE KEY\nTHE ANCIENT SEER OG HAS LOST HIS SIGHT\nTHE IDOLS WILL HELP TO END HIS PLIGHT
//���� ����� ����� �� ������\n����� ���������� ����\n� �� �������� ����\n������� �������� �� ������� ���� ������\n����� ������� ����� ���� 

//1109 00011AB9 - 4D2C 000156DC
unsigned char addrMsg4[] = { 0x2C, 0x4D }; // ����� �����
//������ �� ��������� �� ������  00011807
//IN HONOR OF CORAK...\n\nFOR HIS MAPPING EXPEDITION\nOF THE LAND OF VARN AND REDISCOVERY\nOF THE LOST TOWN OF DUSK
//�� ����� ������...\n\n�� ��� ���������������� ����������\n�� ����� VARN � ��������\n����� ����������� ������ Dusk

typedef struct {
  unsigned int addr;
  char msg[255];
  unsigned int addrOfAddr;
  unsigned short newAddr;
} msg;

msg messages[] = {
  // 0D14 000116C4
  //  ARE YOU READY?
  //    �� ������?  
  { 0x000116C4, "   �� ������?  ", 0, 0 },

  // 0D26 000116D6
  //THEN PRESS ENTER!
  // ������� ENTER!
  { 0x000116D6, " ������� ENTER!  ", 0, 0 },

///////////////////////////////////////////////////////////////////////////////
  //OPTIONS
  //��������
  { 0x00012B24, "��������", 0, 0 },

  // 217C
  //-------
  //--------
  { 0x00012B24 + 9, "--------", 0x0000547E, 0x00012B24 + 9 - 0x000109B0 },

  // 2184 00012B34
  //'C'.......CREATE NEW CHARACTERS
  //'C'.......�������� ����������
  { 0x00012B24 + 9 + 9, "'C'.......�������� ����������", 0x00005495, 0x00012B24 + 9 + 9 - 0x000109B0 },

  // 21A4
  //'V'.......VIEW ALL CHARACTERS
  //'V'.......������ ����������
  { 0x00012B24 + 9 + 9 + 30, "'V'.......������ ����������", 0x000054AC, 0x00012B24 + 9 + 9 + 30 - 0x000109B0 },

  // 21C2
  //'#'.......GO TO TOWN
  //'#'.......����� ������
  { 0x00012B24 + 9 + 9 + 30 + 28, "'#'.......����� ������", 0x000054C3, 0x00012B24 + 9 + 9 + 30 + 28 - 0x000109B0 },

  { 0, "", 0, 0 }
};



char msg1[] = " ������� ENTER!  ";

void performRus(const char* inStr, 
                unsigned char* outBuf, unsigned int* outBufL) {
  int i = 0;
  while ((char)*inStr) {
    switch ((char)*inStr) {
      case '�': case '�': outBuf[i] = 0x40 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x41 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x42 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x43 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x44 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x45 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x46 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x47 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x48 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x49 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x4A + 0x20; break;
      case '�': case '�': outBuf[i] = 0x4B + 0x20; break;
      case '�': case '�': outBuf[i] = 0x4C + 0x20; break;
      case '�': case '�': outBuf[i] = 0x4D + 0x20; break;
      case '�': case '�': outBuf[i] = 0x4E + 0x20; break;
      case '�': case '�': outBuf[i] = 0x4F + 0x20; break;
      case '�': case '�': outBuf[i] = 0x50 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x51 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x52 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x53 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x54 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x55 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x56 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x57 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x58 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x59 + 0x20; break;
      case '�': case '�': outBuf[i] = 0x5A + 0x20; break;
      case '�': case '�': outBuf[i] = 0x5B + 0x20; break;
      case '�': case '�': outBuf[i] = 0x5C + 0x20; break;
      case '�': case '�': outBuf[i] = 0x5D + 0x20; break;
      case '�': case '�': outBuf[i] = 0x5E + 0x20; break;
      case '�': case '�': outBuf[i] = 0x5F + 0x20; break;
      default: outBuf[i] = (unsigned char)*inStr;  break;
    }
    i++; inStr++;
  }
  outBuf[i] = 0;
  *outBufL = i + 1;
}

void main() {

  FILE* fp = fopen("c:\\Projects.side\\MM.Parser\\MM.Parser\\mm.exe", "r+b");
  // ������� ����� ������ �� ����� �������
  fseek(fp, 0x000156BC, SEEK_SET);
  fwrite(nullChars, 1, sizeof(nullChars), fp);
  // ������� ������� �� ����� ������
  fseek(fp, 0x0001180F, SEEK_SET);
  fwrite(origChars, 1, sizeof(origChars), fp);
  // ������ ������ �� ������
  fseek(fp, 0x00000F05, SEEK_SET);
  fwrite(addrFonts, 1, sizeof(addrFonts), fp);
  // ������ ������ �� ���������
  fseek(fp, 0x000117FF, SEEK_SET);
  fwrite(addrMsg0, 1, sizeof(addrMsg0), fp);
  fseek(fp, 0x00011801, SEEK_SET);
  fwrite(addrMsg1, 1, sizeof(addrMsg1), fp);
  fseek(fp, 0x00011803, SEEK_SET);
  fwrite(addrMsg2, 1, sizeof(addrMsg2), fp);
  fseek(fp, 0x00011805, SEEK_SET);
  fwrite(addrMsg3, 1, sizeof(addrMsg3), fp);
  fseek(fp, 0x00011807, SEEK_SET);
  fwrite(addrMsg4, 1, sizeof(addrMsg4), fp);

  unsigned char tmpS[1024] = { 0 };
  unsigned int tmpSl = 0;
  int i = 0;
  while (messages[i].addr) {
    fseek(fp, messages[i].addr, SEEK_SET);
    performRus(messages[i].msg, tmpS, &tmpSl);
    fwrite(tmpS, 1, tmpSl, fp);

    if (messages[i].addrOfAddr) {
      fseek(fp, messages[i].addrOfAddr, SEEK_SET);
      fwrite(&messages[i].newAddr, 1, sizeof(unsigned short), fp);
    }

    i++;
  }

  fclose(fp);
}

//void main() {
//  FILE* fp = fopen("c:\\Projects.side\\MM.Parser\\MM.Parser\\mm.exe", "rb");
//  fseek(fp, 0x0156BC, SEEK_SET);
//  unsigned char chars[8 * 0xFF] = { 0 };
//  fread(chars, 1, 8 * 0xFF, fp);
//  fclose(fp);
//
//  for (int k = 0; k < 8 * 0xFF; k++) printf("0x%02X,", chars[k]);
//
//  //for (int i = 0; i < 0x40 + 5; i++) {
//  //  for (int j = 0; j < 8; j++) {
//  //    char curChar = chars[i * 8 + j];
//  //    if (curChar & 1) printf("X"); else printf(" ");
//  //    if (curChar & 2) printf("X"); else printf(" ");
//  //    if (curChar & 4) printf("X"); else printf(" ");
//  //    if (curChar & 8) printf("X"); else printf(" ");
//  //    if (curChar & 16) printf("X"); else printf(" ");
//  //    if (curChar & 32) printf("X"); else printf(" ");
//  //    if (curChar & 64) printf("X"); else printf(" ");
//  //    if (curChar & 128) printf("X"); else printf(" ");
//  //    printf("\n");
//  //  }
//  //}
//  //getch();
//}