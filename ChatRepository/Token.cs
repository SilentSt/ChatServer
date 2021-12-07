using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRepository
{
    public class Tokens
    {
        [Key]
        public string Token { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
