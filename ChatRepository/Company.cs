using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatRepository
{
    public class Company
    {
        [Key]
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<User> Users { get; set; }
        [JsonProperty("boards")]
        public virtual List<Board> Boards { get; set; }
    }
}
