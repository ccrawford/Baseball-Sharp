using BaseballSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/lastBox", () =>
{
    var todayBox = Enumerable.Range(1, 1).Select(index =>
        new LastBox(DateTime.Today, "Chicago White Sox")
    ).ToArray();
    
    return todayBox;
})
.WithName("GetLastBox");

app.MapGet("/display", () =>
{
    string line1 = getFirstLine().Result;
    string line2 = "";
    string line3 = getAwayLineScore(false, 662883).Result;
    string line4 = getAwayLineScore(true, 662883).Result;

    var disp = new RawDisplayDTO(line1, line2, line3, line4);
    return disp;
}
).WithName("GetDisplay");

async Task<string> getFirstLine()
{
    MLBClient mlbClient = new MLBClient();

    var teamsList = await mlbClient.GetTeamDataAsync();

    var upcomingGames = await mlbClient.GetScheduleAsync(DateTime.Now);

    bool soxPlay = false;
    int soxGameId = 0;

    string line1 = "";

    foreach (var game in upcomingGames)
    {
        //                 Console.WriteLine($"{game.AwayTeam} vs {game.HomeTeam} at {game.Ballpark}");
        if (game.AwayTeam == "Chicago White Sox" || game.HomeTeam == "Chicago White Sox")
        {
            string opponentShort = "???";

            DateTime gameStart = DateTime.Parse(game.GameTime.ToString()).ToLocalTime();
            if (game.HomeTeam == "Chicago White Sox")
            {
                foreach (var team in teamsList) { if (team.Name == game.AwayTeam) { opponentShort = team.Abbreviation; } }
                // Console.WriteLine($"{opponentShort} at SOX {gameStart.ToString("h:mm")}");
                line1 = ($"{opponentShort} @ SOX {gameStart.ToString("h:mm")}");
            }
            else
            {
                foreach (var team in teamsList) { if (team.Name == game.HomeTeam) { opponentShort = team.Abbreviation; } }
                // Console.WriteLine($"SOX at {opponentShort} {gameStart.ToString("h:mm")}");
                line1 = ($"SOX @ {opponentShort} {gameStart.ToString("h:mm")}");
            }
            Console.WriteLine($"GameId: {game.gameID}");

            soxGameId = game.gameID ?? 0;
            soxPlay = true;
        }
    }
    if (!soxPlay)
    {
        line1 = "Sox off";
    }
    return line1;
}

async Task<string> getAwayLineScore(bool home, int id)
{
    MLBClient mlbClient = new MLBClient();
    string retString = "";

    var lineScore = await mlbClient.GetLineScoreAsync(id);

    if (home)
    {
        retString += "DET ";
        foreach (var inning in lineScore)
        {
            retString += ($"{inning.HometeamRuns}");
        }
    }
    else
    {
        retString += "CWS ";
        foreach (var inning in lineScore)
        {

            retString += ($"{inning.AwayteamRuns}");
        }
    }
    return retString;
}

app.Run();

internal record LastBox(DateTime Date, String TeamName)
{
    public string awayString = "000202001";
    public string homeString = "102203000";
}


public class RawDisplayDTO
{
    public string? line1 { get; set; }
    public string? line2 { get; set; }

    public string? line3 { get; set; }
    public string? line4 { get; set; }

    public RawDisplayDTO()
    {

    }

    public RawDisplayDTO(string Line1, string Line2, string Line3, string Line4)
    {
        (line1, line2, line3, line4) = (Line1, Line2, Line3, Line4);
    }
}
