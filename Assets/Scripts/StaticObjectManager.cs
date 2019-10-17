using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjectManager : MonoBehaviour
{

    //This is called from PlatformGenerator Script

    public ObjectPooler[] itemPool;
    private int selectedItem;
    private int spriteRotatingNumber;

    private float spritePositionModifier;

    List<int> plainsList = new List<int>(){0, 1, 2};
    List<int> forestList = new List<int>(){0, 2, 3, 4, 5, 6};

    //Corresponds to the StaticObjectPool Order
    private int Tree1 = 3;
    private int Tree2 = 4;
    private int mushroomBrown = 6;
    private int mushroomRed = 5;

    public GameObject playerCharacter;
    public Vector3 playerCharacterPosition;

    public void Start() {
        playerCharacter = GameObject.Find("Player");
        playerCharacterPosition = playerCharacter.transform.position;
        
    }

    
    public void SpawnObject(Vector3 startPosition){

        startPosition.x +=1;
        GameObject staticItemSelected = itemPool[ItemSelector()].GetPooledObject();

        startPosition.y += spritePositionModifier;

        staticItemSelected.transform.position = startPosition;

        spriteRotatingNumber = Random.Range(0,100);
        if(spriteRotatingNumber > 50){
            staticItemSelected.transform.localRotation = Quaternion.Euler(0, 180, 0);
            staticItemSelected.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            staticItemSelected.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

        }else{
            staticItemSelected.transform.localRotation = Quaternion.Euler(0, 0, 0);
            staticItemSelected.GetComponent<SpriteRenderer>().color = new Color(.9f,.9f,.9f,1);
            staticItemSelected.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            
        }

        playerCharacterPosition = playerCharacter.transform.position;

        staticItemSelected.SetActive(true);
    }

    private int ItemSelector(){
        // Need to get players X Coordinate
        if(playerCharacterPosition.x < 1000){
            selectedItem = plainsList[Random.Range(0, plainsList.Count)];
        }
        if(playerCharacterPosition.x >= 1000){
            selectedItem = forestList[Random.Range(0, forestList.Count)];
        }

        SpriteHightAdjuster(selectedItem);

        return selectedItem;
    }

    private void SpriteHightAdjuster(int selectedItem){
        
        if(selectedItem == Tree1 || selectedItem == Tree2){
            spritePositionModifier = 1.05f;
        }else if(selectedItem == mushroomBrown || selectedItem == mushroomRed){
            spritePositionModifier = -.15f;
        }else{
            spritePositionModifier = 0f;
        }
    }


}
