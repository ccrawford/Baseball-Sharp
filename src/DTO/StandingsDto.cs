using System;
using System.Collections.Generic;

namespace BaseballSharp.DTO.Standings
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Division
    {
        public int id { get; set; }
        public string? link { get; set; }
        public string? name { get; set; }
    }

    public class DivisionRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string? pct { get; set; }
        public Division? division { get; set; }
    }

    public class ExpectedRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string? type { get; set; }
        public string? pct { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public string? link { get; set; }
        public string? name { get; set; }
    }


    public class LeagueRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public string? pct { get; set; }
        public League? league { get; set; }
    }

    public class OverallRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string? type { get; set; }
        public string? pct { get; set; }
    }

    public class Record
    {
        public string? standingsType { get; set; }
        public League? league { get; set; }
        public Division? division { get; set; }
        public Sport? sport { get; set; }
        public DateTime lastUpdated { get; set; }
        public TeamRecord[] teamRecords { get; set; } = Array.Empty<TeamRecord>();
        public SplitRecord[] splitRecords { get; set; } = Array.Empty<SplitRecord>();
        public DivisionRecord[] divisionRecords { get; set; } = Array.Empty<DivisionRecord>();
        public OverallRecord[] overallRecords { get; set; } = Array.Empty<OverallRecord>();
        public LeagueRecord[] leagueRecords { get; set; } = Array.Empty<LeagueRecord>();
        public ExpectedRecord[] expectedRecords { get; set; } = Array.Empty<ExpectedRecord>();
    }

    public class StandingDto
    {
        public string? copyright { get; set; }
        public Record[] records { get; set; } = Array.Empty<Record>();
    }

    public class SplitRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string? type { get; set; }
        public string? pct { get; set; }
    }

    public class Sport
    {
        public int id { get; set; }
        public string? link { get; set; }
    }

    public class Streak
    {
        public string? streakType { get; set; }
        public int streakNumber { get; set; }
        public string? streakCode { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? link { get; set; }
    }

    public class TeamRecord
    {
        public Team? team { get; set; }
        public string? season { get; set; }
        public Streak? streak { get; set; }
        public string? divisionRank { get; set; }
        public string? leagueRank { get; set; }
        public string? sportRank { get; set; }
        public int gamesPlayed { get; set; }
        public string? gamesBack { get; set; }
        public string? wildCardGamesBack { get; set; }
        public string? leagueGamesBack { get; set; }
        public string? springLeagueGamesBack { get; set; }
        public string? sportGamesBack { get; set; }
        public string? divisionGamesBack { get; set; }
        public string? conferenceGamesBack { get; set; }
        public LeagueRecord? leagueRecord { get; set; }
        public DateTime? lastUpdated { get; set; }
        public Record? records { get; set; }
        public int runsAllowed { get; set; }
        public int runsScored { get; set; }
        public bool divisionChamp { get; set; }
        public bool divisionLeader { get; set; }
        public bool hasWildcard { get; set; }
        public bool clinched { get; set; }
        public string? eliminationNumber { get; set; }
        public string? wildCardEliminationNumber { get; set; }
        public string? magicNumber { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int runDifferential { get; set; }
        public string? winningPercentage { get; set; }
        public string? wildCardRank { get; set; }
        public bool? wildCardLeader { get; set; }
    }

}