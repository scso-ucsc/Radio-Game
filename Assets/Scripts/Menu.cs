using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject Paused;
    public GameObject P2_paused;

    public void GamePause()
    {
        Time.timeScale = 0;
        Paused.SetActive(true);
        GameIsPause = true;
        P2_paused.SetActive(false);
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        Paused.SetActive(false);
        GameIsPause = false;
        P2_paused.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause == true){
                GameStart();
            }else if (GameIsPause == false){
                GamePause();
            }
        }    
    }
}
