using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    public int playerXCoordinate;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public int playerLifeCount;
    public PlatformGenerator thePlatformGenerator;
    private float respawnXLocation;
    private float respawnYLocation;
    private bool waitingToResumeGame;


    public float jumpForce;
    public float jumpTime;
    private bool isJumping;
    private float jumpTimeCounter;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;


    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    public GameManager theGameManager;

    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        waitingToResumeGame = false;

        jumpTimeCounter = jumpTime;
        isJumping = false;

        playerLifeCount = 3;

        playerSpeedSetup();

        GetComponent<SpriteRenderer>().color = new Color(.9f,.9f,.9f,1f);
    }

    // Update is called once per frame
    void Update() {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        playerSpeedController();

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        playerJumpInputController();

        if(grounded){
            jumpTimeCounter = jumpTime;
        }

        myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool ("Grounded", grounded);
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "killbox"){
            if(playerLifeCount == 0){
                restartPlayerGame();
            } else{
                respawnPlayer();
            }
        }  
    }

    void playerSpeedSetup(){
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    void playerSpeedController(){
        if(transform.position.x > speedMilestoneCount){
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }
        playerXCoordinate = (int)myRigidbody.position.x;
        playerSpeedLevelAdjuster();
        speedIncreaseMilestoneAdjuster();
    }

    void playerSpeedLevelAdjuster(){
        if(playerXCoordinate == 1000){
            moveSpeed = 8;
        }
        if(playerXCoordinate == 2000){
            moveSpeed = 9;
        }
    }

    void speedIncreaseMilestoneAdjuster(){
        if(playerXCoordinate == 1000){
            speedIncreaseMilestone = 100;
            }
        if(playerXCoordinate == 2000){
            speedIncreaseMilestone = 115;
            }
    }

    void playerJumpInputController(){
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            if(waitingToResumeGame){
                ResumeGame();
            }else{
                playerJumps();  
            }
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)){
            playerKeepsJumping();
        }
        if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0)){
            playerStopsJumping();
        }
    }

    void playerJumps(){
        if(grounded && !EventSystem.current.IsPointerOverGameObject()){
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            isJumping = true;
        }
    }

    void playerKeepsJumping(){
        if(jumpTimeCounter > 0){
            if(isJumping){   
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
    }

    void playerStopsJumping(){
        jumpTimeCounter = 0;
        isJumping = false;
    }

    void respawnPlayer(){
            transportPlayerToSpawnLocation();
            Time.timeScale = 0;
            waitingToResumeGame = true;
            playerLifeCount--;


    }

    public void transportPlayerToSpawnLocation(){
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        respawnXLocation = (thePlatformGenerator.transform.position.x - thePlatformGenerator.distanceBetween);
        respawnYLocation = (thePlatformGenerator.transform.position.y + 1);
        myRigidbody.transform.position = new Vector3(respawnXLocation,respawnYLocation,0);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        waitingToResumeGame = false;
    }

    void restartPlayerGame(){
        theGameManager.RestartGame();
        moveSpeed = moveSpeedStore;
        speedMilestoneCount = speedMilestoneCountStore;
        speedIncreaseMilestone = speedIncreaseMilestoneStore;
    }
}
