using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public bool IsGameOver { get; private set; }

    // World objects
    private GameObject floorObject;

    // UI objects
    private GameObject mainCanvas;
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
        mainCanvas = GameObject.Find("MainCanvas");
        scoreText = GameObject.Find("ScoreText");
        endLevelCanvas = GameObject.Find("EndLevelCanvas");
        finalScore = GameObject.Find("FinalScore");

        // Find Sound objects
        SFXobject = GameObject.Find("DeathSFX").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!IsGameOver)
        {
            CheckPlayerHeight();
            UpdateScore();
        }
    }

    // Public methods //

    public void UpdateScore()
    {
        playerScore = PlayerManager.Instance.GetDistanceFromStart();
        scoreText.GetComponent<Text>().text = string.Format("{0:N2}", playerScore); // TODO: Add method to MainCanvas script (or UIManager) to update in-game score UI for during game.
    }

    public void CheckPlayerHeight()
    {
        if ((PlayerManager.Instance.GetTransform().position.y < floorObject.transform.position.y - 1))
        {
            EndGame();
        }
    }

    public void RestartGame()
    {
        //GameObject.Find("InputManager").GetComponent<InputManager>().DestroyRb();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        mainCanvas.GetComponent<MainCanvas>().EnableStartGameUI(); // TODO: Make UIManager singleton.

        //GameObject.Find("InputManager").GetComponent<InputManager>().Init();
    }

    public void EndGame()
    {
        if (!IsGameOver)
        {
            IsGameOver = true;
            Debug.LogError("Game over!");
            SFXobject.Play();

            PlayerManager.Instance.DisableMovement();
            finalScore.GetComponent<Text>().text = string.Format("{0:N2}", playerScore); // TODO: Add method to MainCanvas script (or UIManager) to update final score UI for endgame.
            mainCanvas.GetComponent<MainCanvas>().EnableEndGameUI(); // TODO: Make UIManager singleton.
        }
    }
}
