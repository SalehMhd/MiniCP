using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCP;

namespace MiniCPTests
{
    [TestClass]
    public class VariableTests
    {
        #region NextValue
        [TestMethod]
        public void Next_Value_For_Non_Initialized_Variable_Throws_Exception()
        {
            //Arrange
            var variable = new Variable();

            //Act
            try
            {
                variable.NextValue();
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, "Initialize Domains");
            }
        }

        [TestMethod]
        public void Next_Value_returns_first_domains_low_bound()
        {
            //Arrange
            var domain = new RangeDomain() { LowBound = 1, HighBound = 3 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain } };

            //Act
            var firstValue = variable.NextValue();

            //Assert
            Assert.AreEqual(firstValue, domain.LowBound);
        }

        [TestMethod]
        public void Next_Value_after_NextValue_returns_the_Value_After()
        {
            //Arrange
            var domain = new RangeDomain() { LowBound = 1, HighBound = 3 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain } };
            variable.NextValue();

            //Act
            var secondValue = variable.NextValue();

            //Assert
            Assert.AreEqual(secondValue, 2);
        }

        [TestMethod]
        public void Next_Value_when_adomain_ends_returns_low_bound_of_the_next_domain()
        {
            //Arrange
            var domain1 = new RangeDomain() { LowBound = 1, HighBound = 2 };
            var domain2 = new RangeDomain() { LowBound = 4, HighBound = 6 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain1, domain2 } };
            variable.NextValue();
            variable.NextValue();

            //Act
            var firstValue_SecondDomain = variable.NextValue();

            //Assert
            Assert.AreEqual(firstValue_SecondDomain, domain2.LowBound);
        }

        [TestMethod]
        public void Next_Value_after_the_last_value_of_the_last_domain_is_IntMax()
        {
            //Arrange
            var domain1 = new RangeDomain() { LowBound = 1, HighBound = 2 };
            var domain2 = new RangeDomain() { LowBound = 4, HighBound = 5 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain1, domain2 } };
            variable.NextValue();
            variable.NextValue();
            variable.NextValue();
            variable.NextValue();

            //Act
            var afterLastValue = variable.NextValue();

            //Assert
            Assert.AreEqual(afterLastValue, int.MaxValue);
        }
        #endregion

        #region Value

        [TestMethod]
        public void Value_called_for_the_first_time_equals_low_bound()
        {
            //Arrange
            var domain = new RangeDomain() { LowBound = 1, HighBound = 2 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain } };

            //Act
            var value = variable.Value();

            //Assert
            Assert.AreEqual(value, domain.LowBound);
        }

        [TestMethod]
        public void Value_equals_Next_Value()
        {
            //Arrange
            var domain = new RangeDomain() { LowBound = 1, HighBound = 2 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain } };

            //Act
            var nextValue = variable.NextValue();

            //Assert
            Assert.AreEqual(variable.Value(), nextValue);
        }
        #endregion

        #region Values
        [TestMethod]
        public void Values_Equal_Domain_Listing()
        {
            //Arrange
            var domain = new RangeDomain() { LowBound = 1, HighBound = 2 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain } };

            //Act
            var values = variable.Values();

            //Assert
            Assert.AreEqual(values[0], 1);
            Assert.AreEqual(values[1], 2);
        }
        #endregion

        #region RemoveValue
        [TestMethod]
        public void Remove_Not_Bound_Value_Throws_Exception()
        {
            //Arrange
            var domain = new RangeDomain() { LowBound = 1, HighBound = 3 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain } };

            //Act
            try
            {
                variable.RemoveValue(2);
            }
            catch(Exception ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, "value within the range, could not be removed");
            }
        }

        [TestMethod]
        public void Removing_last_value_of_domain_removes_domain()
        {
            //Arrange
            var domain1 = new RangeDomain() { LowBound = 1, HighBound = 2 };
            var domain2 = new RangeDomain() { LowBound = 4, HighBound = 5 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain1, domain2 } };

            //Act
            variable.RemoveValue(5);
            variable.RemoveValue(4);

            //Assert
            Assert.AreEqual(variable.Domains.Count, 1);
        }

        [TestMethod]
        public void Removing_last_value_of_last_domain_removes_domains()
        {
            //Arrange
            var domain = new RangeDomain() { LowBound = 1, HighBound = 2 };
            var variable = new Variable() { Domains = new System.Collections.Generic.List<IDomain>() { domain } };

            //Act
            variable.RemoveValue(1);
            variable.RemoveValue(2);

            //Assert
            Assert.AreEqual(variable.Domains.Count, 0);
        }
        #endregion
    }
}
