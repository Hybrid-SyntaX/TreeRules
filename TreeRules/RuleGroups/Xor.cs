using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;

namespace TreeRules.RuleGroups
{
    public class Xor : RuleGroup
    {
        private List<bool> _results = new List<bool>();
        private bool _reuslt;

        private List<string> _evaluations =new List<string>();
        public Xor(params ITreeRule[] rules) : base(rules)
        {
        }

        public override bool Result => _reuslt;

        protected override string sign => "^";

        public override bool Evaluate()
        {

            foreach (var rule in rules)
            {
                _reuslt ^= rule.Evaluate();
            }

            return _reuslt;
        }
    }
}
