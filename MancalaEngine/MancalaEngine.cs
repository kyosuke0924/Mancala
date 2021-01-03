﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common;
using static common.Constant;



namespace mancalaEngine
{
    public readonly struct Move
    {
        public int? Pit { get; }
        public int Value { get; }

        public Move(int? pit, int value)
        {
            this.Pit = pit;
            this.Value = value;
        }
    }

    public class MancalaEngine
    {
        private const string EVALUATION_FILE_PATH = "eval.dat";
        private const string POSITION_FILE_PATH = "position.dat";
        private const string ENDING_FILE_PATH = "ending.dat";

        private const int  MIN_VISIT = 10;
        private const double CONFIDENCE_SCALE = 32.0 * EvaluatorConst.VALUE_PER_SEED;
        private const int MAX_VALUE = 100000;
        private const int EXPLORE_BONUS = 50000;

        private Evaluator evaluator;
        private PositionMap positionMap;
        public PositionMap EndingMap { get; private set; }

        public MancalaEngine()
        {
            LoadFiles();
        }

        public void LoadFiles()
        {
            evaluator = new Evaluator();
            positionMap = new PositionMap();
            EndingMap = new PositionMap();
            evaluator.Load(EVALUATION_FILE_PATH);
            positionMap.Load(POSITION_FILE_PATH);
            EndingMap.Load(ENDING_FILE_PATH);
        }

        public (Move bestMove, int?[] values) FindBestMove(BoardState boardState, int depth, bool explore)
        {
          
            (int value, int confidence)?[] movesValues = FindMovesValues(boardState, depth, explore);

            Move bestMove = new Move(null, 0);
            var bestConfidence = -MAX_VALUE;

            for (int i = 0; i < movesValues.Length; i++)
            {
                if (movesValues[i] != null && movesValues[i].Value.confidence > bestConfidence)
                {
                    bestMove = new Move(i, movesValues[i].Value.value);
                    bestConfidence = movesValues[i].Value.confidence;
                }
            }
            return (bestMove, movesValues.Select(x => x?.value).ToArray());
        }

        private (int value, int confidence)?[] FindMovesValues(BoardState boardState, int depth, bool explore)
        {
            (int value, int confidence)?[] movesValues = new (int value, int confidence)?[Constant.PIT_NUM];

            Parallel.For(0, movesValues.Length, i => {
                movesValues[i] = CalcMoveValue(new BoardState(boardState), depth, explore,i);
            });
            return movesValues;
        }

