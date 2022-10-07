using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMove : MonoBehaviour
{
    Transform Firetransform;
    // Start is called before the first frame update
    public float TotalHorizontal=0,PerFire=0.3f;//开火间隔与总水平状态
    float horizontal = 0;//用于记录GetAxis
    float FireTime=0;//距离上一次开火的时间
    public int BatterySpeed=10,Now;//炮台移动速度与炮台目前状态
    public GameObject Player,Bullet,BatteryAnime;//获取人物与子弹以及开火动画
    Animator BatteryAni, PlayerAni;//获取动画机
    public Transform Hand2;
    public Transform Hand3;
    public Transform Hand4;
    public Transform Hand5;
    public Transform Hand6;
    public Transform Hand7;
    public Transform Hand8;//握持点
    public Transform Fire0;
    public Transform Fire1; 
    public Transform Fire2;
    public Transform Fire3;
    public Transform Fire4;
    public Transform Fire5;
    public Transform Fire6;
    public Transform Fire7;
    public Transform Fire8;
    void Start()
    {
        BatteryAni=GetComponent<Animator>();  
        PlayerAni=Player.GetComponent<Animator>();//获取炮台和角色的Animator
        TransPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");//实现线性左右移动角色与炮台
        if(Mathf.Abs(TotalHorizontal+horizontal)<=9&&Player.gameObject.active==true)//将上限稍微设大一点
            TotalHorizontal+=Time.deltaTime*horizontal*BatterySpeed;

        BatteryAni.SetFloat("Horizontal", Mathf.Abs(TotalHorizontal));//与动画机联动
        PlayerAni.SetFloat("Horizontal", Mathf.Abs(TotalHorizontal));

        transform.localScale=new Vector3(TotalHorizontal >= 0?-1f:1f,1f,1f);//设置炮台和角色的朝向
       // Player.transform.localScale = new Vector3(TotalHorizontal >= 0 ? 1f : -1f, 1f, 1f);
        Player.GetComponent<SpriteRenderer>().flipX = TotalHorizontal >= 0?false:true;

        TransPosition();
        




    }
    private void Update()
    {
        FireTime+=Time.deltaTime;
        if (Input.GetKey(KeyCode.J) && FireTime >= PerFire&&Player.gameObject.active==true)
        {
            Shoot();
        }    

    }
    void Shoot()
    {
        
        FireTime = 0;
        if (Now == 0)
        {
            Firetransform = Fire0;
        }
        else if (Now == 1)
        {
            Firetransform = Fire1;
        }
        else if (Now == 2)
        {
            Firetransform = Fire2;
        }
        else if (Now == 3)
        {
            Firetransform = Fire3;
        }
        else if (Now == 4)
        {
            Firetransform = Fire4;
        }
        else if (Now == 5)
        {
            Firetransform = Fire5;
        }
        else if (Now == 6)
        {
            Firetransform = Fire6;
        }
        else if (Now == 7)
        {
            Firetransform = Fire7;
        }
        else if (Now == 8)
        {
            Firetransform = Fire8;
        }
        BatteryAnime.transform.position = Firetransform.position;
        BatteryAnime.transform.rotation = Firetransform.rotation;
        BatteryAnime.gameObject.SetActive(true);
        Invoke("StopFire", 0.5f);
        GameObject BulletObject = Instantiate(Bullet, Firetransform.position, Firetransform.rotation);
        BulletObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.x, 1);

    }
    void StopFire()
    {
        BatteryAnime.gameObject.SetActive(false);
    }
    void TransPosition()//实现人物跟随炮台移动
    {
        Now = (int)(Mathf.Abs(TotalHorizontal) + 0.5f);//判断目前所处的状态
        if (Now == 2)
        {
            Player.transform.position = Hand2.position;
        }
        else if (Now == 3)
        {
            Player.transform.position = Hand3.position;
        }
        else if (Now == 4)
        {
            Player.transform.position = Hand4.position;
        }
        else if (Now == 5)
        {
            Player.transform.position = Hand5.position;
        }
        else if (Now == 6)
        {
            Player.transform.position = Hand6.position;
        }
        else if (Now == 7)
        {
            Player.transform.position = Hand7.position;
        }
        else if (Now >= 8)
        {
            Player.transform.position = Hand8.position;//读取每个状态角色应该处于的位置
        }
    }
}
