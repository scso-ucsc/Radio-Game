using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver;
    private float playerScore;

    void Awake(){
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerScore += 1.0f * Time.deltaTime;
    }

    public void gameOver(){
        isGameOver = true;
    }

    public bool getGameOverStatus(){
        return isGameOver;
    }

    public int getPlayerScore(){
        return (int)playerScore;
    }
}
