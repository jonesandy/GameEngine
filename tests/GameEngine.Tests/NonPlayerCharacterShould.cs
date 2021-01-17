using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "NonPlayer")]
    public class NonPlayerCharacterShould
    {
        [Trait("Theory", "MemberData")]
        [Theory]
        [MemberData(nameof(HealthDamageTestData.TestData), MemberType = typeof(HealthDamageTestData))]
        public void TakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}
