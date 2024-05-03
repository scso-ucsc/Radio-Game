using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    private List<GameObject> cloudList = new List<GameObject>();
    private List<GameObject> seagullList = new List<GameObject>();
    [SerializeField] private GameObject cloudObj, batteryObj, seagullObj, seaplaneObj, kiteObj;
    [SerializeField] private Transform cloudParent, seagullParent;
    private float seagullSpawnTime, seaplaneSpawnTime, kiteSpawnTime;

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
        //Defining Initial Spawn Times
        seagullSpawnTime = 2.0f;
        seaplaneSpawnTime = 6.0f;
        kiteSpawnTime = 7.5f;

        for(int i = 0; i < 3; i++){ //Instantiating Clouds
            Vector3 spawnPoint = new Vector3(0, 0, 0);
            GameObject cloud = Instantiate(cloudObj, spawnPoint, Quaternion.Euler(0, 0, 0), cloudParent);
            cloud.SetActive(false);
            cloudList.Add(cloud);
        }

        for(int i = 0; i < 10; i++){ //Instantiating Seagulls
            Vector3 spawnPoint = new Vector2(0, 0);
            GameObject seagull = Instantiate(seagullObj, spawnPoint, Quaternion.Euler(0, 0, 0), seagullParent);
            seagull.SetActive(false);
            seagullList.Add(seagull);
        }

        StartCoroutine(spawnClouds());
        StartCoroutine(spawnBattery());
        StartCoroutine(spawnSeagulls());
        StartCoroutine(spawnSeaplane());
        StartCoroutine(spawnKite());
        StartCoroutine(increaseDifficulty());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnClouds(){
        while(GameManager.instance.getGameOverStatus() == false){
            yield return new WaitForSeconds(3.0f);
            Vector3 spawnLocation = new Vector3(12.5f, Random.Range(-1.13f, 3.65f), 1f); //Generating random spawn point

            GameObject chosenCloud = getObject("cloud");
            if(chosenCloud != null){
                chosenCloud.transform.position = spawnLocation;
                chosenCloud.SetActive(true);
            }
        }
    }

    IEnumerator spawnSeagulls(){
        while(GameManager.instance.getGameOverStatus() == false){
            yield return new WaitForSeconds(seagullSpawnTime);
            Vector3 spawnLocation = new Vector2(10.5f, Random.Range(-1.3f, 3.6f)); //Generating random spawn point

            GameObject chosenSeagull = getObject("seagull");
            if(chosenSeagull != null){
                chosenSeagull.transform.position = spawnLocation;
                chosenSeagull.SetActive(true);
                chosenSeagull.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
            }
        }
    }

    private GameObject getObject(string desiredObject){ //Returns desired game object depending on inputted string
        if(desiredObject == "cloud"){
            for(int i = 0; i < cloudList.Count; i++){ //Finding current inactive cloud in hierarchy
                if(!cloudList[i].activeInHierarchy){
                    return cloudList[i];
                }
            }
        } else if(desiredObject == "seagull"){
            for(int i = 0; i < seagullList.Count; i++){ //Finding current inactive seagull in hierarchy
                if(!seagullList[i].activeInHierarchy){
                    return seagullList[i];
                }
            }
        }
        return null;
    }

    IEnumerator spawnBattery(){
        while(GameManager.instance.getGameOverStatus() == false){
            yield return new WaitForSeconds(10.0f); //Spawn the battery every 10 seconds
            batteryObj.transform.position = new Vector2(10.5f, Random.Range(-2.25f, 3.45f)); //Resetting position of battery
            batteryObj.SetActive(true);
            batteryObj.GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
        }
    }

    IEnumerator spawnSeaplane(){
        while(GameManager.instance.getGameOverStatus() == false){
            yield return new WaitForSeconds(seaplaneSpawnTime); //Sending seaplane
            seaplaneObj.transform.position = new Vector2(11.5f, Random.Range(-2.25f, 3.45f));
            seaplaneObj.SetActive(true);
            seaplaneObj.GetComponent<Rigidbody2D>().velocity = Vector2.left * 7;
        }
    }

    IEnumerator spawnKite(){
        while(GameManager.instance.getGameOverStatus() == false){
            yield return new WaitForSeconds(kiteSpawnTime); //Sending kite
            if(!kiteObj.activeInHierarchy){ //Reactivating kiteObj if inactive
                kiteObj.SetActive(true);
                var kiteScript = kiteObj.gameObject.GetComponent<Kite>(); //Accessing Kite Script on kiteObj
                kiteScript.restartFloatCoroutine(); //Calling restartFloatCoroutine() function in Kite Script
            }
            kiteObj.transform.position = new Vector2(10.5f, Random.Range(-1.5f, 2.15f));
        }
    }

    IEnumerator increaseDifficulty(){
        if(GameManager.instance.getGameOverStatus() == false){
            yield return new WaitForSeconds(10.0f); //Difficulty increases every 10 seconds
            if(seagullSpawnTime > 0.25f){ //Lower spawn time = faster spawn rate
                seagullSpawnTime -= 0.25f;
            }
            if(seaplaneSpawnTime > 4.0f){
                seaplaneSpawnTime -= 0.5f;
            }
        }
    }
}
