using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests 
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould : IDisposable
    {
        private ITestOutputHelper _output;
        private EnemyFactory _sut;

        public EnemyFactoryShould(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Creating EnemyFactory");
            _sut = new EnemyFactory();
        }
        
        public void Dispose()
        {
            _output.WriteLine("Disposing of EnemyFactory");
        }


        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            Enemy enemy = _sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            Enemy enemy = _sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_AndAssignName()
        {
            Enemy enemy = _sut.Create("Zombie King", true);

            BossEnemy result = Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Zombie King", result.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertFromAssignableTypes()
        {
            Enemy enemy = _sut.Create("Zombie King", true);

            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeperateInstances()
        {
            Enemy enemy1 = _sut.Create("Zombie");
            Enemy enemy2 = _sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void ThrowExceptionWithNullName()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => _sut.Create(null));
        }

        [Fact]
        public void OnlyAllowsKingOrQueenBossEnemies()
        {
            EnemyCreationException ex = 
                Assert.Throws<EnemyCreationException>(() => _sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
            Assert.Contains("must end with", ex.Message);
        }
    }
}
