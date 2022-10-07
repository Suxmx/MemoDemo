using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Enemy;
    public GameObject Trigger;
    void Start()
    {
        Debug.Log(Enemy.Length);
        for(int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i] != null)
            {
                Enemy[i].gameObject.SetActive(true);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
