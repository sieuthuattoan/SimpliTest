using SympliDevelopment.Api.Factories.Interfaces;
using SympliDevelopment.Api.Services.Interfaces;

namespace SympliDevelopment.Api.Services
{
    class GoogleFactory : ISearchAbstractFactory
    {
        private readonly IEnumerable<ISearchService> _searchService;
        private readonly IEnumerable<IDetectionService> _detectionService;
        public GoogleFactory(IEnumerable<ISearchService> searchService, IEnumerable<IDetectionService> detectionService)
        {
            _searchService = searchService;
            _detectionService = detectionService;
        }
        public IDetectionService CreateDetectionService() => _detectionService.First(a => a.GetType().Equals(typeof(GoogleDetectionService)));

        public ISearchService CreateSearchService() => _searchService.First(a => a.GetType().Equals(typeof(GoogleSearchService)));
    }
}