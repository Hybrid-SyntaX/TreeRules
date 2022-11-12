using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;

namespace TreeRules.Rules
{
    public class Not : Rule
    {
        private readonly bool _value;
        private readonly string _valueVar;
        private bool _result;

        public override string Description => $"!{_valueVar}";

        public override string Evaluation => $"!{_value} == {_result}";

        public override bool Result => _result;

        public Not(bool value, [CallerArgumentExpression("value")] string valueVar=null)
        {
            _value = value;
            _valueVar = valueVar;
        }
        public override bool Evaluate()
        {
            return _result = !_value;
        }
    }
}
