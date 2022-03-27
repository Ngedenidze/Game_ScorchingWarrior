
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{ 
    //yvela cvladi
    public float runSpeed = 40f;
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    private bool isGrounded = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;
    public float movement;
    private float moveInput;
    private int extraJumps = 1 ;


    //rigid bodys shemotana
    private void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
    }
    // horizontaluri poziciis shemotana da horizontze modzraoba

    void FixedUpdate()
    {
        // Move our character
        movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0f, 0f) * Time.deltaTime * runSpeed;

    }
    //axtoma
    void Update()
    {  

        //shemowmeba dgas tuara rameze
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        //shemotrialeba
        if (movement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); 

        } else if (movement <0 ) { transform.eulerAngles = new Vector3(0, 180, 0);  }

        //tu dgas sheudzlia axtoma, tuarada ara + double jump
        if(isGrounded == true)
        {
            extraJumps = 1;
        }
        if (extraJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded==true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;

        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else { isJumping = false; }
        } 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    
}
