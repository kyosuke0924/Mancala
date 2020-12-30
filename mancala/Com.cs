using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mancala
{

    public struct Move
    {
        public int? i;
        public int value;

        public Move(int? i, int value)
        {
            this.i = i;
            this.value = value;
        }
    }

    public class Com
    {
        const int  MIN_VISIT = 10;
        const double CONFIDENCE_SCALE = 32.0 * EvaluatorConst.VALUE_PER_SEED;
        const int MAX_VALUE = 100000;
        const int EXPLORE_BONUS = 50000;





        public Move FindBestMove(Board iBoard,int depth,Evaluator evaluator,PositionMap positionMap, PositionMap endingMap,  Boolean explore)
        {
            Board board = new Board(iBoard);

            var turn = board.GetTurn();
            var opponent = board.State.GetOpponentTurn();
            var LogTotalSize = positionMap.GetLength();
            Move bestMove = new Move(null , 0);
            var bestConfidence = -MAX_VALUE;
            var upper = MAX_VALUE;
            var lower = -MAX_VALUE;

            for (int i = 0; i < Constant.PIT_NUM; i++)
            {
                if (!board.Play(i)) continue;

                (int,int)? positionMapResult;
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

                (int, int) result;
                if (positionMapResult != null)
                {
                    result.Item1 = positionMapResult.Value.Item1;
                    result.Item2 = positionMapResult.Value.Item2;
                }
                else
                {
                    if (board.State.IsOver())
                    {
                        result.Item1 = (board.State.Stores[(int)turn] - board.State.Stores[(int)opponent]) * EvaluatorConst.VALUE_PER_SEED;
                    }
                    else 
                    {
                        var endingValue = endingMap.GetPositionValue(board.State);

                        if (endingValue != null)
                        {
                            result.Item1 = board.State.Turn == turn ? endingValue.Value.Value : -endingValue.Value.Value;
                        }
                        else if(depth == 1)
                        {
                            result.Item1 = board.State.Turn == turn ? evaluator.Evaluate(board.State) : -evaluator.Evaluate(board.State);
                        }
                        else
                        {
                            if (board.State.Turn == turn)
                            {
                                result.Item1 = Search(board, depth - 1, lower, upper, evaluator, endingMap).value;
                            }
                            else
                            {
                                result.Item1 = -Search(board, depth - 1, lower, upper, evaluator, endingMap).value;
                            }

                        }
                    }

                    result.Item2 = explore ? result.Item1 + EXPLORE_BONUS : result.Item1;
                    if (result.Item1 > lower) lower = result.Item1; 
                }

                if (result.Item2 > bestConfidence)
                {
                    bestMove = new Move(i, result.Item1);
                    bestConfidence = result.Item2;
                }

                board.Undo();

            }

            return bestMove;
        }

        private Move Search(Board iBoard, int depth, int lower, int upper, Evaluator evaluator, PositionMap endingMap)
        {

            Board board = new Board(iBoard);
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

                moves = candidates.OrderByDescending(x => x.value).Select(x => (int)x.i).ToList();
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
                            value = Search(board, depth - 1, lower, upper, evaluator, endingMap).value;
                        }
                        else
                        {
                            value = -Search(board, depth - 1, lower, upper, evaluator, endingMap).value;
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
