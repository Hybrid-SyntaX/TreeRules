using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeRules
{
    public class AndRuleGroup : RuleGroup
    {
        public AndRuleGroup(params ITreeRule[] rules):base(rules)
        {
        }

        public override bool Evaluate()
        {
            return Rules.All(x => x.Evaluate());
        }
    }
}
