using Bogus;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public abstract class GeneratorBase
    {
        protected readonly Randomizer _randomizer = new Randomizer();
    }
}
