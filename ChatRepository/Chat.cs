using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRepository
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }
        public bool Private { get; set; }
    }
}
