using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionKnockbackScript : MonoBehaviour
{

    public float KnockbackAmount = 5f;

    private float timer = 0.1f;


    //Commented script is experimental angle-distance calculations; doesnt work
    /*
    private Vector2 pos = new Vector2();
    Vector2 origin;
    float distance;
    float angle;
    */

    void Start()
    {
        //origin = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 collisionPoint = collision.ClosestPoint(pos);

        distance = Vector3.Distance(origin, collisionPoint);
        angle = Vector3.Angle(origin, collisionPoint);

        Debug.Log("d: " + distance);
        Debug.Log("a: " + angle);   
        
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Player") && !WallScript.playerIsNearWall)
        {
            if (angle > 7)
            {
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.left * KnockbackAmount * distance, ForceMode2D.Impulse);
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * KnockbackAmount * distance, ForceMode2D.Impulse);
            }
            if (angle < 3)
            {
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.right * KnockbackAmount * distance, ForceMode2D.Impulse);
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * KnockbackAmount * distance, ForceMode2D.Impulse);
            }
        }
        if (collision.gameObject.CompareTag("Player") && WallScript.playerIsNearWall)
        {
            if (angle > 7)
            {
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.left * KnockbackAmount * distance, ForceMode2D.Impulse);
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * KnockbackAmount * distance, ForceMode2D.Impulse);
            }
            if (angle < 3)
            {
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.right * KnockbackAmount * distance, ForceMode2D.Impulse);
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * KnockbackAmount * distance, ForceMode2D.Impulse);
            }
        }*/

        if (collision.gameObject.CompareTag("Player") && WallScript.playerIsNearWall)
        {
             collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * KnockbackAmount * 2, ForceMode2D.Impulse);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * KnockbackAmount, ForceMode2D.Impulse);
        }
    }

}
