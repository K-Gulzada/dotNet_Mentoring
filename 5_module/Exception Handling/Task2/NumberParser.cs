using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse_2(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }
            stringValue = stringValue.Trim();
            if (stringValue.Length == 0)
            {
                throw new FormatException();
            }

            long number = 0;
            bool isMinus = false;
            int specSymbolCounter = 0;
            string specSymbols = String.Empty;

            foreach (char c in stringValue)
            {
                if (!Char.IsDigit(c))
                {
                    specSymbolCounter++;
                    specSymbols += c;
                }
            }

            if (specSymbolCounter == 1 && specSymbols[0] != '-')
            {
                if (specSymbols[0] == '+')
                {
                    stringValue = stringValue.Replace("+", "");
                }
                else
                {
                    throw new FormatException();
                }
            }
            if (specSymbolCounter >= 2)
            {
                throw new FormatException();
            }

            for (int i = 0; i < stringValue.Length; i++)
            {
                if (i == 0 && stringValue[i] == '-')
                    isMinus = true;
                else if (i != 0 && stringValue[i] == '-')
                {
                    throw new FormatException();
                }
                else
                {
                    number *= 10;
                    number += stringValue[i] - '0';
                }
            }
            if (isMinus)
            {
                number = number * (-1);
            }
            Console.WriteLine(number);

            if (number > int.MaxValue || number < int.MinValue)
            {
                throw new OverflowException();
            }

            return (int)number;
        }

        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }
            stringValue = stringValue.Trim();
            if (stringValue.Length == 0)
            {
                throw new FormatException();
            }

            long number = 0;
            bool isMinus = false;

            for (int i = stringValue.Length - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    if (!char.IsDigit(stringValue[i]))
                    {
                        throw new FormatException();
                    }
                }
                else
                {
                    if (stringValue[i] == '-')
                    {
                        isMinus = true;
                        stringValue = stringValue.Replace("-", "");
                    }
                    else if (stringValue[i] == '+')
                    {
                        stringValue = stringValue.Replace("+", "");
                    }
                    else if (!char.IsDigit(stringValue[i]))
                    {
                        throw new FormatException();
                    }
                }
            }

            for (int i = 0; i < stringValue.Length; i++)
            {
                number *= 10;
                number += stringValue[i] - '0';
            }

            if (isMinus)
            {
                number = number * (-1);
            }
            Console.WriteLine(number);

            if (number > int.MaxValue || number < int.MinValue)
            {
                throw new OverflowException();
            }

            return (int)number;
        }
    }
}