namespace LudoAPI
{
    public class BoardSpace : iBoardSpace
    {
        public iBoardSpace NextSpace { get; set; }
        List<Token> tokens { get; set; }

        public BoardSpace() 
        {
            tokens = new List<Token>();
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