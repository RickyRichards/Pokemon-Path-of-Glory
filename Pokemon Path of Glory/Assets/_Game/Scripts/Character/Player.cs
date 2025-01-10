using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    [SerializeField] CharacterBase _Base;
    [SerializeField] int level;
    [SerializeField] int statPoint;
    [SerializeField] int addedPoints;

    public int Hp{get;set;}

    public void Init(){
        Hp = MaxHp;
    }

    public int Attack => (_Base.Attack + addedPoints);
    public int Defense => (_Base.Defense + addedPoints);
    public int SpAttack => (_Base.SpAttack + addedPoints);
    public int SpDefense => (_Base.SpDefense + addedPoints);
    public int Speed => (_Base.Speed + addedPoints);
    public int MaxHp => (_Base.MaxHp + addedPoints * 3) + 10;

    public CharacterBase Base => _Base;
    public int Level => level;
}
