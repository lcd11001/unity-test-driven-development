namespace TestEditor.Infrastructure
{
    public static class Builder
    {
        public static ImageBuilder Image()
        {
            return new ImageBuilder();
        }

        public static HeartBuilder Heart()
        {
            return new HeartBuilder();
        }

        public static HeartContainerBuilder HeartContainer()
        {
            return new HeartContainerBuilder();
        }
    }
}