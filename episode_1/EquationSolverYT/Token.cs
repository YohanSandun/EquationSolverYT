namespace EquationSolverYT
{
    enum TokenType
    {
        NUMBER,
        VARIABLE,
        PLUS,
        MINUS,
        MUL,
        DIV,
        POWER,
        L_PAREN,
        R_PAREN
    }

    class Token
    {
        public TokenType Type { get; set; }
        public Token(TokenType type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return Type.ToString();
        }
    }

    class NumberToken : Token
    {
        public double Value { get; set; }
        public NumberToken(double value) : base(TokenType.NUMBER)
        {
            Value = value;
        }
        public override string ToString()
        {
            return Type + ":" + Value;
        }
    }
    class VariableToken : Token
    {
        public char Name { get; set; }
        public VariableToken(char name) : base(TokenType.VARIABLE)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Type + ":" + Name;
        }
    }
}
