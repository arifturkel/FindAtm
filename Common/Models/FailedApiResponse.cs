namespace Common.Models
{
    using System.Collections.Generic;

    public class FailedApiResponse<T>
    {
        private FailedApiResponse() { }

        private FailedApiResponse(IEnumerable<string> errors)
        {
            Succeeded = false;
            Errors = errors;
        }
        public bool Succeeded { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public static FailedApiResponse<T> Failure(IEnumerable<string> errors)
        {
            return new(errors);
        }
    }
}
