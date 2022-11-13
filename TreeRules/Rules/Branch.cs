using TreeRules.Core;

namespace TreeRules.Rules
{
    public class Branch : Core.Rule
    {
        public ITreeRule Condition { get; }
        public ITreeRule MainRule { get; }
        public ITreeRule ElseRule { get; }

        public string ExecuationPath { get; private set; }
        private bool _result;

        public override bool Result => _result;

        public override string Description => $"[ ({Condition.Description})? {MainRule.Description} : {ElseRule.Description} ]";

        public override string Evaluation => $"({Condition.Evaluation})? {MainRule.Evaluation}) : {ElseRule.Evaluation} == {Result}";

        public Branch(ITreeRule conditionRule, ITreeRule mainRule, ITreeRule elseRule)
        {
            Condition = conditionRule;
            MainRule = mainRule;
            ElseRule = elseRule;
        }

        public override bool Evaluate()
        {
            if (Condition.Evaluate())
            {
                ExecuationPath = nameof(MainRule);
                return _result = MainRule.Evaluate();

            }
            ExecuationPath = nameof(ElseRule);
            return _result = ElseRule.Evaluate();
        }
    }
}
