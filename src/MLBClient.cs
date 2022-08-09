using BaseballSharp.DTO;
using BaseballSharp.DTO.GameSchedule;
using BaseballSharp.DTO.Linescore;
using BaseballSharp.DTO.PitchingReport;
using BaseballSharp.DTO.Teams;
using BaseballSharp.DTO.Standings;
using BaseballSharp.DTO.LeagueStandings;
using BaseballSharp.Enums;
using BaseballSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Team = BaseballSharp.DTO.Teams.Team;

namespace BaseballSharp
{
    /// <summary>
    /// The MLBClient class holds all MLB Stats API endpoints that can be accessed from Baseball Sharp.
    /// </summary>
    public class MLBClient : IMLBClient
    {
        private static HttpClient _httpClient = new HttpClient();
        private static readonly string _baseUrl = "https://statsapi.mlb.com/api/v1";

        private async Task<string> GetResponseAsync(string endpoint)
        {

            var returnMessage = await _httpClient.GetAsync(_baseUrl + (endpoint ?? "")).ConfigureAwait(false);

            return await returnMessage.Content.ReadAsStringAsync();
        }


        /// <summary>
        /// Returns the next five games for a specified team.
        /// </summary>
        /// <param teamId="int">The id of the team of interest</param>
        /// <returns>A list of schedule objects.</returns>
        public async Task<IEnumerable<Schedule>> GetNextScheduleAsync(int teamId)
        {
            var upcomingGames = new List<Schedule>();

            var jsonResponse = await GetResponseAsync("/teams/" + teamId + "?sportIds=1&hydrate=nextSchedule");
            var mlbTeams = JsonSerializer.Deserialize<TeamDto>(jsonResponse);

            foreach (var team in (mlbTeams ?? new TeamDto()).teams)
            {
                foreach (var item in (team?.nextGameSchedule?.dates ?? new GameScheduleRoot().dates))
                {

                    foreach (var game in item.games)
                    {

                        upcomingGames.Add(new Models.Schedule()
                        {
                            gameID = game?.gamePk,
                            AwayTeam = game?.teams?.away?.team?.name,
                            HomeTeam = game?.teams?.home?.team?.name,
                            Ballpark = game?.venue?.name,
                            ScheduledInnings = game?.scheduledInnings,
                            CodedGameState = game?.status?.codedGameState,
                            DayNight = game?.dayNight,
                            GameTime = game?.gameDate,
                        });

                    }
                }
            }

            return upcomingGames;
        }

        /// <summary>
        /// Returns the previous five games for a specified team.
        /// </summary>
        /// <param teamId="int">The id of the team of interest</param>
        /// <returns>A list of schedule objects.</returns>
        public async Task<IEnumerable<Schedule>> GetPreviousScheduleAsync(int teamId)
        {
            var previousGames = new List<Schedule>();

            var jsonResponse = await GetResponseAsync("/teams/" + teamId + "?sportIds=1&hydrate=previousSchedule");
            var mlbTeams = JsonSerializer.Deserialize<TeamDto>(jsonResponse);

            foreach (var team in (mlbTeams ?? new TeamDto()).teams)
            {
                foreach (var item in (team?.previousGameSchedule?.dates ?? new GameScheduleRoot().dates))
                {

                    foreach (var game in item.games)
                    {
                        if (game?.status?.codedGameState == "F") // Only add completed games.
                        {
                            previousGames.Add(new Models.Schedule()
                            {
                                gameID = game?.gamePk,
                                AwayTeam = game?.teams?.away?.team?.name,
                                HomeTeam = game?.teams?.home?.team?.name,
                                Ballpark = game?.venue?.name,
                                ScheduledInnings = game?.scheduledInnings,
                                CodedGameState = game?.status?.codedGameState,
                                DayNight = game?.dayNight,
                                GameTime = game?.gameDate,
                            });
                        }
                    }
                }
            }

            return previousGames;
        }


