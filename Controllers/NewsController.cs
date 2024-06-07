using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Controllers
{
    public class NewsController
    {
        public static async Task<List<NewsAPI.Models.Article>> Get()
        {
            var newsApiClient = new NewsApiClient("64da400ab97345e89903192b81a9b849");
            var req = new EverythingRequest
            {
                Sources = { "bbc-news" },
                SortBy = SortBys.Popularity,
                PageSize = 10
            };
            var articlesResponse = await newsApiClient.GetEverythingAsync(req).ConfigureAwait(true);
            Console.WriteLine("StatusCode: " + articlesResponse.Status);
            if (articlesResponse.Status == Statuses.Ok)
            {
                foreach (var item in articlesResponse.Articles)
                {
                    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(item));
                }
                return articlesResponse.Articles;
            }
            return null;
        }

        public static async Task<string> GetList()
        {
            string uri = "https://newsapi.org/v2/everything?pageSize=10&apiKey=64da400ab97345e89903192b81a9b849";
            HttpClient http = new HttpClient();
            var result = await http.GetAsync(uri).ConfigureAwait(true);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync().ConfigureAwait(true);
                Console.WriteLine("content: " + content);
                var data = JsonConvert.DeserializeObject<Article>(content);
                return content;
            }
            return null;
        }
    }
}
