using FluentValidation.Results;

namespace StockTracker.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Bir veya daha fazla doğrulama hatası oluştu")
        {
        }

        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }


    }
}
