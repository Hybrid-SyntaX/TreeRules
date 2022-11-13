
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TreeRules;
using _ = TreeRules.Functional;
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
            var rule1 = new All(new Gte(x, y));

            Assert.True(rule1.Evaluate());
        }
        [Fact]
        public void Test3()
        {
            var x = 3;
            var y = 2;
            var rule1 = new Gte(x, y);

            Assert.True(rule1);
        }

        [Fact]
        public void Test4()
        {
            var x = 1;
            var y = 2;
            var rule1 = new Any(new Lte(x, y), new Lte(y, x));

            Assert.True(rule1);
        }


        [Fact]
        public void Test5()
        {
            var x = 1;
            var y = 2;
            var rule1 = new Any(
                                new Lte(x, y),
                                                new All(new Gte(y, x), new Gte(x, x))
                                        );
            var json = JsonConvert.SerializeObject(rule1);
            Assert.True(rule1.Evaluate());
        }


        [Fact]
        public void TestBranch()
        {
            var x = 1;
            var y = 2;
            var rule1 = _.Branch(
                            _.Gte(x, y), // True
                            _.Equal(12, 12), // True
                            _.Gte(y, x) // False
                        );
            //var rule2 = _.Equal(12, 12);
            //rule2.Evaluate();
     
            var res = rule1.Evaluate();
            var json = JsonConvert.SerializeObject(rule1);
            Assert.True(res);
        }

        [Fact]
        public void TestXor()
        {
            var x = 10;
            var y = 20;
            var rule1 = _.Any(
                                _.Gt(x, 1), _.Gte(y, x)
                                    , _.Xor(_.Equal(1, 1), _.NotEqual(y, 11),
                                    _.Not(_.All(_.Lt(x, y), _.Gt(y, 1)))
                                    )
                                  );
            var result = rule1.Evaluate();

            var json = JsonConvert.SerializeObject(rule1);
            Assert.True(result);
        }


        class XorTest : RuleBook
        {
            private Xor rule1;

            public XorTest(int x, int y)
            {
                rule1 = Xor(Equal(x, 1), Gt(y, x));

            }
            public override bool Evaluate()
            {
                return rule1.Evaluate();
            }
        }

        [Fact]
        public void TestFunctional()
        {
            var x = 1;
            var y = 2;


            var rule1 = _.Xor(_.Equal(x, 1), _.Gt(y, x));
            var result = rule1.Evaluate();

            var json = JsonConvert.SerializeObject(rule1);
            Assert.True(result);
        }

        [Fact]
        public void TestBooks()
        {
            int x = 1;
            int y = 2;
            var ruleBook = new XorTest(x, y);
            var result = ruleBook.Evaluate();

            var json = JsonConvert.SerializeObject(ruleBook);
            Assert.True(result);
        }
    }
}