using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CompoundInterest
    {
        public double _principal;
        private int _timesCompounded;
        private double _interestRate;
        private int _years;

        public double Principal
        {
            get { return _principal; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Principal amount cannot be negative.");
                }

                _principal = value;
            }
        }

        [Display(Name = "Times interest is compounded per year")]
        public int TimesCompounded
        {
            get
            {
                return _timesCompounded;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Times interest is compounded per year cannot be negative.");
                }
                if (value == 0)
                {
                    throw new Exception("Times interest is compounded per year cannot be zero.");
                }
                _timesCompounded = value;
            }
        }

        [Display(Name = "Interest Rate (%)")]
        public double InterestRate
        {
            get { return _interestRate; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Interest rate cannot be negative.");
                }

                _interestRate = value;
            }
        }

        [Display(Name = "Time in years")]
        public int Years
        {
            get { return _years; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Years cannot be negative.");
                }
                _years = value;
            }
        }

        /// <summary>
        /// CompoundInterest.
        /// </summary>
        public double CompoundInterestCalculator()
        {
            var interestRate = InterestRate / 100;

            // (1 + r/n)
            double body = 1 + (interestRate / TimesCompounded);

            // nt
            double exponent = TimesCompounded * Years;

            // P(1 + r/n)^nt
            return Principal * Math.Pow(body, exponent) * 1000;
        }

    }
}