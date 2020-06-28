using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBalloon : MonoBehaviour, Collectable
{
    public void collide()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerController>().balloons.Count <= 3)
        {
            player.GetComponent<PlayerController>().balloons.Add("Red");
            player.GetComponent<PlayerController>().AdjustBalloons();
        }
        Destroy(gameObject);
    }
}
