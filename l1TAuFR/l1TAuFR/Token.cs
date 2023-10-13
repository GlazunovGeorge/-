using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l1TAuFR
{
    public enum TokenType
    {
        INT, LITERAL, IDENTIFIER, BEGIN, END,
        TRUE, FALSE, LPAR, RPAR, PLUS, ASSIGNMENT, LESSEQ, GREATEREQ,
        MINUS, EQUAL, SEMICOLON, WHILE, MAIN, MULTIPLICATION, DIVISION, COMMA, GREATER, LESS, NETERM, EXPR
    }
    public class Token
    {
        public string Value;
        public TokenType Type;
        public string NameIDValue;
        private static TokenType[] Delimiters = new TokenType[] { TokenType.SEMICOLON, TokenType.PLUS, TokenType.MINUS, TokenType.EQUAL, TokenType.RPAR, TokenType.LPAR, TokenType.ASSIGNMENT, TokenType.MULTIPLICATION, TokenType.DIVISION, TokenType.COMMA, TokenType.GREATER, TokenType.LESS };
        public static Dictionary<string, TokenType> SpecialWords = new Dictionary<string, TokenType>() { { "int", TokenType.INT }, { "while", TokenType.WHILE }, { "main", TokenType.MAIN } };
        public static Dictionary<string, TokenType> SpecialSymbols = new Dictionary<string, TokenType>() { { ";", TokenType.SEMICOLON }, { "(", TokenType.LPAR }, { ")", TokenType.RPAR }, { "+", TokenType.PLUS }, { "-", TokenType.MINUS }, { "==", TokenType.ASSIGNMENT }, { "*", TokenType.MULTIPLICATION }, { "/", TokenType.DIVISION }, { ",", TokenType.COMMA }, { "=", TokenType.EQUAL }, { ">", TokenType.GREATER }, { "<", TokenType.LESS }, { "<=", TokenType.LESSEQ }, { ">=", TokenType.GREATEREQ }, { "{", TokenType.BEGIN }, { "}", TokenType.END } };
        public static Dictionary<string, TokenType> NoMathSymbols = new Dictionary<string, TokenType>() { { ";", TokenType.SEMICOLON }, { "==", TokenType.ASSIGNMENT }, { ",", TokenType.COMMA }, { "=", TokenType.EQUAL }, { ">", TokenType.GREATER }, { "<", TokenType.LESS }, { "<=", TokenType.LESSEQ }, { ">=", TokenType.GREATEREQ }, { "{", TokenType.BEGIN }, { "}", TokenType.END } };
        public static Dictionary<string, TokenType> MathSymbols = new Dictionary<string, TokenType>() { { "+", TokenType.PLUS }, { "-", TokenType.MINUS }, { "*", TokenType.MULTIPLICATION }, { "/", TokenType.DIVISION } };
        public Token() { }
        public Token(TokenType type) { this.Type = type; }
        public Token(string value, TokenType type)
        {
            this.Value = value;
            this.Type = type;
        }
        public Token(string value, TokenType type, string NameIDValue)
        {
            this.Value = value;
            this.Type = type;
            this.NameIDValue = NameIDValue;
        }
        public static bool IsDelimiter(Token token)
        {
            return Delimiters.Contains(token.Type);
        }
        public static bool IsSpecialWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }
            return (SpecialWords.ContainsKey(word));
        }
        public static bool IsSpecialSymbol(string ch)
        {
            return SpecialSymbols.ContainsKey(ch);
        }
        public static bool IsNoMathSymbol(string ch)
        {
            return NoMathSymbols.ContainsKey(ch);
        }
        public static bool IsMathSymbol(string ch)
        {
            return MathSymbols.ContainsKey(ch);
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}", Type, Value);
        }

    }
}
