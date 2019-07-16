using System.Collections.Generic;

namespace HiQoDataGenerator.Tests.Extensions
{
    public class IntegerInputData : BaseInputData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            for (var i = 0; i < CountData; i++)
            {
                var begin = Faker.Random.Int(int.MinValue, int.MaxValue);
                var end = Faker.Random.Int(begin, int.MaxValue);
                yield return new object[] { begin, end };
            }
        }
    }
}