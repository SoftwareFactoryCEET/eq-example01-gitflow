namespace eq_example01_gitflow.Interfaces
{
    public interface ICalculable
    {
        decimal Add(decimal number1, decimal number2);
        decimal Subtract(decimal number1, decimal number2);
        decimal Multiply(decimal number1, decimal number2);
        decimal Divide(decimal number1, decimal number2);
    }
}
