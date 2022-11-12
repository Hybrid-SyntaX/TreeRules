using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;

namespace TreeRules.Rules
{
    public class NotRule : Rule
    {
        private readonly bool _value;
        private readonly ITreeRule _rule;
        private readonly string _valueVar;
        private bool _result;

        public override string Description => $"!{_valueVar}";

        public override string Evaluation => $"!{_value} == {_result}";

        public override bool Result => _result;

        public NotRule(ITreeRule rule, [CallerArgumentExpression("value")] string valueVar=null)
        {
            _rule = rule;
            _valueVar = valueVar;
        }
        public override bool Evaluate()
        {
            return _result = !_rule.Evaluate();
        }
    }
}
