using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler[] coinPool;

    public float distanceBetweenCoins;

    private int goldCoin = 2;
    private int silverCoin = 1;
    private int bronzeCoin = 0;
    private int coinRarity;
    private int coinSelected;



    public void SpawnCoins(Vector3 startPosition){

        GameObject coin1 = coinPool[CoinSelector()].GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool[CoinSelector()].GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool[CoinSelector()].GetPooledObject();
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
        coin3.SetActive(true);

    }

    private int CoinSelector(){

        coinRarity = Random.Range(0, 100);

        if(coinRarity > 94){
            coinSelected = goldCoin;
            return coinSelected;
        }else if(coinRarity > 75){
            coinSelected = silverCoin;
            return coinSelected;
        }else{
            coinSelected = bronzeCoin;
            return coinSelected;
        }
    }
}