        /// <summary>
        /// Returns game schedule/summary for specified gamePk
        /// </summary>
        /// <param gamePk="gamePk">The date to return data for.</param>
        /// <returns>A single schedule objects.</returns>
        public async Task<Schedule> GetSingleScheduleAsync(int gamePk)
        {

            var jsonResponse = await GetResponseAsync("/schedule?gamePk=" + gamePk.ToString() + "&useLatestGames=true&hydrate=probablePitcher");
            var gameSchedule = JsonSerializer.Deserialize<GameScheduleRoot>(jsonResponse);
            // This is really odd. Using gamePk returns both games of DH and gives same gamePk for both.
            if (gameSchedule?.totalGames == 0) return new Schedule();

            var gameResult = new Models.Schedule()
            {
                gameID = gameSchedule?.dates[0].games[0].gamePk,
                AwayTeam = gameSchedule?.dates[0].games[0].teams?.away?.team?.name,
                HomeTeam = gameSchedule?.dates[0].games[0].teams?.home?.team?.name,
                AwayProbablePitcher = gameSchedule?.dates[0].games[0].teams?.away?.probablePitcher?.fullName ?? "",
                HomeProbablePitcher = gameSchedule?.dates[0].games[0].teams?.home?.probablePitcher?.fullName ?? "",
                Ballpark = gameSchedule?.dates[0].games[0].venue?.name,
                ScheduledInnings = gameSchedule?.dates[0].games[0].scheduledInnings,
                CodedGameState = gameSchedule?.dates[0].games[0].status?.codedGameState ?? "X",
                StatusCode = gameSchedule?.dates[0].games[0].status.statusCode,
                DetailedState = gameSchedule?.dates[0].games[0].status.detailedState,
                Reason = gameSchedule?.dates[0].games[0].status.reason,
                DayNight = gameSchedule?.dates[0].games[0].dayNight,
                GameTime = gameSchedule?.dates[0].games[0].gameDate,
                OfficialDate = DateTime.Parse(gameSchedule?.dates[0].games[0].officialDate),
                HomeScore = gameSchedule?.dates[0].games[0].teams?.home?.score,
                AwayScore = gameSchedule?.dates[0].games[0].teams?.away?.score,
            };

            return gameResult;
        }



        /// <summary>
        /// Returns a list of the matchups and ballpark for the specified date.
        /// </summary>
        /// <param name="date">The date to return data for.</param>
        /// <returns>A list of schedule objects.</returns>
        public async Task<IEnumerable<Schedule>> GetScheduleAsync(DateTime date)
        {
            var upcomingGames = new List<Schedule>();

            var jsonResponse = await GetResponseAsync("/schedule/games/?sportId=1&date=" + date.ToString("MM/dd/yyyy"));
            var gameSchedule = JsonSerializer.Deserialize<GameScheduleRoot>(jsonResponse);

            foreach (var item in (gameSchedule ?? new GameScheduleRoot()).dates)
            {
                foreach (var game in item.games)
                {
                    upcomingGames.Add(new Models.Schedule()
                    {
                        gameID = game.gamePk,
                        AwayTeam = game.teams?.away?.team?.name,
                        AwayID = game.teams?.away?.team?.id,
                        HomeTeam = game.teams?.home?.team?.name,
                        HomeID = game.teams?.home?.team?.id,
                        Ballpark = game.venue?.name,
                        ScheduledInnings = game.scheduledInnings,
                        DayNight = game.dayNight,
                        GameTime = game.gameDate,
                        HomeScore = game.teams?.home?.score,
                        AwayScore = game.teams?.away?.score,
                        CodedGameState = game.status.codedGameState,
                    });
                }
            }

            return upcomingGames;
        }

