using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{

    public int randomValue;


    //public Text text;
    public Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Roll()
    {
        randomValue = Random.Range(1, 21);
      //  Debug.Log(randomValue);

      //  text.text = randomValue.ToString();

        anim.SetTrigger("roll");
    }
}
