using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    static Object _instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(this);

        }
        else
            Destroy(this.gameObject);

    }

    public void EnableStartGameUI()
    {
        gameObject.transform.Find("EndLevelCanvas").GetComponent<Canvas>().enabled = false;
        gameObject.transform.Find("ScoreText").GetComponent<Text>().enabled = true;
    }

    public void EnableEndGameUI()
    {
        gameObject.transform.Find("ScoreText").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("EndLevelCanvas").GetComponent<Canvas>().enabled = true;
    }
}
