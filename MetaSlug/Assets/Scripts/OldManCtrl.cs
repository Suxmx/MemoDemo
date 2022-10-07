using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManCtrl : MonoBehaviour
{
    Animator Ani;
    // Start is called before the first frame update
    void Start()
    {
        Ani= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Destroy(collision.gameObject);
            Ani.SetTrigger("Rescued");
            Invoke("Exit", 0.5f);
        }
    }
    void Exit()
    {
        GetComponent<OldManExit>().enabled = true;
        GetComponent<OldManExit>().IfFirst = true;
    }
}
