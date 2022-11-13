using System.Runtime.CompilerServices;

namespace TreeRules.Rules
{
    public class Equal : ComparisonBase
    {

        private bool _result;

        public Equal(IComparable leftValue,
                         IComparable rightValue,
                         [CallerArgumentExpression("leftValue")] string leftName = null,
                         [CallerArgumentExpression("rightValue")] string rightName = null) : base(leftValue, rightValue, leftName, rightName)
        {
        }

        public override bool Result => _result;

        protected override string sign => "==";

        public override bool Evaluate()
        {
            return _result = LeftValue.CompareTo(RightValue) == 0;
        }

    }
}
