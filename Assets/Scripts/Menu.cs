using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        Time.timeScale = 1;
    }
}