        /// <summary>
        /// Returns a list of pitchers and their associated game reports.
        /// </summary>
        /// <param name="date">The date to return data for.</param>
        /// <returns>A list of pitching report objects</returns>
        public async Task<IEnumerable<PitchingReport>> GetPitchingReportsAsync(DateTime date)
        {
            var pitchingReports = new List<PitchingReport>();

            var jsonResponse = await GetResponseAsync("/schedule?sportId=1&hydrate=probablePitcher(note)" +
                "&fields=dates,date,games,gamePk,gameDate,status,abstractGameState," +
                "teams,away,home,team,id,name,probablePitcher,id,fullName,note&" + date.ToString("MM/dd/yyyy"));
            var reports = JsonSerializer.Deserialize<PitchingReportDto>(jsonResponse);

            foreach (var selectedDate in (reports ?? new PitchingReportDto()).dates ?? Array.Empty<DTO.PitchingReport.Date>())
            {
                foreach (var game in selectedDate.games ?? Array.Empty<DTO.PitchingReport.Game>())
                {
                    pitchingReports.Add(new PitchingReport()
                    {
                        HomeTeam = game.teams?.home?.team?.name,
                        AwayTeam = game.teams?.away?.team?.name,
                        AwayProbablePitcherId = game.teams?.away?.probablePitcher?.id,
                        AwayProbablePitcherName = game.teams?.away?.probablePitcher?.fullName,
                        AwayProbablePitcherNotes = game.teams?.away?.probablePitcher?.note,
                        HomeProbablePitcherId = game.teams?.home?.probablePitcher?.id,
                        HomeProbablePitcherName = game.teams?.home?.probablePitcher?.fullName,
                        HomeProbablePitcherNotes = game.teams?.home?.probablePitcher?.note
                    });
                }
            }

            return pitchingReports;
        }

        /// <summary>
        /// Returns a list of all MLB teams and some associated data. The ID parameters can be used to build other queries.
        /// </summary>
        /// <returns>A list of team objects.</returns>
        public async Task<IEnumerable<Models.Team>> GetTeamDataAsync()
        {
            var teamsList = new List<Models.Team>();

            var jsonResponse = await GetResponseAsync("/teams?sportId=1");
            var mlbTeams = JsonSerializer.Deserialize<TeamDto>(jsonResponse);

            foreach (var team in (mlbTeams ?? new TeamDto()).teams ?? Array.Empty<Team>())
            {
                teamsList.Add(new Models.Team()
                {
                    Name = team.name,
                    TeamName = team.teamName,
                    Location = team.locationName,
                    Id = team.id,
                    LeagueId = team.league?.id,
                    LeagueName = team.league?.name,
                    DivisionName = team.division?.name,
                    DivisionId = team.division?.id,
                    Abbreviation = team.abbreviation,
                    VenueName = team.venue?.name,
                    VenueId = team.venue?.id
                });
            }

            return teamsList;
        }

        public async Task<String> GetLatestComment(int gamePk)
        {
            var jsonResponse = await GetResponseAsync($"/game/{gamePk}/playByPlay?fields=allPlays,result,description");
            var commentaryJson = JsonSerializer.Deserialize<CommentaryDto>(jsonResponse);

            if ((commentaryJson?.allPlays?.Length ?? 0) > 0)
                return commentaryJson?.allPlays?[commentaryJson.allPlays.Length - 2].result?.description ?? String.Empty;

            return String.Empty;
        }

