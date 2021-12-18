using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatRepository
{
    public class Message
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("fromid")]
        public int FromId { get; set; }
        [Required]
        [JsonProperty("chatid")]
        public int ChatId { get; set; }
        [Required]
        [JsonProperty("text")]
        public string Text { get; set; }
        [Required]
        [JsonProperty("utctime")]
        public DateTime UtcTime { get; set; }
        [JsonProperty("reply")]
        public string? Reply { get; set; }
    }
}
