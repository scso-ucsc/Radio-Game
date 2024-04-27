using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject Paused;

    public void GamePause()
    {
        Time.timeScale = 0;
        Paused.SetActive(true);
        GameIsPause = true;
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        Paused.SetActive(false);
        GameIsPause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause == true){
                GameStart();
            }else{
                GamePause();
            }
        }    
    }
}
