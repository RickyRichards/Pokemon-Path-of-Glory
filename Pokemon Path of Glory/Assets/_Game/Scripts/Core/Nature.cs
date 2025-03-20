using System.Collections.Generic;
using UnityEngine;

public enum Nature
{
    Cuddly, Distracted, Proud, Decisive, Patient,
    Desperate, Lonely, Adamant, Naughty, Brave,
    Stark, Bold, Impish, Lax, Relaxed,
    Curious, Modest, Mild, Rash, Quiet,
    Dreamy, Calm, Gentle, Careful, Sassy,
    Skittish, Timid, Hasty, Jolly, Naive,
    Composed, Hardy, Docile, Bashful, Quirky, Serious
}

// Helper class to store Nature effects and flavor preferences
public static class NatureEffects
{
    private static readonly Dictionary<Nature, (string raise, string lower, string like, string dislike)> natureData =
        new Dictionary<Nature, (string, string, string, string)>
        {
            { Nature.Cuddly, ("HP", "Attack", "Salty", "Spicy") },
            { Nature.Distracted, ("HP", "Defense", "Salty", "Sour") },
            { Nature.Proud, ("HP", "Special Attack", "Salty", "Dry") },
            { Nature.Decisive, ("HP", "Special Defense", "Salty", "Bitter") },
            { Nature.Patient, ("HP", "Speed", "Salty", "Sweet") },
            { Nature.Desperate, ("Attack", "HP", "Spicy", "Salty") },
            { Nature.Lonely, ("Attack", "Defense", "Spicy", "Sour") },
            { Nature.Adamant, ("Attack", "Special Attack", "Spicy", "Dry") },
            { Nature.Naughty, ("Attack", "Special Defense", "Spicy", "Bitter") },
            { Nature.Brave, ("Attack", "Speed", "Spicy", "Sweet") },
            { Nature.Stark, ("Defense", "HP", "Sour", "Salty") },
            { Nature.Bold, ("Defense", "Attack", "Sour", "Spicy") },
            { Nature.Impish, ("Defense", "Special Attack", "Sour", "Dry") },
            { Nature.Lax, ("Defense", "Special Defense", "Sour", "Bitter") },
            { Nature.Relaxed, ("Defense", "Speed", "Sour", "Sweet") },
            { Nature.Curious, ("Special Attack", "HP", "Dry", "Salty") },
            { Nature.Modest, ("Special Attack", "Attack", "Dry", "Spicy") },
            { Nature.Mild, ("Special Attack", "Defense", "Dry", "Sour") },
            { Nature.Rash, ("Special Attack", "Special Defense", "Dry", "Bitter") },
            { Nature.Quiet, ("Special Attack", "Speed", "Dry", "Sweet") },
            { Nature.Dreamy, ("Special Defense", "HP", "Bitter", "Salty") },
            { Nature.Calm, ("Special Defense", "Attack", "Bitter", "Spicy") },
            { Nature.Gentle, ("Special Defense", "Defense", "Bitter", "Sour") },
            { Nature.Careful, ("Special Defense", "Special Attack", "Bitter", "Dry") },
            { Nature.Sassy, ("Special Defense", "Speed", "Bitter", "Sweet") },
            { Nature.Skittish, ("Speed", "HP", "Sweet", "Salty") },
            { Nature.Timid, ("Speed", "Attack", "Sweet", "Spicy") },
            { Nature.Hasty, ("Speed", "Defense", "Sweet", "Sour") },
            { Nature.Jolly, ("Speed", "Special Attack", "Sweet", "Dry") },
            { Nature.Naive, ("Speed", "Special Defense", "Sweet", "Bitter") }
        };

    public static (string raise, string lower, string like, string dislike) GetNatureEffects(Nature nature)
    {
        if (natureData.ContainsKey(nature))
        {
            return natureData[nature];
        }
        return ("None", "None", "None", "None");
    }
}