        private (int value,int confidence)? CalcMoveValue(BoardState boardState, int depth, bool explore,int i)
        {

            var turn = boardState.Turn;
            var opponent = boardState.GetOpponentTurn();
            var LogTotalSize = positionMap.GetLength();
            var upper = MAX_VALUE;
            var lower = -MAX_VALUE;

            if (!boardState.CanPlay(i)) return null;

            boardState.Play(i);
            (int value, int confidence)? positionMapResult = null;

            var positionValue = positionMap.GetPositionValue(boardState);
            if (positionValue != null)
            {
                if (!explore && positionValue.Value.Visit < MIN_VISIT)
                {
                    positionMapResult = null;
                }
                else
                {
                    int value = boardState.Turn == turn ? positionValue.Value.Value : -positionValue.Value.Value;
                    int confidence;
                    if (explore)
                    {
                        confidence = value + (int)(Math.Sqrt(CONFIDENCE_SCALE * LogTotalSize / positionValue.Value.Visit));
                    }
                    else
                    {
                        confidence = value;
                    }
                    positionMapResult = (value, confidence);
                }
            }

            (int value, int confidence) result;
            if (positionMapResult != null)
            {
                result.value = positionMapResult.Value.value;
                result.confidence = positionMapResult.Value.confidence;
            }
            else
            {
                if (boardState.IsOver())
                {
                    result.value = (boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * EvaluatorConst.VALUE_PER_SEED;
                }
                else
                {
                    var endingValue = EndingMap.GetPositionValue(boardState);

                    if (endingValue != null)
                    {
                        result.value = boardState.Turn == turn ? endingValue.Value.Value : -endingValue.Value.Value;
                    }
                    else if (depth == 1)
                    {
                        result.value = boardState.Turn == turn ? evaluator.Evaluate(boardState) : -evaluator.Evaluate(boardState);
                    }
                    else
                    {
                        Stack<BoardState> stackBoardStates = new Stack<BoardState>(MAX_SEED_NUM);
                        stackBoardStates.Push(new BoardState(boardState));

                        if (boardState.Turn == turn)
                        {
                            result.value = Search(stackBoardStates, depth - 1, lower, upper).Value;
                        }
                        else
                        {
                            result.value = -Search(stackBoardStates, depth - 1, -upper, -lower).Value;
                        }
                    }
                }
                result.confidence = explore ? result.value + EXPLORE_BONUS : result.value;
            }

            return (result.value, result.confidence);
        }

        private Move Search(Stack<BoardState> stackBoardStates, int depth, int lower, int upper)
        {

            BoardState boardState = stackBoardStates.Peek();

            var turn = boardState.Turn;
            var opponent = boardState.GetOpponentTurn();
            var maxValue = -MAX_VALUE;
            var lowerValue = lower;
            Move bestMove = new Move(null, maxValue);

            List<int> moves = new List<int>();
            if (depth >= 4)
            {
                List<Move> candidates = new List<Move>();
                for (int i = 0; i < Constant.PIT_NUM; i++)
                {
                    if (!boardState.CanPlay(i)) continue;
                    int value = evaluator.Evaluate(boardState);
                    candidates.Add(new Move(i, boardState.Turn == turn ? -value : value));
                }
                moves = candidates.OrderByDescending(x => x.Value).Select(x => (int)x.Pit).ToList();
            }
            else {

                for (int i = Constant.PIT_NUM - 1; i >= 0; i--)
                {
                    if (boardState.GetSeed(turn,i) > 0) moves.Add(i);
                }
            }

            foreach (var i in moves)
            {
                if (!boardState.CanPlay(i)) continue;

                stackBoardStates.Push(new BoardState(boardState));
                boardState.Play(i);

                int value;
                if (boardState.IsOver())
                {
                    value= (boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * EvaluatorConst.VALUE_PER_SEED;
                }
                else if (depth == 1)
                {
                    int v = evaluator.Evaluate(boardState);
                    value = boardState.Turn == turn ? v : -v;
                }
                else
                {
                    var endingValue = EndingMap.GetPositionValue(boardState);
                    if (endingValue != null)
                    {
                        value = boardState.Turn == turn ? endingValue.Value.Value : -endingValue.Value.Value;
                    }
                    else
                    {
                        if (boardState.Turn == turn)
                        {
                            value = Search(stackBoardStates, depth - 1, lowerValue, upper).Value;
                        }
                        else
                        {
                            value = -Search(stackBoardStates, depth - 1, -upper, -lowerValue).Value;
                        }
                    }

                }
                stackBoardStates.Pop();

                if (value > maxValue)
                {
                    bestMove = new Move(i, value);
                    maxValue = value;
                    if (value >= upper) return bestMove;
                    if(maxValue > lowerValue) lowerValue = maxValue;
                }
            }
            return bestMove;
        }

        public void MakeEndingFile(int seedNum)
        {
            positionMap = new PositionMap();
            EndingMap = new PositionMap();

            int[] seeds = new int[Constant.PIT_NUM * 2];

            for (int max = 2; max < seedNum + 1; max++)
            {
                int i = 0;
                int remain = max;
                Boolean isOver = false;
                while (!isOver)
                {
                    i++;
                    if (remain == 0 | i == seeds.Length - 1)
                    {
                        seeds[i] = remain;
                        var firstSeeds = seeds.Take(Constant.PIT_NUM).ToArray();
                        var secondSeeds = seeds.Skip(Constant.PIT_NUM).Take(Constant.PIT_NUM).ToArray();
                        if (firstSeeds.Sum() > 0 && secondSeeds.Sum() > 0)
                        {
                            BoardState board = new BoardState(firstSeeds, secondSeeds);
                            int value = FindBestMove(board, 1000, false).bestMove.Value;
                            EndingMap.Add(board, value);
                        }
                        seeds[i] = 0;
                        while (true)
                        {
                            if (i == 0)
                            {
                                isOver = true;
                                break;
                            }
                            i--;
                            if (remain > 0)
                            {
                                remain--;
                                seeds[i]++;
                                break;
                            }
                            else
                            {
                                remain += seeds[i];
                                seeds[i] = 0;
                            }
                        }
                    }
                }
            }
            EndingMap.Save(ENDING_FILE_PATH);
            LoadFiles();
        }
    }
}
