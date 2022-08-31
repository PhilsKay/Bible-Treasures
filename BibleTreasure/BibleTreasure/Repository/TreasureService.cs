using BibleTreasure.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BibleTreasure.Repository
{
    public class TreasureService : ITreasure
    {
        private readonly TreasureUrl treasureUrl;
        public TreasureService(IOptions<TreasureUrl> treasureUrl)
        {
            this.treasureUrl = treasureUrl.Value;
        }
        public async Task<Treasures> GetTodayTreasure()
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
            try
            {
                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Treasures>(body);
                    }
                    else
                    {
                        return new Treasures()
                        {
                            Results = new List<TreasureData>()
                        };
                    }
                }
            }
            catch (System.AggregateException ag)
            {
                throw new Exception(ag.Message);    
            }catch(HttpRequestException ht)
            {
                throw new Exception(ht.Message);
            }
            
        }
    }
}
