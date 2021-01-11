using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Andy";
            sut.LastName = "Jones";

            Assert.Equal("Andy Jones", sut.FullName);
        }
        
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Andy";

            Assert.StartsWith("Andy", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.LastName = "Jones";

            Assert.EndsWith("Jones", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameIgnoringCase()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "JOHN";
            sut.LastName = "SMITH";

            Assert.Equal("John Smith", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void IncreasesInHealthAfterSleep()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep();

            Assert.InRange(sut.Health, 101, 200);
        }
    }
}
