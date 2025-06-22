namespace Saas_B2B_Back.Application.Common {
  public class EmailModel {
    public string Address { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public bool IsBodyHtml { get; set; }
    public string AttachmentPath { get; set; }
  }
}
