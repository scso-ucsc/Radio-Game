using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kite : MonoBehaviour
{
    private Rigidbody2D rb;
    private string direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = "down";
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Vector2.left * Time.deltaTime * 3f); //Moving kite left
    }

    IEnumerator changeFloatDirection(){
        while(GameManager.instance.getGameOverStatus() == false){
            yield return new WaitForSeconds(1f);
            if(direction == "down"){ //Switching float direction based on current
                rb.velocity = Vector2.zero;
                rb.velocity = Vector2.down * 1;
                direction = "up";
            } else{
                rb.velocity = Vector2.zero;
                rb.velocity = Vector2.up * 1;
                direction = "down";
            }
        }
    }

    public void restartFloatCoroutine(){ //Restarting float coroutine if kite obj was initially deactive
        StartCoroutine(changeFloatDirection());
    }
}
