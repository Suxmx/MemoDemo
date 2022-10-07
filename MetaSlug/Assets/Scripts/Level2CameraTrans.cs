using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2CameraTrans : MonoBehaviour
{
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.transform.Translate(Vector2.right  *Time.deltaTime * 3);
        }
    }
}
