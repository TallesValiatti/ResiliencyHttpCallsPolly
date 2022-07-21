namespace ResiliencyHttpCallsPolly.Models
{
    public class ServiceResult<T>
    {
        public bool Sucess { get; private set; }
        public string? Message { get; private set; }
        public T? Result { get; private set; }

        public ServiceResult(bool sucess, string? message, T? result)
        {
            this.Sucess = sucess;
            this.Result = result;
            this.Message = message;
        }
    }
}