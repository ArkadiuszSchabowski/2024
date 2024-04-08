using System.ComponentModel.DataAnnotations;

namespace WordMaster.ServerDatabase.Entities
{
    public class FlashCard
    {
        public int Id { get; set; }
        public string PolishWord { get; set; }
        public string EnglishWord { get; set; }
    }
}
