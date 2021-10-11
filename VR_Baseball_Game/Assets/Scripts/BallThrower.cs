using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    #region Variable
    private GameManager gameManager; //variable to store game manager game object

    #region Ball Variable
    [SerializeField]
    private GameObject ballGB; //ball game object
    private Vector3 ballInitPos; //initial ball position on the tower
    private bool ballInitialized = false; //status to know whether ball position is on the tower
    #endregion

    #region Timer
    private bool timerIsRunning = false; //variable to know whether the time is running or not.
    private float timeRemaining = 15f; //variable to save the time remaining

    #endregion
    #endregion


    /// <summary>
    /// What happened when the application first awaken
    /// </summary>
    private void Awake()
    {
        //assign game manager variable
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        ballInitPos = new Vector3(0f, 1.797f, 3.5925f); //assign ball position on the tower
    }

    /// <summary>
    /// Fixed Update for the timer
    /// </summary>
    private void FixedUpdate()
    {
        if(gameManager.gameStatus == GameManager.GameStatus.Playing)
        {
            if (timerIsRunning) //make sure only run when the timer is running
            {
                if (timeRemaining > 0) //when the time remaining is more than zero
                {
                    timeRemaining -= Time.fixedDeltaTime; //update the time
                    if (timeRemaining < 5f && !ballInitialized) //when the timer is less than 5 seconds
                    {
                        InitializeBall(); //Reset the ball position
                    }
                }
                else // when the time remaining is equal or less than 0
                {
                    timerIsRunning = false; //stop the running timer
                    ShootBall(); //shoot the ball
                }
            }
        }
    }

    /// <summary>
    /// Reset the ball position to be on the tower
    /// </summary>
    public void InitializeBall()
    {
        ballGB.GetComponent<Rigidbody>().isKinematic = true; //to make sure the ball not moving
        ballGB.transform.position = ballInitPos; //set position
        ballGB.transform.rotation = Quaternion.identity; //reset rotation
        ballInitialized = true; //set ball status to be initialized
    }

    /// <summary>
    /// Function to shoot the ball towards the player
    /// </summary>
    //[ContextMenu("ShootBall")] //for testing
    public void ShootBall()
    {
        ballGB.GetComponent<Rigidbody>().isKinematic = false; //to make sure the ball fall on gravity
        Vector3 shoot = new Vector3(0, 0.35f, -1f); //direction of the shooting ball
        ballGB.GetComponent<Rigidbody>().AddForce(shoot * 500f); //the ball will move based on the force added on them
        timeRemaining = 10f; //set the timer
        ballInitialized = false; //set the status of the ball to be shooting
        timerIsRunning = true; //run the timer again
    }

    /// <summary>
    /// Timer for the first shoot of the ball
    /// </summary>
    public void FirstShoot()
    {
        timeRemaining = 2f; //set the timer time
        timerIsRunning = true; //run the timer
    }
}
