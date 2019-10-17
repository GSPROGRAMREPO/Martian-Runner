using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingNPCController : MonoBehaviour
{
    private Rigidbody2D npcRigidbody;
    public float movementSpeed;
    public float upwardMovementSpeed;
    private bool flippedSprite;
    public GameObject playerCharacter;
    public Vector3 playerCharacterPosition;

    // Start is called before the first frame update
    void Start(){
        playerCharacter = GameObject.Find("Player");
        npcRigidbody = GetComponent<Rigidbody2D>();
        flippedSprite = false;
    }

    // Update is called once per frame
    void Update(){
        playerCharacterPosition = playerCharacter.transform.position;
        npcRigidbody.velocity = new Vector2(movementSpeed, npcRigidbody.velocity.y);
        
        if (playerCharacterPosition.x >= npcRigidbody.position.x){
            FlipSprite();
            npcRigidbody.velocity = new Vector2(0, npcRigidbody.velocity.y);
        }

        if (playerCharacterPosition.x < npcRigidbody.position.x){
            if (flippedSprite == true){
                FlipSpriteBack();
            }
            ResetUpWardMovementSpeed();
        }
    }

    void OnCollisionEnter2D(Collision2D other){   
        if(other.gameObject){
            npcRigidbody.gravityScale = upwardMovementSpeed;
        }

    }

    void FlipSprite(){
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            flippedSprite = true;
        }
    void FlipSpriteBack(){
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void ResetUpWardMovementSpeed(){
        npcRigidbody.gravityScale = 0;
    }
        

}
