using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            var x = new Variable<int>(domainsList);

            var rule = new Rule();
            rule.Operand(x).LargerThan().Operand(5);

            var context = new CPContext();
            context.add(rule);

            //Act
            var xAssignments = context.evaluate();

            //Assert
            Assert.AreEqual(6, x.Value());
        }
    }
}
