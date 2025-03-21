using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM Instance { get; private set; }

    public TrainerData PlayerTrainer;
    public List<PokemonData> PlayerPokemonTeam = new List<PokemonData>(); // Player's Pokémon

    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/saveData.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            trainerData = JsonUtility.ToJson(PlayerTrainer),
            playerPokemon = new List<string>()
        };

        foreach (var pokemon in PlayerPokemonTeam)
        {
            data.playerPokemon.Add(JsonUtility.ToJson(pokemon));
        }

        File.WriteAllText(savePath, JsonUtility.ToJson(data));
        Debug.Log("Game Saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            JsonUtility.FromJsonOverwrite(data.trainerData, PlayerTrainer);
            PlayerPokemonTeam.Clear();

            foreach (var pokemonJson in data.playerPokemon)
            {
                PokemonData newPokemon = new PokemonData();
                JsonUtility.FromJsonOverwrite(pokemonJson, newPokemon);
                PlayerPokemonTeam.Add(newPokemon);
            }

            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.LogWarning("No save file found!");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public string trainerData;
    public List<string> playerPokemon;
}
