using UnityEngine;
using RPG.Battle;

namespace RPG.Control
{
  [RequireComponent(typeof(BattleCharacter))]
  public class AIController : MonoBehaviour {
    [SerializeField] float timeSinceLastAttack = 0f;
    [SerializeField] float timeBetweenAttack = 3f;
    [SerializeField] BattleState attackState;
    
    Fighter fighter;
    BattleCharacter battleCharacter;

    void Awake()
    {
      fighter = GetComponent<Fighter>();
      battleCharacter = GetComponent<BattleCharacter>();
    }

    void Update()
    {
      timeSinceLastAttack += Time.deltaTime;
      if (battleCharacter.TurnManager.state != attackState) return;

      if (timeSinceLastAttack >= timeBetweenAttack)
      {
        fighter.Hit();
        timeSinceLastAttack = 0f;
      }
    }
  }
}
