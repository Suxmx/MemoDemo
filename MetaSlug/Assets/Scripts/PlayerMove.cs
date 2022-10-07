using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Animator aniFoot,aniBody;
    Rigidbody2D PlayerRG;
    
    
    public GameObject PlayerBody;//获取身体组件以达成动画同步
    public GameObject Health;//生命系统
    public GameObject FITHFirePoint,FITH;//手雷
    public GameObject NearAttack;
    public bool IfNearAttack = false;

    bool IsGround;//是否在地面
    
    
    public float PerFire=0.6f, FireTime=0;//射击时间与射击间隔
    public float vertical;//水平值
    public float CameraMove;//为了方便的实现摄像头移动
    public float OriginSpeed = 2;//人物移动速度
    public float PlayerBig = 1;
    float speed = 2;//目前人物移动速度
    Vector3 offset, UpShootOffset,UpOffset,DownOffset,LeftOffset;
    public GameObject PlayerBullet,TargetedBullet,RandomBullet;//玩家子弹
    

    public Transform RightFirePoint;
    public Transform UpFirePoint,OriginFirePoint,DunFirePoint;//各个开火点

    int FireMode = 1;//开火模式
    
    
    //public Transform LeftFirePoint;
    public int FireInTheHoleCount = 10;
    int NowFITH;

    void Start()
    {
        NowFITH = FireInTheHoleCount;
        PlayerRG = GetComponent<Rigidbody2D>(); 
        aniBody = PlayerBody.GetComponent<Animator>();
        aniFoot= GetComponent<Animator>();
        aniFoot.SetBool("IsRun", false);
        aniBody.SetBool("IsRun", false);
        IsGround = true;
        offset = PlayerBody.transform.position - transform.position;
        UpShootOffset =  new Vector3(-0f, 0, 0);//向上时的动画偏移值 -0.08 0.15
        UpOffset= offset +new Vector3(0.02f,0.03f,0);
        DownOffset= offset +new Vector3(0,-0.1f,0);
        LeftOffset = offset + new Vector3(-0.05f, 0, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");//读取左右移动
        
        aniBody.SetFloat("Vertical", vertical);
        aniFoot.SetFloat("Vertical", vertical);//向动画机传递竖直方向的值
        if (Mathf.Abs(horizontal)>=0.1 &&IsGround)
        {
            aniFoot.SetBool("IsRun", true);
            aniBody.SetBool("IsRun", true);
        }//判断物体是否在运动并联动动画机
        else
        {
            aniFoot.SetBool("IsRun", false);
            aniBody.SetBool("IsRun", false);
        }
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(-1*PlayerBig, 1 * PlayerBig, 1 * PlayerBig);
            PlayerBody.transform.position = transform.position + offset;
        }
        else if (horizontal < 0) 
        {
            transform.localScale = new Vector3(1* PlayerBig, 1 * PlayerBig, 1 * PlayerBig);
            PlayerBody.transform.position = transform.position + LeftOffset;
        }
        transform.Translate(new Vector3(horizontal, 0,0)*Time.deltaTime*speed);//实现左右移动
        


    }
    private void Update()
    {
        
        //scene1 5.5 -2.7
        UpAndDown();//KeyCode=W/S
        Jump();//KeyCode=K
        Shoot();//KeyCode=J
        FireInTheHole();
        TransShootMode();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//判断是否和地面碰撞
        {
            IsGround = true;
            aniBody.SetBool("IsJump", false);
            aniFoot.SetBool("IsJump", false);//联动跳跃动作
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//判断是否离开地面
        {
            IsGround = false;
            aniBody.SetBool("IsJump", true);
            aniFoot.SetBool("IsJump", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//受击判定
    {
        if (collision.gameObject.tag == "SceneTransform")
        {
            CameraMove = collision.transform.position.z;
            transform.Translate(Vector2.right*0.7f);
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            //Debug.Log("Hurt");
            Debug.Log("Health-1 Because of TriggerBullet");
            Health.GetComponent<PlayerHealth>().NowLives -= 1;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Hurt");
            Debug.Log("Health-1 Because of TriggerEnemy");
            Health.GetComponent<PlayerHealth>().NowLives -= 1;
        }
        /*else if(collision.gameObject.tag == "Die")
        {
            Health.GetComponent<PlayerHealth>().LastDeath = 100;
            Health.GetComponent<PlayerHealth>().NowLives -= 1;
            
        }*/

    }
    private void OnCollisionEnter2D(Collision2D collision)//在车上时碰到地面直接死亡
    {
        if (collision.gameObject.tag == "Die")
        {
            Debug.Log("Health-1 Because of Collision Die");
            transform.Translate(Vector2.up*13f);
            Health.GetComponent<PlayerHealth>().LastDeath = 20.49f;
            Health.GetComponent<PlayerHealth>().NowLives -= 1;
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            //Debug.Log("Hurt");
            Debug.Log("Health-1 Because of TriggerBullet");
            Health.GetComponent<PlayerHealth>().NowLives -= 1;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Hurt");
            Debug.Log("Health-1 Because of TriggerEnemy");
            Health.GetComponent<PlayerHealth>().NowLives -= 1;
        }
    }
    void Shoot()
    {
        FireTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.J) && FireTime >= PerFire)
        {
            FireTime = 0;//增加开火时间
            
            if (vertical >= 0.5f)
            {
                UpOffset = UpOffset + UpShootOffset;
                Invoke("OffsetRecover", 0.3f);
            }//处理向上动画偏移


            //----------------------------------射击---------------------------------------------

            if (IfNearAttack)//如果近战攻击范围里面有敌人就近战
            {
                aniBody.SetTrigger("NearAttack");
                NearAttack.SetActive(true);
                NearAttack.transform.Translate(Vector2.right * 0.01f);
                Invoke("StopNearAttack", 0.1f);

            }
            else//如果没有就正常进行远程攻击
            {

                aniBody.SetTrigger("Shoot");//播放射击动画
                if (FireMode == 1) FireMode1();
                else if (FireMode == 2) FireMode2();
                else if (FireMode == 3) FireMode3();



                
            }
            //----------------------------------射击---------------------------------------------
        }
    }
    void OffsetRecover()
    {
        UpOffset = UpOffset - UpShootOffset;
    }
    void UpAndDown()
    {
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
            PlayerBody.transform.position = transform.position + UpOffset;//处理动画偏移
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.3616078f, 0.7685583f);//复原碰撞体积
            GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.0158039f, 0.2192791f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RightFirePoint.transform.position = DunFirePoint.transform.position;
            vertical = -1;
            PlayerBody.transform.position = transform.position + DownOffset;
            
            //原始碰撞体积0.7685583

            GetComponent<CapsuleCollider2D>().size = new Vector2(0.3616078f, 0.55f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.0158039f, 0.10f);
        }
        else
        {
            vertical = 0;
            RightFirePoint.transform.position = OriginFirePoint.transform.position;
            PlayerBody.transform.position = transform.position + offset;
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.27f, 0.65f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.05f, 0.16f);
        }
        if (vertical <= -0.5f)
        {
            speed = OriginSpeed * 0.5f;
        }
        else speed = OriginSpeed;
        // ----------------上下----------------
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.K) && IsGround)//跳跃
        {
            PlayerRG.AddForce(Vector2.up * 110);//放在fixedupdate里会判断不灵敏
        }
    }
    void FireInTheHole()
    {
        if (Input.GetKeyDown(KeyCode.L)&&NowFITH>0)
        {
            NowFITH--;
            if(transform.localScale.x<0)
                Instantiate(FITH, FITHFirePoint.transform.position, FITHFirePoint.transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(1.5f,4)*100);
            else Instantiate(FITH, FITHFirePoint.transform.position, FITHFirePoint.transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.5f, 4) * 100);
        }
    }
    void ShootSpawn()//根据射击类型选择生成子弹的类型
    {

    }
    void TransShootMode()//切换开火模式
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            FireMode++;
            if (FireMode == 4) FireMode = 1;
        }
    }
    void StopNearAttack()//备用
    {
        NearAttack.SetActive(false);
    }
    
    void FireMode1()
    {
        if (vertical >= 0.5f)//向上射击
        {//向上射击
            GameObject Bullet = Instantiate(PlayerBullet, UpFirePoint.transform.position, UpFirePoint.rotation);
            if (transform.localScale.x < 0) Bullet.GetComponent<PlayerBulletCtrl>().Face = 2;
            else Bullet.GetComponent<PlayerBulletCtrl>().Face = 1;
        }
        else//水平射击
        {
            if (transform.localScale.x < 0)
            {
                Instantiate(PlayerBullet, RightFirePoint.transform.position, RightFirePoint.rotation).GetComponent<PlayerBulletCtrl>().Face = 2;
            }
            else
            {
                Instantiate(PlayerBullet, RightFirePoint.transform.position, RightFirePoint.rotation).GetComponent<PlayerBulletCtrl>().Face = 1;
            }
        } 
    }
    void FireMode2()
    {
        Instantiate(TargetedBullet, RightFirePoint.transform.position, RightFirePoint.rotation).GetComponent<PlayerBulletCtrl>();
    }
    void FireMode3()
    {
        FireTime = -0.5f;
        if (vertical >= 0.5f)//向上射击
        {//向上射击
            GameObject Bullet = Instantiate(RandomBullet, UpFirePoint.transform.position, UpFirePoint.rotation);
            if (transform.localScale.x < 0) Bullet.GetComponent<RandomBulletManager>().Face = 2;
            else Bullet.GetComponent<RandomBulletManager>().Face = 1;
        }
        else//水平射击
        {
            if (transform.localScale.x < 0)
            {
                Instantiate(RandomBullet, RightFirePoint.transform.position, RightFirePoint.rotation).GetComponent<RandomBulletManager>().Face = 2;
            }
            else
            {
                Instantiate(RandomBullet, RightFirePoint.transform.position, RightFirePoint.rotation).GetComponent<RandomBulletManager>().Face = 1;
            }
        }
    }

}
