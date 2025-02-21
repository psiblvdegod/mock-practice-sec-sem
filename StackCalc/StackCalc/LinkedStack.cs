namespace StackCalc;

/// <inheritdoc/>
public class LinkedStack : IStack
{
    private Element? head;

    /// <inheritdoc/>
    public bool IsEmpty => head == null;

    /// <inheritdoc/>
    public void Push(double item)
        => head = new(item, head);

    /// <inheritdoc/>
    public (double Value, bool IsError) Pop()
    {
        if (head == null)
        {
            return (0, true);
        }

        var value = head.Value;
        head = head.Next;

        return (value, false);
    }

    private class Element
    {
        public Element(double value, Element? next)
        {
            Value = value;
            Next = next;
        }

        public double Value { get; }

        public Element? Next { get; }
    }
}
