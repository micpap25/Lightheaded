using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    public Camera cam;
    public float moveScale;
    private float startpos;
    private float thispos;

    private void Start()
    {
        startpos = cam.transform.position.x;
        thispos = transform.position.x;
    }
    void Update()
    {
        float campos = cam.transform.position.x;
        float xpos = (campos - startpos) * moveScale;
        transform.position = new Vector3(thispos + xpos, transform.position.y, transform.position.z);
        
    }
}
