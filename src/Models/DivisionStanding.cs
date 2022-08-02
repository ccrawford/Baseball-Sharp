using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.Models
{
    public class DivisionStanding
    {
        public int DivisionId { get; set; }
        public int LeagueId { get; set; }
        public string DivisionName { get; set; }
        public string DivisionAbbr { get; set; }
        public string LeagueName { get; set; }
        public List<Standing> Teams { get; set; }
    }
}
