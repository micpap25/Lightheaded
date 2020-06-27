using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public PolygonCollider2D pc;
    public Animator anim;
    public int numBalloons;
    public float moveSpeed = 1f;
    private bool isFacingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics2D.Raycast(transform.position - new Vector3(pc.bounds.extents.x, pc.bounds.extents.y, 0), Vector2.down, .1f, LayerMask.GetMask("Ground")).collider ||
           Physics2D.Raycast(transform.position + new Vector3(pc.bounds.extents.x, -pc.bounds.extents.y, 0), Vector2.down, .1f, LayerMask.GetMask("Ground")).collider;

        if (Input.GetKeyDown(KeyCode.Space) && numBalloons > 0)
        {
           numBalloons--;
        }

        float value = -1.5f + (.75f * numBalloons);
        if (!isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y - .1f));
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

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

        anim.SetBool("xmove", newxvel != 0);
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
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("UpperBoundary"))
        {
            numBalloons--;
        }

    }
}
