using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float radioVolume = 5.0f; //Speed of flight (Min: 5.0f, Max 25.0f)
    [SerializeField] private LayerMask groundLayer;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(radioVolume > 0){ //Add upwards force to player based on radio volume
            rb.velocity = Vector2.up * radioVolume;
        } else{
            rb.velocity = Vector2.up * 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider){ //If player touches water below them, GAME OVER!!!
        if(collider.gameObject.tag == "Water"){
            Debug.Log("Game Over!!!");
        }
    }

    public void onSliderChanged(float value){ //Update Radio Volume upon slider change
        radioVolume = value;
    }

    public float getRadioForce(){ //For UI
        return radioVolume;
    }
}
