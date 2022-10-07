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
    
    
    public GameObject PlayerBody;//��ȡ��������Դ�ɶ���ͬ��
    public GameObject Health;//����ϵͳ
    public GameObject FITHFirePoint,FITH;//����
    public GameObject NearAttack;
    public bool IfNearAttack = false;

    bool IsGround;//�Ƿ��ڵ���
    
    
    public float PerFire=0.6f, FireTime=0;//���ʱ����������
    public float vertical;//ˮƽֵ
    public float CameraMove;//Ϊ�˷����ʵ������ͷ�ƶ�
    public float OriginSpeed = 2;//�����ƶ��ٶ�
    public float PlayerBig = 1;
    float speed = 2;//Ŀǰ�����ƶ��ٶ�
    Vector3 offset, UpShootOffset,UpOffset,DownOffset,LeftOffset;
    public GameObject PlayerBullet,TargetedBullet,RandomBullet;//����ӵ�
    

    public Transform RightFirePoint;
    public Transform UpFirePoint,OriginFirePoint,DunFirePoint;//���������

    int FireMode = 1;//����ģʽ
    
    
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
        UpShootOffset =  new Vector3(-0f, 0, 0);//����ʱ�Ķ���ƫ��ֵ -0.08 0.15
        UpOffset= offset +new Vector3(0.02f,0.03f,0);
        DownOffset= offset +new Vector3(0,-0.1f,0);
        LeftOffset = offset + new Vector3(-0.05f, 0, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");//��ȡ�����ƶ�
        
        aniBody.SetFloat("Vertical", vertical);
        aniFoot.SetFloat("Vertical", vertical);//�򶯻���������ֱ�����ֵ
        if (Mathf.Abs(horizontal)>=0.1 &&IsGround)
        {
            aniFoot.SetBool("IsRun", true);
            aniBody.SetBool("IsRun", true);
        }//�ж������Ƿ����˶�������������
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
        transform.Translate(new Vector3(horizontal, 0,0)*Time.deltaTime*speed);//ʵ�������ƶ�
        


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
        if (collision.gameObject.tag == "Ground")//�ж��Ƿ�͵�����ײ
        {
            IsGround = true;
            aniBody.SetBool("IsJump", false);
            aniFoot.SetBool("IsJump", false);//������Ծ����
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//�ж��Ƿ��뿪����
        {
            IsGround = false;
            aniBody.SetBool("IsJump", true);
            aniFoot.SetBool("IsJump", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//�ܻ��ж�
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
    private void OnCollisionEnter2D(Collision2D collision)//�ڳ���ʱ��������ֱ������
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
            FireTime = 0;//���ӿ���ʱ��
            
            if (vertical >= 0.5f)
            {
                UpOffset = UpOffset + UpShootOffset;
                Invoke("OffsetRecover", 0.3f);
            }//�������϶���ƫ��


            //----------------------------------���---------------------------------------------

            if (IfNearAttack)//�����ս������Χ�����е��˾ͽ�ս
            {
                aniBody.SetTrigger("NearAttack");
                NearAttack.SetActive(true);
                NearAttack.transform.Translate(Vector2.right * 0.01f);
                Invoke("StopNearAttack", 0.1f);

            }
            else//���û�о���������Զ�̹���
            {

                aniBody.SetTrigger("Shoot");//�����������
                if (FireMode == 1) FireMode1();
                else if (FireMode == 2) FireMode2();
                else if (FireMode == 3) FireMode3();



                
            }
            //----------------------------------���---------------------------------------------
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
            PlayerBody.transform.position = transform.position + UpOffset;//������ƫ��
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.3616078f, 0.7685583f);//��ԭ��ײ���
            GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.0158039f, 0.2192791f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RightFirePoint.transform.position = DunFirePoint.transform.position;
            vertical = -1;
            PlayerBody.transform.position = transform.position + DownOffset;
            
            //ԭʼ��ײ���0.7685583

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
        // ----------------����----------------
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.K) && IsGround)//��Ծ
        {
            PlayerRG.AddForce(Vector2.up * 110);//����fixedupdate����жϲ�����
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
    void ShootSpawn()//�����������ѡ�������ӵ�������
    {

    }
    void TransShootMode()//�л�����ģʽ
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            FireMode++;
            if (FireMode == 4) FireMode = 1;
        }
    }
    void StopNearAttack()//����
    {
        NearAttack.SetActive(false);
    }
    
    void FireMode1()
    {
        if (vertical >= 0.5f)//�������
        {//�������
            GameObject Bullet = Instantiate(PlayerBullet, UpFirePoint.transform.position, UpFirePoint.rotation);
            if (transform.localScale.x < 0) Bullet.GetComponent<PlayerBulletCtrl>().Face = 2;
            else Bullet.GetComponent<PlayerBulletCtrl>().Face = 1;
        }
        else//ˮƽ���
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
        if (vertical >= 0.5f)//�������
        {//�������
            GameObject Bullet = Instantiate(RandomBullet, UpFirePoint.transform.position, UpFirePoint.rotation);
            if (transform.localScale.x < 0) Bullet.GetComponent<RandomBulletManager>().Face = 2;
            else Bullet.GetComponent<RandomBulletManager>().Face = 1;
        }
        else//ˮƽ���
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
