using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introduce : MonoBehaviour
{
    public GameObject buttom;
    public GameObject Introduce;

    // Start is called before the first frame update
    // void Start()
    // {
    //     buttom.SetActive(true);
    //     Introduce.SetActive(false);
    // }

    public void Intro_close(){
        buttom.SetActive(true);
        Introduce.SetActive(false);
    }

    public void Intro_open(){
        buttom.SetActive(false);
        Introduce.SetActive(true);
    }
}
