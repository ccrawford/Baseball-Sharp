namespace SoxMonApi
{
    public class RawDisplayDTO
    {
        string? line1 { get; set; }
        string? line2 { get; set; }

        string? line3 { get; set; }
        string? line4 { get; set; }

        public RawDisplayDTO()
        {

        }

        public RawDisplayDTO(string Line1,string Line2,string Line3,string Line4)
        {
            (line1, line2, line3, line4) = (Line1,Line2,Line3,Line4);
        }
    }
}
