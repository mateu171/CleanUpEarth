using System.IO;
using UnityEngine;

public class SaveManager
{
    private readonly string _filePath = Application.persistentDataPath + "/Save.encrypted";

    private static SaveManager _instance;
    public static SaveManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SaveManager();

            return _instance;
        }
    }

    private SaveData _data;
    public SaveData Data => _data;
    public SaveManager()
    {
        GetData();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(_data);
        string encrypted = EncryptionHelper.Encrypt(json);
        File.WriteAllText(_filePath,encrypted);
    }

    public void GetData()
    {
       if (File.Exists(_filePath))
       {
            string encrypted = File.ReadAllText(_filePath);
            string dectypted = EncryptionHelper.Decrypt(encrypted);
            _data = JsonUtility.FromJson<SaveData>(dectypted);
       }
       else
        {
            _data = new SaveData();
            SaveData();
        }
    }
}
