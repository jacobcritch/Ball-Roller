using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool running;
    public bool Running { get => running; private set => running = value; }

    Rigidbody rb;

    private void Start()
    {
        running = true;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running) // TODO: Add all this stuff to a InputManager
        {
            rb.AddForce(0, 0, 20); // Add forward force

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb.AddForce((float)-0.5, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb.AddForce((float)0.5, 0, 0, ForceMode.VelocityChange);
            }
        }
        else
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return)) && GameManager.Instance.IsGameOver)
            {
                GameManager.Instance.RestartGame();
            }
        }
    }

    public void DisableMovement()
    {
        running = false;
    }

    public void EnableMovement()
    {
        running = true;
    }
}
