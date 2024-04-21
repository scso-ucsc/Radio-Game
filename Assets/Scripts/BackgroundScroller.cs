using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-5f, 5f)]
    public float speed = 1f; 

    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // divide by 10 to slow down the movement increment
        offset += (Time.deltaTime * speed) / 10f;
        // this should shift the material horizontally
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
