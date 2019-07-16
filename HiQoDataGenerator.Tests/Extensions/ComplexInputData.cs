using System.Collections.Generic;

namespace HiQoDataGenerator.Tests.Extensions
{
    public class ComplexInputData : BaseInputData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            for (var i = 0; i < CountData; i++)
            {
                var minA = Faker.Random.Double();
                var maxA = Faker.Random.Double(minA);
                var minB = Faker.Random.Double();
                var maxB = Faker.Random.Double(minB);
                yield return new object[] {minA, maxA, minB, maxB};
            }
        }
    }
}