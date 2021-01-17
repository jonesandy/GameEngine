using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "NonPlayer")]
    public class NonPlayerCharacterShould
    {
        [Trait("Theory", "HealthDamageData")]
        [Theory]
        [HealthDamageData]
        public void TakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}
