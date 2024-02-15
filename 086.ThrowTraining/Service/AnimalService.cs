namespace _086.ThrowTraining.Service
{
    public interface IAnimalService
    {
        List<Animal> GetAnimals();
    }
    public class AnimalService : IAnimalService
    {
        public List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>()
            {
                //new Animal
                //{
                //    Name = "Guinea Pig",
                //    IsPredator = false,
                //    MaxWeight = 1
                //},
                //new Animal
                //{
                //    Name = "Cat",
                //    IsPredator = true,
                //    MaxWeight = 12
                //}
            };
            return animals;
        }
    }
}
