using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Stats", menuName = "Scriptables/Combat/Unit Stats")]
public class UnitStatsScriptable : ScriptableObject 
{
    public int MaxHealth;
    public int StaminaDiceCount;
    public int Attack;
    public int SpecialAttack;
    public int Defense;
    public int SpecialDefense;
    public int Speed;
    public int Luck;

    public List<UnitSkillScriptable> Skills = new();
}
