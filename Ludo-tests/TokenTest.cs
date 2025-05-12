using LudoAPI.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_tests
{
    public class TokenTest
    {
        [TestMethod]
        public void MoveToken_ShouldMoveTokenToBoardOnRollOfSix()
        {
            // Arrange  
            var settings = new GameSettings(); // Assuming GameSettings is a class that needs to be passed to the Game constructor.  
            var game = new Game(settings);
            game.Initialize();
            var player = game.CurrentPlayer;
            var token = player.Tokens[0];

            // Act  
            game.MoveToken(player, token, 6);

            // Assert  
            Assert.AreEqual(TokenState.OnBoard, token.State);
        }
    }
}
