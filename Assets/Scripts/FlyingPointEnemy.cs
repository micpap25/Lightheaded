using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPointEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float lastLerp;
    private bool returning;
    private float dist;
    private float dt;
    public Vector2 endpos;
    public Vector2 startpos;
    public int travelTime;
    public float maxChange;
    public float distToReturn;

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

        if (returning && Vector2.Distance(startpos, transform.position) < distToReturn)
        {
            returning = false;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        if (!returning && Vector2.Distance(endpos, transform.position) < distToReturn)
        {
            returning = true;
            transform.Rotate(new Vector3(0, 180, 0));
        }


    }
    
}
