using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To Be Removed/Refactored => Weapon.cs
public class WeaponHandler : MonoBehaviour
{



    [Header("Weapon Type")]
    public bool LongSword;
    public bool Sword;
    public bool Axe;
    public bool Mace;

    [Header("Weapon Parameters")]
    public bool twoHanded;
    public bool canBlock;


    [Header("Attack Type")]
    public bool Piercing;
    public bool Slashing;
    public bool Bludgeoning;
    public bool Magic;

    [Header("Weapon Attack Characteristics")]
    public int basicAttack;
    public int criticalAttack;
    public int criticalAttackChance;
    public int blockBreaking;
    public int armorPiercing;
    public int Precision;

    [Header("Effects")]
    public int stun;
    public int bleeding;
    public int poisoning;

    [Header("Weapon Block Characteristics")]
    public int blockChance;



    private void Start()
    {

    }
}
