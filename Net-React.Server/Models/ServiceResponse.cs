
namespace Net_React.Server.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public string ErrorMessage { get; set; }
        public ServiceResponse()
        {
            IsSuccess = true;
        }
    }
}
