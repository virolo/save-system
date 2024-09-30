using System;
using System.IO;
using SaveSystem.Loaders;
using SaveSystem.Writers;
using UnityEngine;

namespace SaveSystem
{
    public class SaveSystem<T> : IDisposable  where T : IData, new()
    {
        private readonly Saver _saver;

        private readonly string _filePath;

        private LoadableMonoBehaviour[] _loadableMonoBehaviour;
    
        private SaveSystem(string fileName, DataLoader dataLoader, DataWriter dataWriter)
        {
            _filePath = Path.Combine(Application.persistentDataPath, fileName);
            _saver = new Saver(dataLoader, dataWriter);
        }

        public void Dispose()
        {
            Save();
        }

        public async void Load(LoadableMonoBehaviour[] loadableMonoBehaviours)
        {
            _loadableMonoBehaviour = loadableMonoBehaviours;
            T gameData = await _saver.Load<T>(_filePath);
            
            foreach (LoadableMonoBehaviour loadableMonoBehaviour in _loadableMonoBehaviour)
            {
                loadableMonoBehaviour.LoadData(gameData);
            }
        }

        private void Save()
        {
            IData gameData = new T();
            
            foreach (LoadableMonoBehaviour loadableMonoBehaviour in _loadableMonoBehaviour)
            {
                loadableMonoBehaviour.WriteData(ref gameData);
            }

            _saver.Write(gameData, _filePath);
        }
    }
}