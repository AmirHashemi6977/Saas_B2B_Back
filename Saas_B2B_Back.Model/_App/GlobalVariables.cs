
namespace FlowerShop.Model {
  public class GlobalVariables {
    public const string ExceptionSource = "Custom";
    public const string SystemGeneratedMessage = "SystemGeneratedMessage";
    public const string UnknownError = "خطای ناشناخته ای رخ داده است.";

    public static string[] ClientUnsafeKeywords = { "javascript", "vbscript", "script" };
    public static string[] SqlUnsafeKeywords = { "shutdown", "exec", "having", "union", "select", "insert", "update", "delete", "drop", "truncate", "script" };
  }
}
