using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManExit : MonoBehaviour
{
    Animator Ani;
    public GameObject[] Gifts;
    float Rand;
    int Now;
    public bool IfFirst=false;
    // Start is called before the first frame update
    void Start()
    {   
         Rand =  Random.Range(-0.1f, 2.1f);
        Now = (int)(Rand + 0.5f);
        Ani= GetComponent<Animator>();
        GetComponent<OldManCtrl>().enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&IfFirst)
        {
            IfFirst=false;
            Ani = GetComponent<Animator>();
            Ani = GetComponent<Animator>();
            Ani.SetTrigger("Touched");

            Invoke("Gift", 0.2f);
            Invoke("Move", 0.55f);
            Destroy(this.gameObject,2f);
            
        }
    }
    
    void Gift()
    {
        
        Instantiate(Gifts[Now], transform.position, transform.rotation);
    }    
    void Move()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
    }
    
}
