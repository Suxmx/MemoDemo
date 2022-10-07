using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FITHCtrl : MonoBehaviour
{
    public GameObject Inclusive;
    Animator Ani;
    // Start is called before the first frame update
    void Start()
    {
        Ani=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Die"||collision.gameObject.tag=="OldMan")
        {
            Ani.SetTrigger("Boom");
            GetComponent<Rigidbody2D>().gravityScale = 0;
            Inclusive.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy"||collision.gameObject.tag=="Die" || collision.gameObject.tag == "OldMan")
        {
            Ani.SetTrigger("Boom");
            Destroy(GetComponent<Rigidbody2D>());
            Inclusive.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}
