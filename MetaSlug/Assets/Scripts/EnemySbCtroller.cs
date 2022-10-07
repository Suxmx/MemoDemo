using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySbCtroller : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 FaceV;//在玩家的左侧还是右侧
    int Face;
    public float MovingSpeed, PerFire,DisappearTime=6;//开火时间与敌人移动速度
    float FireTime = 0,RandomFire;//开火计时器
    public int Hp = 2;
    public GameObject Player1,Player2,Player;//分别对应正常状态和炮台状态 以及正在使用的Player状态
    public GameObject FirePoint1,Bullet,FirePoint2;
    Animator Ani;
    bool IsDie = false;
    public int Score = 100;
    GameObject ScoreCtrl;

    void Start()
    {
        ScoreCtrl = GameObject.Find("PlayerScoreCtrl");
        RandomFire = Random.Range(PerFire - 2, PerFire + 2);
        FaceV = new Vector2();
        Invoke("EnemyDestory", DisappearTime);//销毁此敌人
        Player1 = GameObject.Find("Player");
        Player2 = GameObject.Find("PlayerBattery");//找到两种状态的玩家
        if (Player1!=null) Player = Player1;//确定现在玩家的状态
        else Player = Player2;

        Ani=GetComponent<Animator>();


        if (transform.position.x > Player.transform.position.x)//敌人在右边生成
        {
            FaceV = Vector2.left*2 + Vector2.down;
            Face = 1;
        }
        else//敌人在左边生成
        {
            GetComponent<SpriteRenderer>().flipX = true;//翻转敌人朝向
            FaceV = Vector2.right*2 + Vector2.down;
            Face = 2;
        }
        FaceV *= 0.7f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(FaceV * MovingSpeed*Time.deltaTime);
    }
    private void Update()
    {
        if (Player1!=null) Player = Player1;//确定现在玩家的状态
        else Player = Player2;
        FireTime += Time.deltaTime;
        if (FireTime >= RandomFire&&Hp>0)
            Shoot();//时间到了就开火
        if (transform.position.x > Player.transform.position.x)//敌人在右边生成
        {
            //FaceV = Vector2.left + Vector2.down;
            GetComponent<SpriteRenderer>().flipX = false;
            Face = 1;
        }
        else//敌人在左边生成
        {
            GetComponent<SpriteRenderer>().flipX = true;//翻转敌人朝向
            //FaceV = Vector2.right + Vector2.down;
            Face = 2;
        }



    }
    void EnemyDestory()
    {
        Destroy(this.gameObject);
    }
    void Shoot()
    {
        FireTime = 0;
        RandomFire = Random.Range(PerFire - 2, PerFire + 6);
        GameObject BulletCloned;
        if(Face==1)BulletCloned = Instantiate(Bullet, FirePoint1.transform.position, FirePoint1.transform.rotation);
        else BulletCloned = Instantiate(Bullet, FirePoint2.transform.position, FirePoint2.transform.rotation);//左右开火点生成子弹
        BulletCloned.GetComponent<EnemySbBulletCtrl>().Face = GetComponent<SpriteRenderer>().flipX == true ? 1 : -1;
        //子弹射击的位置
            //1右-1左
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp--;

        }
        else if (collision.gameObject.tag == "Bullet5")
            Hp -= 5;
        if (Hp <= 0&&IsDie==false)
            {
                IsDie = true;
                Ani.SetTrigger("Die");
                this.gameObject.tag = "DieEnemy";
                GetComponent<Rigidbody2D>().AddForce(Vector3.down * 100);
                Destroy(gameObject,1.5f);
            AddScore();
        }
    }
    void AddScore()
    {
        ScoreCtrl.GetComponent<ScoreCtrl>().Score += Score;
    }
}
