using System.Collections;
using System.Collections.Generic;
using Bogus;

namespace HiQoDataGenerator.Tests.Extensions
{
    public abstract class BaseInputData : IEnumerable<object[]>
    {
        protected const int CountData = 10;
        protected readonly Faker Faker = new Faker();

        public abstract IEnumerator<object[]> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}