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
        GameObject.Find("EndLevelCanvas").GetComponent<Canvas>().enabled = false;

        gameObject.transform.Find("LeftTouchButton").GetComponent<Image>().enabled = true;
        gameObject.transform.Find("RightTouchButton").GetComponent<Image>().enabled = true;
        GameObject.Find("LeftTouchButtonText").GetComponent<Text>().enabled = true;
        GameObject.Find("RightTouchButtonText").GetComponent<Text>().enabled = true;

        gameObject.transform.Find("ScoreText").GetComponent<Text>().enabled = true;
    }

    public void EnableEndGameUI()
    {
        gameObject.transform.Find("ScoreText").GetComponent<Text>().enabled = false;

        gameObject.transform.Find("LeftTouchButton").GetComponent<Image>().enabled = false;
        gameObject.transform.Find("RightTouchButton").GetComponent<Image>().enabled = false;
        GameObject.Find("LeftTouchButtonText").GetComponent<Text>().enabled = false;
        GameObject.Find("RightTouchButtonText").GetComponent<Text>().enabled = false;

        GameObject.Find("EndLevelCanvas").GetComponent<Canvas>().enabled = true;
    }
}
