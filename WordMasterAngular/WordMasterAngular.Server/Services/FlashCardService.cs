using AutoMapper;
using WordMaster.Server.Exceptions;
using WordMaster.Server.Models;
using WordMaster.ServerDatabase;
using WordMaster.ServerDatabase.Entities;

namespace WordMaster.Server.Services
{
    public interface IFlashCardService
    {
        List<FlashCardDto> GetFlashCards();
        FlashCardDto GetPolishFlashCard(string word);
        FlashCardDto GetEnglishFlashCard(string word);
        FlashCardDto GetFlashCard(FlashCard flashCard);
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
        public List<FlashCardDto> GetFlashCards()
        {
            var flashcards = _context.FlashCards.ToList();

            var flashcardsDto = _mapper.Map<List<FlashCardDto>>(flashcards);

            return flashcardsDto;
        }

        public FlashCardDto GetPolishFlashCard(string word)
        {
            var flashcard = _context.FlashCards.FirstOrDefault(x => x.PolishWord == word);
            var flashCardDto = GetFlashCard(flashcard);
            return flashCardDto;
        }
        public FlashCardDto GetEnglishFlashCard(string word)
        {
            var flashcard = _context.FlashCards.FirstOrDefault(x => x.EnglishWord == word);
            var flashCardDto = GetFlashCard(flashcard);
            return flashCardDto;
        }
        public FlashCardDto GetFlashCard(FlashCard? flashcard)
        {
            if (flashcard == null)
            {
                throw new NotFoundException("Nie znalezionio takiego słowa");
            }
            var flashcardDto = _mapper.Map<FlashCardDto>(flashcard);
            return flashcardDto;
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
            if(polishFlashCard != null)
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
