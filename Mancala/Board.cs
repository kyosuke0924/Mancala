using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using static common.Constant;
using mancalaEngine;

namespace Mancala
{
    internal class Board
    {
        private MancalaEngine mancalaEngine;
        private BoardState state;
        private Stack<BoardState> history;

        internal Board()
        {
            mancalaEngine = new MancalaEngine();
            mancalaEngine.LoadFiles();
            Reset();
        }

        /// <summary>
        /// 局面を初期化する。
        /// </summary>
        internal void Reset()
        {
            state = new BoardState();
            history = new Stack<BoardState>(HISTORY_SIZE);
        }

        /// <summary>
        /// 一手戻す。初期局面では局面を戻せないのでNoneを返す。
        /// </summary>
        /// <returns>戻せたかどうか</returns>
        internal bool Undo()
        {
            if (history.Count == 0) return false;
            state = new BoardState(history.Pop());
            return true;
        }

        /// <summary>
        /// 有効な手かを返す
        /// </summary>
        /// <param name="idx">pit位置</param>
        /// <returns>有効な手か</returns>
        internal bool CanPlay(int idx)
        {
            return state.CanPlay(idx);
        }

        /// <summary>
        /// 一手進める。ルール上有効な手ならtrueを、無効な手ならfalseを返す。
        /// </summary>
        /// <param name="idx">pit位置</param>
        internal void Play(int idx)
        {
            history.Push(new BoardState(state));
            state.Play(idx);
        }

        /// <summary>
        /// 現在の手番を返す
        /// </summary>
        /// <returns>現在の手番</returns>
        internal Turn GetTurn()
        {
            return state.Turn;
        }

        /// <summary>
        /// storeにあるseedの個数を返す。
        /// </summary>
        /// <param name="turn">現在の手番</param>
        /// <returns>storeにあるseedの個数</returns>
        internal int GetStore(Turn turn)
        {
            return state.Stores[(int)turn];
        }

        /// <summary>
        /// すべてのseedの個数を返す。
        /// </summary>
        /// <param name="turn">現在の手番</param>
        /// <returns>seedの個数</returns>
        public byte[] GetSeedArray(Turn turn)
        {
            return BitConverter.GetBytes(state.Seed_states[(int)turn]).Take(PIT_NUM).ToArray();
        }

        /// <summary>
        /// 指定したpitのseedの個数を返す。
        /// </summary>
        /// <param name="turn">現在の手番</param>
        /// <param name="idx">pitの位置（0=storeから遠い位置）</param>
        /// <returns>seedの個数</returns>
        internal int GetSeed(Turn turn, int idx)
        {
            return state.GetSeed(turn, idx);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="explore"></param>
        /// <returns></returns>
        internal (Move bestMove, int?[] values) FindBestMove(int depth, bool explore)
        {
            return mancalaEngine.FindBestMove(state, depth, explore);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seedNum"></param>
        internal void MakeEndingFile(int seedNum)
        {
            mancalaEngine.MakeEndingFile(seedNum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal PositionMap GetEndingMap()
        {
            return mancalaEngine.EndingMap;
        }

    }

}
