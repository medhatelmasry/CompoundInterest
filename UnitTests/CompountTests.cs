using System;
using Web.Models;
using Xunit;

namespace UnitTests
{
    public class CompountTests
    {
        [Fact]
        public void P1000T12I5Y10Results1647dot01()
        {
            CompoundInterest ci = new CompoundInterest()
            {
                Principal = 1000,
                TimesCompounded = 12,
                InterestRate = 5,
                Years = 10
            };

            var expected = 1647.01;
            var actual = Math.Round(ci.CompoundInterestCalculator(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void P0T12I5Y10Results0()
        {
            CompoundInterest ci = new CompoundInterest()
            {
                Principal = 0,
                TimesCompounded = 12,
                InterestRate = 5,
                Years = 10
            };


            var expected = 0.00;
            var actual = Math.Round(ci.CompoundInterestCalculator(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void P1000T12I0Y10Results1000()
        {
            CompoundInterest ci = new CompoundInterest()
            {
                Principal = 1000,
                TimesCompounded = 12,
                InterestRate = 0,
                Years = 10
            };


            var expected = 1000.00;
            var actual = Math.Round(ci.CompoundInterestCalculator(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrincipalAmountCannotBeNegative()
        {
            CompoundInterest ci = new CompoundInterest();

            Action act = () => ci.Principal = -10; 
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void TimesCompoundedCannotBeNegative()
        {
            CompoundInterest ci = new CompoundInterest();

            Action act = () => ci.TimesCompounded = -10;
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void TimesCompoundedCannotBeZero()
        {
            CompoundInterest ci = new CompoundInterest();
            
            Action act = () => ci.TimesCompounded = 0; 
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void InterestRateCannotBeNegative()
        {
            CompoundInterest ci = new CompoundInterest();
            
            Action act = () => ci.InterestRate = -10;
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void YearsCannotBeNegative()
        {
            CompoundInterest ci = new CompoundInterest();
            
            Action act = () => ci.Years = -10;
            Assert.Throws<Exception>(act);
        }
    }
}
