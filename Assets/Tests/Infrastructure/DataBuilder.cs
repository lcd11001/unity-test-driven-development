namespace TestEditor.Infrastructure
{
    public abstract class DataBuilder<T>
    {
        public abstract T Build();
        public static implicit operator T(DataBuilder<T> bulider)
        {
            // make code cleaner
            // var target = An.Image().Build();
            // to
            // Image target = An.Image();
            return bulider.Build();
        }
    }
}