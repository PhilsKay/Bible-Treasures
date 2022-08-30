using System.Text.Json.Serialization;

namespace BibleTreasure.Models
{
    public class TreasureData
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("scriptures")]
        public List<string> Scriptures { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("topics")]
        public List<object> Topics { get; set; }

        [JsonPropertyName("bookOrder")]
        public int BookOrder { get; set; }
    }
    public class Treasures
    {
        [JsonPropertyName("results")]
        public List<TreasureData> Results { get; set; }
    }
}
