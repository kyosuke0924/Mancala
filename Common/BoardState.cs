using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static common.Constant;

namespace common
{

    public class BoardState
    {
        public Turn Turn { get; private set; }
        public int[] Stores { get; private set; }
        public long[] Seed_states { get; private set; }

        public BoardState()
        {
            Turn = Turn.First;
            Stores = new int[] { 0, 0 };
            Seed_states = new long[] { INITIAL_SEEDS, INITIAL_SEEDS };
        }

        public BoardState(BoardState boardState)
        {
            Turn = boardState.Turn;
            Stores = (int[])boardState.Stores.Clone();
            Seed_states = (long[])boardState.Seed_states.Clone();
        }

        public BoardState(int[] firstSeeds,int[] secondSeeds) :this()
        {
            byte[] firstSeedsBytes = new byte[8];
            byte[] secondSeedsBytes = new byte[8];
            for (int i = 0; i < PIT_NUM; i++)
            {
                firstSeedsBytes[i] = (byte)firstSeeds[i];
                secondSeedsBytes[i] = (byte)secondSeeds[i];
            }
            Seed_states = new long[] { BitConverter.ToInt64(firstSeedsBytes, 0), BitConverter.ToInt64(secondSeedsBytes, 0) };
        }

        /// <summary>
        /// 指定したpitのseedの個数を返す。
        /// </summary>
        /// <param name="turn">現在の手番</param>
        /// <param name="idx">pitの位置（0=storeから遠い位置）</param>
        /// <returns>seedの個数</returns>
        public int GetSeed(Turn turn, int idx)
        {
            return BitConverter.GetBytes(Seed_states[(int)turn])[idx];
        }

        /// <summary>
        /// 現在の手番と逆の手番を返す
        /// </summary>
        /// <returns>現在の手番</returns>
        public Turn GetOpponentTurn()
        {
            return Turn == Turn.First ? Turn.Second : Turn.First;
        }

        /// <summary>
        /// ゲームが終了しているかどうかを返す。
        /// </summary>
        /// <returns>終了しているか</returns>
        public Boolean IsOver()
        {
            return Seed_states[(int)Turn.First] == 0 | Seed_states[(int)Turn.Second] == 0;
        }

        /// <summary>
        /// 有効な手かを返す
        /// </summary>
        /// <param name="idx">pit位置</param>
        /// <returns>有効な手か</returns>
        public bool CanPlay(int idx)
        {
            int seedNum = GetSeed(Turn, idx);
            int diffIdx = idx * (MAX_SEED_NUM + 1) + seedNum;
            return SEED_DIFFS[diffIdx] != 0;
        }

        /// <summary>
        /// 一手進める。ルール上有効な手ならtrueを、無効な手ならfalseを返す。
        /// </summary>
        /// <param name="idx">pit位置</param>
        /// <returns>有効な手か</returns>
        public void Play(int idx)
        {
            int seedNum = GetSeed(Turn, idx);
            int diffIdx = idx * (MAX_SEED_NUM + 1) + seedNum;

            Turn opponent = GetOpponentTurn();
            Seed_states[(int)Turn] += SEED_DIFFS[diffIdx];
            Seed_states[(int)opponent] += OPPONENT_SEED_DIFFS[diffIdx];
            Stores[(int)Turn] += STORE_DIFFS[diffIdx];
            int lastIdx = (idx + seedNum) % SOW_CYCLE_SIZE;

            if (lastIdx < PIT_NUM && GetSeed(Turn, lastIdx) == 1) //横取り処理
            {
                int opponentIdx = PIT_NUM - lastIdx - 1;
                if (GetSeed(opponent, opponentIdx) > 0)
                {
                    Stores[(int)Turn] += GetSeed(Turn, lastIdx) + GetSeed(opponent, opponentIdx);
                    Seed_states[(int)Turn] &= ~(PIT_BIT_MASK << (lastIdx * PIT_BIT_NUM));
                    Seed_states[(int)opponent] &= ~(PIT_BIT_MASK << (opponentIdx * PIT_BIT_NUM));
                }
            }

            if (IsOver()) //終局処理
            {
                Stores[(int)Turn] += SumSeeds(Turn);
                Stores[(int)opponent] += SumSeeds(opponent);
                Seed_states[(int)Turn] = EMPTY_SEEDS;
                Seed_states[(int)opponent] = EMPTY_SEEDS;
            }

            if (lastIdx != PIT_NUM) //ピッタリゴール
            {
                Turn = opponent;
            }
        }

        /// <summary>
        /// 手番のpitに残っているseedsの合計を返す
        /// </summary>
        /// <param name="turn">現在の手番</param>
        /// <returns>seedsの合</returns>
        private int SumSeeds(Turn turn)
        {
            return BitConverter.GetBytes(Seed_states[(int)turn]).Sum(value => value);
        }

    };

}
