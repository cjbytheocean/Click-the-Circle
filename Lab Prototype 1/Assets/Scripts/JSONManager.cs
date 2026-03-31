using UnityEngine;
using System.IO;

public class JSONManager : MonoBehaviour
{
    

    [System.Serializable]
    public class PlayerData
    {
       public float highScore = 0f; 
    }

    [System.Serializable]
    public class AllData
    {
        public PlayerData playerData;
    }

    public static JSONManager instance;
    private string filePath;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/JSONData.json";
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        string JSONOutput = JsonUtility.ToJson(GetData());
        File.WriteAllText(filePath, JSONOutput);
    }

    public AllData LoadData()
    {
        string readJSON;
        if (!File.Exists(filePath))
        {
            DefaultJSON();
        }
        readJSON = File.ReadAllText(filePath);
        AllData data = JsonUtility.FromJson<AllData>(readJSON);
        return data;
    }

    public AllData GetData()
    {
        AllData data = new AllData();
        data.playerData = new PlayerData();
        data.playerData.highScore = FindAnyObjectByType<GameBehavior>().highScore;
        return data;
    }

    void DefaultJSON()
    {
        AllData data = new AllData();

        data.playerData = new PlayerData();

        string outputJSON = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, outputJSON);
    }    
}