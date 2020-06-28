using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBalloon : MonoBehaviour, Collectable
{
    public bool tutorial;
    public GameObject enabling;
    public void FixedUpdate()
    {
        //visual stuff while not collected, floating up and down, particles
    }
    public void collide()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().numBalloons++;
        if (tutorial)
        {
            enabling.SetActive(true);
        }
        Destroy(gameObject);
    }
}
