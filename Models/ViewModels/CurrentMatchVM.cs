namespace Models.ViewModels
{
    public class CurrentMatchVM
    {
        public int MatchId { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public decimal HomeCoeficient { get; set; }
        public decimal DrawCoeficient { get; set; }
        public decimal AwayCoeficient { get; set; }
    }
}
