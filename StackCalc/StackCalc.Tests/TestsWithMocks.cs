namespace StackCalc.Tests;

using Moq;

public class TestsWithMocks
{
    [Test]
    public void Calc_Evaluate_ShouldBeCorrect()
    {
        var input = "10 20 *";
        var expectedResult = 200.0;

        var mock = new Mock<IStack<double>>();
        mock.SetupSequence(s => s.IsEmpty).Returns(false).Returns(false).Returns(true);
        mock.Setup(s => s.Pop()).Returns(expectedResult);

        var calc = new Calc(mock.Object);

        Assert.That(calc.Evaluate(input), Is.EqualTo(expectedResult).Within(0.001));
    }

    [Test]
    public void Calc_EvaluateOnEmptyString_ShouldThrowException()
    {
        var mock = new Mock<IStack<double>>();
        mock.Setup(s => s.Pop()).Throws<InvalidOperationException>();

        var calc = new Calc(mock.Object);

        Assert.Throws<ArgumentException>(() => calc.Evaluate(string.Empty));
    }
}
