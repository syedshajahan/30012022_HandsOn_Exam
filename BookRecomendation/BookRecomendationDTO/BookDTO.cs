using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecomendationDTO
{
    public class BookDTO
    {
        public int Book_ISBN { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
    }
}
