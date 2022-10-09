﻿using System;

namespace BaseballSharp.DTO;
public class DivisionsDto
{
    public string? copyright { get; set; }
    public LeagueDivision[] divisions { get; set; } = Array.Empty<LeagueDivision>();
}

public class LeagueDivision
{
    public int? id { get; set; }
    public string? name { get; set; }
    public string? season { get; set; }
    public string? nameShort { get; set; }
    public string? link { get; set; }
    public string? abbreviation { get; set; }
    public LeagueDto? league { get; set; }
    public Sport? sport { get; set; }
    public bool? hasWildcard { get; set; }
    public int? numPlayoffTeams { get; set; }
}

public class LeagueDto
{
    public int? id { get; set; }
    public string? link { get; set; }
}

public class Sport
{
    public int? id { get; set; }
    public string? link { get; set; }
}