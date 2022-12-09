using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(25, 0);

    public float jumpForce = 10;
    public float camMoveSpeed = 5f;

    public Transform MainCamera;

    private Rigidbody2D rb2d;
    private Vector2 movement;
    private Vector3 cam;

    public static bool grounded;
    public static bool movingHorizontally;
    public static bool movingVertically;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //aimingLeft = false;
        grounded = false;

    }
    private void FixedUpdate()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckDirection();
        RestartLevel();
        
        cam = new Vector3(transform.position.x, transform.position.y + 5, -10);

       // Vector3 camLerp = new Vector3(MainCamera.position.x, MainCamera.position.y, -10);
        MainCamera.position = Vector3.Lerp(MainCamera.position, cam, camMoveSpeed * Time.deltaTime);   
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

    /*
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
    }*/

    void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(scene.name);

        }
    }

    void Movement()
    {
        if (!WinGameScript.gameWon)
        {
            //Left-right movement
            float moveHorizontal = Input.GetAxis("Horizontal");

            movement = new Vector2(speed.x * moveHorizontal, speed.y);

            movement *= Time.deltaTime;
            transform.Translate(movement);


            //Jumping
            if (Input.GetKey(KeyCode.Space) && grounded)
            {
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }

}
