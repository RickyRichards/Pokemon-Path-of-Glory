using UnityEngine;

public static class SkillUtility
{
    //get the correct number of d6s for the skillrank
    public static int GetSkillDice(SkillRank skill){
        switch(skill){
            case SkillRank.Untrained: return 1;
            case SkillRank.Novice: return 2;
            case SkillRank.Adept: return 3;
            case SkillRank.Apprentice: return 4;
            case SkillRank.Expert: return 5;
            case SkillRank.Master: return 6;
            case SkillRank.Legendary: return 7;
            case SkillRank.Virtuoso: return 8;
            default: return 1;
        }
    }
    // roll the correct number based on skill rank
    public static int RollSkill(SkillRank skill){
        int diceCount = GetSkillDice(skill);
        int total = 0;

        for (int i = 0; i< diceCount; i++){
            total += Random.Range(1, 7);// roll d6 (1-6)
        }

        return total;
    }
}
