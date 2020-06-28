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
        if (player.GetComponent<PlayerController>().balloons.Count <= 3)
            player.GetComponent<PlayerController>().balloons.Add("Blue");
        if (tutorial)
        {
            enabling.SetActive(true);
        }
        Destroy(gameObject);
    }
}
