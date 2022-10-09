using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.Models
{
    public class GameSummary
    {
        public int? gamePk { get; set; }
        public int? HomeId { get; set; }
        public int? AwayId { get; set; }

        public string? hPitcher { get; set; }
        public string? aPitcher { get; set; }
        public string? wPitcher { get; set; }
        public string? lPitcher { get; set; }

        public string? HomeAbbr { get; set; }
        public string? AwayAbbr { get; set; }

        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        public string? State { get; set; }

        public long? UnixTime { get; set; }

        public int Inning { get; set; }
        public bool IsTop { get; set; }

        public int Outs { get; set; }

        public bool On1 { get; set; }
        public bool On2 { get; set; }
        public bool On3 { get; set; }

    }

    public class PostSeasonGameSummary
    {
        public int? gamePk { get; set; }
        public int? HomeId { get; set; }
        public int? AwayId { get; set; }

        public string? HomeAbbr { get; set; }
        public string? AwayAbbr { get; set; }

        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        public string? State { get; set; }

        public long? UnixTime { get; set; }

        public int Inning { get; set; }
        public string? InningOrdinal { get; set; }
        public bool IsTop { get; set; }

        public string? SeriesName { get; set; }
        public int? HomeWins { get; set; }
        public int? AwayWins { get; set; }
        public string? WinnerAbbr { get; set; }

    }
}
