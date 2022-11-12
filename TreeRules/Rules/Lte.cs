using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;

namespace TreeRules.Rules
{
    public class Lte : Rule
    {
        private readonly IComparable _left;
        private readonly IComparable _right;
        private readonly string _leftVar;
        private readonly string _rightVar;
        private bool _result;

        public override string Description => $"{_leftVar} >= {_rightVar}";
        public override string Evaluation => $"{_left} >= {_right} == {_result}";

        public override bool Result => _result;

        public Lte(IComparable left, IComparable right,
                        [CallerArgumentExpression("left")] string leftVar = null,
            [CallerArgumentExpression("right")] string rightVar = null)
        {
            _left = left;
            _right = right;
            _leftVar = leftVar;
            _rightVar = rightVar;
        }


        public override bool Evaluate()
        {
            return _result = _left.CompareTo(_right) <= 0;
        }
    }
}
