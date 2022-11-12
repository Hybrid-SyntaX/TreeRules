
using TreeRules;

namespace Tests
{
    public class UnitTest1
    {
        //[Fact]
        //public void Test1()
        //{
        //    var x = true;
        //    var y = true;
        //    //var rule = new Rule(x && y);

        //    Assert.True(rule.Execute());
        //}

        //[Fact]
        //public void Test2()
        //{
        //    var x = true;
        //    var y = true;
        //    var rule1 = new Rule(x && y);
        //    var rule2 = new Rule(x != y);
        //    var ruleGroup = new RuleGroup(rule1,rule2);

        //    Assert.False(ruleGroup.Execute());
        //}

        [Fact]
        public void Test2()
        {
            var x = 3;
            var y = 2;
            var rule1 = new AndRuleGroup(new GteRule(x, y));

            Assert.True(rule1.Evaluate());
        }
        [Fact]
        public void Test3()
        {
            var x = 3;
            var y = 2;
            var rule1 = new GteRule(x, y);

            Assert.True(rule1);
        }

        [Fact]
        public void Test4()
        {
            var x = 1;
            var y = 2;
            var rule1 = new OrRuleGroup(new  LteRule(x, y), new LteRule(y, x));

            Assert.True(rule1);
        }

        [Fact]
        public void Test5()
        {
            var x = 1;
            var y = 2;
            var rule1 = new OrRuleGroup(new LteRule(x, y), new OrRuleGroup(new GteRule(y, x), new GteRule(x, x)));

            Assert.True(rule1.Evaluate());
        }
    }
}