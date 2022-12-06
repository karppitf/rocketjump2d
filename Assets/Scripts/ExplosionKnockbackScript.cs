using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionKnockbackScript : MonoBehaviour
{

    public float KnockbackAmount = 5f;

    private float timer = 0.1f;

    void Start()
    {

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


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * KnockbackAmount, ForceMode2D.Impulse);
        }

        
    }

}
