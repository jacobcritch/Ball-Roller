using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    // Game states
    private bool isGameOver;

    // World objects
    private GameObject floorObject;

    // UI objects
    private GameObject scoreText;
    private GameObject endLevelCanvas;
    private GameObject finalScore;

    // Sound objects
    private AudioSource SFXobject;

    private float playerScore;


    // Private Unity functions //

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        // Find World objects
        floorObject = GameObject.FindGameObjectWithTag("Floor");

        // Find UI objects
        scoreText = GameObject.Find("ScoreText");
        endLevelCanvas = GameObject.Find("EndLevelCanvas");
        finalScore = GameObject.Find("FinalScore");

        // Find Sound objects
        SFXobject = GameObject.Find("DeathSFX").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!isGameOver)
        {
            CheckPlayerHeight();
            UpdateScore();
        }
    }

    // Public methods //

    public void UpdateScore()
    {
        playerScore = PlayerManager.Instance.GetDistanceFromStart();
        scoreText.GetComponent<Text>().text = string.Format("{0:N2}", playerScore);
    }

    public void CheckPlayerHeight()
    {
        if ((PlayerManager.Instance.GetTransform().position.y < floorObject.transform.position.y - 1))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.LogError("Game over!");
            SFXobject.Play();

            PlayerManager.Instance.DisableMovement();
            scoreText.GetComponentInParent<Canvas>().enabled = false;
            finalScore.GetComponent<Text>().text = string.Format("{0:N2}", playerScore);
            endLevelCanvas.GetComponent<Canvas>().enabled = true;
        }
    }
}
