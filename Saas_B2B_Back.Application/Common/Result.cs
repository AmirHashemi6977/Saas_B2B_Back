

namespace Saas_B2B_Back.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public List<string> Errors { get; } = new();
        public T? Value { get; }

        private Result(bool isSuccess, T? value = default, List<string>? errors = null)
        {
            IsSuccess = isSuccess;
            Value = value;
            if (errors != null)
                Errors.AddRange(errors);
        }

        // متد موفقیت
        public static Result<T> Success(T value) => new(true, value);

        // متد شکست برای یک پیام خطا
        public static Result<T> Failure(string error) => new(false, default, new List<string> { error });

        // متد شکست برای چند پیام خطا
        public static Result<T> Failure(List<string> errors) => new(false, default, errors);
    }
}
