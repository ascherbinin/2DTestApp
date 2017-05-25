using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
 
public static class SaveLoadManager
{

    public static void Save(int id, int leftCounter, int rightCounter)
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.gd");
        GameInfo gi = new GameInfo(id, leftCounter, rightCounter);
        bf.Serialize(file,gi);
        file.Close();
    }

    public static GameInfo Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.gd", FileMode.Open);
            var gi = (GameInfo)bf.Deserialize(file);
            file.Close();
            return gi;
        }
        return null;
    }
}
