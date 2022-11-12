using TreeRules.Core;
using TreeRules.RuleGroups;
using TreeRules.Rules;




namespace TreeRules
{

    public static class Functional
    {
        public static LteRule Lte(IComparable a, IComparable b) => new LteRule(a, b);
        public static GteRule Gte( IComparable a, IComparable b) => new GteRule(a, b);
        public static LtRule Lt( IComparable a, IComparable b) => new LtRule(a, b);
        public static GtRule Gt( IComparable a, IComparable b) => new GtRule(a, b);
        public static EqualRule Equal( IComparable a, IComparable b) => new EqualRule(a, b);
        public static NotRule Not( ITreeRule rule) => new NotRule(rule);

        public static BranchRule Branch( ITreeRule condition, ITreeRule left, ITreeRule right) => new BranchRule(condition, left, right);

        public static AllRuleGroup All( params ITreeRule[] rules) => new AllRuleGroup(rules);
        public static AnyRuleGroup Any( params ITreeRule[] rules) => new AnyRuleGroup(rules);
        public static XorRuleGroup Xor( params ITreeRule[] rules) => new XorRuleGroup(rules);
    }
}