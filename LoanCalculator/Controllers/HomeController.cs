using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoanCalculator
{
    public class HomeController : RazorPagesController
    {
        public IActionResult Index()
        {
            // Get the loan amount, payment frequency, loan period, start date, and interest type from the user.
            decimal loanAmount = 10000;
            string paymentFrequency = "Monthly";
            int loanPeriod = 36;
            DateTime startDate = DateTime.Now;
            string interestType = "Reducing balance";

            // Calculate the interest rate for the loan.
            decimal interestRate = 0;
            if (interestType == "Reducing balance")
            {
                interestRate = 25;
            }
            else
            {
                interestRate = 20;
            }

            // Calculate the monthly payment.
            decimal monthlyPayment = CalculateMonthlyPayment(loanAmount, interestRate, loanPeriod, paymentFrequency);

            // Calculate the total interest paid over the life of the loan.
            decimal totalInterest = CalculateTotalInterest(loanAmount, interestRate, loanPeriod, paymentFrequency);

            // Create a view model to store the loan details.
            LoanCalculatorViewModel loanCalculatorViewModel = new LoanCalculatorViewModel
            {
                LoanAmount = loanAmount,
                PaymentFrequency = paymentFrequency,
                LoanPeriod = loanPeriod,
                StartDate = startDate,
                InterestType = interestType,
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest
            };

            // Return the view.
            return View(loanCalculatorViewModel);
        }

        private IActionResult View(LoanCalculatorViewModel loanCalculatorViewModel)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int loanPeriod, string paymentFrequency)
        {
            // Calculate the number of payments.
            int numberOfPayments = loanPeriod * 12 / GetPaymentFrequency(paymentFrequency);

            // Calculate the monthly payment.
            decimal monthlyPayment = loanAmount * (interestRate / 12) / ((1 - (1 + (interestRate / 12))) ^ -numberOfPayments);

            return (decimal)monthlyPayment;
        }

        private decimal CalculateTotalInterest(decimal loanAmount, decimal interestRate, int loanPeriod, string paymentFrequency)
        {
            // Calculate the number of payments.
            int numberOfPayments = loanPeriod * 12 / GetPaymentFrequency(paymentFrequency);

            // Calculate the total interest.
            decimal totalInterest = loanAmount * interestRate * numberOfPayments / (12 * (1 - (1 + interestRate / 12) ^ -numberOfPayments));

            return totalInterest;
        }

        private int GetPaymentFrequency(string paymentFrequency)
        {
            switch (paymentFrequency)
            {
                case "Annually":
                    return 1;
                case "Quarterly":
                    return 4;
                case "Monthly":
                    return 12;
                case "Every 6 Months":
                    return 6;
                default:
                    return 0;
            }
        }
    }

    public class RazorPagesController
    {
        public object? ModelState { get; private set; }

        [HttpPost]
        public IActionResult Index(LoanCalculatorViewModel loanViewModel)
        {
            // Validate the input.
            if (ModelState.IsValid)
            {
                // Calculate the loan details.
                decimal monthlyPayment = CalculateMonthlyPayment(loanViewModel.LoanAmount, loanViewModel.InterestRate, loanViewModel.LoanPeriod, loanViewModel.PaymentFrequency);
                decimal totalInterest = CalculateTotalInterest(loanViewModel.LoanAmount, loanViewModel.InterestRate, loanViewModel.LoanPeriod, loanViewModel.PaymentFrequency);

                // Update the view model with the loan details.
                loanViewModel.MonthlyPayment = monthlyPayment;
                loanViewModel.TotalInterest = totalInterest;

                // Return the view.
                return ViewResult(loanViewModel);
            }
            else
            {
                // Return the view with the errors.
                return ViewResult(loanViewModel);
            }
        }

        private IActionResult ViewResult(LoanCalculatorViewModel loanViewModel)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateTotalInterest(decimal loanAmount, object interestRate, int loanPeriod, string paymentFrequency)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateMonthlyPayment(decimal loanAmount, object interestRate, int loanPeriod, string paymentFrequency)
        {
            throw new NotImplementedException();
        }
    }
}
