namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputConverter = new InputConverter();
                var calculator = new Calculator();

                Console.WriteLine("Enter a number: ");
                var firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.WriteLine("Enter another number: ");
                var secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.WriteLine("Enter an operation: ");
                var operation = Console.ReadLine();

                var result = calculator.Calculate(operation, firstNumber, secondNumber);
                Console.WriteLine(result);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}