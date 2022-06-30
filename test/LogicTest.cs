using System;
using Xunit;

namespace Test
{
    public class LogicTest
    {
        [Fact]
        public void SimpleTest()
        {
        //Given
        var x =1;
        //When
        x++;
        //Then
        Assert.Equal(2,x);
        }
        [Fact]
        public void TestName()
        {
        //Given
        var a=3;
        var b=4;
        //When
        var x=a*b;
        //Then
        Assert.Equal(12,x);
        }
        
    }
}
