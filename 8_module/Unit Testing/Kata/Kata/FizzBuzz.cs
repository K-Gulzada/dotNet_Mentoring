namespace Kata
{
    public class FizzBuzz
    {
        public string CheckForFizzBuzz(int number)
        {
            string result = string.Empty;

            if (number < 1 || number > 100)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (number % 3 == 0 && number % 5 == 0)
                {
                    result = "FizzBuzz";
                }
                else if (number % 3 == 0)
                {
                    result = "Fizz";
                }
                else if (number % 5 == 0)
                {
                    result = "Buzz";
                }
                else
                {
                    result = number.ToString();
                }
            }

            return result;
        }
    }
}