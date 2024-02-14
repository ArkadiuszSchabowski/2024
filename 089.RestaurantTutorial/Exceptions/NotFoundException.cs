using Azure.Messaging;

namespace _089.RestaurantTutorial.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
                
        }
    }
}
