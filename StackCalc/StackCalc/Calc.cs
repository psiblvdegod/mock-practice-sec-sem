namespace StackCalc;

/// <summary>
/// Stack calculator.
/// </summary>
public class Calc(IStack<double> stack)
{
    /// <summary>
    /// Evaluates <paramref name="input"/> as <see langword="double"/>.
    /// </summary>
    /// <param name="input">Input string in reverse polish notation.</param>
    /// <returns>Evaluation result.</returns>
    public double Evaluate(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                if (stack.IsEmpty)
                {
                    throw new ArgumentException("Passed expression is invalid.");
                }

                var rightOperand = stack.Pop();

                if (stack.IsEmpty)
                {
                    throw new ArgumentException("Passed expression is invalid.");
                }

                var leftOperand = stack.Pop();

                var operationResult = token switch
                {
                    "+" => leftOperand + rightOperand,
                    "-" => leftOperand - rightOperand,
                    "*" => leftOperand * rightOperand,
                    "/" => leftOperand / rightOperand,
                    _ => throw new ArgumentException("Passed expression is invalid."),
                };

                stack.Push(operationResult);
            }
        }

        var result = stack.Pop();

        if (!stack.IsEmpty)
        {
            throw new ArgumentException("Passed expression is invalid.");
        }

        return result;
    }
}
