using System.IO;
using NUnit.Framework;
using SaveSystem;
using SaveSystem.Loaders;
using SaveSystem.Writers;
using UnityEngine;

public class MockData : IData
{
    public int _playerHealth;

    public int _enemyHealth;

    public int PlayerHealth => _playerHealth;

    public int EnemyHealth => _enemyHealth;

    public MockData(int playerHealth, int enemyHealth)
    {
        _playerHealth = playerHealth;
        _enemyHealth = enemyHealth;
    }
}

public class SaverTests
{
    private string _filePath;

    private DataLoader _loader;

    private DataWriter _writer;

    [SetUp]
    public void SetUp()
    {
        _filePath = Path.Combine(Application.persistentDataPath, "Data.json");
        _loader = new JsonDataLoader();
        _writer = new JsonDataWriter();
    }

    [Test]
    public async void Loader_LoadData_ShouldLoadData()
    {
        IData mockData = new MockData(1, 1);
        _writer.Write(mockData, _filePath);
        MockData loadedData = await _loader.Load<MockData>(_filePath);
        Assert.AreEqual(1, loadedData.PlayerHealth);
    }
}