using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int Lives=10,NowLives=10;
    public GameObject Player,PlayerBody,End;
    public float LastDeath = 3;
    public float UnHurt=2.5f;//�ܷ���
    
    

    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {

        Camera = GameObject.Find("Main Camera");
        //Player = GameObject.Find("Player");
        //PlayerBody = GameObject.Find("PlayerBody");
    }

    // Update is called once per frame
    void Update()
    {
        LastDeath += Time.deltaTime;
        if (Lives > NowLives&&LastDeath>=UnHurt)//����⵽�����仯�ͽ���Die����
        {
            LastDeath = 0;
            Die();
        }
        else if(Lives>NowLives)
        {
            NowLives++;
        }
        
    }
    void Die()
    {
        PlayerBody.SetActive(false);//���������Ա㲥�Ŷ���
        Player.GetComponent<PlayerMove>().enabled = false;
        Player.GetComponent<Animator>().SetTrigger("Die");//���ƽŵĶ����������ƶ���
        if (NowLives > 0)//������������ͼ�һ������
        {
            Lives = NowLives;
            Invoke("ReBurn", 0.6f);
        }
        else
        {
            End.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void ReBurn()
    {
        
        PlayerBody.SetActive(true);//�ָ�����
        Player.transform.position = Camera.transform.position + Vector3.up * 5+new Vector3(-3,0,10);//���Ϸ�׹��
        Invoke("AwakeMove",1);
    }
    void AwakeMove()
    {
        Player.GetComponent<PlayerMove>().enabled = true;
    }
    
}
