using UnityEngine;

namespace RPG.Battle
{
  [CreateAssetMenu(menuName="Battle Character/Ignore Damage")]
  public class CharacterIgnoreDamage : ScriptableObject {
    public int toPiercing;
    public int toSlashing;
    public int toBludgeoning;
    public int toMagic;   
  }
}