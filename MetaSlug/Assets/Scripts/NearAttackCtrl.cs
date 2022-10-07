using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearAttackCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    float Bug = 0,PerBug=1.6f;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Bug+=Time.deltaTime;
        if (Bug >= PerBug)
        {
            Bug = 0;
            Player.GetComponent<PlayerMove>().IfNearAttack = false;
        }
        transform.position = Player.transform.position; 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "OldMan")
        {
            Player.GetComponent<PlayerMove>().IfNearAttack=false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "OldMan")
        {
            Player.GetComponent<PlayerMove>().IfNearAttack = true;
        }
    }
}
