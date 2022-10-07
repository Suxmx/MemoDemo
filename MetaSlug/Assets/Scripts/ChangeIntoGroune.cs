using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIntoGroune : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&collision.transform.position.y>transform.position.y+0.2f)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.tag = "Ground";
            GetComponent<MovingForward>().enabled = true;
            Invoke("StopMovingForward", 2.5f);
        }
    }
    void StopMovingForward()
    {
        GetComponent<MovingForward>().enabled = false;
    }
}
