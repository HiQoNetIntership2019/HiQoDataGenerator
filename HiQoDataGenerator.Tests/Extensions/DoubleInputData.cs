using System.Collections.Generic;

namespace HiQoDataGenerator.Tests.Extensions
{
    public class DoubleInputData : BaseInputData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            for (var i = 0; i < CountData; i++)
            {
                var min = Faker.Random.Double();
                var max = Faker.Random.Double(min);
                yield return new object[] {min, max};
            }
        }
    }
}
