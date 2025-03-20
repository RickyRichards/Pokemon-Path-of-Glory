using System.Collections.Generic;
using UnityEngine;

public static class TypeEffectiveness
{
    // Type Effectiveness Chart: AttackingType → (DefendingType, Multiplier)
    private static readonly Dictionary<EnergyTypes, Dictionary<EnergyTypes, float>> effectivenessChart =
        new Dictionary<EnergyTypes, Dictionary<EnergyTypes, float>>()
        {
            { EnergyTypes.Normal, new Dictionary<EnergyTypes, float>
                { { EnergyTypes.Rock, 0.5f }, { EnergyTypes.Ghost, 0.0f }, { EnergyTypes.Steel, 0.5f } } },
            { EnergyTypes.Fire, new Dictionary<EnergyTypes, float>
                { { EnergyTypes.Fire, 0.5f }, { EnergyTypes.Water, 0.5f }, { EnergyTypes.Grass, 2f }, { EnergyTypes.Ice, 2f },
                  { EnergyTypes.Bug, 2f }, { EnergyTypes.Rock, 0.5f }, { EnergyTypes.Dragon, 0.5f }, { EnergyTypes.Steel, 2f } } },
            { EnergyTypes.Water, new Dictionary<EnergyTypes, float>
                { { EnergyTypes.Fire, 2f }, { EnergyTypes.Water, 0.5f }, { EnergyTypes.Grass, 0.5f }, { EnergyTypes.Ground, 2f },
                  { EnergyTypes.Rock, 2f }, { EnergyTypes.Dragon, 0.5f } } },
            { EnergyTypes.Electric, new Dictionary<EnergyTypes, float>
                { { EnergyTypes.Water, 2f }, { EnergyTypes.Electric, 0.5f }, { EnergyTypes.Grass, 0.5f }, { EnergyTypes.Ground, 0.0f },
                  { EnergyTypes.Flying, 2f }, { EnergyTypes.Dragon, 0.5f } } },
            { EnergyTypes.Grass, new Dictionary<EnergyTypes, float>
                { { EnergyTypes.Fire, 0.5f }, { EnergyTypes.Water, 2f }, { EnergyTypes.Grass, 0.5f }, { EnergyTypes.Poison, 0.5f },
                  { EnergyTypes.Ground, 2f }, { EnergyTypes.Flying, 0.5f }, { EnergyTypes.Bug, 0.5f }, { EnergyTypes.Rock, 2f },
                  { EnergyTypes.Dragon, 0.5f }, { EnergyTypes.Steel, 0.5f } } },
            { EnergyTypes.Ice, new Dictionary<EnergyTypes, float>
                { { EnergyTypes.Fire, 0.5f }, { EnergyTypes.Water, 0.5f }, { EnergyTypes.Grass, 2f }, { EnergyTypes.Ice, 0.5f },
                  { EnergyTypes.Ground, 2f }, { EnergyTypes.Flying, 2f }, { EnergyTypes.Dragon, 2f }, { EnergyTypes.Steel, 0.5f } } },
            { EnergyTypes.Fighting, new Dictionary<EnergyTypes, float>
                { { EnergyTypes.Normal, 2f }, { EnergyTypes.Ice, 2f }, { EnergyTypes.Rock, 2f }, { EnergyTypes.Dark, 2f }, { EnergyTypes.Steel, 2f },
                  { EnergyTypes.Poison, 0.5f }, { EnergyTypes.Flying, 0.5f }, { EnergyTypes.Psychic, 0.5f }, { EnergyTypes.Bug, 0.5f },
                  { EnergyTypes.Ghost, 0.0f }, { EnergyTypes.Fairy, 0.5f } } },
            // 🔥 Continue filling out chart for all types...
        };

    // Get effectiveness multiplier
    public static float GetEffectiveness(EnergyTypes attackType, EnergyTypes defenseType)
    {
        if (effectivenessChart.ContainsKey(attackType) && effectivenessChart[attackType].ContainsKey(defenseType))
        {
            return effectivenessChart[attackType][defenseType];
        }
        return 1f; // Neutral by default
    }
}
