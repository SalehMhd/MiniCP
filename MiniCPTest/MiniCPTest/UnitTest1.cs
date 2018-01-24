using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCP;
using System.Collections.Generic;

namespace MiniCPTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var domainsList = new List<IDomain<int>> {
                new RangeDomain<int> { LowBound = 1, HighBound = 3 },
                new RangeDomain<int> { LowBound = 4, HighBound = 6 }
            };

            var x = new Variable<int> { Domains = domainsList };

            var rule = new SmallerThan<int> { Operand1 = new Constant<int> { Value = 5 }, Operand2 = x };

            var context = new CPContext();
            context.Add(rule);

            //Act
            var xAssignments = context.Evaluate();

            //Assert
            Assert.AreEqual(6, x.Value());
        }
    }
}
