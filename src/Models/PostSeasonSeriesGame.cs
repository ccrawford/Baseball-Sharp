namespace BaseballSharp.Models
{
    public class PostSeasonSeriesGame
    {
        public string id { get; set; }
        public string homeAbbr { get; set; }   
        public string awayAbbr { get; set; }

        public string description { get; set; }

        public int totalGames { get; set; }
        
        public int awayId { get; set; }
        public int homeId { get; set; }
        
        public int awayWins { get; set; }
        public int homeWins { get; set; }

        public bool isOver { get; set; }
    }
}