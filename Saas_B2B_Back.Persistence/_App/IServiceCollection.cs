
using Saas_B2B_Back.Application.Base;
using Saas_B2B_Back.Application.Common;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Persistence {
  public interface ISMSService {
    Task<IServiceResult> SendAsync(SMSModel email);
  }

  public interface IEmailService {
    Task<IServiceResult> SendAsync(EmailModel email);
  }
}
