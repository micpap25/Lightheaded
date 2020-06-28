using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Float : MonoBehaviour
{
    // Start is called before the first frame update
    private float x;
    private Vector2 origpos;
    public float yboundingfactor;
    public float speed;
    void Start()
    {
        x = UnityEngine.Random.Range(0, Mathf.PI);
        origpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(origpos.x, origpos.y + (Mathf.Sin(x)/yboundingfactor));
        x += speed * Time.deltaTime;
    }
}
