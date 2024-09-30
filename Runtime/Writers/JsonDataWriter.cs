using System;
using System.IO;
using UnityEngine;

namespace SaveSystem.Writers
{
    public class JsonDataWriter : DataWriter
    {
        public void Write<T>(T data, string filePath)
        {
            try
            {
                if (data is null)
                {
                    throw new NullReferenceException();
                }

                string jsonString = JsonUtility.ToJson(data);

                File.WriteAllText(filePath, jsonString);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("Data to write is null");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to write data: {ex.Message}");
            }
        }
    }
}