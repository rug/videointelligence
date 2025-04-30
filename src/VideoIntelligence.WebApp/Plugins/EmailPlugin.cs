using Azure;
using Azure.Communication.Email;
using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Reflection;

namespace VideoIntelligence.WebApp.Plugins
{
    /// <summary>
    /// A plugin for sending emails.
    /// </summary>
    public class EmailPlugin
    {
        private readonly string _connectionString;
        private readonly string _senderAddress;
        private readonly ILogger<EmailPlugin> _logger;
        public EmailPlugin(ILogger<EmailPlugin> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration["EmailCommunicationService:ConnectionString"] ?? "";
            _senderAddress = configuration["EmailCommunicationService:SenderAddress"] ?? "";
        }

        [KernelFunction]
        [Description(@"Send an email to recipients that are specified into parameter ""recipients"". 
            If recipients are more than one, concatenate all recipients using "";"".
            The subject of the email must be passed to the parameter ""subject"". If the user does not supply a subject for an email, then you must include the title of the video in the subject. 
            The body of the email to the parameter ""html"" for html content and ""plainText"" for simple content body without html. 
            The function returns ""true"" if the email has been successfully sent. Give a feedback to the user about the sent status")]
        public bool SendEmail(string recipients, string subject, string html, string plainText)
        {
            bool completed = false;
            try
            {
                if(!EmailParamIsValid(recipients, subject, html, plainText))
                {
                    return false;
                }

                // Transform the recipients string into a list of EmailAddress objects.
                var recipientList = new List<EmailAddress>();
                foreach (var item in recipients.Split(";", StringSplitOptions.RemoveEmptyEntries))
                {
                    recipientList.Add(new EmailAddress(item.Trim()));
                }

                var emailClient = new EmailClient(_connectionString);

                // Construct the email message
                var emailMessage = new EmailMessage(
                    senderAddress: _senderAddress,
                    content: new EmailContent(subject)
                    {
                        PlainText = plainText,
                        Html = html
                    },
                recipients: new EmailRecipients(recipientList));

                // Send the email and wait until it's completed
                EmailSendOperation emailSendOperation = emailClient.Send(
                    WaitUntil.Completed,
                    emailMessage);

                completed = emailSendOperation.HasValue && emailSendOperation.HasCompleted && emailSendOperation.Value.Status == EmailSendStatus.Succeeded;

            }
            catch (Exception ex)
            {
                _logger.LogError($"{MethodBase.GetCurrentMethod()} - Cannot send an email. Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return completed;
        }

        /// <summary>
        /// Validate Email Params
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="html"></param>
        /// <param name="plainText"></param>
        /// <returns></returns>
        private bool EmailParamIsValid(string recipients, string subject, string html, string plainText)
        {
            // Validate input arguments
            if (string.IsNullOrWhiteSpace(recipients))
            {
                _logger.LogWarning("No recipients provided for sending email.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(html) && string.IsNullOrWhiteSpace(plainText))
            {
                _logger.LogWarning("Either HTML or plain text content must be provided for email.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(subject))
            {
                _logger.LogWarning("No subject provided for sending email.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                _logger.LogError($"Configure EmailCommunicationService:ConnectionString");
                return false;
            }

            if (string.IsNullOrWhiteSpace(_senderAddress))
            {
                _logger.LogError($"Configure EmailCommunicationService:SenderAddress");
                return false;
            }

            return true;
        }
    }
}





