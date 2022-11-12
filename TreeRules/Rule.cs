using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeRules
{
    public abstract class Rule : ITreeRule
    {
        public abstract bool Evaluate();


        public static implicit operator bool(Rule treeRule)
        {
            return treeRule.Evaluate();
        }
    }
}
