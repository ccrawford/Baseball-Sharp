using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.DTO.LeagueStandings
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Division
    {
        public int id { get; set; }
        public string name { get; set; }
        public string season { get; set; }
        public string nameShort { get; set; }
        public string link { get; set; }
        public string abbreviation { get; set; }
        public League league { get; set; }
        public Sport sport { get; set; }
        public bool hasWildcard { get; set; }
        public int sortOrder { get; set; }
        public int numPlayoffTeams { get; set; }
        public bool active { get; set; }
    }

    public class DivisionRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string pct { get; set; }
        public Division division { get; set; }
    }

    public class ExpectedRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string type { get; set; }
        public string pct { get; set; }
    }

    public class League
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

    public class LeagueRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public string pct { get; set; }
    }

    public class LeagueRecord2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string pct { get; set; }
        public League league { get; set; }
    }

    public class OverallRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string type { get; set; }
        public string pct { get; set; }
    }

    public class Record
    {
        public string standingsType { get; set; }
        public League league { get; set; }
        public Division division { get; set; }
        public Sport sport { get; set; }
        public DateTime lastUpdated { get; set; }
        public List<TeamRecord> teamRecords { get; set; }
        public List<SplitRecord> splitRecords { get; set; }
        public List<DivisionRecord> divisionRecords { get; set; }
        public List<OverallRecord> overallRecords { get; set; }
        public List<LeagueRecord> leagueRecords { get; set; }
        public List<ExpectedRecord> expectedRecords { get; set; }
    }

    public class LeagueStandingsDto
    {
        public string copyright { get; set; }
        public List<Record> records { get; set; }
    }

    public class SeasonDateInfo
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

    public class SplitRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string type { get; set; }
        public string pct { get; set; }
    }

    public class Sport
    {
        public int id { get; set; }
        public string link { get; set; }
    }

    public class Streak
    {
        public string streakType { get; set; }
        public int streakNumber { get; set; }
        public string streakCode { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class TeamRecord
    {
        public Team team { get; set; }
        public string season { get; set; }
        public Streak streak { get; set; }
        public string divisionRank { get; set; }
        public string leagueRank { get; set; }
        public string sportRank { get; set; }
        public int gamesPlayed { get; set; }
        public string gamesBack { get; set; }
        public string wildCardGamesBack { get; set; }
        public string leagueGamesBack { get; set; }
        public string springLeagueGamesBack { get; set; }
        public string sportGamesBack { get; set; }
        public string divisionGamesBack { get; set; }
        public string conferenceGamesBack { get; set; }
        public LeagueRecord leagueRecord { get; set; }
        public DateTime lastUpdated { get; set; }
        public SplitRecord records { get; set; }
        public int runsAllowed { get; set; }
        public int runsScored { get; set; }
        public bool divisionChamp { get; set; }
        public bool divisionLeader { get; set; }
        public bool hasWildcard { get; set; }
        public bool clinched { get; set; }
        public string eliminationNumber { get; set; }
        public string wildCardEliminationNumber { get; set; }
        public string magicNumber { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int runDifferential { get; set; }
        public string winningPercentage { get; set; }
        public string wildCardRank { get; set; }
        public bool? wildCardLeader { get; set; }
    }


}

