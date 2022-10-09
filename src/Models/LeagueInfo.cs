using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.Models
{
    public class LeagueInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string nameShort { get; set; }
        public string seasonState { get; set; }
        public bool hasWildCard { get; set; }
        public bool hasSplitSeason { get; set; }
        public int numGames { get; set; }
        public bool hasPlayoffPoints { get; set; }
        public int numTeams { get; set; }
        public int numWildcardTeams { get; set; }
        public SeasonDateInfo seasonDateInfo { get; set; }
        public string season { get; set; }
        public string orgCode { get; set; }
        public bool conferencesInUse { get; set; }
        public bool divisionsInUse { get; set; }
        public int sortOrder { get; set; }
        public bool active { get; set; }
    }

    public class SeasonDateInfo
    {
        public string seasonId { get; set; }
        public long preSeasonStartDate { get; set; }
        public long preSeasonEndDate { get; set; }
        public long seasonStartDate { get; set; }
        public long springStartDate { get; set; }
        public long springEndDate { get; set; }
        public long regularSeasonStartDate { get; set; }
        public long lastDate1stHalf { get; set; }
        public long allStarDate { get; set; }
        public long firstDate2ndHalf { get; set; }
        public long regularSeasonEndDate { get; set; }
        public long postSeasonStartDate { get; set; }
        public long postSeasonEndDate { get; set; }
        public long seasonEndDate { get; set; }
        public long offseasonStartDate { get; set; }
        public long offSeasonEndDate { get; set; }
        public string seasonState { get; set; }
        public string seasonYear { get; set; } // The year
    }



}
