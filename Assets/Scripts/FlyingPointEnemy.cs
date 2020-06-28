using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPointEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float lastLerp;
    public bool returning;
    public float maxChange;
    public float dist;
    public float dt;
    public Vector2 endpos;
    public Vector2 startpos;
    public int travelTime;

    // Update is called once per frame
    void Update()
    {
        if (returning)
            dist = Vector2.Distance(transform.position, startpos);
        else
            dist = Vector2.Distance(transform.position, endpos);
        dt = Mathf.Min(dist*Time.deltaTime/travelTime, maxChange);

        if (returning)
        {
            lastLerp -= dt;
            transform.position = Vector3.Lerp(startpos, endpos, lastLerp);
        } 
        else
        {
            lastLerp += dt;
            transform.position = Vector3.Lerp(startpos, endpos, lastLerp);
        }

        if (returning && Vector2.Distance(startpos, transform.position) < .5)
        {
            returning = false;
        }

        if (!returning && Vector2.Distance(endpos, transform.position) < .5)
        {
            returning = true;
        }


    }
    
}
