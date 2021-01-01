using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mancala
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

    public class Com
    {
        const int  MIN_VISIT = 10;
        const double CONFIDENCE_SCALE = 32.0 * EvaluatorConst.VALUE_PER_SEED;
        const int MAX_VALUE = 100000;
        const int EXPLORE_BONUS = 50000;

        private (int value, int confidence)?[] FindMovesValues(Board board, int depth, Evaluator evaluator, PositionMap positionMap, PositionMap endingMap, Boolean explore)
        {
            (int value, int confidence)?[] movesValues = new (int value, int confidence)?[Constant.PIT_NUM];

            var turn = board.GetTurn();
            var opponent = board.State.GetOpponentTurn();
            var LogTotalSize = positionMap.GetLength();
            var upper = MAX_VALUE;
            var lower = -MAX_VALUE;

            for (int i = 0; i < Constant.PIT_NUM; i++)
            {
                if (!board.Play(i)) continue;

                (int value, int confidence)? positionMapResult;
                {
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
                    else
                    {
                        positionMapResult = null;
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
                        var endingValue = endingMap.GetPositionValue(board.State);

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
                                result.value = Search(board, depth - 1, lower, upper, evaluator, endingMap).Value;
                            }
                            else
                            {
                                result.value = -Search(board, depth - 1, -upper, -lower, evaluator, endingMap).Value;
                            }

                        }
                    }

                    result.confidence = explore ? result.value + EXPLORE_BONUS : result.value;
                    if (result.value > lower) lower = result.value;
                }

                movesValues[i] = (result.value, result.confidence);
                board.Undo();

            }

            return movesValues;
        }

        public (Move bestMove ,int?[] values) FindBestMove(Board board,int depth,Evaluator evaluator,PositionMap positionMap, PositionMap endingMap,  Boolean explore)
        {
            (int value, int confidence)?[] movesValues = FindMovesValues(board, depth, evaluator, positionMap, endingMap, explore);

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

        private Move Search(Board board, int depth, int lower, int upper, Evaluator evaluator, PositionMap endingMap)
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
                    if (!board.Play(i)) continue;
                    int value = evaluator.Evaluate(board.State);
                    value = board.State.Turn == turn ? -value : value;
                    candidates.Add(new Move(i, value));
                    board.Undo();
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
                if (!board.Play(i)) continue;

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
                    var endingValue = endingMap.GetPositionValue(board.State);
                    if (endingValue != null)
                    {
                        value = board.State.Turn == turn ? endingValue.Value.Value : -endingValue.Value.Value;
                    }
                    else
                    {
                        if (board.State.Turn == turn)
                        {
                            value = Search(board, depth - 1, lowerValue, upper, evaluator, endingMap).Value;
                        }
                        else
                        {
                            value = -Search(board, depth - 1, -upper, -lowerValue, evaluator, endingMap).Value;
                        }
                    }

                }
                board.Undo();

                if (value > maxValue)
                {
                    bestMove = new Move(i, value);
                    maxValue = value;
                    if (value >= upper)
                    {
                        return bestMove;
                    }else if(maxValue > lowerValue)
                    {
                        lowerValue = maxValue;
                    }
                }

            }

            return bestMove;

        }
    }
}
