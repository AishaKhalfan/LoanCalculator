namespace LoanCalculator
{
    internal class LoanCalculatorViewModel
    {
        public decimal LoanAmount { get; internal set; }
        public string PaymentFrequency { get; internal set; }
        public int LoanPeriod { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public string InterestType { get; internal set; }
        public decimal MonthlyPayment { get; internal set; }
        public decimal TotalInterest { get; internal set; }
    }
}