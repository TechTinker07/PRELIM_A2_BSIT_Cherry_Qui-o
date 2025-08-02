namespace PRELIM_A2_BSIT_Cherry_Quiño.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Books> BorrowedBooks { get; set; } = new List<Books>();
    
}
}
