// My LoanCalculator.js

$(document).ready(function () {

    // Initialize the loan calculator.
    var loanCalculator = new LoanCalculator();

    // Bind the event handlers.
    $("#loanAmount").on("input", function () {
        loanCalculator.calculate();
    });

    $("#interestRate").on("input", function () {
        loanCalculator.calculate();
    });

    $("#loanPeriod").on("input", function () {
        loanCalculator.calculate();
    });

    $("#paymentFrequency").on("change", function () {
        loanCalculator.calculate();
    });

    // Calculate the loan details.
    loanCalculator.calculate();
});

// LoanCalculator class

class LoanCalculator {

    constructor() {
        this.loanAmount = 10000;
        this.interestRate = 20;
        this.loanPeriod = 36;
        this.paymentFrequency = "Monthly";
    }

    calculate() {
        // Calculate the number of payments.
        var numberOfPayments = this.loanPeriod * 12 / GetPaymentFrequency(this.paymentFrequency);

        // Calculate the monthly payment.
        var monthlyPayment = this.loanAmount * (this.interestRate / 12) / (1 - (1 + this.interestRate / 12) ^ -numberOfPayments);

        // Calculate the total interest paid over the life of the loan.
        var totalInterest = this.loanAmount * this.interestRate * numberOfPayments / (12 * (1 - (1 + this.interestRate / 12) ^ -numberOfPayments));

        // Update the UI.
        $("#monthlyPayment").val(monthlyPayment);
        $("#totalInterest").val(totalInterest);
    }
}

// GetPaymentFrequency function

function GetPaymentFrequency(paymentFrequency) {
    switch (paymentFrequency) {
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