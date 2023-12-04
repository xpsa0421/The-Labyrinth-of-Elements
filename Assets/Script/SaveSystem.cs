using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{

    public static void SavePlayer(Player player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+"/player.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        // Debug.Log("System saves Level"+data.level);
        // Debug.Log("System saves Health"+data.health);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        Debug.Log("Loading data from file...");
        string path = Application.persistentDataPath+"/player.dat";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            Debug.Log("System loads Level"+data.level);
            stream.Close();
            return data;

        }else{
            Debug.LogError("Save file not found in"+path);
            return null;
        }
    }

}
