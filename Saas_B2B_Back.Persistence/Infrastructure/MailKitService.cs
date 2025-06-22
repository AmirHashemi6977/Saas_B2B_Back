using Saas_B2B_Back.Application.Base;
using Saas_B2B_Back.Application.Common;
using MailKit.Net.Smtp;
using MimeKit;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Persistence.Infrastructure {
    public class MailKitService : IEmailService
    {
        // #region ctor
        //private readonly AppSetting _appSetting;

        //public MailKitService(
        //    AppSetting appSetting) {

        //  _appSetting = appSetting;
        //}
        //#endregion

        //public async Task<IServiceResult> SendAsync(EmailModel email) {
        //  var message = new MimeMessage();

        //  var from = new MailboxAddress("MailboxName", _appSetting.SmtpConfig.Host);
        //  message.From.Add(from);

        //  var to = new MailboxAddress("MailboxName", email.Address);
        //  message.To.Add(to);


        //  var bodyBuilder = new BodyBuilder();
        //  if(email.IsBodyHtml)
        //    bodyBuilder.HtmlBody = email.Body;
        //  else
        //    bodyBuilder.TextBody = email.Body;
        //  bodyBuilder.Attachments.Add(email.AttachmentPath);

        //  message.Subject = email.Subject;
        //  message.Body = bodyBuilder.ToMessageBody();

        //  var client = new SmtpClient();
        //  client.Connect(_appSetting.SmtpConfig.Address, _appSetting.SmtpConfig.Port, true);
        //  client.Authenticate(_appSetting.SmtpConfig.Username, _appSetting.SmtpConfig.Password);

        //  await client.SendAsync(message);
        //  await client.DisconnectAsync(true);
        //  client.Dispose();

        //  return DataTransferer.Ok();
        public Task<IServiceResult> SendAsync(EmailModel email)
        {
            throw new NotImplementedException();
        }
    }
}
