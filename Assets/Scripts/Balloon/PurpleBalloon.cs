using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://answers.unity.com/questions/351420/simple-timer-1.html
public class PurpleBalloon : MonoBehaviour, Collectable
{
    public float targetTime = 5.0f;
    public void collide()
    {
         GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player.GetComponent<PlayerController>().balloons.Count <= 3)
        {
            player.GetComponent<PlayerController>().balloons.Add("Purple");
            player.GetComponent<PlayerController>().AdjustBalloons();
        }
        Destroy(gameObject);
    }
}
