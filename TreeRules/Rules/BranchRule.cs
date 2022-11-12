using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;

namespace TreeRules.Rules
{
    public class BranchRule : Rule
    {
        private readonly ITreeRule _condition;
        private readonly ITreeRule _left;
        private readonly ITreeRule _right;
        private bool _result;

        public override bool Result => _result;

        public override string Description => $"({_left.Description}, {_right.Description})?";

        public override string Evaluation => $"({_left.Result}, {_right.Result})?{_result}";

        public BranchRule(ITreeRule condition, ITreeRule left, ITreeRule right)
        {
            _condition = condition;
            _left = left;
            _right = right;
        }

        public override bool Evaluate()
        {
            if (_condition.Result)
            {
                return _result = _left.Evaluate();
            }
  
            return _result = _right.Evaluate();
        }
    }
}
