using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeRules
{
    public class LteRule:Rule
    {
        public IComparable Left { get; }
        public IComparable Right { get; }

        public LteRule(IComparable left, IComparable right)
        {
            Left = left;
            Right = right;
        }


        public override bool Evaluate()
        {
            return Left.CompareTo(Right) <= 0;
        }
    }
}
