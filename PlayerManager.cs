using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    public static PlayerManager Instance { get { return _instance; } }

    // Player object tracking
    private GameObject playerObject;
    private float playerStartZPos;

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


        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerStartZPos = playerObject.transform.position.z;
    }

    // Public methods //

    public Transform GetTransform()
    {
        return playerObject.transform;
    }

    public float GetPlayerStartZPos()
    {
        return this.playerStartZPos;
    }

    public float GetPlayerZPos()
    {
        return GetTransform().position.z;
    }

    public float GetDistanceFromStart()
    {
        return GetTransform().position.z - GetPlayerStartZPos();
    }

    public void DisableMovement()
    {
        playerObject.GetComponent<Player>().DisableMovement();
    }
}
