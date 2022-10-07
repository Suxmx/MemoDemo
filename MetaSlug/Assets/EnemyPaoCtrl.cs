using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaoCtrl : MonoBehaviour
{
    public GameObject FirePoint, Bullet;
    public float PerFireTime;
    
    float FireTimeRandom;
    float NowFireTime = 0;
    GameObject Player;
    int Face = 1;//目前朝向，1左2右
    // Start is called before the first frame update
    void Start()
    {
        FireTimeRandom = Random.Range(PerFireTime - 1f, PerFireTime + 2f);
        Player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Flip();
    }
    void Shoot()
    {
        NowFireTime += Time.deltaTime;
        if (NowFireTime >= FireTimeRandom)
        {
            NowFireTime = 0;
            FireTimeRandom = Random.Range(PerFireTime - 1f, PerFireTime + 2f);

            Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation).GetComponent<EnemySbBulletCtrl>().Face = Face;


        }
    }
    void Flip()
    {
        if (Player != null)
        {
            if (Player.transform.position.x < transform.position.x)//敌人在左边
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                Face = 2;
            }
            else//敌人在右边
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                Face = 1;
            }
        }
    }
    

}
