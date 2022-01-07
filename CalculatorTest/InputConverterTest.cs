using System; // without explicitly using this, ArgumentException is not recognized.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace CalculatorTest;

[TestClass]
public class InputConverterTest
{
    private readonly InputConverter _inputConverter = new InputConverter();

    [TestMethod]
    public void ConvertsInputToDouble()
    {
        var inputNumber = "5";
        var convertedNumber = _inputConverter.ConvertInputToNumeric(inputNumber);
        Assert.AreEqual(5, convertedNumber);     
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void FailsWithInvalidInput()
    {
        var inputNumber = "*";
        var convertedNumber = _inputConverter.ConvertInputToNumeric(inputNumber);
    }
}