using Saas_B2B_Back.Application.Base;
using Saas_B2B_Back.Application.Common;
using Serilog;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Persistence.Infrastructure
{
    public class EmailService : Persistence.IEmailService
    {
        #region ctor
        private readonly AppSetting _appSetting;

        public EmailService(
            AppSetting appSetting)
        {

            _appSetting = appSetting;
        }
        #endregion

        public async Task<IServiceResult> SendAsync(EmailModel email)
        {
            //    try
            //    {
            //        if (string.IsNullOrWhiteSpace(email.Address) || string.IsNullOrWhiteSpace(email.Subject) ||
            //            string.IsNullOrWhiteSpace(email.Body))
            //        {
            //            return Application.Common.DataTransferer.DefectiveEntry();
            //        }

            //        var mail = new MailMessage()
            //        {
            //            From = new MailAddress(_appSetting.SmtpConfig.Address),
            //            Subject = email.Subject,
            //            Body = email.Body,
            //            IsBodyHtml = email.IsBodyHtml,
            //            Priority = MailPriority.High
            //        };
            //        mail.To.Add(new MailAddress(email.Address));
            //        if (!string.IsNullOrWhiteSpace(email.AttachmentPath) && File.Exists(email.AttachmentPath))
            //            mail.Attachments.Add(new Attachment(email.AttachmentPath));

            //        using (var smtp = new SmtpClient(_appSetting.SmtpConfig.Host, _appSetting.SmtpConfig.Port))
            //        {
            //            smtp.UseDefaultCredentials = false;
            //            smtp.Credentials = new NetworkCredential(_appSetting.SmtpConfig.Username, _appSetting.SmtpConfig.Password);
            //            smtp.EnableSsl = true;
            //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //            await smtp.SendMailAsync(mail);
            //        }

            //        return Ok();
            //    }
            //    catch (Exception ex)
            //    {
            //        Log.Error(ex, ex.Source);
            //        return DataTransferer.InternalServerError();
            //    }
            //}
            return null;
        }
    }
}
