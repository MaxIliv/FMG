using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator_Handler : MonoBehaviour
{
    public GameObject Dice;
    public GameObject SandClock;

    private Animator _diceAnim, _sand_Anim;

    [Header("States")]
    public bool NoSkillsSelected;
    public bool SkillSelected;
    public bool EnemyTurn;
    public bool MakeAction;
    public bool SkipTurn;


    public List<string> slillNames = new List<string>();

    public Image activeImage;

    [Header("References")]
    public WeaponHandler weapon;
    public Turn_Manager TM;

    [Header("SkillIcons")]
    public Image[] skillIcons;


    private void Awake()
    {
        _diceAnim = Dice.GetComponent<Animator>();
        _sand_Anim = SandClock.GetComponent<Animator>();
    }

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DiceRoll()
    {
        _diceAnim.SetTrigger("roll");
        
    }


    public void SetSkillIcon()
    {

    }
}
