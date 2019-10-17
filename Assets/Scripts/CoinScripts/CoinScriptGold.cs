using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScriptGold : MonoBehaviour
{
    private CoinManager theCoinManager;
    public int coinsToGive;
    // Start is called before the first frame update
    void Start(){
        coinsToGive = 10;
        theCoinManager = FindObjectOfType<CoinManager>();
    }
       
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Player"){
            theCoinManager.AddCoins(coinsToGive);
            gameObject.SetActive(false);
        }

    }
}
