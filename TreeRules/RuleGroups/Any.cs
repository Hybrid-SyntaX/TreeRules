using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;

namespace TreeRules.RuleGroups
{
    public class Any : RuleGroup
    {
        private List<bool> _results = new List<bool>();
        private bool _reuslt;

        
        public Any(params ITreeRule[] rules) : base(rules)
        {
        }

        //public override string Description => string.Join(" | ", rules.Select(x => x.Description));

        //public override string Evaluation => $"{string.Join(" | ", _results)} == {_results.Any()}";

        public override bool Result => _reuslt;

        protected override string sign => "|";

        public override bool Evaluate()
        {
            return _reuslt = rules.Any(x => x.Evaluate());
        }
    }
}
