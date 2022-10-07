using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DiLeiCrtl : MonoBehaviour
{
    bool First = true;
    // Start is called before the first frame update
    Animator Ani;
    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Ani.SetTrigger("Boom");
            Destroy(this.gameObject, 0.6f);
        }
        else if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bullet5"&& First)
        {   
            First = false;
            Ani.SetTrigger("Boom");
            gameObject.tag = "DieEnemy";
            Destroy(this.gameObject,0.6f);

        }
    }
    
}
