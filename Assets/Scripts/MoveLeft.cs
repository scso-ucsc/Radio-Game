using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.getGameOverStatus() == false){
            float moveAmount = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.left * moveAmount);
        }

        if(this.gameObject.transform.position.x <= -13.85){
            this.gameObject.SetActive(false);
        }
    }
}
