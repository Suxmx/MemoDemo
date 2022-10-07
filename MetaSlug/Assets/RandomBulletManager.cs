using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Face=0;
    public float PerFire = 0.05f;
    public GameObject Bullet;
    bool Wait = false;
    int Rand,NowCount=-1;
    
    float NowTime = 0;
    void Start()
    {
        
        Rand = (int)(Random.Range(0.51f, 9.49f) + 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("WaitMe", 0.1f);
        if (Wait)
        {
            NowTime += Time.deltaTime;
            if (NowCount < Rand)
            {

                //Debug.Log(NowCount);
                //Debug.Log("NowTime=" + NowTime);
                if (NowTime >= PerFire)
                {
                    NowCount++;
                    NowTime = 0;
                    Debug.Log("Fire");
                    GameObject BulletChild = Instantiate(Bullet, transform.position, transform.rotation);
                    BulletChild.GetComponent<Animator>().SetFloat("Rand", (float)Rand);
                    Bullet.GetComponent<PlayerBulletCtrl>().Face = Face;
                    Debug.Log(Face);
                    if (Face == 1)
                    {
                        BulletChild.GetComponent<SpriteRenderer>().flipY = true;
                        BulletChild.GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
            }
            else if (NowCount == Rand)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
    void WaitMe()
    {
        Wait = true;
    }
}
