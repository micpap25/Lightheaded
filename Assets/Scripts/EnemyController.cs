using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeStartedLerping 
    private float lerpTime;
    public Rigidbody2D rb;
    void Start()
    
    {
        rb = GetComponent<Rigidbody2D>();
        public Vector2 endpos;
        public Vector2 startpos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 xvelocity= Lerp(startpos,endpos, timeSinceStarted).x;
        
        rb.velocity=new Vector2 (xvelocity,rb.velocity.y);
        timeSinceStarted+=Time.deltaTime;


        
    }
    
    public Vector2 Lerp(Vector2 start, Vector2 end, float timeStartedLerping, float lerpTime=1){
        float timeSinceStarted= Time.time - timeStartedLerping;
        float percentage =timeSinceStarted/lerpTime;
        Vector2 result = Vector2.Lerp(start,end, percentage);
        return result;
    }
}
