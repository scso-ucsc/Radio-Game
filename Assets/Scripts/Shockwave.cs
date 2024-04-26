using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 1); //This will cause the shockwave object to become exponentially faster
        if(this.gameObject.transform.position.x >= 11){ //If shockwave gameObject goes off screen, deactivate and reset velocity to 0
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collider){ //If shockwave hits obstacle, destroy it
        if(collider.gameObject.tag == "Obstacle"){
            //Destroy Obstacle
        }
    }
}
