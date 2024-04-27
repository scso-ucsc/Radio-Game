using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //To access Slider variable

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource radioMusic; //Background Music
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
        radioMusic.Play(); //Playing Background Music
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeVolume(){
        if(volumeSlider.value == 0){ //For the sake of realism, if audio slider is at 0, then volume will be 0
            AudioListener.volume = 0;
        } else{
            AudioListener.volume = 0.5f + (volumeSlider.value / 10.0f); //Adjusting volume based on slider
        }
    }
}
