using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WordMaster.Server.Exceptions;
using WordMaster.Server.Services;
using WordMaster.ServerDatabase;
using WordMaster.ServerDatabase.Entities;

namespace WordMaster.ServerTests.IntegrationTests.Services
{
    public class FlashCardServiceIntegrationTests
    {
        public IConfiguration _configuration;
        public FlashCardService _service;
        public MyDbContext _context;
        public List<FlashCard> _flashCards;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase("myDb").Options;

            _context = new MyDbContext(options);

            _service = new FlashCardService(_context, null);

            _flashCards = new List<FlashCard> {
                new FlashCard { PolishWord = "Pies", EnglishWord = "Kot"},
                new FlashCard { PolishWord = "Kot", EnglishWord = "Cat" },
                new FlashCard { PolishWord = "Świnia", EnglishWord = "Pig"}
            };
        }
        [Test]
        public void GetFlashCard_WhenCalledWithCorrectId_ShouldReturnFlashCard()
        {
            _context.AddRange(_flashCards);

            var result = _service.GetFlashCard(3);

            Assert.That(result, Is.InstanceOf<FlashCard>());

            _context.RemoveRange(_flashCards);
        }

        [Test]
        public void GetFlashCard_WhenFlashCardNotExist_ShouldThrowNotFoundException()
        {
            int id = 3;

            Assert.Throws<NotFoundException>(() => _service.GetFlashCard(id));
        }
    }
}
