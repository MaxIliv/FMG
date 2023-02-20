using UnityEngine;
using RPG.Battle;
using RPG.Control;

namespace RPG.InputSystem
{
  public class SwipeHandler : MonoBehaviour {
    [SerializeField] TrailRenderer trail;

    GameObject player;
    PlayerController playerController;
    GameObject GameMaster;
    TurnManager TurnManager;

    void Awake()
    {
      player = GameObject.FindGameObjectWithTag("Player");
      playerController = player.GetComponent<PlayerController>();

      GameMaster = GameObject.FindGameObjectWithTag("GM");
      TurnManager = GameMaster.GetComponent<TurnManager>();
    }

    void Update()
    {
      if (TurnManager.state != BattleState.PLAYER_TURN) return;
      if (playerController.CanAttack == false) return;
      if (Input.touchCount <= 0) return;

      Touch touch = Input.GetTouch(0);
      Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
  
      if (touch.phase == TouchPhase.Began) ResetTrail(pos);
      
      trail.transform.position = pos;

      if (touch.phase == TouchPhase.Ended)
      {
        playerController.Hit();
      }
    }

    // reset trail last position
    void ResetTrail(Vector2 pos)
    {
      trail.gameObject.SetActive(false);
      TrailRenderer[] trails = trail.gameObject.GetComponentsInChildren<TrailRenderer>();
      foreach (TrailRenderer t in trails)
      {
        t.Clear();
      }
      trail.transform.position = pos;
      trail.gameObject.SetActive(true);
    }
  }
}