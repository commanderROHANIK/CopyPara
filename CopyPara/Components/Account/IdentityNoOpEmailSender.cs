using CopyPara.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CopyPara.Components.Account
{
    // Remove the "else if (EmailSender is IdentityNoOpEmailSender)" block from RegisterConfirmation.razor after updating with a real implementation.
    internal sealed class IdentityNoOpEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IEmailSender _emailSender;

        public IdentityNoOpEmailSender(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
            _emailSender.SendEmailAsync(email, "Welcome to RadiOptima - Confirmation of Registration",
                $"Dear Doctor,<br><br>Welcome to the RadiOptima community! We are delighted to have received your registration.<br><br>We extend our utmost respect for your noble commitment to treating cancer patients. Your expertise and dedication hold exceptional value in the lives of these patients.<br><br>Please confirm your registration by following this link: <a href='{confirmationLink}'>clicking here</a><br><br>Should you require any assistance in your professional endeavors or have any questions regarding our platform, please feel free to reach out to us.<br><br>Thank you for joining us and for your contribution to improving the quality of life for cancer patients.<br><br>Warm regards,<br>RadiOptima Team");

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
            _emailSender.SendEmailAsync(email, "Password Reset Request for Your RadiOptima Account",
                $"Dear Doctor,<br><br>We have received a request to reset the password associated with your RadiOptima account.<br><br>To reset your password, please click on the following link: <a href='{resetLink}'>clicking here</a><br><br>If you did not initiate this password reset request or have any concerns, please contact our support team immediately.<br><br>Thank you for choosing RadiOptima. Your security and privacy are of utmost importance to us.<br><br>Best regards,<br>RadiOptima Team");
      
        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
            _emailSender.SendEmailAsync(email, "Your Password Reset Code for RadiOptima",
                $"Dear Doctor,<br><br>As requested, here is your password reset code for your RadiOptima account: {resetCode}.<br><br>Please use this code to reset your password. Enter the code in the designated field when prompted during the password reset process.<br><br>If you did not request this code or have any concerns regarding your account security, please reach out to our support team immediately.<br><br>Thank you for being a part of RadiOptima. Your security is our priority.<br><br>Best regards,RadiOptima Team");
    }
}