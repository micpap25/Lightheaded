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
        if (player.GetComponent<PlayerController>().balloons.Count <= 3)
            player.GetComponent<PlayerController>().balloons.Add("Yellow");
        Destroy(gameObject);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        Destroy(gameObject);
        Destroy(enemy);
    }
}
