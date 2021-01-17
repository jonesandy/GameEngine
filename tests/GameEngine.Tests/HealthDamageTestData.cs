using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    public class HealthDamageTestData
    {
        private static readonly List<object[]> Data = new List<object[]>
        {
            new object[]{0, 100},
            new object[]{1, 99},
            new object[]{50, 50},
            new object[]{101, 1}
        };

        public static IEnumerable<object[]> TestData => Data;
    }
}
