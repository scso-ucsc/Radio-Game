using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float radioForce = 5.0f; //Speed of flight (Min: 5.0f, Max 10.0f)
    [SerializeField] private LayerMask groundLayer;
    private bool soarStatus;

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
        soarStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump")){ //While the SPACE button is down, player will float up
            rb.velocity = Vector2.up * radioForce;
            soarStatus = true;
        }
        if(Input.GetButtonUp("Jump")){
            rb.velocity = Vector2.up * 0f;
            soarStatus = false;
        }
    }

    public bool returnSoarStatus(){ //For future AudioManager
        return soarStatus;
    }
}
