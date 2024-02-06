namespace AutoMapper.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public bool? isPremiumAccount { get; set; }
        public bool? isAdmin { get; set; }
    }
}
