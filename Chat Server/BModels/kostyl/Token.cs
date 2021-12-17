using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Server.BModels.kostyl
{
    public class Token
    {
        public string token { get; set; }
        public override string ToString()
        {
            return token;
        }
    }
}
