using SympliDevelopment.Api.Services.Models;

namespace SympliDevelopment.Api.Services.Interfaces
{
    /// <summary>
    /// this interface is an abstraction for detection service.
    /// Because we will have several Search Engine, each search engine return to differences layout of HTML
    /// Therefore for each SearchEngine we will have difference compartible Detection Service.
    /// 
    /// Why don't we merge this into SearchService?
    /// - SearchService is definitive name, should only for Searching purpose. We toss keyword and SearchService and it return us the data from the internet.
    /// - DetectionService doesn't have to work as a subset of Searching. 
    ///     We could use it for several purposes, just tossing a raw string and its will detect things for us no matter where the raw string come from.
    /// </summary>
    public interface IDetectionService
    {
        SearchResponseModel GetTargetPosition(string raw, string searchingTarget);
    }
}