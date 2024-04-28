using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject onButton, offButton, pauseButton, playButton;

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
        onButton.SetActive(true); //Setting UI Buttons
        offButton.SetActive(false);
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.instance.getPlayerScore().ToString();
        
        if(PlayerManager.instance.getPlayerHasAmmo() == true){ //Updating on-off button when player has ammo
            onButton.SetActive(true);
            offButton.SetActive(false);
        } else{ //PlayerManager.instance.getPlayerHasAmmo() == false
            onButton.SetActive(false);
            offButton.SetActive(true);
        }

        if(PlayerManager.instance.getIsFiringStatus() == true){
            pauseButton.SetActive(false);
            playButton.SetActive(true);
        } else{ //PlayerManager.instance.getIsFiringStatus() == false
            pauseButton.SetActive(true);
            playButton.SetActive(false);
        }
    }
}
