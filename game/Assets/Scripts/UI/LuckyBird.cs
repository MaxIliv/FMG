using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyBird : MonoBehaviour
{
    public Image Bird;
    public Sprite Lucky_Bird, UnLucky_Bird;

    public Color32 colorOfLuck, colorofFailure, coloroOFF;

    public void Luck()
    {
        Bird.GetComponent<Image>().sprite = Lucky_Bird;
        Bird.color = colorOfLuck;
    }
    public void Fail()
    {
        Bird.GetComponent<Image>().sprite = UnLucky_Bird;
        Bird.color = colorofFailure;
    }


    public void BirdOff()
    {
        Bird.GetComponent<Image>().sprite = UnLucky_Bird;
        Bird.color = coloroOFF;
    }
}
