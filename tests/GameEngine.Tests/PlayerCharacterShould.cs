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
            Assert.StartsWith("John", sut.FullName, StringComparison.OrdinalIgnoreCase);
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

        [Fact]
        public void NotHaveANicknameOnStart()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void HaveALongBowOnCreation()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void DoesNotHaveAGun()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Gun", sut.Weapons);
        }

        [Fact]
        public void DoesHaveOneTypeOfSword()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.Sleep());
        }
    }
}
