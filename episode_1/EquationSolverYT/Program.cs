using System;
using System.Collections.Generic;

namespace EquationSolverYT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an expression: ");
            string input = Console.ReadLine().Trim();

            Lexer lexer = new Lexer(input);
            List<Token> tokens = lexer.GenerateTokens();

            foreach (Token token in tokens)
            {
                Console.WriteLine(token.ToString());
            }

            Console.ReadLine();
        }
    }
}
