using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemySpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTrigger")
        {
            EnemySpawn.SetActive(true);
        }
    }
}
