using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBalloon : MonoBehaviour, Collectable
{
    public void FixedUpdate()
    {
        //visual stuff while not collected, floating up and down, particles
    }
    public void collide()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().numBalloons++;
        Destroy(gameObject);
    }
}

// modify for yellow, this is just blue
