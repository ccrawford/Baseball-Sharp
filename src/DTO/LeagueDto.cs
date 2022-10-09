using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseballSharp.DTO.LeagueStandings;

namespace BaseballSharp.DTO
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class NOTNEEDEDLeague // it's in LeagueStandings class

    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
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
        public Sport sport { get; set; }
        public int sortOrder { get; set; }
        public bool active { get; set; }
    }

    public class Leagues
    {
        public string copyright { get; set; }
        public List<League> leagues { get; set; }
    }

    public class NOTNEEDEDSeasonDateInfo
    {
        public string seasonId { get; set; }
        public string preSeasonStartDate { get; set; }
        public string preSeasonEndDate { get; set; }
        public string seasonStartDate { get; set; }
        public string springStartDate { get; set; }
        public string springEndDate { get; set; }
        public string regularSeasonStartDate { get; set; }
        public string lastDate1stHalf { get; set; }
        public string allStarDate { get; set; }
        public string firstDate2ndHalf { get; set; }
        public string regularSeasonEndDate { get; set; }
        public string postSeasonStartDate { get; set; }
        public string postSeasonEndDate { get; set; }
        public string seasonEndDate { get; set; }
        public string offseasonStartDate { get; set; }
        public string offSeasonEndDate { get; set; }
        public string seasonLevelGamedayType { get; set; }
        public string gameLevelGamedayType { get; set; }
        public double qualifierPlateAppearances { get; set; }
        public double qualifierOutsPitched { get; set; }
    }
}
