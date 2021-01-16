using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Collection("GameState collection")]
    [Trait("SharedCollection", "GameState")]
    public class ThrowawayClass2
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public ThrowawayClass2(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;
            _output = output;
        }

        [Fact]
        public void Test3()
        {
            _output.WriteLine($"Using {_gameStateFixture.State.Id}");
        }

        [Fact]
        public void Test4()
        {
            _output.WriteLine($"Using {_gameStateFixture.State.Id}");
        }
    }
}
