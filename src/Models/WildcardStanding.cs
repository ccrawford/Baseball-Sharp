using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.Models
{
    public class WildcardStanding
    {
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public List<WildcardTeamStanding> Teams { get; set; }
    }

    public class WildcardTeamStanding
    {
        public int teamId { get; set; }
        public string? nameAbbr { get; set; }
        public string? wildCardRank { get; set; }
        public string? wildCardGamesBack { get; set; }
        public bool? clinched { get; set; }
        public string? magicNumber { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }

    }

}
