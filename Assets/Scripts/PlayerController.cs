using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public Rigidbody rb;
     public int numberOfBalloons;
     public Transform transform;
     public bool alive;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform= GetComponent<Transform>();
        alive=true;
        numberOfBalloons=0;
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space) numberOfBalloons > 0)
        {
           numberOfBalloons--;
        }

     if (numberOfBalloons==0)
    {
        Physics2D.gravity=new Vector2(0f, -9.81f);
    }
     else if (numberOfBalloons==1)
     {
          Physics2D.gravity=new Vector2(0f, -7.35f);
     }
     else if (numberOfBalloons==2)
     {
          Physics2D.gravity=new Vector2(0f, 0f);
     }

     else if (numberOfBalloons==3){
         Physics2D.gravity=new Vector2(0f,2.45f);
     }      

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Balloon"))
        {
            Destroy(other.gameObject);
            numberOfBalloons++;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("UpperBoundary"))
        {
           
            numberOfBalloons--;
        }

    }
}
