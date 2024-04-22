using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float radioForce = 10f; //Speed of flight
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump")){ //While the SPACE button is down, player will float up
            rb.velocity = Vector2.up * radioForce;
        }

        if(Input.GetButtonUp("Jump")){
            rb.velocity = Vector2.up * 0f;
        }
    }
}
