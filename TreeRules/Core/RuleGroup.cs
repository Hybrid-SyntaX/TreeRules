using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeRules.Core
{
    public abstract class RuleGroup : ITreeRule

    {
        public string OperatorName => GetType().Name;

        protected List<ITreeRule> rules = new List<ITreeRule>();

        public virtual string Description => $"[ {string.Join($" {sign} ", rules.Select(x => x.Description))} ]";
        public virtual string Evaluation => $"[ {string.Join($" {sign} ", rules.Select(x => x.Evaluation))} ]";

        protected abstract string sign { get; }

        public abstract bool Result { get; }

        public RuleGroup(params ITreeRule[] rules)
        {
            this.rules.AddRange(rules);
        }

        public IEnumerable<ITreeRule> Rules => rules.AsEnumerable();


        public void Add(ITreeRule treeRule) => rules.Add(treeRule);
        public void Remove(ITreeRule treeRule) => rules.Remove(treeRule);
        public abstract bool Evaluate();

        public static implicit operator bool(RuleGroup treeRule)
        {
            return treeRule.Evaluate();
        }


    }
}
