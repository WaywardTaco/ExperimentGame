using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Skill", menuName = "Scriptables/Combat/Unit Skill")]
public class UnitSkillScriptable : ScriptableObject
{
    public String SkillName;
    public String SkillTag;
    public SkillType SkillType;
}
