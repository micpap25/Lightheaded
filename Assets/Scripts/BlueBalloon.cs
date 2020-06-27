using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBalloon : MonoBehaviour, Collectable
{
    public void collide()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().numberOfBalloons++;
        Destroy(gameObject);
    }
}