        /// <summary>
        /// Returns a list of team roster data for a given season.
        /// Use the GetTeamDataAsync() call to obtain the id numbers needed to satisfy the teamId parameter.
        /// </summary>
        /// <param name="teamId"> The team's MLB id (use enum)</param>
        /// <param name="season"> The year the season begins on</param>
        /// <param name="date"> A date to use, will return the roster as of that date</param>
        /// <param name="roster"> The roster type to return. Can choose either full roster, 25man or 40 man</param>
        /// <returns>An IEnumerable TeamRoster</returns>
        public async Task<IEnumerable<TeamRoster>> GetTeamRosterAsync(int teamId, int season, DateTime date, rosterType roster = rosterType.rosterFull)
        {
            List<TeamRoster> teamRosters = new();

            var typeString = "";

            switch (roster)
            {
                case rosterType.rosterFull:
                    typeString = "/teams/" + teamId + "/roster/fullRoster?season=" + season + "&date=" + date.ToString("MM/dd/yyyy");
                    break;

                case rosterType.roster25:
                    typeString = "/teams/" + teamId + "/roster?season=" + season + "&date=" + date.ToString("MM/dd/yyyy");
                    break;

                case rosterType.roster40:

                    typeString = "/teams/" + teamId + "/roster?season=" + season + "&rosterType=40Man" + "&date=" + date.ToString("MM/dd/yyyy");
                    break;
            }

            var jsonResponse = await GetResponseAsync(typeString);
            var teamRostersJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

            foreach (var item in (teamRostersJson ?? new TeamRosterDto()).roster ?? Array.Empty<Roster>())
            {
                teamRosters.Add(new TeamRoster()
                {
                    PlayerId = item.person?.id,
                    PlayerFullName = item.person?.fullName,
                    PlayerPosition = item.position?.name,
                    PlayerType = item.position?.type,
                    PositionCode = item.position?.code,
                    TeamId = teamRostersJson?.teamId,
                    PositionAbbreviation = item.position?.abbreviation,
                    StatusCode = item.status?.code,
                    StatusDescription = item.status?.description
                });
            }

            return teamRosters;
        }

        public async Task<IEnumerable<Standing>> GetStandings(int divisionId)
        {
            var standings = new List<Standing>();
            // XXX TODO remove hard coding.
            var jsonResponse = await GetResponseAsync("/standings?leagueId=103&season=2022");
            var standingsJson = JsonSerializer.Deserialize<StandingDto>(jsonResponse);

            foreach (var divisionStanding in (standingsJson ?? new StandingDto()).records)
            {
                if (divisionStanding.division.id == divisionId)
                {
                    foreach (var teamRecord in divisionStanding.teamRecords)
                    {
                        standings.Add(new Standing()
                        {
                            name = teamRecord?.team?.name ?? "n/a",
                            teamId = teamRecord?.team?.id ?? 0,
                            divisionRank = teamRecord.divisionRank,
                            gamesBack = teamRecord.gamesBack,
                            wins = teamRecord.wins,
                            losses = teamRecord.losses,
                            magicNumber = teamRecord.magicNumber,

                        });
                    }
                }
                Console.WriteLine($"Division: {divisionStanding.division.id}, Team: {divisionStanding.teamRecords[0].team.name}");

            }

            return standings;

        }

        public async Task<IEnumerable<BaseballSharp.Models.GameSummary>> GetAllGameSummary(string date)
        {
            // TODO check for valid date

            var jsonResponse = await GetResponseAsync($"/schedule?sportId=1&scheduleType=1&date={date}&hydrate=linescore");
            var allGames = JsonSerializer.Deserialize<BaseballSharp.DTO.GameSummary.AllGameSummaryDto>(jsonResponse);

            var retval = new List<BaseballSharp.Models.GameSummary>();

            foreach (var game in (allGames ?? new BaseballSharp.DTO.GameSummary.AllGameSummaryDto()).dates[0].games)
            {
                // If game is delayed, linescore is null.
                retval.Add(new BaseballSharp.Models.GameSummary()
                {
                    gamePk = game.gamePk,
                    HomeId = game.teams.home.team.id,
                    AwayId = game.teams.away.team.id,
                    HomeAbbr = MLBHelpers.NameToShortName(game.teams.home.team.name),
                    AwayAbbr = MLBHelpers.NameToShortName(game.teams.away.team.name),
                    HomeScore = game.teams.home.score,
                    AwayScore = game.teams.away.score,
                    Inning = game.linescore?.currentInning ?? 0,
                    State = game.status.codedGameState,
                    IsTop = game.linescore?.isTopInning ?? false,
                    Outs = game.linescore?.outs ?? 0,
                    On1 = game.linescore?.offense.first != null,
                    On2 = game.linescore?.offense.second != null,
                    On3 = game.linescore?.offense.third != null,
                    UnixTime = ((DateTimeOffset)game.gameDate).ToUnixTimeSeconds(),
                });
            }
            return retval;
        }
       

