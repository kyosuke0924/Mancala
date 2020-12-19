using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static mancala.Construct;

namespace mancala
{

    public class BoardState
    {
        public Turn Turn { get; set; }
        public int[] Stores { get; set; }
        public long[] Seed_states { get; set; }

        public BoardState()
        {
            Turn = Turn.First;
            Stores = new int[]{ 0, 0 };
            Seed_states = new long[] { INITIAL_SEEDS, INITIAL_SEEDS };
        }

        public BoardState(BoardState boardState) :this()
        {
            Turn = boardState.Turn;
            Array.Copy(boardState.Stores, Stores, boardState.Stores.Length);
            Array.Copy(boardState.Seed_states, Seed_states, boardState.Seed_states.Length);
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
        /// 一手進める。ルール上有効な手ならtrueを、無効な手ならfalseを返す。
        /// </summary>
        /// <param name="idx"></param>
        /// <returns>有効な手か</returns>
        public Boolean Play(int idx)
        {
            int seedNum = GetSeed(Turn, idx);
            int diffIdx = idx * (MAX_SEED_NUM + 1) + seedNum;
            if (SEED_DIFFS[diffIdx] == 0) return false;

            Turn opponent = GetOpponentTurn();
            Seed_states[(int)Turn] += SEED_DIFFS[diffIdx];
            Seed_states[(int)opponent] += OPPONENT_SEED_DIFFS[diffIdx];
            Stores[(int)Turn] += STORE_DIFFS[diffIdx];
            int lastIdx = (idx + seedNum) % SOW_CYCLE_SIZE;

            if (lastIdx < PIT_NUM && GetSeed(Turn,lastIdx) == 1) //横取り処理
            {
                int opponentIdx = PIT_NUM - lastIdx - 1;
                if (GetSeed(opponent, opponentIdx) > 0)
                {
                    Stores[(int)Turn] += GetSeed(Turn,lastIdx) + GetSeed(opponent,opponentIdx);
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

            return true;
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

    public class Board
    {
        private BoardState State { get; set; }
        private Stack<BoardState> History { get; set; }

        public Board()
        {
            State = new BoardState();
            History = new Stack<BoardState>(HISTORY_SIZE);
        }

        /// <summary>
        /// 局面を初期化する。
        /// </summary>
        public void Reset()
        {
            State = new BoardState();
            History.Clear();
        }

        /// <summary>
        /// 現在の手番を返す
        /// </summary>
        /// <returns>現在の手番</returns>
        public Turn GetTurn()
        {
            return State.Turn;
        }

        /// <summary>
        /// storeにあるseedの個数を返す。
        /// </summary>
        /// <param name="turn">現在の手番</param>
        /// <returns>storeにあるseedの個数</returns>
        public int GetStore(Turn turn)
        {
            return State.Stores[(int)turn];
        }

        /// <summary>
        /// 指定したpitのseedの個数を返す。
        /// </summary>
        /// <param name="turn">現在の手番</param>
        /// <param name="idx">pitの位置</param>
        /// <returns>seedの個数</returns>
        public int GetSeed(Turn turn, int idx)
        {
            return State.GetSeed(turn, idx);
        }

        /// <summary>
        /// ゲームが終了しているかどうかを返す。
        /// </summary>
        /// <returns>終了しているか</returns>
        public Boolean IsOver()
        {
            return State.IsOver(); ;
        }

        /// <summary>
        /// 一手戻す。初期局面では局面を戻せないのでNoneを返す。
        /// </summary>
        /// <returns>戻せたかどうか</returns>
        public Boolean Undo()
        {
            if (History.Count == 0)
            {
                return false;
            }
            else
            {      
                State = new BoardState(History.Pop());
                return true;
            }
        }

        /// <summary>
        /// 一手進める。ルール上有効な手ならtrueを、無効な手ならfalseを返す。
        /// </summary>
        /// <param name="idx"></param>
        /// <returns>有効な手か</returns>
        public Boolean Play(int idx)
        {
            History.Push(new BoardState(State));
            Boolean canSow = State.Play(idx);
            if (!canSow) History.Pop();
            return canSow;
        }

    }
}
