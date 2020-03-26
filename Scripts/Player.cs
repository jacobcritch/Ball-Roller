using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool running;

    Rigidbody rb;

    private void Start()
    {
        running = true;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running)
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
