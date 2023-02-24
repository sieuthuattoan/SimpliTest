using SympliDevelopment.Api.Services.Interfaces;

namespace SympliDevelopment.Api.Factories.Interfaces
{
    /// <summary>
    /// Because Search and Detection business for each search engines could be totally different
    /// that why we need to implement each search engine a SearchService and DetectionService
    /// Uses AbstractFactory to group SearchService and DetectionService for each Search Engine 
    /// </summary>
    public interface ISearchAbstractFactory
    {
        ISearchService CreateSearchService();
        IDetectionService CreateDetectionService();
    }
}