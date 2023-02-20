using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDisplay : MonoBehaviour
{
    public Skill skill;

    public Image nonActiveSkill;
    public Image activeSkill;
    public string skillName;

    public GameObject Active, Inactive;
    public bool activated;


    [Header("References")]
    private GameObject GameMaster;
    private GameObject thePlayer;
    private UI_Manager ui_manager;
    public Turn_Manager TM;
    public Player_Battle Player;
    public GameObject clickingArea;

    void Awake()
    {
        activeSkill.sprite = skill.activeSkill;
        nonActiveSkill.sprite = skill.nonActiveSkill;

        skillName = skill.skillName;

        GameMaster = GameObject.FindGameObjectWithTag("GM");
        TM = GameMaster.GetComponent<Turn_Manager>();

        thePlayer = GameObject.FindGameObjectWithTag("Player");
        Player = thePlayer.GetComponent<Player_Battle>();

        clickingArea = GameObject.FindGameObjectWithTag("AA");

        ui_manager = GameMaster.GetComponent<UI_Manager>();
    }

    private void Start()
    {
        clickingArea.SetActive(false);
    }

    void Update()
    {
        if (!TM.playerTurn)
        {
            clickingArea.SetActive(false);
            activeSkill.enabled = false;
            activated = false;
            ui_manager.skillActivated = false;
        }
    }



    public void HighlightButton()
    {
        if (!activated)
        {
            // activated = true;

            activeSkill.enabled = true;
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
        if (!activated && !ui_manager.skillActivated)
        {


            ui_manager.skillActivated = true;
            clickingArea.SetActive(true);
            activeSkill.enabled = true;
            activated = true;

        }
        else if (activated)
        {
            clickingArea.SetActive(false);
            activeSkill.enabled = false;
            activated = false;

            ui_manager.skillActivated = false;
        }

    }



}
