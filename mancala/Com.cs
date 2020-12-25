using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mancala
{
    public  class Com
    {
        const int  MIN_VISIT = 10;
        const double CONFIDENCE_SCALE = 32.0 * EvaluatorConst.VALUE_PER_SEED;
        const int MAX_VALUE = 100000;
        const int EXPLORE_BONUS = 50000;

        public struct Move
        {
            public int? x;
            public int i;
        }

        public Move FindBestMove(BoardState boardState,int depth,Evaluator evaluator)
        {
            return new Move();
        }










    }
}
