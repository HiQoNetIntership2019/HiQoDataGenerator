using Bogus;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public abstract class GeneratorBase
    {
        protected readonly Faker _faker;
        protected readonly Randomizer _randomizer;

        public GeneratorBase()
        {
            _faker = new Faker();
            _randomizer = _faker.Random;
        }
    }
}
