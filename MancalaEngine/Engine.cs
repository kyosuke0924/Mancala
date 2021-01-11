using Mancala.Common.BoardState;
using Mancala.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mancala.MancalaEngine
{

    public readonly struct Move
    {
        public int? Pit { get; }
        public int Value { get; }

        public Move(int? pit, int value)
        {
            Pit = pit;
            Value = value;
        }
    }

    public class Engine
    {
        private const string EVALUATION_FILE_PATH = "eval.dat";
        private const string POSITION_FILE_PATH = "position.dat";
        private const string ENDING_FILE_PATH = "ending.dat";

        private const int VALUE_PER_SEED = 100;
        private const int MIN_VISIT = 10;
        private const double CONFIDENCE_SCALE = 32.0 * VALUE_PER_SEED;
        private const int MAX_VALUE = 100000;
        private const int EXPLORE_BONUS = 50000;

        public PositionMap EndingMap { get; private set; }

        private readonly int pitNum;
        private Evaluator evaluator;
        private PositionMap positionMap;


        public Engine(int pitNum)
        {
            this.pitNum = pitNum;
            LoadFiles();
        }

        public void LoadFiles()
        {
            evaluator = new Evaluator(VALUE_PER_SEED);
            positionMap = new PositionMap(VALUE_PER_SEED);
            EndingMap = new PositionMap(VALUE_PER_SEED);
            evaluator.Load(EVALUATION_FILE_PATH);
            positionMap.Load(POSITION_FILE_PATH);
            EndingMap.Load(ENDING_FILE_PATH);
        }

        public (Move bestMove, int?[] values) FindBestMove(BoardState boardState, int depth, bool explore)
        {

            (int value, int confidence)?[] movesValues = FindMovesValues(boardState, depth, explore);

            Move bestMove = new Move(null, 0);
            int bestConfidence = -MAX_VALUE;

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

        public void MakeEndingFile(int seedNum)
        {
            positionMap = new PositionMap(VALUE_PER_SEED);
            EndingMap = new PositionMap(VALUE_PER_SEED);

            int[] seeds = new int[pitNum * 2];

            for (int max = 2; max < seedNum + 1; max++)
            {
                int i = 0;
                int remain = max;
                bool isOver = false;
                while (!isOver)
                {
                    i++;
                    if (remain == 0 | i == seeds.Length - 1)
                    {
                        seeds[i] = remain;
                        int[] firstSeeds = seeds.Take(pitNum).ToArray();
                        int[] secondSeeds = seeds.Skip(pitNum).Take(pitNum).ToArray();
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

        private (int value, int confidence)?[] FindMovesValues(BoardState boardState, int depth, bool explore)
        {
            (int value, int confidence)?[] movesValues = new (int value, int confidence)?[pitNum];

            Parallel.For(0, movesValues.Length, i =>
            {
                movesValues[i] = CalcMoveValue(new BoardState(boardState), depth, explore, i);
            });
            return movesValues;
        }

        private (int value, int confidence)? CalcMoveValue(BoardState boardState, int depth, bool explore, int i)
        {

            Turn turn = boardState.ThisTurn;
            Turn opponent = boardState.GetOpponentTurn();
            int logTotalSize = positionMap.GetLength();
            int upper = MAX_VALUE;
            int lower = -MAX_VALUE;

            if (!boardState.CanPlay(i))
            {
                return null;
            }

            boardState.Play(i);
            (int value, int confidence)? positionMapResult = null;

            PositionValue? positionValue = positionMap.GetPositionValue(boardState);
            if (positionValue != null)
            {
                if (!explore && positionValue.Value.Visit < MIN_VISIT)
                {
                    positionMapResult = null;
                }
                else
                {
                    int value = boardState.ThisTurn == turn ? positionValue.Value.Value : -positionValue.Value.Value;
                    int confidence;
                    if (explore)
                    {
                        confidence = value + (int)(Math.Sqrt(CONFIDENCE_SCALE * logTotalSize / positionValue.Value.Visit));
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
                    result.value = (boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * VALUE_PER_SEED;
                }
                else
                {
                    PositionValue? endingValue = EndingMap.GetPositionValue(boardState);

                    if (endingValue != null)
                    {
                        result.value = boardState.ThisTurn == turn ? endingValue.Value.Value : -endingValue.Value.Value;
                    }
                    else if (depth == 1)
                    {
                        result.value = boardState.ThisTurn == turn ? evaluator.Evaluate(boardState) : -evaluator.Evaluate(boardState);
                    }
                    else
                    {
                        Stack<BoardState> stackBoardStates = new Stack<BoardState>(BoardInfo.MAX_SEED_NUM);
                        stackBoardStates.Push(new BoardState(boardState));

                        if (boardState.ThisTurn == turn)
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

            Turn turn = boardState.ThisTurn;
            Turn opponent = boardState.GetOpponentTurn();
            int maxValue = -MAX_VALUE;
            int lowerValue = lower;
            Move bestMove = new Move(null, maxValue);

            List<int> moves = new List<int>();

            if (depth >= 4)
            {
                List<Move> candidates = new List<Move>();
                for (int i = 0; i < pitNum; i++)
                {
                    if (!boardState.CanPlay(i))
                    {
                        continue;
                    }

                    int value = evaluator.Evaluate(boardState);
                    candidates.Add(new Move(i, boardState.ThisTurn == turn ? -value : value));
                }
                moves = candidates.OrderByDescending(x => x.Value).Select(x => (int)x.Pit).ToList();
            }
            else
            {

                for (int i = pitNum - 1; i >= 0; i--)
                {
                    if (boardState.GetSeed(turn, i) > 0)
                    {
                        moves.Add(i);
                    }
                }
            }

            foreach (int i in moves)
            {
                if (!boardState.CanPlay(i))
                {
                    continue;
                }

                stackBoardStates.Push(new BoardState(boardState));
                boardState.Play(i);

                int value;
                if (boardState.IsOver())
                {
                    value = (boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * VALUE_PER_SEED;
                }
                else if (depth == 1)
                {
                    int v = evaluator.Evaluate(boardState);
                    value = boardState.ThisTurn == turn ? v : -v;
                }
                else
                {
                    PositionValue? endingValue = EndingMap.GetPositionValue(boardState);
                    if (endingValue != null)
                    {
                        value = boardState.ThisTurn == turn ? endingValue.Value.Value : -endingValue.Value.Value;
                    }
                    else
                    {
                        if (boardState.ThisTurn == turn)
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
                    if (value >= upper)
                    {
                        return bestMove;
                    }

                    if (maxValue > lowerValue)
                    {
                        lowerValue = maxValue;
                    }
                }
            }

            return bestMove;
        }


    }
}
