using BibleTreasure.Models;
using Microsoft.Extensions.Options;

namespace BibleTreasure.Repository
{
    public class TreasureService : ITreasure
    {
        private readonly TreasureUrl treasureUrl;
        public TreasureService(IOptions<TreasureUrl> treasureUrl)
        {
            this.treasureUrl = treasureUrl.Value;
        }
        public async Task GetTodayTreasure()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(treasureUrl.Uri),
                Headers =
    {
        { "X-RapidAPI-Key", treasureUrl.Key },
        { "X-RapidAPI-Host", treasureUrl.Host },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}
