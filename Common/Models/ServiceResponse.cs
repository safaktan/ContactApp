namespace Common.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }


        public ServiceResponse(bool isSuccess, string message, T data = default)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public static ServiceResponse<T> Success(T data)
        {
            return new ServiceResponse<T>(true, null, data);
        }

        public static ServiceResponse<T> Failure(string message)
        {
            return new ServiceResponse<T>(false, message);
        }
    }
}