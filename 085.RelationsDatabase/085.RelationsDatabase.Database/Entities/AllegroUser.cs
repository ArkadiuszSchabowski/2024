namespace _085.RelationsDatabase.Database.Entities
{
    public class AllegroUser
    {
        public Guid Id { get; set; }
        public string Nick {  get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
