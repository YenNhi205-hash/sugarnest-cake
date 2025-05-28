using Domain.IExternalServices;
using System.Net.Mail;
using System.Net;

namespace Infrastructure.ExternalServices;

/// <summary>
/// Provides functionality to send emails asynchronously using SMTP.
/// </summary>
/// <param name="username">The email address used as the sender.</param>
/// <param name="password">The password or app-specific password for authentication.</param>
public class EmailSenderService(string username, string password) : IEmailSenderService
{
    /// <summary>
    /// Sends an email message asynchronously to the specified recipient.
    /// </summary>
    /// <param name="emailTO">The recipient's email address.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="body">The body content of the email. HTML content is supported.</param>
    /// <returns>
    /// A task that represents the asynchronous send operation.
    /// Returns true if the email was sent successfully; otherwise, false.
    /// </returns>
    public async Task<bool> SendEmailAsync(string emailTO, string subject, string body)
    {
        // Creates a mail message object containing the email data
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(username); // Sender address
        mail.To.Add(emailTO);                   // Recipient address
        mail.Subject = subject;                 // Email subject
        mail.Body = body;                       // Email body content
        mail.IsBodyHtml = true;                 // Supports HTML content

        // Configures the SMTP client for Gmail SMTP server
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.EnableSsl = true;                                   // Enable SSL encryption
        smtpClient.Credentials = new NetworkCredential(username, password); // Authentication credentials
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;        // Delivery method

        try
        {
            // Send the email asynchronously
            await smtpClient.SendMailAsync(mail);
            return true;
        }
        catch (Exception ex)
        {
            // Log the exception message and return failure
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
