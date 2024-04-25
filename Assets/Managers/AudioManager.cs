using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //To access Slider variable

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private Slider volumeSlider;

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
        
    }

    public void changeVolume(){
        AudioListener.volume = volumeSlider.value;
    }
}
