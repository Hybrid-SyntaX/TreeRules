using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeRules.Core;
using TreeRules.RuleGroups;
using TreeRules.Rules;

namespace TreeRules
{
    public abstract class RuleBook
    {
        public static Lte Lte(IComparable a, IComparable b) => new Lte(a, b);
        public static Gte Gte(IComparable a, IComparable b) => new Gte(a, b);
        public static Lt Lt(IComparable a, IComparable b) => new Lt(a, b);
        public static Gt Gt(IComparable a, IComparable b) => new Gt(a, b);
        public static NotEqual Equal(IComparable a, IComparable b) => new NotEqual(a, b);
        public static Not Not(ITreeRule rule) => new Not(rule);

        public static Branch Branch(ITreeRule condition, ITreeRule left, ITreeRule right) => new Branch(condition, left, right);

        public static All All(params ITreeRule[] rules) => new All(rules);
        public static Any Any(params ITreeRule[] rules) => new Any(rules);
        public static Xor Xor(params ITreeRule[] rules) => new Xor(rules);


        public RuleBook()
        {

        }

        public abstract bool Evaluate();

    }
}
