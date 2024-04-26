using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x <= -11.5){ //Deactivating gameObject if it goes off screen
            this.gameObject.SetActive(false);
        }
    }
}
