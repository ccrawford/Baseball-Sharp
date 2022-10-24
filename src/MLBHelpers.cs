using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballSharp.Models;

namespace BaseballSharp
{
    public static class MLBHelpers
    {
        static IEnumerable<Models.Team> mlbTeams;
        static MLBClient mlbClient;

        public static bool Initialize()
        {
            mlbClient = new MLBClient();
            mlbTeams = mlbClient.GetTeamDataAsync().Result;

            return true;
        }

        public static string NameToShortName(string name)
        {
            if (mlbTeams == null) Initialize();

            foreach(var team in mlbTeams)
            {
                if (team.Name == name) return team.Abbreviation.PadRight(3) ?? string.Empty;
            }
            return name; //If you cant find abbr, just return the original.
        }

        public static int DivisionIdFromTeamId(int teamId)
        {
            int retval = 0;
            if (mlbTeams == null) Initialize();
            foreach(var team in mlbTeams)
            {
                if(team.Id == teamId)
                {
                    return team.DivisionId ?? 0;
                }
            }
            
            return retval;
        }

        public static string IdToAbbr(int id)
        {
            if (mlbTeams == null) Initialize();
            var abbr = mlbTeams.Where(x=>x.Id == id).Select(x=>x.Abbreviation).FirstOrDefault();
            return abbr ?? String.Empty;

        }



        public static string LeagueAbbrFromTeamId(int teamId)
        {
            if (mlbTeams == null) Initialize();
            var name = mlbTeams.Where(x => x.Id == teamId).Select(x => x.LeagueName).FirstOrDefault();
            return name?? String.Empty;
        }

        public static void BuildTeamSelect()
        {
            if (mlbTeams == null) Initialize();
            var sortedTeams =
                from team in mlbTeams
                orderby team.LeagueName, team.Name
                select team;
            foreach (var team in sortedTeams)
            {
                Console.WriteLine($"<option value='{team.Id}'>{team.Name}</option>");
            }
            return;
        }

        public static IEnumerable<Team> AllTeams()
        {
            if (mlbTeams == null) Initialize();
            var sortedTeams =
                from team in mlbTeams
                orderby team.LeagueName, team.Name
                select team;
            
            return sortedTeams;
        }
    }
}
