using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolverYT
{
    class Lexer
    {
        private string expression;
        private char currentChar;
        private int index = -1;

        public Lexer(string expression)
        {
            this.expression = expression;
            advance();
        }

        private void advance()
        {
            index++;
            if (expression.Length > index)
                currentChar = expression[index];
            else
                currentChar = '\0';
        }

        public List<Token> GenerateTokens()
        {
            List<Token> tokens = new List<Token>();

            while (currentChar != '\0')
            {
                if (currentChar == ' ' || currentChar == '\t')
                    advance();
                else if (currentChar == '+')
                {
                    tokens.Add(new Token(TokenType.PLUS));
                    advance();
                }
                else if (currentChar == '-')
                {
                    tokens.Add(new Token(TokenType.MINUS));
                    advance();
                }
                else if (currentChar == '*')
                {
                    tokens.Add(new Token(TokenType.MUL));
                    advance();
                }
                else if (currentChar == '/')
                {
                    tokens.Add(new Token(TokenType.DIV));
                    advance();
                }
                else if (currentChar == '^')
                {
                    tokens.Add(new Token(TokenType.POWER));
                    advance();
                }
                else if (currentChar == '(')
                {
                    tokens.Add(new Token(TokenType.L_PAREN));
                    advance();
                }
                else if (currentChar == ')')
                {
                    tokens.Add(new Token(TokenType.R_PAREN));
                    advance();
                }
                else if (currentChar >= '0' && currentChar <= '9')
                {
                    tokens.Add(createNumber());
                }
                else if (currentChar >= 'a' && currentChar <= 'z')
                {
                    tokens.Add(new VariableToken(currentChar));
                    advance();
                }
            }

            return tokens;
        }

        private Token createNumber()
        {
            string num = "";
            while (currentChar != '\0' && ((currentChar >= '0' && currentChar <= '9') || currentChar == '.'))
            {
                num += currentChar;
                advance();
            }
            return new NumberToken(double.Parse(num));
        }
    }
}
