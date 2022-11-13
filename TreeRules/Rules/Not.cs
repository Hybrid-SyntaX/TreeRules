using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;

namespace TreeRules.Rules
{
    public class Not : Core.Rule
    {
        private  ITreeRule Rule { get;  }
        private  string RuleName { get;  }
        private bool _result;

        public override string Description => $"!({Rule.Description})";

        public override string Evaluation => $"!({Rule.Evaluation}) == {Result}";

        public override bool Result => _result;

        public Not(ITreeRule rule,
                       [CallerArgumentExpression("rule")] string ruleName = null)
        {
            Rule = rule;
            RuleName = ruleName;
        }
        public override bool Evaluate()
        {
            return _result = !Rule.Evaluate();
        }
    }
}
