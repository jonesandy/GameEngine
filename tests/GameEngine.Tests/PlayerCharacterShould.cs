using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "Player")]
    public class PlayerCharacterShould : IDisposable
    {
        ITestOutputHelper _output;
        PlayerCharacter _sut;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Creating new PlayerCharacter");
            _sut = new PlayerCharacter();
        }

        public void Dispose()
        {
            _output.WriteLine($"Disposing of charactor {_sut.FirstName}");
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        // Testing skip attribute on redundant test
        [Fact(Skip = "Testing Skip attribute")]
        public void NotBeExperiencedWhenNew()
        {
            Assert.False(!_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Andy";
            _sut.LastName = "Jones";

            Assert.Equal("Andy Jones", _sut.FullName);
        }
        
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            _sut.FirstName = "John";

            Assert.StartsWith("John", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            _sut.LastName = "Jones";

            Assert.EndsWith("Jones", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameIgnoringCase()
        {
            _sut.FirstName = "PAUL";
            _sut.LastName = "SMITH";

            Assert.Equal("Paul Smith", _sut.FullName, ignoreCase: true);
            Assert.StartsWith("Paul", _sut.FullName, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void IncreasesInHealthAfterSleep()
        {
            _sut.Sleep();

            Assert.InRange(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveANicknameOnStart()
        {
            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBowOnCreation()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void DoesNotHaveAGun()
        {
            Assert.DoesNotContain("Gun", _sut.Weapons);
        }

        [Fact]
        public void DoesHaveOneTypeOfSword()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(_sut, "Health", () => _sut.Sleep());
        }
    }
}
