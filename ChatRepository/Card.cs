using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRepository
{
    public class Card
    {
        [Key]
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int BoardId { get; set; }
        public DateTime UtcDeadline { get; set; }
    }
}
