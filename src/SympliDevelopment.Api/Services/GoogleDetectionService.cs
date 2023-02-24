using Microsoft.Extensions.Options;
using SympliDevelopment.Api.Services.Interfaces;
using SympliDevelopment.Api.Services.Models;

namespace SympliDevelopment.Api.Services
{
    class GoogleDetectionService : IDetectionService
    {
        /// <summary>
        ///separator is html that bound each item from respondance of search services.
        ///4ex:"<div><div class=\"Gx5Zad fP1Qef xpd EtOod pkphOe\"><div class=\"egMi0 kCrYT\"><a href=\"/url?q="
        /// 
        ///Instead of hard code, move this to appsettings.json
        ///reason to do so is that the separator depends on the SearcEngine response's html layout. In the future google or bing may change there html layout
        ///hence in that circumstance the separator is not correct any more => by move it to appsettings.json we can reset it later.
        /// </summary>
        private readonly SeparatorOptions _separatorOptions;
        public GoogleDetectionService(IOptions<SeparatorOptions> separatorOptions)
        {
            _separatorOptions = separatorOptions.Value;
        }

        public SearchResponseModel GetTargetPosition(string raw, string searchingTarget)
        {
            var listItems = raw.Split(_separatorOptions.Google)?.Skip(1);

            if (listItems is null)
            {
                return new SearchResponseModel()
                {
                    Status = Status.SeparatorChanged.ToString()
                };
            }

            var result = string.Empty;

            //check index of target items in itemlist to build the string result 
            foreach (var item in listItems.Select((value, index) => new { index, value }))
            {
                if (item.value.StartsWith(searchingTarget))
                    result += $"{item.index + 1},";
            }

            return new SearchResponseModel()
            {
                Status = Status.OK.ToString(),
                Result = string.IsNullOrEmpty(result) ? "0" : result.Substring(0, result.Length - 1)
        }; 
        }
    }
}