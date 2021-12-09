using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatRepository
{
    public class Board
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public long RootId { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}
