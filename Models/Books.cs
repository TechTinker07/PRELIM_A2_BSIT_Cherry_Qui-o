namespace PRELIM_A2_BSIT_Cherry_Quiño.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public Authors Author { get; set; }
        public DateTime? DateLastReturned { get; set; }
        public bool IsAvailable { get; set; }
        public Genre Genre { get; set; } // enum type



    }

    public enum Genre
    {
       Mystery, Comedy, Fantasy, SelfHelp, Contemporary, Spirituality, HistoricalFiction
    }
}
