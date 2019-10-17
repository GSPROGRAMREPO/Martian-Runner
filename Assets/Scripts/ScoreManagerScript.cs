using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public Text scoreText;

    public int scoreCountDistance;
    public int scoreCountTotal;

    public int highScoreTotal;

    public bool scoreIncreasing;

    // Start is called before the first frame update
    void Start(){
        scoreCountTotal = 0;
        scoreIncreasing = true;
        if(PlayerPrefs.HasKey("HighScore")){
            highScoreTotal = PlayerPrefs.GetInt("HighScore");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing){

            scoreCountDistance =  ScoreUpdater();
            scoreCountTotal = scoreCountDistance; // Add coins or whatever else here

            if (scoreCountDistance > 0){
                scoreText.text = "Score: " + (scoreCountTotal);
            }else{
            scoreText.text = "Score: 0"; //Player does not start at 0 x coordinate
        }

        if (scoreCountTotal > highScoreTotal){
            highScoreTotal = scoreCountTotal;
            PlayerPrefs.SetInt("HighScore", highScoreTotal); //Saves value called HighScore and its value on the device
        }

        }
        
    }

    int ScoreUpdater(){

        PlayerController playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreCountDistance = playerScript.playerXCoordinate;

        return scoreCountDistance;
    }
}
