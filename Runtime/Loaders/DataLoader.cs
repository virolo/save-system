using System.Threading.Tasks;

namespace SaveSystem.Loaders
{
    public interface DataLoader
    {
        public Task<T> Load<T>(string filePath);
    }
}