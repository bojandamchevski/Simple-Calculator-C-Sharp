using Calculator.App.Domain.Interfaces;

namespace Calculator.App.Domain
{
    public abstract class BaseCalculations : ICalculations
    {
        public BaseCalculations()
        {

        }

        public virtual double Difference(double FirstNumber, double SecondNumber)
        {
            throw new System.NotImplementedException();
        }

        public virtual double Division(double FirstNumber, double SecondNumber)
        {
            throw new System.NotImplementedException();
        }

        public virtual double Multiplication(double FirstNumber, double SecondNumber)
        {
            throw new System.NotImplementedException();
        }

        public virtual double Percent(double FirstNumber, double SecondNumber)
        {
            throw new System.NotImplementedException();
        }

        public virtual double Root(double FirstNumber)
        {
            throw new System.NotImplementedException();
        }

        public virtual double Square(double FirstNumber)
        {
            throw new System.NotImplementedException();
        }

        public virtual double Sum(double FirstNumber, double SecondNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
