using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManagerScript theScoreManager;

    public DeathMenu theDeathScreen;

    private CoinManager theCoinManager;
    public int playerCoinAmmount;

    // Start is called before the first frame update
    void Start(){
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManagerScript>();
        theCoinManager = FindObjectOfType<CoinManager>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void RestartGame(){

        theScoreManager.scoreIncreasing = false;
        theDeathScreen.gameObject.SetActive(true);

    }

    public void Reset(){

        theDeathScreen.gameObject.SetActive(false);
        thePlayer.transform.position = playerStartPoint;
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i=0; i<platformList.Length; i++){
            platformList[i].gameObject.SetActive(false);
        }

        platformGenerator.position = platformStartPoint;
        theScoreManager.scoreCountTotal = 0;

        playerCoinAmmount = theCoinManager.totalPlayerCoins;
        theCoinManager.SubtractCoins(playerCoinAmmount);

        theScoreManager.scoreIncreasing = true;

    }
}
