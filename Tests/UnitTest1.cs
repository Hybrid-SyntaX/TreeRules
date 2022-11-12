
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
            var rule1 = new Branch(
                            new Gte(y,x),
                            new Gte(x,y),
                            new Lte(x,y)
                        );
            var json = JsonConvert.SerializeObject(rule1);
            Assert.True(rule1.Evaluate());
        }
    }
}