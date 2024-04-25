namespace PT.Application.Models.Responses
{
    public interface IResponse
    {
        int Status { get; set; }
        string Message { get; set; }
    }
}

