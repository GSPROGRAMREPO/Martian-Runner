using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LifeIconScript : MonoBehaviour
{
    private int ammountOfLivesDisplayed;
    public int ammountOfLivesLeft;
    private Color invisible;
    private Color visible;

    // Start is called before the first frame update
    void Start(){
        invisible = new Color(1f,1f,1f,0);
        visible = new Color(1f,1f,1f,1);
        ammountOfLivesLeft = GameObject.Find("Player").GetComponent<PlayerController>().playerLifeCount;
        ammountOfLivesDisplayed = ammountOfLivesLeft;
    }

    // Update is called once per frame
    void Update(){

        ammountOfLivesLeft = GameObject.Find("Player").GetComponent<PlayerController>().playerLifeCount;

        if(ammountOfLivesDisplayed != ammountOfLivesLeft){
            ChangeLifeIconAmmount();
            ammountOfLivesDisplayed = ammountOfLivesLeft;
        }
    }

    void ChangeLifeIconAmmount(){
        if(ammountOfLivesLeft == 3){
            GameObject.Find("LifeIcon3").GetComponent<Image>().color = visible;
            GameObject.Find("LifeIcon2").GetComponent<Image>().color = visible;
            GameObject.Find("LifeIcon1").GetComponent<Image>().color = visible;
        }
        if(ammountOfLivesLeft == 2){
            GameObject.Find("LifeIcon3").GetComponent<Image>().color = invisible;
            GameObject.Find("LifeIcon2").GetComponent<Image>().color = visible;
            GameObject.Find("LifeIcon1").GetComponent<Image>().color = visible;
        }
        if(ammountOfLivesLeft == 1){
            GameObject.Find("LifeIcon3").GetComponent<Image>().color = invisible;
            GameObject.Find("LifeIcon2").GetComponent<Image>().color = invisible;
            GameObject.Find("LifeIcon1").GetComponent<Image>().color = visible;
        }
        if(ammountOfLivesLeft == 0){
            GameObject.Find("LifeIcon3").GetComponent<Image>().color = invisible;
            GameObject.Find("LifeIcon2").GetComponent<Image>().color = invisible;
            GameObject.Find("LifeIcon1").GetComponent<Image>().color = invisible;
        }


    }

}
