namespace StackCalc;

/// <summary>
/// Stack of elements.
/// </summary>
/// <typeparam name="T">Type of elements in the stack.</typeparam>
public interface IStack<T>
{
    /// <summary>
    /// Gets a value indicating whether stack is not empty.
    /// </summary>
    public bool IsEmpty { get; }

    /// <summary>
    /// Pushes <paramref name="item"/> on the top of the stack.
    /// </summary>
    /// <param name="item">The item to push.</param>
    public void Push(T item);

    /// <summary>
    /// Tries to pop value off top of stack.
    /// </summary>
    /// <returns>
    /// Tuple of value of top and <see langword="true"/> if stack was not empty, <see langword="false"/> otherwise.
    /// </returns>
    public T Pop();
}
