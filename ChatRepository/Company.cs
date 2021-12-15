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
        public long Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<User> Users { get; set; }
        public virtual List<Board> Boards { get; set; }
    }
}
