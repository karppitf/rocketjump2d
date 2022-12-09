using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{

    public static bool playerIsNearWall;

    // Start is called before the first frame update
    void Start()
    {
        playerIsNearWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerIsNearWall = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsNearWall = false;
    }
}
