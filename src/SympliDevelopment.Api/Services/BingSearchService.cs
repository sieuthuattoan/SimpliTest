using SympliDevelopment.Api.Services.Interfaces;

namespace SympliDevelopment.Api.Services
{
    class BingSearchService : ISearchService
    {
        public async Task<string> SearchBy(string keywords, int maxSearchItem = 100)
        {
            return "this search engine is not available for now";
        }
    }
}