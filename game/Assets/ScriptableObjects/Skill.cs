using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="NewS kill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public Sprite activeSkill;
    public Sprite nonActiveSkill;

    public string skillName;
}
