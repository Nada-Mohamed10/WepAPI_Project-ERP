namespace Project_ERP.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public List<string> Messages { get; set; } = new();
        public List<string>? Errors { get; set; } = null;
        public bool Succeeded { get; set; } = true;

        public ApiResponse() { }

        public ApiResponse(T data, List<string>? messages = null)
        {
            Data = data;
            Messages = messages ?? new List<string> { "OK" };
            Succeeded = true;
        }

        public ApiResponse(List<string> errors)
        {
            Errors = errors;
            Succeeded = false;
        }


    }
}
