using Microsoft.AspNetCore.Mvc;
using SympliDevelopment.Api.Factories.Interfaces;
using SympliDevelopment.Api.Services;

namespace SympliDevelopment.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SearchController : ControllerBase
  {
        private readonly IEnumerable<ISearchAbstractFactory> _searchAbstractFactory;
        public SearchController(IEnumerable<ISearchAbstractFactory> searchAbstractFactory)
        {
            _searchAbstractFactory = searchAbstractFactory;
        }

        [HttpGet("keywords")]
        public async Task<IActionResult> GetResult([FromQuery] string keywords)
        {
            var googleSearchFactory = _searchAbstractFactory.First(a => a.GetType().Equals(typeof(GoogleFactory)));
            var googleSearch = googleSearchFactory.CreateSearchService();
            var googleDetection = googleSearchFactory.CreateDetectionService();

            if (string.IsNullOrEmpty(keywords)) return Ok("0");
            var rawStr = await googleSearch.SearchBy(keywords);

            var searchingTarget = "https://www.sympli.com.au";
            var result = googleDetection.GetTargetPosition(rawStr, searchingTarget);

            return new JsonResult(result);
        }
    }
}