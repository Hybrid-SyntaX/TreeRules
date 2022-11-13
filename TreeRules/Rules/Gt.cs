using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;

namespace TreeRules.Rules
{
    public class Gt : ComparisonBase
    {

        private bool _result;

        public Gt(IComparable leftValue,
                      IComparable rightValue,
                      [CallerArgumentExpression("leftValue")] string leftName = null,
                      [CallerArgumentExpression("rightValue")] string rightName = null) : base(leftValue, rightValue, leftName, rightName)
        {
        }

        public override bool Result => _result;

        protected override string sign => ">";

        public override bool Evaluate()
        {
            return _result = LeftValue.CompareTo(RightValue) > 0;

        }

    }
}
