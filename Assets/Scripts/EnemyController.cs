using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private float lastLerp;
    private bool returning;
    private float maxChange;
    private float dist;
    private float dt;
    public Rigidbody2D rb;
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
        dt = Mathf.Max(dist*Time.deltaTime/travelTime, maxChange);

        if (returning)
        {
            lastLerp += dt;
            transform.position = Vector3.Lerp(startpos, endpos, lastLerp);
        } 
        else
        {
            lastLerp -= dt;
            transform.position = Vector3.Lerp(startpos, endpos, lastLerp);
        }

        if (returning && Vector2.Distance(startpos, transform.position) < Vector2.kEpsilon)
        {
            returning = false;
        }

        if (!returning && Vector2.Distance(endpos, transform.position) < Vector2.kEpsilon)
        {
            returning = true;
        }


    }
    
}