        public async Task<IEnumerable<WildcardStanding>> GetWildcardStandings()
        {
            var standings = new List<WildcardStanding>();
            var year = DateTime.Now.Year;
            int[] leagueIds = { 103, 104 };
            foreach (var league in leagueIds)
            {
                var jsonResponse = await GetResponseAsync($"/standings?leagueId={league}&season={year}&hydrate=league&standingsType=wildCard");
                var leagueStandingsJson = JsonSerializer.Deserialize<LeagueStandingsDto>(jsonResponse);

                // Should only be one record.
                foreach (var record in (leagueStandingsJson ?? new LeagueStandingsDto()).records)
                {
                    var teamRecords = new List<WildcardTeamStanding>();
                    foreach (var teamRecord in record.teamRecords)
                    {
                        teamRecords.Add(new WildcardTeamStanding()
                        {
                            teamId = teamRecord.team.id,
                            nameAbbr = MLBHelpers.NameToShortName(teamRecord.team.name),
                            magicNumber = teamRecord.magicNumber,
                            clinched = teamRecord.clinched,
                            wildCardGamesBack = teamRecord.wildCardGamesBack,
                            wildCardRank = teamRecord.wildCardRank,
                            wins = teamRecord.wins,
                            losses = teamRecord.losses,
                        });
                    }

                    standings.Add(new WildcardStanding()
                    {
                        Teams = teamRecords,
                        LeagueId = record.league.id,
                        LeagueName = record.league.abbreviation,

                    });
                }
            }

            return standings;

        }


        public async Task<IEnumerable<DivisionStanding>> GetLeagueStandings()
        {
            var standings = new List<DivisionStanding>();
            var year = DateTime.Now.Year;
            int[] leagueIds = { 103, 104 };
            foreach (var league in leagueIds)
            {
                var jsonResponse = await GetResponseAsync($"/standings?leagueId={league}&season={year}&hydrate=division,league");
                var leagueStandingsJson = JsonSerializer.Deserialize<LeagueStandingsDto>(jsonResponse);

                foreach (var division in (leagueStandingsJson ?? new LeagueStandingsDto()).records)
                {
                    var teamRecords = new List<Standing>();
                    foreach (var teamRecord in division.teamRecords)
                    {
                        teamRecords.Add(new Standing()
                        {
                            teamId = teamRecord.team.id,
                            nameAbbr = MLBHelpers.NameToShortName(teamRecord.team.name),
                            divisionRank = teamRecord.divisionRank,
                            gamesBack = teamRecord.gamesBack,
                            magicNumber = teamRecord.magicNumber,
                            clinched = teamRecord.clinched,
                            wildCardGamesBack = teamRecord.wildCardGamesBack,
                            wildCardRank = teamRecord.wildCardRank,
                            wins = teamRecord.wins,
                            losses = teamRecord.losses,
                        });
                    }

                    standings.Add(new DivisionStanding()
                    {
                        DivisionId = division.division.id,
                        DivisionAbbr = division.division.abbreviation,
                        DivisionName = division.division.nameShort,
                        Teams = teamRecords,
                        LeagueId = division.league.id,
                        LeagueName = division.league.nameShort,

                    });
                }
            }

            return standings;

        }


