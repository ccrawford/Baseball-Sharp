using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.DTO
{
    public class ProbabilityDto
    {
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public double homeTeamWinProbability { get; set; }
        public int atBatIndex { get; set; }
        
    }
}
