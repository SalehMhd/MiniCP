using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCP;

namespace MiniCPTests
{
    [TestClass]
    public class SmallerThanTests
    {
        #region Operand2_is_Variable
        [TestMethod]
        public void Constant_Is_Smaller_Than_Operand2_Then_Operand2_is_the_same()
        {
            //Arrange
            var domainsList = new List<IDomain> {
                new RangeDomain { LowBound = 4, HighBound = 6}
            };

            var variable = new Variable { Domains = domainsList };

            var rule = new SmallerThan { Operand1 = new Constant(2), Operand2 = variable };

            //Act
            rule.Propagate();

            //Assert
            Assert.AreEqual(variable.Domains[0].Values().Count, 3);
        }

        [TestMethod]
        public void Constant_Is_Bigger_Than_Operand2_Then_Operand2_is_empty()
        {
            //Arrange
            var domainsList = new List<IDomain> {
                new RangeDomain { LowBound = 4, HighBound = 6}
            };

            var variable = new Variable { Domains = domainsList };

            var rule = new SmallerThan { Operand1 = new Constant(8), Operand2 = variable };

            //Act
            rule.Propagate();

            //Assert
            Assert.AreEqual(variable.Domains.Count, 0);
        }

        [TestMethod]
        public void Constant_Is_Within_Than_Operand2_Then_Operand2_is_pruned()
        {
            //Arrange
            var domainsList = new List<IDomain> {
                new RangeDomain { LowBound = 4, HighBound = 7}
            };

            var variable = new Variable { Domains = domainsList };

            var rule = new SmallerThan { Operand1 = new Constant(5), Operand2 = variable };

            //Act
            rule.Propagate();

            //Assert
            Assert.AreEqual(variable.Domains[0].Values().Count, 2);
        }
        #endregion

        //This region is almost copy/past of the previous one, just to have full coverage
        #region Operand2_is_Variable
        [TestMethod]
        public void Operand1_Is_Bigger_Than_Constant_Then_Operand1_is_empty()
        {
            //Arrange
            var domainsList = new List<IDomain> {
                new RangeDomain { LowBound = 4, HighBound = 6}
            };

            var variable = new Variable { Domains = domainsList };

            var rule = new SmallerThan { Operand1 = variable, Operand2 = new Constant(2) };

            //Act
            rule.Propagate();

            //Assert
            Assert.AreEqual(variable.Domains.Count, 0);
        }

        [TestMethod]
        public void Operand1_Is_Smaller_Than_Constant_Then_Operand1_is_the_same()
        {
            //Arrange
            var domainsList = new List<IDomain> {
                new RangeDomain { LowBound = 4, HighBound = 6}
            };

            var variable = new Variable { Domains = domainsList };

            var rule = new SmallerThan { Operand1 = variable, Operand2 = new Constant(8) };

            //Act
            rule.Propagate();

            //Assert
            Assert.AreEqual(variable.Domains[0].Values().Count, 3);
        }

        #endregion

    }
}
