using SympliDevelopment.Api.Services.Interfaces;
using SympliDevelopment.Api.Services.Models;

namespace SympliDevelopment.Api.Services
{
    class BingDetectionService : IDetectionService
    {
        public SearchResponseModel GetTargetPosition(string raw, string searchingTarget)
        {
            return new SearchResponseModel()
            {
                Status = Status.UnAvailable.ToString(),
                Result = "this serive is in development, pair with BingSearchService... pls wait"
            };
        }
    }
}