using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Needed for using TextMeshPro

public class UI_Test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI radioForceText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        radioForceText.text = PlayerManager.instance.getRadioForce().ToString();
    }
}
