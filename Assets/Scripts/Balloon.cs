using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Balloon : Collectable
{
    private string color;

    public Balloon(string colour)
    {
        color = colour;
    }

    public abstract bool isCollision(gameObject otherObject);
    

    
    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }
    */


    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
