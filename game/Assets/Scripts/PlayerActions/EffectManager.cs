using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public Animator UIAnim;

    public GameObject healingEffect;
    public GameObject lowHealthEffect;

    public Transform effectPos;
    public Transform cameraHolder;

    public Player_Battle player;
    int healthPercent;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Battle>();
    }

    void Start()
    {
       healthPercent = player.MaxHealth / 100 * 15; // define when low health effect will be shown

    }

    // Update is called once per frame
    void Update()
    {
        LowHealthPlayer();
    }

    public void healing()
    {
        Quaternion targetRotation = Quaternion.Euler(cameraHolder.transform.eulerAngles);

        UIAnim.SetTrigger("Healing");
        Instantiate(healingEffect, effectPos.position, targetRotation, effectPos.transform);
    }

    public void LowHealthPlayer()
    {
        if (player.health <= healthPercent)
        {
            lowHealthEffect.SetActive(true);
        }
        else
        {
            lowHealthEffect.SetActive(false);
        }
    }
}
