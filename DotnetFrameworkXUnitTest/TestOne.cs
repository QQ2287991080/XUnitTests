using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotnetFrameworkXUnitTest
{
    public class TestOne
    {

        /*
         * .NET支持两种不同类型的单元测试：事实和理论。
         *(事实)Fact 总是真实的测试。它们测试不变条件。
         *(理论)Theory 是只适用于特定数据集的测试 
         */
        [Fact]
        public void PassTesting()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailTesting()
        {
            Assert.Equal(5, Add(2, 2));
        }
        int Add(int x,int y)
        {
            return x + y;
        }

        /*Write your first theory*/

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyTheory(int value)
        {
            Assert.True(IsOdd(value));
        }
        bool IsOdd(int value) => value % 2 == 1;
        

    }
}
