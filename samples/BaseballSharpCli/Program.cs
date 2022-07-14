using BaseballSharp;
using System;
using BaseballSharp.Enums;
using System.Threading.Tasks;

namespace MLBSharpCli
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var mlbClient = new MLBClient();

            var teamsList = await mlbClient.GetTeamDataAsync();

            var upcomingGames = await mlbClient.GetScheduleAsync(DateTime.Now);

            bool soxPlay= false; 
            int soxGameId =0;
            foreach (var game in upcomingGames)
            {
//                 Console.WriteLine($"{game.AwayTeam} vs {game.HomeTeam} at {game.Ballpark}");
                if (game.AwayTeam == "Chicago White Sox" || game.HomeTeam == "Chicago White Sox" )
                {
                    string opponentShort = "???";

                    DateTime gameStart = DateTime.Parse(game.GameTime.ToString()).ToLocalTime();
                    if (game.HomeTeam == "Chicago White Sox")
                    {
                        foreach (var team in teamsList) { if (team.Name == game.AwayTeam) { opponentShort = team.Abbreviation; } }
                        Console.WriteLine($"{opponentShort} at SOX {gameStart.ToString("h:mm")}");
                    }
                    else
                    {
                        foreach (var team in teamsList) { if (team.Name == game.HomeTeam) { opponentShort = team.Abbreviation; } }
                        Console.WriteLine($"SOX at {opponentShort} at {gameStart.ToString("h:mm")}");
                    }
                    Console.WriteLine($"GameId: {game.gameID}");
                    soxGameId = game.gameID ?? 0;
                    soxPlay=true;
                }
            }
            if (!soxPlay)
            {
                Console.WriteLine("Sox off.");
            }

            /*
            var pitching = await mlbClient.GetPitchingReportsAsync(DateTime.Now);

            foreach (var pitcher in pitching)
            {
                Console.WriteLine($"Home pitcher: {pitcher.HomeProbablePitcherName}, Notes: {pitcher.HomeProbablePitcherNotes}");
            }
            */

            

            foreach (var team in teamsList)
            {
 //               Console.WriteLine($"{team.Name}, ({team.Abbreviation}),  {team.Id}");
            }

            // Example of casting the team ids enum to int in the parameter.
            /*
            var teamRoster = await mlbClient.GetTeamRosterAsync((int)eTeamId.BlueJays, 2021, DateTime.Now, rosterType.rosterFull);

            foreach (var team in teamRoster)
            {
                Console.WriteLine($"{team.PlayerFullName}, {team.PlayerPosition}, {team.StatusCode}");
            }
            */

            // Display some basic data from the LineScore endpoint.
            var lineScore = await mlbClient.GetLineScoreAsync(soxGameId);

            Console.Write("Inning: ");
            foreach (var inning in lineScore)
            {
            //    Console.WriteLine($"Inning: {inning.InningNumber},  Home: {inning.HometeamRuns}, Away: {inning.AwayteamRuns}");
                Console.Write($"{inning.InningNumber} ");
            }
            Console.WriteLine();

            Console.Write("  Home: ");
            foreach (var inning in lineScore)
            {
                Console.Write($"{inning.HometeamRuns} ");
            }
            Console.WriteLine();

            Console.Write("  Away: ");
            foreach (var inning in lineScore)
            {
                Console.Write($"{inning.AwayteamRuns} ");
            }
            Console.WriteLine();

            // Get a team's depth chart
            /*
            var depthChart = await mlbClient.GetDepthChartAsync(111);

            foreach (var person in depthChart)
            {
                Console.WriteLine($"Name: {person.PlayerFullName}, position: {person.PositionName}");
            }

            // Get a list of divisions
            var divisions = await mlbClient.GetDivisionsAsync();

            foreach (var division in divisions)
            {
                Console.WriteLine($"Division name: {division.DivisionName}, Division ID: {division.DivisionId}");
            }
            */
        }
    }
}