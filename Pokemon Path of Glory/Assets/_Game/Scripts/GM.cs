using UnityEngine;
using System.IO;

public class GM : MonoBehaviour
{
    public static GM Instance;
    public TrainerData trainerData; // Assign in Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        string json = JsonUtility.ToJson(trainerData);
        File.WriteAllText(path, json);
        Debug.Log("Game Saved!");
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, trainerData);
            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Press "L" to level up
        {
            if (trainerData != null)
            {
                trainerData.TestLevelUp();
                SaveGame();
            }
        }
    }

}
