using UnityEngine;
using RPG.Battle;

namespace RPG.Control 
{
  [RequireComponent(typeof(BattleCharacter))]
  public class PlayerController : MonoBehaviour {
    [SerializeField] GameObject enemy; // tmp for test

    [SerializeField] float timeSinceLastAttack = 0f;
    [SerializeField] float timeBetweenAttack = 3f;
    [SerializeField] BattleState attackState;

    Fighter fighter;
    BattleCharacter battleCharacter;

    public bool CanAttack
    {
      get { return timeSinceLastAttack >= timeBetweenAttack; }
    }

    void Update()
    {
      timeSinceLastAttack += Time.deltaTime;
    }

    void Awake()
    {
      fighter = GetComponent<Fighter>();
      battleCharacter = GetComponent<BattleCharacter>();
    }

    public void Hit()
    {
      if (battleCharacter.TurnManager.state != attackState) return;

      if (CanAttack)
      {
        fighter.Hit();
        timeSinceLastAttack = 0f;
      }
    }
  }
}