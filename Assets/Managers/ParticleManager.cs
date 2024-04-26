using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleManager : MonoBehaviour
{
    private static ParticleManager instance;
    [SerializeField] private GameObject audioParticleSource;
    private ParticleSystem audioParticles;
    [SerializeField] private Slider volumeSlider;
    private float emissionRate = 5.0f;

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
        audioParticles = audioParticleSource.GetComponent<ParticleSystem>(); //Accessing Particle System
        StartCoroutine(emitAudioParticles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator emitAudioParticles(){ //Depending on current volume, fire audio particles
        while(GameManager.instance.getGameOverStatus() == false){
            emissionRate = volumeSlider.value;
            yield return new WaitForSeconds(1.1f - (emissionRate / 10.0f));
            audioParticles.Play();
        }
    }
}
