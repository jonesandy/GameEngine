using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "GameState")]
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameState;
        private readonly ITestOutputHelper _output;

        public GameStateShould(ITestOutputHelper output, GameStateFixture gameState)
        {
            _output = output;
            _gameState = gameState;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"Using gamestate {_gameState.State.Id}");
            _output.WriteLine($"Number of players in game: {_gameState.State.Players.Count}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();
            player1.Nickname = "John";
            player2.Nickname = "Paul";

            _gameState.State.Players.Add(player1);
            _gameState.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            _gameState.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);

            foreach(var x in _gameState.State.Players)
            {
                _output.WriteLine(x.Nickname);
            }
        }

        [Fact]
        public void Reset()
        {
            _output.WriteLine($"Using gamestate {_gameState.State.Id}");
            _output.WriteLine($"Number of players in game: {_gameState.State.Players.Count}");

            var player3 = new PlayerCharacter();
            var player4 = new PlayerCharacter();
            player3.Nickname = "George";
            player4.Nickname = "Ringo";

            _gameState.State.Players.Add(player3);
            _gameState.State.Players.Add(player4);

            foreach (var x in _gameState.State.Players)
            {
                _output.WriteLine(x.Nickname);
            }

            _gameState.State.Reset();

            Assert.Empty(_gameState.State.Players);
        }
    }
}
