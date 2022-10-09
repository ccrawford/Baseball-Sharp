using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.DTO.GameSummary
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // For use with: https://statsapi.mlb.com/api/v1/schedule?sportId=1&scheduleType=1&date=2022-08-01&hydrate=linescore

    public class PlayingTeams
    {
        public LeagueRecord leagueRecord { get; set; }
        public int score { get; set; }
        public Team team { get; set; }
        public bool isWinner { get; set; }
        public Pitcher? probablePitcher { get; set; }
        public bool splitSquad { get; set; }
        public int seriesNumber { get; set; }
        public int runs { get; set; }
        public int hits { get; set; }
        public int errors { get; set; }
        public int leftOnBase { get; set; }
    }

    public class Batter
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Catcher
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Center
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Content
    {
        public string link { get; set; }
    }

    public class Date
    {
        public string date { get; set; }
        public int totalItems { get; set; }
        public int totalEvents { get; set; }
        public int totalGames { get; set; }
        public int totalGamesInProgress { get; set; }
        public List<Game> games { get; set; }
        public List<object> events { get; set; }
    }

    public class Decisions
    {
        public Pitcher winner { get; set; }
        public Pitcher loser { get; set; }
        public Pitcher save { get; set; }
    }

    public class Defense
    {
        public Pitcher pitcher { get; set; }
        public Catcher catcher { get; set; }
        public First first { get; set; }
        public Second second { get; set; }
        public Third third { get; set; }
        public Shortstop shortstop { get; set; }
        public Left left { get; set; }
        public Center center { get; set; }
        public Right right { get; set; }
        public Batter batter { get; set; }
        public OnDeck onDeck { get; set; }
        public InHole inHole { get; set; }
        public int battingOrder { get; set; }
        public Team team { get; set; }
    }

    public class First
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Game
    {
        public int gamePk { get; set; }
        public string link { get; set; }
        public string gameType { get; set; }
        public string season { get; set; }
        public DateTime gameDate { get; set; }
        public string officialDate { get; set; }
        public Status status { get; set; }
        public Teams teams { get; set; }
        public Linescore? linescore { get; set; }
        public Decisions? decisions { get; set; }
        public Venue venue { get; set; }
        public Content content { get; set; }
        public bool isTie { get; set; }
        public int gameNumber { get; set; }
        public bool publicFacing { get; set; }
        public string doubleHeader { get; set; }
        public string gamedayType { get; set; }
        public string tiebreaker { get; set; }
        public string calendarEventID { get; set; }
        public string seasonDisplay { get; set; }
        public string dayNight { get; set; }
        public int scheduledInnings { get; set; }
        public bool reverseHomeAwayStatus { get; set; }
        public int inningBreakLength { get; set; }
        public int gamesInSeries { get; set; }
        public int seriesGameNumber { get; set; }
        public string seriesDescription { get; set; }
        public string? description { get; set; }  //used during post season.
        public string recordSource { get; set; }
        public string ifNecessary { get; set; }
        public string ifNecessaryDescription { get; set; }
    }


    //public class Home
    //{
    //    public LeagueRecord leagueRecord { get; set; }
    //    public int score { get; set; }
    //    public Team team { get; set; }
    //    public bool isWinner { get; set; }
    //    public bool splitSquad { get; set; }
    //    public int seriesNumber { get; set; }
    //    public int runs { get; set; }
    //    public int hits { get; set; }
    //    public int errors { get; set; }
    //    public int leftOnBase { get; set; }
    //}
    public class InHole
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Inning
    {
        public int num { get; set; }
        public string ordinalNum { get; set; }
        public PlayingTeams home { get; set; }
        public PlayingTeams away { get; set; }
    }

    public class LeagueRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public string pct { get; set; }
    }

    public class Left
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }
    
    public class Linescore
    {
        public int currentInning { get; set; }
        public string currentInningOrdinal { get; set; }
        public string inningState { get; set; }
        public string inningHalf { get; set; }
        public bool isTopInning { get; set; }
        public int scheduledInnings { get; set; }
        public List<Inning> innings { get; set; }
        public Teams teams { get; set; }
        public Defense defense { get; set; }
        public Offense offense { get; set; }
        public int balls { get; set; }
        public int strikes { get; set; }
        public int outs { get; set; }
        public string note { get; set; }
    }
    
    public class Offense
    {
        public Batter batter { get; set; }
        public OnDeck onDeck { get; set; }
        public InHole inHole { get; set; }
        public Pitcher pitcher { get; set; }
        public int battingOrder { get; set; }
        public Team team { get; set; }
        public First first { get; set; }
        public Second second { get; set; }
        public Third third { get; set; }
    }
    

    public class OnDeck
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Pitcher
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Right
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class AllGameSummaryDto
    {
        public string copyright { get; set; }
        public int totalItems { get; set; }
        public int totalEvents { get; set; }
        public int totalGames { get; set; }
        public int totalGamesInProgress { get; set; }
        public List<Date> dates { get; set; }
    }

    public class Second
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Shortstop
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }
    
    public class Status
    {
        public string abstractGameState { get; set; }
        public string codedGameState { get; set; }
        public string detailedState { get; set; }
        public string statusCode { get; set; }
        public bool startTimeTBD { get; set; }
        public string abstractGameCode { get; set; }
    }
    
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }
    
    public class Teams
    {
        public PlayingTeams away { get; set; }
        public PlayingTeams home { get; set; }
    }
    
    
    public class Third
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public class Venue
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }


}

