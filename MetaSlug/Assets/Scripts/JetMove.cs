using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JetMove : MonoBehaviour
{
    // Start is called before the first frame update
    bool IsDie = false;
    GameObject Left, Right,ScoreCtrl;
    public GameObject Bullet,FirePoint,JetFly;
    Vector3 FaceV;
    int Face = 1;//1右 2左
    public float JetSpeed=1,PerFire=5;
    float NowFire=0,RandomFire;
    public float BulletTime;//射出多个子弹时，每个子弹之间间隔的时间
    public int BulletCount = 3;//单次射出的子弹数
    int Count = 0;
    public int Hp = 10;
    Animator Ani;
    public int Score = 500;
    void Start()
    {
        ScoreCtrl = GameObject.Find("PlayerScoreCtrl");
        Ani = GetComponent<Animator>();
        RandomFire = Random.Range(PerFire - 2, PerFire + 3);
        FaceV = Vector3.right;
        GetComponent<JetEnter>().enabled = false;
        Left = GameObject.Find("JetLeft");
        Right = GameObject.Find("JetRight");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
        PerShoot();
        IfIsDie();
    }
    void Move()
    {
        transform.Translate(FaceV * Time.deltaTime * JetSpeed);
        if (Face == 1)
        {
            //Debug.Log(Vector3.Distance(transform.position, Right.transform.position));
            if (Vector3.Distance(transform.position, Right.transform.position) < 0.05f || transform.position.x > Right.transform.position.x)
            {
                FaceV = Vector3.left;
                Face = 2;
            }
        }
        else
        {
            //Debug.Log(Vector3.Distance(transform.position, Left.transform.position));
            if (Vector3.Distance(transform.position, Left.transform.position) < 0.1f || transform.position.x < Left.transform.position.x)
            {
                FaceV = Vector3.right;
                Face = 1;
            }
        }
    }
    void Shoot()
    {
        NowFire += Time.deltaTime;
        if (NowFire >= RandomFire&&Hp>0)
        {
            RandomFire = Random.Range(PerFire - 2, PerFire + 6);
            NowFire = 0;
            //Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation);
            Count = BulletCount;
            BulletTime = 30;
        }
    }
    void PerShoot()
    {
        BulletTime += Time.deltaTime;
        if (Count > 0&&BulletTime>0.5f && Hp > 0)
        {
            Count--;
            BulletTime = 0;
            Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp--;
        }
        else if(collision.gameObject.tag == "Bullet5")
        {
            Hp -= 5;
        }
        
        
    }
    void IfIsDie()
        {
            if (Hp <= 0 && IsDie == false)
            {
                IsDie = true;
                Ani.SetTrigger("Die");
                this.gameObject.tag = "DieEnemy";
                //GetComponent<Rigidbody2D>().AddForce(Vector3.down * 100);
                JetFly.gameObject.SetActive(false);
                Destroy(gameObject, 1f);
            AddScore();
            }
        }
    void AddScore()
    {
        ScoreCtrl.GetComponent<ScoreCtrl>().Score += Score;
    }
}
