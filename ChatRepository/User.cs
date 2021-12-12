﻿using System;
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
        public string Login { get; set; }
        public string Password { get; set; }
        public long CompanyId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual Company Company { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Tokens> Tokens { get; set; }

    }
}
