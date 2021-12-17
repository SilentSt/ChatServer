using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatRepository
{
    public class Card
    {
        [Key]
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("boardid")]
        public long BoardId { get; set; }
        [JsonProperty("deadline")]
        public DateTime Deadline { get; set; }
    }
}
