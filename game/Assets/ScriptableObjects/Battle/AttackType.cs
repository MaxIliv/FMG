using UnityEngine;

namespace RPG.Battle
{
  [CreateAssetMenu(menuName="Battle Character/Attack Type")]
  public class AttackType : ScriptableObject {
    public bool Piercing;
    public bool Slashing;
    public bool Bludgeoning;
    public bool Magic;
  }
}