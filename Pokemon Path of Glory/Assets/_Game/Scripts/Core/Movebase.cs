using UnityEngine;

[CreateAssetMenu(menuName = "Pokemon/Create New Move")]
public class Movebase : ScriptableObject
{
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] EnergyTypes type;

    [SerializeField] int baseDamage;
    [SerializeField] int ac;
    [SerializeField] string fequency;
    [SerializeField] int rollDamage;
    [SerializeField] int numberOfRoll;
    [SerializeField] int actDamage;

    public string Name => name;
    public string Description => description;
    public string Fequency => fequency;
    public EnergyTypes Type => type;
    public int BaseDamage => baseDamage;
    public int AC => ac;
    public int RollDamage => rollDamage;
    public int NumberOfRoll => numberOfRoll;
    public int ActDamage => actDamage;


}
