using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace LoanCalculator.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    public ActionResult DownloadPdf(int loanId)
    {
        // Get the loan details.
        Loan loan = _context.Loans.Find(loanId);

        // Create a PDF document.
        var pdfDocument = new PdfDocument();

        // Add the loan details to the PDF document.
        pdfDocument.AddPage(new LoanPdfPage(loan));

        // Save the PDF document.
        pdfDocument.Save(@"C:\path\to\loan.pdf");

        // Return the PDF file.
        return FileInfo(pdfDocument, "application/pdf");
    }

    public ActionResult Email(int loanId, string emailAddress)
    {
        // Get the loan details.
        Loan loan = _context.Loans.Find(loanId);

        // Send the instalments to the specified email address.
        MailMessage mailMessage = new MailMessage();
        mailMessage.To = emailAddress;
        mailMessage.Subject = "Loan Instalments";
        mailMessage.Body = "Please find attached the loan instalments.";
        mailMessage.Attachments.Add(@"C:\path\to\loan.pdf");
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Send(mailMessage);

        // Return a success message.
        return Content("The instalments have been emailed to the specified email address.");
    }
}

