using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// made by melissa, feel free to ask questions
// https://answers.unity.com/questions/351420/simple-timer-1.html
public class PurpleBalloon : MonoBehaviour, Collectable
{
    public float targetTime = 5.0f;
    public GameObject player = GameObject.FindGameObjectWithTag("Player"); //up here so i can kill
    public void FixedUpdate()
    {
        //visual stuff while not collected, floating up and down, particles
    }
    public void collide()
    {
        
        player.GetComponent<PlayerController>().numBalloons++;
        Destroy(gameObject);
    }

    public void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        Destroy(player);
        GUI.TextField(new Rect(580, 250, 100, 20), "The Purple Balloon has eaten you."); //death message
    }
}
