namespace Domain.IExternalServices;

/// <summary>
/// Defines a contract for sending emails asynchronously.
/// </summary>
public interface IEmailSenderService
{
    /// <summary>
    /// Sends an email asynchronously to the specified recipient.
    /// </summary>
    /// <param name="mailTO">The recipient's email address.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="body">The body content of the email, can be HTML.</param>
    /// <returns>A task that represents the asynchronous operation. Returns true if the email is sent successfully; otherwise, false.</returns>
    Task<bool> SendEmailAsync(string mailTO, string subject, string body);
}

