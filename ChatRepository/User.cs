using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Newtonsoft.Json.Serialization;

namespace ChatRepository
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string NickName { get; set; }
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Tokens> Tokens { get; set; }

    }
}
