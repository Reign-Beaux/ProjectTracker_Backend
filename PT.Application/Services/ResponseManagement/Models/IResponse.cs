namespace PT.Application.Services.ResponseManagement.Models
{
    public interface IResponse
    {
        int Status { get; set; }
        string? Message { get; set; }
    }
}
