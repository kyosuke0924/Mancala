using Mancala.Common.BoardState;
using Mancala.Common.Constant;
using Mancala.MancalaEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mancala.Mancala
{
    internal class BoardManager
    {
        private const int HISTORY_SIZE = BoardInfo.MAX_SEED_NUM * 3;

        private readonly Engine mancalaEngine;
        private BoardState state;
        private Stack<BoardState> history;

        internal BoardManager()
        {
            mancalaEngine = new Engine(BoardInfo.PIT_NUM);
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
        /// <returns>戻すことができたか</returns>
        internal bool Undo()
        {
            if (history.Count == 0)
            {
                return false;
            }

            state = new BoardState(history.Pop());
            return true;
        }

        /// <summary>
        /// ルール上有効な手ならtrueを、無効な手ならfalseを返す。
        /// </summary>
        /// <param name="idx">pit位置</param>
        /// <returns>有効な手か</returns>
        internal bool CanPlay(int idx)
        {
            return state.CanPlay(idx);
        }

        /// <summary>
        /// 一手進める。
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
            return state.ThisTurn;
        }

        /// <summary>
        /// 現在の手番が先手かを返す
        /// </summary>
        /// <returns>先手か</returns>
        internal bool IsthisTurnFirst()
        {
            return state.ThisTurn == Turn.First;
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
            return BitConverter.GetBytes(state.Seed_states[(int)turn]).Take(BoardInfo.PIT_NUM).ToArray();
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
        /// 推奨着手を返す
        /// </summary>
        /// <param name="depth">読み手の深さ</param>
        /// <param name="explore">自己対局か</param>
        /// <returns>推奨着手、評価値</returns>
        internal (int? bestMoveIdx, int?[] values) FindBestMove(int depth, bool explore)
        {
            (Move bestMove, int?[] values) result = mancalaEngine.FindBestMove(state, depth, explore);
            return (result.bestMove.Pit, result.values);
        }

        /// <summary>
        /// 終盤局面ファイルを作成する
        /// </summary>
        /// <param name="seedNum">最大seed数</param>
        internal void MakeEndingFile(int seedNum)
        {
            mancalaEngine.MakeEndingFile(seedNum);
        }

        /// <summary>
        /// 終盤局面ファイルを取得する
        /// </summary>
        /// <returns>終盤局面ファイル</returns>
        internal PositionMap GetEndingMap()
        {
            return mancalaEngine.EndingMap;
        }

    }

}
