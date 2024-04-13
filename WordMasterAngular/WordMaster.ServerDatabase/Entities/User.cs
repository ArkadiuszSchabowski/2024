namespace WordMaster.ServerDatabase.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string? City { get; set; }
        public string Country { get; set; }
    }
}
