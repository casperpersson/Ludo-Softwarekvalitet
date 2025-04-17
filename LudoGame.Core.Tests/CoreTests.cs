using System.ComponentModel;
using System.Linq;
using LudoGame.Core;
using LudoGame.Core.Dice;
using LudoGame.Core.Domain;
using LudoGame.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LudoGame.Core.Tests;

[TestClass]
public class CoreTests
{
    // Fake terning der altid returnerer 6
    private sealed class SixDice : IDice { public int Roll() => 6; }

    [TestMethod]
    public void RollSix_ShouldMovePieceOutOfYard()
    {
        // Arrange
        var board = new Board();
        var dice = new SixDice();
        var game = new Game(dice, board, new[] { PlayerColor.Red });
        var piece = ((Player)game.Current).Pieces.First();

        // Act
        game.PlayTurn((p, r) => piece);

        // Assert
        Assert.AreEqual(PieceState.OnLoop, piece.State);
        Assert.AreEqual(0, piece.Position);      // Rød starter på felt 0
    }
}

