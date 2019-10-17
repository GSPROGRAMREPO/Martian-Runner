using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour{
    // Start is called before the first frame update

    public GameObject thePlatform;
    public Transform generationPoint;

    private float platformWidth;

    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;
    
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    public float heightChange;

    private CoinGenerator theCoinGenerator;
    private StaticObjectManager theStaticObjectGenerator;
    private EnemyGeneratorManager theEnemyGenerator;
    public float randomCoinThreshold;

    private float rightBoundry;
    private float leftBoundry;
    public float objectLocation;

    void Start(){
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[theObjectPools.Length];

        for(int i=0; i<theObjectPools.Length; i++){
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
        theStaticObjectGenerator = FindObjectOfType<StaticObjectManager>();
        theEnemyGenerator = FindObjectOfType<EnemyGeneratorManager>();
    }

    // Update is called once per frame
    void Update(){
        
        if(transform.position.x < generationPoint.position.x){

            distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
            
            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            PlatformVerticleBounderyCheck();
            PlatformHorizontalBounderyCheck();
            
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();   
            
            CoinGeneration();
            StaticObjectGeneration();
            generateSomeEnemies();


            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }

    void PlatformVerticleBounderyCheck(){

        if(heightChange > maxHeight){
            heightChange = maxHeight;
        } else if(heightChange < minHeight){
            heightChange = minHeight;
        }
    }

    void PlatformHorizontalBounderyCheck(){
        rightBoundry = transform.position.x + distanceBetween + (platformWidths[platformSelector] - 1.5f);
        leftBoundry = transform.position.x + distanceBetween;
    }

    void CoinGeneration(){

            if(Random.Range(0f, 100f) < randomCoinThreshold){
            theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z));
        }
    }

    void StaticObjectGeneration(){

        //Check if it's smallest platform generated
        if(platformWidths[platformSelector] > 3){
            StaticObjectXCoordGenerator();
            AddObjectToPlatform();
            if(IsInForest()){
                StaticObjectXCoordGenerator();
                AddObjectToPlatform();
                }
            if(platformWidths[platformSelector] > 5){
                StaticObjectXCoordGenerator();
                AddObjectToPlatform();

                if(platformWidths[platformSelector] > 7){
                    StaticObjectXCoordGenerator();
                    AddObjectToPlatform();
                    }
                if(IsInForest()){
                    StaticObjectXCoordGenerator();
                    AddObjectToPlatform();

                    StaticObjectXCoordGenerator();
                    AddObjectToPlatform();
                }
            }
        }
    }

    void AddObjectToPlatform(){
        theStaticObjectGenerator.SpawnObject(new Vector3(objectLocation, (transform.position.y + 1f), transform.position.z));
    }

    bool IsInForest(){
        
        if(transform.position.x >= 1000 && transform.position.x < 2000){
            return true;
        }else{
            return false;
        }
    }

    void generateSomeEnemies(){
        theEnemyGenerator.spawnTheEnemy();
    }

    void StaticObjectXCoordGenerator(){

        objectLocation = Random.Range(leftBoundry, rightBoundry);
    }


}
