namespace Generics
{
    public interface INamed<T>
    {
        string Name { get; }

        T Value { get; }
    }
}
