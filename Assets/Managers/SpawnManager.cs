using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    private List<GameObject> cloudList = new List<GameObject>();
    [SerializeField] private GameObject cloudObj;
    [SerializeField] private Transform cloudParent;

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
        for(int i = 0; i < 3; i++){ //Instantiating Clouds
            Vector3 spawnPoint = new Vector3(0, 0, 0);
            GameObject cloud = Instantiate(cloudObj, spawnPoint, Quaternion.Euler(0, 0, 0), cloudParent);
            cloud.SetActive(false);
            cloudList.Add(cloud);
        }

        StartCoroutine(spawnClouds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnClouds(){
        while(GameManager.instance.getGameOverStatus() == false){
            yield return new WaitForSeconds(3.0f);
            Vector3 spawnLocation = new Vector3(12.5f, Random.Range(-1.13f, 3.65f), 9f); //Generating random spawn point

            GameObject chosenCloud = getCloud();
            if(chosenCloud != null){
                chosenCloud.transform.position = spawnLocation;
                chosenCloud.SetActive(true);
            }
        }
    }

    private GameObject getCloud(){
        for(int i = 0; i < cloudList.Count; i++){ //Finding current inactive cloud in hierarchy
            if(!cloudList[i].activeInHierarchy){
                return cloudList[i];
            }
        }
        return null;
    }
}
