using TreeRules.Core;
using TreeRules.RuleGroups;
using TreeRules.Rules;




namespace TreeRules
{

    public static class Functional
    {
        public static Lte Lte(IComparable a, IComparable b) => new Lte(a, b);
        public static Gte Gte( IComparable a, IComparable b) => new Gte(a, b);
        public static Lt Lt( IComparable a, IComparable b) => new Lt(a, b);
        public static Gt Gt( IComparable a, IComparable b) => new Gt(a, b);
        public static Equal Equal( IComparable a, IComparable b) => new Equal(a, b);
        public static NotEqual NotEqual(IComparable a, IComparable b) => new NotEqual(a, b);

        public static Not Not( ITreeRule rule) => new Not(rule);



        public static Branch Branch( ITreeRule condition, ITreeRule left, ITreeRule right) => new Branch(condition, left, right);

        public static All All( params ITreeRule[] rules) => new All(rules);
        public static Any Any( params ITreeRule[] rules) => new Any(rules);
        public static Xor Xor( params ITreeRule[] rules) => new Xor(rules);
    }
}