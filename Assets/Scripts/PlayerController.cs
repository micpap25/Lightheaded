using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D pc;
    public Animator anim;
    public ArrayList balloons;
    public float moveSpeed = 1f;
    private bool isFacingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
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
            balloons.RemoveAt(0);
        }

        float value = -1.5f + (.75f * balloons.Count);
        
        /*
        if (balloons.Count == 0)
            value *= 2;
        */
        //Maybe use this line? Consider it.
       
        rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y - .05f));

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reset());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ReturnToMenu());
        }
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
                    // TODO: what? if they have a yellow balloon, kill enemy and the balloon
                }
            }
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("UpperBoundary"))
        {
            balloons.RemoveAt(0);
        }

    }

    private IEnumerator Reset()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while (!async.isDone)
        {
            yield return null;
        }
    }
    private IEnumerator ReturnToMenu()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Menu");
        while (!async.isDone)
        {
            yield return null;
        }
    }

}
