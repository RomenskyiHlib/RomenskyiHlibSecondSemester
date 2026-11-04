using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace WpfApp1.Service
{
    internal class CalculationServiceMethods
    {
        public static string Calculate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return "0";

            List<string> tokens = Tokenize(expression);
            if (tokens.Count == 0) return "0";

            tokens = ProcessMultiplicationAndDivision(tokens);
            double result = ProcessAdditionAndSubtraction(tokens);

            return result.ToString(CultureInfo.InvariantCulture);
        }

        private static List<string> Tokenize(string expr)
        {
            List<string> tokens = new List<string>();
            string currentNumber = "";

            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];

                if (char.IsDigit(c) || c == '.')
                {
                    currentNumber += c;
                }
                else if ("+-*/".Contains(c.ToString()))
                {
                    if (c == '-' && string.IsNullOrEmpty(currentNumber) && (tokens.Count == 0 || "+-*/".Contains(tokens[tokens.Count - 1])))
                    {
                        currentNumber += c;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(currentNumber))
                        {
                            tokens.Add(currentNumber);
                            currentNumber = "";
                        }
                        tokens.Add(c.ToString());
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentNumber))
            {
                tokens.Add(currentNumber);
            }

            return tokens;
        }

        private static List<string> ProcessMultiplicationAndDivision(List<string> tokens)
        {
            for (int i = 1; i < tokens.Count - 1; i += 2)
            {
                string op = tokens[i];
                if (op == "*" || op == "/")
                {
                    double left = double.Parse(tokens[i - 1], CultureInfo.InvariantCulture);
                    double right = double.Parse(tokens[i + 1], CultureInfo.InvariantCulture);
                    double res = 0;

                    if (op == "*") 
                        res = left * right;
                    if (op == "/")
                    {
                        if (right == 0) throw new DivideByZeroException();
                        res = left / right;
                    }

                    tokens[i - 1] = res.ToString();
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i);
                    i -= 2;
                }
            }
            return tokens;
        }

        private static double ProcessAdditionAndSubtraction(List<string> tokens)
        {
            double result = double.Parse(tokens[0], CultureInfo.InvariantCulture);

            for (int i = 1; i < tokens.Count; i += 2)
            {
                string op = tokens[i];
                double right = double.Parse(tokens[i + 1], CultureInfo.InvariantCulture);

                if (op == "+") result += right;
                if (op == "-") result -= right;
            }

            return result;
        }

    }
}