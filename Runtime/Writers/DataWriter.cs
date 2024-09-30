namespace SaveSystem.Writers
{
    public interface DataWriter
    {
        public void Write<T>(T data, string filePath);
    }
}