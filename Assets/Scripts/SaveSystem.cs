using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    static string path = Application.persistentDataPath + "/game_session.trs";

    public static void SaveGameSession(GameSession gameSession)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameSession);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGameSession()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("Save file is not in " + path);
            return null;
        }
    }

    public static void DeleteSaved()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
