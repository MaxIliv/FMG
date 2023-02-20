using UnityEngine;

namespace RPG.Battle
{
  [CreateAssetMenu(menuName="Battle Character/Attributes")]
  public class CharacterAttributes : ScriptableObject {
    public int initiative;
    public int strength;
    public int dexterity;
    public int intelligence;
    public int luck;
  }
}