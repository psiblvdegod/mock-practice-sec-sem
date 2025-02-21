namespace StackCalc;

/// <inheritdoc/>
public class ArrayStack : IStack
{
    private double[] array = new double[8];
    private int head = -1;

    /// <inheritdoc/>
    public bool IsEmpty => this.head == -1;

    /// <inheritdoc/>
    public void Push(double value)
    {
        this.head++;
        if (this.head >= this.array.Length)
        {
            Array.Resize(ref this.array, this.array.Length * 2);
        }

        this.array[this.head] = value;
    }

    /// <inheritdoc/>
    public (double Value, bool IsError) Pop()
    {
        if (this.head == -1)
        {
            return (0, true);
        }

        double value = this.array[this.head];
        this.head--;
        return (value, false);
    }
}
