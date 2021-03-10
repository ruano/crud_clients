namespace Domain.Services.Responses
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            Success = true;
        }

        public ServiceResponse(T resource)
        {
            Success = true;
            Resource = resource;
        }

        public ServiceResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }
    }
}