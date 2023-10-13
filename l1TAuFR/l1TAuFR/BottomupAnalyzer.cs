using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l1TAuFR
{
    public class BottomupAnalyzer
    {
        private List<Token> listLeksemsToken;
        private Stack<Token> stackLeksems = new Stack<Token>();
        private int i = 0;
        private Stack<int> stateStack = new Stack<int>();
        private int stateNow = 0;
        private bool end = false;
        private Token k;

        public List<string> Matr = new List<string>();
        private int count2 = 1;

        private Dictionary<char, int> operationPriority = new Dictionary<char, int> { { '(', 0 }, { ')', 1 }, { '+', 2 }, { '-', 2 }, { '*', 3 }, { '/', 3 } };

        public BottomupAnalyzer(List<Token> listLeksemsToken)
        {
            this.listLeksemsToken = listLeksemsToken;
        }
        public void Analyzer()
        {
            GoToState(0);
            while (!end)
            {
                switch (stateNow)
                {
                    case 0:
                        State0();
                        break;
                    case 1:
                        State1();
                        break;
                    case 2:
                        State2();
                        break;
                    case 3:
                        State3();
                        break;
                    case 4:
                        State4();
                        break;
                    case 5:
                        State5();
                        break;
                    case 6:
                        State6();
                        break;
                    case 7:
                        State7();
                        break;
                    case 8:
                        State8();
                        break;
                    case 9:
                        State9();
                        break;
                    case 10:
                        State10();
                        break;
                    case 14:
                        State14();
                        break;
                    case 15:
                        State15();
                        break;
                    case 16:
                        State16();
                        break;
                    case 17:
                        State17();
                        break;
                    case 19:
                        State19();
                        break;
                    case 20:
                        State20();
                        break;
                    case 21:
                        State21();
                        break;
                    case 22:
                        State22();
                        break;
                    case 23:
                        State23();
                        break;
                    case 24:
                        State24();
                        break;
                    case 25:
                        State25();
                        break;
                    case 27:
                        State27();
                        break;
                    case 28:
                        State28();
                        break;
                    case 29:
                        State29();
                        break;
                    case 30:
                        State30();
                        break;
                    case 31:
                        State31();
                        break;
                    case 32:
                        State32();
                        break;
                    case 34:
                        State34();
                        break;
                    case 35:
                        State35();
                        break;
                    case 36:
                        State36();
                        break;
                    case 37:
                        State37();
                        break;
                    case 38:
                        State38();
                        break;
                    case 39:
                        State39();
                        break;
                    case 40:
                        State40();
                        break;
                    case 41:
                        State41();
                        break;
                    case 42:
                        State42();
                        break;
                    case 43:
                        State43();
                        break;
                    case 44:
                        State44();
                        break;
                    case 45:
                        State45();
                        break;
                    case 46:
                        State46();
                        break;
                    case 47:
                        State47();
                        break;
                    case 48:
                        State48();
                        break;
                    case 49:
                        State49();
                        break;
                    case 50:
                        State50();
                        break;
                }
            }
        }
        private void Shift()
        {
            stackLeksems.Push(listLeksemsToken[i++]);
        }
        private void GoToState(int state)
        {
            stateStack.Push(state);
            this.stateNow = state;
        }
        private void Reduce(int num, string neterm)
        {
            while (num > 0)
            {
                stackLeksems.Pop();
                stateStack.Pop();
                num--;
            }
            k = new Token(neterm, TokenType.NETERM);
            stackLeksems.Push(k);
            GoToState(stateStack.Pop());
        }
        private void State0()
        {
            if (stackLeksems.Count == 0)
                Shift();
            switch (stackLeksems.Peek().Value)
            {
                case "<программа'>":
                    end = true;
                    break;
                case "<программа>":
                    GoToState(1);
                    break;
                case "main":
                    GoToState(2);
                    break;
                default:
                    throw new Exception($"Ожидался main,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State1()
        {
            if (stackLeksems.Peek().Value == "<программа>")
                Reduce(1, "<программа'>");
        }
        private void State2()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "main":
                    Shift();
                    break;
                case "(":
                    GoToState(3);
                    break;
                default:
                    throw new Exception($"Ожидался (,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State3()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "(":
                    Shift();
                    break;
                case ")":
                    GoToState(4);
                    break;
                default:
                    throw new Exception($"Ожидался ),а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State4()
        {
            switch (stackLeksems.Peek().Value)
            {
                case ")":
                    Shift();
                    break;
                case "{":
                    GoToState(5);
                    break;
                default:
                    throw new Exception($"Ожидался {{,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State5()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "{":
                    Shift();
                    break;
                case "<список>":
                    GoToState(6);
                    break;
                case "}":
                    stackLeksems.Pop();
                    k = new Token("<список>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                case "<единица списка>":
                    GoToState(7);
                    break;
                case "<объявление>":
                    GoToState(8);
                    break;
                case "<тип>":
                    GoToState(9);
                    break;
                case "int":
                    GoToState(10);
                    break;
                case "<while>":
                    GoToState(14);
                    break;
                case "while":
                    GoToState(15);
                    break;
                case "<присвоение2>":
                    GoToState(16);
                    break;
                case "id":
                    GoToState(17);
                    break;
                default:
                    throw new Exception($"Ожидался }} или int или string или bool или char или while или id,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State6()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<список>":
                    Shift();
                    break;
                case "}":
                    GoToState(19);
                    break;
                default:
                    throw new Exception($"Ожидался }},а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State7()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<единица списка>":
                    Shift();
                    if (stackLeksems.Peek().Value != "}")
                        GoToState(7);
                    break;
                case "<список>":
                    GoToState(20);
                    break;
                case "}":
                    stackLeksems.Pop();
                    k = new Token("<список>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                case "<объявление>":
                    GoToState(8);
                    break;
                case "<тип>":
                    GoToState(9);
                    break;
                case "int":
                    GoToState(10);
                    break;
                case "<while>":
                    GoToState(14);
                    break;
                case "while":
                    GoToState(15);
                    break;
                case "<присвоение2>":
                    GoToState(16);
                    break;
                case "id":
                    GoToState(17);
                    break;
                default:
                    throw new Exception($"Ожидался }} или int или string или bool или char или while или id,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State8()
        {
            if (stackLeksems.Peek().Value == "<объявление>")
                Reduce(1, "<единица списка>");
        }
        private void State9()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<тип>":
                    Shift();
                    break;
                case "id":
                    GoToState(21);
                    break;
                default:
                    throw new Exception($"Ожидался id,а встретился {stackLeksems.Peek()}\n Состояние: {stateNow}");
            }
        }
        private void State10()
        {
            if (stackLeksems.Peek().Value == "int")
                Reduce(1, "<тип>");
        }
        private void State14()
        {
            if (stackLeksems.Peek().Value == "<while>")
                Reduce(1, "<единица списка>");
        }
        private void State15()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "while":
                    Shift();
                    break;
                case "(":
                    GoToState(22);
                    break;
                default:
                    throw new Exception($"Ожидался (,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State16()
        {
            if (stackLeksems.Peek().Value == "<присвоение2>")
                Reduce(1, "<единица списка>");
        }
        private void State17()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "id":
                    Shift();
                    break;
                case "=":
                    GoToState(23);
                    break;
                default:
                    throw new Exception($"Ожидался =,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State19()
        {
            if (stackLeksems.Peek().Value == "}")
                Reduce(6, "<программа>");
        }
        private void State20()
        {
            if (stackLeksems.Peek().Value == "<список>")
                Reduce(2, "<список>");
        }
        private void State21()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "id":
                    k = stackLeksems.Pop();
                    if (stackLeksems.Peek().Value == "id")
                    {
                        stackLeksems.Push(k);
                        throw new Exception($"Ожидался = или , или ;,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
                    }
                    stackLeksems.Push(k);
                    Shift();
                    break;
                case "<присвоение1>":
                    GoToState(24);
                    break;
                case "=":
                    GoToState(25);
                    break;
                case ",":
                    stackLeksems.Pop();
                    k = new Token("<присвоение1>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                case ";":
                    stackLeksems.Pop();
                    k = new Token("<присвоение1>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                default:
                    throw new Exception($"Ожидался = или , или ;,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State22()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "(":
                    Shift();
                    break;
                case "<операнд>":
                    GoToState(27);
                    break;
                case "id":
                    GoToState(28);
                    break;
                case "lit":
                    GoToState(29);
                    break;
                default:
                    throw new Exception($"Ожидался id или lit,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State23()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "=":
                    Expr();
                    break;
                case "expr":
                    GoToState(30);
                    break;
                default:
                    throw new Exception($"Ожидался expr,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State24()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<присвоение1>":
                    Shift();
                    break;
                case "<,id>":
                    GoToState(31);
                    break;
                case ",":
                    GoToState(32);
                    break;
                case ";":
                    stackLeksems.Pop();
                    Token k = new Token("<,id>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                default:
                    throw new Exception($"Ожидался , или ;,а встретился {stackLeksems.Peek()}\n Состояние: {stateNow}");
            }
        }
        private void State25()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "=":
                    Expr();
                    break;
                case "expr":
                    GoToState(34);
                    break;
                default:
                    throw new Exception($"Ожидался expr,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State27()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<операнд>":
                    Shift();
                    break;
                case "<знак>":
                    GoToState(35);
                    break;
                case "<":
                    GoToState(36);
                    break;
                case ">":
                    GoToState(37);
                    break;
                case "==":
                    GoToState(38);
                    break;
                case ">=":
                    GoToState(39);
                    break;
                case "<=":
                    GoToState(40);
                    break;
                default:
                    throw new Exception($"Ожидался < или > или == или >= или <=,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State28()
        {
            if (stackLeksems.Peek().Type == TokenType.IDENTIFIER)
                Reduce(1, "<операнд>");
        }
        private void State29()
        {
            if (stackLeksems.Peek().Type == TokenType.LITERAL)
                Reduce(1, "<операнд>");
        }
        private void State30()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "expr":
                    Shift();
                    break;
                case ";":
                    GoToState(41);
                    break;
                default:
                    throw new Exception($"Ожидался ;,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State31()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<,id>":
                    Shift();
                    break;
                case ";":
                    GoToState(42);
                    break;
                default:
                    throw new Exception($"Ожидался ;,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State32()
        {
            switch (stackLeksems.Peek().Value)
            {
                case ",":
                    Shift();
                    break;
                case "id":
                    GoToState(43);
                    break;
                default:
                    throw new Exception($"Ожидался id,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State34()
        {
            if (stackLeksems.Peek().Value == "expr")
                Reduce(2, "<присвоение1>");
        }
        private void State35()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<знак>":
                    Shift();
                    break;
                case "<операнд>":
                    GoToState(46);
                    break;
                case "id":
                    GoToState(28);
                    break;
                case "lit":
                    GoToState(29);
                    break;
                default:
                    throw new Exception($"Ожидался id или lit,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State36()
        {
            if (stackLeksems.Peek().Value == "<")
                Reduce(1, "<знак>");
        }
        private void State37()
        {
            if (stackLeksems.Peek().Value == ">")
                Reduce(1, "<знак>");
        }
        private void State38()
        {
            if (stackLeksems.Peek().Value == "==")
                Reduce(1, "<знак>");
        }
        private void State39()
        {
            if (stackLeksems.Peek().Value == ">=")
                Reduce(1, "<знак>");
        }
        private void State40()
        {
            if (stackLeksems.Peek().Value == "<=")
                Reduce(1, "<знак>");
        }
        private void State41()
        {
            if (stackLeksems.Peek().Value == ";")
                Reduce(4, "<присвоение2>");
        }
        private void State42()
        {
            if (stackLeksems.Peek().Value == ";")
                Reduce(5, "<объявление>");
        }
        private void State43()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "id":
                    k = stackLeksems.Pop();
                    if (stackLeksems.Peek().Value == "id")
                    {
                        stackLeksems.Push(k);
                        throw new Exception($"Ожидался = или , или ;,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
                    }
                    stackLeksems.Push(k);
                    Shift();
                    break;
                case "<присвоение1>":
                    GoToState(44);
                    break;
                case "=":
                    GoToState(25);
                    break;
                case ",":
                    stackLeksems.Pop();
                    k = new Token("<присвоение1>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                case ";":
                    stackLeksems.Pop();
                    k = new Token("<присвоение1>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                default:
                    throw new Exception($"Ожидался = или , или ;,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State44()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<присвоение1>":
                    Shift();
                    break;
                case "<,id>":
                    GoToState(45);
                    break;
                case ",":
                    GoToState(32);
                    break;
                case ";":
                    stackLeksems.Pop();
                    Token k = new Token("<,id>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                default:
                    throw new Exception($"Ожидался , или ;,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State45()
        {
            if (stackLeksems.Peek().Value == "<,id>")
                Reduce(4, "<,id>");
        }
        private void State46()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<операнд>":
                    Shift();
                    break;
                case ")":
                    GoToState(47);
                    break;
                default:
                    throw new Exception($"Ожидался ),а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State47()
        {
            switch (stackLeksems.Peek().Value)
            {
                case ")":
                    Shift();
                    break;
                case "{":
                    GoToState(48);
                    break;
                default:
                    throw new Exception($"Ожидался {{,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State48()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "{":
                    Shift();
                    break;
                case "<список>":
                    GoToState(49);
                    break;
                case "}":
                    stackLeksems.Pop();
                    k = new Token("<список>", TokenType.NETERM);
                    stackLeksems.Push(k);
                    i--;
                    break;
                case "<единица списка>":
                    GoToState(7);
                    break;
                case "<объявление>":
                    GoToState(8);
                    break;
                case "<тип>":
                    GoToState(9);
                    break;
                case "int":
                    GoToState(10);
                    break;
                case "<while>":
                    GoToState(14);
                    break;
                case "while":
                    GoToState(15);
                    break;
                case "<присвоение2>":
                    GoToState(16);
                    break;
                case "id":
                    GoToState(17);
                    break;
                default:
                    throw new Exception($"Ожидался }} или int или string или bool или char или while или id,а встретился {stackLeksems.Peek().Value}\n Состояние: {stateNow}");
            }
        }
        private void State49()
        {
            switch (stackLeksems.Peek().Value)
            {
                case "<список>":
                    Shift();
                    break;
                case "}":
                    GoToState(50);
                    break;
                default:
                    throw new Exception($"Ожидался }},а встретился {stackLeksems.Peek().Value} \n Состояние: {stateNow}");
            }
        }
        private void State50()
        {
            if (stackLeksems.Peek().Value == "}")
                Reduce(9, "<while>");
        }
        public void Expr()
        {
            Shift();
            char cr = '0';
            Stack<char> stack = new Stack<char>();
            string postfix = "";
            int count = 0, b = 0;
            {
                if (stackLeksems.Peek().Value == ";" || stackLeksems.Peek().Value == ",")
                {
                    throw new Exception($"После знака = должно идти арифметическое выражение любой сложности \n Состояние: {stateNow}");
                }
                for (int j = i; (j + 1) < listLeksemsToken.Count && listLeksemsToken[j].Value != ";" && listLeksemsToken[j].Value != ","; j++)
                {
                    if (listLeksemsToken[j].Value == "(")
                        b++;
                    if (listLeksemsToken[j].Value == ")")
                        b--;
                }
                if (b > 0)
                    throw new Exception($") отсутствует или является лишним\n Состояние: {stateNow}");
                if (b < 0)
                    throw new Exception($"( отсутствует или является лишним\n Состояние: {stateNow}");
                if (!Char.IsLetterOrDigit(stackLeksems.Peek().Value[0]))
                    throw new Exception($"После знака = должно идти арифметическое выражение любой сложности и знак разделитель ; или ,\n Состояние: {stateNow}");
            }
            while (stackLeksems.Peek().Value != ";" && stackLeksems.Peek().Value != ",")
            {
                {
                    if (Token.IsNoMathSymbol(stackLeksems.Peek().Value) || Token.IsSpecialWord(stackLeksems.Peek().Value))
                        throw new Exception($"{stackLeksems.Peek().Value} не может стоять в мат. выражении\n Состояние: {stateNow}");
                    k = stackLeksems.Pop();
                    if (Token.IsMathSymbol(k.Value) && Token.IsMathSymbol(stackLeksems.Peek().Value))
                        throw new Exception($"После или перед знаком математической операции отсутствует значение\n Состояние: {stateNow}");
                    if ((k.Value == "id" && stackLeksems.Peek().Value == "lit") || (k.Value == "lit" && stackLeksems.Peek().Value == "lit") || (k.Value == "id" && stackLeksems.Peek().Value == "id") || (k.Value == "lit" && stackLeksems.Peek().Value == "id"))
                        throw new Exception($"Между значениями должны стоять знак математической операции\n Состояние: {stateNow}");
                    if ((k.Value == "(" && stackLeksems.Peek().Value == "lit") || (k.Value == "(" && stackLeksems.Peek().Value == "id") || (k.Value == "lit" && stackLeksems.Peek().Value == ")") || (k.Value == "id" && stackLeksems.Peek().Value == ")"))
                        throw new Exception($"Между значением и скобкой должен быть знак\n Состояние: {stateNow}");
                    stackLeksems.Push(k);
                }
                if (stackLeksems.Peek().Value == "id" || stackLeksems.Peek().Value == "lit")
                {
                    postfix += stackLeksems.Peek().NameIDValue + " ";
                }
                else if (stackLeksems.Peek().Value == "(")
                {
                    stack.Push('(');
                }
                else if (stackLeksems.Peek().Value == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop() + " ";
                    }
                    stack.Pop();
                }
                else if (char.TryParse(stackLeksems.Peek().Value, out cr) && operationPriority.ContainsKey(char.Parse(stackLeksems.Peek().Value)))
                {
                    while (stack.Count > 0 && (operationPriority[stack.Peek()] >= operationPriority[char.Parse(stackLeksems.Peek().Value)]))
                    {
                        postfix += stack.Pop() + " ";
                    }
                    stack.Push(char.Parse(stackLeksems.Peek().Value));

                }
                Shift();
                count++;
            }
            stackLeksems.Pop();
            i--;
            while (count-- > 0)
                stackLeksems.Pop();
            k = new Token("expr", TokenType.EXPR);
            stackLeksems.Push(k);
            foreach (char op in stack)
                postfix += op + " ";
            stack.Clear();

            Stack<string> stack1 = new Stack<string>();
            string[] pf = postfix.Split(' ');
            int count1 = 1;
            Matr.Add($"{count2++}-ое выражение\r\n" + postfix);
            for (int j = 0; j < pf.Length; j++)
            {
                stack1.Push(pf[j]);
                char c;
                if (char.TryParse(pf[j], out c) && operationPriority.ContainsKey(c))
                {
                    Matr.Add($"M{count1} = {stack1.Pop()} {stack1.Pop()} {stack1.Pop()}");
                    stack1.Push($"M{count1++}");
                }
            }
        }
    }
}
