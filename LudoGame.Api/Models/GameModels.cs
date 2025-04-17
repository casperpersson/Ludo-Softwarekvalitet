using LudoGame.Api.Store;
using LudoGame.Core;
using LudoGame.Core.Domain;
using LudoGame.Core.Enums;

namespace LudoGame.Api.Models
{
    /// <summary>
    /// Request DTO til oprettelse af spil
    /// </summary>
    public record CreateGameRequest(string[] Colors);

    /// <summary>
    /// Request DTO til at udføre et træk
    /// </summary>
    public record TurnRequest(int PiecePosition);

    /// <summary>
    /// En briks tilstand som DTO
    /// </summary>
    public record PieceDto(PlayerColor Color, PieceState State, int Position)
    {
        public static PieceDto From(Piece p)
            => new(p.Color, p.State, p.Position);
    }

    /// <summary>
    /// DTO for hele spiltilstanden
    /// </summary>
    public record GameDto(
        Guid Id,
        PlayerColor CurrentPlayer,
        IEnumerable<PieceDto> Pieces,
        bool HasWinner,
        PlayerColor? Winner)
    {
        public static GameDto From(TrackedGame tg)
        {
            var current = tg.Game.Current;
            PlayerColor? winner = current.HasWon ? current.Color : null;

            return new GameDto(
                tg.Id,
                current.Color,
                tg.Pieces.Select(PieceDto.From),
                winner is not null,
                winner
            );
        }
    }
}
