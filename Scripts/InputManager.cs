using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //GameObject player;

    bool pointerDownLeft, pointerDownRight;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        //Rigidbody rb = GameObject.Find("PlayerBall").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();

        if (rb.gameObject.GetComponent<Player>().Running)
        {
            if (pointerDownLeft)
                rb.AddForce((float)-0.5, 0, 0, ForceMode.VelocityChange);

            else if (pointerDownRight)
                rb.AddForce((float)0.5, 0, 0, ForceMode.VelocityChange);
        }   
    }

    /*
    public void Init()
    {
        Rigidbody rb = GameObject.Find("PlayerBall").GetComponent<Rigidbody>();
    }

    public void DestroyRb()
    {
        Destroy(rb);
    }
    */

    public void PointerDownLeft()
    {

        pointerDownLeft = true;
    }

    public void PointerDownRight()
    {
        pointerDownRight = true;
    }

    public void PointerUpLeft()
    {
        pointerDownLeft = false;
    }

    public void PointerUpRight()
    {
        pointerDownRight = false;
    }
}
