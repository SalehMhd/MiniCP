using MiniCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiniCPTests
{
    [TestClass]
    public class RangeDomainTests
    {
        #region NextValue
        [TestMethod]
        public void Next_to_less_than_lower_bound_is_lower_bound()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 2, HighBound = 3 };

            //Act
            var nextToOne = domain.NextValue(1);

            //Assert
            Assert.AreEqual(nextToOne, domain.LowBound);
        }

        [TestMethod]
        public void Next_to_lower_bound_is_lower_bound_plus_1()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 2, HighBound = 4 };

            //Act
            var nextLowerBound = domain.NextValue(domain.LowBound);

            //Assert
            Assert.AreEqual(nextLowerBound, 3);
        }

        [TestMethod]
        public void Next_to_value_in_domain_is_value_plus_1()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 2, HighBound = 6 };

            //Act
            var nextToValue = domain.NextValue(4);

            //Assert
            Assert.AreEqual(nextToValue, 5);
        }

        [TestMethod]
        public void Next_to_higher_bound_is_int_max()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 2, HighBound = 4 };

            //Act
            var nextHigherBound = domain.NextValue(4);

            //Assert
            Assert.AreEqual(nextHigherBound, int.MaxValue);
        }

        [TestMethod]
        public void Next_to_higher_than_higher_bound_is_int_max()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 2, HighBound = 4 };

            //Act
            var nextHigherBound = domain.NextValue(5);

            //Assert
            Assert.AreEqual(nextHigherBound, int.MaxValue);
        }
        #endregion

        #region Values
        [TestMethod]
        public void Lower_bound_equal_to_higher_bound_returns_one_value()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 1, HighBound = 1 };

            //Act
            var domainValues = domain.Values();

            //Assert
            Assert.AreEqual(domainValues.Count, 1);
            Assert.AreEqual(domainValues[0], 1);
        }

        [TestMethod]
        public void Lower_bound_lower_then_higher_bound_returns_values_count()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 1, HighBound = 3 };

            //Act
            var domainValues = domain.Values();

            //Assert
            Assert.AreEqual(domainValues.Count, 3);
            Assert.AreEqual(domainValues[0], 1);
            Assert.AreEqual(domainValues[1], 2);
            Assert.AreEqual(domainValues[2], 3);
        }
        #endregion

        #region RemoveValue
        [TestMethod]
        public void remove_lower_bound_should_make_new_lower_bound_plus_one()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 1, HighBound = 3 };

            //Act
            domain.Remove(domain.LowBound);

            //Assert
            Assert.AreEqual(domain.LowBound, 2);
        }

        [TestMethod]
        public void remove_higher_bound_should_make_new_higher_bound_minus_one()
        {
            //Arrange
            var domain = new RangeDomain { LowBound = 1, HighBound = 3 };

            //Act
            domain.Remove(domain.HighBound);

            //Assert
            Assert.AreEqual(domain.HighBound, 2);
        }
        #endregion
    }
}