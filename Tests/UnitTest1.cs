
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TreeRules;
using TreeRules.RuleGroups;
using TreeRules.Rules;

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
            var rule1 = new AllRuleGroup(new GteRule(x, y));

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
            var rule1 = new AnyRuleGroup(new LteRule(x, y), new LteRule(y, x));

            Assert.True(rule1);
        }


        [Fact]
        public void Test5()
        {
            var x = 1;
            var y = 2;
            var rule1 = new AnyRuleGroup(
                                new LteRule(x, y),
                                                new AllRuleGroup(new GteRule(y, x), new GteRule(x, x))
                                        );
            var json = JsonConvert.SerializeObject(rule1);
            Assert.True(rule1.Evaluate());
        }


        [Fact]
        public void TestBranch()
        {
            var x = 1;
            var y = 2;
            var rule1 = new BranchRule(
                            new LteRule(y, x),
                            new GteRule(x, y),
                            new LteRule(x, y)
                        );
            var json = JsonConvert.SerializeObject(rule1);
            var res = rule1.Evaluate();
            Assert.True(res);
        }

        [Fact]
        public void TestXor()
        {
            var x = 1;
            var y = 2;
            var rule1 = new XorRuleGroup(new EqualRule(x, 1), new GtRule(y, x));
            var result = rule1.Evaluate();

            var json = JsonConvert.SerializeObject(rule1);
            Assert.True(result);
        }


        class XorTest: RuleBook
        {
            private XorRuleGroup rule1;

            public XorTest(int x,int y)
            {
                rule1 = Xor(Equal(x, 1), Gt(y, x));

            }
            public override bool Evaluate()
            {
                return rule1.Evaluate();
            }
        }

        [Fact]
        public void TestBook()
        {
            int x = 1;
            int y = 2;
            var ruleBook = new XorTest(x,y);
            var result = ruleBook.Evaluate();

            var json = JsonConvert.SerializeObject(ruleBook);
            Assert.True(result);
        }
    }
}