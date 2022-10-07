using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    Transform StartPoint;
    GameObject Battery,PlayerStand,Camera,Player,Scene;
    public GameObject Enemy;
    public GameObject PlayerHealth;
    public Transform EndPoint;
    
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Scene = GameObject.Find("WhileScene");
        Camera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        Battery = GameObject.Find("Battery");
        PlayerStand = GameObject.Find("PlayerStandPoint");
        
        
        offset = Camera.transform.position-transform.position+Vector3.up*0.75f;//��ȡ��ʼ�����ƫ��ֵ

        
        
        Player.gameObject.GetComponent<PlayerMove>().enabled=false;//����ʱ�رն���ҵĿ����Է�bug
        Battery.gameObject.GetComponent<BoxCollider2D>().enabled = false;//����ͬ��
        StartPoint= transform;
        Invoke("AwakePlayer", 2.2f);//������ѿ����Լ���̨��ʹ��
        Invoke("AwakeSceneLoop", 2.2f);//��ʼ������ѭ��
        Invoke("AwakeHealth", 3.5f);//����һ��ʱ����޵�
        Invoke("AwakeEnemySpawn", 2.3f);//��ʼ��������
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(StartPoint.position, EndPoint.position,Time.deltaTime*0.6f);//��ֵʵ���ƶ�
        Player.transform.position = PlayerStand.transform.position;//ʹ��ɫʵʱ���泵
        Player.GetComponent<Animator>().SetBool("IsJump", false);
        Camera.transform.position = offset + transform.position;//����ͷ����
    }
    void AwakePlayer()//������ɫ����̨ʹ��
    {
        Player.gameObject.GetComponent<PlayerMove>().enabled = true;
        
        Battery.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    void AwakeSceneLoop()
    {
        Scene.GetComponent<SceneLoop>().enabled = true;
    }
    
    void AwakeEnemySpawn()
    {
        Enemy.gameObject.SetActive(true);
    }
    void AwakeHealth()
    {
        PlayerHealth.gameObject.SetActive(true);    
    }
}
