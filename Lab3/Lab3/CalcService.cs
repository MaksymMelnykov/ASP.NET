namespace Lab3
{
    public class CalcService
    {
        public double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        public double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }

        public double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public double Divide(double number1, double number2)
        {
            if (number2 == 0)
            {
                throw new ArgumentException("Division by zero is not allowed!!!");
            }
            return number1 / number2;
        }
    }
}
