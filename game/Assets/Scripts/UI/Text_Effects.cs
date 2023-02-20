using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Effects : MonoBehaviour
{
    public Animator textEffectAnimator;

    public int damage;
    public Text _damage;
    public Text _damageArmor;

    public void Critical()
    {
        textEffectAnimator.SetTrigger("Critical");
    }
    public void Missed()
    {
        textEffectAnimator.SetTrigger("Missed");
    }
    public void Blocked()
    {
        textEffectAnimator.SetTrigger("Blocked");
    }

    public void DamageValue(int value)
    {
        _damage.text = "- " + value.ToString();
        textEffectAnimator.SetTrigger("Damage");
    }

    public void DamageArmorValue()
    {

        _damageArmor.text = "- " + damage.ToString();
        textEffectAnimator.SetTrigger("DamageArmor");
    }

    public void Show(BattleState state)
    {
        if (state == BattleState.WON)
        {
            Debug.Log("[Text Effects] Show Won");
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("[Text Effects] Show Lost");
        }
    }
}
