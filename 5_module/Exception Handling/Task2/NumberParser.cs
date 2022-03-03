using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {

            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }
            stringValue = stringValue.Trim();
            if (stringValue.Trim().Length == 0)
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
            Console.WriteLine(specSymbols);

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
            Console.WriteLine(stringValue);
            /*
            foreach (char c in stringValue)
            {
                if (c == '-')
                {
                    isMinus = true;
                }
                else
                {
                    number *= 10;
                    number += c-'0';
                }
               
            }*/

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
            // Parse_NumberOutOfInt32Range_ThrowFormatException
            if (number > int.MaxValue || number < int.MinValue)
            {
                throw new OverflowException();
            }


            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }
            // Parse_InvalidNumberFormat_ThrowFormatException
            /* if (stringValue.Length == 0)
             {
                 throw new FormatException();
             }*/




            return (int)number;
        }
    }
}