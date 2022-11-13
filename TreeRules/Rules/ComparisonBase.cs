using System.Runtime.CompilerServices;

namespace TreeRules.Rules
{
    public abstract class ComparisonBase : Core.Rule
    {

        public IComparable LeftValue { get; }
        public IComparable RightValue { get; }
        public string LeftName { get; }
        public string RightName { get; }

        protected abstract string sign { get; }

        public override string Description => $"({LeftName} {sign} {RightName})";
        public override string Evaluation => $"({LeftValue} {sign} {RightValue} == {Result})";


        public ComparisonBase(IComparable leftValue,
                              IComparable rightValue,
                              [CallerArgumentExpression("leftValue")] string leftName = null,
                              [CallerArgumentExpression("rightValue")] string rightName = null)
        {
            LeftValue = leftValue;
            RightValue = rightValue;
            LeftName = leftName;
            RightName = rightName;
        }


    }
}
