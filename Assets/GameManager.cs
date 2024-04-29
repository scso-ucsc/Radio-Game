using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver;
    private float playerScore;

    public GameObject Ending;

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
        if(isGameOver == false){
            playerScore += 1.0f * Time.deltaTime;
        }
        if (isGameOver)
        {
            Ending.SetActive(true);
        }
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
