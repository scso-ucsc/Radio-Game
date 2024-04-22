using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        float moveAmount = moveSpeed * Time.deltaTime;

        transform.Translate(Vector3.left * moveAmount);
    }
}
