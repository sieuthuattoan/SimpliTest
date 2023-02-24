namespace SympliDevelopment.Api.Services.Interfaces
{
    /// <summary>
    /// this interface is an abstraction for Search engines such as Bing.
    /// </summary>
    public interface ISearchService
    {
        Task<string> SearchBy(string keywords, int maxSearchItem=100);
    }
}