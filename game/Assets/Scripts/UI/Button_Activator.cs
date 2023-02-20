using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Activator : MonoBehaviour
{
    public GameObject Active, Inactive;

    public bool activated;

    public string skillName;






    //references
    public Turn_Manager TM;
    public Player_Battle Player;
    public GameObject clickingArea;
    private SkillDisplay  skill;

    private void Start()
    {
        skill = GetComponent<SkillDisplay>();
        skillName = skill.skillName;

    }
    void Update()
    {
        if (!TM.playerTurn)
        {
            DeactivateSkill();
        }
    }



    public void HighlightButton()
    {
        if (!activated)
        {
            activated = true;
            clickingArea.SetActive(true);
        }
        else
        {
            SetDefaultColor();
        }
    }
    public void SetDefaultColor()
    {
        activated = false;
      //  clickingArea.SetActive(false);

    }

    public void saySkillName() // rewrite skill name for attack in Player_Battle skripta
    {
        Player.skillName = skillName;
    }

    public void ActivateSkill()
    {
        Active.SetActive(true);
        activated = true;
        clickingArea.SetActive(true);
    }
    public void DeactivateSkill()
    {
        Active.SetActive(false);
        activated = false;
        clickingArea.SetActive(false);
    }







}
