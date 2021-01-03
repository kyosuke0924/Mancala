using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;


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

        public (Move bestMove, int?[] values) FindBestMove(Board board, int depth, bool explore)
        {
            (int value, int confidence)?[] movesValues = FindMovesValues(board, depth, explore);

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

        private (int value, int confidence)?[] FindMovesValues(Board board, int depth, bool explore)
        {
            (int value, int confidence)?[] movesValues = new (int value, int confidence)?[Constant.PIT_NUM];

            Parallel.For(0, movesValues.Length, i => {
                movesValues[i] = CalcMoveValue(new Board(board), depth, explore,i);
            });
            return movesValues;
        }

        private (int value,int confidence)? CalcMoveValue(Board board, int depth, bool explore,int i)
        {

            var turn = board.GetTurn();
            var opponent = board.State.GetOpponentTurn();
            var LogTotalSize = positionMap.GetLength();
            var upper = MAX_VALUE;
            var lower = -MAX_VALUE;

            if (!board.CanPlay(i)) return null;

            board.Play(i);
            (int value, int confidence)? positionMapResult = null;

            var positionValue = positionMap.GetPositionValue(board.State);
            if (positionValue != null)
            {
                if (!explore && positionValue.Value.Visit < MIN_VISIT)
                {
                    positionMapResult = null;
                }
                else
                {
                    int value = board.State.Turn == turn ? positionValue.Value.Value : -positionValue.Value.Value;
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
                if (board.State.IsOver())
                {
                    result.value = (board.State.Stores[(int)turn] - board.State.Stores[(int)opponent]) * EvaluatorConst.VALUE_PER_SEED;
                }
                else
                {
                    var endingValue = EndingMap.GetPositionValue(board.State);

                    if (endingValue != null)
                    {
                        result.value = board.State.Turn == turn ? endingValue.Value.Value : -endingValue.Value.Value;
                    }
                    else if (depth == 1)
                    {
                        result.value = board.State.Turn == turn ? evaluator.Evaluate(board.State) : -evaluator.Evaluate(board.State);
                    }
                    else
                    {
                        if (board.State.Turn == turn)
                        {
                            result.value = Search(board, depth - 1, lower, upper).Value;
                        }
                        else
                        {
                            result.value = -Search(board, depth - 1, -upper, -lower).Value;
                        }
                    }
                }
                result.confidence = explore ? result.value + EXPLORE_BONUS : result.value;
            }
            board.Undo();

            return (result.value, result.confidence);
        }

        private Move Search(Board board, int depth, int lower, int upper)
        {
            var turn = board.GetTurn();
            var opponent = board.State.GetOpponentTurn();
            var maxValue = -MAX_VALUE;
            var lowerValue = lower;
            Move bestMove = new Move(null, maxValue);

            List<int> moves = new List<int>();
            if (depth >= 4)
            {
                List<Move> candidates = new List<Move>();
                for (int i = 0; i < Constant.PIT_NUM; i++)
                {
                    if (!board.CanPlay(i)) continue;
                    int value = evaluator.Evaluate(board.State);
                    candidates.Add(new Move(i, board.State.Turn == turn ? -value : value));
                }
                moves = candidates.OrderByDescending(x => x.Value).Select(x => (int)x.Pit).ToList();
            }
            else {

                for (int i = Constant.PIT_NUM - 1; i >= 0; i--)
                {
                    if (board.GetSeed(turn,i) > 0) moves.Add(i);
                }
            }

            foreach (var i in moves)
            {
                if (!board.CanPlay(i)) continue;

                board.Play(i);
                int value;
                if (board.State.IsOver())
                {
                    value= (board.State.Stores[(int)turn] - board.State.Stores[(int)opponent]) * EvaluatorConst.VALUE_PER_SEED;
                }
                else if (depth == 1)
                {
                    int v = evaluator.Evaluate(board.State);
                    value = board.State.Turn == turn ? v : -v;
                }
                else
                {
                    var endingValue = EndingMap.GetPositionValue(board.State);
                    if (endingValue != null)
                    {
                        value = board.State.Turn == turn ? endingValue.Value.Value : -endingValue.Value.Value;
                    }
                    else
                    {
                        if (board.State.Turn == turn)
                        {
                            value = Search(board, depth - 1, lowerValue, upper).Value;
                        }
                        else
                        {
                            value = -Search(board, depth - 1, -upper, -lowerValue).Value;
                        }
                    }

                }
                board.Undo();

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
            Board newBoard = new Board();
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
                            newBoard.ResetWithSeeds(firstSeeds, secondSeeds);
                            int value = FindBestMove(newBoard, 1000, false).bestMove.Value;
                            EndingMap.Add(newBoard.State, value);
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
