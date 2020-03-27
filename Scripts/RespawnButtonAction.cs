using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnButtonAction : MonoBehaviour
{
    public void Respawn()
    {
        GameManager.Instance.RestartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
