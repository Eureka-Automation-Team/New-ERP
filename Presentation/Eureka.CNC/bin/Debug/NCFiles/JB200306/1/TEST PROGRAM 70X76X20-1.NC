%
O0011
(PROGRAM NAME -  TEST PROGRAM 70X76X20 )
(DATE=DD-MM-YY -  14-11-19  TIME=HH:MM -  09:30 )
N40
N100 G21
N102 G0 G17 G40 G49 G80 G90
( CD   TOOL - 1  DIA. OFF. - 1  LEN. - 1  DIA. - 8. )
N104 T1 M6
N106 G0 G90 G54 X10. Y-10. S1200 M3
N108 G43 H1 Z50.
N110 G98 G81 Z-2. R3. F110.
N112 X60.
N114 Y-66.
N116 X10.
N118 G80
N120 M5
N122 G91 G28 Z0.
N124 M01
( DRILL 5.2   TOOL - 4  DIA. OFF. - 4  LEN. - 4  DIA. - 5.2 )
N126 T4 M6
N128 G0 G90 G54 X10. Y-10. S1500 M3
N130 G43 H4 Z50.
N132 G98 G83 Z-25. R3. Q2. F120.
N134 X60.
N136 Y-66.
N138 X10.
N140 G80
N142 M5
N144 G91 G28 Z0.
G90 G80 G49 G40 G00.
G65 P9857 B1. Y#[11000+#4120] H0. 2
N146 M30
%
