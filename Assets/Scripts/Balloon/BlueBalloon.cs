using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBalloon : MonoBehaviour, Collectable
{
    public bool tutorial;
    public GameObject enabling;
    public void collide()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerController>().balloons.Count <= 3)
        {
            player.GetComponent<PlayerController>().balloons.Add("Blue");
            player.GetComponent<PlayerController>().AdjustBalloons();
        }
        if (tutorial)
        {
            enabling.SetActive(true);
        }
        Destroy(gameObject);
    }
}
