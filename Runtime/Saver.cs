using System.Threading.Tasks;
using SaveSystem.Loaders;
using SaveSystem.Writers;

namespace SaveSystem
{
    public class Saver
    {
        private readonly DataLoader _dataLoader;

        private readonly DataWriter _dataWriter;

        public Saver(DataLoader dataLoader, DataWriter dataWriter)
        {
            _dataLoader = dataLoader;
            _dataWriter = dataWriter;
        }

        public Task<T> Load<T>(string filePath)
        {
            return _dataLoader.Load<T>(filePath);
        }

        public void Write<T>(T data, string filePath)
        {
            _dataWriter.Write(data, filePath);
        }
    }
}