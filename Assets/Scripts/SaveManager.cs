using System.IO;
using UnityEngine;

public class SaveManager
{
    private readonly string _filePath;

    public SaveManager()
    {
        _filePath = Application.persistentDataPath + "/Save.json";

        if (!File.Exists(_filePath))
            File.Create(_filePath).Close();
    }

    public void SaveData(SaveData saveData)
    {
        string json = JsonUtility.ToJson(saveData);
        using(var writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(json);
        }
    }

    public SaveData GetData()
    {
        string json = "";
        using(var reader = new StreamReader(_filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                json += line;
            }
        }
        if (string.IsNullOrEmpty(json))
            return new SaveData();
        return JsonUtility.FromJson<SaveData>(json);
    }
}
