using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D pc;
    public Animator anim;
    public AudioSource aud;
    public ArrayList balloons;
    public float moveSpeed = 1f;
    private bool isFacingRight = true;

    public GameObject blueBalloon;
    public GameObject yellowBalloon;
    public GameObject redBalloon;
    public GameObject purpleBalloon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        balloons = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics2D.Raycast(transform.position - new Vector3(pc.bounds.extents.x, pc.bounds.extents.y, 0), Vector2.down, .2f, LayerMask.GetMask("Ground")).collider ||
           Physics2D.Raycast(transform.position + new Vector3(pc.bounds.extents.x, -pc.bounds.extents.y, 0), Vector2.down, .2f, LayerMask.GetMask("Ground")).collider;
        anim.SetBool("grounded", isGrounded);


        if (Input.GetKeyDown(KeyCode.Space) && balloons.Count > 0)
        {
            if (aud.isPlaying)
                aud.Stop();
            balloons.RemoveAt(0);
            AdjustBalloons();
            aud.Play();
        }

        float value = -1.5f + (.75f * balloons.Count);
        
        if (balloons.Count == 0)
            value *= 2;
       
        rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y - .1f));

        if (rb.velocity.y < value) {
            rb.velocity = new Vector2 (rb.velocity.x, value);
        }

        //horizontal movement and flipping the sprite
        float newxvel = Input.GetAxis("Horizontal") * moveSpeed;
        if ((isFacingRight && newxvel < 0) || (!isFacingRight && newxvel > 0))  
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        anim.SetBool("xmove", !(newxvel == 0 && !Input.GetButton("Horizontal")));
        rb.velocity = new Vector2(newxvel, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collectable"))
        {
            col.gameObject.GetComponent<Collectable>().collide();
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            for (int i = 0; i < balloons.Count; i++)
            {
                if (balloons[i].GetType().Equals("Yellow"))
                {
                    Destroy(col.gameObject);
                    balloons.RemoveAt(i);
                    AdjustBalloons();
                    break;
                }
                Destroy(this.gameObject);
            }
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Candle"))
        {
            bool safe = false;
            for (int i = 0; i < balloons.Count; i++)
            {
                if (!balloons[i].GetType().Equals("Red"))
                {
                    balloons.RemoveAt(i);
                    AdjustBalloons();
                }
                else
                {
                    safe = true;
                }
            }
            if (!safe)
                Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("UpperBoundary"))
        {
            balloons.RemoveAt(0);
        }
    }

    public void AdjustBalloons()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < balloons.Count; i++)
        {
            if (i == 0)
            {
                Instantiate(getBalloon((string)balloons[i]), new Vector2(transform.position.x, transform.position.y + .5f), transform.rotation, transform);
            }
            if (i == 1)
            {
                Instantiate(getBalloon((string)balloons[i]), new Vector2(transform.position.x + .25f, transform.position.y + .25f), new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - .25f, 1), transform);
            }
            if (i == 2)
            {
                Instantiate(getBalloon((string)balloons[i]), new Vector2(transform.position.x - .25f, transform.position.y + .25f), new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + .25f, 1), transform);
            }
        }
        
    }

    public GameObject getBalloon(string bal)
    {
        if (bal.Equals("Blue"))
            return blueBalloon;
        if (bal.Equals("Red"))
            return redBalloon;
        if (bal.Equals("Yellow"))
            return yellowBalloon;
        return purpleBalloon;
    }

}
