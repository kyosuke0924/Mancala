using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mancala
{
    static public class EvaluatorConst
    {
        public const int VALUE_PER_SEED = 100;
        public const int PATTERN_NUM = 60;
        public const int PATTERN_SIZE = 15 * 15 * 15;
        public const int MAX_SEED = 48;
        public static readonly int[] SEED_TO_INDEX_0 = new int[MAX_SEED]
                                   {
                                         0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
                                        14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
                                   };

        public static readonly int[] SEED_TO_INDEX_1 = new int[MAX_SEED]
                                   {
                                        0, 15, 30, 45, 60, 75, 90, 105, 120, 135, 150, 165, 180, 195, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210,
                                        210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210,
                                   };

        public static readonly int[] SEED_TO_INDEX_2 = new int[MAX_SEED]
                                   {
                                        0, 225, 450, 675, 900, 1125, 1350, 1575, 1800, 2025, 2250, 2475, 2700, 2925, 3150, 3150, 3150, 3150, 3150, 3150,
                                        3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150,
                                        3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150,
                                   };
    }


    public class Evaluator
    {
        private List<List<int>> Pattern_values { set; get;}

        public Evaluator()
        {
            Pattern_values = new List<List<int>>(EvaluatorConst.PATTERN_NUM);
            for (int i = 0; i < EvaluatorConst.PATTERN_NUM; i++)
            {
                Pattern_values.Add(new List<int>(Enumerable.Repeat(0, EvaluatorConst.PATTERN_NUM)));
            }
        }
        
        public void Load(string filePath)
        {
            FileStream fs = new System.IO.FileStream(filePath, FileMode.Open);
            try
            {
                int idx = 0;
                int readByte = 4;
                byte[] data = new byte[readByte];

                for (int i = 0; i < EvaluatorConst.PATTERN_NUM; i++)
                {
                    for (int j = 0; j < EvaluatorConst.PATTERN_SIZE; i++)
                    {
                        fs.Read(data, idx, readByte);
                        Pattern_values[i][j] = BitConverter.ToInt32(data, 0);
                        idx += readByte;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public int Evaluate(BoardState boardState)
        {
            var turn = boardState.Turn;
            var opponent = boardState.GetOpponentTurn();
            var seeds = BitConverter.GetBytes(boardState.Seed_states[(int)turn]);
            var opponent_seeds = BitConverter.GetBytes(boardState.Seed_states[(int)opponent]);

            int value = 0;

            value += Pattern_values[0][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += Pattern_values[1][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += Pattern_values[2][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += Pattern_values[3][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[4]]];

            value += Pattern_values[4][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += Pattern_values[5][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += Pattern_values[6][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += Pattern_values[7][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];

            value += Pattern_values[8][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += Pattern_values[9][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += Pattern_values[10][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += Pattern_values[11][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];

            value += Pattern_values[12][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += Pattern_values[13][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[14][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[15][EvaluatorConst.SEED_TO_INDEX_0[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];

            value += Pattern_values[16][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += Pattern_values[17][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[18][EvaluatorConst.SEED_TO_INDEX_0[seeds[0]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[19][EvaluatorConst.SEED_TO_INDEX_0[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];

            value += Pattern_values[20][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += Pattern_values[21][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += Pattern_values[22][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += Pattern_values[23][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];

            value += Pattern_values[24][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += Pattern_values[25][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += Pattern_values[26][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += Pattern_values[27][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];

            value += Pattern_values[28][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += Pattern_values[29][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[30][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[31][EvaluatorConst.SEED_TO_INDEX_0[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];

            value += Pattern_values[32][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += Pattern_values[33][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[34][EvaluatorConst.SEED_TO_INDEX_0[seeds[1]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[35][EvaluatorConst.SEED_TO_INDEX_0[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];

            value += Pattern_values[36][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += Pattern_values[37][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += Pattern_values[38][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += Pattern_values[39][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];

            value += Pattern_values[40][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += Pattern_values[41][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[42][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[43][EvaluatorConst.SEED_TO_INDEX_0[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];

            value += Pattern_values[44][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += Pattern_values[45][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[46][EvaluatorConst.SEED_TO_INDEX_0[seeds[2]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[47][EvaluatorConst.SEED_TO_INDEX_0[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[3]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];

            value += Pattern_values[48][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += Pattern_values[49][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[50][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[2]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[51][EvaluatorConst.SEED_TO_INDEX_0[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[2]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];

            value += Pattern_values[52][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += Pattern_values[53][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[54][EvaluatorConst.SEED_TO_INDEX_0[seeds[3]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[2]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[55][EvaluatorConst.SEED_TO_INDEX_0[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[2]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];

            value += Pattern_values[56][EvaluatorConst.SEED_TO_INDEX_0[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += Pattern_values[57][EvaluatorConst.SEED_TO_INDEX_0[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_1[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[58][EvaluatorConst.SEED_TO_INDEX_0[seeds[4]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[1]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += Pattern_values[59][EvaluatorConst.SEED_TO_INDEX_0[seeds[5]] + EvaluatorConst.SEED_TO_INDEX_1[opponent_seeds[1]] + EvaluatorConst.SEED_TO_INDEX_2[opponent_seeds[0]]];


            return (boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * EvaluatorConst.VALUE_PER_SEED + value;

        }


    }


}
