namespace SympliDevelopment.Api.Services.Models
{
    public class SearchResponseModel
    {
        public string? Status { get; set; }
        public string? Result { get; set; }
    }

    public enum Status
    {
        OK,
        SeparatorChanged,
        UnAvailable,
    }
}