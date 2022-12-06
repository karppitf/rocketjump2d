using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(25, 0);

    public float jumpForce = 10;

    private Rigidbody2D rb2d;
    private Vector2 movement;

    public static bool grounded;
    private bool aimingLeft;

    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        aimingLeft = false;
        grounded = false;
    }


    private void FixedUpdate()
    {

        //Left-right movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        movement = new Vector2(speed.x * moveHorizontal, speed.y);

        movement *= Time.deltaTime;
        transform.Translate(movement);


        //Jumping
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckDirection();
    }


    //Checking if colliding with ground for jumping
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = false;
        }
    }


    //Check if player is moving left and flip sprite if true
    private void CheckDirection()
    {       

        if(aimingLeft)
        {

            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if (movement.x <= 0)
        {         
            aimingLeft = true;
        }
        else if (movement.x >= 0)
        {
            aimingLeft = false;
        }
    }

}
