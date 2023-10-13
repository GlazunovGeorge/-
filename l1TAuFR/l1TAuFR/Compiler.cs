using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l1TAuFR
{
    public class Compiler
    {
        public List<string> listLeksems;
        public List<Token> listTokensAnalyzer;
        public BottomupAnalyzer bottomupAnalyzer;
        public List<Token> LeksemAnalyzer(string a)
        {
            return Tokenization(Leksems(a));
        }
        public void BottomupAnalyzer()
        {
            bottomupAnalyzer = new BottomupAnalyzer(listTokensAnalyzer);
            bottomupAnalyzer.Analyzer();
        }
        private List<string> Leksems(string a)
        {
            a = a.Replace("\r", " ");
            a = a.Replace("\t", " ");
            a = a.Replace("\n", " ");
            int b;
            string[] a1 = new string[a.Length];
            for (int i = 0; i < a1.Length; i++)
                a1[i] = a[i].ToString();
            for (int i = 0; i < a1.Length; i++)
            {
                if ((a1[i] == ">" || a1[i] == "<" || a1[i] == "=") && a1[i+1] == "=")
                {
                    a1[i] = " " + a1[i];
                    a1[i+1] += " ";
                    i++;
                    i++;
                }
                if (Token.SpecialSymbols.ContainsKey(a1[i]))
                {
                    a1[i] = " " + a1[i];
                    if (i+1 == a1.Length)
                        continue;
                    a1[i] += " ";
                }
                if (int.TryParse(a1[i].ToString(), out b) && !int.TryParse(a1[i+1].ToString(), out b))
                    a1[i] =  a1[i] + " ";
            }
            a = string.Concat(a1);
            a1 = a.Split(' ');
            List<string> list = new List<string>();
            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != "")
                    list.Add(a1[i].ToString());
            this.listLeksems = list;
            return list;
        }
        private List<Token> Tokenization(List<string> listLeksems)
        {
            List<Token> list = new List<Token>();
            List<Token> list2 = new List<Token>();
            int b = 0;
            foreach (string s in listLeksems)
            {
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!Token.IsSpecialSymbol(s))
                            if (!Token.IsSpecialWord(s))
                                if (!Char.IsLetterOrDigit(s[i]))
                                    throw new Exception($"Недопустимый символ");
                    }
                } 
                if (Token.IsSpecialSymbol(s))
                {
                    Token token = new Token(Token.SpecialSymbols[s]);
                    list.Add(token);
                    token = new Token(s, Token.SpecialSymbols[s]);
                    list2.Add(token);
                    continue;
                }
                if (Token.IsSpecialWord(s))
                {
                    Token token = new Token(Token.SpecialWords[s]);
                    list.Add(token);
                    token = new Token(s, Token.SpecialWords[s]);
                    list2.Add(token);
                    continue;
                }
                if (int.TryParse(s, out b))
                {
                    Token token = new Token(s, TokenType.LITERAL);
                    list.Add(token);
                    token = new Token("lit", TokenType.LITERAL,s);
                    list2.Add(token);
                    continue;
                }
                Token token1 = new Token(s, TokenType.IDENTIFIER);
                list.Add(token1);
                token1 = new Token("id", TokenType.IDENTIFIER, s);
                list2.Add(token1);

            }
            this.listTokensAnalyzer = list2;   
            return list;
        }
        
    }
}
