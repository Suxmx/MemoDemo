using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPlayerHurt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Health;
    public GameObject Player1;
    public GameObject Player2;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touch");
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hurt");
            //Player1.gameObject.SetActive(true);
            //Player2.gameObject.SetActive(false);
            Health.GetComponent<PlayerHealth>().NowLives--;
        }
    }
}
