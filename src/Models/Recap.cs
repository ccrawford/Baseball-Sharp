using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.Models
{
    public class Recap
    {
        public int gameId { get; set; }
        public string headline{ get; set; }

        public string seoTitle { get; set; }

        public string blurb { get; set; }
    }
}
