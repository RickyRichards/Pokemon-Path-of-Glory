// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;

// public class Pokemon 
// {
//     [SerializeField] Pokemonbase _Base;
//     [SerializeField] int level;
//     [SerializeField] int statPoint;
//     int addedPoints;

//     public int Hp {get;set;}
//     public List<Move> Moves{get;set;}

//     public void Init(){
//         Hp = MaxHp;

//         foreach(var move in _Base.LearnableMoves.OrderByDescending(m => m.Level)){
//             if (move.Level <= level){
//                 Moves.Add(new Move(move.Movebase));
//             }
//             break;
//         }
//     }

//     public int Attack => (_Base.Attack + addedPoints);
//     public int Defense => (_Base.Defense + addedPoints);
//     public int SpAttack => (_Base.SpAttack + addedPoints);
//     public int SpDefense => (_Base.SpDefense + addedPoints);
//     public int Speed => (_Base.Speed + addedPoints);
//     public int MaxHp => (_Base.MaxHp + addedPoints * 3) + 10;


//     public Pokemonbase Base => _Base;
//     public int Level => level;
// }
