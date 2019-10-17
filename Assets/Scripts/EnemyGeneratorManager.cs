using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorManager : MonoBehaviour{

    
    public ObjectPooler[] enemyPool;
    private float enemySpawnXLocation;
    private float enemySpawnYLocation;
    private float ammountOfEnemiesSpawn;
    private int randomEnemyChoice;
    private float EnemyHightVarience;
    private bool answer;

    public void spawnTheEnemy(){
        if (EnemyShouldSpawn()){
            GameObject enemySelected = enemyPool[whichEnemiesToSpawn()].GetPooledObject();
            enemySelected.transform.position = new Vector3(getEnemyXLocation(),getEnemyYLocation(),1f);
            enemySelected.SetActive(true);
        }
    }


    bool EnemyShouldSpawn(){
        if (Random.Range(0, 100) > 60){
            answer = true;
        }else{
            answer = false;
        }
        return answer;
    }

    int whichEnemiesToSpawn(){
        randomEnemyChoice = Random.Range(0,enemyPool.Length);
        return randomEnemyChoice;
    }

    float getEnemyXLocation(){
        enemySpawnXLocation = GameObject.Find("PlatformGenerator").GetComponent<PlatformGenerator>().objectLocation + 2;
        return enemySpawnXLocation;
    }

    float getEnemyYLocation(){
        EnemyHightVarience = Random.Range(1f, 2f);
        enemySpawnYLocation = (GameObject.Find("PlatformGenerator").GetComponent<PlatformGenerator>().heightChange + EnemyHightVarience);
        return enemySpawnYLocation;
    }
}
