using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBattleHandler : MonoBehaviour
{
    public GameObject winPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void youWin()
    {
        winPanel.SetActive(true);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Test_Fight");
    }
}
