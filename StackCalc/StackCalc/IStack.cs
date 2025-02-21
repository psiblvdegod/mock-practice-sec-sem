namespace StackCalc;

/// <summary>
/// Stack of elements.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Gets a value indicating whether stack is not empty.
    /// </summary>
    public bool IsEmpty { get; }

    /// <summary>
    /// Pushes <paramref name="item"/> on top of stack.
    /// </summary>
    /// <param name="item">The item to push.</param>
    public void Push(double item);

    /// <summary>
    /// Tries to pop value off top of stack.
    /// </summary>
    /// <returns>
    /// Tuple of value of top and <see langword="true"/> if stack was not empty, <see langword="false"/> otherwise.
    /// </returns>
    public (double Value, bool IsError) Pop();
}
