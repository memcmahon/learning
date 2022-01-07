using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace CalculatorTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void AddsTwoNumbersWithNonSymbolOperator()
    {
        Calculator calc = new Calculator();
        int number1 = 1;
        int number2 = 2;
        double result = calc.Calculate("add", number1, number2);

        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void AddsTwoNumbersWithSymbolOperator()
    {
        Calculator calc = new Calculator();
        int number1 = 1;
        int number2 = 2;
        double result = calc.Calculate("+", number1, number2);

        Assert.AreEqual(3, result);
    }
}