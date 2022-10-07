using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public float PerFireTime=3,PerFireCountTime=0.3f;
    public int Hp=20;
    public float PerFireCountMin,PerFireCountMax;
    int PerFireCount = 2;
    float RandomFireTime,NowTime=0,NowPerFireTime=0;//已经看不懂各种time了 反正坦克射的怎么爽怎么来
    int Count = 0;
    public GameObject Bullet,FirePoint;
    public GameObject[] Tank;
    bool First = true;
    Animator Ani;
    GameObject ScoreUI;
    
    void Start()
    {
        ScoreUI = GameObject.Find("PlayerScoreCtrl");
        Ani= GetComponent<Animator>();
        RandomFireTime = Random.Range(PerFireTime-2f,PerFireTime+3f);
        PerFireCount = (int)Random.Range(PerFireCountMin - 0.1f, PerFireCountMax + 0.1f);
        PerFireCountTime = 0.6f / PerFireCount * 2;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        
    }
    void Shoot()
    {
        NowTime+=Time.deltaTime;
        NowPerFireTime += Time.deltaTime;
        if (NowTime >= RandomFireTime)//每一波开炮时间
        {
            NowTime=0;
            RandomFireTime = Random.Range(PerFireTime - 1f, PerFireTime + 4f);
            Count += PerFireCount;
            PerFireCount = (int)Random.Range(PerFireCountMin - 0.1f, PerFireCountMax + 0.1f);
            PerFireCountTime = 0.9f / PerFireCount * 2;
        }
        if (Count > 0&&NowPerFireTime>PerFireCountTime)//每波里每个子弹之间开炮时间间距
        {
            NowPerFireTime = 0;
            NowTime = 0;
            Count--;
            Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation).GetComponent<TankBulletCtrl>().Speed*=Mathf.Min(PerFireCount,5)/2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp--;
        }
        else if (collision.gameObject.tag == "Bullet5")
        {
            Hp -= 5;
        }
        if (Hp <= 0 && First)
        {
            
            Ani.SetTrigger("Boom");
            
            
            Invoke("DestoryD", 0.1f);
            
            
            
            Destroy(this.gameObject, 1f);
        }
            
    }
    void DestoryD()
    {
        transform.Translate(Vector2.up * 0.5f);
        for(int i = 0; i < Tank.Length; i++)//摧毁其他坦克组件
            {
            ScoreUI.GetComponent<ScoreCtrl>().Score += 1000;
                Destroy(Tank[i]);
            }
    }
}
