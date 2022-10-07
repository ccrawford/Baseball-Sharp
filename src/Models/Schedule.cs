namespace BaseballSharp.Models;

public class Schedule
{
    public int? gameID { get; set; }
    public int? HomeID { get; set; }
    public int? AwayID { get; set; }
    public string? HomeTeam { get; set; }
    public string? AwayTeam { get; set; }

    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }

    public string? CodedGameState { get; set; }
    public string? StatusCode { get; set; }
    public string? DetailedState { get; set; }
    public string? Reason { get; set; }
    public string? AbstractGameCode { get; set; }

    public bool? IsHomeWinner
    {
        get 
        {
            if (HomeScore == null || AwayScore == null) return null;
            else return (HomeScore > AwayScore); 
        }
    }

    public string? HomeProbablePitcher { get; set; }
    public string? AwayProbablePitcher { get; set; }
    public string? WinningPitcher { get; set; }
    public string? LosingPitcher { get; set; }


    /// <summary>
    /// The stadium that the team is playing at.
    /// </summary>
    public string? Ballpark { get; set; }

    public string? DayNight { get; set; }

    public System.DateTime? GameTime { get; set; }

    public System.DateTime? OfficialDate { get; set; }

    /// <summary>
    /// The number of innings scheduled for the game. 
    /// </summary>
    public int? ScheduledInnings { get; set; }
}