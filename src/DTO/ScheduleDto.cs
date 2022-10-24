﻿using System;
using System.Collections.Generic;

namespace BaseballSharp.DTO.GameSchedule;


public class GameScheduleRoot
{
    public string? copyright { get; set; }
    public int totalItems { get; set; }
    public int totalEvents { get; set; }
    public int totalGames { get; set; }
    public int totalGamesInProgress { get; set; }
    public Date[] dates { get; set; } = Array.Empty<Date>();
    public List<Series>? series { get; set; }
}

public class Date
{
    public string? date { get; set; }
    public int totalItems { get; set; }
    public int totalEvents { get; set; }
    public int totalGames { get; set; }
    public int totalGamesInProgress { get; set; }
    public Game[] games { get; set; } = Array.Empty<Game>();
    public object[] events { get; set; } = Array.Empty<Object>();
}

public class Game
{
    public int gamePk { get; set; }
    public string? link { get; set; }
    public string? gameType { get; set; }
    public string? season { get; set; }
    public DateTime gameDate { get; set; }
    public string? officialDate { get; set; }
    public Status? status { get; set; }
    public Teams? teams { get; set; }
    public Decisions? decisions { get; set; }
    public Venue? venue { get; set; }
    public Content? content { get; set; }
    public int gameNumber { get; set; }
    public bool publicFacing { get; set; }
    public string? doubleHeader { get; set; }
    public string? gamedayType { get; set; }
    public string? tiebreaker { get; set; }
    public string? calendarEventID { get; set; }
    public string? seasonDisplay { get; set; }
    public string? dayNight { get; set; }
    public int scheduledInnings { get; set; }
    public bool reverseHomeAwayStatus { get; set; }
    public int inningBreakLength { get; set; }
    public int gamesInSeries { get; set; }
    public int seriesGameNumber { get; set; }
    public string? seriesDescription { get; set; }
    public string? recordSource { get; set; }
    public string? ifNecessary { get; set; }
    public string? ifNecessaryDescription { get; set; }
    public DateTime rescheduledFrom { get; set; }
    public string? rescheduledFromDate { get; set; }
    public string? description { get; set; }
}

public class Status
{
    public string? abstractGameState { get; set; }
    public string? codedGameState { get; set; }
    public string? detailedState { get; set; }
    public string? statusCode { get; set; }
    public bool startTimeTBD { get; set; }
    public string? abstractGameCode { get; set; }
    public string? reason { get; set; }
}

public class Teams
{
    public Away? away { get; set; }
    public Home? home { get; set; }
}

public class Away
{
    public Leaguerecord? leagueRecord { get; set; }
    public Team? team { get; set; }
    public bool splitSquad { get; set; }
    public int seriesNumber { get; set; }
    public int? score { get; set; }

    public ProbablePitcher? probablePitcher { get; set; }
}

public class ProbablePitcher
{
    public int id { get; set; }
    public string? fullName { get; set; }
}

public class Leaguerecord
{
    public int wins { get; set; }
    public int losses { get; set; }
    public string? pct { get; set; }
}

public class Team
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? link { get; set; }
}

public class Home
{
    public Leaguerecord1? leagueRecord { get; set; }
    public Team1? team { get; set; }
    public bool splitSquad { get; set; }
    public int seriesNumber { get; set; }
    public int? score { get; set; }

    public ProbablePitcher? probablePitcher { get; set; }
}

public class Leaguerecord1
{
    public int wins { get; set; }
    public int losses { get; set; }
    public string? pct { get; set; }
}

public class Team1
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? link { get; set; }
}

public class Venue
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? link { get; set; }
}

public class Content
{
    public string? link { get; set; }
}

public class Decisions
{
    public Winner winner { get; set; }
    public Loser loser { get; set; }
    public Save save { get; set; }
}

public class Winner
{
    public int id { get; set; }
    public string fullName { get; set; }
    public string link { get; set; }
}

public class Loser
{
    public int id { get; set; }
    public string fullName { get; set; }
    public string link { get; set; }
}

public class Save
{
    public int id { get; set; }
    public string fullName { get; set; }
    public string link { get; set; }
}

public class Series
{
    public Series series { get; set; }
    public int totalGames { get; set; }
    public List<Game> games { get; set; }
    public string id { get; set; }
}