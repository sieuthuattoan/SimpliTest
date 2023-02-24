using Microsoft.Extensions.Caching.Memory;
using SympliDevelopment.Api.Services.Interfaces;

namespace SympliDevelopment.Api.Services
{
    class GoogleSearchService : ISearchService
    {
        private const string SearchUri = "https://google.com.au/search";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _memoryCache;
        public GoogleSearchService(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
        }

        public async Task<string> SearchBy(string keywords, int maxSearchItem = 100)
        {
            var cacheKey = $"{nameof(GoogleSearchService.SearchBy)}-{keywords}-{maxSearchItem}-cachekey";

            if (!_memoryCache.TryGetValue(cacheKey, out string result))
            {

                string searchUrl = $"{SearchUri}?q={keywords}&num={maxSearchItem}";
                var client = _httpClientFactory.CreateClient();
                result = await client.GetStringAsync(searchUrl);

                //cache for 1 hour
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
                _memoryCache.Set(cacheKey, result, cacheEntryOptions);
            }

            return result;
        }
    }
}