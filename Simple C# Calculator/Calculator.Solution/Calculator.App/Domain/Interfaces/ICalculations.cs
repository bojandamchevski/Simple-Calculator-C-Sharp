namespace Calculator.App.Domain.Interfaces
{
    public interface ICalculations
    {
        double Sum(double FirstNumber, double SecondNumber);
        double Difference(double FirstNumber, double SecondNumber);
        double Multiplication(double FirstNumber, double SecondNumber);
        double Division(double FirstNumber, double SecondNumber);
        double Square(double FirstNumber);
        double Root(double FirstNumber);
        double Percent(double FirstNumber, double SecondNumber);
    }
}
