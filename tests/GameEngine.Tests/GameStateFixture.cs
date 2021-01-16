using System;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class GameStateFixture
    { 
        public GameState State { get; private set; }

        public GameStateFixture()
        {
            State = new GameState();
        }
    }
}
