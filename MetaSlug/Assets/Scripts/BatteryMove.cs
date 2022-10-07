using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMove : MonoBehaviour
{
    Transform Firetransform;
    // Start is called before the first frame update
    public float TotalHorizontal=0,PerFire=0.3f;//����������ˮƽ״̬
    float horizontal = 0;//���ڼ�¼GetAxis
    float FireTime=0;//������һ�ο����ʱ��
    public int BatterySpeed=10,Now;//��̨�ƶ��ٶ�����̨Ŀǰ״̬
    public GameObject Player,Bullet,BatteryAnime;//��ȡ�������ӵ��Լ����𶯻�
    Animator BatteryAni, PlayerAni;//��ȡ������
    public Transform Hand2;
    public Transform Hand3;
    public Transform Hand4;
    public Transform Hand5;
    public Transform Hand6;
    public Transform Hand7;
    public Transform Hand8;//�ճֵ�
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
        PlayerAni=Player.GetComponent<Animator>();//��ȡ��̨�ͽ�ɫ��Animator
        TransPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");//ʵ�����������ƶ���ɫ����̨
        if(Mathf.Abs(TotalHorizontal+horizontal)<=9&&Player.gameObject.active==true)//��������΢���һ��
            TotalHorizontal+=Time.deltaTime*horizontal*BatterySpeed;

        BatteryAni.SetFloat("Horizontal", Mathf.Abs(TotalHorizontal));//�붯��������
        PlayerAni.SetFloat("Horizontal", Mathf.Abs(TotalHorizontal));

        transform.localScale=new Vector3(TotalHorizontal >= 0?-1f:1f,1f,1f);//������̨�ͽ�ɫ�ĳ���
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
    void TransPosition()//ʵ�����������̨�ƶ�
    {
        Now = (int)(Mathf.Abs(TotalHorizontal) + 0.5f);//�ж�Ŀǰ������״̬
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
            Player.transform.position = Hand8.position;//��ȡÿ��״̬��ɫӦ�ô��ڵ�λ��
        }
    }
}
