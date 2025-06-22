using FlowerShop.Model.Base;
using FlowerShop.Model.Common;
using System.Threading.Tasks;

namespace FlowerShop.Utility {
  public interface ISMSService {
    Task<IServiceResult> SendAsync(SMSModel email);
  }

  public interface IEmailService {
    Task<IServiceResult> SendAsync(EmailModel email);
  }
}
