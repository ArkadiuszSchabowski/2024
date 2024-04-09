using NUnit.Framework;
using WordMaster.Server.Exceptions;
using WordMaster.Server.Services;

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
        public void GetFlashCard_WhenCalledWithNegativeId()
        {
            int id = -1;

            Assert.Throws<BadRequestException>(() => _service.GetFlashCard(id));
        }
    }
}
