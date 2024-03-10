namespace _085.RelationsDatabase.Database.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public AllegroUser User { get; set; }
    }
}
