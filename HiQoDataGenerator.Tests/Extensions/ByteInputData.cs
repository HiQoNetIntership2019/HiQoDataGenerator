using System.Collections.Generic;

namespace HiQoDataGenerator.Tests.Extensions
{
    public class ByteInputData : BaseInputData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            for (var i = 0; i < CountData; i++)
            {
                var min = Faker.Random.Byte();
                var max = Faker.Random.Byte(min);

                yield return new object[] {min, max};
            }
        }
    }
}