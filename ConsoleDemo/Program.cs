using HelloWorld.Math;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var number = Calculator.Add(1, 2);
            Console.WriteLine(number);
        }
    }
}