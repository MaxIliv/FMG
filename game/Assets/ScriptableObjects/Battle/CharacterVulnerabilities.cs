using UnityEngine;

namespace RPG.Battle
{
  [CreateAssetMenu(menuName="Battle Character/Vulnerabilities")]
  public class CharacterVulnerabilities : ScriptableObject {
    public int toPiercing;
    public int toSlashing;
    public int toBludgeoning;
    public int toMagic;
  }
}