var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Setup game here
LudoAPI.GameController gameController = new LudoAPI.GameController();

app.Map("/LudoGenBoard", () =>
{
    gameController.SetupGameBoard();
}); //board array of board id

app.Map("/LudoMoveBrickCheck", (int roll, int playerID, int tokenID) => "Hello World!"); //return true if it can make a legal move


app.Map("/LudoMoveBrickComplete", (int roll, int playerID, int tokenID) => "Hello World!"); //return id for felt

app.Run();
