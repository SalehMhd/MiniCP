using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCP;

namespace MiniCPTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var domainsList = new List<IDomain> {
                //new RangeDomain { LowBound = 1, HighBound = 3},
                new RangeDomain { LowBound = 4, HighBound = 6}
            };

            var x = new Variable { Domains = domainsList };

            var rule = new SmallerThan { Operand1 = new Constant(5), Operand2 = x };

            var context = new CPContext();
            context.Add(x);
            context.Add(rule);

            //Act
            var xAssignments = context.Evaluate();

            //Assert
            Assert.AreEqual(6, x.Values()[0]);            
        }
    }
}
