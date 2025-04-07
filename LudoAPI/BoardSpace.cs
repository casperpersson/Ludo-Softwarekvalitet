namespace LudoAPI
{
    public class BoardSpace : iBoardSpace
    {
        public int id { get; set; }
        public iBoardSpace NextSpace { get; set; }
        List<Token> tokens { get; set; }

        public BoardSpace(int id) 
        {
            tokens = new List<Token>();
            this.id = id;
        }

        public void ReciveToken(Token token)
        {

            tokens.Add(token);
        }

        public void ReleaseToken(Token token)
        {
            tokens.Remove(token);
        }
        /// <summary>
        /// Used for getting the tokens on this boardspace
        /// </summary>
        /// <returns>Shallow copy of Tokens list</returns>
        public List<Token> GetTokens()
        { 
            return tokens.GetRange(0, tokens.Count);
        }
    }
}