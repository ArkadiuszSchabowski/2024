using Moq;
using NUnit.Framework;
using WordMaster.Server.Exceptions;
using WordMaster.Server.Services;
using WordMaster.ServerDatabase;

namespace WordMaster.ServerTests.UnitTests.Services
{
    public class FlashCardServiceUnitTests
    {
        public FlashCardService _service;
        [SetUp]
        public void Setup()
        {
            _service = new FlashCardService(null, null);
        }
        [Test]
        public void GetFlashCard_WhenCalledWithNegativeId_ShouldThrowBadRequestException()
        {
            int id = -1;

            Assert.Throws<BadRequestException>(() => _service.GetFlashCard(id));
        }
        [Test]
        public void GetPolishFlashCard_WhenNameIsTooLong_ShouldThrowBadRequestException()
        {
            string name = "WrongNameWrongNameWrongNameWrongName";

            Assert.Throws<BadRequestException>(() => _service.GetPolishFlashCard(name));
        }
        [Test]
        public void GetEnglishFlashCard_WhenNameIsTooShort_ShouldThrowBadRequestException()
        {
            string name = "a";

            Assert.Throws<BadRequestException>(() => _service.GetEnglishFlashCard(name));
        }
    }
}
