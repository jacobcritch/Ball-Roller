using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Object _instance;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(this);

            GetComponent<AudioSource>().Play();
        }
        else
            Destroy(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void Mute() => audioSource.mute = audioSource.mute == false ? true : false;
}
