using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActionPlayer : MonoBehaviour
{
    public Player_Battle plyerScript;

    public Indicator_Handler IH;

    void Awake()
    {
        plyerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Battle>();
    }

    public void Action ()
    {
        
        IH.DiceRoll();

        plyerScript.actionMade = true;
        plyerScript.Attack();
       // gameObject.SetActive(false);
        
    }


}
