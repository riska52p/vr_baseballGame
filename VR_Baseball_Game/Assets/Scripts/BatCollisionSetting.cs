using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCollisionSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreText; //3D text to show score

    private int score = 0; //score value

    /// <summary>
    /// Update the score when the ball hit the bat
    /// </summary>
    /// <param name="collision"> ball game object</param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            score++; //Update the score
            scoreText.GetComponent<TextMesh>().text = score.ToString(); //Show the score with 3D text
        }
    }

    /// <summary>
    /// Reset the score to be zero
    /// </summary>
    public void ResetScore()
    {
        score = 0; //Update the score
        scoreText.GetComponent<TextMesh>().text = score.ToString(); //Show the score with 3D text
    }
}