        /// <summary>
        /// Returns a list of linescore data for the game in question.
        /// </summary>
        /// <returns>A list of Linescore objects.</returns>
        /// <param name="gameId">The ID number of the game.</param>
        /// <returns>A list of Linescore objects</returns>
        public async Task<IEnumerable<Linescore>> GetLineScoreAsync(int gameId)
        {
            var lineScores = new List<Linescore>();

            var jsonResponse = await GetResponseAsync("/game/" + gameId + "/linescore");
            var lineScoresJson = JsonSerializer.Deserialize<LinescoreDto>(jsonResponse);

            foreach (var inning in (lineScoresJson ?? new LinescoreDto()).innings ?? new List<Innings>())
            {
                lineScores.Add(new Linescore()
                {
                    CurrentInning = lineScoresJson?.currentInning,
                    InningHalf = lineScoresJson?.inningHalf,
                    InningState = lineScoresJson?.inningState,
                    Outs = lineScoresJson?.outs,
                    Balls = lineScoresJson?.balls,
                    Strikes = lineScoresJson?.strikes,
                    ScheduledInnings = lineScoresJson?.scheduledInnings,
                    HometeamRunsGame = lineScoresJson?.teams?.home?.runs,
                    HometeamRuns = inning?.home?.runs,
                    HometeamHits = lineScoresJson?.teams?.home?.hits,
                    HometeamErrors = lineScoresJson?.teams?.home?.errors,
                    AwayteamRunsGame = lineScoresJson?.teams?.away?.runs,
                    AwayteamRuns = inning?.away?.runs,
                    AwayteamHits = lineScoresJson?.teams?.away?.hits,
                    AwayteamErrors = lineScoresJson?.teams?.away?.errors,
                    InningNumber = inning?.num,
                    DefensivePitcherId = lineScoresJson?.defense?.pitcher?.id,
                    DefensePitcherName = lineScoresJson?.defense?.pitcher?.fullName,
                    CatcherName = lineScoresJson?.defense?.catcher?.fullName,
                    CatcherId = lineScoresJson?.defense?.catcher?.id,
                    FirstBasemanName = lineScoresJson?.defense?.first?.fullName,
                    FirstBasemanId = lineScoresJson?.defense?.first?.id,
                    SecondBasemanName = lineScoresJson?.defense?.second?.fullName,
                    SecondBasemanId = lineScoresJson?.defense?.second?.id,
                    ThirdBasemanName = lineScoresJson?.defense?.third?.fullName,
                    ThirdBasemanId = lineScoresJson?.defense?.third?.id,
                    ShortstopName = lineScoresJson?.defense?.shortstop?.fullName,
                    ShortstopId = lineScoresJson?.defense?.shortstop?.id,
                    LeftFielderName = lineScoresJson?.defense?.left?.fullName,
                    LeftFielderId = lineScoresJson?.defense?.left?.id,
                    CenterFielderName = lineScoresJson?.defense?.center?.fullName,
                    CenterFielderId = lineScoresJson?.defense?.center?.id,
                    RightFielderName = lineScoresJson?.defense?.right?.fullName,
                    RightFielderId = lineScoresJson?.defense?.right?.id,
                    DefensiveBatterName = lineScoresJson?.defense?.batter?.fullName,
                    DefensiveBatterId = lineScoresJson?.defense?.batter?.id,
                    DefensiveOnDeck = lineScoresJson?.defense?.onDeck?.fullName,
                    DefensiveOnDeckId = lineScoresJson?.defense?.onDeck?.id,
                    DefensiveInHole = lineScoresJson?.defense?.inHole?.fullName,
                    DefensiveInHoleId = lineScoresJson?.defense?.inHole?.id,
                    DefensiveTeamName = lineScoresJson?.defense?.team?.name,
                    DefensiveTeamId = lineScoresJson?.defense?.team?.id,
                    OffensiveTeamBatterName = lineScoresJson?.offense?.batter?.fullName,
                    OffensiveTeamBatterId = lineScoresJson?.offense?.batter?.id,
                    OffensiveTeamOnDeckName = lineScoresJson?.offense?.onDeck?.fullName,
                    OffensiveTeamOnDeckId = lineScoresJson?.offense?.onDeck?.id,
                    OffensiveTeamInHoleName = lineScoresJson?.offense?.inHole?.fullName,
                    OffensiveTeamInHoleId = lineScoresJson?.offense?.inHole?.id,
                    ManOnFirst = lineScoresJson?.offense?.first != null,
                    ManOnSecond = lineScoresJson?.offense?.second != null,
                    ManOnThird = lineScoresJson?.offense?.third != null,


                });
            }

            return lineScores;
        }

