using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.DTO
{
        public class AllPlay
    {
        public Result? result { get; set; }
    }

    public class Result
    {
        public string? description { get; set; } = string.Empty;
    }

    public class CommentaryDto
    {
        public AllPlay[]? allPlays { get; set; } = Array.Empty<AllPlay>();
         
    }

    
}
