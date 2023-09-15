using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
     private float horizontal;

     private float Jump;

     public Transform groundCheck;
     public LayerMask groundLayer;

     bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        horizontal = Input.GetAxisRaw("Horizontal");
        Jump = Input.GetAxisRaw("Jump");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

       if(IsGrounded)
       {
        if (Jump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 6);
        }
       }
    }

}
