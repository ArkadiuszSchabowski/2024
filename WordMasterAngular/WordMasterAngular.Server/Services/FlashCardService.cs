using AutoMapper;
using WordMaster.Server.Exceptions;
using WordMaster.Server.Models;
using WordMaster.ServerDatabase;
using WordMaster.ServerDatabase.Entities;

namespace WordMaster.Server.Services
{
    public interface IFlashCardService
    {
        List<FlashCard> GetFlashCards();
        FlashCard GetPolishFlashCard(string word);
        FlashCard GetEnglishFlashCard(string word);
        void AddWord(FlashCardDto dto);
    }
    public class FlashCardService : IFlashCardService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public FlashCardService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<FlashCard> GetFlashCards()
        {
            return _context.FlashCards.ToList();
        }

        public FlashCard GetPolishFlashCard(string word)
        {
            var flashCard = _context.FlashCards.FirstOrDefault(x => x.PolishWord == word);

            if (flashCard == null)
            {
                throw new NotFoundException("Nie znaleziono takiego polskiego słowa");
            }

            return flashCard;
        }
        public FlashCard GetEnglishFlashCard(string word)
        {
            var flashCard = _context.FlashCards.FirstOrDefault(x => x.EnglishWord == word);

            if (flashCard == null)
            {
                throw new NotFoundException("Nie znaleziono takiego angielskiego słowa");
            }

            return flashCard;
        }

        public void AddWord(FlashCardDto dto)
        {
            var newWordDto = new FlashCard()
            {
                PolishWord = dto.PolishWord.ToUpper(),
                EnglishWord = dto.EnglishWord.ToUpper()
            };

            var polishFlashCard = _context.FlashCards.FirstOrDefault(x => x.PolishWord == newWordDto.PolishWord);
            var englishFlashCard = _context.FlashCards.FirstOrDefault(x => x.EnglishWord == newWordDto.EnglishWord);

            if (polishFlashCard != null)
            {
                throw new ConflictException("W słowniku istnieje już takie polskie słowo");
            }
            if (englishFlashCard != null)
            {
                throw new ConflictException("W słowniku istnieje już takie angielskie słowo");
            }
            var newWord = _mapper.Map<FlashCard>(newWordDto);
            _context.FlashCards.Add(newWord);
            _context.SaveChanges();
        }
    }

}