        /// <summary>
        /// Returns a list of depth chart information for a given team.
        /// Use the GetTeamDataAsync() call to obtain the id numbers needed to satisfy the teamId parameter.
        /// </summary>
        /// <returns>A list of team objects.</returns>
        /// <param name="teamId">The team's ID number.</param>
        /// <returns>A list of pitching report objects</returns>
        public async Task<IEnumerable<DepthChart>> GetDepthChartAsync(int teamId)
        {
            var depthCharts = new List<DepthChart>();

            var jsonResponse = await GetResponseAsync("/teams/" + teamId + "/roster/depthChart");
            var depthChartJson = JsonSerializer.Deserialize<TeamRosterDto>(jsonResponse);

            foreach (var person in (depthChartJson ?? new TeamRosterDto()).roster ?? Array.Empty<Roster>())
            {
                depthCharts.Add(new DepthChart()
                {
                    TeamId = depthChartJson?.teamId,
                    RosterType = depthChartJson?.rosterType,
                    PlayerId = person.person?.id,
                    PlayerFullName = person.person?.fullName,
                    JerseyNumber = person.jerseyNumber,
                    PositionCode = person.position?.code,
                    PositionName = person.position?.name,
                    PositionType = person.position?.type,
                    PositionAbbrevition = person.position?.abbreviation,
                    StatusCode = person.status?.code,
                    StatusDescription = person.status?.description
                });
            }

            return depthCharts;
        }

        /// <summary>
        /// Endpoint to get the MLB divisions and associated data.
        /// </summary>
        /// <returns>A list of Division objects.</returns>
        public async Task<IEnumerable<Models.Division>> GetDivisionsAsync()
        {
            var divisions = new List<Models.Division>();

            var jsonResponse = await GetResponseAsync("/divisions?sportId=1");
            var teamDivisions = JsonSerializer.Deserialize<DivisionsDto>(jsonResponse);

            foreach (var division in (teamDivisions ?? new DivisionsDto()).divisions)
            {
                divisions.Add(new Models.Division()
                {
                    DivisionId = division.id,
                    DivisionName = division.name,
                    ShortDivisionName = division.nameShort,
                    DivisionAbbreviation = division.abbreviation,
                    LeagueId = division.league?.id
                });
            }

            return divisions;
        }

        public async Task<int> GetNextGameId(int teamId)
        {
            // Get the upcoming games for the team and return the id of the one with the earliest gametime
            var games = await GetNextScheduleAsync(teamId);
            if (games.Count() == 0) return 0;
            var firstGame = games.Aggregate((curMin, x) =>
                (curMin == null || (x.GameTime ?? DateTime.MaxValue) < curMin.GameTime ? x : curMin));
            return firstGame.gameID ?? 0;
        }

        public async Task<int> GetGameInProgressId(int teamId)
        {
            // Get the upcoming games for the team and return the id of the one with the earliest gametime
            var games = await GetNextScheduleAsync(teamId);
            if (games.Count() == 0) return 0;
            var liveGame = games.Where(g => g.CodedGameState == "P" || g.CodedGameState == "I" || g.CodedGameState == "O").FirstOrDefault();
            return liveGame?.gameID ?? 0;
        }

        public async Task<int> GetNextUnplayedGameId(int teamId)
        {
            // Get the upcoming games for the team and return the id of the one with the earliest gametime
            var games = await GetNextScheduleAsync(teamId);
            if (games.Count() == 0) return 0;
            var gameId = games.Where(g => g.CodedGameState == "S").OrderBy(g => g.GameTime).Select(g => g.gameID).First();
            return gameId ?? 0;
        }

        public async Task<int> GetLastGameId(int teamId)
        {
            // Get the upcoming games for the team and return the id of the one with the earliest gametime
            var games = await GetPreviousScheduleAsync(teamId);
            if (games.Count() == 0) return 0;
            var firstGame = games.Aggregate((curMax, x) =>
                (curMax == null || (x.GameTime ?? DateTime.MinValue) > curMax.GameTime ? x : curMax));
            return firstGame.gameID ?? 0;
        }

    }
}