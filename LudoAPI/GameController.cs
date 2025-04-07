namespace LudoAPI
{
    internal class GameController
    {
        public iBoardSpace[] Board { get; set; }
        public Token playerToken { get; set; } //temp - should be list of players

        public int[] SetupGameBoard()
        {
            BoardSpace[] boardspaces = new BoardSpace[4];
            int[] boardSpacesId = new int[4];

            for (int i = 0; i < boardspaces.Length; i++)
            {
                boardspaces[i] = new BoardSpace(i);
                boardSpacesId[i] = i;
            }

            
            for (int i = 0; i < boardspaces.Length; i++)
            {
                if (i == boardspaces.Length - 1)
                {
                    boardspaces[boardspaces.Length - 1].NextSpace = boardspaces[0];
                }
                else
                {
                    boardspaces[i].NextSpace = boardspaces[i + 1];
                }
            }

            Board = boardspaces;


            playerToken = new Token();
            Board[0].ReciveToken(playerToken);

            return boardSpacesId;
        }
    }
}
