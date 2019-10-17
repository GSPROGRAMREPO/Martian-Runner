using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parallax : MonoBehaviour
{
    
    private float backgroundLength;
    private float backgroundStartPosition;
    public GameObject backgroundCamera;
    public float parallaxEffect;
    private float distanceRelativeToCamera;
    private float distance;
    public Sprite background2;
    public Sprite background3;

    // Start is called before the first frame update
    void Start(){
        backgroundStartPosition = transform.position.x;
        backgroundLength = (GetComponent<SpriteRenderer>().bounds.size.x);
    }

    // Update is called once per frame
    void Update(){
        distanceRelativeToCamera = (backgroundCamera.transform.position.x * (1 - parallaxEffect));
        distance = (backgroundCamera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(backgroundStartPosition + distance, transform.position.y, transform.position.z);

        if (distanceRelativeToCamera > (backgroundStartPosition) + (backgroundLength)){
            backgroundStartPosition += ((backgroundLength)*2f);
        }

        if (backgroundCamera.transform.position.x > 1000 && backgroundCamera.transform.position.x < 2000){
            BackgroundChangerForest();
            GetComponent<SpriteRenderer>().color = new Color(.9f, .95f, .90f, 1);
        }

        if (backgroundCamera.transform.position.x > 2000){
            BackgroundChangerCastle();
            GetComponent<SpriteRenderer>().color = new Color(.4f, .4f, .4f, 1);
        }



    }

    void BackgroundChangerForest(){
        GetComponent<SpriteRenderer>().sprite = background2;
    }

    void BackgroundChangerCastle(){
        GetComponent<SpriteRenderer>().sprite = background3;
    }

}
