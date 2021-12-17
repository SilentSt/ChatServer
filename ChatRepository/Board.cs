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
    public class Board
    {
        [Key]
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("companyid")]
        public long? CompanyId { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
        [JsonProperty("userid")]
        public int? UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonProperty("cards")]
        public virtual List<Card> Cards { get; set; }
    }
}
