using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeRules
{
    public class OrRuleGroup : RuleGroup
    {
        public OrRuleGroup( params ITreeRule[] rules) : base(rules)
        {
        }

        public override bool Evaluate()
        {
            return Rules.Any(x => x.Evaluate());
        }
    }
}
