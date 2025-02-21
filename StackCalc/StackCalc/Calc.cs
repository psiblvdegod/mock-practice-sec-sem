namespace StackCalc;

/// <summary>
/// Stack calculator.
/// </summary>
public class Calc
{
    private readonly IStack stack;

    /// <summary>
    /// Initializes a new instance of the <see cref="Calc"/> class.
    /// </summary>
    /// <param name="stack">Stack to use.</param>
    public Calc(IStack stack)
    {
        this.stack = stack;
    }

    /// <summary>
    /// Evaluates <paramref name="input"/> as <see langword="double"/>.
    /// </summary>
    /// <param name="input">Input string in reverse polish notation.</param>
    /// <returns>Evaluation result.</returns>
    public double Evaluate(string input)
    {
        var tokens = input.Split(' ');

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                var (rightOperand, isError) = stack.Pop();
                (var leftOperand, isError) = stack.Pop();

                if (isError)
                {
                    throw new();
                }

                var operationResult = token switch
                {
                    "+" => leftOperand + rightOperand,
                    "-" => leftOperand - rightOperand,
                    "*" => leftOperand * rightOperand,
                    "/" => leftOperand / rightOperand,
                    _ => throw new(),
                };

                stack.Push(operationResult);
            }
        }

        var (result, isError2) = stack.Pop();

        if (isError2)
        {
            throw new();
        }

        return result;
    }
}
