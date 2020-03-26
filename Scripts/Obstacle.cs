using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.LogWarning(collision.collider.name + " hit " + this.name);
            GameObject.Find("BlockHitSFX").GetComponent<AudioSource>().Play();
            GameManager.Instance.EndGame();

            //collision.collider.GetComponent<Player>().DisableMovement();
            //GameObject.Find("EndLevelCanvas").GetComponent<Canvas>().enabled = true;
        }
    }
}
