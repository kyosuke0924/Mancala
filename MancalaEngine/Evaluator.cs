using Mancala.Common.BoardState;
using Mancala.Common.Constant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mancala.MancalaEngine
{
    internal class Evaluator
    {
        private const int PATTERN_NUM = 60;
        private const int PATTERN_SIZE = 15 * 15 * 15;
        private static readonly int[] SEED_TO_INDEX_0 = new int[BoardInfo.MAX_SEED_NUM]
                                   {
                                         0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
                                        14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
                                   };

        private static readonly int[] SEED_TO_INDEX_1 = new int[BoardInfo.MAX_SEED_NUM]
                                   {
                                        0, 15, 30, 45, 60, 75, 90, 105, 120, 135, 150, 165, 180, 195, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210,
                                        210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210, 210,
                                   };

        private static readonly int[] SEED_TO_INDEX_2 = new int[BoardInfo.MAX_SEED_NUM]
                                   {
                                        0, 225, 450, 675, 900, 1125, 1350, 1575, 1800, 2025, 2250, 2475, 2700, 2925, 3150, 3150, 3150, 3150, 3150, 3150,
                                        3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150,
                                        3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150, 3150,
                                   };

        private readonly int valuePerSeed;
        private readonly List<List<int>> patternValues;

        internal Evaluator(int valuePerSeed)
        {
            this.valuePerSeed = valuePerSeed;
            patternValues = new List<List<int>>(PATTERN_NUM);
            for (int i = 0; i < PATTERN_NUM; i++)
            {
                patternValues.Add(new List<int>(Enumerable.Repeat(0, PATTERN_SIZE)));
            }
        }

        internal void Load(string filePath)
        {
            FileStream fs = new System.IO.FileStream(filePath, FileMode.Open);
            try
            {
                int idx = 0;
                int readByte = 4;

                for (int i = 0; i < PATTERN_NUM; i++)
                {
                    for (int j = 0; j < PATTERN_SIZE; j++)
                    {
                        byte[] data = new byte[readByte];
                        fs.Read(data, idx, readByte);
                        patternValues[i][j] = BitConverter.ToInt32(data, 0);
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

        internal int Evaluate(BoardState boardState)
        {
            Turn turn = boardState.ThisTurn;
            Turn opponent = boardState.GetOpponentTurn();
            byte[] seeds = BitConverter.GetBytes(boardState.Seed_states[(int)turn]);
            byte[] opponent_seeds = BitConverter.GetBytes(boardState.Seed_states[(int)opponent]);

            int value = 0;

            value += patternValues[0][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[1]] + SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += patternValues[1][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[1]] + SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += patternValues[2][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += patternValues[3][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[4]]];

            value += patternValues[4][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[2]] + SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += patternValues[5][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[2]] + SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += patternValues[6][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += patternValues[7][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[3]]];

            value += patternValues[8][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += patternValues[9][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += patternValues[10][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += patternValues[11][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[2]]];

            value += patternValues[12][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += patternValues[13][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[14][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[15][SEED_TO_INDEX_0[seeds[4]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[1]]];

            value += patternValues[16][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[5]]];
            value += patternValues[17][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[18][SEED_TO_INDEX_0[seeds[0]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[19][SEED_TO_INDEX_0[seeds[5]] + SEED_TO_INDEX_1[opponent_seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[0]]];

            value += patternValues[20][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[seeds[2]] + SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += patternValues[21][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[seeds[2]] + SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += patternValues[22][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[opponent_seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += patternValues[23][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[opponent_seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[3]]];

            value += patternValues[24][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += patternValues[25][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += patternValues[26][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[opponent_seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += patternValues[27][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[opponent_seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[2]]];

            value += patternValues[28][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += patternValues[29][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[30][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[opponent_seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[31][SEED_TO_INDEX_0[seeds[4]] + SEED_TO_INDEX_1[opponent_seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[1]]];

            value += patternValues[32][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[4]]];
            value += patternValues[33][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[34][SEED_TO_INDEX_0[seeds[1]] + SEED_TO_INDEX_1[opponent_seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[35][SEED_TO_INDEX_0[seeds[5]] + SEED_TO_INDEX_1[opponent_seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[0]]];

            value += patternValues[36][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += patternValues[37][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += patternValues[38][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[opponent_seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += patternValues[39][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[opponent_seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[2]]];

            value += patternValues[40][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += patternValues[41][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[42][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[opponent_seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[43][SEED_TO_INDEX_0[seeds[4]] + SEED_TO_INDEX_1[opponent_seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[1]]];

            value += patternValues[44][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[3]]];
            value += patternValues[45][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[46][SEED_TO_INDEX_0[seeds[2]] + SEED_TO_INDEX_1[opponent_seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[47][SEED_TO_INDEX_0[seeds[5]] + SEED_TO_INDEX_1[opponent_seeds[3]] + SEED_TO_INDEX_2[opponent_seeds[0]]];

            value += patternValues[48][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += patternValues[49][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[seeds[4]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[50][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[opponent_seeds[2]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[51][SEED_TO_INDEX_0[seeds[4]] + SEED_TO_INDEX_1[opponent_seeds[2]] + SEED_TO_INDEX_2[opponent_seeds[1]]];

            value += patternValues[52][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[2]]];
            value += patternValues[53][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[54][SEED_TO_INDEX_0[seeds[3]] + SEED_TO_INDEX_1[opponent_seeds[2]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[55][SEED_TO_INDEX_0[seeds[5]] + SEED_TO_INDEX_1[opponent_seeds[2]] + SEED_TO_INDEX_2[opponent_seeds[0]]];

            value += patternValues[56][SEED_TO_INDEX_0[seeds[4]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[1]]];
            value += patternValues[57][SEED_TO_INDEX_0[seeds[4]] + SEED_TO_INDEX_1[seeds[5]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[58][SEED_TO_INDEX_0[seeds[4]] + SEED_TO_INDEX_1[opponent_seeds[1]] + SEED_TO_INDEX_2[opponent_seeds[0]]];
            value += patternValues[59][SEED_TO_INDEX_0[seeds[5]] + SEED_TO_INDEX_1[opponent_seeds[1]] + SEED_TO_INDEX_2[opponent_seeds[0]]];

            return (boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * valuePerSeed + value;
        }
    }
}
