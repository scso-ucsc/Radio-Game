using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float radioVolume = 5.0f; //Speed of flight (Min: 5.0f, Max 25.0f)
    [SerializeField] private GameObject shockwaveObj;
    [SerializeField] private Transform shockwaveSpawnLocation;
    private bool playerHasAmmo, isFiring;

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
        radioVolume = 5.0f;
        playerHasAmmo = true; //Starts game with ammo
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.getGameOverStatus() == false){
            if(radioVolume > 0){ //Add upwards force to player based on radio volume
                rb.velocity = Vector2.up * radioVolume;
            } else{
                rb.velocity = Vector2.up * 0f;
            }

            if(Input.GetKeyDown(KeyCode.Space) && playerHasAmmo){
                AudioManager.instance.playPlayerSound("shockwave");
                fireShockWave();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collider){ //If player touches water below them or hits an obstacle, inform GameManager isGameOver = true
        if(collider.gameObject.tag == "Water"){
            AudioManager.instance.playPlayerSound("water");
            GameManager.instance.gameOver();
        } else if(collider.gameObject.tag == "Obstacle"){
            AudioManager.instance.playPlayerSound("hurt");
            GameManager.instance.gameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){ //If player collides with battery, regain ammo
        if(collider.gameObject.tag == "Battery"){
            AudioManager.instance.playPlayerSound("battery");
            collider.gameObject.SetActive(false);
            playerHasAmmo = true;
        }
    }

    public void onSliderChanged(float value){ //Update Radio Volume upon slider change
        radioVolume = value;
    }

    public float getRadioForce(){ //For UI
        return radioVolume;
    }

    private void fireShockWave(){
        isFiring = true;
        shockwaveObj.transform.position = shockwaveSpawnLocation.position;
        shockwaveObj.SetActive(true);
        playerHasAmmo = false;
    }

    public bool getIsFiringStatus(){ //For UI Manager
        return isFiring;
    }

    public void switchIsFiringOff(){ //For shockwave
        isFiring = false;
    }

    public bool getPlayerHasAmmo(){ //For UI Manager
        return playerHasAmmo;
    }
}
