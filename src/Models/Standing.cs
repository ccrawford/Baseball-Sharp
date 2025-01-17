﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.Models
{
    public class Standing
    {
        public int teamId { get; set; }
        public string? name { get; set; }
        public string? nameAbbr { get; set; }
        public string? divisionRank { get; set; }
        public string? gamesBack { get; set; }
        public string? wildCardRank { get; set; }
        public string? wildCardGamesBack { get; set; }
        public bool? clinched { get; set; }
        public string? magicNumber { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
    }
}
