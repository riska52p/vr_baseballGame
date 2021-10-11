using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    #region Variable
    [SerializeField]
    private GameObject tower; //tower game object
    [SerializeField]
    private GameObject batGB; //bat game object
    [SerializeField]
    private GameObject uiCanvas; //start game canvas gameobject
    [SerializeField]
    private GameObject restartCanvas; //restart game canvas gameobject

    [HideInInspector]
    public GameStatus gameStatus; //the status of the game

    [HideInInspector]
    public enum GameStatus
    {
        Idle,
        Playing
    }

    #endregion

    /// <summary>
    /// The starting of the game,
    /// Initialize the game condition
    /// </summary>
    private void Start()
    {
        RestartGame();
    }

    /// <summary>
    /// What to do when the game is starting.
    /// </summary>
    //[ContextMenu("StartGame")] //for testing
    public void StartGame()
    {
        uiCanvas.SetActive(false); //hide the start canvas
        gameStatus = GameStatus.Playing; //set the game status to be playing 
        batGB.SetActive(true); //show the bat
        restartCanvas.SetActive(true); //show the restart canvas
        tower.GetComponent<BallThrower>().FirstShoot(); //shoot the first ball
    }

    /// <summary>
    /// Restart the scene condition to the initial state
    /// </summary>
    public void RestartGame()
    {
        uiCanvas.SetActive(true); //show the start canvas
        gameStatus = GameStatus.Idle; //set the game status to idle
        batGB.SetActive(false); //hide the bat
        restartCanvas.SetActive(false); //hide the restart canvas
        tower.GetComponent<BallThrower>().InitializeBall(); //initialize the ball position
        batGB.GetComponent<BatCollisionSetting>().ResetScore(); //reset the score to zero
    }
}
