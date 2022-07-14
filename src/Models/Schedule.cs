namespace BaseballSharp.Models;

public class Schedule
{
    public int? gameID { get; set; }
    public string? HomeTeam { get; set; }
    public string? AwayTeam { get; set; }

    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }

    public string? CodedGameState { get; set; }

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


    /// <summary>
    /// The stadium that the team is playing at.
    /// </summary>
    public string? Ballpark { get; set; }

    public string? DayNight { get; set; }

    public System.DateTime? GameTime { get; set; }

    /// <summary>
    /// The number of innings scheduled for the game. 
    /// </summary>
    public int? ScheduledInnings { get; set; }
}