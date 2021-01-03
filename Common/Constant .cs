﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{

    public static class Constant
    {

        public enum Turn { First, Second };
        public const int PLAYER_NUM = 2;
        public const int PIT_NUM = 6;
        public const int PIT_BIT_NUM = 8;
        public const long PIT_BIT_MASK = 0xff;
        public const long INITIAL_SEEDS = 0x040404040404; //下位バイトからstoreから遠いpitを示す。
        public const long EMPTY_SEEDS = 0;
        public const int MAX_SEED_NUM = 48;
        public const int HISTORY_SIZE = MAX_SEED_NUM * 3;
        public const int SOW_CYCLE_SIZE = PIT_NUM * 2 + 1;
        public static readonly long[] SEED_DIFFS = new long[PIT_NUM * (MAX_SEED_NUM + 1)]
                                            {
                                                0 , 255, 65790, 16843005, 4311810300, 1103823438075, 1103823438074, 1103823438073, 1103823438072, 1103823438071,
                                                1103823438070, 1103823438069, 1103823438068, 1103823438068, 1103823438323, 1103823503858, 1103840281073,
                                                1108135248368, 2207646876143, 2207646876142, 2207646876141, 2207646876140, 2207646876139, 2207646876138,
                                                2207646876137, 2207646876136, 2207646876136, 2207646876391, 2207646941926, 2207663719141, 2211958686436,
                                                3311470314211, 3311470314210, 3311470314209, 3311470314208, 3311470314207, 3311470314206, 3311470314205,
                                                3311470314204, 3311470314204, 3311470314459, 3311470379994, 3311487157209, 3315782124504, 4415293752279,
                                                4415293752278, 4415293752277, 4415293752276, 4415293752275,
                                                0, 65280, 16842240, 4311809280, 1103823436800, 1103823436544, 1103823436288, 1103823436032, 1103823435776,
                                                1103823435520, 1103823435264, 1103823435008, 1103823434753, 1103823434753, 1103823500033, 1103840276993,
                                                1108135244033, 2207646871553, 2207646871297, 2207646871041, 2207646870785, 2207646870529, 2207646870273,
                                                2207646870017, 2207646869761, 2207646869506, 2207646869506, 2207646934786, 2207663711746, 2211958678786,
                                                3311470306306, 3311470306050, 3311470305794, 3311470305538, 3311470305282, 3311470305026, 3311470304770,
                                                3311470304514, 3311470304259, 3311470304259, 3311470369539, 3311487146499, 3315782113539, 4415293741059,
                                                4415293740803, 4415293740547, 4415293740291, 4415293740035, 4415293739779,
                                                0, 16711680, 4311613440, 1103823175680, 1103823110144, 1103823044608, 1103822979072, 1103822913536,
                                                1103822848000, 1103822782464, 1103822716928, 1103822651393, 1103822586113, 1103822586113, 1103839297793,
                                                1108134199553, 2207645761793, 2207645696257, 2207645630721, 2207645565185, 2207645499649, 2207645434113,
                                                2207645368577, 2207645303041, 2207645237506, 2207645172226, 2207645172226, 2207661883906, 2211956785666,
                                                3311468347906, 3311468282370, 3311468216834, 3311468151298, 3311468085762, 3311468020226, 3311467954690,
                                                3311467889154, 3311467823619, 3311467758339, 3311467758339, 3311484470019, 3315779371779, 4415290934019,
                                                4415290868483, 4415290802947, 4415290737411, 4415290671875, 4415290606339, 4415290540803,
                                                0, 4278190080, 1103773040640, 1103756263424, 1103739486208, 1103722708992, 1103705931776, 1103689154560,
                                                1103672377344, 1103655600128, 1103638822913, 1103622045953, 1103605334273, 1103605334273, 1107883524353,
                                                2207378374913, 2207361597697, 2207344820481, 2207328043265, 2207311266049, 2207294488833, 2207277711617,
                                                2207260934401, 2207244157186, 2207227380226, 2207210668546, 2207210668546, 2211488858626, 3310983709186,
                                                3310966931970, 3310950154754, 3310933377538, 3310916600322, 3310899823106, 3310883045890, 3310866268674,
                                                3310849491459, 3310832714499, 3310816002819, 3310816002819, 3315094192899, 4414589043459, 4414572266243,
                                                4414555489027, 4414538711811, 4414521934595, 4414505157379, 4414488380163, 4414471602947,
                                                0, 1095216660480, 1090921693184, 1086626725888, 1082331758592, 1078036791296, 1073741824000, 1069446856704,
                                                1065151889408, 1060856922113, 1056561955073, 1052267053313, 1047988863233, 1047988863233, 2143205523713,
                                                2138910556417, 2134615589121, 2130320621825, 2126025654529, 2121730687233, 2117435719937, 2113140752641,
                                                2108845785346, 2104550818306, 2100255916546, 2095977726466, 2095977726466, 3191194386946, 3186899419650,
                                                3182604452354, 3178309485058, 3174014517762, 3169719550466, 3165424583170, 3161129615874, 3156834648579,
                                                3152539681539, 3148244779779, 3143966589699, 3143966589699, 4239183250179, 4234888282883, 4230593315587,
                                                4226298348291, 4222003380995, 4217708413699, 4213413446403, 4209118479107, 4204823511812,
                                                0, -1099511627776, -2199023255552, -3298534883328, -4398046511104, -5497558138880, -6597069766656,
                                                -7696581394432, -8796093022207, -9895604649727, -10995116211967, -12094611062527, -13189827723007,
                                                -13189827723007, -14289339350783, -15388850978559, -16488362606335, -17587874234111, -18687385861887,
                                                -19786897489663, -20886409117439, -21985920745214, -23085432372734, -24184943934974, -25284438785534,
                                                -26379655446014, -26379655446014, -27479167073790, -28578678701566, -29678190329342, -30777701957118,
                                                -31877213584894, -32976725212670, -34076236840446, -35175748468221, -36275260095741, -37374771657981,
                                                -38474266508541, -39569483169021, -39569483169021, -40668994796797, -41768506424573, -42868018052349,
                                                -43967529680125, -45067041307901, -46166552935677, -47266064563453, -48365576191228, -49465087818748,
                                            };

        public static readonly long[] OPPONENT_SEED_DIFFS = new long[PIT_NUM * (MAX_SEED_NUM + 1)]
                                            {
                                                0, 0, 0, 0, 0, 0, 0, 1, 257, 65793, 16843009, 4311810305, 1103823438081, 1103823438081, 1103823438081,
                                                1103823438081, 1103823438081, 1103823438081, 1103823438081, 1103823438081, 1103823438082, 1103823438338,
                                                1103823503874, 1103840281090, 1108135248386, 2207646876162, 2207646876162, 2207646876162, 2207646876162,
                                                2207646876162, 2207646876162, 2207646876162, 2207646876162, 2207646876163, 2207646876419, 2207646941955,
                                                2207663719171, 2211958686467, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243,
                                                3311470314243, 3311470314243, 3311470314243, 3311470314244, 3311470314500, 3311470380036,
                                                0, 0, 0, 0, 0, 0, 1, 257, 65793, 16843009, 4311810305, 1103823438081, 1103823438081, 1103823438081,
                                                1103823438081, 1103823438081, 1103823438081, 1103823438081, 1103823438081, 1103823438082, 1103823438338,
                                                1103823503874, 1103840281090, 1108135248386, 2207646876162, 2207646876162, 2207646876162, 2207646876162,
                                                2207646876162, 2207646876162, 2207646876162, 2207646876162, 2207646876163, 2207646876419, 2207646941955,
                                                2207663719171, 2211958686467, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243,
                                                3311470314243, 3311470314243, 3311470314243, 3311470314244, 3311470314500, 3311470380036, 3311487157252,
                                                0, 0, 0, 0, 0, 1, 257, 65793, 16843009, 4311810305, 1103823438081, 1103823438081, 1103823438081, 1103823438081,
                                                1103823438081, 1103823438081, 1103823438081, 1103823438081, 1103823438082, 1103823438338, 1103823503874,
                                                1103840281090, 1108135248386, 2207646876162, 2207646876162, 2207646876162, 2207646876162, 2207646876162,
                                                2207646876162, 2207646876162, 2207646876162, 2207646876163, 2207646876419, 2207646941955, 2207663719171,
                                                2211958686467, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243,
                                                3311470314243, 3311470314243, 3311470314244, 3311470314500, 3311470380036, 3311487157252, 3315782124548,
                                                0, 0, 0, 0, 1, 257, 65793, 16843009, 4311810305, 1103823438081, 1103823438081, 1103823438081, 1103823438081,
                                                1103823438081, 1103823438081, 1103823438081, 1103823438081, 1103823438082, 1103823438338, 1103823503874,
                                                1103840281090, 1108135248386, 2207646876162, 2207646876162, 2207646876162, 2207646876162, 2207646876162,
                                                2207646876162, 2207646876162, 2207646876162, 2207646876163, 2207646876419, 2207646941955, 2207663719171,
                                                2211958686467, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243,
                                                3311470314243, 3311470314243, 3311470314244, 3311470314500, 3311470380036, 3311487157252, 3315782124548,
                                                4415293752324,
                                                0, 0, 0, 1, 257, 65793, 16843009, 4311810305, 1103823438081, 1103823438081, 1103823438081, 1103823438081,
                                                1103823438081, 1103823438081, 1103823438081, 1103823438081, 1103823438082, 1103823438338, 1103823503874,
                                                1103840281090, 1108135248386, 2207646876162, 2207646876162, 2207646876162, 2207646876162, 2207646876162,
                                                2207646876162, 2207646876162, 2207646876162, 2207646876163, 2207646876419, 2207646941955, 2207663719171,
                                                2211958686467, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243,
                                                3311470314243, 3311470314243, 3311470314244, 3311470314500, 3311470380036, 3311487157252, 3315782124548,
                                                4415293752324, 4415293752324,
                                                0, 0, 1, 257, 65793, 16843009, 4311810305, 1103823438081, 1103823438081, 1103823438081, 1103823438081,
                                                1103823438081, 1103823438081, 1103823438081, 1103823438081, 1103823438082, 1103823438338, 1103823503874,
                                                1103840281090, 1108135248386, 2207646876162, 2207646876162, 2207646876162, 2207646876162, 2207646876162,
                                                2207646876162, 2207646876162, 2207646876162, 2207646876163, 2207646876419, 2207646941955, 2207663719171,
                                                2211958686467, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243, 3311470314243,
                                                3311470314243, 3311470314243, 3311470314244, 3311470314500, 3311470380036, 3311487157252, 3315782124548,
                                                4415293752324, 4415293752324, 4415293752324,
                                            };

        public static readonly int[] STORE_DIFFS = new int[PIT_NUM * (MAX_SEED_NUM + 1)]
                                           {
                                                0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3,
                                                3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4,
                                                0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3,
                                                3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4,
                                                0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3,
                                                3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4,
                                                0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                                                3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4,
                                                0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                                                3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4,
                                                0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                                                3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4,
                                            };

    }
}
