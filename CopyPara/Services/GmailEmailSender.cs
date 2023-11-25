using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CopyPara.Services;

public class GmailEmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly string _smtpUsername;
    private readonly string _smtpPassword;

    public GmailEmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
        _smtpUsername = _configuration["Gmail:Address"]!;
        _smtpPassword = _configuration["Gmail:Password"]!;
    }
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_smtpUsername),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        mailMessage.To.Add(new MailAddress(email));

        var smtpClient = new SmtpClient(_smtpServer, _smtpPort)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
            EnableSsl = true
        };

        return smtpClient.SendMailAsync(mailMessage);
    }
}