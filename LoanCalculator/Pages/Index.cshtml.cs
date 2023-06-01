using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Pages
{
    public class LoanCalculatorModel : PageModel
    {
        private readonly ILogger<LoanCalculatorModel> _logger;
        private PaymentFrequency paymentFrequency;

        public LoanCalculatorModel(ILogger<LoanCalculatorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet() { }
        public void OnPost() { }

     
        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [Required]
        public int LoanPeriod { get; set; }


        public PaymentFrequency GetPaymentFrequency()
        {
            return paymentFrequency;
        }

        public void SetPaymentFrequency(PaymentFrequency value)
        {
            paymentFrequency = value;
        }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public decimal InterestType { get; set; }

        [Required]
        public decimal LegalFees { get; set; }

        [Required]
        public decimal ProcessingFees { get; set; }

        [Required]
        public decimal ExciseDuty { get; set; }

        public IEnumerable<LoanPayments> Payments { get; set; }

        public decimal GetTotalInterest()
        {
            return Payments.Sum(p => p.Interest);
        }

        public decimal GetTotalPrincipal()
        {
            return Payments.Sum(p => p.Principal);
        }

        public decimal GetTotalPayments()
        {
            return Payments.Sum(p => p.Amount);
        }
    }
}