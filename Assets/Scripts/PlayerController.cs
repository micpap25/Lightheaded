using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public PolygonCollider2D pc;
    public int numBalloons;
    public float moveSpeed = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
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
        if (isGrounded)
        {
            value = Mathf.Max(value, 0);
        }

        if (rb.velocity.y < value) {
            rb.velocity = new Vector2 (rb.velocity.x, value);
        }



        //horizontal movement

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

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
