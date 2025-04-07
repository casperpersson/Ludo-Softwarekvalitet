using LudoAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Setup game here
LudoAPI.GameController gameController = new LudoAPI.GameController();

app.Map("/LudoGenBoard", () =>
{
    int[] boardSpacesId = new int[4];
    boardSpacesId = gameController.SetupGameBoard();
    return boardSpacesId;
});

app.Map("/LudoMoveBrickCheck", (int roll, int playerID, int tokenID) => "Not Implemented"); //return true if it can make a legal move


app.Map("/LudoMoveBrickComplete", (int roll) =>
{
    iBoardSpace currentSpace = gameController.playerToken.CurrentSpace;

    for (int i = 0; i < roll; i++)
    {
        currentSpace = ((BoardSpace)currentSpace).NextSpace;
    }

    gameController.playerToken.CurrentSpace = currentSpace;
    currentSpace.ReciveToken(gameController.playerToken);

    return ((BoardSpace)currentSpace).id;
}); //return id for felt. expand with int playerID, int tokenID

app.Run();
