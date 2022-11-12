using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeRules.Core
{
    public abstract class Rule : ITreeRule
    {
        public abstract bool Evaluate();
        public abstract string Description { get; }
        public abstract string Evaluation { get; }

        public abstract bool Result { get; }

        public static implicit operator bool(Rule treeRule)
        {
            return treeRule.Evaluate();
        }
    }
}
