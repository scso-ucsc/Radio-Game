using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // public void MoveToScene(int sceneID){
    //     SceneManager.LoadScene(sceneID);
    // }

    public void MoveToHomeScene(){
        SceneManager.LoadScene("Menu");
    }

    public void MoveToPlayScene(){
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
