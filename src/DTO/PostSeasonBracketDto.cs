using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.DTO
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Away
    {
        public LeagueRecord leagueRecord { get; set; }
        public Team team { get; set; }
    }

    public class Game
    {
        public int gamePk { get; set; }
        public DateTime gameDate { get; set; }
        public Status status { get; set; }
        public Teams1 teams { get; set; }
        public string description { get; set; }
        public int gamesInSeries { get; set; }
        public int seriesGameNumber { get; set; }
        public string seriesDescription { get; set; }
    }

    public class Home
    {
        public LeagueRecord leagueRecord { get; set; }
        public Team team { get; set; }
    }

    public class LeagueRecord
    {
        public int wins { get; set; }
    }

    public class PostSeasonBracketDto
    {
        public int totalGames { get; set; }
        public List<Series> series { get; set; }
    }

    public class Series
    {
        public Series series { get; set; }
        public int totalGames { get; set; }
        public List<Game> games { get; set; }
        public string id { get; set; }
    }



    public class Team
    {
        public int id { get; set; }
    }

    public class Teams1
    {
        public Away away { get; set; }
        public Home home { get; set; }
    }
}
