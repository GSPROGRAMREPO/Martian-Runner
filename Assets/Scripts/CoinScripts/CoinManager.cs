using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour{

    public int totalPlayerCoins;
    public int onePlayerLife = 1;
    private int playerLives;
    public Text coinText;

    // Start is called before the first frame update
    void Start(){
        playerLives = GameObject.Find("Player").GetComponent<PlayerController>().playerLifeCount;
    }

    // Update is called once per frame
    void Update(){
        coinText.text = " " + (totalPlayerCoins);
        if(playerLives < 3 && totalPlayerCoins >= 100){
            AddLife();
            SubtractCoins(100);
        }


    }

    public void AddCoins(int coinsToAdd){
        totalPlayerCoins += coinsToAdd;
        playerLives = GameObject.Find("Player").GetComponent<PlayerController>().playerLifeCount;
    }

    public void SubtractCoins(int coinsToSubtract){
        totalPlayerCoins -= coinsToSubtract;
    }

    public void AddLife(){
        GameObject.Find("Player").GetComponent<PlayerController>().playerLifeCount += onePlayerLife;
    }

}
