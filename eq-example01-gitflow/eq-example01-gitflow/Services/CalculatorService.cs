using eq_example01_gitflow.Interfaces;

namespace eq_example01_gitflow.Services
{
    public class CalculatorService : ICalculable
    {
        public decimal Add(decimal number1, decimal number2)
        {
            return (number1 + number2);
        }

        public decimal Divide(decimal number1, decimal number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException("Attempted to divide by zero.");
            }

            return number1 / number2;
        }

        public decimal Multiply(decimal number1, decimal number2)
        {
            return (number1 * number2);
        }

        public decimal Subtract(decimal number1, decimal number2)
        {
            return (number1 - number2);
        }
    }
}
