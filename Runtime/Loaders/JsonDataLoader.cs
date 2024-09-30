using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace SaveSystem.Loaders
{
    public class EmptyDataException : Exception
    {
        public override string Message => "Read data is empty.";
    }

    public class JsonDataLoader : DataLoader
    {
        public Task<T> Load<T>(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new NullReferenceException();
                }

                string dataLoaded = File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(dataLoaded))
                {
                    throw new EmptyDataException();
                }
            
                return Task.FromResult(JsonUtility.FromJson<T>(dataLoaded));
            }
            catch (EmptyDataException e)
            {
                Debug.LogError(e);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load data: {e.Message}");
            }

            return default;
        }
    }
}