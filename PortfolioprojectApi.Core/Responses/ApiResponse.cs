using System.Net;

namespace PortfolioProject.core.Responses
{
    public class ApiResponse<T>
    {
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public HttpStatusCode StatusCode { get; set; }

        public static ApiResponse<T> Success(T data, string message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = new ApiResponse<T>
            {
                Succeeded = true,
                Data = data,
                StatusCode = statusCode
            };
            if (message != null) response.Messages.Add(message);
            return response;
        }

        public static ApiResponse<T> Failure(IEnumerable<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>
            {
                Succeeded = false,
                Messages = errors.ToList(),
                StatusCode = statusCode
            };
        }
        public static ApiResponse<T> Failure(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>
            {
                Succeeded = false,
                Messages = new List<string> { error },
                StatusCode = statusCode
            };
        }
    }
}
