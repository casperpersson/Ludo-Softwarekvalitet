namespace LudoAPI
{
    internal class GameController
    {
        public iBoardSpace[] Board { get; set; }

        public void SetupGameBoard()
        {
            BoardSpace[] boardspaces = new BoardSpace[4];

            for (int i = 0; i < boardspaces.Length; i++)
            {
                boardspaces[i] = new BoardSpace();
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
        }
    }
}
