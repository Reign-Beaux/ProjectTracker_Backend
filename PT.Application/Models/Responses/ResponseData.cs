namespace PT.Application.Models.Responses
{
    public class ResponseData<T> : Response where T : new()
    {
        public T Data { get; set; } = new T();
    }
}
